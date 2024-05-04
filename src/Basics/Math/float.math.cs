using System.Runtime.CompilerServices;
#if NETCORE || UNITY_5_3_OR_NEWER
using SMathF = System.MathF;
#else
using SMathF = DCFApixels.DataMath.Internal.MathF;
#endif

namespace DCFApixels.DataMath
{
    //float
    public static partial class math //self
    {
        #region simple
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void OneMinus(this ref float self) => self = 1f - self;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Abs(this ref float self) => self = SMathF.Abs(self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Sign(this ref float self) => self = SMathF.Sign(self);
        #endregion

        #region round/floor/ceil
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Round(this ref float self) => self = SMathF.Round(self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Floor(this ref float self) => self = SMathF.Floor(self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Ceil(this ref float self) => self = SMathF.Ceiling(self);
        #endregion

        #region clamp/clamp01
        public static void Clamp(this ref float self, float min, float max)
        {
            if (self < min) { self = min; return; }
            if (self > max) { self = max; }
        }
        public static void Clamp01(this ref float self)
        {
            if (self < 0f) { self = 0f; return; }
            if (self > 1f) { self = 1f; }
        }
        #endregion
    }
    public static partial class math
    {
        #region simple
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float OneMinus(float v) => 1f - v;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Abs(float v) => SMathF.Abs(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Sign(float v) => SMathF.Sign(v);
        #endregion

        #region round/floor/ceil
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Round(float v) => SMathF.Round(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Round2Int(float v) => (int)SMathF.Round(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Floor(float v) => SMathF.Floor(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Floor2Int(float v) => (int)SMathF.Floor(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Ceil(float v) => SMathF.Ceiling(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Ceil2Int(float v) => (int)SMathF.Ceiling(v);
        #endregion

        #region clamp/clamp01
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Clamp(float value, float min, float max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Loop(float value, float length)
        {
            return value % length;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Loop(float value, float min, float max)
        {
            return Loop(value - min, max - min) + min;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Clamp01(float value)
        {
            if (value < 0f) return 0f;
            if (value > 1f) return 1f;
            return value;
        }
        #endregion

        #region lerp
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Lerp(float start, float end, float t)
        {
            return start + t * (end - start);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float LerpClamp(float start, float end, float t)
        {
            t = Clamp01(t);
            return start + t * (end - start);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float LerpLoop(float start, float end, float t)
        {
            t %= 1f;
            return start + t * (end - start);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float UnLerp(float start, float end, float v)
        {
            return (v - start) / (end - start);
        }
        #endregion

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Max(float a, float b) => a > b ? a : b;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float AbsMax(float a, float b) => Abs(a) > Abs(b) ? a : b;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Min(float a, float b) => a < b ? a : b;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Cos(float v) { return SMathF.Cos(v); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sin(float v) { return SMathF.Sin(v); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Atan2(float a, float b) { return SMathF.Atan2(a, b); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Asin(float v) { return SMathF.Asin(v); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Acos(float v) { return SMathF.Acos(v); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sqrt(float v) { return SMathF.Sqrt(v); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sqr(float v) { return v * v; }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Pow(float a, float b) { return SMathF.Pow(a, b); }


        public static float SmoothStep(float from, float to, float t)
        {
            t = Clamp01(t);
            t = -2f * t * t * t + 3f * t * t;
            return to * t + from * (1f - t);
        }
    }
}
