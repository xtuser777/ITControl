using System.Text.Json;
using System.Text.Json.Serialization;

namespace ITControl.Presentation.Shared.Converters;

public class TimeOnlyNullableConverter : JsonConverter<TimeOnly?>
{
    public override TimeOnly? Read(
        ref Utf8JsonReader reader, 
        Type typeToConvert, 
        JsonSerializerOptions options)
    {
        var value = reader.GetString();
        if (string.IsNullOrEmpty(value))
        {
            return null;
        }
        return TimeOnly.TryParse(value, out var time) 
            ? time 
            : TimeOnly.MinValue;
    }

    public override void Write(
        Utf8JsonWriter writer, 
        TimeOnly? value, 
        JsonSerializerOptions options)
    {
        if (value.HasValue)
        {
            writer.WriteStringValue(value.Value.ToString("HH:mm:ss"));
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}
