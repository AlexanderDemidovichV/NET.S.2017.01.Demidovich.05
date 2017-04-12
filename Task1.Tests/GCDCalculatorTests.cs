using NUnit.Framework;
using System.Collections.Generic;

namespace Task1.Tests
{
    public class GcdCalculatorTests
    {
        public static IEnumerable<TestCaseData> TestData
        {
            get
            {
                yield return new TestCaseData(new int[] { 12, 18, 6 }).Returns(6);
                yield return new TestCaseData(new int[] { 12, 18, 6, 81 }).Returns(3);
                yield return new TestCaseData(new int[] { 12, 0 }).Returns(12);
                yield return new TestCaseData(new int[] { 0, 12 }).Returns(12);
                yield return new TestCaseData(new int[] { 0, 0 }).Returns(0);
                yield return new TestCaseData(new int[] { 12, 12 }).Returns(12);
                yield return new TestCaseData(new int[] { -12, 2 }).Returns(2);
                yield return new TestCaseData(new int[] { -5, 10 }).Returns(5);
                yield return new TestCaseData(new int[] { -5, 0 }).Returns(5);
                yield return new TestCaseData(new int[] { 0, -8 }).Returns(8);
            }
        }

        public static IEnumerable<TestCaseData> TestData2
        {
            get
            {
                yield return new TestCaseData(12, 0).Returns(12);
                yield return new TestCaseData(0, 12).Returns(12);
                yield return new TestCaseData(0, 0).Returns(0);
                yield return new TestCaseData(12, 12).Returns(12);
                yield return new TestCaseData(-12, 2).Returns(2);
                yield return new TestCaseData(-5, 10).Returns(5);
                yield return new TestCaseData(-5, 0).Returns(5);
                yield return new TestCaseData(0, -8).Returns(8);
            }
        }

        [Test, TestCaseSource("TestData")]
        public static double CalculateEuclidianGcd_Test_Yeild(int[] a)
        {
            return GcdCalculator.CalculateGcdEuclideanAlgorithm(a);
        }

        [Test, TestCaseSource("TestData2")]
        public static double CalculateEuclidianGcd_Test_Yeild(int a, int b)
        {
            return GcdCalculator.CalculateGcdEuclideanAlgorithm(a, b);
        }

        [Test, TestCaseSource("TestData")]
        public static double CalculateStainsGcd_Test_Yeild(int[] a)
        {
            return GcdCalculator.CalculateGcdStainsAlgorithm(a);
        }
    }
}
