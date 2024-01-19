using DCFApixels.DataMath.Internal;
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
        public static float Clamp(float value, float min, float max)
        {
            if (value < min) return min; 
            if (value > max) return max;
            return value;
        }
        public static float Clamp01(float value)
        {
            if (value < 0f) return 0f;
            if (value > 1f) return 1f;
            return value;
        }
        #endregion

        #region lerp
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Lerp(in float a, in float b, float t) => a + (b - a) * t;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float LerpClamp(in float a, in float b, float t) => a + (b - a) * Clamp01(t);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float LerpLoop(in float a, in float b, float t) => a + (b - a) * (t % 1f);
        #endregion

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Max(float a, float b) => a > b ? a : b;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float AbsMax(float a, float b) => Abs(a) > Abs(b) ? a : b;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Min(float a, float b) => a < b ? a : b;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Cos(float x) { return SMathF.Cos(x); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  
        public static float Sin(float x) { return SMathF.Sin(x); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Atan2(float a, float b) { return SMathF.Atan2(a, b); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Asin(float x) { return SMathF.Asin(x); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Acos(float x) { return SMathF.Acos(x); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Sqrt(float x) { return SMathF.Sqrt(x); }
    }
}
