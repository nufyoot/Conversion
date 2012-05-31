using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversion
{
    /// <summary>
    /// Provides the weight of the conversion process.
    /// </summary>
    public enum ConversionWeight
    {
        /// <summary>
        /// The information being converted is 100% accurate.
        /// </summary>
        Lossless = 1,

        /// <summary>
        /// The information being converted may not be 100%, but it is pretty close.
        /// </summary>
        HighPrecision = 2,

        /// <summary>
        /// The information being converted may have some data loss.
        /// </summary>
        LowPrecision = 3
    }
}
