using System.Runtime.CompilerServices;
using SMath = System.Math;
#if NETCORE || UNITY_5_3_OR_NEWER
using SMathF = System.MathF;
#else
using SMathF = DCFApixels.DataMath.Internal.MathF;
#endif

namespace DCFApixels.DataMath
{
    public partial struct float3
    {
        public const float vectorEpsilon = 0.00001f;
       
        #region vector
        public float Magnitude
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => SMathF.Sqrt(x * x + y * y + z * z);
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
        { x = 1f - x; y = 1f - y; z = 1f - z; }
        public void Abs()
        { x = SMathF.Abs(x); y = SMathF.Abs(y); z = SMathF.Abs(z); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Sign()
        { x = SMathF.Sign(x); y = SMathF.Sign(y); z = SMathF.Sign(z); }
        #endregion
    }
    public static partial class math
    {
        #region simple
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 one_minus(float3 v) => 1f - v;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 abs(float3 v)
        {
            return new float3(SMathF.Abs(v.x), SMathF.Abs(v.y), SMathF.Abs(v.z));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 sign(float3 v)
        {
            return new int3(SMath.Sign(v.x), SMath.Sign(v.y), SMath.Sign(v.z));
        }
        #endregion

        #region round/floor/ceil
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 round(float3 v)
        {
            return new float3(SMathF.Round(v.x), SMathF.Round(v.y), SMathF.Round(v.z));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 round2int(float3 v)
        {
            return new int3((int)SMathF.Round(v.x), (int)SMathF.Round(v.y), (int)SMathF.Round(v.z));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 floor(float3 v)
        {
            return new float3(SMathF.Floor(v.x), SMathF.Floor(v.y), SMathF.Floor(v.z));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 floor2int(float3 v)
        {
            return new int3((int)SMathF.Floor(v.x), (int)SMathF.Floor(v.y), (int)SMathF.Floor(v.z));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 ceil(float3 v)
        {
            return new float3(SMathF.Ceiling(v.x), SMathF.Ceiling(v.y), SMathF.Ceiling(v.z));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 ceil2int(float3 v)
        {
            return new int3((int)SMathF.Ceiling(v.x), (int)SMathF.Ceiling(v.y), (int)SMathF.Ceiling(v.z));
        }
        #endregion

        #region vector
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 normalize(float3 v) { v.Normalize(); return v; }
        /// <summary>alias for magnitude(a, b)</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float magn(in float3 v) => v.Magnitude;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float magnitude(in float3 v) => v.Magnitude;
        #endregion

        #region lerp
        public static float3 lerp(in float3 a, in float3 b, float t)
        {
            return new float3(
                a.x + (b.x - a.x) * t,
                a.y + (b.y - a.y) * t,
                a.z + (b.z - a.z) * t
            );
        }
        public static float3 lerp_clamp(in float3 a, in float3 b, float t)
        {
            t.Clamp01();
            return new float3(
                a.x + (b.x - a.x) * t,
                a.y + (b.y - a.y) * t,
                a.z + (b.z - a.z) * t
            );
        }
        public static float3 lerp_loop(in float3 a, in float3 b, float t)
        {
            t = t % 1f;
            return new float3(
                a.x + (b.x - a.x) * t,
                a.y + (b.y - a.y) * t,
                a.z + (b.z - a.z) * t
            );
        }
        #endregion

        #region distance
        /// <summary>alias for distance(a, b)</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float dist(in float3 a, in float3 b) => magnitude(b - a);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float distance(in float3 a, in float3 b) => magnitude(b - a);
        #endregion
    }
}
