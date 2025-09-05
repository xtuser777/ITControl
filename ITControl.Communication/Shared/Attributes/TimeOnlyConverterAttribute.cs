using System.Text.Json.Serialization;

namespace ITControl.Communication.Shared.Attributes;

public class TimeOnlyConverterAttribute : JsonConverterAttribute
{
    public override JsonConverter? CreateConverter(Type typeToConvert) => new Converters.TimeOnlyConverter();
}
