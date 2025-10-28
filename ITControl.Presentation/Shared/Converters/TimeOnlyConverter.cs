using System.Text.Json;
using System.Text.Json.Serialization;
using ITControl.Domain.Shared.Exceptions;

namespace ITControl.Presentation.Shared.Converters;

public class TimeOnlyConverter : JsonConverter<TimeOnly>
{
    public override TimeOnly Read(
        ref Utf8JsonReader reader, 
        Type typeToConvert, 
        JsonSerializerOptions options)
    {
        var value = reader.GetString() 
                    ?? throw new BadRequestException("campo do tipo hora não opcional");
        return TimeOnly.TryParse(value, out var time) 
            ? time 
            : TimeOnly.MinValue;
    }

    public override void Write(
        Utf8JsonWriter writer, 
        TimeOnly value, 
        JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("HH:mm:ss"));
    }
}
