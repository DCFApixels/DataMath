#pragma warning disable CS8981
#if DISABLE_DEBUG
#undef DEBUG
#endif
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct line1
    {
        #region Length/Normalized
        public float From { [IN(LINE)] get { return a; } [IN(LINE)] set { a = value; } }
        public float To { [IN(LINE)] get { return b; } [IN(LINE)] set { b = value; } }
        public float Min { [IN(LINE)] get { return DM.Min(this); } }
        public float Max { [IN(LINE)] get { return DM.Max(this); } }
        public float Center { [IN(LINE)] get { return (a + b) * 0.5f; } }
        public float Length { [IN(LINE)] get { return DM.Length(this); } }
        public float LengthSq { [IN(LINE)] get { return DM.LengthSq(this); } }
        public line1 Normalized { [IN(LINE)] get { return new line1(a, a + DM.NormalizeSafe(dir)); } }
        #endregion
    }
    public static partial class DM // line1
    {
        #region Abs
        [IN(LINE)] public static line1 Abs(line1 a) { return new line1(a.a, a.a + Abs(a.dir)); }
        #endregion

        #region Clamp/Repeat/PingPong/SmoothStep
        [IN(LINE)] public static float Clamp(float a, line1 range) { return Clamp(a, range.From, range.To); }
        [IN(LINE)] public static float Repeat(float a, line1 range) { return Repeat(a, range.From, range.To); }
        [IN(LINE)] public static float PingPong(float a, line1 range) { return PingPong(a, range.From, range.To); }
        [IN(LINE)] public static float SmoothStep(line1 range, float a) { return SmoothStep(range.From, range.To, a); }
        #endregion

        #region Min/Max
        [IN(LINE)] public static float Max(line1 range) { return Max(range.a, range.b); }
        [IN(LINE)] public static float Min(line1 range) { return Min(range.a, range.b); }
        #endregion

        #region Lerp
        [IN(LINE)] public static float Lerp(line1 range, float t) { return Lerp(range.From, range.To, t); }
        [IN(LINE)] public static float LerpClamp(line1 range, float t) { return LerpClamp(range.From, range.To, t); }
        [IN(LINE)] public static float LerpRepeat(line1 range, float t) { return LerpRepeat(range.From, range.To, t); }

        [IN(LINE)] public static float UnLerp(line1 range, float a) { return UnLerp(range.From, range.To, a); }
        [IN(LINE)] public static float UnLerpClamp(line1 range, float a) { return UnLerpClamp(range.From, range.To, a); }
        [IN(LINE)] public static float UnLerpRepeat(line1 range, float a) { return UnLerpRepeat(range.From, range.To, a); }

        [IN(LINE)] public static float Remap(line1 oldRange, line1 newRange, float v) { return Remap(oldRange.From, oldRange.To, newRange.From, newRange.To, v); }

        [IN(LINE)] public static float LerpAngle(line1 range, float t) { return LerpAngle(range.From, range.To, t); }
        [IN(LINE)] public static float LerpAngleClamp(line1 range, float t) { return LerpAngleClamp(range.From, range.To, t); }
        [IN(LINE)] public static float LerpAngleRepeat(line1 range, float t) { return LerpAngleRepeat(range.From, range.To, t); }

        [IN(LINE)] public static float MoveTowards(line1 range, float distance) { return MoveTowards(range.From, range.To, distance); }
        [IN(LINE)] public static float MoveTowards(line1 range, float distance, out float excess) { return MoveTowards(range.From, range.To, distance, out excess); }

        [IN(LINE)] public static float MoveTowardsAngle(line1 range, float distance) { return MoveTowardsAngle(range.From, range.To, distance); }
        #endregion

        #region Real Value State Checks
        [IN(LINE)] public static bool IsNegative(line1 a) { return IsNegative(a.a); }
        [IN(LINE)] public static bool IsPositive(line1 a) { return IsPositive(a.a); }
        [IN(LINE)] public static bool IsFinite(line1 a) { return IsFinite(a.a); }
        [IN(LINE)] public static bool IsInfinity(line1 a) { return IsInfinity(a.a); }
        [IN(LINE)] public static bool IsNegativeInfinity(line1 a) { return IsNegativeInfinity(a.a); }
        [IN(LINE)] public static bool IsPositiveInfinity(line1 a) { return IsPositiveInfinity(a.a); }
        #endregion

        #region Space Converts
        [IN(LINE)] public static line1 GammaToLinearSpace(line1 a) { const float Gamma = 2.2f; return new line1(Pow(a.a, Gamma), Pow(a.b, Gamma)); }
        [IN(LINE)] public static line1 LinearToGammaSpace(line1 a) { const float InverseGamma = 1.0f / 2.2f; return new line1(Pow(a.a, InverseGamma), Pow(a.b, InverseGamma)); }
        [IN(LINE)] public static line1 Degrees(line1 radians) { return new line1(Degrees(radians.a), Degrees(radians.b)); }
        [IN(LINE)] public static line1 Radians(line1 degrees) { return new line1(Radians(degrees.a), Radians(degrees.b)); }
        #endregion

        #region Length/Distance/Normalize
        [IN(LINE)] public static float Length(line1 a) { return Length(a.dir); }
        [IN(LINE)] public static float LengthSq(line1 a) { return LengthSq(a.dir); }
        [IN(LINE)] public static line1 Normalize(line1 a) { return new line1(a.a, a.a + Normalize(a.dir)); }
        [IN(LINE)] public static line1 NormalizeSafe(line1 a, float defaultvalue = 0f) { return new line1(a.a, a.a + NormalizeSafe(a.dir, defaultvalue)); }
        [IN(LINE)] public static bool IsNormalized(line1 a) { return IsNormalized(a.dir); }
        #endregion

        #region Other
        [IN(LINE)] public static line1 Reverse(line1 a) { return new line1(a.b, a.a); }
        [IN(LINE)] public static float GetPoint(line1 line, float distance) { return line.a + line.dir * distance; }
        [IN(LINE)] public static bool Contains(line1 range, float a, float tolerance = 0.0001f) { return a >= range.Min - tolerance && a <= range.Max + tolerance; }
        [IN(LINE)] public static bool Contains(line1 range, line1 other, float tolerance = 0.0001f) { return other.Min >= range.Min - tolerance && other.Max <= range.Max + tolerance; }
        [IN(LINE)] public static float ProjectPoint(line1 line, float point) { return point; }
        [IN(LINE)] public static line1 Expand(line1 line, float amount) { return new line1(Expand(new ray1(line), amount)); }
        [IN(LINE)] public static bool Overlaps(line1 a, line1 b, float tolerance = 0.0001f) { return a.Min <= b.Max + tolerance && b.Min <= a.Max + tolerance; }
        [IN(LINE)] public static line1 Intersection(line1 a, line1 b) { return new line1(Max(a.Min, b.Min), Min(a.Max, b.Max)); }
        [IN(LINE)] public static line1 Union(line1 a, line1 b) { return new line1(Min(a.Min, b.Min), Max(a.Max, b.Max)); }
        #endregion
    }
}
