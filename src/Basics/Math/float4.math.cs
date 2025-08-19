#if DISABLE_DEBUG
#undef DEBUG
#endif
using DCFApixels.DataMath.Internal;
using System.ComponentModel;
using static DCFApixels.DataMath.Consts;
using static DCFApixels.DataMath.DMBasic;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct float4
    {
        #region Length/Normalized
        public float Length { [IN(LINE)] get { return DM.Length(this); } }
        public float LengthSqr { [IN(LINE)] get { return DM.LengthSqr(this); } }
        public float4 Normalized { [IN(LINE)] get { return DM.Normalize(this); } }
        #endregion
    }
    public static partial class DM // float4
    {
        #region Abs/Sign
        [IN(LINE)] public static float4 Abs(float4 a) { return new float4(Abs(a.x), Abs(a.y), Abs(a.z), Abs(a.w)); }
        [IN(LINE)] public static float4 Sign(float4 a) { return new float4(Sign(a.x), Sign(a.y), Sign(a.z), Sign(a.w)); }
        [IN(LINE)] public static int4 Sign2Int(float4 a) { return new int4(Sign2Int(a.x), Sign2Int(a.y), Sign2Int(a.z), Sign2Int(a.w)); }
        #endregion

        #region Round/Floor/Ceil
        [IN(LINE)] public static float4 Round(float4 a) { return new float4(Round(a.x), Round(a.y), Round(a.z), Round(a.w)); }
        [IN(LINE)] public static int4 Round2Int(float4 a) { return new int4(Round2Int(a.x), Round2Int(a.y), Round2Int(a.z), Round2Int(a.w)); }
        [IN(LINE)] public static float4 Floor(float4 a) { return new float4(Floor(a.x), Floor(a.y), Floor(a.z), Floor(a.w)); }
        [IN(LINE)] public static int4 Floor2Int(float4 a) { return new int4(Floor2Int(a.x), Floor2Int(a.y), Floor2Int(a.z), Floor2Int(a.w)); }
        [IN(LINE)] public static float4 Ceil(float4 a) { return new float4(Ceil(a.x), Ceil(a.y), Ceil(a.z), Ceil(a.w)); }
        [IN(LINE)] public static int4 Ceil2Int(float4 a) { return new int4(Ceil2Int(a.x), Ceil2Int(a.y), Ceil2Int(a.z), Ceil2Int(a.w)); }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [IN(LINE)] public static int4 Round2UInt(float4 a) { return new int4(Round2UInt(a.x), Round2UInt(a.y), Round2UInt(a.z), Round2UInt(a.w)); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        [IN(LINE)] public static int4 Floor2UInt(float4 a) { return new int4(Floor2UInt(a.x), Floor2UInt(a.y), Floor2UInt(a.z), Floor2UInt(a.w)); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        [IN(LINE)] public static int4 Ceil2UInt(float4 a) { return new int4(Ceil2UInt(a.x), Ceil2UInt(a.y), Ceil2UInt(a.z), Ceil2UInt(a.w)); }
        #endregion

        #region Clamp/Repeat/PingPong
        /// <summary> Clamps the value between min and max. </summary>
        [IN(LINE)] public static float4 Clamp(float4 a, float4 min, float4 max) { return Max(min, Min(max, a)); }
        /// <summary> Clamps the value between 0 and 1. </summary>
        [IN(LINE)] public static float4 Clamp01(float4 a) { return Clamp(a, 0f, 1f); }
        /// <summary> Clamps the value between -1 and 1. </summary>
        [IN(LINE)] public static float4 ClampMirror1(float4 a) { return Clamp(a, -1f, 1f); }

        [IN(LINE)] public static float4 Repeat(float4 a, float4 length) { return Clamp(a - Floor(a / length) * length, 0f, length); }
        [IN(LINE)] public static float4 Repeat(float4 a, float4 min, float4 max) { return Repeat(a, max - min) + min; }
        [IN(LINE)] public static float4 Repeat01(float4 a) { return Repeat(a, 1f); }
        [IN(LINE)] public static float4 RepeatMirror1(float4 a) { return Repeat(a, -1f, 1f); }

        [IN(LINE)] public static float4 PingPong(float4 a, float4 length) { return length - Abs(Repeat(a, length * 2f) - length); }
        [IN(LINE)] public static float4 PingPong(float4 a, float4 min, float4 max) { return PingPong(a, max - min) + min; }
        [IN(LINE)] public static float4 PingPong01(float4 a) { return PingPong(a, 1f); }
        [IN(LINE)] public static float4 PingPongMirror1(float4 a) { return PingPong(a, -1f, 1f); }
        #endregion

        #region SmoothStep
        /// <summary> Clamps the value between from and to. </summary>
        [IN(LINE)]
        public static float4 SmoothStep(float4 from, float4 to, float4 a)
        {
            var t = Clamp01((a - from) / (to - from));
            return t * t * (3.0f - (2.0f * t));
        }
        /// <summary> Clamps the value between 0 and 1. </summary>
        [IN(LINE)] public static float4 SmoothStep01(float4 a) { return SmoothStep(0f, 1f, a); }
        /// <summary> Clamps the value between -1 and 1. </summary>
        [IN(LINE)] public static float4 SmoothStepMirror1(float4 a) { return SmoothStep(-1f, 1f, a); }
        #endregion

        #region All/Any
        [IN(LINE)] public static bool All(float4 a) { return a.x != default && a.y != default && a.z != default && a.w != default; }
        [IN(LINE)] public static bool Any(float4 a) { return a.x != default || a.y != default || a.z != default || a.w != default; }
        #endregion

        #region Min/Max/Sum
        [IN(LINE)] public static float4 Max(float4 a, float4 b) { return new float4(Max(a.x, b.x), Max(a.y, b.y), Max(a.z, b.z), Max(a.w, b.w)); }
        [IN(LINE)] public static float4 AbsMax(float4 a, float4 b) { return new float4(AbsMax(a.x, b.x), AbsMax(a.y, b.y), AbsMax(a.z, b.z), AbsMax(a.w, b.w)); }
        [IN(LINE)] public static float4 Min(float4 a, float4 b) { return new float4(Min(a.x, b.x), Min(a.y, b.y), Min(a.z, b.z), Min(a.w, b.w)); }
        [IN(LINE)] public static float4 AbsMin(float4 a, float4 b) { return new float4(AbsMin(a.x, b.x), AbsMin(a.y, b.y), AbsMin(a.z, b.z), AbsMin(a.w, b.w)); }
        [IN(LINE)] public static float CMax(float4 a) { return CMax(a.x, a.y, a.z, a.w); }
        [IN(LINE)] public static float CAbsMax(float4 a) { return CAbsMax(a.x, a.y, a.z, a.w); }
        [IN(LINE)] public static float CMin(float4 a) { return CMin(a.x, a.y, a.z, a.w); }
        [IN(LINE)] public static float CAbsMin(float4 a) { return CAbsMin(a.x, a.y, a.z, a.w); }
        [IN(LINE)] public static float CSum(float4 a) { return (a.x + a.y) + (a.z + a.w); }
        #endregion

        #region Lerp
        [IN(LINE)] public static float4 Lerp(float4 start, float4 end, float4 t) { return start + t * (end - start); }
        [IN(LINE)] public static float4 LerpClamp(float4 start, float4 end, float4 t) { return Lerp(start, end, Clamp01(t)); }
        [IN(LINE)] public static float4 LerpRepeat(float4 start, float4 end, float4 t) { return Lerp(start, end, Repeat01(t)); }

        [IN(LINE)] public static float4 UnLerp(float4 start, float4 end, float4 a) { return (a - start) / (end - start); }
        [IN(LINE)] public static float4 UnLerpClamp(float4 start, float4 end, float4 a) { return Clamp01(UnLerp(start, end, a)); }
        [IN(LINE)] public static float4 UnLerpRepeat(float4 start, float4 end, float4 a) { return Repeat01(UnLerp(start, end, a)); }


        [IN(LINE)]
        public static float4 MoveTowards(float4 from, float4 to, float distance)
        {
            float4 dif = to - from;
            float len = dif.Length;
            if (len <= distance) { return to; }
            return from + dif / len * distance;
        }
        [IN(LINE)]
        public static float4 MoveTowards(float4 from, float4 to, float distance, out float excess)
        {
            if (distance == 0)
            {
                excess = 0;
                return from;
            }
            float4 dif = to - from;
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
        public static float4 Remap(float4 oldStart, float4 oldEnd, float4 newStart, float4 newEnd, float4 v)
        {
            return Lerp(newStart, newEnd, UnLerp(oldStart, oldEnd, v));
        }


        [IN(LINE)]
        public static float4 LerpAngle(float4 start, float4 end, float t)
        {
            float4 angle = Repeat(end - start, 360f);
            if (angle > 180f) { angle -= 360f; }
            //float angle = Repeat(end - start, -180f, 180f);
            return start + angle * Clamp01(t);
        }
        [IN(LINE)]
        public static float4 DeltaAngle(float4 current, float4 target)
        {
            float4 angle = Repeat(target - current, 360f);
            if (angle > 180f) { angle -= 360f; }
            //float angle = Repeat(end - start, -180f, 180f);
            return angle;
        }
        [IN(LINE)]
        public static float4 MoveTowardsAngle(float4 current, float4 target, float maxDelta)
        {
            float4 delta = DeltaAngle(current, target);
            if (0f - maxDelta < delta && delta < maxDelta)
            {
                return target;
            }
            return MoveTowards(current, current + delta, maxDelta);
        }
        #endregion

        #region Float State Checks
        [IN(LINE)] public static bool4 IsNormalFloat(float4 a) { return new bool4(float.IsNormal(a.x), float.IsNormal(a.y), float.IsNormal(a.z), float.IsNormal(a.w)); }
        [IN(LINE)] public static bool4 IsFinite(float4 a) { return new bool4(float.IsFinite(a.x), float.IsFinite(a.y), float.IsFinite(a.z), float.IsFinite(a.w)); }
        [IN(LINE)] public static bool4 IsNaN(float4 a) { return new bool4(float.IsNaN(a.x), float.IsNaN(a.y), float.IsNaN(a.z), float.IsNaN(a.w)); }
        [IN(LINE)] public static bool4 IsInfinity(float4 a) { return new bool4(float.IsInfinity(a.x), float.IsInfinity(a.y), float.IsInfinity(a.z), float.IsInfinity(a.w)); }
        [IN(LINE)] public static bool4 IsNegativeInfinity(float4 a) { return new bool4(float.IsNegativeInfinity(a.x), float.IsNegativeInfinity(a.y), float.IsNegativeInfinity(a.z), float.IsNegativeInfinity(a.w)); }
        [IN(LINE)] public static bool4 IsPositiveInfinity(float4 a) { return new bool4(float.IsPositiveInfinity(a.x), float.IsPositiveInfinity(a.y), float.IsPositiveInfinity(a.z), float.IsPositiveInfinity(a.w)); }
        #endregion

        #region Color
        [IN(LINE)] public static float4 GammaToLinearSpace(float4 value) { const float Gamma = 2.2f; return Pow(value, Gamma); }
        [IN(LINE)] public static float4 LinearToGammaSpace(float4 value) { const float InverseGamma = 1.0f / 2.2f; return Pow(value, InverseGamma); }
        #endregion

        #region Approximately
        [IN(LINE)] public static bool4 Approximately(float4 a, float4 b) { return Approximately(a, b, CMax(1E-06f * Max(Abs(a), Abs(b)), FloatEpsilon * 8f)); }
        [IN(LINE)] public static bool4 Approximately(float4 a, float4 b, float4 tolerance) { return Abs(b - a) < tolerance; }
        #endregion

        #region Pow2
        [IN(LINE)] public static float4 CeilPow2(float4 value) { return new float4(CeilPow2(value.x), CeilPow2(value.y), CeilPow2(value.z), CeilPow2(value.w)); }
        [IN(LINE)] public static float4 FloorPow2(float4 value) { return new float4(FloorPow2(value.x), FloorPow2(value.y), FloorPow2(value.z), FloorPow2(value.w)); }
        [IN(LINE)] public static float4 RoundPow2(float4 value) { return new float4(RoundPow2(value.x), RoundPow2(value.y), RoundPow2(value.z), RoundPow2(value.w)); }
        [IN(LINE)] public static bool4 IsPow2(float4 value) { return new bool4(IsPow2(value.x), IsPow2(value.y), IsPow2(value.z), IsPow2(value.w)); }
        #endregion

        #region Other
        [IN(LINE)] public static float Length(float4 a) { return Sqrt(Dot(a, a)); }
        [IN(LINE)] public static float LengthSqr(float4 a) { return Dot(a, a); }
        [IN(LINE)] public static float Distance(float4 a, float4 b) { return Length(b - a); }
        [IN(LINE)] public static float DistanceSqr(float4 a, float4 b) { return LengthSqr(b - a); }
        [IN(LINE)] public static float4 Normalize(float4 a) { return 1.0f / Sqrt(Dot(a, a)) * a; }
        [IN(LINE)]
        public static float4 NormalizeSafe(float4 a, float4 defaultvalue = default)
        {
            var len = Dot(a, a);
            return Select(defaultvalue, RSqrt(len) * a, len > FloatMinNormal);
        }

        [IN(LINE)] public static float4 Project(float4 a, float4 ontoB) { return (Dot(a, ontoB) / Dot(ontoB, ontoB)) * ontoB; }
        [IN(LINE)]
        public static float4 ProjectSafe(float4 a, float4 ontoB, float4 defaultValue = default)
        {
            var proj = Project(a, ontoB);
            return Select(defaultValue, proj, All(IsInfinity(proj)));
        }
        [IN(LINE)] public static float4 Reflect(float4 v, float4 n) { return v - 2f * n * Dot(v, n); }

        [IN(LINE)] public static float4 Select(float4 falseValue, float4 trueValue, bool4 test) { return test ? trueValue : falseValue; }
        [IN(LINE)] public static float4 Step(float4 threshold, float4 a) { return Select(0.0f, 1.0f, a >= threshold); }

        /// <summary> Convert Radians to Degrees. x * 57.296~ </summary>
        [IN(LINE)] public static float4 Degrees(float4 radians) { return radians * Rad2Deg; }
        /// <summary> Convert Degrees to Radians. x * 0.0175~ </summary>
        [IN(LINE)] public static float4 Radians(float4 degrees) { return degrees * Deg2Rad; }

        [IN(LINE)] public static float4 Cos(float4 a) { return new float4(Cos(a.x), Cos(a.y), Cos(a.z), Cos(a.w)); }
        [IN(LINE)] public static float4 Cosh(float4 a) { return new float4(Cosh(a.x), Cosh(a.y), Cosh(a.z), Cosh(a.w)); }
        [IN(LINE)] public static float4 Acos(float4 a) { return new float4(Acos(a.x), Acos(a.y), Acos(a.z), Acos(a.w)); }
        [IN(LINE)] public static float4 Sin(float4 a) { return new float4(Sin(a.x), Sin(a.y), Sin(a.z), Sin(a.w)); }
        [IN(LINE)] public static float4 Sinh(float4 a) { return new float4(Sinh(a.x), Sinh(a.y), Sinh(a.z), Sinh(a.w)); }
        [IN(LINE)] public static float4 Asin(float4 a) { return new float4(Asin(a.x), Asin(a.y), Asin(a.z), Asin(a.w)); }

        [IN(LINE)] public static float4 Atan(float4 a) { return new float4(Atan(a.x), Atan(a.y), Atan(a.z), Atan(a.w)); }
        [IN(LINE)] public static float4 Atan2(float4 a, float4 b) { return new float4(Atan2(a.x, b.x), Atan2(a.y, b.y), Atan2(a.z, b.z), Atan2(a.w, b.w)); }

        [IN(LINE)] public static float Dot(float4 a, float4 b) { return a.x * b.x + a.y * b.y + a.z * b.z; }
        [IN(LINE)] public static float4 Sqr(float4 a) { return a * a; }
        [IN(LINE)] public static float4 Sqrt(float4 a) { return new float4(Sqrt(a.x), Sqrt(a.y), Sqrt(a.z), Sqrt(a.w)); }
        [IN(LINE)] public static float4 RSqrt(float4 a) { return 1f / Sqrt(a); }
        [IN(LINE)] public static float4 Pow(float4 a, float4 b) { return new float4(Pow(a.x, a.y), Pow(a.y, a.y), Pow(a.z, a.z), Pow(a.w, a.w)); }
        [IN(LINE)] public static float4 Exp(float4 pow) { return new float4(Exp(pow.x), Exp(pow.y), Exp(pow.z), Exp(pow.z)); }
        [IN(LINE)] public static float4 Exp2(float4 pow) { return new float4(Exp2(pow.x), Exp2(pow.y), Exp2(pow.z), Exp2(pow.z)); }
        [IN(LINE)] public static float4 Exp10(float4 pow) { return new float4(Exp10(pow.x), Exp10(pow.y), Exp10(pow.z), Exp10(pow.z)); }
        [IN(LINE)] public static float4 Log(float4 f, float4 p) { return new float4(Log(f.x, p.x), Log(f.y, p.y), Log(f.z, p.z), Log(f.w, p.w)); }
        [IN(LINE)] public static float4 Log(float4 f) { return new float4(Log(f.x), Log(f.y), Log(f.z), Log(f.z)); }
        [IN(LINE)] public static float4 Log2(float4 f) { return new float4(Log2(f.x), Log2(f.y), Log2(f.z), Log2(f.z)); }
        [IN(LINE)] public static float4 Log10(float4 f) { return new float4(Log10(f.x), Log10(f.y), Log10(f.z), Log10(f.z)); }

        [IN(LINE)] public static float4 Tan(float4 a) { return new float4(Tan(a.x), Tan(a.y), Tan(a.z), Tan(a.w)); }
        [IN(LINE)] public static float4 Tanh(float4 a) { return new float4(Tanh(a.x), Tanh(a.y), Tanh(a.z), Tanh(a.w)); }

        [IN(LINE)] public static float4 Truncate(float4 a) { return new float4(Truncate(a.x), Truncate(a.y), Truncate(a.z), Truncate(a.w)); }
        #endregion


        #region Hash
        [IN(LINE)] public static uint UHash(float4 v) { return unchecked((uint)Hash(v)); }
        [IN(LINE)] public static int Hash(float4 v) { return Hash<float4>(v); }
        #endregion
    }

    public static partial class DM // IVector4<float>
    {
        #region Abs/Sign
        [IN(LINE)] public static T Abs<T>(T a, _4_ _ = default) where T : unmanaged, IVector4Impl<float> { return New<T>(Abs(ToBasic(a))); }
        [IN(LINE)] public static T Sign<T>(T a, _4_ _ = default) where T : unmanaged, IVector4Impl<float> { return New<T>(Sign(ToBasic(a))); }
        [IN(LINE)] public static int4 Sign2Int<T>(T a, _4_ _ = default) where T : unmanaged, IVector4Impl<float> { return Sign2Int(ToBasic(a)); }
        #endregion

        #region Round/Floor/Ceil
        [IN(LINE)] public static T Round<T>(T a, _4_ _ = default) where T : unmanaged, IVector4Impl<float> { return New<T>(Round(ToBasic(a))); }
        [IN(LINE)] public static int4 Round2Int<T>(T a, _4_ _ = default) where T : unmanaged, IVector4Impl<float> { return Round2Int(ToBasic(a)); }
        [IN(LINE)] public static T Floor<T>(T a, _4_ _ = default) where T : unmanaged, IVector4Impl<float> { return New<T>(Floor(ToBasic(a))); }
        [IN(LINE)] public static int4 Floor2Int<T>(T a, _4_ _ = default) where T : unmanaged, IVector4Impl<float> { return Floor2Int(ToBasic(a)); }
        [IN(LINE)] public static T Ceil<T>(T a, _4_ _ = default) where T : unmanaged, IVector4Impl<float> { return New<T>(Ceil(ToBasic(a))); }
        [IN(LINE)] public static int4 Ceil2Int<T>(T a, _4_ _ = default) where T : unmanaged, IVector4Impl<float> { return Ceil2Int(ToBasic(a)); }

        [EditorBrowsable(EditorBrowsableState.Never)] [IN(LINE)] public static int4 Round2UInt<T>(T a, _4_ _ = default) where T : unmanaged, IVector4Impl<float> { return Round2UInt(ToBasic(a)); }
        [EditorBrowsable(EditorBrowsableState.Never)] [IN(LINE)] public static int4 Floor2UInt<T>(T a, _4_ _ = default) where T : unmanaged, IVector4Impl<float> { return Floor2UInt(ToBasic(a)); }
        [EditorBrowsable(EditorBrowsableState.Never)] [IN(LINE)] public static int4 Ceil2UInt<T>(T a, _4_ _ = default) where T : unmanaged, IVector4Impl<float> { return Ceil2UInt(ToBasic(a)); }
        #endregion

        #region Clamp/Repeat/PingPong
        /// <summary> Clamps the value between min and max. </summary>
        [IN(LINE)] public static T Clamp<T>(T a, T min, T max, _4_ _ = default) where T : unmanaged, IVector4Impl<float> { return New<T>(Clamp(ToBasic(a), ToBasic(min), ToBasic(max))); }
        /// <summary> Clamps the value between 0 and 1. </summary>
        [IN(LINE)] public static T Clamp01<T>(T a, _4_ _ = default) where T : unmanaged, IVector4Impl<float> { return New<T>(Clamp01(ToBasic(a))); }
        /// <summary> Clamps the value between -1 and 1. </summary>
        [IN(LINE)] public static T ClampMirror1<T>(T a, _4_ _ = default) where T : unmanaged, IVector4Impl<float> { return New<T>(ClampMirror1(ToBasic(a))); }

        [IN(LINE)] public static T Repeat<T>(T a, T length, _4_ _ = default) where T : unmanaged, IVector4Impl<float> { return New<T>(Repeat(ToBasic(a), ToBasic(length))); }
        [IN(LINE)] public static T Repeat<T>(T a, T min, T max, _4_ _ = default) where T : unmanaged, IVector4Impl<float> { return New<T>(Repeat(ToBasic(a), ToBasic(min), ToBasic(max))); }
        [IN(LINE)] public static T Repeat01<T>(T a, _4_ _ = default) where T : unmanaged, IVector4Impl<float> { return New<T>(Repeat01(ToBasic(a))); }
        [IN(LINE)] public static T RepeatMirror1<T>(T a, _4_ _ = default) where T : unmanaged, IVector4Impl<float> { return New<T>(RepeatMirror1(ToBasic(a))); }

        [IN(LINE)] public static T PingPong<T>(T a, T length, _4_ _ = default) where T : unmanaged, IVector4Impl<float> { return New<T>(PingPong(ToBasic(a), ToBasic(length))); }
        [IN(LINE)] public static T PingPong<T>(T a, T min, T max, _4_ _ = default) where T : unmanaged, IVector4Impl<float> { return New<T>(PingPong(ToBasic(a), ToBasic(min), ToBasic(max))); }
        [IN(LINE)] public static T PingPong01<T>(T a, _4_ _ = default) where T : unmanaged, IVector4Impl<float> { return New<T>(PingPong01(ToBasic(a))); }
        [IN(LINE)] public static T PingPongMirror1<T>(T a, _4_ _ = default) where T : unmanaged, IVector4Impl<float> { return New<T>(PingPongMirror1(ToBasic(a))); }
        #endregion

        #region SmoothStep
        /// <summary> Clamps the value between from and to. </summary>
        [IN(LINE)] public static T SmoothStep<T>(T from, T to, T a, _4_ _ = default) where T : unmanaged, IVector4Impl<float> { return New<T>(SmoothStep(ToBasic(from), ToBasic(to), ToBasic(a))); }
        /// <summary> Clamps the value between 0 and 1. </summary>
        [IN(LINE)] public static T SmoothStep01<T>(T a, _4_ _ = default) where T : unmanaged, IVector4Impl<float> { return New<T>(SmoothStep01(ToBasic(a))); }
        /// <summary> Clamps the value between -1 and 1. </summary>
        [IN(LINE)] public static T SmoothStepMirror1<T>(T a, _4_ _ = default) where T : unmanaged, IVector4Impl<float> { return New<T>(SmoothStepMirror1(ToBasic(a))); }
        #endregion

        #region All/Any
        [IN(LINE)] public static bool All<T>(T a, _4_ _ = default) where T : unmanaged, IVector4Impl<float> { return All(ToBasic(a)); }
        [IN(LINE)] public static bool Any<T>(T a, _4_ _ = default) where T : unmanaged, IVector4Impl<float> { return Any(ToBasic(a)); }
        #endregion
    
        #region Min/Max/Sum
        [IN(LINE)] public static T Max<T>(T a, T b) where T : unmanaged, IVector4Impl<float> { return New<T>(Max(ToBasic(a), ToBasic(b))); }
        [IN(LINE)] public static T AbsMax<T>(T a, T b) where T : unmanaged, IVector4Impl<float> { return New<T>(AbsMax(ToBasic(a), ToBasic(b))); }
        [IN(LINE)] public static T Min<T>(T a, T b) where T : unmanaged, IVector4Impl<float> { return New<T>(Min(ToBasic(a), ToBasic(b))); }
        [IN(LINE)] public static T AbsMin<T>(T a, T b) where T : unmanaged, IVector4Impl<float> { return New<T>(AbsMin(ToBasic(a), ToBasic(b))); }
        [IN(LINE)] public static float CMax<T>(T a) where T : unmanaged, IVector4Impl<float> { return CMax(ToBasic(a)); }
        [IN(LINE)] public static float CAbsMax<T>(T a) where T : unmanaged, IVector4Impl<float> { return CAbsMax(ToBasic(a)); }
        [IN(LINE)] public static float CMin<T>(T a) where T : unmanaged, IVector4Impl<float> { return CMin(ToBasic(a)); }
        [IN(LINE)] public static float CAbsMin<T>(T a) where T : unmanaged, IVector4Impl<float> { return CAbsMin(ToBasic(a)); }
        [IN(LINE)] public static float CSum<T>(T a) where T : unmanaged, IVector4Impl<float> { return CSum(ToBasic(a)); }
        #endregion

        #region Lerp
        [IN(LINE)] public static T Lerp<T>(T start, T end, T t) where T : unmanaged, IVector4Impl<float> { return New<T>(Lerp(ToBasic(start), ToBasic(end), ToBasic(t))); }
        [IN(LINE)] public static T LerpClamp<T>(T start, T end, T t) where T : unmanaged, IVector4Impl<float> { return New<T>(LerpClamp(ToBasic(start), ToBasic(end), ToBasic(t))); }
        [IN(LINE)] public static T LerpRepeat<T>(T start, T end, T t) where T : unmanaged, IVector4Impl<float> { return New<T>(LerpRepeat(ToBasic(start), ToBasic(end), ToBasic(t))); }

        [IN(LINE)] public static T UnLerp<T>(T start, T end, T a) where T : unmanaged, IVector4Impl<float> { return New<T>(UnLerp(ToBasic(start), ToBasic(end), ToBasic(a))); }
        [IN(LINE)] public static T UnLerpClamp<T>(T start, T end, T a) where T : unmanaged, IVector4Impl<float> { return New<T>(UnLerpClamp(ToBasic(start), ToBasic(end), ToBasic(a))); }
        [IN(LINE)] public static T UnLerpRepeat<T>(T start, T end, T a) where T : unmanaged, IVector4Impl<float> { return New<T>(UnLerpRepeat(ToBasic(start), ToBasic(end), ToBasic(a))); }


        [IN(LINE)] public static T MoveTowards<T>(T from, T to, float distance) where T : unmanaged, IVector4Impl<float> { return New<T>(MoveTowards(ToBasic(from), ToBasic(to), distance)); }
        [IN(LINE)] public static T MoveTowards<T>(T from, T to, float distance, out float excess) where T : unmanaged, IVector4Impl<float> { return New<T>(MoveTowards(ToBasic(from), ToBasic(to), distance, out excess)); }
        [IN(LINE)] public static T Remap<T>(T oldStart, T oldEnd, T newStart, T newEnd, T v) where T : unmanaged, IVector4Impl<float> { return New<T>(Remap(ToBasic(oldStart), ToBasic(oldEnd), ToBasic(newStart), ToBasic(newEnd), ToBasic(v))); }

        [IN(LINE)]
        public static float4 LerpAngle(float4 start, float4 end, float t)
        {
            float4 angle = Repeat(end - start, 360f);
            if (angle > 180f) { angle -= 360f; }
            //float angle = Repeat(end - start, -180f, 180f);
            return start + angle * Clamp01(t);
        }
        [IN(LINE)]
        public static float4 DeltaAngle(float4 current, float4 target)
        {
            float4 angle = Repeat(target - current, 360f);
            if (angle > 180f) { angle -= 360f; }
            //float angle = Repeat(end - start, -180f, 180f);
            return angle;
        }
        [IN(LINE)]
        public static float4 MoveTowardsAngle(float4 current, float4 target, float maxDelta)
        {
            float4 delta = DeltaAngle(current, target);
            if (0f - maxDelta < delta && delta < maxDelta)
            {
                return target;
            }
            return MoveTowards(current, current + delta, maxDelta);
        }
        #endregion
    
        #region Float State Checks
        [IN(LINE)] public static bool4 IsNormalFloat(float4 a) { return new bool4(float.IsNormal(a.x), float.IsNormal(a.y), float.IsNormal(a.z), float.IsNormal(a.w)); }
        [IN(LINE)] public static bool4 IsFinite(float4 a) { return new bool4(float.IsFinite(a.x), float.IsFinite(a.y), float.IsFinite(a.z), float.IsFinite(a.w)); }
        [IN(LINE)] public static bool4 IsNaN(float4 a) { return new bool4(float.IsNaN(a.x), float.IsNaN(a.y), float.IsNaN(a.z), float.IsNaN(a.w)); }
        [IN(LINE)] public static bool4 IsInfinity(float4 a) { return new bool4(float.IsInfinity(a.x), float.IsInfinity(a.y), float.IsInfinity(a.z), float.IsInfinity(a.w)); }
        [IN(LINE)] public static bool4 IsNegativeInfinity(float4 a) { return new bool4(float.IsNegativeInfinity(a.x), float.IsNegativeInfinity(a.y), float.IsNegativeInfinity(a.z), float.IsNegativeInfinity(a.w)); }
        [IN(LINE)] public static bool4 IsPositiveInfinity(float4 a) { return new bool4(float.IsPositiveInfinity(a.x), float.IsPositiveInfinity(a.y), float.IsPositiveInfinity(a.z), float.IsPositiveInfinity(a.w)); }
        #endregion
    
        #region Color
        [IN(LINE)] public static float4 GammaToLinearSpace(float4 value) { const float Gamma = 2.2f; return Pow(value, Gamma); }
        [IN(LINE)] public static float4 LinearToGammaSpace(float4 value) { const float InverseGamma = 1.0f / 2.2f; return Pow(value, InverseGamma); }
        #endregion
    
        #region Approximately
        [IN(LINE)] public static bool4 Approximately(float4 a, float4 b) { return Approximately(a, b, CMax(1E-06f * Max(Abs(a), Abs(b)), FloatEpsilon * 8f)); }
        [IN(LINE)] public static bool4 Approximately(float4 a, float4 b, float4 tolerance) { return Abs(b - a) < tolerance; }
        #endregion
    
        #region Other
        [IN(LINE)] public static float Length(float4 a) { return Sqrt(Dot(a, a)); }
        [IN(LINE)] public static float LengthSqr(float4 a) { return Dot(a, a); }
        [IN(LINE)] public static float Distance(float4 a, float4 b) { return Length(b - a); }
        [IN(LINE)] public static float DistanceSqr(float4 a, float4 b) { return LengthSqr(b - a); }
        [IN(LINE)] public static float4 Normalize(float4 a) { return 1.0f / Sqrt(Dot(a, a)) * a; }
        [IN(LINE)]
        public static float4 NormalizeSafe(float4 a, float4 defaultvalue = default)
        {
            var len = Dot(a, a);
            return Select(defaultvalue, RSqrt(len) * a, len > FloatMinNormal);
        }
    
        [IN(LINE)] public static float4 Project(float4 a, float4 ontoB) { return (Dot(a, ontoB) / Dot(ontoB, ontoB)) * ontoB; }
        [IN(LINE)]
        public static float4 ProjectSafe(float4 a, float4 ontoB, float4 defaultValue = default)
        {
            var proj = Project(a, ontoB);
            return Select(defaultValue, proj, All(IsInfinity(proj)));
        }
        [IN(LINE)] public static float4 Reflect(float4 v, float4 n) { return v - 2f * n * Dot(v, n); }
    
        [IN(LINE)] public static float4 Select(float4 falseValue, float4 trueValue, bool4 test) { return test ? trueValue : falseValue; }
        [IN(LINE)] public static float4 Step(float4 threshold, float4 a) { return Select(0.0f, 1.0f, a >= threshold); }
    
        /// <summary> Convert Radians to Degrees. x * 57.296~ </summary>
        [IN(LINE)] public static float4 Degrees(float4 radians) { return radians * Rad2Deg; }
        /// <summary> Convert Degrees to Radians. x * 0.0175~ </summary>
        [IN(LINE)] public static float4 Radians(float4 degrees) { return degrees * Deg2Rad; }
    
        [IN(LINE)] public static float4 Cos(float4 a) { return new float4(Cos(a.x), Cos(a.y), Cos(a.z), Cos(a.w)); }
        [IN(LINE)] public static float4 Cosh(float4 a) { return new float4(Cosh(a.x), Cosh(a.y), Cosh(a.z), Cosh(a.w)); }
        [IN(LINE)] public static float4 Acos(float4 a) { return new float4(Acos(a.x), Acos(a.y), Acos(a.z), Acos(a.w)); }
        [IN(LINE)] public static float4 Sin(float4 a) { return new float4(Sin(a.x), Sin(a.y), Sin(a.z), Sin(a.w)); }
        [IN(LINE)] public static float4 Sinh(float4 a) { return new float4(Sinh(a.x), Sinh(a.y), Sinh(a.z), Sinh(a.w)); }
        [IN(LINE)] public static float4 Asin(float4 a) { return new float4(Asin(a.x), Asin(a.y), Asin(a.z), Asin(a.w)); }
    
        [IN(LINE)] public static float4 Atan(float4 a) { return new float4(Atan(a.x), Atan(a.y), Atan(a.z), Atan(a.w)); }
        [IN(LINE)] public static float4 Atan2(float4 a, float4 b) { return new float4(Atan2(a.x, b.x), Atan2(a.y, b.y), Atan2(a.z, b.z), Atan2(a.w, b.w)); }
    
        [IN(LINE)] public static float Dot(float4 a, float4 b) { return a.x * b.x + a.y * b.y + a.z * b.z; }
        [IN(LINE)] public static float4 Sqr(float4 a) { return a * a; }
        [IN(LINE)] public static float4 Sqrt(float4 a) { return new float4(Sqrt(a.x), Sqrt(a.y), Sqrt(a.z), Sqrt(a.w)); }
        [IN(LINE)] public static float4 RSqrt(float4 a) { return 1f / Sqrt(a); }
        [IN(LINE)] public static float4 Pow(float4 a, float4 b) { return new float4(Pow(a.x, a.y), Pow(a.y, a.y), Pow(a.z, a.z), Pow(a.w, a.w)); }
        [IN(LINE)] public static float4 Exp(float4 pow) { return new float4(Exp(pow.x), Exp(pow.y), Exp(pow.z), Exp(pow.z)); }
        [IN(LINE)] public static float4 Exp2(float4 pow) { return new float4(Exp2(pow.x), Exp2(pow.y), Exp2(pow.z), Exp2(pow.z)); }
        [IN(LINE)] public static float4 Exp10(float4 pow) { return new float4(Exp10(pow.x), Exp10(pow.y), Exp10(pow.z), Exp10(pow.z)); }
        [IN(LINE)] public static float4 Log(float4 f, float4 p) { return new float4(Log(f.x, p.x), Log(f.y, p.y), Log(f.z, p.z), Log(f.w, p.w)); }
        [IN(LINE)] public static float4 Log(float4 f) { return new float4(Log(f.x), Log(f.y), Log(f.z), Log(f.z)); }
        [IN(LINE)] public static float4 Log2(float4 f) { return new float4(Log2(f.x), Log2(f.y), Log2(f.z), Log2(f.z)); }
        [IN(LINE)] public static float4 Log10(float4 f) { return new float4(Log10(f.x), Log10(f.y), Log10(f.z), Log10(f.z)); }
    
        [IN(LINE)] public static float4 Tan(float4 a) { return new float4(Tan(a.x), Tan(a.y), Tan(a.z), Tan(a.w)); }
        [IN(LINE)] public static float4 Tanh(float4 a) { return new float4(Tanh(a.x), Tanh(a.y), Tanh(a.z), Tanh(a.w)); }
    
        [IN(LINE)] public static float4 Truncate(float4 a) { return new float4(Truncate(a.x), Truncate(a.y), Truncate(a.z), Truncate(a.w)); }
        #endregion
    
    
    
    
        #region Hash
        [IN(LINE)] public static uint UHash(float4 v) { return unchecked((uint)Hash(v)); }
        [IN(LINE)] public static int Hash(float4 v) { return Hash<float4>(v); }
        #endregion
    }

    public static partial class DMBasicExt // IVector4<float>
    {
        [IN(LINE)] public static float4 ToBasic<T>(this T a, _4_ _ = default) where T : unmanaged, IVector4Impl<float> { return new float4(a.x, a.y, a.z, a.w); }
    }
    public static partial class DMBasic // IVector4<float>
    {
        [IN(LINE)] public static T New<T>(float a, _4_ _ = default) where T : unmanaged, IVector4<float> { return New<T>(a, a, a, a); }
        [IN(LINE)] public static T New<T>(float4 a) where T : unmanaged, IVector4<float> { return New<T>(a.x, a.y, a.z, a.w); }
        [IN(LINE)] public static T New<T>(float x, float y, float z, float w) where T : unmanaged, IVector4<float> { T r = default; r.x = x; r.y = y; r.z = z; r.w = w; return r; }
        [IN(LINE)] public static float4 ToBasic<T>(T a, _4_ _ = default) where T : unmanaged, IVector4Impl<float> { return new float4(a.x, a.y, a.z, a.w); }
        [IN(LINE)] public static T Add<T>(T a, T b, _4_ _ = default) where T : unmanaged, IVector4Impl<float> { return New<T>(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w); }
        [IN(LINE)] public static T Sub<T>(T a, T b, _4_ _ = default) where T : unmanaged, IVector4Impl<float> { return New<T>(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w); }
        [IN(LINE)] public static T Mul<T>(T a, T b, _4_ _ = default) where T : unmanaged, IVector4Impl<float> { return New<T>(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w); }
        [IN(LINE)] public static T Div<T>(T a, T b, _4_ _ = default) where T : unmanaged, IVector4Impl<float> { return New<T>(a.x / b.x, a.y / b.y, a.z / b.z, a.w / b.w); }
        [IN(LINE)] public static T Mod<T>(T a, T b, _4_ _ = default) where T : unmanaged, IVector4Impl<float> { return New<T>(a.x % b.x, a.y % b.y, a.z % b.z, a.w % b.w); }
        [IN(LINE)] public static bool4 Equals<T>(T a, T b, _4_ _ = default) where T : unmanaged, IVector4Impl<float> { return new bool4(a.x == b.x, a.y == b.y, a.z == b.z, a.w == b.w); }
        [IN(LINE)] public static bool4 Greater<T>(T a, T b, _4_ _ = default) where T : unmanaged, IVector4Impl<float> { return new bool4(a.x > b.x, a.y > b.y, a.z > b.z, a.w > b.w); }
        [IN(LINE)] public static bool4 Less<T>(T a, T b, _4_ _ = default) where T : unmanaged, IVector4Impl<float> { return new bool4(a.x < b.x, a.y < b.y, a.z < b.z, a.w < b.w); }
        [IN(LINE)] public static bool4 GreaterOrEquals<T>(T a, T b, _4_ _ = default) where T : unmanaged, IVector4Impl<float> { return new bool4(a.x >= b.x, a.y >= b.y, a.z >= b.z, a.w >= b.w); }
        [IN(LINE)] public static bool4 LessOrEquals<T>(T a, T b, _4_ _ = default) where T : unmanaged, IVector4Impl<float> { return new bool4(a.x <= b.x, a.y <= b.y, a.z <= b.z, a.w <= b.w); }
    }
}