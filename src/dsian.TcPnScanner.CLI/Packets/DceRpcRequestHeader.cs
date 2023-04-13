using System.Runtime.InteropServices;

namespace dsian.TcPnScanner.CLI.Packets;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
internal struct DceRpcRequestHeader
{
    public byte Version;
    public byte Type;
    public byte Flags1;
    public byte Flags2;
    public byte ByteOrder;      // 1=LittleEndian
    public byte Character;      // 0=ASCII
    public byte FloatingPoint;  // 0=IEEE
    public byte SerialHigh;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
    public byte[] ObjectUUID;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
    public byte[] InterfaceUUID;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
    public byte[] Activity;
    public uint ServerBootTime;
    public uint InterfaceVersion;
    public uint SequenceNumber;
    public ushort OpNumber;
    public ushort InterfaceHint;
    public ushort ActivityHint;
    public ushort FragmentLength;
    public ushort FragmentNumber;
    public byte AuthProto;          // 0=None
    public byte SerialLow;
}
