using System.Runtime.CompilerServices;
using SMath = System.Math;

namespace DCFApixels.DataMath
{
    //double
    public static partial class math
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint uhash(double v) => unchecked((uint)hash(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe int hash(double v)
        {
            long bits = *(long*)&v;
            // Optimized check for IsNan() || IsZero()
            if (((bits - 1) & 0x7FFFFFFFFFFFFFFF) >= 0x7FF0000000000000)
            {
                // Ensure that all NaNs and both zeros have the same hash code
                bits &= 0x7FF0000000000000;
            }
            return unchecked((int)bits) ^ ((int)(bits >> 32));
        }

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
        
    }
}
