using System;
using System.Runtime.InteropServices;

namespace Task2
{
    /// <summary>
    /// Provides methods for number conversion
    /// </summary>
    public static class NumberConverter
    {
        #region Public Methods

        /// <summary>
        /// Returns the specified double-precision floating point value as a string representation of bits.
        /// </summary>
        /// <param name="value">The number to convert.</param>
        /// <returns>A string representation of bits with length 64.</returns>
        public static string DoubleToBinary(this double value)
        {
            var long64bits = BitConverter.ToInt64(BitConverter.GetBytes(value), 0);
            var sign64 = long64bits >> 63 & 0x01;
            var exponent64 = long64bits >> 52 & 0x7FF;
            var fraction64 = long64bits & 0xFFFFFFFFFFFFF;

            return $"{Convert.ToString(sign64, 2)}" +
                   $"{Convert.ToString(exponent64, 2).PadLeft(11, '0')}" +
                   $"{Convert.ToString(fraction64, 2).PadLeft(52, '0')}";
        }

        public static string DoubleToBinaryString(this double value)
        {
            ConvertStruct convertStruct = new ConvertStruct {DoubleBitsRepresentation = value};

            return Convert.ToString(convertStruct.LongBitsRepresentation, 2).PadLeft(64, '0');
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct ConvertStruct
        {
            [FieldOffset(0)] private double double64Representation;

            [FieldOffset(0)] private readonly long long64Representation;

            public long LongBitsRepresentation => long64Representation;

            public double DoubleBitsRepresentation {  set { double64Representation = value; } }
        }

        #endregion

    }
}
