using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace DCFApixels.DataMath
{
    public partial struct int2
    {
        #region Convert operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2(float v) => new int2(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2(float2 v) => new int2(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int2(int v) => new int2(v);
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static implicit operator int2(int2 v) => new int2(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2(uint v) => new int2(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2(uint2 v) => new int2(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2(double v) => new int2(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2(double2 v) => new int2(v);
        #endregion
    }
}
