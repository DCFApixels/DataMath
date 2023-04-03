using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.ComponentModel;
using SMath = System.Math;
using SMathF = System.MathF;

namespace DCFApixels.DataMath
{
    public partial struct uint2
    {

    }
    public static partial class math
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 one_minus(uint2 v) => 1u - v;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 abs(uint2 v)
        {
            return new uint2(SMathF.Abs(v.x), SMathF.Abs(v.y));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 sign(uint2 v)
        {
            return new int2(SMath.Sign(v.x), SMath.Sign(v.y));
        }
        
    }
}
