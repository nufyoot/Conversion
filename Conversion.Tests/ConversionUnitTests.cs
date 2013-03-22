using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Conversion.Tests
{

    public delegate object ObjectConverter(object input);

    [TestFixture]
    public class ConversionUnitTests
    {
        [Test]
        public void TestRegisterAndGet()
        {
            Conversion.ConverterFactory.RegisterConversionMethod<string, int>(s => int.Parse(s));

            for (int i = 0; i < 100000; i++)
            {
                int a = i.ToString().ConvertTo<int>();
                Assert.AreEqual(a, i);
            }
        }

        [Test]
        public void TestRegisterAndGetFast()
        {
            for (int i = 0; i < 100000; i++)
            {
                int a = int.Parse(i.ToString());
                Assert.AreEqual(a, i);
            }
        }
    }
}
