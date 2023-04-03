using System.Runtime.CompilerServices;

namespace DCFApixels.DataMath
{
    public partial struct double4 
    {
        #region Convert operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4(float v) => new double4(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4(float4 v) => new double4(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4(int v) => new double4(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4(int4 v) => new double4(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4(uint v) => new double4(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4(uint4 v) => new double4(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double4(double v) => new double4(v);
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static explicit operator double4(double4 v) => new double4(v);
        #endregion
    }
}
