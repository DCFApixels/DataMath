using System.Runtime.CompilerServices;

namespace DCFApixels.DataMath
{
    public partial struct uint2
    {
        #region Convert operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(float v) => new uint2(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(float2 v) => new uint2(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(int v) => new uint2(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(int2 v) => new uint2(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint2(uint v) => new uint2(v);
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static implicit operator uint2(uint2 v) => new uint2(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(double v) => new uint2(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint2(double2 v) => new uint2(v);
        #endregion
    }
}
