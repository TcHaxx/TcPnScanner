namespace dsian.TcPnScanner.CLI.Packets;


public struct DataDescription
{
    public DataDescriptionTypeEnum DataDescriptionType;
    public ushort SubmoduleDataLength;
    public byte LengthIOCS;
    public byte LengthIOPS;

    internal static bool TryDeserialize(BinaryReader reader, out DataDescription dataDescription)
    {
        dataDescription = default;

        if (reader.BaseStream.Length is < 6)
        {
            return false;
        }

        dataDescription.DataDescriptionType = GetDataDescriptionType(reader);
        if (dataDescription.DataDescriptionType is DataDescriptionTypeEnum.Unknown)
        {
            return false;
        }

        dataDescription.SubmoduleDataLength = reader.ReadUInt16BigEndian();
        dataDescription.LengthIOCS = reader.ReadByte();
        dataDescription.LengthIOPS = reader.ReadByte();

        return true;
    }
    private static DataDescriptionTypeEnum GetDataDescriptionType(BinaryReader reader)
    {
        var type = (DataDescriptionTypeEnum)reader.ReadUInt16BigEndian() switch
        {
            DataDescriptionTypeEnum.Input => DataDescriptionTypeEnum.Input,
            DataDescriptionTypeEnum.Output => DataDescriptionTypeEnum.Output,
            _ => DataDescriptionTypeEnum.Unknown
        };

        return type;
    }
}
