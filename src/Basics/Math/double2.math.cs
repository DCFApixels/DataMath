using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.ComponentModel;
using SMath = System.Math;

namespace DCFApixels.DataMath
{
    public partial struct double2
    {

    }
    public static partial class math
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 one_minus(double2 v) => 1d - v;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 abs(double2 v)
        {
            return new double2(SMath.Abs(v.x), SMath.Abs(v.y));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 sign(double2 v)
        {
            return new int2(SMath.Sign(v.x), SMath.Sign(v.y));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 round(double2 v)
        {
            return new double2(SMath.Round(v.x), SMath.Round(v.y));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 round2int(double2 v)
        {
            return new int2((int)SMath.Round(v.x), (int)SMath.Round(v.y));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 floor(double2 v)
        {
            return new double2(SMath.Floor(v.x), SMath.Floor(v.y));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 floor2int(double2 v)
        {
            return new int2((int)SMath.Floor(v.x), (int)SMath.Floor(v.y));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 ceil(double2 v)
        {
            return new double2(SMath.Ceiling(v.x), SMath.Ceiling(v.y));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 ceil2int(double2 v)
        {
            return new int2((int)SMath.Ceiling(v.x), (int)SMath.Ceiling(v.y));
        }
        
    }
}
