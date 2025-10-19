using System.Reflection;
using ITControl.Domain.Shared.Attributes;

namespace ITControl.Domain.Shared.Extensions;

public static class EnumExtensions
{
    public static string GetDisplayValue(this Enum value)
    {
        FieldInfo? field = value.GetType().GetField(value.ToString());
        if (field == null) return value.ToString(); // Fallback to enum name if no attribute found
        DisplayValueAttribute? attribute = field.GetCustomAttribute<DisplayValueAttribute>();
        return attribute != null ? attribute.DisplayValue : value.ToString(); // Fallback to enum name if no attribute found
    }
}
