#pragma warning disable CS8981
#if DISABLE_DEBUG
#undef DEBUG
#endif
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct line3
    {
        #region Length/Normalized
        public float3 From { [IN(LINE)] get { return a; } [IN(LINE)] set { a = value; } }
        public float3 To { [IN(LINE)] get { return b; } [IN(LINE)] set { b = value; } }
        public float3 Min { [IN(LINE)] get { return DM.Min(this); } }
        public float3 Max { [IN(LINE)] get { return DM.Max(this); } }
        public float3 Center { [IN(LINE)] get { return (a + b) * 0.5f; } }
        public float Length { [IN(LINE)] get { return DM.Length(this); } }
        public float LengthSq { [IN(LINE)] get { return DM.LengthSq(this); } }
        public line3 Normalized { [IN(LINE)] get { return new line3(a, a + DM.NormalizeSafe(dir)); } }
        #endregion
    }
    public static partial class DM // line3
    {
        #region Abs
        [IN(LINE)] public static line3 Abs(line3 a) { return new line3(a.a, a.a + Abs(a.dir)); }
        #endregion

        #region Clamp/Repeat/PingPong/SmoothStep
        [IN(LINE)] public static float3 Clamp(float3 a, line3 range) { return Clamp(a, range.From, range.To); }
        [IN(LINE)] public static float3 Repeat(float3 a, line3 range) { return Repeat(a, range.From, range.To); }
        [IN(LINE)] public static float3 PingPong(float3 a, line3 range) { return PingPong(a, range.From, range.To); }
        [IN(LINE)] public static float3 SmoothStep(line3 range, float3 a) { return SmoothStep(range.From, range.To, a); }
        #endregion

        #region Min/Max
        [IN(LINE)] public static float3 Max(line3 range) { return Max(range.a, range.b); }
        [IN(LINE)] public static float3 Min(line3 range) { return Min(range.a, range.b); }
        #endregion

        #region Lerp
        [IN(LINE)] public static float3 Lerp(line3 range, float t) { return Lerp(range.From, range.To, t); }
        [IN(LINE)] public static float3 Lerp(line3 range, float3 t) { return Lerp(range.From, range.To, t); }
        [IN(LINE)] public static float3 LerpClamp(line3 range, float t) { return LerpClamp(range.From, range.To, t); }
        [IN(LINE)] public static float3 LerpClamp(line3 range, float3 t) { return LerpClamp(range.From, range.To, t); }
        [IN(LINE)] public static float3 LerpRepeat(line3 range, float t) { return LerpRepeat(range.From, range.To, t); }
        [IN(LINE)] public static float3 LerpRepeat(line3 range, float3 t) { return LerpRepeat(range.From, range.To, t); }

        [IN(LINE)] public static float3 UnLerp(line3 range, float3 a) { return UnLerp(range.From, range.To, a); }
        [IN(LINE)] public static float3 UnLerpClamp(line3 range, float3 a) { return UnLerpClamp(range.From, range.To, a); }
        [IN(LINE)] public static float3 UnLerpRepeat(line3 range, float3 a) { return UnLerpRepeat(range.From, range.To, a); }

        [IN(LINE)] public static float3 Remap(line3 oldRange, line3 newRange, float v) { return Remap(oldRange.From, oldRange.To, newRange.From, newRange.To, v); }
        [IN(LINE)] public static float3 Remap(line3 oldRange, line3 newRange, float3 v) { return Remap(oldRange.From, oldRange.To, newRange.From, newRange.To, v); }

        [IN(LINE)] public static float3 LerpAngle(line3 range, float t) { return LerpAngle(range.From, range.To, t); }
        [IN(LINE)] public static float3 LerpAngleClamp(line3 range, float t) { return LerpAngleClamp(range.From, range.To, t); }
        [IN(LINE)] public static float3 LerpAngleRepeat(line3 range, float t) { return LerpAngleRepeat(range.From, range.To, t); }

        [IN(LINE)] public static float3 MoveTowards(line3 range, float distance) { return MoveTowards(range.From, range.To, distance); }
        [IN(LINE)] public static float3 MoveTowards(line3 range, float distance, out float excess) { return MoveTowards(range.From, range.To, distance, out excess); }

        [IN(LINE)] public static float3 MoveTowardsAngle(line3 range, float distance) { return MoveTowardsAngle(range.From, range.To, distance); }
        #endregion

        #region Real Value State Checks
        [IN(LINE)] public static bool3 IsNegative(line3 a) { return IsNegative(a.a); }
        [IN(LINE)] public static bool3 IsPositive(line3 a) { return IsPositive(a.a); }
        [IN(LINE)] public static bool3 IsFinite(line3 a) { return IsFinite(a.a); }
        [IN(LINE)] public static bool3 IsInfinity(line3 a) { return IsInfinity(a.a); }
        [IN(LINE)] public static bool3 IsNegativeInfinity(line3 a) { return IsNegativeInfinity(a.a); }
        [IN(LINE)] public static bool3 IsPositiveInfinity(line3 a) { return IsPositiveInfinity(a.a); }
        #endregion

        #region Space Converts
        [IN(LINE)] public static line3 GammaToLinearSpace(line3 a) { const float Gamma = 2.2f; return new line3(Pow(a.a, Gamma), Pow(a.b, Gamma)); }
        [IN(LINE)] public static line3 LinearToGammaSpace(line3 a) { const float InverseGamma = 1.0f / 2.2f; return new line3(Pow(a.a, InverseGamma), Pow(a.b, InverseGamma)); }
        [IN(LINE)] public static line3 Degrees(line3 radians) { return new line3(Degrees(radians.a), Degrees(radians.b)); }
        [IN(LINE)] public static line3 Radians(line3 degrees) { return new line3(Radians(degrees.a), Radians(degrees.b)); }
        #endregion

        #region Length/Distance/Normalize
        [IN(LINE)] public static float Length(line3 a) { return Length(a.dir); }
        [IN(LINE)] public static float LengthSq(line3 a) { return LengthSq(a.dir); }
        [IN(LINE)] public static line3 Normalize(line3 a) { return new line3(a.a, a.a + Normalize(a.dir)); }
        [IN(LINE)] public static line3 NormalizeSafe(line3 a, float3 defaultvalue = default) { return new line3(a.a, a.a + NormalizeSafe(a.dir, defaultvalue)); }
        [IN(LINE)] public static bool IsNormalized(line3 a) { return IsNormalized(a.dir); }
        #endregion

        #region Other
        [IN(LINE)] public static line3 Reverse(line3 a) { return new line3(a.b, a.a); }
        [IN(LINE)] public static float3 GetPoint(line3 line, float distance) { return line.a + line.dir * distance; }
        [IN(LINE)] public static bool Contains(line3 line, float3 point, float tolerance = 0.0001f) { return Contains(new ray3(line), point, tolerance); }
        [IN(LINE)] public static float3 ProjectPoint(line3 line, float3 point) { return line.a + Project(point - line.a, line.dir); }
        [IN(LINE)] public static line3 Expand(line3 line, float amount) { return new line3(Expand(new ray3(line), amount)); }
        #endregion
    }
}
