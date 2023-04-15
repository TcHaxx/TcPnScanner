using Argon;
using System.Net.NetworkInformation;

namespace dsian.TcPnScanner.Tests;

internal class JsonPhysicalAddressConverter : Argon.JsonConverter<PhysicalAddress>
{
    public override PhysicalAddress? ReadJson(JsonReader reader, Type type, PhysicalAddress? existingValue, bool hasExisting, JsonSerializer serializer)
    {
        if (reader.Value is not null and string)
        {
            return PhysicalAddress.Parse((string)reader.Value);
        }
        else
        {
            return PhysicalAddress.None;
        }
    }

    public override void WriteJson(JsonWriter writer, PhysicalAddress? value, JsonSerializer serializer)
    {
        writer.WriteValue(value?.ToString());
    }
}
