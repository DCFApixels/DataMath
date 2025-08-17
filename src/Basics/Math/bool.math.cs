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


        #region Component iteration operations
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
