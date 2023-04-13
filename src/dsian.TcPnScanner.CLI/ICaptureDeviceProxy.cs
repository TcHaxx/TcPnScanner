using PacketDotNet;
using SharpPcap;
using SharpPcap.LibPcap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsian.TcPnScanner.CLI
{
    internal interface ICaptureDeviceProxy : IPcapDevice
    {
        PcapDevice PcapDevice { get; init; }
        void SendPacketHandler(Packet p);

        event EventHandler<Packet>? OnPacketSend;
    }
}
