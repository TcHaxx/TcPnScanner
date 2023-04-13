using dsian.TcPnScanner.CLI.Packets;
using System.Diagnostics.CodeAnalysis;

namespace dsian.TcPnScanner.CLI.PnDevice
{
    internal interface IDeviceStore
    {
        bool TryAddDevice(Device device);
        bool TryUpdateIpAddress(ProfinetDcpSetIPRequestPacket dcpSetIpReqPacket);
        bool TryFindDevice(Func<Device, bool> predicate, [MaybeNullWhen(false)] out Device device);
        bool UpdatePnIoConnectRequestPacket(ProfinetIoConnectRequestPacket profinetIoConnectRequestPacket);
        int Count { get; }
        IEnumerable<Device> GetDevices();
        event EventHandler? OnAllDevicesScanned;
        string GetProfinetDeviceName();
    }
}
