using ITControl.Communication.Shared.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ITControl.Communication.Shared.Converters;

public class GuidConverter() : JsonConverter<Guid>
{
    public override Guid Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (Guid.TryParse(reader.GetString(), out Guid guid))
        {
            return guid;
        }
        return Guid.Empty;
    }

    public override void Write(Utf8JsonWriter writer, Guid value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}
