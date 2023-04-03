using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace DCFApixels.DataMath
{
    public partial struct double3
    {
        #region Convert operators
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
