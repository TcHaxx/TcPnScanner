using System.Runtime.InteropServices;

namespace dsian.TcPnScanner.CLI.Packets;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
internal struct IODataObject
{
    public ushort SlotNumber;
    public ushort SubSlotNumber;
    public ushort FrameOffset;
    internal static bool TryDeserialize(BinaryReader reader, out IODataObject ioDataObject)
    {
        ioDataObject = new IODataObject();
        if (reader.BaseStream.Length < 6)
        {
            return false;
        }
        ioDataObject.SlotNumber = reader.ReadUInt16BigEndian();
        ioDataObject.SubSlotNumber = reader.ReadUInt16BigEndian();
        ioDataObject.FrameOffset = reader.ReadUInt16BigEndian();
        return true;
    }
}
