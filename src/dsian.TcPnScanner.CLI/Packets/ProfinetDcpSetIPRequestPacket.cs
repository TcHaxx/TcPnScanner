using PacketDotNet;
using System.Buffers.Binary;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace dsian.TcPnScanner.CLI.Packets;

internal sealed class ProfinetDcpSetIPRequestPacket
{
    public const ushort FRAME_ID_REQ = 0xfefd;
    public const ushort FRAME_ID_RES = 0xfefd;

    public ushort FrameID { get; init; }
    public PnDcpServiceId ServiceId { get; init; }
    public PnDcpServiceType ServiceType { get; init; }
    public uint Xid { get; init; }
    public ushort DcpDataLength { get; init; }
    public IPAddress IpAddress { get; init; } = IPAddress.None;
    public uint SubnetMask { get; init; }
    public uint StandardGateway { get; init; }


    public Packet? SourcePacket { get; init; }
    private ProfinetDcpSetIPRequestPacket()
    {
    }

    internal static bool TryParse(Packet packet, [NotNullWhen(true)] out ProfinetDcpSetIPRequestPacket? pndcpPacket)
    {
        pndcpPacket = default;

        if (!packet.TryGetPacketPayload(out var payloadData))
        {
            return false;
        }

        if (!IsDynamicConfigurationProtocol(payloadData))
        {
            return false;
        }

        pndcpPacket = Create(packet, payloadData);

        return pndcpPacket is not null;
    }

    private static bool IsDynamicConfigurationProtocol(ReadOnlySpan<byte> payloadData)
    {
        return BinaryPrimitives.ReadUInt16BigEndian(payloadData) == FRAME_ID_REQ;
    }

    private static ProfinetDcpSetIPRequestPacket? Create(Packet packet, ReadOnlySpan<byte> payloadData)
    {
        var frameID = BitConverter.ToUInt16(payloadData);

        var serviceId = (PnDcpServiceId)payloadData[2];
        if (serviceId != PnDcpServiceId.Set)
        {
            return default;
        }
        var serviceType = (PnDcpServiceType)payloadData[3];
        if (serviceType != PnDcpServiceType.Request)
        {
            return default;
        }

        var xid = BitConverter.ToUInt32(payloadData.Slice(4, sizeof(uint)));
        var dcpDataLength = ParseDcpDataLength(payloadData[10..]);

        var option = payloadData[12];
        if (option != 1)
        {
            return default;
        }

        var suboption = payloadData[13];
        if (suboption != 2)
        {
            return default;
        }

        var ipAddress = new IPAddress(payloadData[18..22]);
        var subnetMask = BinaryPrimitives.ReadUInt32BigEndian(payloadData[22..26]);
        var gateway = BinaryPrimitives.ReadUInt32BigEndian(payloadData[26..30]);

        var pnDcpSetIPReqPacket = new ProfinetDcpSetIPRequestPacket
        {
            SourcePacket = packet,
            FrameID = frameID,
            ServiceId = serviceId,
            ServiceType = serviceType,
            Xid = xid,
            DcpDataLength = dcpDataLength,
            IpAddress = ipAddress,
            SubnetMask = subnetMask,
            StandardGateway = gateway
        };

        return pnDcpSetIPReqPacket;
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
}
