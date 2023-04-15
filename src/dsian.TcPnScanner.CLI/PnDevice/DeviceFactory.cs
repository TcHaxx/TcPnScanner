using dsian.TcPnScanner.CLI.Packets;

namespace dsian.TcPnScanner.CLI.PnDevice;

internal static class DeviceFactory
{
    internal static Device CreateFromPacket(ProfinetDcpIdentRequestPacket dcpIdentRequestPacket)
    {
        Guard.ThrowIfNull(dcpIdentRequestPacket.FakePhysicalAddress);
        return new Device(dcpIdentRequestPacket.FakePhysicalAddress, dcpIdentRequestPacket.NameOfStation);
    }
}
