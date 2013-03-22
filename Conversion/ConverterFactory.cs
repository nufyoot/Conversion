using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conversion
{
    /// <summary>
    /// Provides common methods for converting from one type to another.
    /// </summary>
    public static class ConverterFactory
    {
        #region Fields

        private static Dictionary<Type, Dictionary<Type, Delegate>> _conversionMethods = new Dictionary<Type,Dictionary<Type,Delegate>>();
        private static System.Reflection.MethodInfo _getConversionMethodInfo = typeof(ConverterFactory).GetMethod("GetConversionMethod");

        #endregion

        #region Methods

        public static TOutput ConvertTo<TOutput>(this object original)
        {
            Delegate conversionMethod =
                (Delegate)_getConversionMethodInfo
                    .MakeGenericMethod(original.GetType(), typeof(TOutput))
                    .Invoke(null, new object[] { });

            return (TOutput)conversionMethod.Method.Invoke(conversionMethod.Target, new object[] { original });
        }

        /// <summary>
        /// Gets the conversion method to be used for converting from the given <c>TInput</c>
        /// to the given <c>TOutput</c>.
        /// </summary>
        /// <typeparam name="TInput">This is the input type.</typeparam>
        /// <typeparam name="TOutput">Ths is the output type.</typeparam>
        /// <returns>Returns the method to be used for converting the types.</returns>
        public static Func<TInput, TOutput> GetConversionMethod<TInput, TOutput>()
        {
            Dictionary<Type, Delegate> outputMethods;
            Delegate result = null;

            if (!_conversionMethods.TryGetValue(typeof(TInput), out outputMethods))
            {
                return null;
            }

            if (!outputMethods.TryGetValue(typeof(TOutput), out result))
            {
                return null;
            }

            return (Func<TInput, TOutput>)result;
        }

        /// <summary>
        /// Registers a conversion method for converting from one type to another.
        /// </summary>
        /// <typeparam name="TInput">The type of object being passed in.</typeparam>
        /// <typeparam name="TOutput">The type of object being returned.</typeparam>
        /// <param name="conversionMethod">This is the method to be used when converting from one type to another.</param>
        public static void RegisterConversionMethod<TInput, TOutput>(Func<TInput, TOutput> conversionMethod)
        {
            Dictionary<Type, Delegate> outputMethods;

            //------------------------------------------
            // First, see if we need to add a collection of conversion methods for the given input.
            if (!_conversionMethods.TryGetValue(typeof(TInput), out outputMethods))
            {
                _conversionMethods.Add(typeof(TInput), outputMethods = new Dictionary<Type,Delegate>());
            }
            //------------------------------------------

            //------------------------------------------
            // Next, find the matching conversion method for the given output and either add it or replace it.
            if (outputMethods.ContainsKey(typeof(TOutput)))
            {
                outputMethods[typeof(TOutput)] = conversionMethod;
            }
            else
            {
                outputMethods.Add(typeof(TOutput), conversionMethod);
            }
            //------------------------------------------
        }

        #endregion
    }
}
