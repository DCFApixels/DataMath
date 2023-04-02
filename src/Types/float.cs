using System.Runtime.CompilerServices;
using SMathF = System.MathF;

namespace DCFApixels.DataMath
{
    //float
    public static partial class math
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float one_minus(float v) => 1f - v;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float abs(float v) => SMathF.Abs(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sign(float v) => SMathF.Sign(v);
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float round(float v) => SMathF.Round(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int round2int(float v) => (int)SMathF.Round(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float floor(float v) =>  SMathF.Floor(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int floor2int(float v) => (int)SMathF.Floor(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ceil(float v) => SMathF.Ceiling(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ceil2int(float v) => (int)SMathF.Ceiling(v);
        
    }
}
