using dsian.TcPnScanner.CLI.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace dsian.TcPnScanner.CLI.PnDevice;

/// <summary>
/// Represents a Profinet Device.
/// </summary>
/// <param name="PhysicalAddress"></param>
/// <param name="NameOfStation"></param>
/// <param name=""></param>
internal record Device(PhysicalAddress PhysicalAddress, string NameOfStation)
{
    public IPAddress IpAddress { get; set; } = IPAddress.None;
    public ProfinetIoConnectRequestPacket? PnIoConnectRequestPacket { get; set; }
}
