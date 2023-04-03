using System.Runtime.CompilerServices;
using SMathF = System.MathF;
using static DCFApixels.DataMath.math;

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
        public static float one_minus(float v) => 1f - v;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float abs(float v) => SMathF.Abs(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int sign(float v) => SMathF.Sign(v);
        #endregion

        #region round/floor/ceil
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float round(float v) => SMathF.Round(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int round2int(float v) => (int)SMathF.Round(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float floor(float v) => SMathF.Floor(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int floor2int(float v) => (int)SMathF.Floor(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ceil(float v) => SMathF.Ceiling(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ceil2int(float v) => (int)SMathF.Ceiling(v);
        #endregion

        #region clamp/clamp01
        public static float clamp(float value, float min, float max)
        {
            if (value < min) return min; 
            if (value > max) return max;
            return value;
        }
        public static float clamp01(float value)
        {
            if (value < 0f) return 0f;
            if (value > 1f) return 1f;
            return value;
        }
        #endregion

        #region lerp
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float lerp(in float a, in float b, float t) => a + (b - a) * t;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float lerp_clamp(in float a, in float b, float t) => a + (b - a) * clamp01(t);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float lerp_loop(in float a, in float b, float t) => a + (b - a) * (t % 1f);
        #endregion
    }
}
