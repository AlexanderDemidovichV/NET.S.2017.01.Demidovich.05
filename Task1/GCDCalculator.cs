using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public static class GCDCalculator
    {
        public static int CalculateGcdEuclideanAlgorithm(params int[] x)
        {
            return x.Aggregate(CalculateGcdEuclideanAlgorithm);
        }

        public static int CalculateGcdEuclideanAlgorithm(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            return b == 0 ? a : CalculateGcdEuclideanAlgorithm(b, a % b);
        }
    }
}
