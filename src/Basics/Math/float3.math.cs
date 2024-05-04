using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;
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
            [IN(LINE)]
            get => SMathF.Sqrt(x * x + y * y + z * z);
        }
        public float PowMagnitude
        {
            [IN(LINE)]
            get => x * x + y * y + z * z;
        }
        public float3 Normalized
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
        { x = 1f - x; y = 1f - y; z = 1f - z; }
        public void Abs()
        { x = SMathF.Abs(x); y = SMathF.Abs(y); z = SMathF.Abs(z); }
        [IN(LINE)]
        public void Sign()
        { x = SMathF.Sign(x); y = SMathF.Sign(y); z = SMathF.Sign(z); }
        #endregion
    }
    public static partial class math
    {
        #region simple
        [IN(LINE)]
        public static float3 OneMinus(float3 v) => 1f - v;
        [IN(LINE)]
        public static float3 Abs(float3 v)
        {
            return new float3(SMathF.Abs(v.x), SMathF.Abs(v.y), SMathF.Abs(v.z));
        }
        [IN(LINE)]
        public static float3 Sign(float3 v)
        {
            return new float3(SMath.Sign(v.x), SMath.Sign(v.y), SMath.Sign(v.z));
        }
        #endregion

        #region round/floor/ceil
        [IN(LINE)]
        public static float3 Round(float3 v)
        {
            return new float3(SMathF.Round(v.x), SMathF.Round(v.y), SMathF.Round(v.z));
        }
        [IN(LINE)]
        public static int3 Round2Int(float3 v)
        {
            return new int3((int)SMathF.Round(v.x), (int)SMathF.Round(v.y), (int)SMathF.Round(v.z));
        }
        [IN(LINE)]
        public static float3 Floor(float3 v)
        {
            return new float3(SMathF.Floor(v.x), SMathF.Floor(v.y), SMathF.Floor(v.z));
        }
        [IN(LINE)]
        public static int3 Floor2Int(float3 v)
        {
            return new int3((int)SMathF.Floor(v.x), (int)SMathF.Floor(v.y), (int)SMathF.Floor(v.z));
        }
        [IN(LINE)]
        public static float3 Ceil(float3 v)
        {
            return new float3(SMathF.Ceiling(v.x), SMathF.Ceiling(v.y), SMathF.Ceiling(v.z));
        }
        [IN(LINE)]
        public static int3 Ceil2Int(float3 v)
        {
            return new int3((int)SMathF.Ceiling(v.x), (int)SMathF.Ceiling(v.y), (int)SMathF.Ceiling(v.z));
        }
        #endregion

        #region vector
        [IN(LINE)]
        public static float3 Normalize(float3 v) { v.Normalize(); return v; }
        [IN(LINE)]
        public static float Magnitude(float3 v) => v.Magnitude;
        [IN(LINE)]
        public static float PowMagnitude(float3 v) => v.PowMagnitude;
        #endregion

        #region Lerp
        [IN(LINE)]
        public static float3 Lerp(float3 start, float3 end, float t)
        {
            return start + t * (end - start);
        }
        [IN(LINE)]
        public static float3 Lerp(float3 start, float3 end, float3 t)
        {
            return start + t * (end - start);
        }
        [IN(LINE)]
        public static float3 LerpClamp(float3 start, float3 end, float t)
        {
            t = Clamp01(t);
            return start + t * (end - start);
        }
        [IN(LINE)]
        public static float3 LerpClamp(float3 start, float3 end, float3 t)
        {
            t = Clamp01(t);
            return start + t * (end - start);
        }
        [IN(LINE)]
        public static float3 LerpLoop(float3 start, float3 end, float t)
        {
            t %= 1f;
            return start + t * (end - start);
        }
        [IN(LINE)]
        public static float3 LerpLoop(float3 start, float3 end, float3 t)
        {
            t %= 1f;
            return start + t * (end - start);
        }
        [IN(LINE)]
        public static float3 UnLerp(float3 start, float3 end, float3 v)
        {
            return (v - start) / (end - start);
        }
        #endregion

        #region Move
        [IN(LINE)]
        public static float3 Move(float3 from, float3 to, float distance)
        {
            float3 dif = to - from;
            float difpowmag = dif.PowMagnitude;
            if (difpowmag == 0f || (distance >= 0f && difpowmag <= distance * distance))
            {
                return to;
            }
            float difmag = Sqrt(difpowmag);
            return new float3(from.x + dif.x / difmag * distance, from.y + dif.y / difmag * distance, from.z + dif.z / difmag * distance);
        }
        [IN(LINE)]
        public static float3 Move(float3 from, float3 to, float distance, out float excess)
        {
            if (distance == 0)
            {
                excess = 0;
                return from;
            }
            float3 dif = to - from;
            float difpowmag = dif.PowMagnitude;
            if (difpowmag == 0f)
            {
                excess = distance;
                return to;
            }
            float difmag = Sqrt(difpowmag);
            excess = distance - difmag;
            if (excess > -float.Epsilon)
            {
                return to;
            }
            return new float3(from.x + dif.x / difmag * distance, from.y + dif.y / difmag * distance, from.z + dif.z / difmag * distance);
        }
        #endregion

        #region Clamp/Clamp01/Min/Max
        public static float3 Clamp(float3 value, float min, float max) => new float3(
            Clamp(value.x, min, max),
            Clamp(value.y, min, max),
            Clamp(value.z, min, max));
        public static float3 Clamp(float3 value, float3 min, float3 max) => new float3(
            Clamp(value.x, min.x, max.x),
            Clamp(value.y, min.y, max.y),
            Clamp(value.z, min.z, max.z));
        public static float3 Clamp01(float3 value) => new float3(
            Clamp01(value.x),
            Clamp01(value.y),
            Clamp01(value.z));

        [IN(LINE)]
        public static float3 Max(float3 a, float3 b) => new float3(Max(a.x, b.x), Max(a.y, b.y), Max(a.z, b.z));
        [IN(LINE)]
        public static float3 AbsMax(float3 a, float3 b) => new float3(AbsMax(a.x, b.x), AbsMax(a.y, b.y), AbsMax(a.z, b.z));

        [IN(LINE)]
        public static float3 Min(float3 a, float3 b) => new float3(Min(a.x, b.x), Min(a.y, b.y), Min(a.z, b.z));

        #endregion

        [IN(LINE)]
        public static float3 Cos(float3 x) => new float3(Cos(x.x), Cos(x.y), Cos(x.z));
        [IN(LINE)]
        public static float3 Sin(float3 x) => new float3(Sin(x.x), Sin(x.y), Sin(x.z));


        [IN(LINE)]
        public static float CSum(float3 x) => x.x + x.y + x.z;
        [IN(LINE)]
        public static float PowDistance(float3 a, float3 b) => PowMagnitude(b - a);
        [IN(LINE)]
        public static float Distance(float3 a, float3 b) => Magnitude(b - a);
        [IN(LINE)]
        public static float Dot(float3 a, float3 b) => a.x * b.x + a.y * b.y + a.z * b.z;
        [IN(LINE)]
        public static float3 Atan2(float3 a, float3 b) => new float3(Atan2(a.x, b.x), Atan2(a.y, b.y), Atan2(a.z, b.z));
        [IN(LINE)]
        public static float3 Asin(float3 x) => new float3(Asin(x.x), Asin(x.y), Asin(x.z));

        [IN(LINE)]
        public static float3 Project(float3 vector, float3 normal)
        {
            float num = Dot(normal, normal);
            if (num < Epsilon)
            {
                return float3.zero;
            }
            float num2 = Dot(vector, normal);
            return new float3(normal.x * num2 / num, normal.y * num2 / num, normal.z * num2 / num);
        }


        [IN(LINE)]
        public static float3 Cross(float3 a, float3 b) => (a * b.yzx - a.yzx * b).yzx;



    }
}
