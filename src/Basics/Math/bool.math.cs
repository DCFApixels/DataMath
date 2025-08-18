using DCFApixels.DataMath.Internal;
using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public static partial class DM // bool
    {
        #region Hash
        [IN(LINE)] public unsafe static uint UHash(bool v) { return *(uint*)&v & 0x0000_00FF; }
        [IN(LINE)] public static int Hash(bool v) { return unchecked((int)UHash(v)); }
        #endregion

        #region All/Any
        [IN(LINE)] public static bool All(bool a) { return a; }
        [IN(LINE)] public static bool Any(bool a) { return a; }
        #endregion

        #region Min/Max/Sum
        [IN(LINE)] public static bool Max(bool a, bool b) { return a | b; }
        [IN(LINE)] public static bool AbsMax(bool a, bool b) { return a | b; }
        [IN(LINE)] public static bool Min(bool a, bool b) { return a & b; }
        [IN(LINE)] public static bool AbsMin(bool a, bool b) { return a & b; }
        [IN(LINE)] public static bool CMax(bool a) { return a; }
        [IN(LINE)] public static bool CAbsMax(bool a) { return a; }
        [IN(LINE)] public static bool CMin(bool a) { return a; }
        [IN(LINE)] public static bool CAbsMin(bool a) { return a; }
        [IN(LINE)] public static int CSum(bool a) { return a ? 1 : 0; }
        #endregion


        #region Component iteration operations
        [IN(LINE)] public static bool CMax(bool a, bool b) { return Max(a, b); }
        [IN(LINE)] public static bool CMax(bool a, bool b, bool c) { return Max(Max(a, b), c); }
        [IN(LINE)] public static bool CMax(bool a, bool b, bool c, bool d) { return Max(Max(a, b), Max(c, d)); }
        [IN(LINE)] public static bool CMax(bool a, bool b, bool c, bool d, bool e) { return Max(CMax(a, b, c, d), e); }
        [IN(LINE)] public static bool CMax(bool a, bool b, bool c, bool d, bool e, bool f) { return Max(CMax(a, b, c, d), Max(e, f)); }
        [IN(LINE)] public static bool CMax(bool a, bool b, bool c, bool d, bool e, bool f, bool g) { return Max(CMax(a, b, c, d), Max(Max(a, b), c)); }
        [IN(LINE)] public static bool CMax(bool a, bool b, bool c, bool d, bool e, bool f, bool g, bool h) { return Max(CMax(a, b, c, d), CMax(e, f, g, h)); }

        [IN(LINE)] public static bool CAbsMax(bool a, bool b) { return AbsMax(a, b); }
        [IN(LINE)] public static bool CAbsMax(bool a, bool b, bool c) { return AbsMax(AbsMax(a, b), c); }
        [IN(LINE)] public static bool CAbsMax(bool a, bool b, bool c, bool d) { return AbsMax(AbsMax(a, b), AbsMax(c, d)); }
        [IN(LINE)] public static bool CAbsMax(bool a, bool b, bool c, bool d, bool e) { return AbsMax(CAbsMax(a, b, c, d), e); }
        [IN(LINE)] public static bool CAbsMax(bool a, bool b, bool c, bool d, bool e, bool f) { return AbsMax(CAbsMax(a, b, c, d), AbsMax(e, f)); }
        [IN(LINE)] public static bool CAbsMax(bool a, bool b, bool c, bool d, bool e, bool f, bool g) { return AbsMax(CAbsMax(a, b, c, d), AbsMax(AbsMax(a, b), c)); }
        [IN(LINE)] public static bool CAbsMax(bool a, bool b, bool c, bool d, bool e, bool f, bool g, bool h) { return AbsMax(CAbsMax(a, b, c, d), CAbsMax(e, f, g, h)); }

        [IN(LINE)] public static bool CMin(bool a, bool b) { return Min(a, b); }
        [IN(LINE)] public static bool CMin(bool a, bool b, bool c) { return Min(Min(a, b), c); }
        [IN(LINE)] public static bool CMin(bool a, bool b, bool c, bool d) { return Min(Min(a, b), Min(c, d)); }
        [IN(LINE)] public static bool CMin(bool a, bool b, bool c, bool d, bool e) { return Min(CMin(a, b, c, d), e); }
        [IN(LINE)] public static bool CMin(bool a, bool b, bool c, bool d, bool e, bool f) { return Min(CMin(a, b, c, d), Min(e, f)); }
        [IN(LINE)] public static bool CMin(bool a, bool b, bool c, bool d, bool e, bool f, bool g) { return Min(CMin(a, b, c, d), Min(Min(a, b), c)); }
        [IN(LINE)] public static bool CMin(bool a, bool b, bool c, bool d, bool e, bool f, bool g, bool h) { return Min(CMin(a, b, c, d), CMin(e, f, g, h)); }

        [IN(LINE)] public static bool CAbsMin(bool a, bool b) { return AbsMin(a, b); }
        [IN(LINE)] public static bool CAbsMin(bool a, bool b, bool c) { return AbsMin(AbsMin(a, b), c); }
        [IN(LINE)] public static bool CAbsMin(bool a, bool b, bool c, bool d) { return AbsMin(AbsMin(a, b), AbsMin(c, d)); }
        [IN(LINE)] public static bool CAbsMin(bool a, bool b, bool c, bool d, bool e) { return AbsMin(CAbsMin(a, b, c, d), e); }
        [IN(LINE)] public static bool CAbsMin(bool a, bool b, bool c, bool d, bool e, bool f) { return AbsMin(CAbsMin(a, b, c, d), AbsMin(e, f)); }
        [IN(LINE)] public static bool CAbsMin(bool a, bool b, bool c, bool d, bool e, bool f, bool g) { return AbsMin(CAbsMin(a, b, c, d), AbsMin(AbsMin(a, b), c)); }
        [IN(LINE)] public static bool CAbsMin(bool a, bool b, bool c, bool d, bool e, bool f, bool g, bool h) { return AbsMin(CAbsMin(a, b, c, d), CAbsMin(e, f, g, h)); }


        [IN(LINE)] public static bool CMax<T>(T a, bool _ = default) where T : IVectorN<bool> { return Any<T>(a); }
        [IN(LINE)] public static bool CAbsMax<T>(T a, bool _ = default) where T : IVectorN<bool> { return Any<T>(a); }
        [IN(LINE)] public static bool CMin<T>(T a, bool _ = default) where T : IVectorN<bool> { return All<T>(a); }
        [IN(LINE)] public static bool CAbsMin<T>(T a, bool _ = default) where T : IVectorN<bool> { return All<T>(a); }

        [IN(LINE)]
        public static int CSum<T>(T a, bool _ = default) where T : IVectorN<bool>
        {
            var result = 0;
            for (int i = 0; i < a.count; i++)
            {
                result += a[i] ? 1 : 0;
            }
            return result;
        }


        [IN(LINE)] public static uint UHash<TVector>(TVector v, bool _ = default) where TVector : IVectorN<bool> { return unchecked((uint)Hash<TVector>(v)); }
        [IN(LINE)]
        public static int Hash<TVector>(TVector v, bool _ = default) where TVector : IVectorN<bool>
        {
            int bits = 0;
            for (int i = 0; i < v.count; i++)
            {
                bits ^= Hash(v[i]);
            }
            return bits;
        }
        [IN(LINE)]
        public static bool All<TVector>(TVector v, bool _ = default) where TVector : IVectorN<bool>
        {
            for (int i = 0; i < v.count; i++)
            {
                if (!v[i]) { return false; }
            }
            return true;
        }
        [IN(LINE)]
        public static bool Any<TVector>(TVector v, bool _ = default) where TVector : IVectorN<bool>
        {
            for (int i = 0; i < v.count; i++)
            {
                if (v[i]) { return true; }
            }
            return false;
        }
        #endregion
    }

    public static partial class DMBits // bool2
    {
        #region Bits
        [IN(LINE)]
        public static int BitMask(bool value)
        {
            return value ? 0x01 : 0;
        }
        #endregion
    }
}
