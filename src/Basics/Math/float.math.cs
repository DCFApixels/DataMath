using DCFApixels.DataMath.Internal;
using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public static partial class DM //self
    {

    }
    public static partial class DM //math float
    {
        #region Abs/Sign
        [IN(LINE)] public static float Abs(float a) { return InternalMath.Abs(a); }
        [IN(LINE)] public static float Sign(float a) { return (a > 0f ? 1f : 0f) - (a < 0f ? 1f : 0f); }
        [IN(LINE)] public static int Sign2Int(float a) { return (a > 0f ? 1 : 0) - (a < 0f ? 1 : 0); }
        #endregion

        #region Round/Floor/Ceil
        [IN(LINE)] public static float Round(float a) { return InternalMath.Round(a); }
        [IN(LINE)] public static int Round2Int(float a) { return (int)InternalMath.Round(a); }
        [IN(LINE)] public static float Floor(float a) { return InternalMath.Floor(a); }
        [IN(LINE)] public static int Floor2Int(float a) { return (int)InternalMath.Floor(a); }
        [IN(LINE)] public static float Ceil(float a) { return InternalMath.Ceiling(a); }
        [IN(LINE)] public static int Ceil2Int(float a) { return (int)InternalMath.Ceiling(a); }
        #endregion

        #region Clamp/Loop
        /// <summary> Clamps the value between min and max. </summary>
        [IN(LINE)]
        public static float Clamp(float a, float min, float max)
        {
            if (a < min) return min;
            if (a > max) return max;
            return a;
        }
        /// <summary> Clamps the value between 0 and 1. </summary>
        [IN(LINE)] public static float Clamp01(float a) { return Clamp(a, 0f, 1f); }
        /// <summary> Clamps the value between -1 and 1. </summary>
        [IN(LINE)] public static float ClampMirror1(float a) { return Clamp(a, -1f, 1f); }

        [IN(LINE)]
        public static float Loop(float a, float min, float max)
        {
            return (a - min) % (max - min) + min;
        }
        [IN(LINE)] public static float Loop01(float a) { return Loop(a, 0f, 1f); }
        [IN(LINE)] public static float LoopMirror1(float a) { return Loop(a, -1f, 1f); }
        #endregion

        #region SmoothStep
        /// <summary> Clamps the value between from and to. </summary>
        [IN(LINE)]
        public static float SmoothStep(float from, float to, float a)
        {
            var t = Clamp01((a - from) / (to - from));
            return t * t * (3.0f - (2.0f * t));
        }
        /// <summary> Clamps the value between 0 and 1. </summary>
        [IN(LINE)] public static float SmoothStep01(float a) { return SmoothStep(a, 0f, 1f); }
        /// <summary> Clamps the value between -1 and 1. </summary>
        [IN(LINE)] public static float SmoothStepMirror1(float a) { return SmoothStep(a, -1f, 1f); }
        #endregion

        #region Min/Max
        // Base methods (2 args)
        [IN(LINE)] public static float Max(float a, float b) { return a > b ? a : b; }
        [IN(LINE)] public static float AbsMax(float a, float b) { return InternalMath.Abs(a) > InternalMath.Abs(b) ? a : b; }
        [IN(LINE)] public static float Min(float a, float b) { return a < b ? a : b; }
        [IN(LINE)] public static float AbsMin(float a, float b) { return InternalMath.Abs(a) < InternalMath.Abs(b) ? a : b; }

        // Max overloads (3-8 args)
        [IN(LINE)] public static float Max(float a, float b, float c) { return Max(Max(a, b), c); }
        [IN(LINE)] public static float Max(float a, float b, float c, float d) { return Max(Max(a, b, c), d); }
        [IN(LINE)] public static float Max(float a, float b, float c, float d, float e) { return Max(Max(a, b, c, d), e); }
        [IN(LINE)] public static float Max(float a, float b, float c, float d, float e, float f) { return Max(Max(a, b, c, d, e), f); }
        [IN(LINE)] public static float Max(float a, float b, float c, float d, float e, float f, float g) { return Max(Max(a, b, c, d, e, f), g); }
        [IN(LINE)] public static float Max(float a, float b, float c, float d, float e, float f, float g, float h) { return Max(Max(a, b, c, d, e, f, g), h); }

        // AbsMax overloads (3-8 args)
        [IN(LINE)] public static float AbsMax(float a, float b, float c) { return AbsMax(AbsMax(a, b), c); }
        [IN(LINE)] public static float AbsMax(float a, float b, float c, float d) { return AbsMax(AbsMax(a, b, c), d); }
        [IN(LINE)] public static float AbsMax(float a, float b, float c, float d, float e) { return AbsMax(AbsMax(a, b, c, d), e); }
        [IN(LINE)] public static float AbsMax(float a, float b, float c, float d, float e, float f) { return AbsMax(AbsMax(a, b, c, d, e), f); }
        [IN(LINE)] public static float AbsMax(float a, float b, float c, float d, float e, float f, float g) { return AbsMax(AbsMax(a, b, c, d, e, f), g); }
        [IN(LINE)] public static float AbsMax(float a, float b, float c, float d, float e, float f, float g, float h) { return AbsMax(AbsMax(a, b, c, d, e, f, g), h); }

        // Min overloads (3-8 args)
        [IN(LINE)] public static float Min(float a, float b, float c) { return Min(Min(a, b), c); }
        [IN(LINE)] public static float Min(float a, float b, float c, float d) { return Min(Min(a, b, c), d); }
        [IN(LINE)] public static float Min(float a, float b, float c, float d, float e) { return Min(Min(a, b, c, d), e); }
        [IN(LINE)] public static float Min(float a, float b, float c, float d, float e, float f) { return Min(Min(a, b, c, d, e), f); }
        [IN(LINE)] public static float Min(float a, float b, float c, float d, float e, float f, float g) { return Min(Min(a, b, c, d, e, f), g); }
        [IN(LINE)] public static float Min(float a, float b, float c, float d, float e, float f, float g, float h) { return Min(Min(a, b, c, d, e, f, g), h); }

        // AbsMin overloads (3-8 args)
        [IN(LINE)] public static float AbsMin(float a, float b, float c) { return AbsMin(AbsMin(a, b), c); }
        [IN(LINE)] public static float AbsMin(float a, float b, float c, float d) { return AbsMin(AbsMin(a, b, c), d); }
        [IN(LINE)] public static float AbsMin(float a, float b, float c, float d, float e) { return AbsMin(AbsMin(a, b, c, d), e); }
        [IN(LINE)] public static float AbsMin(float a, float b, float c, float d, float e, float f) { return AbsMin(AbsMin(a, b, c, d, e), f); }
        [IN(LINE)] public static float AbsMin(float a, float b, float c, float d, float e, float f, float g) { return AbsMin(AbsMin(a, b, c, d, e, f), g); }
        [IN(LINE)] public static float AbsMin(float a, float b, float c, float d, float e, float f, float g, float h) { return AbsMin(AbsMin(a, b, c, d, e, f, g), h); }

        // overloads (vector args)
        [IN(LINE)]
        public static float Max<T>(T a) where T : IVectorN<float>
        {
            var result = float.MinValue;
            for (int i = 0; i < a.length; i++)
            {
                if (a[i] > result) { result = a[i]; }
            }
            return result;
        }
        [IN(LINE)] 
        public static float AbsMax<T>(T a) where T : IVectorN<float>
        {
            var result = float.MinValue;
            for (int i = 0; i < a.length; i++)
            {
                if (InternalMath.Abs(a[i]) > InternalMath.Abs(result)) { result = a[i]; }
            }
            return result;
        }
        [IN(LINE)] public static float Min<T>(T a) where T : IVectorN<float>
        {
            var result = float.MinValue;
            for (int i = 0; i < a.length; i++)
            {
                if (a[i] < result) { result = a[i]; }
            }
            return result;
        }
        [IN(LINE)] public static float AbsMin<T>(T a) where T : IVectorN<float>
        {
            var result = float.MinValue;
            for (int i = 0; i < a.length; i++)
            {
                if (InternalMath.Abs(a[i]) < InternalMath.Abs(result)) { result = a[i]; }
            }
            return result;
        }
        #endregion

        #region Lerp
        [IN(LINE)]
        public static float Lerp(float start, float end, float t)
        {
            return start + t * (end - start);
        }
        [IN(LINE)] public static float LerpClamp(float start, float end, float t) { return Lerp(start, end, Clamp01(t)); }
        [IN(LINE)] public static float LerpLoop(float start, float end, float t) { return Lerp(start, end, t % 1f); }

        [IN(LINE)] public static float UnLerp(float start, float end, float a) { return (a - start) / (end - start); }


        [IN(LINE)]
        public static float MoveTowards(float from, float to, float distance)
        {
            float dif = to - from;
            if (Abs(dif) <= distance) { return to; }
            return from + Sign(dif) * distance;
        }
        [IN(LINE)]
        public static float MoveTowards(float from, float to, float distance, out float excess)
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
        [IN(LINE)] public static float Degrees(float a) { return a * Rad2Deg; }
        /// <summary> Convert Degrees to Radians. x * 0.0175~ </summary>
        [IN(LINE)] public static float Radians(float a) { return a * Deg2Rad; }

        [IN(LINE)] public static float Cos(float a) { return InternalMath.Cos(a); }
        [IN(LINE)] public static float Cosh(float a) { return InternalMath.Cosh(a); }
        [IN(LINE)] public static float Acos(float a) { return InternalMath.Acos(a); }
        [IN(LINE)] public static float Sin(float a) { return InternalMath.Sin(a); }
        [IN(LINE)] public static float Sinh(float a) { return InternalMath.Sinh(a); }
        [IN(LINE)] public static float Asin(float a) { return InternalMath.Asin(a); }

        [IN(LINE)] public static float Atan(float a) { return InternalMath.Atan(a); }
        [IN(LINE)] public static float Atan2(float a, float b) { return InternalMath.Atan2(a, b); }

        [IN(LINE)] public static float Sqr(float a) { return a * a; }
        [IN(LINE)] public static float Pow(float a, float b) { return InternalMath.Pow(a, b); }
        [IN(LINE)] public static float Sqrt(float a) { return InternalMath.Sqrt(a); }

        [IN(LINE)] public static float Tan(float a) { return InternalMath.Tan(a); }
        [IN(LINE)] public static float Tanh(float a) { return InternalMath.Tanh(a); }

        [IN(LINE)] public static float Truncate(float a) { return InternalMath.Truncate(a); }


        //[IN(LINE)] public static bool IsPow(int value { return (value & (value - 1)) == 0; }
    }
}
