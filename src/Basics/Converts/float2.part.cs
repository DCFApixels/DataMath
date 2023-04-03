using System.Runtime.CompilerServices;

namespace DCFApixels.DataMath
{
    public partial struct float2
    {
        #region Convert operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(float v) => new float2(v);
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static explicit operator float2(float2 v) => new float2(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(int v) => new float2(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(int2 v) => new float2(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(uint v) => new float2(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(uint2 v) => new float2(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float2(double v) => new float2(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float2(double2 v) => new float2(v);
        #endregion
    }
}