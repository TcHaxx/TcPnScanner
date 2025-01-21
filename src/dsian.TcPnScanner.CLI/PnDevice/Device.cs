using dsian.TcPnScanner.CLI.Packets;
using System.Net;
using System.Net.NetworkInformation;

namespace dsian.TcPnScanner.CLI.PnDevice;

/// <summary>
/// Represents a Profinet Device.
/// </summary>
/// <param name="PhysicalAddress"></param>
/// <param name="NameOfStation"></param>
internal record Device(PhysicalAddress PhysicalAddress, string NameOfStation)
{
    public IPAddress IpAddress { get; set; } = IPAddress.None;
    public ProfinetIoConnectRequestPacket? PnIoConnectRequestPacket { get; set; }
}
