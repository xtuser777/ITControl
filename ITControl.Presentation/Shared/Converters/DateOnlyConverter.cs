using System.Text.Json;
using System.Text.Json.Serialization;
using ITControl.Domain.Shared.Exceptions;

namespace ITControl.Presentation.Shared.Converters;

public class DateOnlyConverter : JsonConverter<DateOnly>
{
    public override DateOnly Read(
        ref Utf8JsonReader reader, 
        Type typeToConvert, 
        JsonSerializerOptions options)
    {
        var value = reader.GetString() 
                    ?? throw new BadRequestException("campo do tipo data não opcional");
        return DateOnly.TryParse(value, out var date) 
            ? date 
            : DateOnly.MinValue;
    }

    public override void Write(
        Utf8JsonWriter writer, 
        DateOnly value, 
        JsonSerializerOptions options)
    {   
        writer.WriteStringValue(value.ToString("yyyy-MM-dd")); 
    }
}
