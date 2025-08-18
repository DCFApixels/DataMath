using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public static partial class DM // bool2
    {
        #region Hash
        [IN(LINE)] public unsafe static uint UHash(bool2 v) { return *(uint*)&v & 0x0000_FFFF; }
        [IN(LINE)] public static int Hash(bool2 v) { return unchecked((int)UHash(v)); }
        #endregion

        #region All/Any
        [IN(LINE)] public static bool All(bool2 a) { return a.x && a.y; }
        [IN(LINE)] public static bool Any(bool2 a) { return a.x || a.y; }
        #endregion

        #region Min/Max/Sum
        [IN(LINE)] public static bool2 Max(bool2 a, bool2 b) { return a | b; }
        [IN(LINE)] public static bool2 AbsMax(bool2 a, bool2 b) { return a | b; }
        [IN(LINE)] public static bool2 Min(bool2 a, bool2 b) { return a & b; }
        [IN(LINE)] public static bool2 AbsMin(bool2 a, bool2 b) { return a & b; }
        [IN(LINE)] public static bool CMax(bool2 a) { return Any(a); }
        [IN(LINE)] public static bool CAbsMax(bool2 a) { return Any(a); }
        [IN(LINE)] public static bool CMin(bool2 a) { return All(a); }
        [IN(LINE)] public static bool CAbsMin(bool2 a) { return All(a); }
        [IN(LINE)] public static int CSum(bool2 a) { return CSum(a.x) + CSum(a.y); }
        #endregion
    }
    public static partial class DMBits // bool2
    {
        #region Bits
        [IN(LINE)]
        public static int BitMask(bool2 value)
        {
            int mask = 0;
            if (value.x) { mask |= 0x01; }
            if (value.y) { mask |= 0x02; }
            return mask;
        }
        #endregion
    }
}