#pragma warning disable CS8981
#if DISABLE_DEBUG
#undef DEBUG
#endif
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct intray1
    {
        #region Length/Normalized
        public int From { [IN(LINE)] get { return src; } [IN(LINE)] set { dir -= value - src; src = value; } }
        public int To { [IN(LINE)] get { return src + dir; } [IN(LINE)] set { dir -= (To - value); } }
        public int Min { [IN(LINE)] get { return DM.Min(this); } }
        public int Max { [IN(LINE)] get { return DM.Max(this); } }
        public float Center { [IN(LINE)] get { return src + dir / 2f; } }
        public float Length { [IN(LINE)] get { return DM.Length(this); } }
        public int LengthSq { [IN(LINE)] get { return DM.LengthSq(this); } }
        public ray1 Normalized { [IN(LINE)] get { return new ray1(src, DM.NormalizeSafe(dir)); } }
        #endregion
    }
    public static partial class DM  // intray1
    {
        #region Abs
        [IN(LINE)] public static intray1 Abs(intray1 a) { return new intray1(a.src, Abs(a.dir)); }
        #endregion

        #region Min/Max
        [IN(LINE)] public static int Max(intray1 range) { return (range.dir >= 0) ? range.src + range.dir : range.src; }
        [IN(LINE)] public static int Min(intray1 range) { return (range.dir >= 0) ? range.src : range.src + range.dir; }
        #endregion

        #region Length/Distance/Normalize
        [IN(LINE)] public static float Length(intray1 a) { return Sqrt(LengthSq(a)); }
        [IN(LINE)] public static int LengthSq(intray1 a) { return LengthSq(a.dir); }
        #endregion

        #region Other
        [IN(LINE)] public static intray1 Reverse(intray1 a) { return new intray1(a.src + a.dir, -a.dir); }
        [IN(LINE)] public static int GetPoint(intray1 ray, int distance) { return ray.src + ray.dir * distance; }
        [IN(LINE)] public static bool Contains(intray1 range, int a) { return a >= range.Min && a <= range.Max; }
        [IN(LINE)] public static int ProjectPoint(intray1 ray, int point) { return point; }
        [IN(LINE)] public static float UnLerpProjected(intray1 ray, int point) { return UnLerpProjected(new ray1(ray), point); }
        [IN(LINE)] public static float UnLerpProjected(intray1 ray, float point) { return UnLerpProjected(new ray1(ray), point); }
        [IN(LINE)] public static float ClosestPoint(intray1 ray, int point) { return ClosestPoint(ray, (float)point); }
        [IN(LINE)] public static float ClosestPoint(intray1 ray, float point) { return ray.dir == 0 ? ray.src : point; }
        [IN(LINE)] public static float ClosestPointClamp(intray1 ray, int point) { return ClosestPointClamp(ray, (float)point); }
        [IN(LINE)] public static float ClosestPointClamp(intray1 ray, float point) { return Clamp(point, ray.Min, ray.Max); }
        [IN(LINE)] public static bool ContainsProjected(intray1 ray, int point) { return ContainsProjected(ray, (float)point); }
        [IN(LINE)] public static bool ContainsProjected(intray1 ray, float point, float tolerance = 0.0001f) { return point >= ray.Min - tolerance && point <= ray.Max + tolerance; }
        [IN(LINE)] public static bool ContainsProjected(intray1 a, intray1 b, float tolerance = 0.0001f) { return ContainsProjected(new ray1(a), new ray1(b), tolerance); }
        [IN(LINE)] public static bool OverlapsProjected(intray1 a, intray1 b, float tolerance = 0.0001f) { return OverlapsProjected(new ray1(a), new ray1(b), tolerance); }
        [IN(LINE)] public static ray1 Expand(intray1 ray, float amount) { return Expand(new ray1(ray), amount); }
        #endregion
    }
}
