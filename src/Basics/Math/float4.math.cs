using System.Runtime.CompilerServices;
using SMath = System.Math;
#if NETCORE || UNITY_5_3_OR_NEWER
using SMathF = System.MathF;
#else
using SMathF = DCFApixels.DataMath.Internal.MathF;
#endif

namespace DCFApixels.DataMath
{
    public partial struct float4
    {
        public const float vectorEpsilon = 0.00001f;


        #region vector
        public float Magnitude
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => SMathF.Sqrt(x * x + y * y + z * z + w * w);
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
    }
    public static partial class math
    {


        #region vector
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 normalize(float4 v) { v.Normalize(); return v; }
        /// <summary>alias for magnitude(a, b)</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float magn(in float4 v) => v.Magnitude;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float magnitude(in float4 v) => v.Magnitude;
        #endregion




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
