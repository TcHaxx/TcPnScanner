using Microsoft.Extensions.Logging;
using PacketDotNet;
using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace dsian.TcPnScanner.CLI.Packets
{
    internal sealed class ProfinetDcpIdentRequestPacket
    {
        public const ushort FRAME_ID_REQ = 0xfefe;
        public const ushort FRAME_ID_RES = 0xfeff;

        public ushort FrameID { get; init; }
        public PnDcpServiceId ServiceId { get; init; }
        public PnDcpServiceType ServiceType { get; init; }
        public uint Xid { get; init; }
        public ushort DcpDataLength { get; init; }
        public string NameOfStation { get; init; } = string.Empty;
        public PhysicalAddress? FakePhysicalAddress { get; private set; }
        public Packet? SourcePacket { get; init; }
        private ProfinetDcpIdentRequestPacket()
        {
        }

        internal static bool TryParse(Packet packet, [NotNullWhen(true)] out ProfinetDcpIdentRequestPacket? pndcpPacket, ILogger? logger = default)
        {
            pndcpPacket = default;

            try
            {
                if (!packet.TryGetPacketPayload(out var payloadData))
                {
                    return false;
                }

                if (!IsDynamicConfigurationProtocol(payloadData))
                {
                    return false;
                }

                pndcpPacket = Create(packet, payloadData);
            }
            catch (Exception ex)
            {
                logger?.LogError(ex, "Parsing \"PN-DCP Ident Req\" failed");
            }

            return pndcpPacket is not null;
        }

        private static bool IsDynamicConfigurationProtocol(ReadOnlySpan<byte> payloadData)
        {
            return BinaryPrimitives.ReadUInt16BigEndian(payloadData) == FRAME_ID_REQ;
        }

        private static ProfinetDcpIdentRequestPacket? Create(Packet packet, ReadOnlySpan<byte> payloadData)
        {
            var serviceId = payloadData[2];
            if (serviceId != (byte)PnDcpServiceId.Identify)
            {
                return default;
            }
            var serviceType = payloadData[3];
            if (serviceType != (byte)PnDcpServiceType.Request)
            {
                return default;
            }

            var pnDcpIdentReqPacket = new ProfinetDcpIdentRequestPacket
            {
                SourcePacket = packet,
                FrameID = BitConverter.ToUInt16(payloadData),
                ServiceId = (PnDcpServiceId)serviceId,
                ServiceType = (PnDcpServiceType)serviceType,
                Xid = BitConverter.ToUInt32(payloadData.Slice(4, sizeof(uint))),
                DcpDataLength = ParseDcpDataLength(payloadData[10..]),
                NameOfStation = ParseName(payloadData[12..])
            };
            pnDcpIdentReqPacket.FakePhysicalAddress = PhysicalAddressExtensions.CreateFakePhysicalAddress(pnDcpIdentReqPacket.Xid);
            if (string.IsNullOrEmpty(pnDcpIdentReqPacket.NameOfStation))
            {
                return default;
            }

            return pnDcpIdentReqPacket;
        }

        private static ushort ParseDcpDataLength(ReadOnlySpan<byte> readOnlySpan)
        {
            var dcpDataLength = BinaryPrimitives.ReadUInt16BigEndian(readOnlySpan);
            if (readOnlySpan.Length - 2 < dcpDataLength)
            {
                throw new InvalidDataException($"Invalid DCP data length {dcpDataLength}.");
            }
            return dcpDataLength;
        }
        private static string ParseName(ReadOnlySpan<byte> readOnlySpan)
        {
            var option = readOnlySpan[0];
            var suboption = readOnlySpan[1];

            if (option != 2 || suboption != 2)
            {
                return string.Empty;
            }

            var dcpBlockLength = BinaryPrimitives.ReadUInt16BigEndian(readOnlySpan[2..4]);
            var stationName = Encoding.UTF8.GetString(readOnlySpan.Slice(4, dcpBlockLength));
            return stationName;
        }
    }
}
