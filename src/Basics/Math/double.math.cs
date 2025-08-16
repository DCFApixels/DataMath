using DCFApixels.DataMath.Internal;
using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public static partial class DM //double
    {
        #region Abs/Sign
        [IN(LINE)] public static double Abs(double a) { return InternalMath.Abs(a); }
        [IN(LINE)] public static double Sign(double a) { return (a > 0f ? 1f : 0f) - (a < 0f ? 1f : 0f); }
        [IN(LINE)] public static int Sign2Int(double a) { return (a > 0f ? 1 : 0) - (a < 0f ? 1 : 0); }
        #endregion

        #region Round/Floor/Ceil
        [IN(LINE)] public static double Round(double a) { return InternalMath.Round(a); }
        [IN(LINE)] public static int Round2Int(double a) { return (int)InternalMath.Round(a); }
        [IN(LINE)] public static double Floor(double a) { return InternalMath.Floor(a); }
        [IN(LINE)] public static int Floor2Int(double a) { return (int)InternalMath.Floor(a); }
        [IN(LINE)] public static double Ceil(double a) { return InternalMath.Ceiling(a); }
        [IN(LINE)] public static int Ceil2Int(double a) { return (int)InternalMath.Ceiling(a); }
        #endregion

        #region Clamp/Repeat/PingPong
        /// <summary> Clamps the value between min and max. </summary>
        [IN(LINE)]
        public static double Clamp(double a, double min, double max)
        {
            if (a < min) return min;
            if (a > max) return max;
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
        [IN(LINE)] public static double SmoothStep01(double a) { return SmoothStep(a, 0f, 1f); }
        /// <summary> Clamps the value between -1 and 1. </summary>
        [IN(LINE)] public static double SmoothStepMirror1(double a) { return SmoothStep(a, -1f, 1f); }
        #endregion

        #region Min/Max
        [IN(LINE)] public static double Max(double a, double b) { return a > b ? a : b; }
        [IN(LINE)] public static double AbsMax(double a, double b) { return InternalMath.Abs(a) > InternalMath.Abs(b) ? a : b; }
        [IN(LINE)] public static double Min(double a, double b) { return a < b ? a : b; }
        [IN(LINE)] public static double AbsMin(double a, double b) { return InternalMath.Abs(a) < InternalMath.Abs(b) ? a : b; }
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
        [IN(LINE)] public static bool Approximately(double a, double b) { return Approximately(a, b, Max(1E-06f * Max(Abs(a), Abs(b)), Epsilon * 8f)); }
        [IN(LINE)] public static bool Approximately(double a, double b, double tolerance) { return Abs(b - a) < tolerance; }
        #endregion

        #region Pow2
        //public static int CeilPow2(int value)
        //{
        //    value--;
        //    value |= value >> 16;
        //    value |= value >> 8;
        //    value |= value >> 4;
        //    value |= value >> 2;
        //    value |= value >> 1;
        //    return value + 1;
        //}
        //public static int FloorPow2(int value)
        //{
        //    var result = CeilPow2(value);
        //    return result == value ? value : result >> 1;
        //}
        //public static int RoundPow2(int value)
        //{
        //    value = CeilPow2(value);
        //    int floor = value >> 1;
        //    if (value - floor < value - value)
        //    {
        //        return floor;
        //    }
        //    return value;
        //}
        //[IN(LINE)] public static bool IsPow2(int value { return (value & (value - 1)) == 0; }
        #endregion

        #region Other
        [IN(LINE)] public static double Length(double a) { return Sqrt(Dot(a, a)); }
        [IN(LINE)] public static double LengthSqr(double a) { return Dot(a, a); }
        [IN(LINE)] public static double Distance(double a, double b) { return Length(b - a); }
        [IN(LINE)] public static double DistanceSqr(double a, double b) { return LengthSqr(b - a); }
        [IN(LINE)] public static double Normalize(double a) { return 1.0f / Sqrt(Dot(a, a)) * a; }

        [IN(LINE)] public static double Dot(double a, double b) { return a * b; }
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

        [IN(LINE)] public static double Sqr(double a) { return a * a; }
        [IN(LINE)] public static double Pow(double a, double b) { return InternalMath.Pow(a, b); }
        [IN(LINE)] public static double Exp(double pow) { return InternalMath.Exp(pow); }
        [IN(LINE)] public static double Exp2(double pow) { return InternalMath.Exp2(pow); }
        [IN(LINE)] public static double Exp10(double pow) { return InternalMath.Exp10(pow); }
        [IN(LINE)] public static double Log(double f, double p) { return InternalMath.Log(f, p); }
        [IN(LINE)] public static double Log(double f) { return InternalMath.Log(f); }
        [IN(LINE)] public static double Log2(double f) { return InternalMath.Log2(f); }
        [IN(LINE)] public static double Log10(double f) { return InternalMath.Log10(f); }
        [IN(LINE)] public static double Sqrt(double a) { return InternalMath.Sqrt(a); }

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
        [IN(LINE)] public static uint UHash<TVector>(TVector v, double _ = default) where TVector : IVectorN<double> { return unchecked((uint)Hash<TVector>(v)); }
        [IN(LINE)]
        public static int Hash<TVector>(TVector v, double _ = default) where TVector : IVectorN<double>
        {
            int bits = 0;
            for (int i = 0; i < v.count; i++)
            {
                bits ^= Hash(v[i]);
            }
            return bits;
        }
        #endregion
    }
}