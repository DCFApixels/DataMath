#pragma warning disable CS8981
#if DISABLE_DEBUG
#undef DEBUG
#endif
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct intray2
    {
        #region Length/Normalized
        public int2 From { [IN(LINE)] get { return src; } [IN(LINE)] set { dir -= value - src; src = value; } }
        public int2 To { [IN(LINE)] get { return src + dir; } [IN(LINE)] set { dir -= (To - value); } }
        public int2 Min { [IN(LINE)] get { return DM.Min(this); } }
        public int2 Max { [IN(LINE)] get { return DM.Max(this); } }
        public float2 Center { [IN(LINE)] get { return (float2)src + (float2)dir * 0.5f; } }
        public float Length { [IN(LINE)] get { return DM.Length(this); } }
        public int LengthSq { [IN(LINE)] get { return DM.LengthSq(this); } }
        public ray2 Normalized { [IN(LINE)] get { return new ray2(src, DM.NormalizeSafe(dir)); } }
        #endregion
    }
    public static partial class DM // intray2
    {
        #region Abs
        [IN(LINE)] public static intray2 Abs(intray2 a) { return new intray2(a.src, Abs(a.dir)); }
        #endregion

        #region Min/Max
        [IN(LINE)] public static int2 Max(intray2 range) { return Select(range.src, range.src + range.dir, range.dir >= 0); }
        [IN(LINE)] public static int2 Min(intray2 range) { return Select(range.src + range.dir, range.src, range.dir >= 0); }
        #endregion

        #region Length/Distance/Normalize
        [IN(LINE)] public static float Length(intray2 a) { return Sqrt(LengthSq(a)); }
        [IN(LINE)] public static int LengthSq(intray2 a) { return LengthSq(a.dir); }
        #endregion

        #region Other
        [IN(LINE)] public static intray2 Reverse(intray2 a) { return new intray2(a.src + a.dir, -a.dir); }
        [IN(LINE)] public static float2 GetPoint(intray2 ray, float distance) { return (float2)ray.src + (float2)ray.dir * distance; }
        [IN(LINE)] public static float UnLerpProjected(intray2 ray, int2 point) { return UnLerpProjected(new ray2(ray), (float2)point); }
        [IN(LINE)] public static float UnLerpProjected(intray2 ray, float2 point) { return UnLerpProjected(new ray2(ray), point); }
        [IN(LINE)] public static float2 ClosestPoint(intray2 ray, int2 point) { return ClosestPoint(ray, (float2)point); }
        [IN(LINE)] public static float2 ClosestPoint(intray2 ray, float2 point)
        {
            int lengthSq = LengthSq(ray.dir);
            if (lengthSq <= 0) { return ray.src; }
            float2 src = ray.src;
            float2 dir = ray.dir;
            return src + Project(point - src, dir);
        }
        [IN(LINE)] public static float2 ClosestPointClamp(intray2 ray, int2 point) { return ClosestPointClamp(ray, (float2)point); }
        [IN(LINE)] public static float2 ClosestPointClamp(intray2 ray, float2 point)
        {
            int lengthSq = LengthSq(ray.dir);
            if (lengthSq <= 0) { return ray.src; }
            float2 src = ray.src;
            float2 dir = ray.dir;
            float t = Clamp01(Dot(point - src, dir) / lengthSq);
            return src + dir * t;
        }
        [IN(LINE)] public static bool ContainsProjected(intray2 ray, int2 point, float tolerance = 0.0001f) { return ContainsProjected(ray, (float2)point, tolerance); }
        [IN(LINE)] public static bool ContainsProjected(intray2 ray, float2 point, float tolerance = 0.0001f)
        {
            int lengthSq = LengthSq(ray.dir);
            if (lengthSq <= 0) { return LengthSq(point - (float2)ray.src) <= tolerance * tolerance; }
            float dot = Dot((float2)ray.dir, point - (float2)ray.src);
            return dot >= -tolerance && dot <= lengthSq + tolerance;
        }
        [IN(LINE)] public static bool ContainsProjected(intray2 a, intray2 b, float tolerance = 0.0001f) { return ContainsProjected(new ray2(a), new ray2(b), tolerance); }
        [IN(LINE)] public static bool OverlapsProjected(intray2 a, intray2 b, float tolerance = 0.0001f) { return OverlapsProjected(new ray2(a), new ray2(b), tolerance); }
        [IN(LINE)] public static ray2 Expand(intray2 ray, float amount) { return Expand(new ray2(ray), amount); }
        #endregion
    }
}
