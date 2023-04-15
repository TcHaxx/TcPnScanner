using System.Runtime.InteropServices;

namespace dsian.TcPnScanner.CLI.Packets;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
internal struct Submodule
{
    public ushort SubslotNumber;
    public uint SubmoduleIdentNumber;
    public ushort SubmoduleProperties;
    public DataDescription DataDescriptionInput;
    public DataDescription DataDescriptionOutput;

    internal static bool TryDeserialize(BinaryReader reader, out Submodule submodule)
    {
        submodule = new();

        submodule.SubslotNumber = reader.ReadUInt16BigEndian();
        submodule.SubmoduleIdentNumber = reader.ReadUInt32BigEndian();
        submodule.SubmoduleProperties = reader.ReadUInt16BigEndian();

        var props = submodule.SubmoduleProperties;

        if (IsInput(props) || IsDAPModule(props))
        {
            if (!DataDescription.TryDeserialize(reader, out submodule.DataDescriptionInput))
            {
                return false;
            }
        }

        if (!IsOutput(props))
        {
            return true;
        }
        if (!DataDescription.TryDeserialize(reader, out submodule.DataDescriptionOutput))
        {
            return false;
        }
        return true;
    }

    private static bool IsInput(ushort properties)
    {
        return (properties & 0x1) != 0;
    }

    private static bool IsOutput(ushort properties)
    {
        return (properties & 0x2) != 0;
    }

    private static bool IsDAPModule(ushort properties)
    {
        return (properties & 0x3) == 0;
    }
}
