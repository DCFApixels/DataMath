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
    public partial struct float2
    {
        public bool all { [IN(LINE)] get => x != 0 & y != 0; }
        public bool any { [IN(LINE)] get => x != 0 | y != 0; }

        public const float vectorEpsilon = 0.00001f;



        #region vector
        public float Magnitude
        {
            [IN(LINE)]
            get => SMathF.Sqrt(x * x + y * y);
        }
        public float2 Normalized
        {
            [IN(LINE)]
            get
            {
                float mag = Magnitude;
                return mag > vectorEpsilon ? this / mag : zero;
            }
        }

        [IN(LINE)]
        public void Normalize()
        {
            float mag = Magnitude;
            this = mag > vectorEpsilon ? this / mag : zero;
        }
        #endregion

        #region simple
        [IN(LINE)]
        public void OneMinus()
        { x = 1f - x; y = 1f - y; }
        public void Abs()
        { x = SMathF.Abs(x); y = SMathF.Abs(y); }
        [IN(LINE)]
        public void Sign()
        { x = SMathF.Sign(x); y = SMathF.Sign(y); }
        #endregion
    }
    public static partial class DM
    {
        #region simple
        [IN(LINE)]
        public static float2 one_minus(float2 v) => 1f - v;
        [IN(LINE)]
        public static float2 abs(float2 v)
        {
            return new float2(SMathF.Abs(v.x), SMathF.Abs(v.y));
        }
        [IN(LINE)]
        public static int2 Sign(float2 v)
        {
            return new int2(SMath.Sign(v.x), SMath.Sign(v.y));
        }
        #endregion

        #region round/floor/ceil
        [IN(LINE)]
        public static float2 round(float2 v)
        {
            return new float2(SMathF.Round(v.x), SMathF.Round(v.y));
        }
        [IN(LINE)]
        public static int2 round2int(float2 v)
        {
            return new int2((int)SMathF.Round(v.x), (int)SMathF.Round(v.y));
        }
        [IN(LINE)]
        public static float2 floor(float2 v)
        {
            return new float2(SMathF.Floor(v.x), SMathF.Floor(v.y));
        }
        [IN(LINE)]
        public static int2 floor2int(float2 v)
        {
            return new int2((int)SMathF.Floor(v.x), (int)SMathF.Floor(v.y));
        }
        [IN(LINE)]
        public static float2 ceil(float2 v)
        {
            return new float2(SMathF.Ceiling(v.x), SMathF.Ceiling(v.y));
        }
        [IN(LINE)]
        public static int2 ceil2int(float2 v)
        {
            return new int2((int)SMathF.Ceiling(v.x), (int)SMathF.Ceiling(v.y));
        }
        #endregion

        #region vector
        [IN(LINE)]
        public static float2 normalize(float2 v) { v.Normalize(); return v; }
        [IN(LINE)]
        public static float magnitude(in float2 v) => v.Magnitude;
        #endregion

        #region lerp
        [IN(LINE)]
        public static float2 Lerp(float2 start, float2 end, float t)
        {
            return start + t * (end - start);
        }
        [IN(LINE)]
        public static float2 LerpClamp(float2 start, float2 end, float t)
        {
            t = Clamp01(t);
            return start + t * (end - start);
        }
        [IN(LINE)]
        public static float2 LerpLoop(float2 start, float2 end, float t)
        {
            t %= 1f;
            return start + t * (end - start);
        }
        [IN(LINE)]
        public static float2 UnLerp(float2 start, float2 end, float2 v)
        {
            return (v - start) / (end - start);
        }
        #endregion

        #region Clamp/Clamp01
        public static float2 Clamp(float2 value, float min, float max) => new float2(
            Clamp(value.x, min, max),
            Clamp(value.y, min, max));
        public static float2 Clamp(float2 value, float2 min, float2 max) => new float2(
            Clamp(value.x, min.x, max.x),
            Clamp(value.y, min.y, max.y));
        public static float2 Clamp01(float2 value) => new float2(
            Clamp01(value.x),
            Clamp01(value.y));
        #endregion

        [IN(LINE)]
        public static float2 Max(float2 a, float2 b) => new float2(Max(a.x, b.x), Max(a.y, b.y));
        [IN(LINE)]
        public static float2 Min(float2 a, float2 b) => new float2(Min(a.x, b.x), Min(a.y, b.y));


        [IN(LINE)]
        public static float2 Cos(float2 x) => new float2(Cos(x.x), Cos(x.y));
        [IN(LINE)]
        public static float2 Sin(float2 x) => new float2(Sin(x.x), Sin(x.y));


        [IN(LINE)]
        public static float Csum(float2 x) => x.x + x.y;
        [IN(LINE)]
        public static float2 Asin(float2 x) => new float2(Asin(x.x), Asin(x.y));
    }
}
