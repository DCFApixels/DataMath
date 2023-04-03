using System.Runtime.CompilerServices;

namespace DCFApixels.DataMath
{
    public partial struct int4
    {
        #region Convert operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4(float v) => new int4(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4(float4 v) => new int4(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int4(int v) => new int4(v);
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static implicit operator int4(int4 v) => new int4(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4(uint v) => new int4(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4(uint4 v) => new int4(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4(double v) => new int4(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int4(double4 v) => new int4(v);
        #endregion
    }
}
