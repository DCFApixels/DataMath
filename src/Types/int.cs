using System.Runtime.CompilerServices;
using SMathF = System.MathF;

namespace DCFApixels.DataMath
{
    //int
    public static partial class math
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint uhash(int v) => unchecked((uint)v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int hash(int v) => v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int one_minus(int v) => 1 - v;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int abs(int v) => SMathF.Abs(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sign(int v) => SMathF.Sign(v);
        
    }
}
