using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dsian.TcPnScanner.CLI.Packets
{
    internal static class BinaryReaderExtensions
    {
        internal static ushort ReadUInt16BigEndian(this BinaryReader reader)
        {
            return BinaryPrimitives.ReadUInt16BigEndian(BitConverter.GetBytes(reader.ReadUInt16()));
        }
        internal static uint ReadUInt32BigEndian(this BinaryReader reader)
        {
            return BinaryPrimitives.ReadUInt32BigEndian(BitConverter.GetBytes(reader.ReadUInt32()));
        }
    }
}
