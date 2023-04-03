using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.ComponentModel;
using SMath = System.Math;
using SMathF = System.MathF;

namespace DCFApixels.DataMath
{
    public partial struct float4
    {

    }
    public static partial class math
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 one_minus(float4 v) => 1f - v;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 abs(float4 v)
        {
            return new float4(SMathF.Abs(v.x), SMathF.Abs(v.y), SMathF.Abs(v.z), SMathF.Abs(v.w));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 sign(float4 v)
        {
            return new int4(SMath.Sign(v.x), SMath.Sign(v.y), SMath.Sign(v.z), SMath.Sign(v.w));
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 round(float4 v)
        {
            return new float4(SMathF.Round(v.x), SMathF.Round(v.y), SMathF.Round(v.z), SMathF.Round(v.w));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 round2int(float4 v)
        {
            return new int4((int)SMathF.Round(v.x), (int)SMathF.Round(v.y), (int)SMathF.Round(v.z), (int)SMathF.Round(v.w));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 floor(float4 v)
        {
            return new float4(SMathF.Floor(v.x), SMathF.Floor(v.y), SMathF.Floor(v.z), SMathF.Floor(v.w));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 floor2int(float4 v)
        {
            return new int4((int)SMathF.Floor(v.x), (int)SMathF.Floor(v.y), (int)SMathF.Floor(v.z), (int)SMathF.Floor(v.w));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 ceil(float4 v)
        {
            return new float4(SMathF.Ceiling(v.x), SMathF.Ceiling(v.y), SMathF.Ceiling(v.z), SMathF.Ceiling(v.w));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 ceil2int(float4 v)
        {
            return new int4((int)SMathF.Ceiling(v.x), (int)SMathF.Ceiling(v.y), (int)SMathF.Ceiling(v.z), (int)SMathF.Ceiling(v.w));
        }
        
    }
}
