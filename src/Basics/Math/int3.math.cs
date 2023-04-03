using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.ComponentModel;
using SMath = System.Math;
using SMathF = System.MathF;

namespace DCFApixels.DataMath
{
    public partial struct int3
    {

    }
    public static partial class math
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 one_minus(int3 v) => 1 - v;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 abs(int3 v)
        {
            return new int3(SMathF.Abs(v.x), SMathF.Abs(v.y), SMathF.Abs(v.z));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 sign(int3 v)
        {
            return new int3(SMath.Sign(v.x), SMath.Sign(v.y), SMath.Sign(v.z));
        }
        
    }
}
