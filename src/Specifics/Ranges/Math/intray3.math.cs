#pragma warning disable CS8981
#if DISABLE_DEBUG
#undef DEBUG
#endif
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct intray3
    {
        #region Length/Normalized
        public int3 From { [IN(LINE)] get { return src; } [IN(LINE)] set { dir -= value - src; src = value; } }
        public int3 To { [IN(LINE)] get { return src + dir; } [IN(LINE)] set { dir -= (To - value); } }
        public int3 Min { [IN(LINE)] get { return DM.Min(this); } }
        public int3 Max { [IN(LINE)] get { return DM.Max(this); } }
        public float3 Center { [IN(LINE)] get { return (float3)src + (float3)dir * 0.5f; } }
        public float Length { [IN(LINE)] get { return DM.Length(this); } }
        public int LengthSq { [IN(LINE)] get { return DM.LengthSq(this); } }
        public ray3 Normalized { [IN(LINE)] get { return new ray3(src, DM.NormalizeSafe(dir)); } }
        #endregion
    }
    public static partial class DM // intray3
    {
        #region Abs
        [IN(LINE)] public static intray3 Abs(intray3 a) { return new intray3(a.src, Abs(a.dir)); }
        #endregion

        #region Min/Max
        [IN(LINE)] public static int3 Max(intray3 range) { return Select(range.src, range.src + range.dir, range.dir >= 0); }
        [IN(LINE)] public static int3 Min(intray3 range) { return Select(range.src + range.dir, range.src, range.dir >= 0); }
        #endregion

        #region Length/Distance/Normalize
        [IN(LINE)] public static float Length(intray3 a) { return Sqrt(LengthSq(a)); }
        [IN(LINE)] public static int LengthSq(intray3 a) { return LengthSq(a.dir); }
        #endregion

        #region Other
        [IN(LINE)] public static intray3 Reverse(intray3 a) { return new intray3(a.src + a.dir, -a.dir); }
        [IN(LINE)] public static float3 GetPoint(intray3 ray, float distance) { return (float3)ray.src + (float3)ray.dir * distance; }
        [IN(LINE)] public static float UnLerpProjected(intray3 ray, int3 point) { return UnLerpProjected(new ray3(ray), (float3)point); }
        [IN(LINE)] public static float UnLerpProjected(intray3 ray, float3 point) { return UnLerpProjected(new ray3(ray), point); }
        [IN(LINE)] public static float3 ClosestPoint(intray3 ray, int3 point) { return ClosestPoint(ray, (float3)point); }
        [IN(LINE)] public static float3 ClosestPoint(intray3 ray, float3 point)
        {
            int lengthSq = LengthSq(ray.dir);
            if (lengthSq <= 0) { return ray.src; }
            float3 src = ray.src;
            float3 dir = ray.dir;
            return src + Project(point - src, dir);
        }
        [IN(LINE)] public static float3 ClosestPointClamp(intray3 ray, int3 point) { return ClosestPointClamp(ray, (float3)point); }
        [IN(LINE)] public static float3 ClosestPointClamp(intray3 ray, float3 point)
        {
            int lengthSq = LengthSq(ray.dir);
            if (lengthSq <= 0) { return ray.src; }
            float3 src = ray.src;
            float3 dir = ray.dir;
            float t = Clamp01(Dot(point - src, dir) / lengthSq);
            return src + dir * t;
        }
        [IN(LINE)] public static bool ContainsProjected(intray3 ray, int3 point, float tolerance = 0.0001f) { return ContainsProjected(ray, (float3)point, tolerance); }
        [IN(LINE)] public static bool ContainsProjected(intray3 ray, float3 point, float tolerance = 0.0001f)
        {
            int lengthSq = LengthSq(ray.dir);
            if (lengthSq <= 0) { return LengthSq(point - (float3)ray.src) <= tolerance * tolerance; }
            float dot = Dot((float3)ray.dir, point - (float3)ray.src);
            return dot >= -tolerance && dot <= lengthSq + tolerance;
        }
        [IN(LINE)] public static bool ContainsProjected(intray3 a, intray3 b, float tolerance = 0.0001f) { return ContainsProjected(new ray3(a), new ray3(b), tolerance); }
        [IN(LINE)] public static bool OverlapsProjected(intray3 a, intray3 b, float tolerance = 0.0001f) { return OverlapsProjected(new ray3(a), new ray3(b), tolerance); }
        [IN(LINE)] public static ray3 Expand(intray3 ray, float amount) { return Expand(new ray3(ray), amount); }
        #endregion
    }
}
