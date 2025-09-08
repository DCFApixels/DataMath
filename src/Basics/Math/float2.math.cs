#pragma warning disable CS8981
#if DISABLE_DEBUG
#undef DEBUG
#endif
using DCFApixels.DataMath.Internal;
using System.ComponentModel;
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct float2
    {
        #region Length/Normalized
        public float Length { [IN(LINE)] get { return DM.Length(this); } }
        public float LengthSqr { [IN(LINE)] get { return DM.LengthSqr(this); } }
        public float2 Normalized { [IN(LINE)] get { return DM.Normalize(this); } }
        #endregion
    }
    public static partial class DM // float2
    {
        #region Abs/Sign
        [IN(LINE)] public static float2 Abs(float2 a) { return new float2(Abs(a.x), Abs(a.y)); }
        [IN(LINE)] public static float2 Sign(float2 a) { return new float2(Sign(a.x), Sign(a.y)); }
        [IN(LINE)] public static float2 SoftSign(float2 a) { return new float2(SoftSign(a.x), SoftSign(a.y)); }
        [IN(LINE)] public static int2 Sign2Int(float2 a) { return new int2(Sign2Int(a.x), Sign2Int(a.y)); }
        #endregion

        #region Round/Floor/Ceil
        [IN(LINE)] public static float2 Round(float2 a) { return new float2(Round(a.x), Round(a.y)); }
        [IN(LINE)] public static int2 Round2Int(float2 a) { return new int2(Round2Int(a.x), Round2Int(a.y)); }
        [IN(LINE)] public static float2 Floor(float2 a) { return new float2(Floor(a.x), Floor(a.y)); }
        [IN(LINE)] public static int2 Floor2Int(float2 a) { return new int2(Floor2Int(a.x), Floor2Int(a.y)); }
        [IN(LINE)] public static float2 Ceil(float2 a) { return new float2(Ceil(a.x), Ceil(a.y)); }
        [IN(LINE)] public static int2 Ceil2Int(float2 a) { return new int2(Ceil2Int(a.x), Ceil2Int(a.y)); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [IN(LINE)] public static uint2 Round2UInt(float2 a) { return new uint2(Round2UInt(a.x), Round2UInt(a.y)); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        [IN(LINE)] public static uint2 Floor2UInt(float2 a) { return new uint2(Floor2UInt(a.x), Floor2UInt(a.y)); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        [IN(LINE)] public static uint2 Ceil2UInt(float2 a) { return new uint2(Ceil2UInt(a.x), Ceil2UInt(a.y)); }
        #endregion

        #region Clamp/Repeat/PingPong
        /// <summary> Clamps the value between min and max. </summary>
        [IN(LINE)] public static float2 Clamp(float2 a, float2 min, float2 max) { return Max(min, Min(max, a)); }
        /// <summary> Clamps the value between 0 and 1. </summary>
        [IN(LINE)] public static float2 Clamp01(float2 a) { return Clamp(a, 0f, 1f); }
        /// <summary> Clamps the value between -1 and 1. </summary>
        [IN(LINE)] public static float2 ClampMirror1(float2 a) { return Clamp(a, -1f, 1f); }

        [IN(LINE)] public static float2 Repeat(float2 a, float2 length) { return Clamp(a - Floor(a / length) * length, 0f, length); }
        [IN(LINE)] public static float2 Repeat(float2 a, float2 min, float2 max) { return Repeat(a, max - min) + min; }
        [IN(LINE)] public static float2 Repeat01(float2 a) { return Repeat(a, 1f); }
        [IN(LINE)] public static float2 RepeatMirror1(float2 a) { return Repeat(a, -1f, 1f); }

        [IN(LINE)] public static float2 PingPong(float2 a, float2 length) { return length - Abs(Repeat(a, length * 2f) - length); }
        [IN(LINE)] public static float2 PingPong(float2 a, float2 min, float2 max) { return PingPong(a, max - min) + min; }
        [IN(LINE)] public static float2 PingPong01(float2 a) { return PingPong(a, 1f); }
        [IN(LINE)] public static float2 PingPongMirror1(float2 a) { return PingPong(a, -1f, 1f); }
        #endregion

        #region SmoothStep
        /// <summary> Clamps the value between from and to. </summary>
        [IN(LINE)]
        public static float2 SmoothStep(float2 from, float2 to, float2 a)
        {
            var t = Clamp01((a - from) / (to - from));
            return t * t * (3.0f - (2.0f * t));
        }
        /// <summary> Clamps the value between 0 and 1. </summary>
        [IN(LINE)] public static float2 SmoothStep01(float2 a) { return SmoothStep(0f, 1f, a); }
        /// <summary> Clamps the value between -1 and 1. </summary>
        [IN(LINE)] public static float2 SmoothStepMirror1(float2 a) { return SmoothStep(-1f, 1f, a); }
        #endregion

        #region All/Any
        [IN(LINE)] public static bool All(float2 a) { return a.x != default && a.y != default; }
        [IN(LINE)] public static bool Any(float2 a) { return a.x != default || a.y != default; }
        #endregion

        #region Min/Max/Sum
        [IN(LINE)] public static float2 Max(float2 a, float2 b) { return new float2(Max(a.x, b.x), Max(a.y, b.y)); }
        [IN(LINE)] public static float2 AbsMax(float2 a, float2 b) { return new float2(AbsMax(a.x, b.x), AbsMax(a.y, b.y)); }
        [IN(LINE)] public static float2 Min(float2 a, float2 b) { return new float2(Min(a.x, b.x), Min(a.y, b.y)); }
        [IN(LINE)] public static float2 AbsMin(float2 a, float2 b) { return new float2(AbsMin(a.x, b.x), AbsMin(a.y, b.y)); }
        [IN(LINE)] public static float CMax(float2 a) { return CMax(a.x, a.y); }
        [IN(LINE)] public static float CAbsMax(float2 a) { return CAbsMax(a.x, a.y); }
        [IN(LINE)] public static float CMin(float2 a) { return CMin(a.x, a.y); }
        [IN(LINE)] public static float CAbsMin(float2 a) { return CAbsMin(a.x, a.y); }
        [IN(LINE)] public static float CSum(float2 a) { return a.x + a.y; }
        #endregion

        #region Lerp/MoveTowards
        [IN(LINE)] public static float2 Lerp(float2 start, float2 end, float2 t) { return start + t * (end - start); }
        [IN(LINE)] public static float2 LerpClamp(float2 start, float2 end, float2 t) { return Lerp(start, end, Clamp01(t)); }
        [IN(LINE)] public static float2 LerpRepeat(float2 start, float2 end, float2 t) { return Lerp(start, end, Repeat01(t)); }

        [IN(LINE)] public static float2 UnLerp(float2 start, float2 end, float2 a) { return (a - start) / (end - start); }
        [IN(LINE)] public static float2 UnLerpClamp(float2 start, float2 end, float2 a) { return Clamp01(UnLerp(start, end, a)); }
        [IN(LINE)] public static float2 UnLerpRepeat(float2 start, float2 end, float2 a) { return Repeat01(UnLerp(start, end, a)); }

        [IN(LINE)]
        public static float2 Remap(float2 oldStart, float2 oldEnd, float2 newStart, float2 newEnd, float2 v)
        {
            return Lerp(newStart, newEnd, UnLerp(oldStart, oldEnd, v));
        }

        [IN(LINE)]
        public static float2 LerpAngle(float2 start, float2 end, float t)
        {
            float2 angle = Repeat(end - start, 360f);
            if (angle > 180f) { angle -= 360f; }
            //float angle = Repeat(end - start, -180f, 180f);
            return start + angle * t;
        }
        [IN(LINE)] public static float2 LerpAngleClamp(float2 start, float2 end, float t) { return LerpAngle(start, end, Clamp01(t)); }
        [IN(LINE)] public static float2 LerpAngleRepeat(float2 start, float2 end, float t) { return LerpAngle(start, end, Repeat01(t)); }

        [IN(LINE)]
        public static float2 DeltaAngle(float2 current, float2 target)
        {
            float2 angle = Repeat(target - current, 360f);
            if (angle > 180f) { angle -= 360f; }
            //float angle = Repeat(end - start, -180f, 180f);
            return angle;
        }

        [IN(LINE)]
        public static float2 MoveTowards(float2 from, float2 to, float distance)
        {
            float2 dif = to - from;
            float len = dif.Length;
            if (len <= distance) { return to; }
            return from + dif / len * distance;
        }
        [IN(LINE)]
        public static float2 MoveTowards(float2 from, float2 to, float distance, out float excess)
        {
            if (distance == 0)
            {
                excess = 0;
                return from;
            }
            float2 dif = to - from;
            float lensqr = LengthSqr(dif);
            if (lensqr == 0f)
            {
                excess = distance;
                return to;
            }
            float len = Sqrt(lensqr);
            excess = distance - len;
            if (excess > -float.Epsilon)
            {
                return to;
            }

            return from + dif / len * distance;
        }
        [IN(LINE)]
        public static float2 MoveTowardsAngle(float2 current, float2 target, float maxDelta)
        {
            float2 delta = DeltaAngle(current, target);
            if (0f - maxDelta < delta && delta < maxDelta)
            {
                return target;
            }
            return MoveTowards(current, current + delta, maxDelta);
        }
        #endregion

        #region Real Value State Checks
        [IN(LINE)] public static bool2 IsNegative(float2 a) { return new bool2(IsNegative(a.x), IsNegative(a.y)); }
        [IN(LINE)] public static bool2 IsPositive(float2 a) { return new bool2(IsPositive(a.x), IsPositive(a.y)); }
        [IN(LINE)] public static bool2 IsNormalReal(float2 a) { return new bool2(IsNormalReal(a.x), IsNormalReal(a.y)); }
        [IN(LINE)] public static bool2 IsFinite(float2 a) { return new bool2(IsFinite(a.x), IsFinite(a.y)); }
        [IN(LINE)] public static bool2 IsNaN(float2 a) { return new bool2(IsNaN(a.x), IsNaN(a.y)); }
        [IN(LINE)] public static bool2 IsInfinity(float2 a) { return new bool2(IsInfinity(a.x), IsInfinity(a.y)); }
        [IN(LINE)] public static bool2 IsNegativeInfinity(float2 a) { return new bool2(IsNegativeInfinity(a.x), IsNegativeInfinity(a.y)); }
        [IN(LINE)] public static bool2 IsPositiveInfinity(float2 a) { return new bool2(IsPositiveInfinity(a.x), IsPositiveInfinity(a.y)); }
        #endregion

        #region Space Converts
        [IN(LINE)] public static float2 GammaToLinearSpace(float2 a) { const float Gamma = 2.2f; return Pow(a, Gamma); }
        [IN(LINE)] public static float2 LinearToGammaSpace(float2 a) { const float InverseGamma = 1.0f / 2.2f; return Pow(a, InverseGamma); }
        /// <summary> Convert Radians to Degrees. x * 57.296~ </summary>
        [IN(LINE)] public static float2 Degrees(float2 radians) { return radians * Rad2Deg; }
        /// <summary> Convert Degrees to Radians. x * 0.0175~ </summary>
        [IN(LINE)] public static float2 Radians(float2 degrees) { return degrees * Deg2Rad; }
        #endregion

        #region Approximately
        [IN(LINE)] public static bool2 Approximately(float2 a, float2 b) { return Approximately(a, b, CMax(1E-06f * Max(Abs(a), Abs(b)), FloatEpsilon * 8f)); }
        [IN(LINE)] public static bool2 Approximately(float2 a, float2 b, float2 tolerance) { return Abs(b - a) < tolerance; }
        #endregion

        #region Pow2
        [IN(LINE)] public static float2 CeilPow2(float2 value) { return new float2(CeilPow2(value.x), CeilPow2(value.y)); }
        [IN(LINE)] public static float2 FloorPow2(float2 value) { return new float2(FloorPow2(value.x), FloorPow2(value.y)); }
        [IN(LINE)] public static float2 RoundPow2(float2 value) { return new float2(RoundPow2(value.x), RoundPow2(value.y)); }
        [IN(LINE)] public static bool2 IsPow2(float2 value) { return new bool2(IsPow2(value.x), IsPow2(value.y)); }
        #endregion

        #region Length/Distance/Normalize
        [IN(LINE)] public static float Length(float2 a) { return Sqrt(Dot(a, a)); }
        [IN(LINE)] public static float LengthSqr(float2 a) { return Dot(a, a); }
        [IN(LINE)] public static float Distance(float2 a, float2 b) { return Length(b - a); }
        [IN(LINE)] public static float DistanceSqr(float2 a, float2 b) { return LengthSqr(b - a); }
        [IN(LINE)] public static float2 Normalize(float2 a) { return 1.0f / Sqrt(Dot(a, a)) * a; }
        [IN(LINE)]
        public static float2 NormalizeSafe(float2 a, float2 defaultvalue = default)
        {
            var len = Dot(a, a);
            return Select(defaultvalue, RSqrt(len) * a, len > FloatMinNormal);
        }
        [IN(LINE)] public static bool IsNormalized(float2 a) { return Approximately(CSum(a) - 1f, 0f, FloatZeroTolerance); }
        #endregion

        #region Other
        [IN(LINE)] public static float2 Project(float2 a, float2 ontoB) { return (Dot(a, ontoB) / Dot(ontoB, ontoB)) * ontoB; }
        [IN(LINE)]
        public static float2 ProjectSafe(float2 a, float2 ontoB, float2 defaultValue = default)
        {
            var proj = Project(a, ontoB);
            return Select(defaultValue, proj, All(IsInfinity(proj)));
        }
        [IN(LINE)] public static float2 Reflect(float2 v, float2 n) { return v - 2f * n * Dot(v, n); }

        [IN(LINE)] public static float2 Select(float2 falseValue, float2 trueValue, bool2 test) { return new float2(test.x ? trueValue.x : falseValue.x, test.y ? trueValue.y : falseValue.y); }
        [IN(LINE)] public static float2 Select(float2 falseValue, float2 trueValue, bool test) { return test ? trueValue : falseValue; }
        [IN(LINE)] public static float2 Step(float2 threshold, float2 a) { return Select(0.0f, 1.0f, a >= threshold); }
        [IN(LINE)] public static int2 Step2Int(float2 threshold, float2 a) { return Select((int2)0, 1, a >= threshold); }

        [IN(LINE)] public static float2 Cos(float2 a) { return new float2(Cos(a.x), Cos(a.y)); }
        [IN(LINE)] public static float2 Cosh(float2 a) { return new float2(Cosh(a.x), Cosh(a.y)); }
        [IN(LINE)] public static float2 Acos(float2 a) { return new float2(Acos(a.x), Acos(a.y)); }
        [IN(LINE)] public static float2 Sin(float2 a) { return new float2(Sin(a.x), Sin(a.y)); }
        [IN(LINE)] public static float2 Sinh(float2 a) { return new float2(Sinh(a.x), Sinh(a.y)); }
        [IN(LINE)] public static float2 Asin(float2 a) { return new float2(Asin(a.x), Asin(a.y)); }

        [IN(LINE)] public static float2 Atan(float2 a) { return new float2(Atan(a.x), Atan(a.y)); }
        [IN(LINE)] public static float2 Atan2(float2 a, float2 b) { return new float2(Atan2(a.x, b.x), Atan2(a.y, b.y)); }

        [IN(LINE)] public static float Dot(float2 a, float2 b) { return a.x * b.x + a.y * b.y; }
        [IN(LINE)] public static float2 Sqr(float2 a) { return a * a; }
        [IN(LINE)] public static float2 Sqrt(float2 a) { return new float2(Sqrt(a.x), Sqrt(a.y)); }
        [IN(LINE)] public static float2 RSqrt(float2 a) { return 1f / Sqrt(a); }
        [IN(LINE)] public static float2 Pow(float2 a, float2 b) { return new float2(Pow(a.x, a.y), Pow(a.y, a.y)); }
        [IN(LINE)] public static float2 Exp(float2 pow) { return new float2(Exp(pow.x), Exp(pow.y)); }
        [IN(LINE)] public static float2 Exp2(float2 pow) { return new float2(Exp2(pow.x), Exp2(pow.y)); }
        [IN(LINE)] public static float2 Exp10(float2 pow) { return new float2(Exp10(pow.x), Exp10(pow.y)); }
        [IN(LINE)] public static float2 Log(float2 f, float2 p) { return new float2(Log(f.x, p.x), Log(f.y, p.y)); }
        [IN(LINE)] public static float2 Log(float2 f) { return new float2(Log(f.x), Log(f.y)); }
        [IN(LINE)] public static float2 Log2(float2 f) { return new float2(Log2(f.x), Log2(f.y)); }
        [IN(LINE)] public static float2 Log10(float2 f) { return new float2(Log10(f.x), Log10(f.y)); }

        [IN(LINE)] public static float2 Tan(float2 a) { return new float2(Tan(a.x), Tan(a.y)); }
        [IN(LINE)] public static float2 Tanh(float2 a) { return new float2(Tanh(a.x), Tanh(a.y)); }

        [IN(LINE)] public static float2 Truncate(float2 a) { return new float2(Truncate(a.x), Truncate(a.y)); }
        #endregion


        #region Hash
        [IN(LINE)] public static uint UHash(float2 v) { return unchecked((uint)Hash(v)); }
        [IN(LINE)] public static int Hash(float2 v) { return Hash<float2>(v); }
        #endregion

        #region Specific
        [IN(LINE)] public static float Cross(float2 a, float2 b) { return a.x * b.y - a.y * b.x; }
        #endregion
    }

    public static partial class DMBasic // IVector2<float>
    {
        [IN(LINE)] public static T New<T>(float a, _2_ _ = default) where T : unmanaged, IVector2<float> { return New<T>(a, a); }
        [IN(LINE)] public static T New<T>(float2 a) where T : unmanaged, IVector2<float> { return New<T>(a.x, a.y); }
        [IN(LINE)] public static T New<T>(float x, float y) where T : unmanaged, IVector2<float> { T r = default; r.x = x; r.y = y; return r; }
        [IN(LINE)] public static float2 ToBasic<T>(this T a, _2_ _ = default) where T : unmanaged, IVector2Impl<float> { return new float2(a.x, a.y); }
        [IN(LINE)] public static T Add<T>(T a, T b, _2_ _ = default) where T : unmanaged, IVector2Impl<float> { return New<T>(a.x + b.x, a.y + b.y); }
        [IN(LINE)] public static T Sub<T>(T a, T b, _2_ _ = default) where T : unmanaged, IVector2Impl<float> { return New<T>(a.x - b.x, a.y - b.y); }
        [IN(LINE)] public static T Mul<T>(T a, T b, _2_ _ = default) where T : unmanaged, IVector2Impl<float> { return New<T>(a.x * b.x, a.y * b.y); }
        [IN(LINE)] public static T Div<T>(T a, T b, _2_ _ = default) where T : unmanaged, IVector2Impl<float> { return New<T>(a.x / b.x, a.y / b.y); }
        [IN(LINE)] public static T Mod<T>(T a, T b, _2_ _ = default) where T : unmanaged, IVector2Impl<float> { return New<T>(a.x % b.x, a.y % b.y); }
        [IN(LINE)] public static bool2 Equals<T>(T a, T b, _2_ _ = default) where T : unmanaged, IVector2Impl<float> { return new bool2(a.x == b.x, a.y == b.y); }
        [IN(LINE)] public static bool2 Greater<T>(T a, T b, _2_ _ = default) where T : unmanaged, IVector2Impl<float> { return new bool2(a.x > b.x, a.y > b.y); }
        [IN(LINE)] public static bool2 Less<T>(T a, T b, _2_ _ = default) where T : unmanaged, IVector2Impl<float> { return new bool2(a.x < b.x, a.y < b.y); }
        [IN(LINE)] public static bool2 GreaterOrEquals<T>(T a, T b, _2_ _ = default) where T : unmanaged, IVector2Impl<float> { return new bool2(a.x >= b.x, a.y >= b.y); }
        [IN(LINE)] public static bool2 LessOrEquals<T>(T a, T b, _2_ _ = default) where T : unmanaged, IVector2Impl<float> { return new bool2(a.x <= b.x, a.y <= b.y); }
    }
}