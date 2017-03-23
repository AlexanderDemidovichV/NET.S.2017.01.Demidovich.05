using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public static class NumberConverter
    {
        public static string DoubleToBinary(double value)
        {
            var long64bits = BitConverter.ToInt64(BitConverter.GetBytes(value), 0);
            var sign64 = long64bits >> 63 & 0x01;
            var exponent64 = long64bits >> 52 & 0x7FF;
            var fraction64 = long64bits & 0xFFFFFFFFFFFFF;

            var raw_str = Convert.ToString(long64bits, 2).PadLeft(64, '0');

            return String.Format($"{Convert.ToString(sign64, 2)}" +
                                 $"{Convert.ToString(exponent64, 2).PadLeft(11, '0')}" +
                                 $"{Convert.ToString(fraction64, 2).PadLeft(52, '0')}");
        }
    }
}
