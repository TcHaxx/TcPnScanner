using System.Runtime.InteropServices;

namespace dsian.TcPnScanner.CLI.Packets;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
internal struct ExpectedSubmoduleBlockReq
{
    public BlockHeader BlockHeader;
    public ushort NumberOfAPIs;
    public APIExpectedSubmoduleBlockReq[] APIs;

    internal static bool TryDeserialize(BinaryReader reader, out ExpectedSubmoduleBlockReq expSubModuleBlockReq)
    {
        expSubModuleBlockReq = default;

        var result = new ExpectedSubmoduleBlockReq();

        if (!BlockHeader.TryDeserialize(reader, out result.BlockHeader) ||
            result.BlockHeader.BlockType != BlockType.ExpectedSubmoduleBlockReq)
        {
            return false;
        }

        result.NumberOfAPIs = reader.ReadUInt16BigEndian();

        if (result.NumberOfAPIs is < 1)
        {
            return false;
        }

        result.APIs = DeserializeAPIs(reader, result.NumberOfAPIs);

        expSubModuleBlockReq = result;
        return true;
    }

    private static APIExpectedSubmoduleBlockReq[] DeserializeAPIs(BinaryReader reader, ushort length)
    {
        var apis = new APIExpectedSubmoduleBlockReq[length];
        for (int i = 0; i < length; i++)
        {
            if (!APIExpectedSubmoduleBlockReq.TryParse(reader, out var api))
            {
                continue;
            }
            apis[i] = api;
        }

        return apis;
    }

}
