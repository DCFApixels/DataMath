using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace DCFApixels.DataMath
{
    public partial struct double2
    {
        #region Convert operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(float v) => new double2(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(float2 v) => new double2(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(int v) => new double2(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(int2 v) => new double2(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(uint v) => new double2(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(uint2 v) => new double2(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(double v) => new double2(v);
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static explicit operator double2(double2 v) => new double2(v);
        #endregion
    }
}
