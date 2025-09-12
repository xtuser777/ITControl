using System.Text.Json;
using System.Text.Json.Serialization;

namespace ITControl.Communication.Shared.Converters;

public class GuidConverter() : JsonConverter<Guid>
{
    public override Guid Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        if (!Guid.TryParse(value, out Guid guid))
        {
            return Guid.Empty;
        }

        return guid;
    }

    public override void Write(Utf8JsonWriter writer, Guid value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}
