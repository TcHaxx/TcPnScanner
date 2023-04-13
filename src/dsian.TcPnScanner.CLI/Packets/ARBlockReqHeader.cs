using System.Buffers.Binary;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;

namespace dsian.TcPnScanner.CLI.Packets;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
internal struct ARBlockReqHeader
{
    public BlockHeader BlockHeader;
    public ushort ARType;
    public Guid ARUUID;
    public ushort SessionKey;
    public PhysicalAddress CMInitiatorMacAdd;
    public Guid ARUCMInitiatorObjectUUID;
    public uint ARProperties;
    public ushort CMInitiatorActivityTimeoutFactor;
    public ushort CMInitiatorUDPRTPort;
    public ushort StationNameLength;
    public string CMInitiatorStationName;
    internal static bool TryDeserialize(BinaryReader reader, out ARBlockReqHeader arBlockReqHeader)
    {
        arBlockReqHeader = default;

        var result = new ARBlockReqHeader();

        if (!BlockHeader.TryDeserialize(reader, out result.BlockHeader) ||
            result.BlockHeader.BlockType != BlockType.ARBLockReq)
        {
            return false;
        }

        result.ARType = reader.ReadUInt16BigEndian();

        result.ARUUID = new Guid(reader.ReadBytes(16));

        result.SessionKey = reader.ReadUInt16BigEndian();

        result.CMInitiatorMacAdd = new PhysicalAddress(reader.ReadBytes(6));

        result.ARUCMInitiatorObjectUUID = new Guid(reader.ReadBytes(16));

        result.ARProperties = reader.ReadUInt32();
        result.CMInitiatorActivityTimeoutFactor = reader.ReadUInt16BigEndian();
        result.CMInitiatorUDPRTPort = reader.ReadUInt16BigEndian();

        result.StationNameLength = reader.ReadUInt16BigEndian();

        byte[] stringBytes = reader.ReadBytes(result.StationNameLength);
        result.CMInitiatorStationName = Encoding.ASCII.GetString(stringBytes).TrimEnd('\0');

        arBlockReqHeader = result;
        return true;
    }
}
