using System.Collections.Generic;
using NUnit.Framework;

namespace Task2.Tests
{
    class DoubleToBinaryTests
    {
        public static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(-255.255).Returns("1100000001101111111010000010100011110101110000101000111101011100");
                yield return new TestCaseData(255.255).Returns("0100000001101111111010000010100011110101110000101000111101011100");
                yield return new TestCaseData(4294967295.0).Returns("0100000111101111111111111111111111111111111000000000000000000000");
                yield return new TestCaseData(4294967295.0).Returns("0100000111101111111111111111111111111111111000000000000000000000");
                yield return new TestCaseData(double.MaxValue).Returns("0111111111101111111111111111111111111111111111111111111111111111");
                yield return new TestCaseData(double.MinValue).Returns("1111111111101111111111111111111111111111111111111111111111111111");
                yield return new TestCaseData(double.Epsilon).Returns("0000000000000000000000000000000000000000000000000000000000000001");
                yield return new TestCaseData(double.NaN).Returns("1111111111111000000000000000000000000000000000000000000000000000");
                yield return new TestCaseData(double.NegativeInfinity).Returns("1111111111110000000000000000000000000000000000000000000000000000");
                yield return new TestCaseData(double.PositiveInfinity).Returns("0111111111110000000000000000000000000000000000000000000000000000");
                yield return new TestCaseData(0.15625d).Returns("0011111111000100000000000000000000000000000000000000000000000000");
                yield return new TestCaseData(1).Returns("0011111111110000000000000000000000000000000000000000000000000000");
                

            }
        }

        [Test, TestCaseSource("TestData")]
        public static string CalculateDoubleToBinary_Test_Yeild(double value)
        {
            return value.DoubleToBinary();
        }
    }
}
