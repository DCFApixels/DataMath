#pragma warning disable CS8981
#if DISABLE_DEBUG
#undef DEBUG
#endif
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct intray4
    {
        #region Length/Normalized
        public int4 From { [IN(LINE)] get { return src; } [IN(LINE)] set { dir -= value - src; src = value; } }
        public int4 To { [IN(LINE)] get { return src + dir; } [IN(LINE)] set { dir -= (To - value); } }
        public int4 Min { [IN(LINE)] get { return DM.Min(this); } }
        public int4 Max { [IN(LINE)] get { return DM.Max(this); } }
        public float4 Center { [IN(LINE)] get { return (float4)src + (float4)dir * 0.5f; } }
        public float Length { [IN(LINE)] get { return DM.Length(this); } }
        public int LengthSq { [IN(LINE)] get { return DM.LengthSq(this); } }
        public ray4 Normalized { [IN(LINE)] get { return new ray4(src, DM.NormalizeSafe(dir)); } }
        #endregion
    }
    public static partial class DM // intray4
    {
        #region Abs
        [IN(LINE)] public static intray4 Abs(intray4 a) { return new intray4(a.src, Abs(a.dir)); }
        #endregion

        #region Min/Max
        [IN(LINE)] public static int4 Max(intray4 range) { return Select(range.src, range.src + range.dir, range.dir >= 0); }
        [IN(LINE)] public static int4 Min(intray4 range) { return Select(range.src + range.dir, range.src, range.dir >= 0); }
        #endregion

        #region Length/Distance/Normalize
        [IN(LINE)] public static float Length(intray4 a) { return Sqrt(LengthSq(a)); }
        [IN(LINE)] public static int LengthSq(intray4 a) { return LengthSq(a.dir); }
        #endregion

        #region Other
        [IN(LINE)] public static intray4 Reverse(intray4 a) { return new intray4(a.src + a.dir, -a.dir); }
        [IN(LINE)] public static float4 GetPoint(intray4 ray, float distance) { return (float4)ray.src + (float4)ray.dir * distance; }
        [IN(LINE)] public static float UnLerpProjected(intray4 ray, int4 point) { return UnLerpProjected(new ray4(ray), (float4)point); }
        [IN(LINE)] public static float UnLerpProjected(intray4 ray, float4 point) { return UnLerpProjected(new ray4(ray), point); }
        [IN(LINE)] public static float4 ClosestPoint(intray4 ray, int4 point) { return ClosestPoint(ray, (float4)point); }
        [IN(LINE)] public static float4 ClosestPoint(intray4 ray, float4 point)
        {
            int lengthSq = LengthSq(ray.dir);
            if (lengthSq <= 0) { return ray.src; }
            float4 src = ray.src;
            float4 dir = ray.dir;
            return src + Project(point - src, dir);
        }
        [IN(LINE)] public static float4 ClosestPointClamp(intray4 ray, int4 point) { return ClosestPointClamp(ray, (float4)point); }
        [IN(LINE)] public static float4 ClosestPointClamp(intray4 ray, float4 point)
        {
            int lengthSq = LengthSq(ray.dir);
            if (lengthSq <= 0) { return ray.src; }
            float4 src = ray.src;
            float4 dir = ray.dir;
            float t = Clamp01(Dot(point - src, dir) / lengthSq);
            return src + dir * t;
        }
        [IN(LINE)] public static bool ContainsProjected(intray4 ray, int4 point, float tolerance = 0.0001f) { return ContainsProjected(ray, (float4)point, tolerance); }
        [IN(LINE)] public static bool ContainsProjected(intray4 ray, float4 point, float tolerance = 0.0001f)
        {
            int lengthSq = LengthSq(ray.dir);
            if (lengthSq <= 0) { return LengthSq(point - (float4)ray.src) <= tolerance * tolerance; }
            float dot = Dot((float4)ray.dir, point - (float4)ray.src);
            return dot >= -tolerance && dot <= lengthSq + tolerance;
        }
        [IN(LINE)] public static bool ContainsProjected(intray4 a, intray4 b, float tolerance = 0.0001f) { return ContainsProjected(new ray4(a), new ray4(b), tolerance); }
        [IN(LINE)] public static bool OverlapsProjected(intray4 a, intray4 b, float tolerance = 0.0001f) { return OverlapsProjected(new ray4(a), new ray4(b), tolerance); }
        [IN(LINE)] public static ray4 Expand(intray4 ray, float amount) { return Expand(new ray4(ray), amount); }
        #endregion
    }
}
