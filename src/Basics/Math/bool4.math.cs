using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public static partial class DM // bool4
    {
        #region Hash
        [IN(LINE)] public unsafe static uint UHash(bool4 v) { return *(uint*)&v; }
        [IN(LINE)] public static int Hash(bool4 v) { return unchecked((int)UHash(v)); }
        #endregion

        #region All/Any
        [IN(LINE)] public static bool All(bool4 a) { return a.x && a.y && a.z && a.w; }
        [IN(LINE)] public static bool Any(bool4 a) { return a.x || a.y || a.z || a.w; }
        #endregion

        #region Min/Max/Sum
        [IN(LINE)] public static bool4 Max(bool4 a, bool4 b) { return a | b; }
        [IN(LINE)] public static bool4 AbsMax(bool4 a, bool4 b) { return a | b; }
        [IN(LINE)] public static bool4 Min(bool4 a, bool4 b) { return a & b; }
        [IN(LINE)] public static bool4 AbsMin(bool4 a, bool4 b) { return a & b; }
        [IN(LINE)] public static bool CMax(bool4 a) { return Any(a); }
        [IN(LINE)] public static bool CAbsMax(bool4 a) { return Any(a); }
        [IN(LINE)] public static bool CMin(bool4 a) { return All(a); }
        [IN(LINE)] public static bool CAbsMin(bool4 a) { return All(a); }
        [IN(LINE)] public static int CSum(bool4 a) { return CSum(a.x) + CSum(a.y) + CSum(a.z) + CSum(a.w); }
        #endregion
    }
    public static partial class DMBits // bool2
    {
        #region Bits
        [IN(LINE)]
        public static int BitMask(bool4 value)
        {
            int mask = 0;
            if (value.x) { mask |= 0x01; }
            if (value.y) { mask |= 0x02; }
            if (value.z) { mask |= 0x04; }
            if (value.w) { mask |= 0x08; }
            return mask;
        }
        #endregion
    }
}
