#if DISABLE_DEBUG
#undef DEBUG
#endif
using System.Numerics;
using System.Reflection;
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct ray1
    {
        #region Length/Normalized
        public float From { [IN(LINE)] get { return src; } [IN(LINE)] set { dir -= value - src; src = value; } }
        public float To { [IN(LINE)] get { return src + dir; } [IN(LINE)] set { dir -= (To - value); } }
        public float Min { [IN(LINE)] get { return DM.Min(this); } }
        public float Max { [IN(LINE)] get { return DM.Max(this); } }
        public float Center { [IN(LINE)] get { return src + dir / 2f; } }
        public float Length { [IN(LINE)] get { return DM.Length(this); } }
        public float LengthSqr { [IN(LINE)] get { return DM.LengthSqr(this); } }
        public ray1 Normalized { [IN(LINE)] get { return new ray1(src, DM.NormalizeSafe(dir)); } }
        #endregion
    }
    public static partial class DM  // ray1
    {
        #region Abs
        [IN(LINE)] public static ray1 Abs(ray1 a) { return new ray1(a.src, Abs(a.dir)); }
        #endregion

        #region Clamp/Repeat/PingPong/SmoothStep
        /// <summary> Clamps the value between min and max. </summary>
        [IN(LINE)] public static float Clamp(float a, ray1 range) { return Clamp(a, range.From, range.To); }
        [IN(LINE)] public static float Repeat(float a, ray1 range) { return Repeat(a, range.From, range.To); }
        [IN(LINE)] public static float PingPong(float a, ray1 range) { return PingPong(a, range.From, range.To); }
        /// <summary> Clamps the value between from and to. </summary>
        [IN(LINE)] public static float SmoothStep(ray1 range, float a) { return SmoothStep(range.From, range.To, a); }
        #endregion

        #region Min/Max
        [IN(LINE)] public static float Max(ray1 range) { return IsPositive(range.dir) ? range.src + range.dir : range.src; }
        [IN(LINE)] public static float Min(ray1 range) { return IsPositive(range.dir) ? range.src : range.src + range.dir; }
        #endregion

        #region Lerp
        [IN(LINE)] public static float Lerp(ray1 range, float t) { return Lerp(range.From, range.To, t); }
        [IN(LINE)] public static float LerpClamp(ray1 range, float t) { return LerpClamp(range.From, range.To, t); }
        [IN(LINE)] public static float LerpRepeat(ray1 range, float t) { return LerpRepeat(range.From, range.To, t); }

        [IN(LINE)] public static float UnLerp(ray1 range, float a) { return UnLerp(range.From, range.To, a); }
        [IN(LINE)] public static float UnLerpClamp(ray1 range, float a) { return UnLerpClamp(range.From, range.To, a); }
        [IN(LINE)] public static float UnLerpRepeat(ray1 range, float a) { return UnLerpRepeat(range.From, range.To, a); }

        [IN(LINE)] public static float Remap(ray1 oldRange, ray1 newRange, float v) { return Remap(oldRange.From, oldRange.To, newRange.From, newRange.To, v); }

        [IN(LINE)] public static float LerpAngle(ray1 range, float t) { return LerpAngle(range.From, range.To, t); }
        [IN(LINE)] public static float LerpAngleClamp(ray1 range, float t) { return LerpAngleClamp(range.From, range.To, t); }
        [IN(LINE)] public static float LerpAngleRepeat(ray1 range, float t) { return LerpAngleRepeat(range.From, range.To, t); }

        [IN(LINE)] public static float MoveTowards(ray1 range, float distance) { return MoveTowards(range.From, range.To, distance); }
        [IN(LINE)] public static float MoveTowards(ray1 range, float distance, out float excess) { return MoveTowards(range.From, range.To, distance, out excess); }

        [IN(LINE)] public static float MoveTowardsAngle(ray1 range, float distance) { return MoveTowardsAngle(range.From, range.To, distance); }
        #endregion

        #region Real Value State Checks
        [IN(LINE)] public static bool IsNegative(ray1 a) { return float.IsNegative(a.src); }
        [IN(LINE)] public static bool IsPositive(ray1 a) { return !float.IsNegative(a.src); }
        [IN(LINE)] public static bool IsFinite(ray1 a) { return float.IsFinite(a.src); }
        [IN(LINE)] public static bool IsInfinity(ray1 a) { return float.IsInfinity(a.src); }
        [IN(LINE)] public static bool IsNegativeInfinity(ray1 a) { return float.IsNegativeInfinity(a.src); }
        [IN(LINE)] public static bool IsPositiveInfinity(ray1 a) { return float.IsPositiveInfinity(a.src); }
        #endregion

        #region Space Converts
        [IN(LINE)] public static ray1 GammaToLinearSpace(ray1 a) { const float Gamma = 2.2f; return new ray1(Pow(a.src, Gamma), Pow(a.dir, Gamma)); }
        [IN(LINE)] public static ray1 LinearToGammaSpace(ray1 a) { const float InverseGamma = 1.0f / 2.2f; return new ray1(Pow(a.src, InverseGamma), Pow(a.dir, InverseGamma)); }
        [IN(LINE)] public static ray1 Degrees(ray1 radians) { return new ray1(Degrees(radians.src), Degrees(radians.dir)); }
        [IN(LINE)] public static ray1 Radians(ray1 degrees) { return new ray1(Radians(degrees.src), Radians(degrees.dir)); }
        #endregion

        #region Length/Distance/Normalize
        [IN(LINE)] public static float Length(ray1 a) { return Length(a.dir); }
        [IN(LINE)] public static float LengthSqr(ray1 a) { return LengthSqr(a.dir); }
        [IN(LINE)] public static ray1 Normalize(ray1 a) { return new ray1(a.src, Normalize(a.dir)); }
        [IN(LINE)] public static ray1 NormalizeSafe(ray1 a, float defaultvalue = 0f) { return new ray1(a.src, NormalizeSafe(a.dir, defaultvalue)); }
        [IN(LINE)] public static bool IsNormalized(ray1 a) { return IsNormalized(a.dir); }
        #endregion

        #region Other
        [IN(LINE)] public static ray1 Reverse(ray1 a) { return new ray1(a.src + a.dir, -a.dir); }
        [IN(LINE)] public static float GetPoint(ray1 ray, float distance) { return ray.src + ray.dir * distance; }
        [IN(LINE)] public static bool Contains(ray1 range, float a, float tolerance = 0.0001f) { return a >= range.Min && a <= range.Max; }
        [IN(LINE)] public static float ProjectPoint(ray1 ray, float point) { return point; }
        #endregion
    }
}