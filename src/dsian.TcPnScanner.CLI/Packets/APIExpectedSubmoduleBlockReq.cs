namespace dsian.TcPnScanner.CLI.Packets;

internal struct APIExpectedSubmoduleBlockReq
{
    public const ushort MAX_NUMBER_OF_SUBMODULES = 255;     // TODO: arbitrary limit, needs clarification
    public uint APIId;
    public ushort SlotNumber;
    public uint ModuleIdentNumber;
    public ushort ModuleProperties;
    public ushort NumberOfSubmodules;
    public Submodule[] Submodules;

    internal static bool TryParse(BinaryReader reader, out APIExpectedSubmoduleBlockReq api)
    {
        api = new();

        api.APIId = reader.ReadUInt32BigEndian();
        api.SlotNumber = reader.ReadUInt16BigEndian();
        api.ModuleIdentNumber = reader.ReadUInt32BigEndian();
        api.ModuleProperties = reader.ReadUInt16BigEndian();
        api.NumberOfSubmodules = reader.ReadUInt16BigEndian();

        if (api.NumberOfSubmodules is < 1 or > MAX_NUMBER_OF_SUBMODULES)
        {
            return false;
        }

        api.Submodules = DeserializeSubmodules(reader, api.NumberOfSubmodules);

        return true;
    }

    private static Submodule[] DeserializeSubmodules(BinaryReader reader, ushort length)
    {
        var subModules = new Submodule[length];
        for (var i = 0; i < subModules.Length; i++)
        {
            if (!Submodule.TryDeserialize(reader, out var submodule))
            {
                continue;
            }
            subModules[i] = submodule;
        }
        return subModules;
    }
}
