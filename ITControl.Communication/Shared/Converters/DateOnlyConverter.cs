using ITControl.Domain.Shared.Exceptions;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ITControl.Communication.Shared.Converters;

public class DateOnlyConverter : JsonConverter<DateOnly>
{
    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString() ?? throw new BadRequestException("campo do tipo data não opcional");
        if (DateOnly.TryParse(value, out var date))
        {
            return date;
        }
        return DateOnly.MinValue;
    }

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
    {   
        writer.WriteStringValue(value.ToString("yyyy-MM-dd")); 
    }
}
