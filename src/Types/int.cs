using System.Runtime.CompilerServices;
using SMathF = System.MathF;

namespace DCFApixels.DataMath
{
    //int
    public static partial class math
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int one_minus(int v) => 1 - v;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int abs(int v) => v < 0 ? -v : v;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sign(int v) => SMathF.Sign(v);
        
    }
}
