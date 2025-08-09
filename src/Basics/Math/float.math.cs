using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;
#if !DOTNET_FRAMEWORK || UNITY_5_3_OR_NEWER
using SMathF = System.MathF;
#else
using SMathF = DCFApixels.DataMath.Internal.MathDM;
#endif

namespace DCFApixels.DataMath
{
    //float
    public static partial class math //self
    {

    }
    public static partial class math
    {
        #region Abs/Sign
        [IN(LINE)] public static float Abs(float a) { return SMathF.Abs(a);  }
        [IN(LINE)] public static float Sign(float a) { return (a > 0f ? 1f : 0f) - (a < 0f ? 1f : 0f); }
        [IN(LINE)] public static int Sign2Int(float a) { return (a > 0f ? 1 : 0) - (a < 0f ? 1 : 0); }
        #endregion

        #region Round/Floor/Ceil
        [IN(LINE)] public static float Round(float v) { return SMathF.Round(v); }
        [IN(LINE)] public static int Round2Int(float v) { return (int)SMathF.Round(v); }
        [IN(LINE)] public static float Floor(float v) { return SMathF.Floor(v); }
        [IN(LINE)] public static int Floor2Int(float v) { return (int)SMathF.Floor(v); }
        [IN(LINE)] public static float Ceil(float v) { return SMathF.Ceiling(v); }
        [IN(LINE)] public static int Ceil2Int(float v) { return (int)SMathF.Ceiling(v); }
        #endregion

        #region Clamp/Min/Max
        [IN(LINE)]
        public static float Clamp(float value, float min, float max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }
        [IN(LINE)] public static float Loop(float value, float length) { return value % length; }
        [IN(LINE)]
        public static float Loop(float value, float min, float max)
        {
            return Loop(value - min, max - min) + min;
        }
        /// <summary> Clamps the value between 0 and 1. </summary>
        [IN(LINE)]
        public static float Clamp01(float value)
        {
            if (value < 0f) return 0f;
            if (value > 1f) return 1f;
            return value;
        }
        /// <summary> Clamps the value between -1 and 1. </summary>
        [IN(LINE)]
        public static float ClampMirror1(float value)
        {
            if (value < -1f) return -1f;
            if (value > 1f) return 1f;
            return value;
        }
        #endregion

        #region Lerp
        [IN(LINE)]
        public static float Lerp(float start, float end, float t)
        {
            return start + t * (end - start);
        }
        [IN(LINE)]
        public static float LerpClamp(float start, float end, float t)
        {
            t = Clamp01(t);
            return start + t * (end - start);
        }
        [IN(LINE)]
        public static float LerpLoop(float start, float end, float t)
        {
            t %= 1f;
            return start + t * (end - start);
        }
        [IN(LINE)] public static float UnLerp(float start, float end, float v) { return (v - start) / (end - start); }
        [IN(LINE)] public static float Max(float a, float b) { return a > b ? a : b; }
        [IN(LINE)] public static float AbsMax(float a, float b) { return Abs(a) > Abs(b) ? a : b; }
        [IN(LINE)] public static float Min(float a, float b) { return a < b ? a : b; }
        [IN(LINE)] public static float AbsMin(float a, float b) { return Abs(a) < Abs(b) ? a : b; }

        [IN(LINE)]
        public static float Move(float from, float to, float distance)
        {
            float dif = to - from;
            if (Abs(dif) <= distance) { return to; }
            return from + Sign(dif) * distance;
        }
        [IN(LINE)]
        public static float Move(float from, float to, float distance, out float excess)
        {
            float dif = to - from;
            excess = Abs(dif);
            if (excess <= distance)
            {
                return to;
            }
            excess = 0f;
            return from + Sign(dif) * distance;
        }
        [IN(LINE)]
        public static float Remap(float oldStart, float oldEnd, float newStart, float newEnd, float v) { return Lerp(newStart, newEnd, UnLerp(oldStart, oldEnd, v)); }
        #endregion

        /// <summary> Convert Radians to Degrees. x * 57.296~ </summary>
        [IN(LINE)]  public static float Degrees(float a) { return a * Rad2Deg; }
        /// <summary> Convert Degrees to Radians. x * 0.0175~ </summary>
        [IN(LINE)]  public static float Radians(float a) { return a * Deg2Rad; }

        [IN(LINE)] public static float Cos(float a) { return SMathF.Cos(a); }
        [IN(LINE)] public static float Cosh(float a) { return SMathF.Cosh(a); }
        [IN(LINE)] public static float Acos(float a) { return SMathF.Acos(a); }
        [IN(LINE)] public static float Sin(float a) { return SMathF.Sin(a); }
        [IN(LINE)] public static float Sinh(float a) { return SMathF.Sinh(a); }
        [IN(LINE)] public static float Asin(float a) { return SMathF.Asin(a); }

        [IN(LINE)] public static float Atan(float a) { return SMathF.Atan(a); }
        [IN(LINE)] public static float Atan2(float a, float b) { return SMathF.Atan2(a, b); }

        [IN(LINE)] public static float Sqr(float a) { return a * a; }
        [IN(LINE)] public static float Pow(float a, float b) { return SMathF.Pow(a, b); }
        [IN(LINE)] public static float Sqrt(float a) { return SMathF.Sqrt(a); }

        [IN(LINE)] public static float Tan(float a) { return SMathF.Tan(a); }
        [IN(LINE)] public static float Tanh(float a) { return SMathF.Tanh(a); }

        [IN(LINE)] public static float Truncate(float a) { return SMathF.Truncate(a); }


        [IN(LINE)]
        public static float SmoothStep(float from, float to, float t)
        {
            t = Clamp01(t);
            t = -2f * t * t * t + 3f * t * t;
            return to * t + from * (1f - t);
        }

        //[IN(LINE)] public static bool IsPow(int value { return (value & (value - 1)) == 0; }
    }
}
