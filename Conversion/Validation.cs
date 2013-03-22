using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversion
{
    internal static class Validation
    {
        public static void ArgumentNotNull<T>(T input, string parameterName)
        {
            if (input == null) throw new ArgumentNullException(parameterName);
        }

        public static void ArgumentNotNull<T>(T? input, string parameterName) where T : struct
        {
            if (!input.HasValue) throw new ArgumentNullException(parameterName);
        }
    }
}
