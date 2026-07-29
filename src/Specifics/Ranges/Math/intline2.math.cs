#pragma warning disable CS8981
#if DISABLE_DEBUG
#undef DEBUG
#endif
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct intline2
    {
        #region Length/Normalized
        public int2 From { [IN(LINE)] get { return a; } [IN(LINE)] set { a = value; } }
        public int2 To { [IN(LINE)] get { return b; } [IN(LINE)] set { b = value; } }
        public int2 Min { [IN(LINE)] get { return DM.Min(this); } }
        public int2 Max { [IN(LINE)] get { return DM.Max(this); } }
        public float2 Center { [IN(LINE)] get { return (float2)a + (float2)(b - a) * 0.5f; } }
        public float Length { [IN(LINE)] get { return DM.Length(this); } }
        public int LengthSq { [IN(LINE)] get { return DM.LengthSq(this); } }
        public line2 Normalized { [IN(LINE)] get { return new line2(a, (float2)a + DM.NormalizeSafe((float2)dir)); } }
        #endregion
    }
    public static partial class DM // intline2
    {
        #region Abs
        [IN(LINE)] public static intline2 Abs(intline2 a) { return new intline2(a.a, a.a + Abs(a.dir)); }
        #endregion

        #region Clamp/Repeat/PingPong
        [IN(LINE)] public static int2 Clamp(int2 a, intline2 range) { return Clamp(a, range.Min, range.Max); }
        [IN(LINE)] public static int2 Repeat(int2 a, intline2 range) { return Repeat(a, range.From, range.To); }
        [IN(LINE)] public static int2 PingPong(int2 a, intline2 range) { return PingPong(a, range.From, range.To); }
        #endregion

        #region Min/Max
        [IN(LINE)] public static int2 Max(intline2 range) { return Max(range.a, range.b); }
        [IN(LINE)] public static int2 Min(intline2 range) { return Min(range.a, range.b); }
        #endregion

        #region Lerp
        [IN(LINE)] public static float2 Lerp(intline2 range, float t) { return (float2)range.From + ((float2)range.To - (float2)range.From) * t; }
        [IN(LINE)] public static float2 Lerp(intline2 range, float2 t) { return (float2)range.From + ((float2)range.To - (float2)range.From) * t; }
        [IN(LINE)] public static float2 LerpClamp(intline2 range, float t) { return Lerp(range, Clamp01(t)); }
        [IN(LINE)] public static float2 LerpClamp(intline2 range, float2 t) { return Lerp(range, Clamp01(t)); }
        [IN(LINE)] public static float2 LerpRepeat(intline2 range, float t) { return Lerp(range, Repeat01(t)); }
        [IN(LINE)] public static float2 LerpRepeat(intline2 range, float2 t) { return Lerp(range, Repeat01(t)); }

        [IN(LINE)] public static float2 UnLerp(intline2 range, int2 a) { return UnLerp(range, (float2)a); }
        [IN(LINE)] public static float2 UnLerp(intline2 range, float2 a) { return (a - (float2)range.From) / ((float2)range.To - (float2)range.From); }
        [IN(LINE)] public static float2 UnLerpClamp(intline2 range, int2 a) { return Clamp01(UnLerp(range, a)); }
        [IN(LINE)] public static float2 UnLerpClamp(intline2 range, float2 a) { return Clamp01(UnLerp(range, a)); }
        [IN(LINE)] public static float2 UnLerpRepeat(intline2 range, int2 a) { return Repeat01(UnLerp(range, a)); }
        [IN(LINE)] public static float2 UnLerpRepeat(intline2 range, float2 a) { return Repeat01(UnLerp(range, a)); }

        [IN(LINE)] public static float2 Remap(intline2 oldRange, intline2 newRange, int2 v) { return Lerp(newRange, UnLerp(oldRange, v)); }
        [IN(LINE)] public static float2 Remap(intline2 oldRange, intline2 newRange, float2 v) { return Lerp(newRange, UnLerp(oldRange, v)); }
        #endregion

        #region Length/Distance/Normalize
        [IN(LINE)] public static float Length(intline2 a) { return Sqrt(LengthSq(a)); }
        [IN(LINE)] public static int LengthSq(intline2 a) { return LengthSq(a.dir); }
        [IN(LINE)] public static line2 Normalize(intline2 a) { return new line2(a.a, (float2)a.a + Normalize((float2)a.dir)); }
        [IN(LINE)] public static line2 NormalizeSafe(intline2 a, float2 defaultvalue = default) { return new line2(a.a, (float2)a.a + NormalizeSafe((float2)a.dir, defaultvalue)); }
        #endregion

        #region Other
        [IN(LINE)] public static intline2 Reverse(intline2 a) { return new intline2(a.b, a.a); }
        [IN(LINE)] public static float2 GetPoint(intline2 line, float distance) { return (float2)line.a + (float2)line.dir * distance; }
        [IN(LINE)] public static bool Contains(intline2 line, int2 point, float tolerance = 0.0001f) { return Contains(new ray2(line.a, line.dir), (float2)point, tolerance); }
        [IN(LINE)] public static bool Contains(intline2 line, float2 point, float tolerance = 0.0001f) { return Contains(new ray2(line.a, line.dir), point, tolerance); }
        [IN(LINE)] public static line2 Expand(intline2 line, float amount) { return new line2(Expand(new ray2(line.a, line.dir), amount)); }
        #endregion
    }
}
