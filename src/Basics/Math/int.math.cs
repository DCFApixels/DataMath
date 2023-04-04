using System.Runtime.CompilerServices;
#if NETCORE || UNITY_5_3_OR_NEWER
using SMathF = System.MathF;
#else
using SMathF = DCFApixels.DataMath.Internal.MathF;
#endif

namespace DCFApixels.DataMath
{
    //int
    public static partial class math //self
    {
        #region simple
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void OneMinus(this ref int self) => self = 1 - self;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Abs(this ref int self) => self = self < 0 ? -self : self;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sign(this ref int self) => self = SMathF.Sign(self);
        #endregion

        #region clamp/clamp01
        public static void Clamp(this ref int self, int min, int max)
        {
            if (self < min) { self = min; return; }
            if (self > max) { self = max; }
        }
        public static void Clamp01(this ref int self)
        {
            if (self <= 0) { self = 0; return; }
            self = 1;
        }
        #endregion
    }
    public static partial class math
    {
        #region simple
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int one_minus(int v) => 1 - v;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int abs(int v) => v < 0 ? -v : v;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sign(int v) => SMathF.Sign(v);
        #endregion

        #region clamp/clamp01
        public static int clamp(int value, int min, int max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }
        public static int clamp01(int value)
        {
            if (value <= 0) return 0; 
            return 1;
        }
        #endregion

        #region lerp
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int lerp(in int a, in int b, int t) => a + (b - a) * t;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int lerp_clamp(in int a, in int b, int t) => a + (b - a) * clamp01(t);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int lerp_loop(in int a, in int b, int t) => a + (b - a) * (t % 1);
        #endregion
    }
}
