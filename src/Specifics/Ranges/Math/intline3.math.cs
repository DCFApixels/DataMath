#pragma warning disable CS8981
#if DISABLE_DEBUG
#undef DEBUG
#endif
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct intline3
    {
        #region Length/Normalized
        public int3 From { [IN(LINE)] get { return a; } [IN(LINE)] set { a = value; } }
        public int3 To { [IN(LINE)] get { return b; } [IN(LINE)] set { b = value; } }
        public int3 Min { [IN(LINE)] get { return DM.Min(this); } }
        public int3 Max { [IN(LINE)] get { return DM.Max(this); } }
        public float3 Center { [IN(LINE)] get { return (float3)a + (float3)(b - a) * 0.5f; } }
        public float Length { [IN(LINE)] get { return DM.Length(this); } }
        public int LengthSq { [IN(LINE)] get { return DM.LengthSq(this); } }
        public line3 Normalized { [IN(LINE)] get { return new line3(a, (float3)a + DM.NormalizeSafe((float3)dir)); } }
        #endregion
    }
    public static partial class DM // intline3
    {
        #region Abs
        [IN(LINE)] public static intline3 Abs(intline3 a) { return new intline3(a.a, a.a + Abs(a.dir)); }
        #endregion

        #region Clamp/Repeat/PingPong
        [IN(LINE)] public static int3 Clamp(int3 a, intline3 range) { return Clamp(a, range.Min, range.Max); }
        [IN(LINE)] public static int3 Repeat(int3 a, intline3 range) { return Repeat(a, range.From, range.To); }
        [IN(LINE)] public static int3 PingPong(int3 a, intline3 range) { return PingPong(a, range.From, range.To); }
        #endregion

        #region Min/Max
        [IN(LINE)] public static int3 Max(intline3 range) { return Max(range.a, range.b); }
        [IN(LINE)] public static int3 Min(intline3 range) { return Min(range.a, range.b); }
        #endregion

        #region Lerp
        [IN(LINE)] public static float3 Lerp(intline3 range, float t) { return (float3)range.From + ((float3)range.To - (float3)range.From) * t; }
        [IN(LINE)] public static float3 Lerp(intline3 range, float3 t) { return (float3)range.From + ((float3)range.To - (float3)range.From) * t; }
        [IN(LINE)] public static float3 LerpClamp(intline3 range, float t) { return Lerp(range, Clamp01(t)); }
        [IN(LINE)] public static float3 LerpClamp(intline3 range, float3 t) { return Lerp(range, Clamp01(t)); }
        [IN(LINE)] public static float3 LerpRepeat(intline3 range, float t) { return Lerp(range, Repeat01(t)); }
        [IN(LINE)] public static float3 LerpRepeat(intline3 range, float3 t) { return Lerp(range, Repeat01(t)); }

        [IN(LINE)] public static float3 UnLerp(intline3 range, int3 a) { return UnLerp(range, (float3)a); }
        [IN(LINE)] public static float3 UnLerp(intline3 range, float3 a) { return (a - (float3)range.From) / ((float3)range.To - (float3)range.From); }
        [IN(LINE)] public static float3 UnLerpClamp(intline3 range, int3 a) { return Clamp01(UnLerp(range, a)); }
        [IN(LINE)] public static float3 UnLerpClamp(intline3 range, float3 a) { return Clamp01(UnLerp(range, a)); }
        [IN(LINE)] public static float3 UnLerpRepeat(intline3 range, int3 a) { return Repeat01(UnLerp(range, a)); }
        [IN(LINE)] public static float3 UnLerpRepeat(intline3 range, float3 a) { return Repeat01(UnLerp(range, a)); }

        [IN(LINE)] public static float3 Remap(intline3 oldRange, intline3 newRange, int3 v) { return Lerp(newRange, UnLerp(oldRange, v)); }
        [IN(LINE)] public static float3 Remap(intline3 oldRange, intline3 newRange, float3 v) { return Lerp(newRange, UnLerp(oldRange, v)); }
        #endregion

        #region Length/Distance/Normalize
        [IN(LINE)] public static float Length(intline3 a) { return Sqrt(LengthSq(a)); }
        [IN(LINE)] public static int LengthSq(intline3 a) { return LengthSq(a.dir); }
        [IN(LINE)] public static line3 Normalize(intline3 a) { return new line3(a.a, (float3)a.a + Normalize((float3)a.dir)); }
        [IN(LINE)] public static line3 NormalizeSafe(intline3 a, float3 defaultvalue = default) { return new line3(a.a, (float3)a.a + NormalizeSafe((float3)a.dir, defaultvalue)); }
        #endregion

        #region Other
        [IN(LINE)] public static intline3 Reverse(intline3 a) { return new intline3(a.b, a.a); }
        [IN(LINE)] public static float3 GetPoint(intline3 line, float distance) { return (float3)line.a + (float3)line.dir * distance; }
        [IN(LINE)] public static bool Contains(intline3 line, int3 point, float tolerance = 0.0001f) { return Contains(new ray3(line.a, line.dir), (float3)point, tolerance); }
        [IN(LINE)] public static bool Contains(intline3 line, float3 point, float tolerance = 0.0001f) { return Contains(new ray3(line.a, line.dir), point, tolerance); }
        [IN(LINE)] public static line3 Expand(intline3 line, float amount) { return new line3(Expand(new ray3(line.a, line.dir), amount)); }
        #endregion
    }
}
