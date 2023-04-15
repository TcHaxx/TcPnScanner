namespace dsian.TcPnScanner.CLI.Packets;

internal enum BlockType : ushort
{
    Unknown,
    ARBLockReq = 0x0101,
    IOCRBlockReq = 0x0102,
    AlarmCRBlockReq = 0x0103,
    ExpectedSubmoduleBlockReq = 0x0104
}

internal struct BlockHeader
{
    public BlockType BlockType;
    public ushort BlockLength;
    public byte BlockVersionHigh;
    public byte BlockVersionLow;
    internal static bool TryDeserialize(BinaryReader reader, out BlockHeader blockHeader)
    {
        blockHeader = default;

        if (reader.BaseStream.Position + 6 > reader.BaseStream.Length)
        {
            return false;
        }
        blockHeader = new()
        {
            BlockType = BlockTypeFromUint16(reader.ReadUInt16BigEndian()),
            BlockLength = reader.ReadUInt16BigEndian(),
            BlockVersionHigh = reader.ReadByte(),
            BlockVersionLow = reader.ReadByte()
        };
        return true;
    }
    internal static bool TryDeserializePeek(BinaryReader reader, out BlockHeader blockHeader)
    {
        var readerStartPos = reader.BaseStream.Position;

        var result = TryDeserialize(reader, out blockHeader);

        reader.BaseStream.Position = readerStartPos;
        return result;
    }
    private static BlockType BlockTypeFromUint16(ushort value)
    {
        switch (value)
        {
            case (ushort)BlockType.ARBLockReq: return BlockType.ARBLockReq;
            case (ushort)BlockType.IOCRBlockReq: return BlockType.IOCRBlockReq;
            case (ushort)BlockType.AlarmCRBlockReq: return BlockType.AlarmCRBlockReq;
            case (ushort)BlockType.ExpectedSubmoduleBlockReq: return BlockType.ExpectedSubmoduleBlockReq;
            default:
                return BlockType.Unknown;
        }
    }
}
