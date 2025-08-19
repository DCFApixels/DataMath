// Основано на реализации System.MathF лицензируемой по под лицензией MIT.
// Части кода, реализованные ниже, основаны на алгоритмах Berkeley SoftFloat Release 3e.

#if DISABLE_DEBUG
#undef DEBUG
#endif
using System;
using System.Diagnostics;
using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;
//#if !DOTNET_FRAMEWORK || UNITY_5_3_OR_NEWER
//using SMathF = System.MathF;
//#else
//using SMathF = DCFApixels.DataMath.Internal.MathDM;
//#endif

namespace DCFApixels.DataMath.Internal
{
    internal static unsafe partial class InternalMath
    {
        public const float E = 2.71828183f;

        public const float PI = 3.14159265f;

        public const float Tau = 6.283185307f;

        private const int maxRoundingDigits = 6;

        // This table is required for the Round function which can specify the number of digits to round to
        private static float[] RoundPower10Single = new float[] {
            1e0f, 1e1f, 1e2f, 1e3f, 1e4f, 1e5f, 1e6f
        };

        private const float singleRoundLimit = 1e8f;

        private const float SCALEB_C1 = 1.7014118E+38f; // 0x1p127f

        private const float SCALEB_C2 = 1.1754944E-38f; // 0x1p-126f

        private const float SCALEB_C3 = 16777216f; // 0x1p24f

        private const int ILogB_NaN = 0x7fffffff;

        private const int ILogB_Zero = (-1 - 0x7fffffff);

        public static float BitDecrement(float x)
        {
            int bits = new FloatIntUnion(x).intValue;
            if ((bits & 0x7F800000) >= 0x7F800000)
            {
                // NaN returns NaN
                // -Infinity returns -Infinity
                // +Infinity returns float.MaxValue
                return (bits == 0x7F800000) ? float.MaxValue : x;
            }
            if (bits == 0x00000000)
            {
                // +0.0 returns -float.Epsilon
                return -float.Epsilon;
            }
            // Negative values need to be incremented
            // Positive values need to be decremented
            bits += ((bits < 0) ? +1 : -1);
            return new FloatIntUnion(bits).intValue;
        }

        public static float BitIncrement(float x)
        {
            int bits = new FloatIntUnion(x).intValue;
            if ((bits & 0x7F800000) >= 0x7F800000)
            {
                // NaN returns NaN
                // -Infinity returns float.MinValue
                // +Infinity returns +Infinity
                return (bits == unchecked((int)(0xFF800000))) ? float.MinValue : x;
            }
            if (bits == unchecked((int)(0x80000000)))
            {
                // -0.0 returns float.Epsilon
                return float.Epsilon;
            }
            // Negative values need to be decremented
            // Positive values need to be incremented
            bits += ((bits < 0) ? -1 : +1);
            return new FloatIntUnion(bits).intValue;
        }

        [IN(LINE)]
        public static float CopySign(float x, float y)
        {
            const int signMask = 1 << 31;
            // This method is required to work for all inputs,
            // including NaN, so we operate on the raw bits.
            int xbits = new FloatIntUnion(x).intValue;
            int ybits = new FloatIntUnion(y).intValue;
            // Remove the sign from x, and remove everything but the sign from y
            xbits &= ~signMask;
            ybits &= signMask;
            // Simply OR them to get the correct sign
            return new FloatIntUnion(xbits | ybits).floatValue;
        }

        public static float IEEERemainder(float x, float y)
        {
            if (float.IsNaN(x))
                return x; // IEEE 754-2008: NaN payload must be preserved
            if (float.IsNaN(y))
                return y; // IEEE 754-2008: NaN payload must be preserved

            float regularMod = x % y;

            if (float.IsNaN(regularMod))
                return float.NaN;

            if ((regularMod == 0) && IsNegative_2(x))
                return -0f;

            float alternativeResult = (regularMod - (Abs(y) * Sign(x)));

            if (Abs(alternativeResult) == Abs(regularMod))
            {
                float divisionResult = x / y;
                float roundedResult = Round(divisionResult);

                if (Abs(roundedResult) > Abs(divisionResult))
                {
                    return alternativeResult;
                }
                else
                {
                    return regularMod;
                }
            }

            if (Abs(alternativeResult) < Abs(regularMod))
            {
                return alternativeResult;
            }
            else
            {
                return regularMod;
            }
        }

        public static int ILogB(float x)
        {
            // Implementation based on https://git.musl-libc.org/cgit/musl/tree/src/math/ilogbf.c
            if (float.IsNaN(x))
            {
                return ILogB_NaN;
            }
            uint i = new FloatUIntUnion(x).uintValue;// BitConverter.SingleToUInt32Bits(x);
            int e = (int)((i >> 23) & 0xFF);

            if (e == 0)
            {
                i <<= 9;
                if (i == 0)
                {
                    return ILogB_Zero;
                }

                for (e = -0x7F; (i >> 31) == 0; e--, i <<= 1) ;
                return e;
            }

            if (e == 0xFF)
            {
                return i << 9 != 0 ? ILogB_Zero : int.MaxValue;
            }

            return e - 0x7F;
        }

        public static float Log(float x, float y)
        {
            if (float.IsNaN(x))
                return x; // IEEE 754-2008: NaN payload must be preserved

            if (float.IsNaN(y))
                return y; // IEEE 754-2008: NaN payload must be preserved

            if (y == 1)
                return float.NaN;

            if ((x != 1) && ((y == 0) || float.IsPositiveInfinity(y)))
                return float.NaN;

            return Log(x) / Log(y);
        }

        [IN(LINE)]
        public static float Max_Standart(float x, float y)
        {
            // This matches the IEEE 754:2019 `maximum` function
            // It propagates NaN inputs back to the caller and
            // otherwise returns the greater of the inputs. It
            // treats +0 as greater than -0 as per the specification.
            if (x != y)
            {
                if (!float.IsNaN(x))
                    return y < x ? x : y;

                return x;
            }
            return IsNegative_2(y) ? x : y;
        }
        [IN(LINE)]
        public static float Max(float x, float y) => x > y ? x : y;

        public static float MaxMagnitude(float x, float y)
        {
            // This matches the IEEE 754:2019 `maximumMagnitude` function
            // It propagates NaN inputs back to the caller and
            // otherwise returns the input with a greater magnitude.
            // It treats +0 as greater than -0 as per the specification.
            float ax = Abs(x);
            float ay = Abs(y);

            if ((ax > ay) || float.IsNaN(ax))
                return x;

            if (ax == ay)
                return IsNegative_2(x) ? y : x;

            return y;
        }

        [IN(LINE)]
        public static float Min_Standart(float x, float y)
        {
            if (x != y)
            {
                if (!double.IsNaN(x))
                    return x < y ? x : y;

                return x;
            }
            return IsNegative_2(x) ? x : y;
        }
        [IN(LINE)]
        public static float Min(float x, float y) => x < y ? x : y;

        public static float MinMagnitude(float x, float y)
        {
            // This matches the IEEE 754:2019 `minimumMagnitude` function
            // It propagates NaN inputs back to the caller and
            // otherwise returns the input with a lesser magnitude.
            // It treats +0 as lesser than -0 as per the specification.
            float ax = Abs(x);
            float ay = Abs(y);

            if ((ax < ay) || float.IsNaN(ax))
                return x;

            if (ax == ay)
                return IsNegative_2(x) ? x : y;

            return y;
        }

        /// <summary>Returns an estimate of the reciprocal of a specified number.</summary>
        /// <param name="x">The number whose reciprocal is to be estimated.</param>
        /// <returns>An estimate of the reciprocal of <paramref name="x" />.</returns
        [IN(LINE)]
        public static float ReciprocalEstimate(float x)
        {
            return 1.0f / x;
        }

        /// <summary>Returns an estimate of the reciprocal square root of a specified number.</summary>
        /// <param name="x">The number whose reciprocal square root is to be estimated.</param>
        /// <returns>An estimate of the reciprocal square root <paramref name="x" />.</returns>
        [IN(LINE)]
        public static float ReciprocalSqrtEstimate(float x)
        {
            return 1.0f / Sqrt(x);
        }

        public static float Round(float x)
        {
            // Do not change this implementation without also updating MathF.Round(float),
            // This is based on the 'Berkeley SoftFloat Release 3e' algorithm

            uint bits = new FloatUIntUnion(x).uintValue;// BitConverter.SingleToUInt32Bits(x);
            byte biasedExponent = ExtractBiasedExponentFromBits(bits);

            if (biasedExponent <= 0x7E)
            {
                if ((bits << 1) == 0)
                {
                    // Exactly +/- zero should return the original value
                    return x;
                }
                // Any value less than or equal to 0.5 will always round to exactly zero
                // and any value greater than 0.5 will always round to exactly one. However,
                // we need to preserve the original sign for IEEE compliance.
                float result = ((biasedExponent == 0x7E) && (ExtractTrailingSignificandFromBits(bits) != 0)) ? 1.0f : 0.0f;
                return CopySign(result, x);
            }

            if (biasedExponent >= 0x96)
            {
                // Any value greater than or equal to 2^23 cannot have a fractional part,
                // So it will always round to exactly itself.
                return x;
            }

            // The absolute value should be greater than or equal to 1.0 and less than 2^23
            Debug.Assert((0x7F <= biasedExponent) && (biasedExponent <= 0x95));

            // Determine the last bit that represents the integral portion of the value
            // and the bits representing the fractional portion
            uint lastBitMask = 1U << (0x96 - biasedExponent);
            uint roundBitsMask = lastBitMask - 1;

            // Increment the first fractional bit, which represents the midpoint between
            // two integral values in the current window.
            bits += lastBitMask >> 1;

            if ((bits & roundBitsMask) == 0)
            {
                // If that overflowed and the rest of the fractional bits are zero
                // then we were exactly x.5 and we want to round to the even result
                bits &= ~lastBitMask;
            }
            else
            {
                // Otherwise, we just want to strip the fractional bits off, truncating
                // to the current integer value.
                bits &= ~roundBitsMask;
            }

            return new FloatIntUnion(bits).intValue;
        }

        [IN(LINE)]
        public static float Round(float x, int digits)
        {
            return Round(x, digits, MidpointRounding.ToEven);
        }

        [IN(LINE)]
        public static float Round(float x, MidpointRounding mode)
        {
            if (mode == MidpointRounding.ToEven)
                return Round(x);

            // For other platforms we use a fast managed implementation
            if (mode == MidpointRounding.AwayFromZero)
            {
                // manually fold BitDecrement(0.5f)
                return Truncate_2(x + CopySign(0.49999997f, x));
            }
            return Round(x, 0, mode);
        }

        public static unsafe float Round(float x, int digits, MidpointRounding mode)
        {
            if ((digits < 0) || (digits > maxRoundingDigits))
            {
                // throw new ArgumentOutOfRangeException(nameof(digits), SR.ArgumentOutOfRange_RoundingDigits_MathF);
                throw new ArgumentOutOfRangeException("throw new ArgumentOutOfRangeException(nameof(digits), SR.ArgumentOutOfRange_RoundingDigits_MathF);");
            }

            //    if (mode < MidpointRounding.ToEven || mode > MidpointRounding.ToPositiveInfinity)
            //    {
            //       // throw new ArgumentException(SR.Format(SR.Argument_InvalidEnumValue, mode, nameof(MidpointRounding)), nameof(mode));
            //        throw new ArgumentOutOfRangeException("throw new ArgumentException(SR.Format(SR.Argument_InvalidEnumValue, mode, nameof(MidpointRounding)), nameof(mode));");
            //    }

            if (Abs(x) < singleRoundLimit)
            {
                float power10 = RoundPower10Single[digits];

                x *= power10;

                switch (mode)
                {
                    // Rounds to the nearest value; if the number falls midway,
                    // it is rounded to the nearest value with an even least significant digit
                    case MidpointRounding.ToEven:
                        {
                            x = Round(x);
                            break;
                        }
                    // Rounds to the nearest value; if the number falls midway,
                    // it is rounded to the nearest value above (for positive numbers) or below (for negative numbers)
                    case MidpointRounding.AwayFromZero:
                        {
                            // manually fold BitDecrement(0.5f)
                            x = Truncate_2(x + CopySign(0.49999997f, x));
                            break;
                        }
                    //   // Directed rounding: Round to the nearest value, toward to zero
                    //   case MidpointRounding.ToZero:
                    //       {
                    //           x = Truncate_2(x);
                    //           break;
                    //       }
                    //   // Directed Rounding: Round down to the next value, toward negative infinity
                    //   case MidpointRounding.ToNegativeInfinity:
                    //       {
                    //           x = Floor(x);
                    //           break;
                    //       }
                    //   // Directed rounding: Round up to the next value, toward positive infinity
                    //   case MidpointRounding.ToPositiveInfinity:
                    //       {
                    //           x = Ceiling(x);
                    //           break;
                    //       }
                    default:
                        {
                            //throw new ArgumentException(SR.Format(SR.Argument_InvalidEnumValue, mode, nameof(MidpointRounding)), nameof(mode));
                            throw new ArgumentException("throw new ArgumentException(SR.Format(SR.Argument_InvalidEnumValue, mode, nameof(MidpointRounding)), nameof(mode));");
                        }
                }

                x /= power10;
            }

            return x;
        }







        public static unsafe float Truncate_1(float x)
        {
            //ModF(x, &x);
            //return x;
            return (float)Math.Truncate(x);
        }
        public static unsafe float Truncate_2(float x)
        {
            return (int)x;
        }

        public static float ScaleB(float x, int n)
        {
            // Implementation based on https://git.musl-libc.org/cgit/musl/tree/src/math/scalblnf.c
            // Performs the calculation x * 2^n efficiently. It constructs a float from 2^n by building
            // the correct biased exponent. If n is greater than the maximum exponent (127) or less than
            // the minimum exponent (-126), adjust x and n to compute correct result.

            float y = x;
            if (n > 127)
            {
                y *= SCALEB_C1;
                n -= 127;
                if (n > 127)
                {
                    y *= SCALEB_C1;
                    n -= 127;
                    if (n > 127)
                    {
                        n = 127;
                    }
                }
            }
            else if (n < -126)
            {
                y *= SCALEB_C2 * SCALEB_C3;
                n += 126 - 24;
                if (n < -126)
                {
                    y *= SCALEB_C2 * SCALEB_C3;
                    n += 126 - 24;
                    if (n < -126)
                    {
                        n = -126;
                    }
                }
            }

            float u = new FloatIntUnion(0x7f + n << 23).floatValue;
            return y * u;
        }

        [IN(LINE)]
        public static bool IsNegativeZero(this float v)
        {
            return 1f / v == float.NegativeInfinity;
        }

        [IN(LINE)]
        public static bool IsNegative_2(this float v)
        {
            return float.PositiveInfinity * v == float.NegativeInfinity;
        }

        [IN(LINE)]
        public static unsafe bool IsNegative_1(float f)
        {
            return new FloatIntUnion(f).intValue < 0;
        }

        internal const uint BiasedExponentMask = 0x7F80_0000;
        internal const int BiasedExponentShift = 23;
        internal const byte ShiftedBiasedExponentMask = (byte)(BiasedExponentMask >> BiasedExponentShift);
        internal const uint TrailingSignificandMask = 0x007F_FFFF;

        [IN(LINE)]
        internal static byte ExtractBiasedExponentFromBits(uint bits)
        {
            return (byte)((bits >> BiasedExponentShift) & ShiftedBiasedExponentMask);
        }

        [IN(LINE)]
        internal static uint ExtractTrailingSignificandFromBits(uint bits)
        {
            return bits & TrailingSignificandMask;
        }





        [IN(LINE)]
        public static float Ceiling(float x)
        {
            return (float)MathF.Ceiling(x);
        }
        [IN(LINE)]
        public static float Floor(float x)
        {
            return (float)MathF.Floor(x);
        }

        [IN(LINE)]
        public static double Ceiling(double x)
        {
            return Math.Ceiling(x);
        }
        [IN(LINE)]
        public static double Round(double x)
        {
            return Math.Round(x);
        }
        [IN(LINE)]
        public static double Floor(double x)
        {
            return Math.Floor(x);
        }




        //TODO протестировать скорость и возможно переработать

        [IN(LINE)]
        public static int Sign(int a)
        {
            return (a > 0 ? 1 : 0) - (a < 0 ? 1 : 0);
        }
        [IN(LINE)]
        public static float Sign(float a)
        {
            return (a > 0f ? 1f : 0f) - (a < 0f ? 1f : 0f);
        }
        [IN(LINE)]
        public static double Sign(double a)
        {
            return (a > 0d ? 1d : 0d) - (a < 0d ? 1d : 0d);
        }
        [IN(LINE)]
        public static int Sign2Int(float a)
        {
            return (a > 0f ? 1 : 0) - (a < 0f ? 1 : 0);
        }
        [IN(LINE)]
        public static int Sign2Int(double a)
        {
            return (a > 0d ? 1 : 0) - (a < 0d ? 1 : 0);
        }

        [IN(LINE)]
        public static int Abs(int x)
        {
            return x & 0x7FFFFFFF;
        }
        [IN(LINE)]
        public static long Abs(long x)
        {
            return x & 0x7FFFFFFF_FFFFFFFF;
        }
        [IN(LINE)]
        public static float Abs(float x)
        {
            return DM.AsFloat(DM.AsUInt(x) & 0x7FFFFFFF);
        }
        [IN(LINE)]
        public static double Abs(double x)
        {
            return DM.AsDouble(DM.AsULong(x) & 0x7FFFFFFF_FFFFFFFF);
        }

        [IN(LINE)]
        public static float Sqrt(float x)
        {
            return (float)MathF.Sqrt(x);
        }
        [IN(LINE)]
        public static double Sqrt(double x)
        {
            return Math.Sqrt(x);
        }
        [IN(LINE)]
        public static float Log(float x)
        {
            return (float)MathF.Log(x);
        }
        [IN(LINE)]
        public static double Log(double x)
        {
            return Math.Log(x);
        }
        [IN(LINE)]
        public static double Log(double x, double y)
        {
            return Math.Log(x, y);
        }
        [IN(LINE)]
        public static float Log2(float x)
        {
            return (float)MathF.Log(x, 2f);
        }
        [IN(LINE)]
        public static double Log2(double x)
        {
            return Math.Log(x, 2f);
        }
        [IN(LINE)]
        public static float Log10(float x)
        {
            return (float)MathF.Log10(x);
        }
        [IN(LINE)]
        public static double Log10(double x)
        {
            return Math.Log10(x);
        }

        [IN(LINE)]
        public static float Cos(float x)
        {
            return (float)MathF.Cos(x);
        }
        [IN(LINE)]
        public static double Cos(double x)
        {
            return Math.Cos(x);
        }
        [IN(LINE)]
        public static float Cosh(float x)
        {
            return (float)MathF.Cosh(x);
        }
        [IN(LINE)]
        public static double Cosh(double x)
        {
            return Math.Cosh(x);
        }
        [IN(LINE)]
        public static float Acos(float x)
        {
            return (float)MathF.Acos(x);
        }
        [IN(LINE)]
        public static double Acos(double x)
        {
            return Math.Acos(x);
        }
        [IN(LINE)]
        public static float Sin(float x)
        {
            return (float)MathF.Sin(x);
        }
        [IN(LINE)]
        public static double Sin(double x)
        {
            return Math.Sin(x);
        }
        [IN(LINE)]
        public static float Sinh(float x)
        {
            return (float)MathF.Sinh(x);
        }
        [IN(LINE)]
        public static double Sinh(double x)
        {
            return Math.Sinh(x);
        }
        [IN(LINE)]
        public static float Asin(float x)
        {
            return (float)MathF.Asin(x);
        }
        [IN(LINE)]
        public static double Asin(double x)
        {
            return Math.Asin(x);
        }
        [IN(LINE)]
        public static float Tan(float x)
        {
            return (float)MathF.Tan(x);
        }
        [IN(LINE)]
        public static double Tan(double x)
        {
            return Math.Tan(x);
        }
        [IN(LINE)]
        public static float Tanh(float x)
        {
            return (float)MathF.Tanh(x);
        }
        [IN(LINE)]
        public static double Tanh(double x)
        {
            return Math.Tanh(x);
        }
        [IN(LINE)]
        public static float Atan(float x)
        {
            return (float)MathF.Atan(x);
        }
        [IN(LINE)]
        public static double Atan(double x)
        {
            return Math.Atan(x);
        }
        [IN(LINE)]
        public static float Atan2(float x, float y)
        {
            return (float)MathF.Atan2(x, y);
        }
        [IN(LINE)]
        public static double Atan2(double x, double y)
        {
            return Math.Atan2(x, y);
        }

        [IN(LINE)]
        public static float Pow(float x, float y)
        {
            return (float)MathF.Pow(x, y);
        }
        [IN(LINE)]
        public static int Pow(int baseValue, int exponent)
        {
            // Обработка отрицательной степени
            if (exponent < 0)
            {
                if (baseValue == 0)
                    throw new DivideByZeroException("Base is zero and exponent is negative. Result is undefined.");
                if (baseValue == 1)
                    return 1;
                if (baseValue == -1)
                    return (exponent % 2 == 0) ? 1 : -1;
                throw new ArgumentException("Negative exponent is not supported for integer bases other than 1 or -1.", nameof(exponent));
            }

            // Обработка нулевой степени
            if (exponent == 0) { return 1; }


            // Алгоритм быстрого возведения в степень
            int result = 1;
            int currentBase = baseValue;
            int exp = exponent;

            while (exp > 0)
            {
                if ((exp & 1) != 0) // Если степень нечётная
                {
                    result *= currentBase;
                }

                currentBase *= currentBase; // Возведение в квадрат
                exp >>= 1; // Уменьшение степени вдвое
            }

            return result;
        }
        [IN(LINE)]
        public static uint Pow(uint baseValue, uint exponent)
        {
            // Обработка нулевой степени
            if (exponent == 0) { return 1; }


            // Алгоритм быстрого возведения в степень
            uint result = 1;
            uint currentBase = baseValue;
            uint exp = exponent;

            while (exp > 0)
            {
                if ((exp & 1) != 0) // Если степень нечётная
                {
                    result *= currentBase;
                }

                currentBase *= currentBase; // Возведение в квадрат
                exp >>= 1; // Уменьшение степени вдвое
            }

            return result;
        }

        [IN(LINE)]
        public static long Pow(long baseValue, long exponent)
        {
            // Обработка отрицательной степени
            if (exponent < 0)
            {
                if (baseValue == 0)
                    throw new DivideByZeroException("Base is zero and exponent is negative. Result is undefined.");
                if (baseValue == 1)
                    return 1;
                if (baseValue == -1)
                    return (exponent % 2 == 0) ? 1 : -1;
                throw new ArgumentException("Negative exponent is not supported for longeger bases other than 1 or -1.", nameof(exponent));
            }

            // Обработка нулевой степени
            if (exponent == 0) { return 1; }


            // Алгоритм быстрого возведения в степень
            long result = 1;
            long currentBase = baseValue;
            long exp = exponent;

            while (exp > 0)
            {
                if ((exp & 1) != 0) // Если степень нечётная
                {
                    result *= currentBase;
                }

                currentBase *= currentBase; // Возведение в квадрат
                exp >>= 1; // Уменьшение степени вдвое
            }

            return result;
        }
        [IN(LINE)]
        public static ulong Pow(ulong baseValue, ulong exponent)
        {
            // Обработка нулевой степени
            if (exponent == 0) { return 1; }


            // Алгоритм быстрого возведения в степень
            ulong result = 1;
            ulong currentBase = baseValue;
            ulong exp = exponent;

            while (exp > 0)
            {
                if ((exp & 1) != 0) // Если степень нечётная
                {
                    result *= currentBase;
                }

                currentBase *= currentBase; // Возведение в квадрат
                exp >>= 1; // Уменьшение степени вдвое
            }

            return result;
        }


        [IN(LINE)]
        public static double Pow(double x, double y)
        {
            return Math.Pow(x, y);
        }
        [IN(LINE)]
        public static float Exp(float pow)
        {
            return (float)MathF.Exp(pow);
        }
        [IN(LINE)]
        public static double Exp(double pow)
        {
            return Math.Exp(pow);
        }
        [IN(LINE)]
        public static float Exp2(float pow)
        {
            return (float)MathF.Exp(pow) * 0.69314718f;
        }
        [IN(LINE)]
        public static float Exp10(float pow)
        {
            return (float)MathF.Exp(pow) * 2.30258509f;
        }
        [IN(LINE)]
        public static double Exp2(double pow)
        {
            return Math.Exp(pow) * 0.693147180559945309d;
        }
        [IN(LINE)]
        public static double Exp10(double pow)
        {
            return Math.Exp(pow) * 2.302585092994045684d;
        }
        [IN(LINE)]
        public static float Truncate(float a)
        {
            return (float)MathF.Truncate(a);
        }
        [IN(LINE)]
        public static double Truncate(double a)
        {
            return Math.Truncate(a);
        }




    }
}