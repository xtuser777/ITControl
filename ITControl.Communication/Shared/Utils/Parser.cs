using ITControl.Domain.Shared.Messages;

namespace ITControl.Communication.Shared.Utils
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
            if (Guid.TryParse(value, out var guid))
            {
                return guid;
            }
            throw new ArgumentException(string.Format(Errors.Parser_ToGuid_Invalid_GUID_format___0_, value), nameof(value));
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
            if (Enum.TryParse<T>(value, true, out var result))
            {
                return result;
            }
            throw new ArgumentException(string.Format(Errors.Parser_ToEnum_Invalid_ENUM_value___0_, value), nameof(value));
        }

        public static DateOnly? ToDateOnlyOptional(string? value)
        {
            if (string.IsNullOrEmpty(value)) return null;
            if (DateOnly.TryParse(value, out var dateOnly))
            {
                return dateOnly;
            }
            return null;
        }

        public static DateOnly ToDateOnly(string value)
        {
            if (DateOnly.TryParse(value, out var dateOnly))
            {
                return dateOnly;
            }
            throw new ArgumentException(string.Format(Errors.Parser_ToDateOnly_Invalid_DateOnly_format___0_, value), nameof(value));
        }

        public static TimeOnly? ToTimeOnlyOptional(string? value)
        {
            if (string.IsNullOrEmpty(value)) return null;
            if (TimeOnly.TryParse(value, out var timeOnly))
            {
                return timeOnly;
            }
            return null;
        }

        public static TimeOnly ToTimeOnly(string value)
        {
            if (TimeOnly.TryParse(value, out var timeOnly))
            {
                return timeOnly;
            }
            throw new ArgumentException(string.Format(Errors.Parser_ToTimeOnly_Invalid_TimeOnly_format___0_, value), nameof(value));
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

        public static bool ToBool(string value)
        {
            if (bool.TryParse(value, out var result))
            {
                return result;
            }
            throw new ArgumentException(string.Format(Errors.Parser_ToBool_Invalid_boolean_format___0_, value), nameof(value));
        }
    }
}
