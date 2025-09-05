using ITControl.Communication.Shared.Converters;
using System.Text.Json.Serialization;

namespace ITControl.Communication.Shared.Attributes;

public class DateOnlyConverterAttribute : JsonConverterAttribute
{
    public override JsonConverter? CreateConverter(Type typeToConvert) => new DateOnlyConverter();
}
