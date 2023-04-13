using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

namespace dsian.TcPnScanner.CLI.Packets;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
internal struct IOCRBlockReq
{
    public BlockHeader BlockHeader;
    public ushort IOCRType;
    public ushort IOCRReference;
    public ushort LT;
    public uint IOCRProperties;
    public ushort DataLength;
    public ushort FrameID;
    public ushort SendClockFactor;
    public ushort ReductionRatio;
    public ushort Phase;
    public ushort Sequence;
    public uint FrameSendOffset;
    public ushort WatchdogFactor;
    public ushort DataHoldFactor;
    public ushort IOCRTagHeader;
    public PhysicalAddress IOCRMultiCastMACAdd;
    public ushort NumberOfAPIs;
    public APIIOCRBlockReq[] APIs;

    internal static bool TryDeserialize(BinaryReader reader, out IOCRBlockReq ioCRBlockReq)
    {
        ioCRBlockReq = default;

        var result = new IOCRBlockReq();

        if (!BlockHeader.TryDeserialize(reader, out result.BlockHeader) ||
            result.BlockHeader.BlockType != BlockType.IOCRBlockReq)
        {
            return false;
        }
        result.IOCRType = reader.ReadUInt16BigEndian();
        result.IOCRReference = reader.ReadUInt16BigEndian();
        result.LT = reader.ReadUInt16BigEndian();
        result.IOCRProperties = reader.ReadUInt32BigEndian();
        result.DataLength = reader.ReadUInt16BigEndian();
        result.FrameID = reader.ReadUInt16BigEndian();
        result.SendClockFactor = reader.ReadUInt16BigEndian();
        result.ReductionRatio = reader.ReadUInt16BigEndian();
        result.Phase = reader.ReadUInt16BigEndian();
        result.Sequence = reader.ReadUInt16BigEndian();
        result.FrameSendOffset = reader.ReadUInt32BigEndian();
        result.WatchdogFactor = reader.ReadUInt16BigEndian();
        result.DataHoldFactor = reader.ReadUInt16BigEndian();
        result.IOCRTagHeader = reader.ReadUInt16BigEndian();
        result.IOCRMultiCastMACAdd = new PhysicalAddress(reader.ReadBytes(6));
        result.NumberOfAPIs = reader.ReadUInt16BigEndian();

        if (result.NumberOfAPIs is < 1)
        {
            return false;
        }

        result.APIs = DeserializeAPIs(reader, result.NumberOfAPIs);


        ioCRBlockReq = result;
        return true;
    }

    private static APIIOCRBlockReq[] DeserializeAPIs(BinaryReader reader, ushort length)
    {
        var apis = new APIIOCRBlockReq[length];
        for (int i = 0; i < length; i++)
        {
            if (!APIIOCRBlockReq.TryParse(reader, out var api))
            {
                continue;
            }
            apis[i] = api;
        }

        return apis;
    }
}
