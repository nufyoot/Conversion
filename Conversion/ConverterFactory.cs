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
        private static Dictionary<Type, Dictionary<Type, Func<object, object>>> _conversionMethods = new Dictionary<Type, Dictionary<Type, Func<object, object>>>();

        private delegate TOutput C<TInput, TOutput>(object o);
        public static TOutput ConvertTo<TOutput>(this object original)
        {
            Func<object, object> conversionMethod = GetConversionMethod(original.GetType(), typeof(TOutput));
            return (TOutput)conversionMethod(original);
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
            return x => (TOutput)GetConversionMethod(typeof(TInput), typeof(TOutput))(x);
        }

        /// <summary>
        /// Gets the conversion method to be used for converting from the given <c>input</c>
        /// to the given <c>output</c>.
        /// </summary>
        /// <param name="input">This is the input type.</typeparam>
        /// <param name="output">Ths is the output type.</typeparam>
        /// <returns>Returns the method to be used for converting the types.</returns>
        public static Func<object, object> GetConversionMethod(Type input, Type output)
        {
            Dictionary<Type, Func<object, object>> outputMethods;
            Func<object, object> result = null;

            if (!_conversionMethods.TryGetValue(input, out outputMethods))
            {
                return null;
            }

            if (!outputMethods.TryGetValue(output, out result))
            {
                return null;
            }

            return result;
        }

        /// <summary>
        /// Registers a conversion method for converting from one type to another.
        /// </summary>
        /// <typeparam name="TInput">The type of object being passed in.</typeparam>
        /// <typeparam name="TOutput">The type of object being returned.</typeparam>
        /// <param name="conversionMethod">This is the method to be used when converting from one type to another.</param>
        public static void RegisterConversionMethod<TInput, TOutput>(Func<TInput, TOutput> conversionMethod)
        {
            Dictionary<Type, Func<object, object>> outputMethods;

            //------------------------------------------
            // First, see if we need to add a collection of conversion methods for the given input.
            if (!_conversionMethods.TryGetValue(typeof(TInput), out outputMethods))
            {
                _conversionMethods.Add(typeof(TInput), outputMethods = new Dictionary<Type, Func<object, object>>());
            }
            //------------------------------------------

            //------------------------------------------
            // Next, find the matching conversion method for the given output and either add it or replace it.
            if (outputMethods.ContainsKey(typeof(TOutput)))
            {
                outputMethods[typeof(TOutput)] = x => conversionMethod((TInput)x);
            }
            else
            {
                outputMethods.Add(typeof(TOutput), x => conversionMethod((TInput)x));
            }
            //------------------------------------------
        }
    }
}
