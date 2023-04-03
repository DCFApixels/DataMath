using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace DCFApixels.DataMath
{
    public partial struct float3
    {
        #region Convert operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3(float v) => new float3(v);
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static explicit operator float3(float3 v) => new float3(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3(int v) => new float3(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3(int3 v) => new float3(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3(uint v) => new float3(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float3(uint3 v) => new float3(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float3(double v) => new float3(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float3(double3 v) => new float3(v);
        #endregion
    }
}
