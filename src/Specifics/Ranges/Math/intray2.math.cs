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
        public float2 Center { [IN(LINE)] get { return src + dir / new float2(2f); } }
        public float Length { [IN(LINE)] get { return DM.Length(this); } }
        public float LengthSqr { [IN(LINE)] get { return DM.LengthSqr(this); } }
        public ray2 Normalized { [IN(LINE)] get { return new ray2(src, DM.NormalizeSafe(dir)); } }
        #endregion
    }
    public static partial class DM // intray2
    {
        #region Abs
        [IN(LINE)] public static intray2 Abs(intray2 a) { return new intray2(a.src, Abs(a.dir)); }
        #endregion

        #region Clamp/Repeat/PingPong/SmoothStep
        /// <summary> Clamps the value between min and max. </summary>
        [IN(LINE)] public static int2 Clamp(int2 a, intray2 range) { return Clamp(a, range.From, range.To); }
        [IN(LINE)] public static int2 Repeat(int2 a, intray2 range) { return Repeat(a, range.From, range.To); }
        [IN(LINE)] public static int2 PingPong(int2 a, intray2 range) { return PingPong(a, range.From, range.To); }
        #endregion

        #region Min/Max
        [IN(LINE)] public static int2 Max(intray2 range) { return Select(range.src, range.src + range.dir, range.dir >= 0); }
        [IN(LINE)] public static int2 Min(intray2 range) { return Select(range.src + range.dir, range.src, range.dir >= 0); }
        #endregion

        #region Length/Distance/Normalize
        //Length - float
        [IN(LINE)] public static int LengthSqr(intray2 a) { return LengthSqr(a.dir); }
        #endregion

        #region Other
        [IN(LINE)] public static intray2 Reverse(intray2 a) { return new intray2(a.src + a.dir, -a.dir); }
        //GetPoint - float
        //Contains - float
        //ProjectPoint - float
        #endregion
    }
}