using System.Runtime.CompilerServices;

namespace DCFApixels.DataMath
{
    public partial struct double3
    {
        #region Convert operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3((double, double, double) v) => new double3(v.Item1, v.Item2, v.Item3);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(float v) => new double3(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(float3 v) => new double3(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(int v) => new double3(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(int3 v) => new double3(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(uint v) => new double3(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(uint3 v) => new double3(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double3(double v) => new double3(v);
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static explicit operator double3(double3 v) => new double3(v);
        #endregion
    }
}
