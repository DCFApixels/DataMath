using System.Runtime.CompilerServices;

namespace DCFApixels.DataMath
{
    public partial struct uint3
    {
        #region Convert operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(float v) => new uint3(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(float3 v) => new uint3(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(int v) => new uint3(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(int3 v) => new uint3(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint3(uint v) => new uint3(v);
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static implicit operator uint3(uint3 v) => new uint3(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(double v) => new uint3(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(double3 v) => new uint3(v);
        #endregion
    }
}
