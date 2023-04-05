using System.Runtime.CompilerServices;

namespace DCFApixels.DataMath
{
    public partial struct uint4
    {
        #region Convert operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint4((uint, uint, uint, uint) v) => new uint4(v.Item1, v.Item2, v.Item3, v.Item4);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4(float v) => new uint4(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4(float4 v) => new uint4(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4(int v) => new uint4(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4(int4 v) => new uint4(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint4(uint v) => new uint4(v);
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static implicit operator uint4(uint4 v) => new uint4(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4(double v) => new uint4(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint4(double4 v) => new uint4(v);
        #endregion
    }
}
