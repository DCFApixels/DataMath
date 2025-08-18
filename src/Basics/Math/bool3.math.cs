#if DISABLE_DEBUG
#undef DEBUG
#endif
using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public static partial class DM // bool3
    {
        #region All/Any
        [IN(LINE)] public static bool All(bool3 a) { return a.x && a.y && a.z; }
        [IN(LINE)] public static bool Any(bool3 a) { return a.x || a.y || a.z; }
        #endregion

        #region Min/Max/Sum
        [IN(LINE)] public static bool3 Max(bool3 a, bool3 b) { return a | b; }
        [IN(LINE)] public static bool3 AbsMax(bool3 a, bool3 b) { return a | b; }
        [IN(LINE)] public static bool3 Min(bool3 a, bool3 b) { return a & b; }
        [IN(LINE)] public static bool3 AbsMin(bool3 a, bool3 b) { return a & b; }
        [IN(LINE)] public static bool CMax(bool3 a) { return Any(a); }
        [IN(LINE)] public static bool CAbsMax(bool3 a) { return Any(a); }
        [IN(LINE)] public static bool CMin(bool3 a) { return All(a); }
        [IN(LINE)] public static bool CAbsMin(bool3 a) { return All(a); }
        [IN(LINE)] public static int CSum(bool3 a) { return CSum(a.x) + CSum(a.y) + CSum(a.z); }
        #endregion


        #region Hash
        [IN(LINE)] public unsafe static uint UHash(bool3 v) { return (*(uint*)&v) & 0x00FF_FFFF; }
        [IN(LINE)] public static int Hash(bool3 v) { return unchecked((int)UHash(v)); }
        #endregion
    }
    public static partial class DMBits // bool3
    {
        #region Bits
        [IN(LINE)]
        public static int BitMask(bool3 value)
        {
            int mask = 0;
            if (value.x) { mask |= 0x01; }
            if (value.y) { mask |= 0x02; }
            if (value.z) { mask |= 0x04; }
            return mask;
        }
        #endregion
    }
}
