#if DISABLE_DEBUG
#undef DEBUG
#endif
using DCFApixels.DataMath.Internal;
using System.ComponentModel;
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public static partial class DM // float self
    {

    }
    public static unsafe partial class DM // float
    {
        #region Abs/Sign
        [IN(LINE)] public static float Abs(float a) { return InternalMath.Abs(a); }
        [IN(LINE)] public static float Sign(float a) { return (a > 0f ? 1f : 0f) - (a < 0f ? 1f : 0f); }
        [IN(LINE)] public static float SoftSign(float a) { return a / (1f + InternalMath.Abs(a)); }
        [IN(LINE)] public static int Sign2Int(float a) { return (a > 0f ? 1 : 0) - (a < 0f ? 1 : 0); }
        #endregion

        #region Round/Floor/Ceil
        [IN(LINE)] public static float Round(float a) { return InternalMath.Round(a); }
        [IN(LINE)] public static int Round2Int(float a) { return (int)InternalMath.Round(a); }
        [IN(LINE)] public static float Floor(float a) { return InternalMath.Floor(a); }
        [IN(LINE)] public static int Floor2Int(float a) { return (int)InternalMath.Floor(a); }
        [IN(LINE)] public static float Ceil(float a) { return InternalMath.Ceiling(a); }
        [IN(LINE)] public static int Ceil2Int(float a) { return (int)InternalMath.Ceiling(a); }


        [EditorBrowsable(EditorBrowsableState.Never)]
        [IN(LINE)] public static uint Round2UInt(float a) { return (uint)InternalMath.Round(a); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        [IN(LINE)] public static uint Floor2UInt(float a) { return (uint)InternalMath.Floor(a); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        [IN(LINE)] public static uint Ceil2UInt(float a) { return (uint)InternalMath.Ceiling(a); }
        #endregion

        #region Clamp/Repeat/PingPong
        /// <summary> Clamps the value between min and max. </summary>
        [IN(LINE)]
        public static float Clamp(float a, float min, float max)
        {
            if (a < min) { return min; }
            if (a > max) { return max; }
            return a;
        }
        /// <summary> Clamps the value between 0 and 1. </summary>
        [IN(LINE)] public static float Clamp01(float a) { return Clamp(a, 0f, 1f); }
        /// <summary> Clamps the value between -1 and 1. </summary>
        [IN(LINE)] public static float ClampMirror1(float a) { return Clamp(a, -1f, 1f); }

        [IN(LINE)] public static float Repeat(float a, float length) { return Clamp(a - Floor(a / length) * length, 0f, length); }
        [IN(LINE)] public static float Repeat(float a, float min, float max) { return Repeat(a, max - min) + min; }
        [IN(LINE)] public static float Repeat01(float a) { return Repeat(a, 1f); }
        [IN(LINE)] public static float RepeatMirror1(float a) { return Repeat(a, -1f, 1f); }

        [IN(LINE)] public static float PingPong(float a, float length) { return length - Abs(Repeat(a, length * 2f) - length); }
        [IN(LINE)] public static float PingPong(float a, float min, float max) { return PingPong(a, max - min) + min; }
        [IN(LINE)] public static float PingPong01(float a) { return PingPong(a, 0f, 1f); }
        [IN(LINE)] public static float PingPongMirror1(float a) { return PingPong(a, -1f, 1f); }
        #endregion

        #region SmoothStep
        /// <summary> Clamps the value between from and to. </summary>
        [IN(LINE)]
        public static float SmoothStep(float from, float to, float a)
        {
            var t = Clamp01((a - from) / (to - from));
            return t * t * (3.0f - (2.0f * t));
        }
        /// <summary> Clamps the value between 0 and 1. </summary>
        [IN(LINE)] public static float SmoothStep01(float a) { return SmoothStep(0f, 1f, a); }
        /// <summary> Clamps the value between -1 and 1. </summary>
        [IN(LINE)] public static float SmoothStepMirror1(float a) { return SmoothStep(-1f, 1f, a); }
        #endregion

        #region All/Any
        [IN(LINE)] public static bool All(float a) { return a != default; }
        [IN(LINE)] public static bool Any(float a) { return a != default; }
        #endregion

        #region Min/Max/Sum
        [IN(LINE)] public static float Max(float a, float b) { return a > b ? a : b; }
        [IN(LINE)] public static float AbsMax(float a, float b) { return InternalMath.Abs(a) > InternalMath.Abs(b) ? a : b; }
        [IN(LINE)] public static float Min(float a, float b) { return a < b ? a : b; }
        [IN(LINE)] public static float AbsMin(float a, float b) { return InternalMath.Abs(a) < InternalMath.Abs(b) ? a : b; }
        [IN(LINE)] public static float CMax(float a) { return a; }
        [IN(LINE)] public static float CAbsMax(float a) { return a; }
        [IN(LINE)] public static float CMin(float a) { return a; }
        [IN(LINE)] public static float CAbsMin(float a) { return a; }
        [IN(LINE)] public static float CSum(float a) { return a; }
        #endregion

        #region Lerp/MoveTowards
        [IN(LINE)] public static float Lerp(float start, float end, float t) { return start + t * (end - start); }
        [IN(LINE)] public static float LerpClamp(float start, float end, float t) { return Lerp(start, end, Clamp01(t)); }
        [IN(LINE)] public static float LerpRepeat(float start, float end, float t) { return Lerp(start, end, Repeat01(t)); }

        [IN(LINE)] public static float UnLerp(float start, float end, float a) { return (a - start) / (end - start); }
        [IN(LINE)] public static float UnLerpClamp(float start, float end, float a) { return Clamp01(UnLerp(start, end, a)); }
        [IN(LINE)] public static float UnLerpRepeat(float start, float end, float a) { return Repeat01(UnLerp(start, end, a)); }

        [IN(LINE)]
        public static float Remap(float oldStart, float oldEnd, float newStart, float newEnd, float v)
        {
            return Lerp(newStart, newEnd, UnLerp(oldStart, oldEnd, v));
        }

        [IN(LINE)]
        public static float LerpAngle(float start, float end, float t)
        {
            float angle = Repeat(end - start, 360f);
            if (angle > 180f) { angle -= 360f; }
            //float angle = Repeat(end - start, -180f, 180f);
            return start + angle * t;
        }
        [IN(LINE)] public static float LerpAngleClamp(float start, float end, float t) { return LerpAngle(start, end, Clamp01(t)); }
        [IN(LINE)] public static float LerpAngleRepeat(float start, float end, float t) { return LerpAngle(start, end, Repeat01(t)); }

        [IN(LINE)]
        public static float DeltaAngle(float current, float target)
        {
            float angle = Repeat(target - current, 360f);
            if (angle > 180f) { angle -= 360f; }
            //float angle = Repeat(end - start, -180f, 180f);
            return angle;
        }

        [IN(LINE)]
        public static float MoveTowards(float from, float to, float distance)
        {
            float dif = to - from;
            if (Abs(dif) <= distance) { return to; }
            return from + Sign(dif) * distance;
        }
        [IN(LINE)]
        public static float MoveTowards(float from, float to, float distance, out float excess)
        {
            float dif = to - from;
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
        public static float MoveTowardsAngle(float current, float target, float maxDelta)
        {
            float delta = DeltaAngle(current, target);
            if (0f - maxDelta < delta && delta < maxDelta)
            {
                return target;
            }
            return MoveTowards(current, current + delta, maxDelta);
        }
        #endregion

        #region Real Value State Checks
        [IN(LINE)] public static bool IsNegative(float a) { return float.IsNegative(a); }
        [IN(LINE)] public static bool IsPositive(float a) { return !float.IsNegative(a); }
        [IN(LINE)] public static bool IsNormalReal(float a) { return float.IsNormal(a); }
        [IN(LINE)] public static bool IsFinite(float a) { return float.IsFinite(a); }
        [IN(LINE)] public static bool IsNaN(float a) { return float.IsNaN(a); }
        [IN(LINE)] public static bool IsInfinity(float a) { return float.IsInfinity(a); }
        [IN(LINE)] public static bool IsNegativeInfinity(float a) { return float.IsNegativeInfinity(a); }
        [IN(LINE)] public static bool IsPositiveInfinity(float a) { return float.IsPositiveInfinity(a); }
        #endregion

        #region Space Converts
        [IN(LINE)] public static float GammaToLinearSpace(float a) { const float Gamma = 2.2f; return Pow(a, Gamma); }
        [IN(LINE)] public static float LinearToGammaSpace(float a) { const float InverseGamma = 1.0f / 2.2f; return Pow(a, InverseGamma); }
        /// <summary> Convert Radians to Degrees. x * 57.296~ </summary>
        [IN(LINE)] public static float Degrees(float radians) { return radians * Rad2Deg; }
        /// <summary> Convert Degrees to Radians. x * 0.0175~ </summary>
        [IN(LINE)] public static float Radians(float degrees) { return degrees * Deg2Rad; }
        #endregion

        #region Approximately
        [IN(LINE)] public static bool Approximately(float a, float b) { return Approximately(a, b, Max(1E-06f * Max(Abs(a), Abs(b)), FloatEpsilon * 8f)); }
        [IN(LINE)] public static bool Approximately(float a, float b, float tolerance) { return Abs(b - a) < tolerance; }
        #endregion

        #region Pow2
        [IN(LINE)]
        public static float CeilPow2(float value)
        {
            uint bits = *(uint*)&value;
            bits = bits & ~DMBits.FloatMantissaMask;
            return *(float*)&bits;
        }
        [IN(LINE)]
        public static float FloorPow2(float value)
        {
            const uint EXP_ONE = DMBits.FloatMantissaMask + 1;
            uint bits = *(uint*)&value;
            uint mantissa = bits & DMBits.FloatMantissaMask;
            bits = bits & ~DMBits.FloatMantissaMask;

            bits = mantissa == 0 ? bits : bits + EXP_ONE;
            return *(float*)&bits;
        }
        [IN(LINE)]
        public static float RoundPow2(float value)
        {
            const uint EXP_ONE = DMBits.FloatMantissaMask + 1;
            uint bits = *(uint*)&value;
            bits = bits & ~DMBits.FloatMantissaMask;
            uint floorbits = bits - EXP_ONE;

            float ceil = *(float*)&bits;
            float floor = *(float*)&floorbits;
            if (value - floor < ceil - value)
            {
                return floor;
            }
            return ceil;
        }
        [IN(LINE)]
        public static bool IsPow2(float value)
        {
            uint bits = *(uint*)&value;
            uint exponent = bits & DMBits.FloatExponentMask;
            uint mantissa = bits & DMBits.FloatMantissaMask;

            return mantissa == 0 && exponent != 0 // степень двойки
                && exponent != DMBits.FloatExponentMask; // не IsNan и не IsInfinity
        }
        #endregion

        #region Length/Distance/Normalize
        [IN(LINE)] public static float Length(float a) { return a; }
        [IN(LINE)] public static float LengthSqr(float a) { return Sqr(a); }
        [IN(LINE)] public static float Distance(float a, float b) { return b - a; }
        [IN(LINE)] public static float DistanceSqr(float a, float b) { return Sqr(b - a); }
        [IN(LINE)] public static float Normalize(float a) { return a < 0f ? -1f : 1f; }
        [IN(LINE)] public static float NormalizeSafe(float a, float defaultvalue = 0f) { return a == 0f ? defaultvalue : Normalize(a); }
        [IN(LINE)] public static bool IsNormalized(float a) { return Approximately(a - 1f, 0f, FloatZeroTolerance); }
        #endregion

        #region Other
        [IN(LINE)] public static float Project(float a, float ontoB) { return (Dot(a, ontoB) / Dot(ontoB, ontoB)) * ontoB; }
        [IN(LINE)]
        public static float ProjectSafe(float a, float ontoB, float defaultValue = 0)
        {
            var proj = Project(a, ontoB);
            return Select(defaultValue, proj, IsInfinity(proj)/*all*/);
        }
        //[IN(LINE)] public static float3 Cross(float3 a, float3 b) { return (a * b.yzx - a.yzx * b).yzx; }
        [IN(LINE)] public static float Reflect(float v, float n) { return v - 2f * n * Dot(v, n); }

        [IN(LINE)] public static float Select(float falseValue, float trueValue, bool test) { return test ? trueValue : falseValue; }
        [IN(LINE)] public static float Step(float threshold, float a) { return Select(0.0f, 1.0f, a >= threshold); }
        [IN(LINE)] public static int Step2Int(float threshold, float a) { return Select(0, 1, a >= threshold); }

        [IN(LINE)] public static float Cos(float a) { return InternalMath.Cos(a); }
        [IN(LINE)] public static float Cosh(float a) { return InternalMath.Cosh(a); }
        [IN(LINE)] public static float Acos(float a) { return InternalMath.Acos(a); }
        [IN(LINE)] public static float Sin(float a) { return InternalMath.Sin(a); }
        [IN(LINE)] public static float Sinh(float a) { return InternalMath.Sinh(a); }
        [IN(LINE)] public static float Asin(float a) { return InternalMath.Asin(a); }

        [IN(LINE)] public static float Atan(float a) { return InternalMath.Atan(a); }
        [IN(LINE)] public static float Atan2(float a, float b) { return InternalMath.Atan2(a, b); }

        [IN(LINE)] public static float Dot(float a, float b) { return a * b; }
        [IN(LINE)] public static float Sqr(float a) { return a * a; }
        [IN(LINE)] public static float Sqrt(float a) { return InternalMath.Sqrt(a); }
        [IN(LINE)] public static float RSqrt(float a) { return 1f / InternalMath.Sqrt(a); }
        [IN(LINE)] public static float Pow(float a, float b) { return InternalMath.Pow(a, b); }
        [IN(LINE)] public static float Exp(float pow) { return InternalMath.Exp(pow); }
        [IN(LINE)] public static float Exp2(float pow) { return InternalMath.Exp2(pow); }
        [IN(LINE)] public static float Exp10(float pow) { return InternalMath.Exp10(pow); }
        [IN(LINE)] public static float Log(float f, float p) { return InternalMath.Log(f, p); }
        [IN(LINE)] public static float Log(float f) { return InternalMath.Log(f); }
        [IN(LINE)] public static float Log2(float f) { return InternalMath.Log2(f); }
        [IN(LINE)] public static float Log10(float f) { return InternalMath.Log10(f); }

        [IN(LINE)] public static float Tan(float a) { return InternalMath.Tan(a); }
        [IN(LINE)] public static float Tanh(float a) { return InternalMath.Tanh(a); }

        [IN(LINE)] public static float Truncate(float a) { return InternalMath.Truncate(a); }
        #endregion


        #region Hash
        [IN(LINE)] public static uint UHash(float v) { return unchecked((uint)Hash(v)); }
        [IN(LINE)]
        public static unsafe int Hash(float v)
        {
            //return v.GetHashCode();
            int bits = *(int*)&v;
            // Optimized check for IsNan() || IsZero()
            if (((bits - 1) & 0x7FFFFFFF) >= 0x7F800000)
            {
                // Ensure that all NaNs and both zeros have the same Hash code
                bits &= 0x7F800000;
            }
            return bits;
        }
        #endregion

        #region Component iteration operations
        [IN(LINE)] public static float CMax(float a, float b) { return Max(a, b); }
        [IN(LINE)] public static float CMax(float a, float b, float c) { return Max(Max(a, b), c); }
        [IN(LINE)] public static float CMax(float a, float b, float c, float d) { return Max(Max(a, b), Max(c, d)); }
        [IN(LINE)] public static float CMax(float a, float b, float c, float d, float e) { return Max(CMax(a, b, c, d), e); }
        [IN(LINE)] public static float CMax(float a, float b, float c, float d, float e, float f) { return Max(CMax(a, b, c, d), Max(e, f)); }
        [IN(LINE)] public static float CMax(float a, float b, float c, float d, float e, float f, float g) { return Max(CMax(a, b, c, d), Max(Max(a, b), c)); }
        [IN(LINE)] public static float CMax(float a, float b, float c, float d, float e, float f, float g, float h) { return Max(CMax(a, b, c, d), CMax(e, f, g, h)); }

        [IN(LINE)] public static float CAbsMax(float a, float b) { return AbsMax(a, b); }
        [IN(LINE)] public static float CAbsMax(float a, float b, float c) { return AbsMax(AbsMax(a, b), c); }
        [IN(LINE)] public static float CAbsMax(float a, float b, float c, float d) { return AbsMax(AbsMax(a, b), AbsMax(c, d)); }
        [IN(LINE)] public static float CAbsMax(float a, float b, float c, float d, float e) { return AbsMax(CAbsMax(a, b, c, d), e); }
        [IN(LINE)] public static float CAbsMax(float a, float b, float c, float d, float e, float f) { return AbsMax(CAbsMax(a, b, c, d), AbsMax(e, f)); }
        [IN(LINE)] public static float CAbsMax(float a, float b, float c, float d, float e, float f, float g) { return AbsMax(CAbsMax(a, b, c, d), AbsMax(AbsMax(a, b), c)); }
        [IN(LINE)] public static float CAbsMax(float a, float b, float c, float d, float e, float f, float g, float h) { return AbsMax(CAbsMax(a, b, c, d), CAbsMax(e, f, g, h)); }

        [IN(LINE)] public static float CMin(float a, float b) { return Min(a, b); }
        [IN(LINE)] public static float CMin(float a, float b, float c) { return Min(Min(a, b), c); }
        [IN(LINE)] public static float CMin(float a, float b, float c, float d) { return Min(Min(a, b), Min(c, d)); }
        [IN(LINE)] public static float CMin(float a, float b, float c, float d, float e) { return Min(CMin(a, b, c, d), e); }
        [IN(LINE)] public static float CMin(float a, float b, float c, float d, float e, float f) { return Min(CMin(a, b, c, d), Min(e, f)); }
        [IN(LINE)] public static float CMin(float a, float b, float c, float d, float e, float f, float g) { return Min(CMin(a, b, c, d), Min(Min(a, b), c)); }
        [IN(LINE)] public static float CMin(float a, float b, float c, float d, float e, float f, float g, float h) { return Min(CMin(a, b, c, d), CMin(e, f, g, h)); }

        [IN(LINE)] public static float CAbsMin(float a, float b) { return AbsMin(a, b); }
        [IN(LINE)] public static float CAbsMin(float a, float b, float c) { return AbsMin(AbsMin(a, b), c); }
        [IN(LINE)] public static float CAbsMin(float a, float b, float c, float d) { return AbsMin(AbsMin(a, b), AbsMin(c, d)); }
        [IN(LINE)] public static float CAbsMin(float a, float b, float c, float d, float e) { return AbsMin(CAbsMin(a, b, c, d), e); }
        [IN(LINE)] public static float CAbsMin(float a, float b, float c, float d, float e, float f) { return AbsMin(CAbsMin(a, b, c, d), AbsMin(e, f)); }
        [IN(LINE)] public static float CAbsMin(float a, float b, float c, float d, float e, float f, float g) { return AbsMin(CAbsMin(a, b, c, d), AbsMin(AbsMin(a, b), c)); }
        [IN(LINE)] public static float CAbsMin(float a, float b, float c, float d, float e, float f, float g, float h) { return AbsMin(CAbsMin(a, b, c, d), CAbsMin(e, f, g, h)); }


        [IN(LINE)]
        public static float CMax<T>(T a, float _ = default) where T : IVectorN<float>
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
        public static float CAbsMax<T>(T a, float _ = default) where T : IVectorN<float>
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
        public static float CMin<T>(T a, float _ = default) where T : IVectorN<float>
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
        public static float CAbsMin<T>(T a, float _ = default) where T : IVectorN<float>
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
        public static float CSum<T>(T a, float _ = default) where T : IVectorN<float>
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
        [IN(LINE)] public static uint UHash<TVector>(TVector v, float _ = default) where TVector : IVectorN<float> { return unchecked((uint)Hash<TVector>(v)); }
        [IN(LINE)]
        public static int Hash<TVector>(TVector v, float _ = default) where TVector : IVectorN<float>
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

    public static partial class DMBasic // IVector1<float>
    {
        [IN(LINE)] public static T New<T>(float x) where T : unmanaged, IVector1<float> { T r = default; r.x = x; return r; }
        [IN(LINE)] public static float ToBasic<T>(this T a, _1_ _ = default) where T : unmanaged, IVector1Impl<float> { return a.x; }
        [IN(LINE)] public static T Add<T>(T a, T b, _1_ _ = default) where T : unmanaged, IVector1Impl<float> { return New<T>(a.x + b.x); }
        [IN(LINE)] public static T Sub<T>(T a, T b, _1_ _ = default) where T : unmanaged, IVector1Impl<float> { return New<T>(a.x - b.x); }
        [IN(LINE)] public static T Mul<T>(T a, T b, _1_ _ = default) where T : unmanaged, IVector1Impl<float> { return New<T>(a.x * b.x); }
        [IN(LINE)] public static T Div<T>(T a, T b, _1_ _ = default) where T : unmanaged, IVector1Impl<float> { return New<T>(a.x / b.x); }
        [IN(LINE)] public static T Mod<T>(T a, T b, _1_ _ = default) where T : unmanaged, IVector1Impl<float> { return New<T>(a.x % b.x); }
        [IN(LINE)] public static bool Equals<T>(T a, T b, _1_ _ = default) where T : unmanaged, IVector1Impl<float> { return a.x == b.x; }
        [IN(LINE)] public static bool Greater<T>(T a, T b, _1_ _ = default) where T : unmanaged, IVector1Impl<float> { return a.x > b.x; }
        [IN(LINE)] public static bool Less<T>(T a, T b, _1_ _ = default) where T : unmanaged, IVector1Impl<float> { return a.x < b.x; }
        [IN(LINE)] public static bool GreaterOrEquals<T>(T a, T b, _1_ _ = default) where T : unmanaged, IVector1Impl<float> { return a.x >= b.x; }
        [IN(LINE)] public static bool LessOrEquals<T>(T a, T b, _1_ _ = default) where T : unmanaged, IVector1Impl<float> { return a.x <= b.x; }
    }
}