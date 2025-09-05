#if DISABLE_DEBUG
#undef DEBUG
#endif
using DCFApixels.DataMath.Internal;
using System.ComponentModel;
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public static unsafe partial class DM //double
    {
        #region Abs/Sign
        [IN(LINE)] public static double Abs(double a) { return InternalMath.Abs(a); }
        [IN(LINE)] public static double Sign(double a) { return (a > 0d ? 1d : 0d) - (a < 0d ? 1d : 0d); }
        [IN(LINE)] public static double SoftSign(double a) { return a / (1d + InternalMath.Abs(a)); }
        [IN(LINE)] public static int Sign2Int(double a) { return (a > 0d ? 1 : 0) - (a < 0d ? 1 : 0); }
        #endregion

        #region Round/Floor/Ceil
        [IN(LINE)] public static double Round(double a) { return InternalMath.Round(a); }
        [IN(LINE)] public static int Round2Int(double a) { return (int)InternalMath.Round(a); }
        [IN(LINE)] public static double Floor(double a) { return InternalMath.Floor(a); }
        [IN(LINE)] public static int Floor2Int(double a) { return (int)InternalMath.Floor(a); }
        [IN(LINE)] public static double Ceil(double a) { return InternalMath.Ceiling(a); }
        [IN(LINE)] public static int Ceil2Int(double a) { return (int)InternalMath.Ceiling(a); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [IN(LINE)] public static uint Round2UInt(double a) { return (uint)InternalMath.Round(a); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        [IN(LINE)] public static uint Floor2UInt(double a) { return (uint)InternalMath.Floor(a); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        [IN(LINE)] public static uint Ceil2UInt(double a) { return (uint)InternalMath.Ceiling(a); }
        #endregion

        #region Clamp/Repeat/PingPong
        /// <summary> Clamps the value between min and max. </summary>
        [IN(LINE)]
        public static double Clamp(double a, double min, double max)
        {
            if (a < min) { return min; }
            if (a > max) { return max; }
            return a;
        }
        /// <summary> Clamps the value between 0 and 1. </summary>
        [IN(LINE)] public static double Clamp01(double a) { return Clamp(a, 0f, 1f); }
        /// <summary> Clamps the value between -1 and 1. </summary>
        [IN(LINE)] public static double ClampMirror1(double a) { return Clamp(a, -1f, 1f); }

        [IN(LINE)] public static double Repeat(double a, double length) { return Clamp(a - Floor(a / length) * length, 0f, length); }
        [IN(LINE)] public static double Repeat(double a, double min, double max) { return Repeat(a, max - min) + min; }
        [IN(LINE)] public static double Repeat01(double a) { return Repeat(a, 1f); }
        [IN(LINE)] public static double RepeatMirror1(double a) { return Repeat(a, -1f, 1f); }

        [IN(LINE)] public static double PingPong(double a, double length) { return length - Abs(Repeat(a, length * 2f) - length); }
        [IN(LINE)] public static double PingPong(double a, double min, double max) { return PingPong(a, max - min) + min; }
        [IN(LINE)] public static double PingPong01(double a) { return PingPong(a, 0f, 1f); }
        [IN(LINE)] public static double PingPongMirror1(double a) { return PingPong(a, -1f, 1f); }
        #endregion

        #region SmoothStep
        /// <summary> Clamps the value between from and to. </summary>
        [IN(LINE)]
        public static double SmoothStep(double from, double to, double a)
        {
            var t = Clamp01((a - from) / (to - from));
            return t * t * (3.0f - (2.0f * t));
        }
        /// <summary> Clamps the value between 0 and 1. </summary>
        [IN(LINE)] public static double SmoothStep01(double a) { return SmoothStep(0f, 1f, a); }
        /// <summary> Clamps the value between -1 and 1. </summary>
        [IN(LINE)] public static double SmoothStepMirror1(double a) { return SmoothStep(-1f, 1f, a); }
        #endregion

        #region All/Any
        [IN(LINE)] public static bool All(double a) { return a != default; }
        [IN(LINE)] public static bool Any(double a) { return a != default; }
        #endregion

        #region Min/Max/Sum
        [IN(LINE)] public static double Max(double a, double b) { return a > b ? a : b; }
        [IN(LINE)] public static double AbsMax(double a, double b) { return InternalMath.Abs(a) > InternalMath.Abs(b) ? a : b; }
        [IN(LINE)] public static double Min(double a, double b) { return a < b ? a : b; }
        [IN(LINE)] public static double AbsMin(double a, double b) { return InternalMath.Abs(a) < InternalMath.Abs(b) ? a : b; }
        [IN(LINE)] public static double CMax(double a) { return a; }
        [IN(LINE)] public static double CAbsMax(double a) { return a; }
        [IN(LINE)] public static double CMin(double a) { return a; }
        [IN(LINE)] public static double CAbsMin(double a) { return a; }
        [IN(LINE)] public static double CSum(double a) { return a; }
        #endregion

        #region Lerp
        [IN(LINE)] public static double Lerp(double start, double end, double t) { return start + t * (end - start); }
        [IN(LINE)] public static double LerpClamp(double start, double end, double t) { return Lerp(start, end, Clamp01(t)); }
        [IN(LINE)] public static double LerpRepeat(double start, double end, double t) { return Lerp(start, end, Repeat01(t)); }

        [IN(LINE)] public static double UnLerp(double start, double end, double a) { return (a - start) / (end - start); }
        [IN(LINE)] public static double UnLerpClamp(double start, double end, double a) { return Clamp01(UnLerp(start, end, a)); }
        [IN(LINE)] public static double UnLerpRepeat(double start, double end, double a) { return Repeat01(UnLerp(start, end, a)); }


        [IN(LINE)]
        public static double MoveTowards(double from, double to, double distance)
        {
            double dif = to - from;
            if (Abs(dif) <= distance) { return to; }
            return from + Sign(dif) * distance;
        }
        [IN(LINE)]
        public static double MoveTowards(double from, double to, double distance, out double excess)
        {
            double dif = to - from;
            excess = Abs(dif);
            if (excess <= distance)
            {
                excess = distance - excess;
                return to;
            }
            excess = 0f;
            return from + Sign(dif) * distance;
        }

        [IN(LINE)]
        public static double Remap(double oldStart, double oldEnd, double newStart, double newEnd, double v)
        {
            return Lerp(newStart, newEnd, UnLerp(oldStart, oldEnd, v));
        }




        [IN(LINE)]
        public static double LerpAngle(double start, double end, double t)
        {
            double angle = Repeat(end - start, 360f);
            if (angle > 180f) { angle -= 360f; }
            //double angle = Repeat(end - start, -180f, 180f);
            return start + angle * Clamp01(t);
        }
        [IN(LINE)]
        public static double DeltaAngle(double current, double target)
        {
            double angle = Repeat(target - current, 360f);
            if (angle > 180f) { angle -= 360f; }
            //double angle = Repeat(end - start, -180f, 180f);
            return angle;
        }
        [IN(LINE)]
        public static double MoveTowardsAngle(double current, double target, double maxDelta)
        {
            double delta = DeltaAngle(current, target);
            if (0f - maxDelta < delta && delta < maxDelta)
            {
                return target;
            }
            return MoveTowards(current, current + delta, maxDelta);
        }
        #endregion

        #region double State Checks
        [IN(LINE)] public static bool IsNormaldouble(double a) { return double.IsNormal(a); }
        [IN(LINE)] public static bool IsFinite(double a) { return double.IsFinite(a); }
        [IN(LINE)] public static bool IsNaN(double a) { return double.IsNaN(a); }
        [IN(LINE)] public static bool IsInfinity(double a) { return double.IsInfinity(a); }
        [IN(LINE)] public static bool IsNegativeInfinity(double a) { return double.IsNegativeInfinity(a); }
        [IN(LINE)] public static bool IsPositiveInfinity(double a) { return double.IsPositiveInfinity(a); }
        #endregion

        #region Color
        [IN(LINE)] public static double GammaToLinearSpace(double value) { const double Gamma = 2.2f; return Pow(value, Gamma); }
        [IN(LINE)] public static double LinearToGammaSpace(double value) { const double InverseGamma = 1.0f / 2.2f; return Pow(value, InverseGamma); }
        #endregion

        #region Approximately
        [IN(LINE)] public static bool Approximately(double a, double b) { return Approximately(a, b, Max(1E-06f * Max(Abs(a), Abs(b)), FloatEpsilon * 8f)); }
        [IN(LINE)] public static bool Approximately(double a, double b, double tolerance) { return Abs(b - a) < tolerance; }
        #endregion

        #region Pow2
        [IN(LINE)]
        public static double CeilPow2(double value)
        {
            ulong bits = *(ulong*)&value;
            bits = bits & ~DMBits.DoubleMantissaMask;
            return *(double*)&bits;
        }
        [IN(LINE)]
        public static double FloorPow2(double value)
        {
            const ulong EXP_ONE = DMBits.DoubleMantissaMask + 1;
            ulong bits = *(ulong*)&value;
            ulong mantissa = bits & DMBits.DoubleMantissaMask;
            bits = bits & ~DMBits.DoubleMantissaMask;

            bits = mantissa == 0 ? bits : bits + EXP_ONE;
            return *(double*)&bits;
        }
        [IN(LINE)]
        public static double RoundPow2(double value)
        {
            const ulong EXP_ONE = DMBits.DoubleMantissaMask + 1;
            ulong bits = *(ulong*)&value;
            bits = bits & ~DMBits.DoubleMantissaMask;
            ulong floorbits = bits - EXP_ONE;

            double ceil = *(double*)&bits;
            double floor = *(double*)&floorbits;
            if (value - floor < ceil - value)
            {
                return floor;
            }
            return ceil;
        }
        [IN(LINE)]
        public static bool IsPow2(double value)
        {
            ulong bits = *(ulong*)&value;
            ulong exponent = bits & DMBits.DoubleExponentMask;
            ulong mantissa = bits & DMBits.DoubleMantissaMask;

            return mantissa == 0 && exponent != 0 // степень двойки
                && exponent != DMBits.DoubleExponentMask; // не IsNan и не IsInfinity
        }
        #endregion

        #region Other
        [IN(LINE)] public static double Length(double a) { return a; }
        [IN(LINE)] public static double LengthSqr(double a) { return Sqr(a); }
        [IN(LINE)] public static double Distance(double a, double b) { return b - a; }
        [IN(LINE)] public static double DistanceSqr(double a, double b) { return Sqr(b - a); }
        [IN(LINE)] public static double Normalize(double a) { return a < 0d ? -1d : 1d; }

        [IN(LINE)] public static double Project(double a, double ontoB) { return (Dot(a, ontoB) / Dot(ontoB, ontoB)) * ontoB; }
        [IN(LINE)]
        public static double ProjectSafe(double a, double ontoB, double defaultValue = 0)
        {
            var proj = Project(a, ontoB);
            return Select(defaultValue, proj, IsInfinity(proj)/*all*/);
        }
        //[IN(LINE)] public static double3 Cross(double3 a, double3 b) { return (a * b.yzx - a.yzx * b).yzx; }
        [IN(LINE)] public static double Reflect(double v, double n) { return v - 2f * n * Dot(v, n); }

        [IN(LINE)] public static double Select(double falseValue, double trueValue, bool test) { return test ? trueValue : falseValue; }
        [IN(LINE)] public static double Step(double threshold, double a) { return Select(0.0f, 1.0f, a >= threshold); }

        /// <summary> Convert Radians to Degrees. x * 57.296~ </summary>
        [IN(LINE)] public static double Degrees(double a) { return a * Rad2Deg; }
        /// <summary> Convert Degrees to Radians. x * 0.0175~ </summary>
        [IN(LINE)] public static double Radians(double a) { return a * Deg2Rad; }

        [IN(LINE)] public static double Cos(double a) { return InternalMath.Cos(a); }
        [IN(LINE)] public static double Cosh(double a) { return InternalMath.Cosh(a); }
        [IN(LINE)] public static double Acos(double a) { return InternalMath.Acos(a); }
        [IN(LINE)] public static double Sin(double a) { return InternalMath.Sin(a); }
        [IN(LINE)] public static double Sinh(double a) { return InternalMath.Sinh(a); }
        [IN(LINE)] public static double Asin(double a) { return InternalMath.Asin(a); }

        [IN(LINE)] public static double Atan(double a) { return InternalMath.Atan(a); }
        [IN(LINE)] public static double Atan2(double a, double b) { return InternalMath.Atan2(a, b); }

        [IN(LINE)] public static double Dot(double a, double b) { return a * b; }
        [IN(LINE)] public static double Sqr(double a) { return a * a; }
        [IN(LINE)] public static double Sqrt(double a) { return InternalMath.Sqrt(a); }
        [IN(LINE)] public static double RSqrt(double a) { return 1f / InternalMath.Sqrt(a); }
        [IN(LINE)] public static double Pow(double a, double b) { return InternalMath.Pow(a, b); }
        [IN(LINE)] public static double Exp(double pow) { return InternalMath.Exp(pow); }
        [IN(LINE)] public static double Exp2(double pow) { return InternalMath.Exp2(pow); }
        [IN(LINE)] public static double Exp10(double pow) { return InternalMath.Exp10(pow); }
        [IN(LINE)] public static double Log(double f, double p) { return InternalMath.Log(f, p); }
        [IN(LINE)] public static double Log(double f) { return InternalMath.Log(f); }
        [IN(LINE)] public static double Log2(double f) { return InternalMath.Log2(f); }
        [IN(LINE)] public static double Log10(double f) { return InternalMath.Log10(f); }

        [IN(LINE)] public static double Tan(double a) { return InternalMath.Tan(a); }
        [IN(LINE)] public static double Tanh(double a) { return InternalMath.Tanh(a); }

        [IN(LINE)] public static double Truncate(double a) { return InternalMath.Truncate(a); }
        #endregion


        #region Hash
        [IN(LINE)] public static uint UHash(double v) => unchecked((uint)Hash(v));
        [IN(LINE)]
        public static unsafe int Hash(double v)
        {
            long bits = *(long*)&v;
            // Optimized check for IsNan() || IsZero()
            if (((bits - 1) & 0x7FFFFFFFFFFFFFFF) >= 0x7FF0000000000000)
            {
                // Ensure that all NaNs and both zeros have the same Hash code
                bits &= 0x7FF0000000000000;
            }
            return unchecked((int)bits) ^ ((int)(bits >> 32));
        }
        #endregion

        #region Component iteration operations
        [IN(LINE)] public static double CMax(double a, double b) { return Max(a, b); }
        [IN(LINE)] public static double CMax(double a, double b, double c) { return Max(Max(a, b), c); }
        [IN(LINE)] public static double CMax(double a, double b, double c, double d) { return Max(CMax(a, b, c), d); }
        [IN(LINE)] public static double CMax(double a, double b, double c, double d, double e) { return Max(CMax(a, b, c, d), e); }
        [IN(LINE)] public static double CMax(double a, double b, double c, double d, double e, double f) { return Max(CMax(a, b, c, d, e), f); }
        [IN(LINE)] public static double CMax(double a, double b, double c, double d, double e, double f, double g) { return Max(CMax(a, b, c, d, e, f), g); }
        [IN(LINE)] public static double CMax(double a, double b, double c, double d, double e, double f, double g, double h) { return Max(CMax(a, b, c, d, e, f, g), h); }

        [IN(LINE)] public static double CAbsMax(double a, double b) { return AbsMax(a, b); }
        [IN(LINE)] public static double CAbsMax(double a, double b, double c) { return AbsMax(AbsMax(a, b), c); }
        [IN(LINE)] public static double CAbsMax(double a, double b, double c, double d) { return AbsMax(CAbsMax(a, b, c), d); }
        [IN(LINE)] public static double CAbsMax(double a, double b, double c, double d, double e) { return AbsMax(CAbsMax(a, b, c, d), e); }
        [IN(LINE)] public static double CAbsMax(double a, double b, double c, double d, double e, double f) { return AbsMax(CAbsMax(a, b, c, d, e), f); }
        [IN(LINE)] public static double CAbsMax(double a, double b, double c, double d, double e, double f, double g) { return AbsMax(CAbsMax(a, b, c, d, e, f), g); }
        [IN(LINE)] public static double CAbsMax(double a, double b, double c, double d, double e, double f, double g, double h) { return AbsMax(CAbsMax(a, b, c, d, e, f, g), h); }

        [IN(LINE)] public static double CMin(double a, double b) { return Min(a, b); }
        [IN(LINE)] public static double CMin(double a, double b, double c) { return Min(Min(a, b), c); }
        [IN(LINE)] public static double CMin(double a, double b, double c, double d) { return Min(CMin(a, b, c), d); }
        [IN(LINE)] public static double CMin(double a, double b, double c, double d, double e) { return Min(CMin(a, b, c, d), e); }
        [IN(LINE)] public static double CMin(double a, double b, double c, double d, double e, double f) { return Min(CMin(a, b, c, d, e), f); }
        [IN(LINE)] public static double CMin(double a, double b, double c, double d, double e, double f, double g) { return Min(CMin(a, b, c, d, e, f), g); }
        [IN(LINE)] public static double CMin(double a, double b, double c, double d, double e, double f, double g, double h) { return Min(CMin(a, b, c, d, e, f, g), h); }

        [IN(LINE)] public static double CAbsMin(double a, double b) { return AbsMin(a, b); }
        [IN(LINE)] public static double CAbsMin(double a, double b, double c) { return AbsMin(AbsMin(a, b), c); }
        [IN(LINE)] public static double CAbsMin(double a, double b, double c, double d) { return AbsMin(CAbsMin(a, b, c), d); }
        [IN(LINE)] public static double CAbsMin(double a, double b, double c, double d, double e) { return AbsMin(CAbsMin(a, b, c, d), e); }
        [IN(LINE)] public static double CAbsMin(double a, double b, double c, double d, double e, double f) { return AbsMin(CAbsMin(a, b, c, d, e), f); }
        [IN(LINE)] public static double CAbsMin(double a, double b, double c, double d, double e, double f, double g) { return AbsMin(CAbsMin(a, b, c, d, e, f), g); }
        [IN(LINE)] public static double CAbsMin(double a, double b, double c, double d, double e, double f, double g, double h) { return AbsMin(CAbsMin(a, b, c, d, e, f, g), h); }


        [IN(LINE)]
        public static double CMax<T>(T a, double _ = default) where T : IVectorN<double>
        {
            switch (a.Count)
            {
                case 0: Throw.ZeroLengthArgument(nameof(a)); break;
                case 1: return a[0];
                case 2: return Max(a[0], a[1]);
                case 3: return CMax(a[0], a[1], a[2]);
                case 4: return CMax(a[0], a[1], a[2], a[3]);
                default:
                    var result = a[0];
                    for (int i = 1; i < a.Count; i++)
                    {
                        result = Max(result, a[i]);
                    }
                    return result;
            }
            return default;
        }
        [IN(LINE)]
        public static double CAbsMax<T>(T a, double _ = default) where T : IVectorN<double>
        {
            switch (a.Count)
            {
                case 0: Throw.ZeroLengthArgument(nameof(a)); break;
                case 1: return a[0];
                case 2: return AbsMax(a[0], a[1]);
                case 3: return CAbsMax(a[0], a[1], a[2]);
                case 4: return CAbsMax(a[0], a[1], a[2], a[3]);
                default:
                    var result = a[0];
                    for (int i = 1; i < a.Count; i++)
                    {
                        result = AbsMax(result, a[i]);
                    }
                    return result;
            }
            return default;
        }
        [IN(LINE)]
        public static double CMin<T>(T a, double _ = default) where T : IVectorN<double>
        {
            switch (a.Count)
            {
                case 0: Throw.ZeroLengthArgument(nameof(a)); break;
                case 1: return a[0];
                case 2: return Min(a[0], a[1]);
                case 3: return CMin(a[0], a[1], a[2]);
                case 4: return CMin(a[0], a[1], a[2], a[3]);
                default:
                    var result = a[0];
                    for (int i = 1; i < a.Count; i++)
                    {
                        result = Min(result, a[i]);
                    }
                    return result;
            }
            return default;
        }
        [IN(LINE)]
        public static double CAbsMin<T>(T a, double _ = default) where T : IVectorN<double>
        {
            switch (a.Count)
            {
                case 0: Throw.ZeroLengthArgument(nameof(a)); break;
                case 1: return a[0];
                case 2: return AbsMin(a[0], a[1]);
                case 3: return CAbsMin(a[0], a[1], a[2]);
                case 4: return CAbsMin(a[0], a[1], a[2], a[3]);
                default:
                    var result = a[0];
                    for (int i = 1; i < a.Count; i++)
                    {
                        result = AbsMin(result, a[i]);
                    }
                    return result;
            }
            return default;
        }

        [IN(LINE)]
        public static double CSum<T>(T a, double _ = default) where T : IVectorN<double>
        {
            switch (a.Count)
            {
                case 0: return 0;
                case 1: return a[0];
                case 2: return a[0] + a[1];
                case 3: return a[0] + a[1] + a[2];
                case 4: return a[0] + a[1] + a[2] + a[3];
                default:
                    var result = a[0] + a[1] + a[2] + a[3];
                    for (int i = 4; i < a.Count; i++)
                    {
                        result += a[i];
                    }
                    return result;
            }
        }
        [IN(LINE)] public static uint UHash<TVector>(TVector v, double _ = default) where TVector : IVectorN<double> { return unchecked((uint)Hash<TVector>(v)); }
        [IN(LINE)]
        public static int Hash<TVector>(TVector v, double _ = default) where TVector : IVectorN<double>
        {
            int bits = 0;
            for (int i = 0; i < v.Count; i++)
            {
                bits ^= Hash(v[i]);
            }
            return bits;
        }
        #endregion
    }
}