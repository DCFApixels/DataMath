#if DISABLE_DEBUG
#undef DEBUG
#endif
using DCFApixels.DataMath.Internal;
using System.ComponentModel;
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct float3
    {
        #region Length/Normalized
        public float Length { [IN(LINE)] get { return DM.Length(this); } }
        public float LengthSqr { [IN(LINE)] get { return DM.LengthSqr(this); } }
        public float3 Normalized { [IN(LINE)] get { return DM.Normalize(this); } }
        #endregion
    }
    public static partial class DM // float3
    {
        #region Abs/Sign
        [IN(LINE)] public static float3 Abs(float3 a) { return new float3(Abs(a.x), Abs(a.y), Abs(a.z)); }
        [IN(LINE)] public static float3 Sign(float3 a) { return new float3(Sign(a.x), Sign(a.y), Sign(a.z)); }
        [IN(LINE)] public static float3 SoftSign(float3 a) { return new float3(SoftSign(a.x), SoftSign(a.y), SoftSign(a.z)); }
        [IN(LINE)] public static int3 Sign2Int(float3 a) { return new int3(Sign2Int(a.x), Sign2Int(a.y), Sign2Int(a.z)); }
        #endregion

        #region Round/Floor/Ceil
        [IN(LINE)] public static float3 Round(float3 a) { return new float3(Round(a.x), Round(a.y), Round(a.z)); }
        [IN(LINE)] public static int3 Round2Int(float3 a) { return new int3(Round2Int(a.x), Round2Int(a.y), Round2Int(a.z)); }
        [IN(LINE)] public static float3 Floor(float3 a) { return new float3(Floor(a.x), Floor(a.y), Floor(a.z)); }
        [IN(LINE)] public static int3 Floor2Int(float3 a) { return new int3(Floor2Int(a.x), Floor2Int(a.y), Floor2Int(a.z)); }
        [IN(LINE)] public static float3 Ceil(float3 a) { return new float3(Ceil(a.x), Ceil(a.y), Ceil(a.z)); }
        [IN(LINE)] public static int3 Ceil2Int(float3 a) { return new int3(Ceil2Int(a.x), Ceil2Int(a.y), Ceil2Int(a.z)); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [IN(LINE)] public static uint3 Round2UInt(float3 a) { return new uint3(Round2UInt(a.x), Round2UInt(a.y), Round2UInt(a.z)); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        [IN(LINE)] public static uint3 Floor2UInt(float3 a) { return new uint3(Floor2UInt(a.x), Floor2UInt(a.y), Floor2UInt(a.z)); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        [IN(LINE)] public static uint3 Ceil2UInt(float3 a) { return new uint3(Ceil2UInt(a.x), Ceil2UInt(a.y), Ceil2UInt(a.z)); }
        #endregion

        #region Clamp/Repeat/PingPong
        /// <summary> Clamps the value between min and max. </summary>
        [IN(LINE)] public static float3 Clamp(float3 a, float3 min, float3 max) { return Max(min, Min(max, a)); }
        /// <summary> Clamps the value between 0 and 1. </summary>
        [IN(LINE)] public static float3 Clamp01(float3 a) { return Clamp(a, 0f, 1f); }
        /// <summary> Clamps the value between -1 and 1. </summary>
        [IN(LINE)] public static float3 ClampMirror1(float3 a) { return Clamp(a, -1f, 1f); }

        [IN(LINE)] public static float3 Repeat(float3 a, float3 length) { return Clamp(a - Floor(a / length) * length, 0f, length); }
        [IN(LINE)] public static float3 Repeat(float3 a, float3 min, float3 max) { return Repeat(a, max - min) + min; }
        [IN(LINE)] public static float3 Repeat01(float3 a) { return Repeat(a, 1f); }
        [IN(LINE)] public static float3 RepeatMirror1(float3 a) { return Repeat(a, -1f, 1f); }

        [IN(LINE)] public static float3 PingPong(float3 a, float3 length) { return length - Abs(Repeat(a, length * 2f) - length); }
        [IN(LINE)] public static float3 PingPong(float3 a, float3 min, float3 max) { return PingPong(a, max - min) + min; }
        [IN(LINE)] public static float3 PingPong01(float3 a) { return PingPong(a, 1f); }
        [IN(LINE)] public static float3 PingPongMirror1(float3 a) { return PingPong(a, -1f, 1f); }
        #endregion

        #region SmoothStep
        /// <summary> Clamps the value between from and to. </summary>
        [IN(LINE)]
        public static float3 SmoothStep(float3 from, float3 to, float3 a)
        {
            var t = Clamp01((a - from) / (to - from));
            return t * t * (3.0f - (2.0f * t));
        }
        /// <summary> Clamps the value between 0 and 1. </summary>
        [IN(LINE)] public static float3 SmoothStep01(float3 a) { return SmoothStep(0f, 1f, a); }
        /// <summary> Clamps the value between -1 and 1. </summary>
        [IN(LINE)] public static float3 SmoothStepMirror1(float3 a) { return SmoothStep(-1f, 1f, a); }
        #endregion

        #region All/Any
        [IN(LINE)] public static bool All(float3 a) { return a.x != default && a.y != default && a.z != default; }
        [IN(LINE)] public static bool Any(float3 a) { return a.x != default || a.y != default || a.z != default; }
        #endregion

        #region Min/Max/Sum
        [IN(LINE)] public static float3 Max(float3 a, float3 b) { return new float3(Max(a.x, b.x), Max(a.y, b.y), Max(a.z, b.z)); }
        [IN(LINE)] public static float3 AbsMax(float3 a, float3 b) { return new float3(AbsMax(a.x, b.x), AbsMax(a.y, b.y), AbsMax(a.z, b.z)); }
        [IN(LINE)] public static float3 Min(float3 a, float3 b) { return new float3(Min(a.x, b.x), Min(a.y, b.y), Min(a.z, b.z)); }
        [IN(LINE)] public static float3 AbsMin(float3 a, float3 b) { return new float3(AbsMin(a.x, b.x), AbsMin(a.y, b.y), AbsMin(a.z, b.z)); }
        [IN(LINE)] public static float CMax(float3 a) { return CMax(a.x, a.y, a.z); }
        [IN(LINE)] public static float CAbsMax(float3 a) { return CAbsMax(a.x, a.y, a.z); }
        [IN(LINE)] public static float CMin(float3 a) { return CMin(a.x, a.y, a.z); }
        [IN(LINE)] public static float CAbsMin(float3 a) { return CAbsMin(a.x, a.y, a.z); }
        [IN(LINE)] public static float CSum(float3 a) { return a.x + a.y + a.z; }
        #endregion

        #region Lerp/MoveTowards
        [IN(LINE)] public static float3 Lerp(float3 start, float3 end, float3 t) { return start + t * (end - start); }
        [IN(LINE)] public static float3 LerpClamp(float3 start, float3 end, float3 t) { return Lerp(start, end, Clamp01(t)); }
        [IN(LINE)] public static float3 LerpRepeat(float3 start, float3 end, float3 t) { return Lerp(start, end, Repeat01(t)); }

        [IN(LINE)] public static float3 UnLerp(float3 start, float3 end, float3 a) { return (a - start) / (end - start); }
        [IN(LINE)] public static float3 UnLerpClamp(float3 start, float3 end, float3 a) { return Clamp01(UnLerp(start, end, a)); }
        [IN(LINE)] public static float3 UnLerpRepeat(float3 start, float3 end, float3 a) { return Repeat01(UnLerp(start, end, a)); }

        [IN(LINE)]
        public static float3 Remap(float3 oldStart, float3 oldEnd, float3 newStart, float3 newEnd, float3 v)
        {
            return Lerp(newStart, newEnd, UnLerp(oldStart, oldEnd, v));
        }

        [IN(LINE)]
        public static float3 LerpAngle(float3 start, float3 end, float t)
        {
            float3 angle = Repeat(end - start, 360f);
            if (angle > 180f) { angle -= 360f; }
            //float angle = Repeat(end - start, -180f, 180f);
            return start + angle * t;
        }
        [IN(LINE)] public static float3 LerpAngleClamp(float3 start, float3 end, float t) { return LerpAngle(start, end, Clamp01(t)); }
        [IN(LINE)] public static float3 LerpAngleRepeat(float3 start, float3 end, float t) { return LerpAngle(start, end, Repeat01(t)); }

        [IN(LINE)]
        public static float3 DeltaAngle(float3 current, float3 target)
        {
            float3 angle = Repeat(target - current, 360f);
            if (angle > 180f) { angle -= 360f; }
            //float angle = Repeat(end - start, -180f, 180f);
            return angle;
        }

        [IN(LINE)]
        public static float3 MoveTowards(float3 from, float3 to, float distance)
        {
            float3 dif = to - from;
            float len = dif.Length;
            if (len <= distance) { return to; }
            return from + dif / len * distance;
        }
        [IN(LINE)]
        public static float3 MoveTowards(float3 from, float3 to, float distance, out float excess)
        {
            if (distance == 0)
            {
                excess = 0;
                return from;
            }
            float3 dif = to - from;
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
        public static float3 MoveTowardsAngle(float3 current, float3 target, float maxDelta)
        {
            float3 delta = DeltaAngle(current, target);
            if (0f - maxDelta < delta && delta < maxDelta)
            {
                return target;
            }
            return MoveTowards(current, current + delta, maxDelta);
        }
        #endregion

        #region Real Value State Checks
        [IN(LINE)] public static bool3 IsNegative(float3 a) { return new bool3(IsNegative(a.x), IsNegative(a.y), IsNegative(a.z)); }
        [IN(LINE)] public static bool3 IsPositive(float3 a) { return new bool3(IsPositive(a.x), IsPositive(a.y), IsPositive(a.z)); }
        [IN(LINE)] public static bool3 IsNormalReal(float3 a) { return new bool3(IsNormalReal(a.x), IsNormalReal(a.y), IsNormalReal(a.z)); }
        [IN(LINE)] public static bool3 IsFinite(float3 a) { return new bool3(IsFinite(a.x), IsFinite(a.y), IsFinite(a.z)); }
        [IN(LINE)] public static bool3 IsNaN(float3 a) { return new bool3(IsNaN(a.x), IsNaN(a.y), IsNaN(a.z)); }
        [IN(LINE)] public static bool3 IsInfinity(float3 a) { return new bool3(IsInfinity(a.x), IsInfinity(a.y), IsInfinity(a.z)); }
        [IN(LINE)] public static bool3 IsNegativeInfinity(float3 a) { return new bool3(IsNegativeInfinity(a.x), IsNegativeInfinity(a.y), IsNegativeInfinity(a.z)); }
        [IN(LINE)] public static bool3 IsPositiveInfinity(float3 a) { return new bool3(IsPositiveInfinity(a.x), IsPositiveInfinity(a.y), IsPositiveInfinity(a.z)); }
        #endregion

        #region Space Converts
        [IN(LINE)] public static float3 GammaToLinearSpace(float3 a) { const float Gamma = 2.2f; return Pow(a, Gamma); }
        [IN(LINE)] public static float3 LinearToGammaSpace(float3 a) { const float InverseGamma = 1.0f / 2.2f; return Pow(a, InverseGamma); }
        /// <summary> Convert Radians to Degrees. x * 57.296~ </summary>
        [IN(LINE)] public static float3 Degrees(float3 radians) { return radians * Rad2Deg; }
        /// <summary> Convert Degrees to Radians. x * 0.0175~ </summary>
        [IN(LINE)] public static float3 Radians(float3 degrees) { return degrees * Deg2Rad; }
        #endregion

        #region Approximately
        [IN(LINE)] public static bool3 Approximately(float3 a, float3 b) { return Approximately(a, b, CMax(1E-06f * Max(Abs(a), Abs(b)), FloatEpsilon * 8f)); }
        [IN(LINE)] public static bool3 Approximately(float3 a, float3 b, float3 tolerance) { return Abs(b - a) < tolerance; }
        #endregion

        #region Pow2
        [IN(LINE)] public static float3 CeilPow2(float3 value) { return new float3(CeilPow2(value.x), CeilPow2(value.y), CeilPow2(value.z)); }
        [IN(LINE)] public static float3 FloorPow2(float3 value) { return new float3(FloorPow2(value.x), FloorPow2(value.y), FloorPow2(value.z)); }
        [IN(LINE)] public static float3 RoundPow2(float3 value) { return new float3(RoundPow2(value.x), RoundPow2(value.y), RoundPow2(value.z)); }
        [IN(LINE)] public static bool3 IsPow2(float3 value) { return new bool3(IsPow2(value.x), IsPow2(value.y), IsPow2(value.z)); }
        #endregion

        #region Length/Normalize/Distance
        [IN(LINE)] public static float Length(float3 a) { return Sqrt(Dot(a, a)); }
        [IN(LINE)] public static float LengthSqr(float3 a) { return Dot(a, a); }
        [IN(LINE)] public static float Distance(float3 a, float3 b) { return Length(b - a); }
        [IN(LINE)] public static float DistanceSqr(float3 a, float3 b) { return LengthSqr(b - a); }
        [IN(LINE)] public static float3 Normalize(float3 a) { return 1.0f / Sqrt(Dot(a, a)) * a; }
        [IN(LINE)]
        public static float3 NormalizeSafe(float3 a, float3 defaultvalue = default)
        {
            var len = Dot(a, a);
            return Select(defaultvalue, RSqrt(len) * a, len > FloatMinNormal);
        }
        [IN(LINE)] public static bool IsNormalized(float3 a) { return Approximately(CSum(a) - 1f, 0f, FloatZeroTolerance); }
        #endregion

        #region Other
        [IN(LINE)] public static float3 Project(float3 a, float3 ontoB) { return (Dot(a, ontoB) / Dot(ontoB, ontoB)) * ontoB; }
        [IN(LINE)]
        public static float3 ProjectSafe(float3 a, float3 ontoB, float3 defaultValue = default)
        {
            var proj = Project(a, ontoB);
            return Select(defaultValue, proj, All(IsInfinity(proj)));
        }
        [IN(LINE)] public static float3 Reflect(float3 v, float3 n) { return v - 2f * n * Dot(v, n); }

        [IN(LINE)] public static float3 Select(float3 falseValue, float3 trueValue, bool3 test) { return test ? trueValue : falseValue; }
        [IN(LINE)] public static float3 Step(float3 threshold, float3 a) { return Select(0.0f, 1.0f, a >= threshold); }
        [IN(LINE)] public static int3 Step2Int(float3 threshold, float3 a) { return Select((int3)0, 1, a >= threshold); }

        [IN(LINE)] public static float3 Cos(float3 a) { return new float3(Cos(a.x), Cos(a.y), Cos(a.z)); }
        [IN(LINE)] public static float3 Cosh(float3 a) { return new float3(Cosh(a.x), Cosh(a.y), Cosh(a.z)); }
        [IN(LINE)] public static float3 Acos(float3 a) { return new float3(Acos(a.x), Acos(a.y), Acos(a.z)); }
        [IN(LINE)] public static float3 Sin(float3 a) { return new float3(Sin(a.x), Sin(a.y), Sin(a.z)); }
        [IN(LINE)] public static float3 Sinh(float3 a) { return new float3(Sinh(a.x), Sinh(a.y), Sinh(a.z)); }
        [IN(LINE)] public static float3 Asin(float3 a) { return new float3(Asin(a.x), Asin(a.y), Asin(a.z)); }

        [IN(LINE)] public static float3 Atan(float3 a) { return new float3(Atan(a.x), Atan(a.y), Atan(a.z)); }
        [IN(LINE)] public static float3 Atan2(float3 a, float3 b) { return new float3(Atan2(a.x, b.x), Atan2(a.y, b.y), Atan2(a.z, b.z)); }

        [IN(LINE)] public static float Dot(float3 a, float3 b) { return a.x * b.x + a.y * b.y + a.z * b.z; }
        [IN(LINE)] public static float3 Sqr(float3 a) { return a * a; }
        [IN(LINE)] public static float3 Sqrt(float3 a) { return new float3(Sqrt(a.x), Sqrt(a.y), Sqrt(a.z)); }
        [IN(LINE)] public static float3 RSqrt(float3 a) { return 1f / Sqrt(a); }
        [IN(LINE)] public static float3 Pow(float3 a, float3 b) { return new float3(Pow(a.x, a.y), Pow(a.y, a.y), Pow(a.z, a.z)); }
        [IN(LINE)] public static float3 Exp(float3 pow) { return new float3(Exp(pow.x), Exp(pow.y), Exp(pow.z)); }
        [IN(LINE)] public static float3 Exp2(float3 pow) { return new float3(Exp2(pow.x), Exp2(pow.y), Exp2(pow.z)); }
        [IN(LINE)] public static float3 Exp10(float3 pow) { return new float3(Exp10(pow.x), Exp10(pow.y), Exp10(pow.z)); }
        [IN(LINE)] public static float3 Log(float3 f, float3 p) { return new float3(Log(f.x, p.x), Log(f.y, p.y), Log(f.z, p.z)); }
        [IN(LINE)] public static float3 Log(float3 f) { return new float3(Log(f.x), Log(f.y), Log(f.z)); }
        [IN(LINE)] public static float3 Log2(float3 f) { return new float3(Log2(f.x), Log2(f.y), Log2(f.z)); }
        [IN(LINE)] public static float3 Log10(float3 f) { return new float3(Log10(f.x), Log10(f.y), Log10(f.z)); }

        [IN(LINE)] public static float3 Tan(float3 a) { return new float3(Tan(a.x), Tan(a.y), Tan(a.z)); }
        [IN(LINE)] public static float3 Tanh(float3 a) { return new float3(Tanh(a.x), Tanh(a.y), Tanh(a.z)); }

        [IN(LINE)] public static float3 Truncate(float3 a) { return new float3(Truncate(a.x), Truncate(a.y), Truncate(a.z)); }
        #endregion


        #region Hash
        [IN(LINE)] public static uint UHash(float3 v) { return unchecked((uint)Hash(v)); }
        [IN(LINE)] public static int Hash(float3 v) { return Hash<float3>(v); }
        #endregion

        #region Specific
        [IN(LINE)] public static float3 Cross(float3 a, float3 b) { return (a * b.yzx - a.yzx * b).yzx; }
        #endregion
    }

    public static partial class DMBasic // IVector3<float>
    {
        [IN(LINE)] public static T New<T>(float a, _3_ _ = default) where T : unmanaged, IVector3<float> { return New<T>(a, a, a); }
        [IN(LINE)] public static T New<T>(float3 a) where T : unmanaged, IVector3<float> { return New<T>(a.x, a.y, a.z); }
        [IN(LINE)] public static T New<T>(float x, float y, float z) where T : unmanaged, IVector3<float> { T r = default; r.x = x; r.y = y; r.z = z; return r; }
        [IN(LINE)] public static float3 ToBasic<T>(this T a, _3_ _ = default) where T : unmanaged, IVector3Impl<float> { return new float3(a.x, a.y, a.z); }
        [IN(LINE)] public static T Add<T>(T a, T b, _3_ _ = default) where T : unmanaged, IVector3Impl<float> { return New<T>(a.x + b.x, a.y + b.y, a.z + b.z); }
        [IN(LINE)] public static T Sub<T>(T a, T b, _3_ _ = default) where T : unmanaged, IVector3Impl<float> { return New<T>(a.x - b.x, a.y - b.y, a.z - b.z); }
        [IN(LINE)] public static T Mul<T>(T a, T b, _3_ _ = default) where T : unmanaged, IVector3Impl<float> { return New<T>(a.x * b.x, a.y * b.y, a.z * b.z); }
        [IN(LINE)] public static T Div<T>(T a, T b, _3_ _ = default) where T : unmanaged, IVector3Impl<float> { return New<T>(a.x / b.x, a.y / b.y, a.z / b.z); }
        [IN(LINE)] public static T Mod<T>(T a, T b, _3_ _ = default) where T : unmanaged, IVector3Impl<float> { return New<T>(a.x % b.x, a.y % b.y, a.z % b.z); }
        [IN(LINE)] public static bool3 Equals<T>(T a, T b, _3_ _ = default) where T : unmanaged, IVector3Impl<float> { return new bool3(a.x == b.x, a.y == b.y, a.z == b.z); }
        [IN(LINE)] public static bool3 Greater<T>(T a, T b, _3_ _ = default) where T : unmanaged, IVector3Impl<float> { return new bool3(a.x > b.x, a.y > b.y, a.z > b.z); }
        [IN(LINE)] public static bool3 Less<T>(T a, T b, _3_ _ = default) where T : unmanaged, IVector3Impl<float> { return new bool3(a.x < b.x, a.y < b.y, a.z < b.z); }
        [IN(LINE)] public static bool3 GreaterOrEquals<T>(T a, T b, _3_ _ = default) where T : unmanaged, IVector3Impl<float> { return new bool3(a.x >= b.x, a.y >= b.y, a.z >= b.z); }
        [IN(LINE)] public static bool3 LessOrEquals<T>(T a, T b, _3_ _ = default) where T : unmanaged, IVector3Impl<float> { return new bool3(a.x <= b.x, a.y <= b.y, a.z <= b.z); }
    }
}