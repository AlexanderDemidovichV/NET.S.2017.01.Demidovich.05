using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public static class GCDCalculator
    {
        #region Delegates

        private delegate int GcdCalculate(int a, int b);

        #endregion

        #region Public Methods
        public static int CalculateGcdEuclideanAlgorithm(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            return b == 0 ? a : CalculateGcdEuclideanAlgorithm(b, a % b);
        }

        public static int CalculateGcdEuclideanAlgorithm(int a, int b, int c)
        {
            int gcd = CalculateGcdEuclideanAlgorithm(a, b);
            return CalculateGcdEuclideanAlgorithm(gcd, c);
        }

        public static int CalculateGcdEuclideanAlgorithm(params int[] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (array.Length == 1)
                return array[0];

            return array.Aggregate(CalculateGcdEuclideanAlgorithm);
        }

        public static int CalculateGcdStainsAlgorithm(int a, int b)
        {
            if (a == 0) return Math.Abs(b);
            if (b == 0) return Math.Abs(a);
            if (a == b) return Math.Abs(a);
            if (a == 1 || b == 1) return 1;
            if ((a % 2 == 0) && (b % 2 == 0)) return 2 * CalculateGcdStainsAlgorithm(a / 2, b / 2);
            if ((a % 2 == 0) && (b % 2 != 0)) return CalculateGcdStainsAlgorithm(a / 2, b);
            if ((a % 2 != 0) && (b % 2 == 0)) return CalculateGcdStainsAlgorithm(a, b / 2);
            return CalculateGcdStainsAlgorithm(b, Math.Abs(a - b));
        }

        public static int CalculateGcdStainsAlgorithm(params int[] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (array.Length == 1)
                return array[0];

            return array.Aggregate(CalculateGcdStainsAlgorithm);
        }

        public static int CalculateGcdEuclideanAlgorithm(int a, int b, out double time)
        {
            return GcdLeadTime(CalculateGcdEuclideanAlgorithm, a, b, out time);
        }

        public static int CalculateGcdStainsAlgorithm(int a, int b, out double time)
        {
            return GcdLeadTime(CalculateGcdEuclideanAlgorithm, a, b, out time);
        }

        #endregion

        #region Private Methods

        private static int GcdLeadTime(GcdCalculate gcdCalculate, int a, int b, out double time)
        {
            System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
            myStopwatch.Start();

            int result = gcdCalculate(a, b);

            myStopwatch.Stop();

            time = myStopwatch.Elapsed.TotalMilliseconds;

            return result;
        }

        #endregion

    }
}
