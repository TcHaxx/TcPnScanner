using Microsoft.Extensions.Logging;
using PacketDotNet;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

namespace dsian.TcPnScanner.CLI.Packets
{
    internal sealed class ProfinetIoConnectRequestPacket
    {
        public DceRpcRequestHeader DceRpcRequestHeader { get; private set; }

        public uint ArgsMaximum { get; private set; }
        public uint ArgsLength { get; private set; }
        public uint ArrayMaximumCount { get; private set; }
        public uint ArrayOffset { get; private set; }
        public uint ArrayActualCount { get; private set; }

        public ARBlockReqHeader ARBlockReqHeader { get; private set; }

        public IOCRBlockReq IOCRBlockReqInput { get; private set; }
        public IOCRBlockReq IOCRBlockReqOutput { get; private set; }

        public List<ExpectedSubmoduleBlockReq> ExpectedSubmoduleBlockRequests { get; private set; } = new();

        public PhysicalAddress DestinationHardwareAddress { get; private set; } = PhysicalAddress.None;
        public IPAddress IPAddress { get; private set; } = IPAddress.None;

        private ProfinetIoConnectRequestPacket()
        {
        }
        internal static bool TryParse(Packet packet, [NotNullWhen(true)] out ProfinetIoConnectRequestPacket? pnIoConReqPacket, ILogger? logger = default)
        {

            pnIoConReqPacket = default;
            try
            {
                if (!packet.HasPayloadPacket || packet.PayloadPacket is null)
                {
                    return false;
                }
                var payloadPacket = packet.PayloadPacket;
                if (packet.PayloadPacket is not IPv4Packet ipv4Packet
                    || ipv4Packet.Protocol != ProtocolType.Udp
                    || !ipv4Packet.HasPayloadPacket
                    || ipv4Packet.DestinationAddress.GetAddressBytes().Last() == 0xff)
                {
                    return false;
                }

                if (ipv4Packet.PayloadPacket is not UdpPacket udpPacket || !udpPacket.HasPayloadData)
                {
                    return false;
                }

                if (!MarshalAs.TryDeserializeStruct<DceRpcRequestHeader>(udpPacket.PayloadData, out var dceRpcRequestHeader))
                {
                    logger?.LogWarning($"Ignoring packet, due to invalid {nameof(DceRpcRequestHeader)}");
                    logger?.LogDebug("Couldn't deserialize {DceRpcRequestHeader} from packet content:\n{UdpPacketContent)}", nameof(DceRpcRequestHeader), udpPacket.PrintHex());
                    return false;
                }

                if (dceRpcRequestHeader.Type != 0x0 || dceRpcRequestHeader.FragmentLength == 0)
                {
                    logger?.LogWarning("Ignoring DCE/RPC Request Header: Packet type={DceRpcReqHeaderType} with Fragment length={DceRpcReqHeaderFragmentLength}",
                        dceRpcRequestHeader.Type, dceRpcRequestHeader.FragmentLength);
                    return false;
                }

                pnIoConReqPacket = new ProfinetIoConnectRequestPacket
                {
                    DestinationHardwareAddress = (packet as EthernetPacket)!.DestinationHardwareAddress,
                    IPAddress = ipv4Packet.DestinationAddress,
                    DceRpcRequestHeader = dceRpcRequestHeader
                };

                using MemoryStream memoryStream = new(udpPacket.PayloadData[Marshal.SizeOf(typeof(DceRpcRequestHeader))..]);
                using BinaryReader binaryReader = new(memoryStream);
                pnIoConReqPacket.ParseArgsAndArray(binaryReader);

                while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
                {
                    if (!BlockHeader.TryDeserializePeek(binaryReader, out var blockHeader))
                    {
                        throw new InvalidDataException($"Couldn't deserialize {nameof(BlockHeader)} at position {binaryReader.BaseStream.Position} from packet content:\n{udpPacket.PrintHex()}");
                    }

                    switch (blockHeader.BlockType)
                    {
                        case BlockType.ARBLockReq:
                            if (!ARBlockReqHeader.TryDeserialize(binaryReader, out var arBlockReqHeader))
                            {
                                throw new InvalidDataException($"Couldn't deserialize {nameof(ARBlockReqHeader)} from packet content:\n{udpPacket.PrintHex()}");
                            }
                            pnIoConReqPacket.ARBlockReqHeader = arBlockReqHeader;
                            break;
                        case BlockType.IOCRBlockReq:
                            ParseIOCRBlockReq(pnIoConReqPacket, binaryReader, udpPacket);
                            break;
                        case BlockType.ExpectedSubmoduleBlockReq:
                            pnIoConReqPacket.ExpectedSubmoduleBlockRequests = pnIoConReqPacket.GetExpectedSubmodules(binaryReader);
                            break;
                        case BlockType.AlarmCRBlockReq: // TODO: Implement (currently not needed)
                        case BlockType.Unknown:
                            AdvanceBinaryReaderByBlockLength(binaryReader, blockHeader);
                            break;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                logger?.LogError(ex, "Parsing \"PNIO-CM Connect Req\" failed");
                return false;
            }
        }

        private static void AdvanceBinaryReaderByBlockLength(BinaryReader binaryReader, BlockHeader blockHeader)
        {
            binaryReader.BaseStream.Position += blockHeader.BlockLength + 4;
        }

        private static void ParseIOCRBlockReq(ProfinetIoConnectRequestPacket pnIoConReqPacket, BinaryReader binaryReader, UdpPacket udpPacket)
        {
            if (!IOCRBlockReq.TryDeserialize(binaryReader, out var ioCRBlockReq))
            {
                throw new InvalidDataException($"Couldn't deserialize {nameof(ioCRBlockReq)} from packet content:\n{udpPacket.PrintHex()}");
            }
            if (ioCRBlockReq.IOCRType == 0x1)
            {
                pnIoConReqPacket.IOCRBlockReqInput = ioCRBlockReq;
            }
            else if (ioCRBlockReq.IOCRType == 0x2)
            {
                pnIoConReqPacket.IOCRBlockReqOutput = ioCRBlockReq;
            }
            else
            {
                throw new InvalidDataException($"Expected IOCRType of 0x1 or 0x2, but got {ioCRBlockReq.IOCRType}");
            }
        }

        private void ParseArgsAndArray(BinaryReader reader)
        {
            ArgsMaximum = reader.ReadUInt32();
            ArgsLength = reader.ReadUInt32();
            ArrayMaximumCount = reader.ReadUInt32();
            ArrayOffset = reader.ReadUInt32();
            ArrayActualCount = reader.ReadUInt32();
        }

        private List<ExpectedSubmoduleBlockReq> GetExpectedSubmodules(BinaryReader reader)
        {
            var result = new List<ExpectedSubmoduleBlockReq>();

            while (ExpectedSubmoduleBlockReq.TryDeserialize(reader, out var expSubModule) &&
                expSubModule.BlockHeader.BlockType == BlockType.ExpectedSubmoduleBlockReq)
            {
                result.Add(expSubModule);
            }

            return result;
        }
    }
}
