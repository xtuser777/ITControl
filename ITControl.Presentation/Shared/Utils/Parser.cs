using ITControl.Domain.Shared.Messages;

namespace ITControl.Presentation.Shared.Utils
{
    internal abstract class Parser
    {
        public static Guid? ToGuidOptional(string? value)
        {
            if (string.IsNullOrEmpty(value)) return null;
            if (Guid.TryParse(value, out var guid))
            {
                return guid;
            }
            return null;
        }
        
        public static Guid ToGuid(string value)
        {
            return Guid.TryParse(value, out var guid) 
                ? guid 
                : throw new ArgumentException(
                    string.Format(Errors.INVALID_GUID, value), nameof(value));
        }

        public static T? ToEnumOptional<T>(string? value) where T : struct, Enum
        {
            if (string.IsNullOrEmpty(value)) return null;
            if (Enum.TryParse<T>(value, true, out var result))
            {
                return result;
            }
            return null;
        }

        public static T ToEnum<T>(string value) where T : struct, Enum
        {
            return Enum.TryParse<T>(value, true, out var result) 
                ? result 
                : throw new ArgumentException(
                    string.Format(Errors.Parser_ToEnum_Invalid_ENUM_value___0_, value),
                    nameof(value));
        }

        public static bool? ToBoolOptional(string? value)
        {
            if (string.IsNullOrEmpty(value)) return null;
            if (bool.TryParse(value, out var result))
            {
                return result;
            }
            return null;
        }

        public static int? ToIntOptional(string? value)
        {
            if (string.IsNullOrEmpty(value)) return null;
            if (int.TryParse(value, out var result))
            {
                return result;
            }
            return null;
        }
    }
}
