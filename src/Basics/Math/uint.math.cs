using System.Runtime.CompilerServices;
#if !DOTNET_FRAMEWORK || UNITY_5_3_OR_NEWER
#else
#endif
using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    //uint
    public static partial class DM
    {
        #region Hash
        [IN(LINE)] public static uint UHash(uint v) { return v; }
        [IN(LINE)] public static int Hash(uint v) { return unchecked((int)v); }
        #endregion

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint one_minus(uint v) => 1u - v;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint abs(uint v) => v;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sign(uint v) => v > 0 ? 1 : 0;


        #region Component iteration operations
        [IN(LINE)]
        public static uint UHash<TVector>(TVector v, uint _ = default) where TVector : IVectorN<uint>
        {
            uint bits = 0;
            for (int i = 0; i < v.count; i++)
            {
                bits ^= UHash(v[i]);
            }
            return bits;
        }
        [IN(LINE)] public static int Hash<TVector>(TVector v, uint _ = default) where TVector : IVectorN<uint> { return unchecked((int)UHash<TVector>(v)); }
        #endregion
    }
}
