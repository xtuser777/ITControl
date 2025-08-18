using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITControl.Application.Utils
{
    internal class Parser
    {
        public static Guid? ToGuid(string? value)
        {
            if (string.IsNullOrEmpty(value)) return null;
            if (Guid.TryParse(value, out var guid))
            {
                return guid;
            }
            return null;
        }

        public static T? ToEnum<T>(string? value) where T : struct, Enum
        {
            if (string.IsNullOrEmpty(value)) return null;
            if (Enum.TryParse<T>(value, true, out var result))
            {
                return result;
            }
            return null;
        }
    }
}
