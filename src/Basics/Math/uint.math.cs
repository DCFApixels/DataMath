using System.Runtime.CompilerServices;
#if !DOTNET_FRAMEWORK || UNITY_5_3_OR_NEWER
#else
#endif

namespace DCFApixels.DataMath
{
    //uint
    public static partial class math
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint one_minus(uint v) => 1u - v;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint abs(uint v) => v;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sign(uint v) => v > 0 ? 1 : 0;

    }
}
