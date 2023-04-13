using dsian.TcPnScanner.CLI.Packets;
using PacketDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsian.TcPnScanner.CLI.PnDevice
{
    internal static class DeviceFactory
    {
        internal static Device CreateFromPacket(ProfinetDcpIdentRequestPacket dcpIdentRequestPacket)
        {
            Guard.ThrowIfNull(dcpIdentRequestPacket.FakePhysicalAddress);
            return new Device(dcpIdentRequestPacket.FakePhysicalAddress, dcpIdentRequestPacket.NameOfStation);
        }
    }
}
