using System.Runtime.CompilerServices;
using SMath = System.Math;
using System;
using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public static partial class DM //double
    {
        #region Hash
        [IN(LINE)] public static uint UHash(double v) => unchecked((uint)Hash(v));
        [IN(LINE)]
        public static unsafe int Hash(double v)
        {
            long bits = *(long*)&v;
            // Optimized check for IsNan() || IsZero()
            if (((bits - 1) & 0x7FFFFFFFFFFFFFFF) >= 0x7FF0000000000000)
            {
                // Ensure that all NaNs and both zeros have the same Hash code
                bits &= 0x7FF0000000000000;
            }
            return unchecked((int)bits) ^ ((int)(bits >> 32));
        }
        #endregion

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double one_minus(double v) => 1d - v;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double abs(double v) => SMath.Abs(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sign(double v) => SMath.Sign(v);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double round(double v) => SMath.Round(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int round2int(double v) => (int)SMath.Round(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double floor(double v) => SMath.Floor(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int floor2int(double v) => (int)SMath.Floor(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double ceil(double v) => SMath.Ceiling(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ceil2int(double v) => (int)SMath.Ceiling(v);


        #region Component iteration operations
        [IN(LINE)] public static uint UHash<TVector>(TVector v, double _ = default) where TVector : IVectorN<double> { return unchecked((uint)Hash<TVector>(v)); }
        [IN(LINE)]
        public static int Hash<TVector>(TVector v, double _ = default) where TVector : IVectorN<double>
        {
            int bits = 0;
            for (int i = 0; i < v.count; i++)
            {
                bits ^= Hash(v[i]);
            }
            return bits;
        }
        #endregion
    }
}
