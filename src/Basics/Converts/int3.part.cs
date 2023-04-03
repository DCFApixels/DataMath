using System.Runtime.CompilerServices;

namespace DCFApixels.DataMath
{
    public partial struct int3
    {
        #region Convert operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(float v) => new int3(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(float3 v) => new int3(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int3(int v) => new int3(v);
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static implicit operator int3(int3 v) => new int3(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(uint v) => new int3(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(uint3 v) => new int3(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(double v) => new int3(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(double3 v) => new int3(v);
        #endregion
    }
}
