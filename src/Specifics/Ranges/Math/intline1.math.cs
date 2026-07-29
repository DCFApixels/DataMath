#pragma warning disable CS8981
#if DISABLE_DEBUG
#undef DEBUG
#endif
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct intline1
    {
        #region Length/Normalized
        public int From { [IN(LINE)] get { return a; } [IN(LINE)] set { a = value; } }
        public int To { [IN(LINE)] get { return b; } [IN(LINE)] set { b = value; } }
        public int Min { [IN(LINE)] get { return DM.Min(this); } }
        public int Max { [IN(LINE)] get { return DM.Max(this); } }
        public float Center { [IN(LINE)] get { return (a + b) * 0.5f; } }
        public float Length { [IN(LINE)] get { return DM.Length(this); } }
        public int LengthSq { [IN(LINE)] get { return DM.LengthSq(this); } }
        public line1 Normalized { [IN(LINE)] get { return new line1(a, a + DM.NormalizeSafe((float)dir)); } }
        #endregion
    }
    public static partial class DM // intline1
    {
        #region Abs
        [IN(LINE)] public static intline1 Abs(intline1 a) { return new intline1(a.a, a.a + Abs(a.dir)); }
        #endregion

        #region Clamp/Repeat/PingPong
        [IN(LINE)] public static int Clamp(int a, intline1 range) { return Clamp(a, range.Min, range.Max); }
        [IN(LINE)] public static int Repeat(int a, intline1 range) { return Repeat(a, range.From, range.To); }
        [IN(LINE)] public static int PingPong(int a, intline1 range) { return PingPong(a, range.From, range.To); }
        #endregion

        #region Min/Max
        [IN(LINE)] public static int Max(intline1 range) { return Max(range.a, range.b); }
        [IN(LINE)] public static int Min(intline1 range) { return Min(range.a, range.b); }
        #endregion

        #region Lerp
        [IN(LINE)] public static float Lerp(intline1 range, float t) { return range.From + (range.To - range.From) * t; }
        [IN(LINE)] public static float LerpClamp(intline1 range, float t) { return Lerp(range, Clamp01(t)); }
        [IN(LINE)] public static float LerpRepeat(intline1 range, float t) { return Lerp(range, Repeat01(t)); }

        [IN(LINE)] public static float UnLerp(intline1 range, int a) { return UnLerp(range, (float)a); }
        [IN(LINE)] public static float UnLerp(intline1 range, float a) { return (a - range.From) / (range.To - range.From); }
        [IN(LINE)] public static float UnLerpClamp(intline1 range, int a) { return Clamp01(UnLerp(range, a)); }
        [IN(LINE)] public static float UnLerpClamp(intline1 range, float a) { return Clamp01(UnLerp(range, a)); }
        [IN(LINE)] public static float UnLerpRepeat(intline1 range, int a) { return Repeat01(UnLerp(range, a)); }
        [IN(LINE)] public static float UnLerpRepeat(intline1 range, float a) { return Repeat01(UnLerp(range, a)); }

        [IN(LINE)] public static float Remap(intline1 oldRange, intline1 newRange, int v) { return Lerp(newRange, UnLerp(oldRange, v)); }
        [IN(LINE)] public static float Remap(intline1 oldRange, intline1 newRange, float v) { return Lerp(newRange, UnLerp(oldRange, v)); }
        #endregion

        #region Length/Distance/Normalize
        [IN(LINE)] public static float Length(intline1 a) { return Sqrt(LengthSq(a)); }
        [IN(LINE)] public static int LengthSq(intline1 a) { return LengthSq(a.dir); }
        [IN(LINE)] public static line1 Normalize(intline1 a) { return new line1(a.a, a.a + Normalize((float)a.dir)); }
        [IN(LINE)] public static line1 NormalizeSafe(intline1 a, float defaultvalue = 0f) { return new line1(a.a, a.a + NormalizeSafe((float)a.dir, defaultvalue)); }
        #endregion

        #region Other
        [IN(LINE)] public static intline1 Reverse(intline1 a) { return new intline1(a.b, a.a); }
        [IN(LINE)] public static float GetPoint(intline1 line, float distance) { return line.a + line.dir * distance; }
        [IN(LINE)] public static bool Contains(intline1 range, int a) { return a >= range.Min && a <= range.Max; }
        [IN(LINE)] public static bool Contains(intline1 range, float a, float tolerance = 0.0001f) { return a >= range.Min - tolerance && a <= range.Max + tolerance; }
        [IN(LINE)] public static bool Contains(intline1 range, intline1 other) { return other.Min >= range.Min && other.Max <= range.Max; }
        [IN(LINE)] public static line1 Expand(intline1 line, float amount) { return Expand(new ray1(line.a, line.dir), amount); }
        [IN(LINE)] public static bool Overlaps(intline1 a, intline1 b) { return a.Min <= b.Max && b.Min <= a.Max; }
        [IN(LINE)] public static intline1 Intersection(intline1 a, intline1 b) { return new intline1(Max(a.Min, b.Min), Min(a.Max, b.Max)); }
        [IN(LINE)] public static intline1 Union(intline1 a, intline1 b) { return new intline1(Min(a.Min, b.Min), Max(a.Max, b.Max)); }
        #endregion
    }
}
