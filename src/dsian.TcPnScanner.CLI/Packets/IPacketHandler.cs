using PacketDotNet;

namespace dsian.TcPnScanner.CLI.Packets;

public interface IPacketHandler
{
    public void HandleEthernetPacket(EthernetPacket ethPacket);
}
