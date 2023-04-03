using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.ComponentModel;
using SMath = System.Math;
using SMathF = System.MathF;

namespace DCFApixels.DataMath
{
    public partial struct int2
    {

    }
    public static partial class math
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 one_minus(int2 v) => 1 - v;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 abs(int2 v)
        {
            return new int2(SMathF.Abs(v.x), SMathF.Abs(v.y));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 sign(int2 v)
        {
            return new int2(SMath.Sign(v.x), SMath.Sign(v.y));
        }
        
    }
}
