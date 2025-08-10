using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;
using SMath = System.Math;
#if !DOTNET_FRAMEWORK || UNITY_5_3_OR_NEWER
using SMathF = System.MathF;
#else
using SMathF = DCFApixels.DataMath.Internal.MathDM;
#endif

namespace DCFApixels.DataMath
{
    public partial struct float4
    {
        public bool all { [IN(LINE)] get => x != 0 & y != 0 & z != 0 & w != 0; }
        public bool any { [IN(LINE)] get => x != 0 | y != 0 | z != 0 | w != 0; }

        public const float vectorEpsilon = 0.00001f;


        #region vector
        public float Magnitude
        {
            [IN(LINE)]
            get => SMathF.Sqrt(x * x + y * y + z * z + w * w);
        }
        [IN(LINE)]
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
    public static partial class DM
    {
        #region vector
        [IN(LINE)]
        public static float4 Normalize(float4 v) { return 1f / Sqrt(Dot(v, v)) * v; }
        /// <summary>alias for magnitude(a, b)</summary>
        [IN(LINE)]
        public static float magn(in float4 v) => v.Magnitude;
        [IN(LINE)]
        public static float magnitude(in float4 v) => v.Magnitude;
        #endregion

        #region Clamp/Clamp01
        public static float4 Clamp(float4 value, float min, float max) => new float4(
            Clamp(value.x, min, max),
            Clamp(value.y, min, max),
            Clamp(value.z, min, max),
            Clamp(value.w, min, max));
        public static float4 Clamp(float4 value, float4 min, float4 max) => new float4(
            Clamp(value.x, min.x, max.x),
            Clamp(value.y, min.y, max.y),
            Clamp(value.z, min.z, max.z),
            Clamp(value.w, min.w, max.w));
        public static float4 Clamp01(float4 value) => new float4(
            Clamp01(value.x),
            Clamp01(value.y),
            Clamp01(value.z),
            Clamp01(value.w));
        #endregion

        [IN(LINE)]
        public static float4 one_minus(float4 v) => 1f - v;
        [IN(LINE)]
        public static float4 abs(float4 v)
        {
            return new float4(SMathF.Abs(v.x), SMathF.Abs(v.y), SMathF.Abs(v.z), SMathF.Abs(v.w));
        }
        [IN(LINE)]
        public static int4 sign(float4 v)
        {
            return new int4(SMath.Sign(v.x), SMath.Sign(v.y), SMath.Sign(v.z), SMath.Sign(v.w));
        }

        [IN(LINE)]
        public static float4 round(float4 v)
        {
            return new float4(SMathF.Round(v.x), SMathF.Round(v.y), SMathF.Round(v.z), SMathF.Round(v.w));
        }
        [IN(LINE)]
        public static int4 round2int(float4 v)
        {
            return new int4((int)SMathF.Round(v.x), (int)SMathF.Round(v.y), (int)SMathF.Round(v.z), (int)SMathF.Round(v.w));
        }
        [IN(LINE)]
        public static float4 floor(float4 v)
        {
            return new float4(SMathF.Floor(v.x), SMathF.Floor(v.y), SMathF.Floor(v.z), SMathF.Floor(v.w));
        }
        [IN(LINE)]
        public static int4 floor2int(float4 v)
        {
            return new int4((int)SMathF.Floor(v.x), (int)SMathF.Floor(v.y), (int)SMathF.Floor(v.z), (int)SMathF.Floor(v.w));
        }
        [IN(LINE)]
        public static float4 ceil(float4 v)
        {
            return new float4(SMathF.Ceiling(v.x), SMathF.Ceiling(v.y), SMathF.Ceiling(v.z), SMathF.Ceiling(v.w));
        }
        [IN(LINE)]
        public static int4 ceil2int(float4 v)
        {
            return new int4((int)SMathF.Ceiling(v.x), (int)SMathF.Ceiling(v.y), (int)SMathF.Ceiling(v.z), (int)SMathF.Ceiling(v.w));
        }


        [IN(LINE)]
        public static float4 Max(float4 a, float4 b) => new float4(Max(a.x, b.x), Max(a.y, b.y), Max(a.z, b.z), Max(a.w, b.w));
        [IN(LINE)]
        public static float4 Min(float4 a, float4 b) => new float4(Min(a.x, b.x), Min(a.y, b.y), Min(a.z, b.z), Min(a.w, b.w));

        [IN(LINE)]
        public static float4 Cos(float4 x) => new float4(Cos(x.x), Cos(x.y), Cos(x.z), Cos(x.w));
        [IN(LINE)]
        public static float4 Sin(float4 x) => new float4(Sin(x.x), Sin(x.y), Sin(x.z), Sin(x.w));

        [IN(LINE)]
        public static float CSum(float4 x) => (x.x + x.y) + (x.z + x.w);

        [IN(LINE)]
        public static float Dot(float4 a, float4 b) => a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w;

        [IN(LINE)]
        public static float4 Asin(float4 x) => new float4(Asin(x.x), Asin(x.y), Asin(x.z), Asin(x.w));
    }
}
