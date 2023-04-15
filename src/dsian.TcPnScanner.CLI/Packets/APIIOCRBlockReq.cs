using System.Runtime.InteropServices;

namespace dsian.TcPnScanner.CLI.Packets;

internal struct APIIOCRBlockReq
{
    public const ushort MAX_NUMBER_OF_IO_DATAOBJECTS = 255;     // TODO: arbitrary limit, needs clarification
    public uint APIId;
    public ushort NumberOfIODataObjects;
    public IODataObject[] IODataObjects;
    public ushort NumberOfIOCs;
    public IODataObject[] IOCs;
    internal static bool TryParse(BinaryReader reader, out APIIOCRBlockReq api)
    {
        api = new();

        api.APIId = reader.ReadUInt32BigEndian();
        api.NumberOfIODataObjects = reader.ReadUInt16BigEndian();
        if (api.NumberOfIODataObjects is > MAX_NUMBER_OF_IO_DATAOBJECTS)
        {
            return false;
        }

        var lenCalc = api.NumberOfIODataObjects * Marshal.SizeOf<IODataObject>();
        if (reader.BaseStream.Length < lenCalc)
        {
            return false;
        }

        api.IODataObjects = DeserializeIOObjects(reader, api.NumberOfIODataObjects);

        api.NumberOfIOCs = reader.ReadUInt16BigEndian();
        if (api.NumberOfIOCs is < 1 or > MAX_NUMBER_OF_IO_DATAOBJECTS)
        {
            return true;
        }

        lenCalc = api.NumberOfIOCs * Marshal.SizeOf<IODataObject>();
        if (reader.BaseStream.Length < lenCalc)
        {
            return false;
        }

        api.IOCs = DeserializeIOObjects(reader, api.NumberOfIOCs);

        return true;
    }

    private static IODataObject[] DeserializeIOObjects(BinaryReader reader, ushort length)
    {
        var ioObjects = new IODataObject[length];
        for (var i = 0; i < ioObjects.Length; i++)
        {
            if (!IODataObject.TryDeserialize(reader, out var apiIoDataObject))
            {
                continue;
            }
            ioObjects[i] = apiIoDataObject;
        }
        return ioObjects;
    }
}
