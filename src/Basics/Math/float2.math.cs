using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using static DCFApixels.DataMath.float2;
using static DCFApixels.DataMath.math;
using SMath = System.Math;
using SMathF = System.MathF;

namespace DCFApixels.DataMath
{
    public partial struct float2
    {
        public const float vectorEpsilon = 0.00001f;
       
        #region vector
        public float Magnitude
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => SMathF.Sqrt(x * x + y * y);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Normalize()
        {
            float mag = Magnitude;
            if (mag > vectorEpsilon)
                this = this / mag;
            else
                this = zero;
        }
        #endregion

        #region simple
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void OneMinus() 
        { x = 1f - x; y = 1f - y; }
        public void Abs()
        { x = SMathF.Abs(x); y = SMathF.Abs(y); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Sign()
        { x = SMathF.Sign(x); y = SMathF.Sign(y); }
        #endregion
    }
    public static partial class math
    {
        #region simple
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 one_minus(float2 v) => 1f - v;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 abs(float2 v)
        {
            return new float2(SMathF.Abs(v.x), SMathF.Abs(v.y));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 sign(float2 v)
        {
            return new int2(SMath.Sign(v.x), SMath.Sign(v.y));
        }
        #endregion

        #region round/floor/ceil
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 round(float2 v)
        {
            return new float2(SMathF.Round(v.x), SMathF.Round(v.y));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 round2int(float2 v)
        {
            return new int2((int)SMathF.Round(v.x), (int)SMathF.Round(v.y));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 floor(float2 v)
        {
            return new float2(SMathF.Floor(v.x), SMathF.Floor(v.y));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 floor2int(float2 v)
        {
            return new int2((int)SMathF.Floor(v.x), (int)SMathF.Floor(v.y));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 ceil(float2 v)
        {
            return new float2(SMathF.Ceiling(v.x), SMathF.Ceiling(v.y));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 ceil2int(float2 v)
        {
            return new int2((int)SMathF.Ceiling(v.x), (int)SMathF.Ceiling(v.y));
        }
        #endregion

        #region vector
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 normalize(float2 v) { v.Normalize(); return v; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float magnitude(in float2 v) => v.Magnitude;
        #endregion

        #region lerp
        public static float2 lerp(in float2 a, in float2 b, float t)
        {
            return new float2(
                a.x + (b.x - a.x) * t,
                a.y + (b.y - a.y) * t
            );
        }
        public static float2 lerp_clamp(in float2 a, in float2 b, float t)
        {
            t.Clamp01();
            return new float2(
                a.x + (b.x - a.x) * t,
                a.y + (b.y - a.y) * t
            );
        }
        public static float2 lerp_loop(in float2 a, in float2 b, float t)
        {
            t = t % 1f;
            return new float2(
                a.x + (b.x - a.x) * t,
                a.y + (b.y - a.y) * t
            );
        }
        #endregion
    }
}
