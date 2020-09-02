using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.Core.Common.Extensions
{
    public static class CustomConvertExtension
    {
        public static string ObjectToString(this object value, string defaultValue = "")
        {
            if (value == null) return defaultValue;
            return value.ToString().Trim();
        }
    }
}
