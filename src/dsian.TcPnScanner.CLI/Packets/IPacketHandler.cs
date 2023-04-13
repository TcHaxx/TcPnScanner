using PacketDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsian.TcPnScanner.CLI.Packets
{
    public interface IPacketHandler
    {
        public void HandleEthernetPacket(EthernetPacket ethPacket);
    }
}
