using PacketDotNet;

namespace dsian.TcPnScanner.CLI.Packets;

internal static class PacketPayloadExtensions
{
    internal static bool TryGetPacketPayload(this Packet packet, out byte[] packetPayload)
    {
        packetPayload = Array.Empty<byte>();

        if (packet.HasPayloadData)
        {
            packetPayload = packet.PayloadData;
            return true;
        }
        else if (packet.HasPayloadPacket && packet.PayloadPacket.HasPayloadData)
        {
            packetPayload = packet.PayloadPacket.PayloadData;
            return true;
        }

        return false;
    }
}
