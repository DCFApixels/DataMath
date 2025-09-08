#pragma warning disable CS8981
#if DISABLE_DEBUG
#undef DEBUG
#endif
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public static partial class DM // bool2
    {
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

        #region Other
        [IN(LINE)] public static bool2 Select(bool2 falseValue, bool2 trueValue, bool2 test) { return test ? trueValue : falseValue; }
        #endregion


        #region Hash
        [IN(LINE)] public unsafe static uint UHash(bool2 v) { return *(uint*)&v & 0x0000_FFFF; }
        [IN(LINE)] public static int Hash(bool2 v) { return unchecked((int)UHash(v)); }
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