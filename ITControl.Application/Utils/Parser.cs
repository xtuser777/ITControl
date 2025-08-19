using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITControl.Application.Utils
{
    internal class Parser
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
            throw new ArgumentException($"Invalid GUID format: {value}", nameof(value));
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
            throw new ArgumentException($"Invalid ENUM value: {value}", nameof(value));
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
            throw new ArgumentException($"Invalid DateOnly format: {value}", nameof(value));
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
            throw new ArgumentException($"Invalid TimeOnly format: {value}", nameof(value));
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
            throw new ArgumentException($"Invalid boolean format: {value}", nameof(value));
        }
    }
}
