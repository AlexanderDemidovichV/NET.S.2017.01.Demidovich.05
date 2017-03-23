using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task2;

namespace Task2.Tests
{
    class DoubleToBinaryTests
    {
        public static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(0.15625d).Returns("0011111111000100000000000000000000000000000000000000000000000000");
                yield return new TestCaseData(-4343.3423d).Returns("1100000010110000111101110101011110100000111110010000100101101100");
                yield return new TestCaseData(1).Returns("0011111111110000000000000000000000000000000000000000000000000000");
                yield return new TestCaseData(double.MaxValue).Returns("0111111111101111111111111111111111111111111111111111111111111111");
                yield return new TestCaseData(double.MinValue).Returns("1111111111101111111111111111111111111111111111111111111111111111");
            }
        }

        [Test, TestCaseSource("TestData")]
        public static string CalculateDoubleToBinary_Test_Yeild(double value)
        {
            return value.DoubleToBinary();
        }
    }
}
