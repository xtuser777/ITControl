using System.Text.Json;
using System.Text.Json.Serialization;

namespace ITControl.Presentation.Shared.Converters;

public class GuidNullableConverter : JsonConverter<Guid?>
{
    public override Guid? Read(
        ref Utf8JsonReader reader, 
        Type typeToConvert, 
        JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return null;
        }
        var valid = Guid.TryParse(reader.GetString(), out Guid guid);
        return valid ? guid : Guid.Empty;
    }

    public override void Write(
        Utf8JsonWriter writer, 
        Guid? value, 
        JsonSerializerOptions options)
    {
        if (value.HasValue)
        {
            writer.WriteStringValue(value.Value.ToString());
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}
