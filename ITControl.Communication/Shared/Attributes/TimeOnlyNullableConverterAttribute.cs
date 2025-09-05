using System.Text.Json.Serialization;

namespace ITControl.Communication.Shared.Attributes;

public class TimeOnlyNullableConverterAttribute : JsonConverterAttribute
{
    public override JsonConverter? CreateConverter(Type typeToConvert) => new Converters.TimeOnlyNullableConverter();
}
