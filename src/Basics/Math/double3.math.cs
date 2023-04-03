using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.ComponentModel;
using SMath = System.Math;

namespace DCFApixels.DataMath
{
    public partial struct double3
    {

    }
    public static partial class math
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 one_minus(double3 v) => 1d - v;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 abs(double3 v)
        {
            return new double3(SMath.Abs(v.x), SMath.Abs(v.y), SMath.Abs(v.z));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 sign(double3 v)
        {
            return new int3(SMath.Sign(v.x), SMath.Sign(v.y), SMath.Sign(v.z));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 round(double3 v)
        {
            return new double3(SMath.Round(v.x), SMath.Round(v.y), SMath.Round(v.z));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 round2int(double3 v)
        {
            return new int3((int)SMath.Round(v.x), (int)SMath.Round(v.y), (int)SMath.Round(v.z));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 floor(double3 v)
        {
            return new double3(SMath.Floor(v.x), SMath.Floor(v.y), SMath.Floor(v.z));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 floor2int(double3 v)
        {
            return new int3((int)SMath.Floor(v.x), (int)SMath.Floor(v.y), (int)SMath.Floor(v.z));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 ceil(double3 v)
        {
            return new double3(SMath.Ceiling(v.x), SMath.Ceiling(v.y), SMath.Ceiling(v.z));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 ceil2int(double3 v)
        {
            return new int3((int)SMath.Ceiling(v.x), (int)SMath.Ceiling(v.y), (int)SMath.Ceiling(v.z));
        }
        
    }
}
