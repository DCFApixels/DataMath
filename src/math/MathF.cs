// Основано на реализации System.MathF лицензируемой по под лицензией MIT.
// Части кода, реализованные ниже, основаны на алгоритмах Berkeley SoftFloat Release 3e.

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace DCFApixels.DataMath.Internal
{
    internal static partial class MathF
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


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Abs(float x) => Math.Abs(x);

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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ReciprocalEstimate(float x)
        {
            return 1.0f / x;
        }

        /// <summary>Returns an estimate of the reciprocal square root of a specified number.</summary>
        /// <param name="x">The number whose reciprocal square root is to be estimated.</param>
        /// <returns>An estimate of the reciprocal square root <paramref name="x" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Round(float x, int digits)
        {
            return Round(x, digits, MidpointRounding.ToEven);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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


        


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sign(float x)
        {
            return Math.Sign(x);
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

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNegativeZero(this float v)
        {
            return 1f / v == float.NegativeInfinity;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNegative_2(this float v)
        {
            return float.PositiveInfinity * v == float.NegativeInfinity;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe bool IsNegative_1(float f)
        {
            return new FloatIntUnion(f).intValue < 0;
        }

        internal const uint BiasedExponentMask = 0x7F80_0000;
        internal const int BiasedExponentShift = 23;
        internal const byte ShiftedBiasedExponentMask = (byte)(BiasedExponentMask >> BiasedExponentShift);
        internal const uint TrailingSignificandMask = 0x007F_FFFF;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static byte ExtractBiasedExponentFromBits(uint bits)
        {
            return (byte)((bits >> BiasedExponentShift) & ShiftedBiasedExponentMask);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint ExtractTrailingSignificandFromBits(uint bits)
        {
            return bits & TrailingSignificandMask;
        }



        //TODO протестировать скорость и возможно переработать
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Ceiling(float x)
        {
            return (float)Math.Ceiling(x);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Floor(float x)
        {
            return (float)Math.Ceiling(x);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sqrt(float x)
        {
            return (float)Math.Sqrt(x);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Log(float x)
        {
            return (float)Math.Log(x);
        }
    }
}