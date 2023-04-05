using System.Runtime.CompilerServices;

namespace DCFApixels.DataMath
{
    public partial struct float4
    {
        #region Convert operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4((float, float, float, float) v) => new float4(v.Item1, v.Item2, v.Item3, v.Item4);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(float v) => new float4(v);
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static explicit operator float4(float4 v) => new float4(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(int v) => new float4(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(int4 v) => new float4(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(uint v) => new float4(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(uint4 v) => new float4(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float4(double v) => new float4(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float4(double4 v) => new float4(v);
        #endregion
    }
}
