#pragma warning disable CS8981
#if DISABLE_DEBUG
#undef DEBUG
#endif
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct intline4
    {
        #region Length/Normalized
        public int4 From { [IN(LINE)] get { return a; } [IN(LINE)] set { a = value; } }
        public int4 To { [IN(LINE)] get { return b; } [IN(LINE)] set { b = value; } }
        public int4 Min { [IN(LINE)] get { return DM.Min(this); } }
        public int4 Max { [IN(LINE)] get { return DM.Max(this); } }
        public float4 Center { [IN(LINE)] get { return (float4)a + (float4)(b - a) * 0.5f; } }
        public float Length { [IN(LINE)] get { return DM.Length(this); } }
        public int LengthSq { [IN(LINE)] get { return DM.LengthSq(this); } }
        public line4 Normalized { [IN(LINE)] get { return new line4(a, (float4)a + DM.NormalizeSafe((float4)dir)); } }
        #endregion
    }
    public static partial class DM // intline4
    {
        #region Abs
        [IN(LINE)] public static intline4 Abs(intline4 a) { return new intline4(a.a, a.a + Abs(a.dir)); }
        #endregion

        #region Clamp/Repeat/PingPong
        [IN(LINE)] public static int4 Clamp(int4 a, intline4 range) { return Clamp(a, range.Min, range.Max); }
        [IN(LINE)] public static int4 Repeat(int4 a, intline4 range) { return Repeat(a, range.From, range.To); }
        [IN(LINE)] public static int4 PingPong(int4 a, intline4 range) { return PingPong(a, range.From, range.To); }
        #endregion

        #region Min/Max
        [IN(LINE)] public static int4 Max(intline4 range) { return Max(range.a, range.b); }
        [IN(LINE)] public static int4 Min(intline4 range) { return Min(range.a, range.b); }
        #endregion

        #region Lerp
        [IN(LINE)] public static float4 Lerp(intline4 range, float t) { return (float4)range.From + ((float4)range.To - (float4)range.From) * t; }
        [IN(LINE)] public static float4 Lerp(intline4 range, float4 t) { return (float4)range.From + ((float4)range.To - (float4)range.From) * t; }
        [IN(LINE)] public static float4 LerpClamp(intline4 range, float t) { return Lerp(range, Clamp01(t)); }
        [IN(LINE)] public static float4 LerpClamp(intline4 range, float4 t) { return Lerp(range, Clamp01(t)); }
        [IN(LINE)] public static float4 LerpRepeat(intline4 range, float t) { return Lerp(range, Repeat01(t)); }
        [IN(LINE)] public static float4 LerpRepeat(intline4 range, float4 t) { return Lerp(range, Repeat01(t)); }

        [IN(LINE)] public static float4 UnLerp(intline4 range, int4 a) { return UnLerp(range, (float4)a); }
        [IN(LINE)] public static float4 UnLerp(intline4 range, float4 a) { return (a - (float4)range.From) / ((float4)range.To - (float4)range.From); }
        [IN(LINE)] public static float4 UnLerpClamp(intline4 range, int4 a) { return Clamp01(UnLerp(range, a)); }
        [IN(LINE)] public static float4 UnLerpClamp(intline4 range, float4 a) { return Clamp01(UnLerp(range, a)); }
        [IN(LINE)] public static float4 UnLerpRepeat(intline4 range, int4 a) { return Repeat01(UnLerp(range, a)); }
        [IN(LINE)] public static float4 UnLerpRepeat(intline4 range, float4 a) { return Repeat01(UnLerp(range, a)); }

        [IN(LINE)] public static float4 Remap(intline4 oldRange, intline4 newRange, int4 v) { return Lerp(newRange, UnLerp(oldRange, v)); }
        [IN(LINE)] public static float4 Remap(intline4 oldRange, intline4 newRange, float4 v) { return Lerp(newRange, UnLerp(oldRange, v)); }
        #endregion

        #region Length/Distance/Normalize
        [IN(LINE)] public static float Length(intline4 a) { return Sqrt(LengthSq(a)); }
        [IN(LINE)] public static int LengthSq(intline4 a) { return LengthSq(a.dir); }
        [IN(LINE)] public static line4 Normalize(intline4 a) { return new line4(a.a, (float4)a.a + Normalize((float4)a.dir)); }
        [IN(LINE)] public static line4 NormalizeSafe(intline4 a, float4 defaultvalue = default) { return new line4(a.a, (float4)a.a + NormalizeSafe((float4)a.dir, defaultvalue)); }
        #endregion

        #region Other
        [IN(LINE)] public static intline4 Reverse(intline4 a) { return new intline4(a.b, a.a); }
        [IN(LINE)] public static float4 GetPoint(intline4 line, float distance) { return (float4)line.a + (float4)line.dir * distance; }
        [IN(LINE)] public static bool Contains(intline4 line, int4 point, float tolerance = 0.0001f) { return Contains(new ray4(line.a, line.dir), (float4)point, tolerance); }
        [IN(LINE)] public static bool Contains(intline4 line, float4 point, float tolerance = 0.0001f) { return Contains(new ray4(line.a, line.dir), point, tolerance); }
        [IN(LINE)] public static line4 Expand(intline4 line, float amount) { return new line4(Expand(new ray4(line.a, line.dir), amount)); }
        #endregion
    }
}
