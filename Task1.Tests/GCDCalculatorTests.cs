using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace Task1.Tests
{
    public class GCDCalculatorTests
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

        [Test, TestCaseSource("TestData")]
        public static double CalculateEuclidianGcd_Test_Yeild(int[] a)
        {
            return GCDCalculator.CalculateGcdEuclideanAlgorithm(a);
        }

        [Test, TestCaseSource("TestData")]
        public static double CalculateStainsGcd_Test_Yeild(int[] a)
        {
            return GCDCalculator.CalculateGcdStainsAlgorithm(a);
        }
    }
}
