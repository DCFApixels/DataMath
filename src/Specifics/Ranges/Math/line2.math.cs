#pragma warning disable CS8981
#if DISABLE_DEBUG
#undef DEBUG
#endif
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct line2
    {
        #region Length/Normalized
        public float2 From { [IN(LINE)] get { return a; } [IN(LINE)] set { a = value; } }
        public float2 To { [IN(LINE)] get { return b; } [IN(LINE)] set { b = value; } }
        public float2 Min { [IN(LINE)] get { return DM.Min(this); } }
        public float2 Max { [IN(LINE)] get { return DM.Max(this); } }
        public float2 Center { [IN(LINE)] get { return (a + b) * 0.5f; } }
        public float Length { [IN(LINE)] get { return DM.Length(this); } }
        public float LengthSq { [IN(LINE)] get { return DM.LengthSq(this); } }
        public line2 Normalized { [IN(LINE)] get { return new line2(a, a + DM.NormalizeSafe(dir)); } }
        #endregion
    }
    public static partial class DM // line2
    {
        #region Abs
        [IN(LINE)] public static line2 Abs(line2 a) { return new line2(a.a, a.a + Abs(a.dir)); }
        #endregion

        #region Clamp/Repeat/PingPong/SmoothStep
        [IN(LINE)] public static float2 Clamp(float2 a, line2 range) { return Clamp(a, range.From, range.To); }
        [IN(LINE)] public static float2 Repeat(float2 a, line2 range) { return Repeat(a, range.From, range.To); }
        [IN(LINE)] public static float2 PingPong(float2 a, line2 range) { return PingPong(a, range.From, range.To); }
        [IN(LINE)] public static float2 SmoothStep(line2 range, float2 a) { return SmoothStep(range.From, range.To, a); }
        #endregion

        #region Min/Max
        [IN(LINE)] public static float2 Max(line2 range) { return Max(range.a, range.b); }
        [IN(LINE)] public static float2 Min(line2 range) { return Min(range.a, range.b); }
        #endregion

        #region Lerp
        [IN(LINE)] public static float2 Lerp(line2 range, float t) { return Lerp(range.From, range.To, t); }
        [IN(LINE)] public static float2 Lerp(line2 range, float2 t) { return Lerp(range.From, range.To, t); }
        [IN(LINE)] public static float2 LerpClamp(line2 range, float t) { return LerpClamp(range.From, range.To, t); }
        [IN(LINE)] public static float2 LerpClamp(line2 range, float2 t) { return LerpClamp(range.From, range.To, t); }
        [IN(LINE)] public static float2 LerpRepeat(line2 range, float t) { return LerpRepeat(range.From, range.To, t); }
        [IN(LINE)] public static float2 LerpRepeat(line2 range, float2 t) { return LerpRepeat(range.From, range.To, t); }

        [IN(LINE)] public static float2 UnLerp(line2 range, float2 a) { return UnLerp(range.From, range.To, a); }
        [IN(LINE)] public static float2 UnLerpClamp(line2 range, float2 a) { return UnLerpClamp(range.From, range.To, a); }
        [IN(LINE)] public static float2 UnLerpRepeat(line2 range, float2 a) { return UnLerpRepeat(range.From, range.To, a); }

        [IN(LINE)] public static float2 Remap(line2 oldRange, line2 newRange, float v) { return Remap(oldRange.From, oldRange.To, newRange.From, newRange.To, v); }
        [IN(LINE)] public static float2 Remap(line2 oldRange, line2 newRange, float2 v) { return Remap(oldRange.From, oldRange.To, newRange.From, newRange.To, v); }

        [IN(LINE)] public static float2 LerpAngle(line2 range, float t) { return LerpAngle(range.From, range.To, t); }
        [IN(LINE)] public static float2 LerpAngleClamp(line2 range, float t) { return LerpAngleClamp(range.From, range.To, t); }
        [IN(LINE)] public static float2 LerpAngleRepeat(line2 range, float t) { return LerpAngleRepeat(range.From, range.To, t); }

        [IN(LINE)] public static float2 MoveTowards(line2 range, float distance) { return MoveTowards(range.From, range.To, distance); }
        [IN(LINE)] public static float2 MoveTowards(line2 range, float distance, out float excess) { return MoveTowards(range.From, range.To, distance, out excess); }

        [IN(LINE)] public static float2 MoveTowardsAngle(line2 range, float distance) { return MoveTowardsAngle(range.From, range.To, distance); }
        #endregion

        #region Real Value State Checks
        [IN(LINE)] public static bool2 IsNegative(line2 a) { return IsNegative(a.a); }
        [IN(LINE)] public static bool2 IsPositive(line2 a) { return IsPositive(a.a); }
        [IN(LINE)] public static bool2 IsFinite(line2 a) { return IsFinite(a.a); }
        [IN(LINE)] public static bool2 IsInfinity(line2 a) { return IsInfinity(a.a); }
        [IN(LINE)] public static bool2 IsNegativeInfinity(line2 a) { return IsNegativeInfinity(a.a); }
        [IN(LINE)] public static bool2 IsPositiveInfinity(line2 a) { return IsPositiveInfinity(a.a); }
        #endregion

        #region Space Converts
        [IN(LINE)] public static line2 GammaToLinearSpace(line2 a) { const float Gamma = 2.2f; return new line2(Pow(a.a, Gamma), Pow(a.b, Gamma)); }
        [IN(LINE)] public static line2 LinearToGammaSpace(line2 a) { const float InverseGamma = 1.0f / 2.2f; return new line2(Pow(a.a, InverseGamma), Pow(a.b, InverseGamma)); }
        [IN(LINE)] public static line2 Degrees(line2 radians) { return new line2(Degrees(radians.a), Degrees(radians.b)); }
        [IN(LINE)] public static line2 Radians(line2 degrees) { return new line2(Radians(degrees.a), Radians(degrees.b)); }
        #endregion

        #region Length/Distance/Normalize
        [IN(LINE)] public static float Length(line2 a) { return Length(a.dir); }
        [IN(LINE)] public static float LengthSq(line2 a) { return LengthSq(a.dir); }
        [IN(LINE)] public static line2 Normalize(line2 a) { return new line2(a.a, a.a + Normalize(a.dir)); }
        [IN(LINE)] public static line2 NormalizeSafe(line2 a, float2 defaultvalue = default) { return new line2(a.a, a.a + NormalizeSafe(a.dir, defaultvalue)); }
        [IN(LINE)] public static bool IsNormalized(line2 a) { return IsNormalized(a.dir); }
        #endregion

        #region Other
        [IN(LINE)] public static line2 Reverse(line2 a) { return new line2(a.b, a.a); }
        [IN(LINE)] public static float2 GetPoint(line2 line, float distance) { return line.a + line.dir * distance; }
        [IN(LINE)] public static bool Contains(line2 line, float2 point, float tolerance = 0.0001f) { return Contains(new ray2(line), point, tolerance); }
        [IN(LINE)] public static float2 ProjectPoint(line2 line, float2 point) { return line.a + Project(point - line.a, line.dir); }
        [IN(LINE)] public static line2 Expand(line2 line, float amount) { return new line2(Expand(new ray2(line), amount)); }
        #endregion
    }
}
