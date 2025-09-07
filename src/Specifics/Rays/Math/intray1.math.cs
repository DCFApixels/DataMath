#if DISABLE_DEBUG
#undef DEBUG
#endif
using System.Numerics;
using System.Reflection;
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
        public int LengthSqr { [IN(LINE)] get { return DM.LengthSqr(this); } }
        public ray1 Normalized { [IN(LINE)] get { return new ray1(src, DM.NormalizeSafe(dir)); } }
        #endregion
    }
    public static partial class DM  // intray1
    {
        #region Abs
        [IN(LINE)] public static intray1 Abs(intray1 a) { return new intray1(a.src, Abs(a.dir)); }
        #endregion

        #region Clamp/Repeat/PingPong/SmoothStep
        /// <summary> Clamps the value between min and max. </summary>
        [IN(LINE)] public static int Clamp(int a, intray1 range) { return Clamp(a, range.From, range.To); }
        [IN(LINE)] public static int Repeat(int a, intray1 range) { return Repeat(a, range.From, range.To); }
        [IN(LINE)] public static int PingPong(int a, intray1 range) { return PingPong(a, range.From, range.To); }
        #endregion

        #region Min/Max
        [IN(LINE)] public static int Max(intray1 range) { return (range.dir >= 0) ? range.src + range.dir : range.src; }
        [IN(LINE)] public static int Min(intray1 range) { return (range.dir >= 0) ? range.src : range.src + range.dir; }
        #endregion

        #region Length/Distance/Normalize
        //Length - float
        [IN(LINE)] public static int LengthSqr(intray1 a) { return LengthSqr(a.dir); }
        #endregion

        #region Other
        [IN(LINE)] public static intray1 Reverse(intray1 a) { return new intray1(a.src + a.dir, -a.dir); }
        [IN(LINE)] public static int GetPoint(intray1 ray, int distance) { return ray.src + ray.dir * distance; }
        [IN(LINE)] public static bool Contains(intray1 range, int a) { return a >= range.Min && a <= range.Max; }
        [IN(LINE)] public static int ProjectPoint(intray1 ray, int point) { return point; }
        #endregion
    }
}