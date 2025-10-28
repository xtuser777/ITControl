using System.Text.Json;
using System.Text.Json.Serialization;

namespace ITControl.Presentation.Shared.Converters;

public class DateOnlyNullableConverter : JsonConverter<DateOnly?>
{
    public override DateOnly? Read(
        ref Utf8JsonReader reader, 
        Type typeToConvert, 
        JsonSerializerOptions options)
    {
        var value = reader.GetString();
        if (string.IsNullOrEmpty(value))
        {
            return null;
        }
        return DateOnly.TryParse(value, out var date) 
            ? date 
            : DateOnly.MinValue;
    }

    public override void Write(
        Utf8JsonWriter writer, 
        DateOnly? value, 
        JsonSerializerOptions options)
    {
        if (value.HasValue)
        {
            writer.WriteStringValue(value.Value.ToString("yyyy-MM-dd"));
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}
