#pragma warning disable CS8981
#if DISABLE_DEBUG
#undef DEBUG
#endif
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct line4
    {
        #region Length/Normalized
        public float4 From { [IN(LINE)] get { return a; } [IN(LINE)] set { a = value; } }
        public float4 To { [IN(LINE)] get { return b; } [IN(LINE)] set { b = value; } }
        public float4 Min { [IN(LINE)] get { return DM.Min(this); } }
        public float4 Max { [IN(LINE)] get { return DM.Max(this); } }
        public float4 Center { [IN(LINE)] get { return (a + b) * 0.5f; } }
        public float Length { [IN(LINE)] get { return DM.Length(this); } }
        public float LengthSq { [IN(LINE)] get { return DM.LengthSq(this); } }
        public line4 Normalized { [IN(LINE)] get { return new line4(a, a + DM.NormalizeSafe(dir)); } }
        #endregion
    }
    public static partial class DM // line4
    {
        #region Abs
        [IN(LINE)] public static line4 Abs(line4 a) { return new line4(a.a, a.a + Abs(a.dir)); }
        #endregion

        #region Clamp/Repeat/PingPong/SmoothStep
        [IN(LINE)] public static float4 Clamp(float4 a, line4 range) { return Clamp(a, range.From, range.To); }
        [IN(LINE)] public static float4 Repeat(float4 a, line4 range) { return Repeat(a, range.From, range.To); }
        [IN(LINE)] public static float4 PingPong(float4 a, line4 range) { return PingPong(a, range.From, range.To); }
        [IN(LINE)] public static float4 SmoothStep(line4 range, float4 a) { return SmoothStep(range.From, range.To, a); }
        #endregion

        #region Min/Max
        [IN(LINE)] public static float4 Max(line4 range) { return Max(range.a, range.b); }
        [IN(LINE)] public static float4 Min(line4 range) { return Min(range.a, range.b); }
        #endregion

        #region Lerp
        [IN(LINE)] public static float4 Lerp(line4 range, float t) { return Lerp(range.From, range.To, t); }
        [IN(LINE)] public static float4 Lerp(line4 range, float4 t) { return Lerp(range.From, range.To, t); }
        [IN(LINE)] public static float4 LerpClamp(line4 range, float t) { return LerpClamp(range.From, range.To, t); }
        [IN(LINE)] public static float4 LerpClamp(line4 range, float4 t) { return LerpClamp(range.From, range.To, t); }
        [IN(LINE)] public static float4 LerpRepeat(line4 range, float t) { return LerpRepeat(range.From, range.To, t); }
        [IN(LINE)] public static float4 LerpRepeat(line4 range, float4 t) { return LerpRepeat(range.From, range.To, t); }

        [IN(LINE)] public static float4 UnLerp(line4 range, float4 a) { return UnLerp(range.From, range.To, a); }
        [IN(LINE)] public static float4 UnLerpClamp(line4 range, float4 a) { return UnLerpClamp(range.From, range.To, a); }
        [IN(LINE)] public static float4 UnLerpRepeat(line4 range, float4 a) { return UnLerpRepeat(range.From, range.To, a); }

        [IN(LINE)] public static float4 Remap(line4 oldRange, line4 newRange, float v) { return Remap(oldRange.From, oldRange.To, newRange.From, newRange.To, v); }
        [IN(LINE)] public static float4 Remap(line4 oldRange, line4 newRange, float4 v) { return Remap(oldRange.From, oldRange.To, newRange.From, newRange.To, v); }

        [IN(LINE)] public static float4 LerpAngle(line4 range, float t) { return LerpAngle(range.From, range.To, t); }
        [IN(LINE)] public static float4 LerpAngleClamp(line4 range, float t) { return LerpAngleClamp(range.From, range.To, t); }
        [IN(LINE)] public static float4 LerpAngleRepeat(line4 range, float t) { return LerpAngleRepeat(range.From, range.To, t); }

        [IN(LINE)] public static float4 MoveTowards(line4 range, float distance) { return MoveTowards(range.From, range.To, distance); }
        [IN(LINE)] public static float4 MoveTowards(line4 range, float distance, out float excess) { return MoveTowards(range.From, range.To, distance, out excess); }

        [IN(LINE)] public static float4 MoveTowardsAngle(line4 range, float distance) { return MoveTowardsAngle(range.From, range.To, distance); }
        #endregion

        #region Real Value State Checks
        [IN(LINE)] public static bool4 IsNegative(line4 a) { return IsNegative(a.a); }
        [IN(LINE)] public static bool4 IsPositive(line4 a) { return IsPositive(a.a); }
        [IN(LINE)] public static bool4 IsFinite(line4 a) { return IsFinite(a.a); }
        [IN(LINE)] public static bool4 IsInfinity(line4 a) { return IsInfinity(a.a); }
        [IN(LINE)] public static bool4 IsNegativeInfinity(line4 a) { return IsNegativeInfinity(a.a); }
        [IN(LINE)] public static bool4 IsPositiveInfinity(line4 a) { return IsPositiveInfinity(a.a); }
        #endregion

        #region Space Converts
        [IN(LINE)] public static line4 GammaToLinearSpace(line4 a) { const float Gamma = 2.2f; return new line4(Pow(a.a, Gamma), Pow(a.b, Gamma)); }
        [IN(LINE)] public static line4 LinearToGammaSpace(line4 a) { const float InverseGamma = 1.0f / 2.2f; return new line4(Pow(a.a, InverseGamma), Pow(a.b, InverseGamma)); }
        [IN(LINE)] public static line4 Degrees(line4 radians) { return new line4(Degrees(radians.a), Degrees(radians.b)); }
        [IN(LINE)] public static line4 Radians(line4 degrees) { return new line4(Radians(degrees.a), Radians(degrees.b)); }
        #endregion

        #region Length/Distance/Normalize
        [IN(LINE)] public static float Length(line4 a) { return Length(a.dir); }
        [IN(LINE)] public static float LengthSq(line4 a) { return LengthSq(a.dir); }
        [IN(LINE)] public static line4 Normalize(line4 a) { return new line4(a.a, a.a + Normalize(a.dir)); }
        [IN(LINE)] public static line4 NormalizeSafe(line4 a, float4 defaultvalue = default) { return new line4(a.a, a.a + NormalizeSafe(a.dir, defaultvalue)); }
        [IN(LINE)] public static bool IsNormalized(line4 a) { return IsNormalized(a.dir); }
        #endregion

        #region Other
        [IN(LINE)] public static line4 Reverse(line4 a) { return new line4(a.b, a.a); }
        [IN(LINE)] public static float4 GetPoint(line4 line, float distance) { return line.a + line.dir * distance; }
        [IN(LINE)] public static bool Contains(line4 line, float4 point, float tolerance = 0.0001f) { return Contains(new ray4(line), point, tolerance); }
        [IN(LINE)] public static float4 ProjectPoint(line4 line, float4 point) { return line.a + Project(point - line.a, line.dir); }
        [IN(LINE)] public static line4 Expand(line4 line, float amount) { return new line4(Expand(new ray4(line), amount)); }
        #endregion
    }
}
