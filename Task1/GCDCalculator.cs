using System;
using System.Linq;

namespace Task1
{
    /// <summary>
    /// Provides static methods for greatest common divisor calculating
    /// </summary>
    public static class GcdCalculator
    {

        #region Public Methods

        /// <summary>
        /// Returns greatest common divisor of specified integers using Euclidian method
        /// </summary>
        /// <param name="a">The first integer.</param>
        /// <param name="b">The second integer.</param>
        /// <returns>The greatest common divisor of specified integers <paramref name="a"/> and <paramref name="b"/>.</returns>
        public static int CalculateGcdEuclideanAlgorithm(int a, int b) => CalculateGcd(CalculateGcdEuclidean, a, b);

        /// <summary>
        /// Returns greatest common divisor of specified integers using Euclidian method
        /// </summary>
        /// <param name="a">The first integer.</param>
        /// <param name="b">The second integer.</param>
        /// <param name="c">The third integer.</param>
        /// <returns>The greatest common divisor of specified integers <paramref name="a"/>, <paramref name="b"/> and <paramref name="c"/>.</returns>
        public static int CalculateGcdEuclideanAlgorithm(int a, int b, int c) => CalculateGcd(CalculateGcdEuclideanAlgorithm, a, b, c);

        /// <summary>
        /// Returns greatest common divisor of specified integers using Euclidian method
        /// </summary>
        /// <param name="array">An array of integer instances.</param>
        /// <returns>The greatest common divisor of specified integers.</returns>
        /// <exception cref="System.ArgumentNullException"><paramref name="array"/> is null.</exception>
        public static int CalculateGcdEuclideanAlgorithm(params int[] array) => CalculateGcd(CalculateGcdEuclideanAlgorithm, array);

        /// <summary>
        /// Returns greatest common divisor of specified integers using Euclidian method
        /// </summary>
        /// <param name="a">The first integer.</param>
        /// <param name="b">The second integer.</param>
        /// <param name="time">The time in milliseconds to determine the execution time for Euclidian method calculation.</param>
        /// <returns>The greatest common divisor of specified integers and time in milliseconds required for Euclidian method calculation.</returns>
        public static int CalculateGcdEuclideanAlgorithm(int a, int b, out double time) => 
            GcdLeadTime(CalculateGcdEuclideanAlgorithm, a, b, out time);

        /// <summary>
        /// Returns greatest common divisor of specified integers using Stains's method
        /// </summary>
        /// <param name="a">The first integer.</param>
        /// <param name="b">The second integer.</param>
        /// <returns>The greatest common divisor of specified integers.</returns>
        public static int CalculateGcdStainsAlgorithm(int a, int b) => CalculateGcd(CalculateGcdStains, a, b);

        /// <summary>
        /// Returns greatest common divisor of specified integers using Stains's method
        /// </summary>
        /// <param name="a">The first integer.</param>
        /// <param name="b">The second integer.</param>
        /// /// <param name="c">The third integer.</param>
        /// <returns>The greatest common divisor of specified integers.</returns>
        public static int CalculateGcdStainsAlgorithm(int a, int b, int c) => CalculateGcd(CalculateGcdStainsAlgorithm, a, b, c);

        /// <summary>
        /// Returns greatest common divisor of specified integers using Stains's method
        /// </summary>
        /// <param name="array">An array of integer instances.</param>
        /// <returns>The greatest common divisor of specified integers.</returns>
        /// <exception cref="System.ArgumentNullException"><paramref name="array"/> is null.</exception>
        public static int CalculateGcdStainsAlgorithm(params int[] array) => CalculateGcd(CalculateGcdStainsAlgorithm, array);

        /// <summary>
        /// Returns greatest common divisor of specified integers using Stains's method
        /// </summary>
        /// <param name="a">The first integer.</param>
        /// <param name="b">THe second integer.</param>
        /// <param name="time">The time in milliseconds to determine the execution time for Euclidian method calculation.</param>
        /// <returns>The greatest common divisor of specified integers and time in milliseconds required for Stain's method calculation.</returns>
        public static int CalculateGcdStainsAlgorithm(int a, int b, out double time) => 
            GcdLeadTime(CalculateGcdStainsAlgorithm, a, b, out time);

        #endregion

        #region Private Methods

        /// <summary>
        /// Returns greatest common divisor of specified integers using specified method
        /// </summary>
        /// <param name="gcdCalculate">A delegate that specifies method of calculation</param>
        /// <param name="a">The first function parameter</param>
        /// <param name="b">The second function parameter</param>
        /// <param name="time">A time in milliseconds required for specified method calculation</param>
        /// <returns>The greatest common divisor of specified integers and time in milliseconds required for specified method calculation</returns>
        private static int GcdLeadTime(Func<int, int, int> gcdCalculate, int a, int b, out double time)
        {
            System.Diagnostics.Stopwatch myStopwatch = new System.Diagnostics.Stopwatch();
            myStopwatch.Start();

            int result = gcdCalculate(a, b);

            myStopwatch.Stop();

            time = myStopwatch.Elapsed.TotalMilliseconds;

            return result;
        }

        private static int CalculateGcd(Func<int, int, int> gcdCalculate, int a, int b)
        {
            if (a == 0) return Math.Abs(b);
            if (b == 0) return Math.Abs(a);
            if (a == b) return Math.Abs(a);
            if (a == 1 || b == 1) return 1;

            a = Math.Abs(a);
            b = Math.Abs(b);

            return gcdCalculate(a, b);
        }

        private static int CalculateGcd(Func<int, int, int> gcdCalculate, int a, int b, int c)
        {
            int gcd = CalculateGcd(gcdCalculate, a, b);
            return CalculateGcd(gcdCalculate, gcd, c);
        }

        private static int CalculateGcd(Func<int, int, int> gcdCalculate, params int[] array)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            if (array.Length == 1)
                return array[0];

            return array.Aggregate(gcdCalculate);
        }

        private static int CalculateGcdEuclidean(int a, int b) => b == 0 ? a : CalculateGcdEuclideanAlgorithm(b, a % b);

        private static int CalculateGcdStains(int a, int b)
        {
            if ((a % 2 == 0) && (b % 2 == 0)) return 2 * CalculateGcdStainsAlgorithm(a / 2, b / 2);
            if ((a % 2 == 0) && (b % 2 != 0)) return CalculateGcdStainsAlgorithm(a / 2, b);
            if ((a % 2 != 0) && (b % 2 == 0)) return CalculateGcdStainsAlgorithm(a, b / 2);
            return CalculateGcdStainsAlgorithm(b, Math.Abs(a - b));
        }

        #endregion

    }
}
