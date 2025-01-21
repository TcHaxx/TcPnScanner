using Argon;
using System.Net;

namespace dsian.TcPnScanner.Tests;

internal class JsonIpAddressConverter : Argon.JsonConverter<System.Net.IPAddress>
{
    public override IPAddress ReadJson(JsonReader reader, Type type, IPAddress? existingValue, bool hasExisting, JsonSerializer serializer)
    {
        if (reader.Value is not null and string)
        {
            return IPAddress.Parse((string)reader.Value);
        }
        else
        {
            return IPAddress.None;
        }
    }

    public override void WriteJson(JsonWriter writer, IPAddress? value, JsonSerializer serializer)
    {
        writer.WriteValue(value?.ToString());
    }
}
