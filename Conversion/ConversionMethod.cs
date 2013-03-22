using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversion
{
    /// <summary>
    /// Provides information about a conversion method.
    /// </summary>
    internal class ConversionMethod 
    {
        #region Fields

        private Delegate _method;
        private int _weight;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the method to be used for conversion.
        /// </summary>
        public Delegate Method
        {
            get { return _method; }
        }

        /// <summary>
        /// Gets the weight of the conversion method.
        /// </summary>
        public int Weight
        {
            get { return _weight; }
        }

        #endregion
    }
}
