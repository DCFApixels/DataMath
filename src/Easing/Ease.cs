using DCFApixels.DataMath.Easing;
using DCFApixels.DataMath.Internal;
using static DCFApixels.DataMath.DM;
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath.Easing
{
#if UNITY_5_3_OR_NEWER
    using UnityEngine;
#endif

    public enum Ease : uint
    {
        None = 0,

        Linear = EaseInternal.InOutLinear,

        InSine = EaseInternal.InSine,
        OutSine = EaseInternal.OutSine,
        InOutSine = EaseInternal.InOutSine,
        OutInSine = EaseInternal.OutInSine,

        InQuad = EaseInternal.InQuad,
        OutQuad = EaseInternal.OutQuad,
        InOutQuad = EaseInternal.InOutQuad,
        OutInQuad = EaseInternal.OutInQuad,

        InCubic = EaseInternal.InCubic,
        OutCubic = EaseInternal.OutCubic,
        InOutCubic = EaseInternal.InOutCubic,
        OutInCubic = EaseInternal.OutInCubic,

        InQuart = EaseInternal.InQuart,
        OutQuart = EaseInternal.OutQuart,
        InOutQuart = EaseInternal.InOutQuart,
        OutInQuart = EaseInternal.OutInQuart,

        InQuint = EaseInternal.InQuint,
        OutQuint = EaseInternal.OutQuint,
        InOutQuint = EaseInternal.InOutQuint,
        OutInQuint = EaseInternal.OutInQuint,

        InExpo = EaseInternal.InExpo,
        OutExpo = EaseInternal.OutExpo,
        InOutExpo = EaseInternal.InOutExpo,
        OutInExpo = EaseInternal.OutInExpo,

        InCirc = EaseInternal.InCirc,
        OutCirc = EaseInternal.OutCirc,
        InOutCirc = EaseInternal.InOutCirc,
        OutInCirc = EaseInternal.OutInCirc,

        InElastic = EaseInternal.InElastic,
        OutElastic = EaseInternal.OutElastic,
        InOutElastic = EaseInternal.InOutElastic,
        OutInElastic = EaseInternal.OutInElastic,

        InBack = EaseInternal.InBack,
        OutBack = EaseInternal.OutBack,
        InOutBack = EaseInternal.InOutBack,
        OutInBack = EaseInternal.OutInBack,

        InBounce = EaseInternal.InBounce,
        OutBounce = EaseInternal.OutBounce,
        InOutBounce = EaseInternal.InOutBounce,
        OutInBounce = EaseInternal.OutInBounce,
    }
    public enum EaseType : uint
    {
        None = 0,
        Linear = 1 << 2,
        Sine = 2 << 2,
        Quad = 3 << 2,
        Cubic = 4 << 2,
        Quart = 5 << 2,
        Quint = 6 << 2,
        Expo = 7 << 2,
        Circ = 8 << 2,
        Elastic = 9 << 2,
        Back = 10 << 2,
        Bounce = 11 << 2,
    }
    public enum EaseInOutType : uint
    {
        In = 0,
        Out = 1,
        InOut = 2,
        OutIn = 3,
    }

    public static class DMEase
    {
        public const float DefaultEaseAmplitude = 1.70158f;
        public const float DefaultEasePeriod = 0.3f;

        #region Evaluate
        public static float Evaluate(this EaseType easeType, EaseInOutType inOutType, float t)
        {
            return Evaluate((Ease)((uint)easeType | (uint)inOutType), t);
        }
        public static float Evaluate(this EaseType easeType, EaseInOutType inOutType, float t, float amplitude = DefaultEaseAmplitude, float period = DefaultEasePeriod)
        {
            return Evaluate((Ease)((uint)easeType | (uint)inOutType), t, amplitude, period);
        }
        public static float Evaluate(this Ease ease, float t)
        {
            switch ((EaseInternal)ease)
            {
                default:
                // None
                case EaseInternal.InNone:
                case EaseInternal.OutNone:
                case EaseInternal.InOutNone:
                case EaseInternal.OutInNone: return 0f;

                // Linear
                case EaseInternal.InLinear:
                case EaseInternal.OutLinear:
                case EaseInternal.InOutLinear:
                case EaseInternal.OutInLinear: return t;

                // Sine
                case EaseInternal.InSine: return InSine(t);
                case EaseInternal.OutSine: return OutSine(t);
                case EaseInternal.InOutSine: return InOutSine(t);
                case EaseInternal.OutInSine: return OutInSine(t);

                // Quad
                case EaseInternal.InQuad: return InQuad(t);
                case EaseInternal.OutQuad: return OutQuad(t);
                case EaseInternal.InOutQuad: return InOutQuad(t);
                case EaseInternal.OutInQuad: return OutInQuad(t);

                // Cubic
                case EaseInternal.InCubic: return InCubic(t);
                case EaseInternal.OutCubic: return OutCubic(t);
                case EaseInternal.InOutCubic: return InOutCubic(t);
                case EaseInternal.OutInCubic: return OutInCubic(t);

                // Quart
                case EaseInternal.InQuart: return InQuart(t);
                case EaseInternal.OutQuart: return OutQuart(t);
                case EaseInternal.InOutQuart: return InOutQuart(t);
                case EaseInternal.OutInQuart: return OutInQuart(t);

                // Quint
                case EaseInternal.InQuint: return InQuint(t);
                case EaseInternal.OutQuint: return OutQuint(t);
                case EaseInternal.InOutQuint: return InOutQuint(t);
                case EaseInternal.OutInQuint: return OutInQuint(t);

                // Expo
                case EaseInternal.InExpo: return InExpo(t);
                case EaseInternal.OutExpo: return OutExpo(t);
                case EaseInternal.InOutExpo: return InOutExpo(t);
                case EaseInternal.OutInExpo: return OutInExpo(t);

                // Circ
                case EaseInternal.InCirc: return InCirc(t);
                case EaseInternal.OutCirc: return OutCirc(t);
                case EaseInternal.InOutCirc: return InOutCirc(t);
                case EaseInternal.OutInCirc: return OutInCirc(t);

                // Elastic
                case EaseInternal.InElastic: return InElastic(t);
                case EaseInternal.OutElastic: return OutElastic(t);
                case EaseInternal.InOutElastic: return InOutElastic(t);
                case EaseInternal.OutInElastic: return OutInElastic(t);

                // Back
                case EaseInternal.InBack: return InBack(t);
                case EaseInternal.OutBack: return OutBack(t);
                case EaseInternal.InOutBack: return InOutBack(t);
                case EaseInternal.OutInBack: return OutInBack(t);

                // Bounce
                case EaseInternal.InBounce: return InBounce(t);
                case EaseInternal.OutBounce: return OutBounce(t);
                case EaseInternal.InOutBounce: return InOutBounce(t);
                case EaseInternal.OutInBounce: return OutInBounce(t);
            }
        }
        public static float Evaluate(this Ease ease, float t, float amplitude = DefaultEaseAmplitude, float period = DefaultEasePeriod)
        {
            switch ((EaseInternal)ease)
            {
                default:
                // None
                case EaseInternal.InNone:
                case EaseInternal.OutNone:
                case EaseInternal.InOutNone:
                case EaseInternal.OutInNone: return 0f;

                // Linear
                case EaseInternal.InLinear:
                case EaseInternal.OutLinear:
                case EaseInternal.InOutLinear:
                case EaseInternal.OutInLinear: return t;

                // Sine
                case EaseInternal.InSine: return InSine(t);
                case EaseInternal.OutSine: return OutSine(t);
                case EaseInternal.InOutSine: return InOutSine(t);
                case EaseInternal.OutInSine: return OutInSine(t);

                // Quad
                case EaseInternal.InQuad: return InQuad(t);
                case EaseInternal.OutQuad: return OutQuad(t);
                case EaseInternal.InOutQuad: return InOutQuad(t);
                case EaseInternal.OutInQuad: return OutInQuad(t);

                // Cubic
                case EaseInternal.InCubic: return InCubic(t);
                case EaseInternal.OutCubic: return OutCubic(t);
                case EaseInternal.InOutCubic: return InOutCubic(t);
                case EaseInternal.OutInCubic: return OutInCubic(t);

                // Quart
                case EaseInternal.InQuart: return InQuart(t);
                case EaseInternal.OutQuart: return OutQuart(t);
                case EaseInternal.InOutQuart: return InOutQuart(t);
                case EaseInternal.OutInQuart: return OutInQuart(t);

                // Quint
                case EaseInternal.InQuint: return InQuint(t);
                case EaseInternal.OutQuint: return OutQuint(t);
                case EaseInternal.InOutQuint: return InOutQuint(t);
                case EaseInternal.OutInQuint: return OutInQuint(t);

                // Expo
                case EaseInternal.InExpo: return InExpo(t);
                case EaseInternal.OutExpo: return OutExpo(t);
                case EaseInternal.InOutExpo: return InOutExpo(t);
                case EaseInternal.OutInExpo: return OutInExpo(t);

                // Circ
                case EaseInternal.InCirc: return InCirc(t);
                case EaseInternal.OutCirc: return OutCirc(t);
                case EaseInternal.InOutCirc: return InOutCirc(t);
                case EaseInternal.OutInCirc: return OutInCirc(t);

                // Elastic
                case EaseInternal.InElastic: return InElastic(t, amplitude, period);
                case EaseInternal.OutElastic: return OutElastic(t, amplitude, period);
                case EaseInternal.InOutElastic: return InOutElastic(t, amplitude, period);
                case EaseInternal.OutInElastic: return OutInElastic(t, amplitude, period);

                // Back
                case EaseInternal.InBack: return InBack(t, amplitude);
                case EaseInternal.OutBack: return OutBack(t, amplitude);
                case EaseInternal.InOutBack: return InOutBack(t, amplitude);
                case EaseInternal.OutInBack: return OutInBack(t, amplitude);

                // Bounce
                case EaseInternal.InBounce: return InBounce(t, amplitude, period);
                case EaseInternal.OutBounce: return OutBounce(t, amplitude, period);
                case EaseInternal.InOutBounce: return InOutBounce(t, amplitude, period);
                case EaseInternal.OutInBounce: return OutInBounce(t, amplitude, period);
            }
        }
        #endregion

        #region Basic
        [IN(LINE)] public static float Linear(float t) { return t; }

        [IN(LINE)] public static float InSine(float t) { const float HalfPI = PI * 0.5f; return 1 - Cos(t * HalfPI); }
        [IN(LINE)] public static float OutSine(float t) { const float HalfPI = PI * 0.5f; return Sin(t * HalfPI); }
        [IN(LINE)] public static float InOutSine(float t) { return (Cos(PI * t) - 1) * -0.5f; }
        [IN(LINE)] public static float OutInSine(float t) { return t < 0.5f ? OutSine(t * 2f) * 0.5f : 0.5f + InSine((t - 0.5f) * 2f) * 0.5f; }

        [IN(LINE)] public static float InQuad(float t) { return t * t; }
        [IN(LINE)] public static float OutQuad(float t) { return 1 - InQuad(1 - t); }
        [IN(LINE)] public static float InOutQuad(float t) { return t < 0.5f ? 2 * t * t : 1 - InQuad(-2 * t + 2) * 0.5f; }
        [IN(LINE)] public static float OutInQuad(float t) { return t < 0.5f ? OutQuad(t * 2f) * 0.5f : 0.5f + InQuad((t - 0.5f) * 2f) * 0.5f; }

        [IN(LINE)] public static float InCubic(float t) { return t * t * t; }
        [IN(LINE)] public static float OutCubic(float t) { return 1 - InCubic(1 - t); }
        [IN(LINE)] public static float InOutCubic(float t) { return t < 0.5f ? 4 * t * t * t : 1 - InCubic(-2 * t + 2) * 0.5f; }
        [IN(LINE)] public static float OutInCubic(float t) { return t < 0.5f ? OutCubic(t * 2f) * 0.5f : 0.5f + InCubic((t - 0.5f) * 2f) * 0.5f; }

        [IN(LINE)] public static float InQuart(float t) { return t * t * t * t; }
        [IN(LINE)] public static float OutQuart(float t) { return 1 - InQuart(1 - t); }
        [IN(LINE)] public static float InOutQuart(float t) { return t < 0.5 ? 8 * t * t * t * t : 1 - InQuart(-2 * t + 2) * 0.5f; }
        [IN(LINE)] public static float OutInQuart(float t) { return t < 0.5f ? OutQuart(t * 2f) * 0.5f : 0.5f + InQuart((t - 0.5f) * 2f) * 0.5f; }

        [IN(LINE)] public static float InQuint(float t) { return t * t * t * t * t; }
        [IN(LINE)] public static float OutQuint(float t) { return 1 - InQuint(1 - t); }
        [IN(LINE)] public static float InOutQuint(float t) { return t < 0.5f ? 16 * t * t * t * t * t : 1 - InQuint(-2 * t + 2) * 0.5f; }
        [IN(LINE)] public static float OutInQuint(float t) { return t < 0.5f ? OutQuint(t * 2f) * 0.5f : 0.5f + InQuint((t - 0.5f) * 2f) * 0.5f; }
        #endregion

        #region Expo
        [IN(LINE)] public static float InExpo(float t) { return t == 0 ? 0 : Pow(2, 10 * t - 10); }
        [IN(LINE)] public static float OutExpo(float t) { return t == 1 ? 1 : 1 - Pow(2, -10 * t); }
        [IN(LINE)]
        public static float InOutExpo(float t)
        {
            if (t == 0) { return 0; }
            if (t == 1) { return 1; }
            return t < 0.5f
                ? Pow(2, 20 * t - 10) * 0.5f
                : (2 - Pow(2, -20 * t + 10)) * 0.5f;
        }
        [IN(LINE)]
        public static float OutInExpo(float t)
        {
            return t < 0.5f
                ? OutExpo(t * 2f) * 0.5f
                : 0.5f + InExpo((t - 0.5f) * 2f) * 0.5f;
        }
        #endregion

        #region Circ
        [IN(LINE)] public static float InCirc(float t) { return 1 - Sqrt(1 - InQuad(t)); }
        [IN(LINE)] public static float OutCirc(float t) { return Sqrt(1 - InQuad(t - 1)); }
        [IN(LINE)]
        public static float InOutCirc(float t)
        {
            return t < 0.5
                ? (1 - Sqrt(1 - InQuad(2 * t))) * 0.5f
                : (Sqrt(1 - InQuad(-2 * t + 2)) + 1) * 0.5f;
        }
        [IN(LINE)]
        public static float OutInCirc(float t)
        {
            return t < 0.5f
                ? OutCirc(t * 2f) * 0.5f
                : 0.5f + InCirc((t - 0.5f) * 2f) * 0.5f;
        }
        #endregion

        #region Back
        [IN(LINE)]
        public static float InBack(float t)
        {
            return (t * t) * ((2.70158f * t) - 1.70158f);
        }
        [IN(LINE)]
        public static float OutBack(float t)
        {
            return ((t -= 1) * t) * ((2.70158f * t) + 1.70158f) + 1;
        }
        [IN(LINE)]
        public static float InOutBack(float t)
        {
            return ((t *= 2) < 1)
                ? ((t * t) * ((3.5949095f * t) - 2.5949095f)) * 0.5f
                : ((t -= 2) * t * (3.5949095f * t + 2.5949095f) + 2) * 0.5f;
        }
        [IN(LINE)]
        public static float OutInBack(float t)
        {
            return t < 0.5f
                ? OutBack(t * 2f) * 0.5f
                : 0.5f + InBack((t - 0.5f) * 2f) * 0.5f;
        }

        // Extended
        [IN(LINE)]
        public static float InBack(float t, float amplitude = DefaultEaseAmplitude)
        {
            return (amplitude + 1) * t * t * t - amplitude * t * t;
        }
        [IN(LINE)]
        public static float OutBack(float t, float amplitude = DefaultEaseAmplitude)
        {
            return 1 + (amplitude + 1) * InCubic(t - 1) + amplitude * InQuad(t - 1);
        }
        [IN(LINE)]
        public static float InOutBack(float t, float amplitude = DefaultEaseAmplitude)
        {
            float n1 = amplitude + 0.70158f;
            return t < 0.5f
                ? Pow(2 * t, 2) * ((n1 + 1) * 2 * t - n1) / 2
                : (Pow(2 * t - 2, 2) * ((n1 + 1) * (t * 2 - 2) + n1) + 2) / 2;
        }
        [IN(LINE)]
        public static float OutInBack(float t, float amplitude = DefaultEaseAmplitude)
        {
            return t < 0.5f
                ? OutBack(t * 2f, amplitude) * 0.5f
                : 0.5f + InBack((t - 0.5f) * 2f, amplitude) * 0.5f;
        }
        #endregion

        #region Elastic
        [IN(LINE)]
        public static float InElastic(float t)
        {
            //const float c4 = 2 * PI / 3;
            if (t == 0) { return 0; }
            if (t == 1) { return 1; }
            return -((Pow(2.0f, (10.0f * (t -= 1))) * Sin((t - 0.075f) * PI * 2.0f * 3.3333f)));
        }
        [IN(LINE)]
        public static float OutElastic(float t)
        {
            const float c4 = 2 * PI / 3;
            if (t == 0) { return 0; }
            if (t == 1) { return 1; }
            return Pow(2, -10 * t) * Sin((t * 10 - 0.75f) * c4) + 1;
        }
        [IN(LINE)]
        public static float InOutElastic(float t)
        {
            const float c5 = 2 * PI / 4.5f;
            if (t == 0) { return 0; }
            if (t == 1) { return 1; }
            return t < 0.5f
                ? -(Pow(2, 20 * t - 10) * Sin((20 * t - 11.125f) * c5)) * 0.5f
                : Pow(2, -20 * t + 10) * Sin((20 * t - 11.125f) * c5) * 0.5f + 1;
        }
        [IN(LINE)]
        public static float OutInElastic(float t)
        {
            return t < 0.5f
                ? OutElastic(t * 2f) * 0.5f
                : 0.5f + InElastic((t - 0.5f) * 2f) * 0.5f;
        }

        // Extended
        [IN(LINE)]
        public static float InElastic(float t, float amplitude = DefaultEaseAmplitude, float period = DefaultEasePeriod)
        {
            if (t == 0) { return 0; }
            if (t == 1) { return 1; }
            period = Max(1e-37f, period);

            float shift;
            if (amplitude < 1)
            {
                amplitude = 1;
                shift = period * 0.25f;
            }
            else
            {
                shift = period / TAU * Asin(1 / amplitude);
            }

            return Pow(2, 10 * (t -= 1)) * Sin((t + shift) * TAU / period) * amplitude;
        }
        [IN(LINE)]
        public static float OutElastic(float time, float amplitude = DefaultEaseAmplitude, float period = DefaultEasePeriod)
        {
            return 1 - InElastic(1 - time, amplitude, period);
        }
        [IN(LINE)]
        public static float InOutElastic(float time, float amplitude = DefaultEaseAmplitude, float period = DefaultEasePeriod)
        {
            return time < 0.5f
                ? (1 - OutElastic(1 - 2 * time, amplitude, period)) * 0.5f
                : (1 + OutElastic(2 * time - 1, amplitude, period)) * 0.5f;
        }
        [IN(LINE)]
        public static float OutInElastic(float time, float amplitude = DefaultEaseAmplitude, float period = DefaultEasePeriod)
        {
            return time < 0.5f
                ? OutElastic(time * 2f, amplitude, period) * 0.5f
                : 0.5f + InElastic((time - 1f * 0.5f) * 2f, amplitude, period) * 0.5f;
        }
        #endregion

        #region Bounce
        [IN(LINE)]
        public static float InBounce(float t) { return 1 - OutBounce(1 - t); }
        [IN(LINE)]
        public static float OutBounce(float t)
        {
            const float n1 = 7.5625f;
            const float d1 = 2.75f;
            if (t < 1 / d1) { return n1 * t * t; }
            if (t < 2 / d1) { return n1 * (t -= 1.5f / d1) * t + 0.75f; }
            if (t < 2.5 / d1) { return n1 * (t -= 2.25f / d1) * t + 0.9375f; }
            return n1 * (t -= 2.625f / d1) * t + 0.984375f;
        }
        [IN(LINE)]
        public static float InOutBounce(float t)
        {
            return t < 0.5f
                ? (1 - OutBounce(1 - 2 * t)) * 0.5f
                : (1 + OutBounce(2 * t - 1)) * 0.5f;
        }
        [IN(LINE)]
        public static float OutInBounce(float t)
        {
            return t < 0.5f
                ? OutBounce(t * 2f) * 0.5f
                : 0.5f + InBounce((t - 0.5f) * 2f) * 0.5f;
        }

        // Extended
        [IN(LINE)]
        public static float InBounce(float t, float amplitude = DefaultEaseAmplitude, float period = DefaultEasePeriod)
        {
            period = Max(1e-05f, period);
            period = Floor(1f / period + 1) - 1; //to segmentCount - 1
            if (period <= 0) { return ParabolicBounce(t * 0.5f, 1f); }

            amplitude *= 0.01f;
            if (amplitude == 1)
            {
                return ParabolicBounce(Repeat(t * period, 1), 1f);
            }
            float a = 1 - amplitude;
            float b = 1 + amplitude;

            // 0 -> (segmentCount - 1)
            float prevLength = period + a * (period - 1) * period * 0.5f;
            // segmentCount
            float lastLength = (1 + a * period) * 0.5f;

            t = t < 0 ? 0 : t * (prevLength + lastLength);

            float c = -2 * t;
            float discriminant = b * b - 4 * a * c;
            float segmentIndexExact = (-b + Sqrt(discriminant)) / (2 * a);

            float segmentIndex = Floor(segmentIndexExact);
            float segmentStart = segmentIndex + a * (segmentIndex - 1) * segmentIndex * 0.5f;
            float segmentWidth = 1 + a * segmentIndex;

            float h = CalculateBounceHeight(segmentIndex, period - 0.5f, amplitude);
            return ParabolicBounce((t - segmentStart) / segmentWidth, h);
        }
        [IN(LINE)]
        public static float OutBounce(float t, float amplitude = DefaultEaseAmplitude, float period = DefaultEasePeriod)
        {
            return 1 - InBounce(1 - t, amplitude, period);
        }
        [IN(LINE)]
        public static float InOutBounce(float t, float amplitude = DefaultEaseAmplitude, float period = DefaultEasePeriod)
        {
            return t < 0.5f
                ? InBounce(2 * t, amplitude, period) * 0.5f
                : 1 - InBounce(2 - 2 * t, amplitude, period) * 0.5f;
        }
        [IN(LINE)]
        public static float OutInBounce(float t, float amplitude = DefaultEaseAmplitude, float period = DefaultEasePeriod)
        {
            return t < 0.5f
                ? (1 - InBounce(1 - 2 * t, amplitude, period)) * 0.5f
                : (1 + InBounce(2 * t - 1, amplitude, period)) * 0.5f;
        }

        [IN(LINE)]
        private static float ParabolicBounce(float t, float height)
        {
            return 4 * height * t * (1 - t);
        }
        [IN(LINE)]
        private static float CalculateBounceHeight(float bounce, float totalBounces, float amplitude)
        {
            float progress = bounce / (totalBounces + 0.5f);
            return Pow(amplitude, 1 - progress);
        }
        #endregion


        #region Convert DOTween
        public static int ToDOTweenEase(this Ease ease)
        {
            switch ((EaseInternal)ease)
            {
                default:
                // Linear
                case EaseInternal.InLinear:
                case EaseInternal.OutLinear:
                case EaseInternal.InOutLinear:
                case EaseInternal.OutInLinear: return (int)DOTweenEaseLayout.Linear;

                // Sine
                case EaseInternal.InSine: return (int)DOTweenEaseLayout.InSine;
                case EaseInternal.OutSine: return (int)DOTweenEaseLayout.OutSine;
                case EaseInternal.InOutSine:
                case EaseInternal.OutInSine: return (int)DOTweenEaseLayout.InOutSine;

                // Quad
                case EaseInternal.InQuad: return (int)DOTweenEaseLayout.InQuad;
                case EaseInternal.OutQuad: return (int)DOTweenEaseLayout.OutQuad;
                case EaseInternal.InOutQuad:
                case EaseInternal.OutInQuad: return (int)DOTweenEaseLayout.InOutQuad;

                // Cubic
                case EaseInternal.InCubic: return (int)DOTweenEaseLayout.InCubic;
                case EaseInternal.OutCubic: return (int)DOTweenEaseLayout.OutCubic;
                case EaseInternal.InOutCubic:
                case EaseInternal.OutInCubic: return (int)DOTweenEaseLayout.InOutCubic;

                // Quart
                case EaseInternal.InQuart: return (int)DOTweenEaseLayout.InQuart;
                case EaseInternal.OutQuart: return (int)DOTweenEaseLayout.OutQuart;
                case EaseInternal.InOutQuart:
                case EaseInternal.OutInQuart: return (int)DOTweenEaseLayout.InOutQuart;

                // Quint
                case EaseInternal.InQuint: return (int)DOTweenEaseLayout.InQuint;
                case EaseInternal.OutQuint: return (int)DOTweenEaseLayout.OutQuint;
                case EaseInternal.InOutQuint:
                case EaseInternal.OutInQuint: return (int)DOTweenEaseLayout.InOutQuint;

                // Expo
                case EaseInternal.InExpo: return (int)DOTweenEaseLayout.InExpo;
                case EaseInternal.OutExpo: return (int)DOTweenEaseLayout.OutExpo;
                case EaseInternal.InOutExpo:
                case EaseInternal.OutInExpo: return (int)DOTweenEaseLayout.InOutExpo;

                // Circ
                case EaseInternal.InCirc: return (int)DOTweenEaseLayout.InCirc;
                case EaseInternal.OutCirc: return (int)DOTweenEaseLayout.OutCirc;
                case EaseInternal.InOutCirc:
                case EaseInternal.OutInCirc: return (int)DOTweenEaseLayout.InOutCirc;

                // Elastic
                case EaseInternal.InElastic: return (int)DOTweenEaseLayout.InElastic;
                case EaseInternal.OutElastic: return (int)DOTweenEaseLayout.OutElastic;
                case EaseInternal.InOutElastic:
                case EaseInternal.OutInElastic: return (int)DOTweenEaseLayout.InOutElastic;

                // Back
                case EaseInternal.InBack: return (int)DOTweenEaseLayout.InBack;
                case EaseInternal.OutBack: return (int)DOTweenEaseLayout.OutBack;
                case EaseInternal.InOutBack:
                case EaseInternal.OutInBack: return (int)DOTweenEaseLayout.InOutBack;

                // Bounce
                case EaseInternal.InBounce: return (int)DOTweenEaseLayout.InBounce;
                case EaseInternal.OutBounce: return (int)DOTweenEaseLayout.OutBounce;
                case EaseInternal.InOutBounce:
                case EaseInternal.OutInBounce: return (int)DOTweenEaseLayout.InOutBounce;
            }
        }
        public static unsafe Ease FromDOTweenEase<T>(T easeRaw) where T : unmanaged, System.Enum
        {
            DOTweenEaseLayout ease = *(DOTweenEaseLayout*)&easeRaw;
            switch (ease)
            {
                default:
                case DOTweenEaseLayout.None: return Ease.Linear;
                case DOTweenEaseLayout.Linear: return Ease.Linear;

                case DOTweenEaseLayout.InSine: return Ease.Linear;
                case DOTweenEaseLayout.OutSine: return Ease.Linear;
                case DOTweenEaseLayout.InOutSine: return Ease.Linear;

                case DOTweenEaseLayout.InQuad: return Ease.InQuad;
                case DOTweenEaseLayout.OutQuad: return Ease.OutQuad;
                case DOTweenEaseLayout.InOutQuad: return Ease.InOutQuad;

                case DOTweenEaseLayout.InCubic: return Ease.InCubic;
                case DOTweenEaseLayout.OutCubic: return Ease.OutCubic;
                case DOTweenEaseLayout.InOutCubic: return Ease.InOutCubic;

                case DOTweenEaseLayout.InQuart: return Ease.InQuart;
                case DOTweenEaseLayout.OutQuart: return Ease.OutQuart;
                case DOTweenEaseLayout.InOutQuart: return Ease.InOutQuart;

                case DOTweenEaseLayout.InQuint: return Ease.InQuint;
                case DOTweenEaseLayout.OutQuint: return Ease.OutQuint;
                case DOTweenEaseLayout.InOutQuint: return Ease.InOutQuint;

                case DOTweenEaseLayout.InExpo: return Ease.InExpo;
                case DOTweenEaseLayout.OutExpo: return Ease.OutExpo;
                case DOTweenEaseLayout.InOutExpo: return Ease.InOutExpo;

                case DOTweenEaseLayout.InCirc: return Ease.InCirc;
                case DOTweenEaseLayout.OutCirc: return Ease.OutCirc;
                case DOTweenEaseLayout.InOutCirc: return Ease.InOutCirc;

                case DOTweenEaseLayout.InElastic: return Ease.InElastic;
                case DOTweenEaseLayout.OutElastic: return Ease.OutElastic;
                case DOTweenEaseLayout.InOutElastic: return Ease.InOutElastic;

                case DOTweenEaseLayout.InBack: return Ease.InBack;
                case DOTweenEaseLayout.OutBack: return Ease.OutBack;
                case DOTweenEaseLayout.InOutBack: return Ease.InOutBack;

                case DOTweenEaseLayout.InBounce: return Ease.InBounce;
                case DOTweenEaseLayout.OutBounce: return Ease.OutBounce;
                case DOTweenEaseLayout.InOutBounce: return Ease.InOutBounce;
            }
        }
        public enum DOTweenEaseLayout
        {
            None,
            Linear,
            InSine,
            OutSine,
            InOutSine,
            InQuad,
            OutQuad,
            InOutQuad,
            InCubic,
            OutCubic,
            InOutCubic,
            InQuart,
            OutQuart,
            InOutQuart,
            InQuint,
            OutQuint,
            InOutQuint,
            InExpo,
            OutExpo,
            InOutExpo,
            InCirc,
            OutCirc,
            InOutCirc,
            InElastic,
            OutElastic,
            InOutElastic,
            InBack,
            OutBack,
            InOutBack,
            InBounce,
            OutBounce,
            InOutBounce,
        }
        #endregion

        #region Convert LitMotion
        public static int ToLitMotionEase(this Ease ease)
        {
            switch ((EaseInternal)ease)
            {
                default:
                // Linear
                case EaseInternal.InLinear:
                case EaseInternal.OutLinear:
                case EaseInternal.InOutLinear:
                case EaseInternal.OutInLinear: return (int)LitMotionEaseLayout.Linear;

                // Sine
                case EaseInternal.InSine: return (int)LitMotionEaseLayout.InSine;
                case EaseInternal.OutSine: return (int)LitMotionEaseLayout.OutSine;
                case EaseInternal.InOutSine:
                case EaseInternal.OutInSine: return (int)LitMotionEaseLayout.InOutSine;

                // Quad
                case EaseInternal.InQuad: return (int)LitMotionEaseLayout.InQuad;
                case EaseInternal.OutQuad: return (int)LitMotionEaseLayout.OutQuad;
                case EaseInternal.InOutQuad:
                case EaseInternal.OutInQuad: return (int)LitMotionEaseLayout.InOutQuad;

                // Cubic
                case EaseInternal.InCubic: return (int)LitMotionEaseLayout.InCubic;
                case EaseInternal.OutCubic: return (int)LitMotionEaseLayout.OutCubic;
                case EaseInternal.InOutCubic:
                case EaseInternal.OutInCubic: return (int)LitMotionEaseLayout.InOutCubic;

                // Quart
                case EaseInternal.InQuart: return (int)LitMotionEaseLayout.InQuart;
                case EaseInternal.OutQuart: return (int)LitMotionEaseLayout.OutQuart;
                case EaseInternal.InOutQuart:
                case EaseInternal.OutInQuart: return (int)LitMotionEaseLayout.InOutQuart;

                // Quint
                case EaseInternal.InQuint: return (int)LitMotionEaseLayout.InQuint;
                case EaseInternal.OutQuint: return (int)LitMotionEaseLayout.OutQuint;
                case EaseInternal.InOutQuint:
                case EaseInternal.OutInQuint: return (int)LitMotionEaseLayout.InOutQuint;

                // Expo
                case EaseInternal.InExpo: return (int)LitMotionEaseLayout.InExpo;
                case EaseInternal.OutExpo: return (int)LitMotionEaseLayout.OutExpo;
                case EaseInternal.InOutExpo:
                case EaseInternal.OutInExpo: return (int)LitMotionEaseLayout.InOutExpo;

                // Circ
                case EaseInternal.InCirc: return (int)LitMotionEaseLayout.InCirc;
                case EaseInternal.OutCirc: return (int)LitMotionEaseLayout.OutCirc;
                case EaseInternal.InOutCirc:
                case EaseInternal.OutInCirc: return (int)LitMotionEaseLayout.InOutCirc;

                // Elastic
                case EaseInternal.InElastic: return (int)LitMotionEaseLayout.InElastic;
                case EaseInternal.OutElastic: return (int)LitMotionEaseLayout.OutElastic;
                case EaseInternal.InOutElastic:
                case EaseInternal.OutInElastic: return (int)LitMotionEaseLayout.InOutElastic;

                // Back
                case EaseInternal.InBack: return (int)LitMotionEaseLayout.InBack;
                case EaseInternal.OutBack: return (int)LitMotionEaseLayout.OutBack;
                case EaseInternal.InOutBack:
                case EaseInternal.OutInBack: return (int)LitMotionEaseLayout.InOutBack;

                // Bounce
                case EaseInternal.InBounce: return (int)LitMotionEaseLayout.InBounce;
                case EaseInternal.OutBounce: return (int)LitMotionEaseLayout.OutBounce;
                case EaseInternal.InOutBounce:
                case EaseInternal.OutInBounce: return (int)LitMotionEaseLayout.InOutBounce;
            }
        }
        public static unsafe Ease FromLitMotionEase<T>(T easeRaw) where T : unmanaged, System.Enum
        {
            LitMotionEaseLayout ease = *(LitMotionEaseLayout*)&easeRaw;
            switch (ease)
            {
                default:
                case LitMotionEaseLayout.Linear: return Ease.Linear;

                case LitMotionEaseLayout.InSine: return Ease.Linear;
                case LitMotionEaseLayout.OutSine: return Ease.Linear;
                case LitMotionEaseLayout.InOutSine: return Ease.Linear;

                case LitMotionEaseLayout.InQuad: return Ease.InQuad;
                case LitMotionEaseLayout.OutQuad: return Ease.OutQuad;
                case LitMotionEaseLayout.InOutQuad: return Ease.InOutQuad;

                case LitMotionEaseLayout.InCubic: return Ease.InCubic;
                case LitMotionEaseLayout.OutCubic: return Ease.OutCubic;
                case LitMotionEaseLayout.InOutCubic: return Ease.InOutCubic;

                case LitMotionEaseLayout.InQuart: return Ease.InQuart;
                case LitMotionEaseLayout.OutQuart: return Ease.OutQuart;
                case LitMotionEaseLayout.InOutQuart: return Ease.InOutQuart;

                case LitMotionEaseLayout.InQuint: return Ease.InQuint;
                case LitMotionEaseLayout.OutQuint: return Ease.OutQuint;
                case LitMotionEaseLayout.InOutQuint: return Ease.InOutQuint;

                case LitMotionEaseLayout.InExpo: return Ease.InExpo;
                case LitMotionEaseLayout.OutExpo: return Ease.OutExpo;
                case LitMotionEaseLayout.InOutExpo: return Ease.InOutExpo;

                case LitMotionEaseLayout.InCirc: return Ease.InCirc;
                case LitMotionEaseLayout.OutCirc: return Ease.OutCirc;
                case LitMotionEaseLayout.InOutCirc: return Ease.InOutCirc;

                case LitMotionEaseLayout.InElastic: return Ease.InElastic;
                case LitMotionEaseLayout.OutElastic: return Ease.OutElastic;
                case LitMotionEaseLayout.InOutElastic: return Ease.InOutElastic;

                case LitMotionEaseLayout.InBack: return Ease.InBack;
                case LitMotionEaseLayout.OutBack: return Ease.OutBack;
                case LitMotionEaseLayout.InOutBack: return Ease.InOutBack;

                case LitMotionEaseLayout.InBounce: return Ease.InBounce;
                case LitMotionEaseLayout.OutBounce: return Ease.OutBounce;
                case LitMotionEaseLayout.InOutBounce: return Ease.InOutBounce;
            }
        }
        public enum LitMotionEaseLayout
        {
            Linear,
            InSine,
            OutSine,
            InOutSine,
            InQuad,
            OutQuad,
            InOutQuad,
            InCubic,
            OutCubic,
            InOutCubic,
            InQuart,
            OutQuart,
            InOutQuart,
            InQuint,
            OutQuint,
            InOutQuint,
            InExpo,
            OutExpo,
            InOutExpo,
            InCirc,
            OutCirc,
            InOutCirc,
            InElastic,
            OutElastic,
            InOutElastic,
            InBack,
            OutBack,
            InOutBack,
            InBounce,
            OutBounce,
            InOutBounce,
        }
        #endregion

        #region Convert Unity AnimationCurve
#if UNITY_5_3_OR_NEWER
        private static AnimationCurve _unityCurveNone;
        private static AnimationCurve _unityCurveLinear;

        private static AnimationCurve _unityCurveInSine;
        private static AnimationCurve _unityCurveOutSine;
        private static AnimationCurve _unityCurveInOutSine;
        private static AnimationCurve _unityCurveOutInSine;

        private static AnimationCurve _unityCurveInQuad;
        private static AnimationCurve _unityCurveOutQuad;
        private static AnimationCurve _unityCurveInOutQuad;
        private static AnimationCurve _unityCurveOutInQuad;

        private static AnimationCurve _unityCurveInCubic;
        private static AnimationCurve _unityCurveOutCubic;
        private static AnimationCurve _unityCurveInOutCubic;
        private static AnimationCurve _unityCurveOutInCubic;

        private static AnimationCurve _unityCurveInQuart;
        private static AnimationCurve _unityCurveOutQuart;
        private static AnimationCurve _unityCurveInOutQuart;
        private static AnimationCurve _unityCurveOutInQuart;

        private static AnimationCurve _unityCurveInQuint;
        private static AnimationCurve _unityCurveOutQuint;
        private static AnimationCurve _unityCurveInOutQuint;
        private static AnimationCurve _unityCurveOutInQuint;

        private static AnimationCurve _unityCurveInExpo;
        private static AnimationCurve _unityCurveOutExpo;
        private static AnimationCurve _unityCurveInOutExpo;
        private static AnimationCurve _unityCurveOutInExpo;

        private static AnimationCurve _unityCurveInCirc;
        private static AnimationCurve _unityCurveOutCirc;
        private static AnimationCurve _unityCurveInOutCirc;
        private static AnimationCurve _unityCurveOutInCirc;

        private static AnimationCurve _unityCurveInElastic;
        private static AnimationCurve _unityCurveOutElastic;
        private static AnimationCurve _unityCurveInOutElastic;
        private static AnimationCurve _unityCurveOutInElastic;

        private static AnimationCurve _unityCurveInBack;
        private static AnimationCurve _unityCurveOutBack;
        private static AnimationCurve _unityCurveInOutBack;
        private static AnimationCurve _unityCurveOutInBack;

        private static AnimationCurve _unityCurveInBounce;
        private static AnimationCurve _unityCurveOutBounce;
        private static AnimationCurve _unityCurveInOutBounce;
        private static AnimationCurve _unityCurveOutInBounce;

        public static AnimationCurve CreateUnityCurve(this Ease ease)
        {
            return new AnimationCurve(ease.ToUnityCurve().keys);
        }
        public static AnimationCurve ToUnityCurve(this Ease ease)
        {
            switch ((EaseInternal)ease)
            {
                default:
                // None
                case EaseInternal.InNone:
                case EaseInternal.OutNone:
                case EaseInternal.InOutNone:
                case EaseInternal.OutInNone: return _unityCurveNone ??= AnimationCurve.Linear(0, 0, 0, 0);

                // Linear
                case EaseInternal.InLinear:
                case EaseInternal.OutLinear:
                case EaseInternal.InOutLinear:
                case EaseInternal.OutInLinear: return _unityCurveLinear ??= AnimationCurve.Linear(0, 0, 1, 1);

                // Sine
                case EaseInternal.InSine: return _unityCurveInSine ??= new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f, 0f, -0.001208493f, 0f, 0.36078f), new Keyframe(1f, 1f, 1.572508f, 0f, 0.326514f, 0f), });
                case EaseInternal.OutSine: return _unityCurveOutSine ??= new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f, 0f, 1.573552f, 0f, 0.330931f), new Keyframe(1f, 1f, -0.0009282457f, 0f, 0.358689f, 0f), });
                case EaseInternal.InOutSine: return _unityCurveInOutSine ??= new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f, 0f, -0.001202949f, 0f, 0.36078f), new Keyframe(0.5f, 0.5f, 1.572508f, 1.573372f, 0.326514f, 0.33093f), new Keyframe(1f, 1f, -0.0009312395f, 0f, 0.358688f, 0f), });
                case EaseInternal.OutInSine: return _unityCurveOutInSine ??= new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f, 1.50548f, 1.50548f, 0.3333333f, 0.3333333f), new Keyframe(0.1600001f, 0.240877f, 1.399913f, 1.399913f, 0.3333333f, 0.3333333f), new Keyframe(0.2220003f, 0.3211266f, 1.20002f, 1.20002f, 0.3333333f, 0.3333333f), new Keyframe(0.2799999f, 0.3852566f, 0.9926128f, 0.9926128f, 0.3333333f, 0.3333333f), new Keyframe(0.3409992f, 0.4389073f, 0.7501102f, 0.7501102f, 0.3333333f, 0.3333333f), new Keyframe(0.3999984f, 0.4755275f, 0.487473f, 0.487473f, 0.3333333f, 0.3333333f), new Keyframe(0.4549977f, 0.4950113f, 0.2259122f, 0.2259122f, 0.3333333f, 0.3333333f), new Keyframe(0.5319967f, 0.502524f, 0.1812712f, 0.1812712f, 0.3333333f, 0.3333333f), new Keyframe(0.5759962f, 0.5141827f, 0.3807511f, 0.3807511f, 0.3333333f, 0.3333333f), new Keyframe(0.6289955f, 0.5404983f, 0.6175001f, 0.6175001f, 0.3333333f, 0.3333333f), new Keyframe(0.6829948f, 0.5803753f, 0.8613304f, 0.8613304f, 0.3333333f, 0.3333333f), new Keyframe(0.7489939f, 0.6453309f, 1.102256f, 1.102256f, 0.3333333f, 0.3333333f), new Keyframe(0.818993f, 0.7307524f, 1.353911f, 1.353911f, 0.3333333f, 0.3333333f), new Keyframe(1f, 1f, 1.487499f, 1.487499f, 0.3333333f, 0.3333333f), });

                // Quad
                case EaseInternal.InQuad: return _unityCurveInQuad ??= new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f, 0f, 0f, 0f, 0.333333f), new Keyframe(1f, 1f, 2.000003f, 0f, 0.333333f, 0f), });
                case EaseInternal.OutQuad: return _unityCurveOutQuad ??= new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f, 0f, 2.000003f, 0f, 0.333333f), new Keyframe(1f, 1f, 0f, 0f, 0.333333f, 0f), });
                case EaseInternal.InOutQuad: return _unityCurveInOutQuad ??= new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f, 0f, 0f, 0f, 0.333334f), new Keyframe(0.5f, 0.5f, 1.999994f, 1.999994f, 0.333334f, 0.333334f), new Keyframe(1f, 1f, 0f, 0f, 0.333334f, 0f), });
                case EaseInternal.OutInQuad: return _unityCurveOutInQuad ??= new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f, 1.876f, 1.876f, 0.3333333f, 0.3333333f), new Keyframe(0.06199995f, 0.1163119f, 1.751f, 1.751f, 0.3333333f, 0.3333333f), new Keyframe(0.1250001f, 0.2187501f, 1.501f, 1.501f, 0.3333333f, 0.3333333f), new Keyframe(0.1870002f, 0.3040622f, 1.250999f, 1.250999f, 0.3333333f, 0.3333333f), new Keyframe(0.2500003f, 0.3750003f, 0.9949998f, 0.9949998f, 0.3333333f, 0.3333333f), new Keyframe(0.3179995f, 0.4337516f, 0.7290023f, 0.7290023f, 0.3333333f, 0.3333333f), new Keyframe(0.3849986f, 0.4735494f, 0.4630056f, 0.4630056f, 0.3333333f, 0.3333333f), new Keyframe(0.4489978f, 0.4947976f, 0.2111176f, 0.2111176f, 0.3333333f, 0.3333333f), new Keyframe(0.5369967f, 0.5027375f, 0.1691064f, 0.1691064f, 0.3333333f, 0.3333333f), new Keyframe(0.586996f, 0.5151366f, 0.3589838f, 0.3589838f, 0.3333333f, 0.3333333f), new Keyframe(0.6479952f, 0.5438052f, 0.5909812f, 0.5909812f, 0.3333333f, 0.3333333f), new Keyframe(0.7079945f, 0.5865234f, 0.8449775f, 0.8449775f, 0.3333333f, 0.3333333f), new Keyframe(0.7809935f, 0.6579147f, 1.123974f, 1.123974f, 0.3333333f, 0.3333333f), new Keyframe(0.8539926f, 0.7506215f, 1.415971f, 1.415971f, 0.3333333f, 0.3333333f), new Keyframe(0.9269916f, 0.8646438f, 1.707976f, 1.707976f, 0.3333333f, 0.3333333f), new Keyframe(1f, 1f, 1.853983f, 1.853983f, 0.3333333f, 0.3333333f), });

                // Cubic
                case EaseInternal.InCubic: return _unityCurveInCubic ??= new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f, 0f, 0f, 0f, 0.333333f), new Keyframe(1f, 1f, 3.000003f, 0f, 0.333333f, 0f), });
                case EaseInternal.OutCubic: return _unityCurveOutCubic ??= new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f, 0f, 3.000003f, 0f, 0.333333f), new Keyframe(1f, 1f, 0f, 0f, 0.333333f, 0f), });
                case EaseInternal.InOutCubic: return _unityCurveInOutCubic ??= new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f, 0f, 0f, 0f, 0.333334f), new Keyframe(0.5f, 0.5f, 2.999994f, 2.999994f, 0.333334f, 0.333334f), new Keyframe(1f, 1f, 0f, 0f, 0.333334f, 0f), });
                case EaseInternal.OutInCubic: return _unityCurveOutInCubic ??= new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f, 2.665456f, 2.665456f, 0.3333333f, 0.3333333f), new Keyframe(0.05799996f, 0.1545963f, 2.352992f, 2.352992f, 0.3333333f, 0.3333333f), new Keyframe(0.1180001f, 0.2770282f, 1.759349f, 1.759349f, 0.3333333f, 0.3333333f), new Keyframe(0.1810002f, 0.3701532f, 1.228747f, 1.228747f, 0.3333333f, 0.3333333f), new Keyframe(0.2490003f, 0.4367473f, 0.7857753f, 0.7857753f, 0.3333333f, 0.3333333f), new Keyframe(0.3079996f, 0.4716883f, 0.4508696f, 0.4508696f, 0.3333333f, 0.3333333f), new Keyframe(0.3729987f, 0.4918062f, 0.2114633f, 0.2114633f, 0.3333333f, 0.3333333f), new Keyframe(0.4359979f, 0.4989513f, 0.06805319f, 0.06805319f, 0.3333333f, 0.3333333f), new Keyframe(0.5829961f, 0.5022869f, 0.1004769f, 0.1004769f, 0.3333333f, 0.3333333f), new Keyframe(0.6569951f, 0.5154781f, 0.3115331f, 0.3115331f, 0.3333333f, 0.3333333f), new Keyframe(0.7259942f, 0.5461692f, 0.6222044f, 0.6222044f, 0.3333333f, 0.3333333f), new Keyframe(0.7889934f, 0.5965437f, 1.004278f, 1.004278f, 0.3333333f, 0.3333333f), new Keyframe(0.8449927f, 0.6642441f, 1.436203f, 1.436203f, 0.3333333f, 0.3333333f), new Keyframe(0.898992f, 0.7540695f, 1.914187f, 1.914187f, 0.3333333f, 0.3333333f), new Keyframe(0.9499913f, 0.8644789f, 2.437436f, 2.437436f, 0.3333333f, 0.3333333f), new Keyframe(1f, 1f, 2.709952f, 2.709952f, 0.3333333f, 0.3333333f), });

                // Quart
                case EaseInternal.InQuart: return _unityCurveInQuart ??= new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f, 0f, 0.0139424f, 0f, 0.434789f), new Keyframe(1f, 1f, 3.985819f, 0f, 0.269099f, 0f), });
                case EaseInternal.OutQuart: return _unityCurveOutQuart ??= new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f, 0f, 3.985823f, 0f, 0.269099f), new Keyframe(1f, 1f, 0.01394233f, 0f, 0.434789f, 0f), });
                case EaseInternal.InOutQuart: return _unityCurveInOutQuart ??= new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f, 0f, 0.01394243f, 0f, 0.434788f), new Keyframe(0.5f, 0.5f, 3.985842f, 3.985834f, 0.269098f, 0.269098f), new Keyframe(1f, 1f, 0.0139425f, 0f, 0.434788f, 0f), });
                case EaseInternal.OutInQuart: return _unityCurveOutInQuart ??= new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f, 3.45998f, 3.45998f, 0.3333333f, 0.3333333f), new Keyframe(0.04799997f, 0.1660789f, 2.971538f, 2.971538f, 0.3333333f, 0.3333333f), new Keyframe(0.1f, 0.2952f, 2.069876f, 2.069876f, 0.3333333f, 0.3333333f), new Keyframe(0.1560001f, 0.3879729f, 1.321569f, 1.321569f, 0.3333333f, 0.3333333f), new Keyframe(0.2190003f, 0.4501215f, 0.756956f, 0.756956f, 0.3333333f, 0.3333333f), new Keyframe(0.274f, 0.4791299f, 0.381305f, 0.381305f, 0.3333333f, 0.3333333f), new Keyframe(0.3409992f, 0.4948868f, 0.129308f, 0.129308f, 0.3333333f, 0.3333333f), new Keyframe(0.6109957f, 0.5012143f, 0.06936252f, 0.06936252f, 0.3333333f, 0.3333333f), new Keyframe(0.6889947f, 0.5102068f, 0.239189f, 0.239189f, 0.3333333f, 0.3333333f), new Keyframe(0.7569938f, 0.5348964f, 0.5596648f, 0.5596648f, 0.3333333f, 0.3333333f), new Keyframe(0.8149931f, 0.5787579f, 1.016198f, 1.016198f, 0.3333333f, 0.3333333f), new Keyframe(0.8669924f, 0.645117f, 1.594229f, 1.594229f, 0.3333333f, 0.3333333f), new Keyframe(0.9139918f, 0.7349941f, 2.28556f, 2.28556f, 0.3333333f, 0.3333333f), new Keyframe(0.9579912f, 0.8519806f, 3.091177f, 3.091177f, 0.3333333f, 0.3333333f), new Keyframe(1f, 1f, 3.523537f, 3.523537f, 0.3333333f, 0.3333333f), });

                // Quint
                case EaseInternal.InQuint: return _unityCurveInQuint ??= new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f, 0f, 0.02411811f, 0f, 0.519568f), new Keyframe(1f, 1f, 4.951815f, 0f, 0.225963f, 0f), });
                case EaseInternal.OutQuint: return _unityCurveOutQuint ??= new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f, 0f, 4.953289f, 0f, 0.225963f), new Keyframe(1f, 1f, 0.02414908f, 0f, 0.518901f, 0f), });
                case EaseInternal.InOutQuint: return _unityCurveInOutQuint ??= new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f, 0f, 0.02412004f, 0f, 0.519568f), new Keyframe(0.5f, 0.5f, 4.951789f, 4.953269f, 0.225964f, 0.225964f), new Keyframe(1f, 1f, 0.02415099f, 0f, 0.5189019f, 0f), });
                case EaseInternal.OutInQuint: return _unityCurveOutInQuint ??= new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f, 4.330001f, 4.330001f, 0.3333333f, 0.3333333f), new Keyframe(0.03599999f, 0.15588f, 3.732531f, 3.732531f, 0.3333333f, 0.3333333f), new Keyframe(0.07499997f, 0.2781473f, 2.633865f, 2.633865f, 0.3333333f, 0.3333333f), new Keyframe(0.1180001f, 0.3698523f, 1.729284f, 1.729284f, 0.3333333f, 0.3333333f), new Keyframe(0.1660002f, 0.4334955f, 1.023763f, 1.023763f, 0.3333333f, 0.3333333f), new Keyframe(0.2200003f, 0.4724635f, 0.5150232f, 0.5150232f, 0.3333333f, 0.3333333f), new Keyframe(0.2859999f, 0.4928189f, 0.1951178f, 0.1951178f, 0.3333333f, 0.3333333f), new Keyframe(0.3649988f, 0.4992825f, 0.04744737f, 0.04744737f, 0.3333333f, 0.3333333f), new Keyframe(0.6849948f, 0.5034667f, 0.1010192f, 0.1010192f, 0.3333333f, 0.3333333f), new Keyframe(0.7509939f, 0.5159381f, 0.3359873f, 0.3359873f, 0.3333333f, 0.3333333f), new Keyframe(0.8039932f, 0.5415374f, 0.6602474f, 0.6602474f, 0.3333333f, 0.3333333f), new Keyframe(0.8349928f, 0.567499f, 1.014021f, 1.014021f, 0.3333333f, 0.3333333f), new Keyframe(0.8629925f, 0.6008343f, 1.514281f, 1.514281f, 0.3333333f, 0.3333333f), new Keyframe(0.9139918f, 0.6945713f, 2.378709f, 2.378709f, 0.3333333f, 0.3333333f), new Keyframe(0.9589912f, 0.8259432f, 3.581897f, 3.581897f, 0.3333333f, 0.3333333f), new Keyframe(1f, 1f, 4.24438f, 4.24438f, 0.3333333f, 0.3333333f), });

                // Expo
                case EaseInternal.InExpo: return _unityCurveInExpo ??= new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f, 0f, 0.03124388f, 0f, 0.636963f), new Keyframe(1f, 1f, 6.815432f, 0f, 0.155667f, 0f), });
                case EaseInternal.OutExpo: return _unityCurveOutExpo ??= new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f, 0f, 6.815433f, 0f, 0.155667f), new Keyframe(1f, 1f, 0.03124354f, 0f, 0.636963f, 0f), });
                case EaseInternal.InOutExpo: return _unityCurveInOutExpo ??= new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f, 0f, 0.03124509f, 0f, 0.636964f), new Keyframe(0.5f, 0.5f, 6.815477f, 6.815476f, 0.155666f, 0.155666f), new Keyframe(1f, 1f, 0.03124377f, 0f, 0.636964f, 0f), });
                case EaseInternal.OutInExpo: return _unityCurveOutInExpo ??= new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f, 5.744604f, 5.744604f, 0.3333333f, 0.3333333f), new Keyframe(0.028f, 0.1608489f, 4.783195f, 4.783195f, 0.3333333f, 0.3333333f), new Keyframe(0.05899996f, 0.2793241f, 3.107495f, 3.107495f, 0.3333333f, 0.3333333f), new Keyframe(0.09600002f, 0.3678728f, 1.88221f, 1.88221f, 0.3333333f, 0.3333333f), new Keyframe(0.1400001f, 0.4282064f, 1.035915f, 1.035915f, 0.3333333f, 0.3333333f), new Keyframe(0.1940002f, 0.4660396f, 0.4992211f, 0.4992211f, 0.3333333f, 0.3333333f), new Keyframe(0.2660001f, 0.4874833f, 0.1971408f, 0.1971408f, 0.3333333f, 0.3333333f), new Keyframe(0.3609989f, 0.4966462f, 0.06458478f, 0.06458478f, 0.3333333f, 0.3333333f), new Keyframe(0.6989946f, 0.5077044f, 0.1110358f, 0.1110358f, 0.3333333f, 0.3333333f), new Keyframe(0.7749936f, 0.5220951f, 0.3261757f, 0.3261757f, 0.3333333f, 0.3333333f), new Keyframe(0.8309929f, 0.5480226f, 0.6442649f, 0.6442649f, 0.3333333f, 0.3333333f), new Keyframe(0.8609925f, 0.5727883f, 1.020204f, 1.020204f, 0.3333333f, 0.3333333f), new Keyframe(0.8869922f, 0.6043746f, 1.604182f, 1.604182f, 0.3333333f, 0.3333333f), new Keyframe(0.9309916f, 0.692087f, 2.73636f, 2.73636f, 0.3333333f, 0.3333333f), new Keyframe(0.9679911f, 0.8208169f, 4.538574f, 4.538574f, 0.3333333f, 0.3333333f), new Keyframe(1f, 1f, 5.597916f, 5.597916f, 0.3333333f, 0.3333333f), });

                // Circ
                case EaseInternal.InCirc: return _unityCurveInCirc ??= new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f, 0f, 0.002162338f, 0f, 0.55403f), new Keyframe(1f, 1f, 459.267f, 0f, 0.001197994f, 0f), });
                case EaseInternal.OutCirc: return _unityCurveOutCirc ??= new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f, 0f, 461.7679f, 0f, 0.001198f), new Keyframe(1f, 1f, 0.00216235f, 0f, 0.554024f, 0f), });
                case EaseInternal.InOutCirc: return _unityCurveInOutCirc ??= new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f, 0f, 0.002162353f, 0f, 0.554026f), new Keyframe(0.5f, 0.5f, 461.7703f, 461.7474f, 0.001197994f, 0.001198053f), new Keyframe(1f, 1f, 0.00216245f, 0f, 0.554026f, 0f), });
                case EaseInternal.OutInCirc: return _unityCurveOutInCirc ??= new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f, 8.713385f, 8.713385f, 0.3333333f, 0.3333333f), new Keyframe(0.013f, 0.113274f, 5.750962f, 5.750962f, 0.3333333f, 0.3333333f), new Keyframe(0.05199997f, 0.222027f, 2.164071f, 2.164071f, 0.3333333f, 0.3333333f), new Keyframe(0.1150001f, 0.319022f, 1.248537f, 1.248537f, 0.3333333f, 0.3333333f), new Keyframe(0.1980002f, 0.3984923f, 0.7882434f, 0.7882434f, 0.3333333f, 0.3333333f), new Keyframe(0.278f, 0.4480134f, 0.5015587f, 0.5015587f, 0.3333333f, 0.3333333f), new Keyframe(0.3649988f, 0.4814298f, 0.2907181f, 0.2907181f, 0.3333333f, 0.3333333f), new Keyframe(0.4419979f, 0.4966244f, 0.1345652f, 0.1345652f, 0.3333333f, 0.3333333f), new Keyframe(0.5809961f, 0.506604f, 0.170126f, 0.170126f, 0.3333333f, 0.3333333f), new Keyframe(0.6769949f, 0.5323753f, 0.3872727f, 0.3872727f, 0.3333333f, 0.3333333f), new Keyframe(0.7719936f, 0.5804533f, 0.65813f, 0.65813f, 0.3333333f, 0.3333333f), new Keyframe(0.8539926f, 0.6468863f, 1.015686f, 1.015686f, 0.3333333f, 0.3333333f), new Keyframe(0.9159918f, 0.7225999f, 1.54738f, 1.54738f, 0.3333333f, 0.3333333f), new Keyframe(0.9619912f, 0.8087825f, 2.57383f, 2.57383f, 0.3333333f, 0.3333333f), new Keyframe(0.9899908f, 0.9004561f, 6.609685f, 6.609685f, 0.3333333f, 0.3333333f), new Keyframe(1f, 1f, 9.945268f, 9.945268f, 0.3333333f, 0.3333333f), });

                // Elastic
                case EaseInternal.InElastic: return _unityCurveInElastic ??= new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f, 0f, 0.0143284f, 0f, 1f), new Keyframe(0.175f, 0f, 0f, -0.06879552f, 0.008331452f, 0.8916667f), new Keyframe(0.475f, 0f, -0.4081632f, -0.5503653f, 0.4083333f, 0.8666668f), new Keyframe(0.775f, 0f, -3.26241f, -4.402922f, 0.3916665f, 0.5916666f), new Keyframe(1f, 1f, 12.51956f, 0f, 0.5916666f, 0f), });
                case EaseInternal.OutElastic: return _unityCurveOutElastic ??= new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f, 0f, 12.51956f, 0f, 0.5916667f), new Keyframe(0.225f, 1f, -4.402922f, -3.262408f, 0.5916666f, 0.3916667f), new Keyframe(0.525f, 1f, -0.5503654f, -0.4081634f, 0.8666667f, 0.4083333f), new Keyframe(0.825f, 1f, -0.06879558f, 0f, 0.8916666f, 0.008331367f), new Keyframe(1f, 1f, 0.01432861f, 0f, 1f, 0f), });
                case EaseInternal.InOutElastic: return _unityCurveInOutElastic ??= new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f, 0f, 0.01433143f, 0f, 1f), new Keyframe(0.0875f, 0f, 0f, -0.06879253f, 0.008331452f, 0.8916667f), new Keyframe(0.2375f, 0f, -0.4081632f, -0.5503692f, 0.4083333f, 0.8666668f), new Keyframe(0.3875f, 0f, -3.262419f, -4.402895f, 0.3916665f, 0.5916712f), new Keyframe(0.5f, 0.5f, 12.51967f, 12.51958f, 0.5916621f, 0.5916664f), new Keyframe(0.6125f, 1f, -4.402927f, -3.262402f, 0.5916669f, 0.3916666f), new Keyframe(0.7625f, 1f, -0.5503691f, -0.4081627f, 0.8666668f, 0.4083335f), new Keyframe(0.9125f, 1f, -0.06879289f, 0f, 0.8916666f, 0.008331029f), new Keyframe(1f, 1f, 0.01432828f, 0f, 1f, 0f), });
                case EaseInternal.OutInElastic: return _unityCurveOutInElastic ??= new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f, 13.09082f, 13.09082f, 0.3333333f, 0.3333333f), new Keyframe(0.04299998f, 0.5629051f, 10.53881f, 10.53881f, 0.3333333f, 0.3333333f), new Keyframe(0.05399996f, 0.6507598f, 5.57284f, 5.57284f, 0.3333333f, 0.3333333f), new Keyframe(0.06499995f, 0.6855074f, 1.304553f, 1.304553f, 0.3333333f, 0.3333333f), new Keyframe(0.07299997f, 0.6811092f, -1.746875f, -1.746875f, 0.3333333f, 0.3333333f), new Keyframe(0.08099999f, 0.6575573f, -3.867259f, -3.867259f, 0.3333333f, 0.3333333f), new Keyframe(0.1200001f, 0.4707259f, -3.690704f, -3.690704f, 0.3333333f, 0.3333333f), new Keyframe(0.1300001f, 0.4448172f, -1.779534f, -1.779534f, 0.3333333f, 0.3333333f), new Keyframe(0.1410001f, 0.4341669f, -0.1236582f, -0.1236582f, 0.3333333f, 0.3333333f), new Keyframe(0.1570001f, 0.4457011f, 1.217627f, 1.217627f, 0.3333333f, 0.3333333f), new Keyframe(0.1940002f, 0.5091329f, 1.205191f, 1.205191f, 0.3333333f, 0.3333333f), new Keyframe(0.2140003f, 0.5230532f, 0.2492215f, 0.2492215f, 0.3333333f, 0.3333333f), new Keyframe(0.2310003f, 0.5196945f, -0.3958523f, -0.3958523f, 0.3333333f, 0.3333333f), new Keyframe(0.2710001f, 0.4959292f, -0.4010276f, -0.4010276f, 0.3333333f, 0.3333333f), new Keyframe(0.2909998f, 0.4917709f, -0.02522608f, -0.02522608f, 0.3333333f, 0.3333333f), new Keyframe(0.3609989f, 0.5027934f, 0.06834626f, 0.06834626f, 0.3333333f, 0.3333333f), new Keyframe(0.6349954f, 0.4971014f, 0.06094041f, 0.06094041f, 0.3333333f, 0.3333333f), new Keyframe(0.7119944f, 0.5080857f, -0.1464642f, -0.1464642f, 0.3333333f, 0.3333333f), new Keyframe(0.7839935f, 0.4767241f, 0.07606834f, 0.07606834f, 0.3333333f, 0.3333333f), new Keyframe(0.8039932f, 0.4884783f, 1.134078f, 1.134078f, 0.3333333f, 0.3333333f), new Keyframe(0.8439927f, 0.5556949f, 1.120004f, 1.120004f, 0.3333333f, 0.3333333f), new Keyframe(0.8609925f, 0.5652075f, -0.314763f, -0.314763f, 0.3333333f, 0.3333333f), new Keyframe(0.8709924f, 0.5533167f, -1.967482f, -1.967482f, 0.3333333f, 0.3333333f), new Keyframe(0.8809922f, 0.5258583f, -3.797368f, -3.797368f, 0.3333333f, 0.3333333f), new Keyframe(0.9179918f, 0.3464525f, -4.019552f, -4.019552f, 0.3333333f, 0.3333333f), new Keyframe(0.9259917f, 0.3209309f, -2.041322f, -2.041322f, 0.3333333f, 0.3333333f), new Keyframe(0.9339916f, 0.3137918f, 1.02884f, 1.02884f, 0.3333333f, 0.3333333f), new Keyframe(0.9459914f, 0.3491924f, 5.466541f, 5.466541f, 0.3333333f, 0.3333333f), new Keyframe(0.9569913f, 0.4370041f, 10.53663f, 10.53663f, 0.3333333f, 0.3333333f), new Keyframe(1f, 1f, 13.09026f, 13.09026f, 0.3333333f, 0.3333333f), });

                // Back
                case EaseInternal.InBack: return _unityCurveInBack ??= new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f, 0f, 0f, 0f, 0.333333f), new Keyframe(1f, 1f, 4.701583f, 0f, 0.333333f, 0f), });
                case EaseInternal.OutBack: return _unityCurveOutBack ??= new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f, 0f, 4.701584f, 0f, 0.333333f), new Keyframe(1f, 1f, 0f, 0f, 0.333333f, 0f), });
                case EaseInternal.InOutBack: return _unityCurveInOutBack ??= new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f, 0f, 0f, 0f, 0.333334f), new Keyframe(0.5f, 0.5f, 5.594898f, 5.594899f, 0.333334f, 0.333334f), new Keyframe(1f, 1f, 0f, 0f, 0.333334f, 0f), });
                case EaseInternal.OutInBack: return _unityCurveOutInBack ??= new AnimationCurve(new Keyframe[] { new Keyframe(0f, 1.110223E-16f, 4.159023f, 4.159023f, 0f, 0.3333333f), new Keyframe(0.04399998f, 0.1829969f, 3.647901f, 3.647901f, 0.3333333f, 0.3333333f), new Keyframe(0.09f, 0.3272888f, 2.673029f, 2.673029f, 0.3333333f, 0.3333333f), new Keyframe(0.1380001f, 0.4333344f, 1.794815f, 1.794815f, 0.3333333f, 0.3333333f), new Keyframe(0.1900002f, 0.5051128f, 1.037488f, 1.037488f, 0.3333333f, 0.3333333f), new Keyframe(0.2410003f, 0.5405387f, 0.4266107f, 0.4266107f, 0.3333333f, 0.3333333f), new Keyframe(0.2989997f, 0.5497373f, -0.01107711f, -0.01107711f, 0.3333333f, 0.3333333f), new Keyframe(0.3459991f, 0.5412421f, -0.2508451f, -0.2508451f, 0.3333333f, 0.3333333f), new Keyframe(0.4589976f, 0.5049765f, -0.2264434f, -0.2264434f, 0.3333333f, 0.3333333f), new Keyframe(0.5489965f, 0.4931013f, -0.219433f, -0.219433f, 0.3333333f, 0.3333333f), new Keyframe(0.6809948f, 0.4525886f, -0.1597189f, -0.1597189f, 0.3333333f, 0.3333333f), new Keyframe(0.7329941f, 0.4519376f, 0.1850969f, 0.1850969f, 0.3333333f, 0.3333333f), new Keyframe(0.7779936f, 0.4691595f, 0.590108f, 0.590108f, 0.3333333f, 0.3333333f), new Keyframe(0.8089932f, 0.4938818f, 0.9988991f, 0.9988991f, 0.3333333f, 0.3333333f), new Keyframe(0.8389928f, 0.5298902f, 1.543002f, 1.543002f, 0.3333333f, 0.3333333f), new Keyframe(0.895992f, 0.6373742f, 2.402222f, 2.402222f, 0.3333333f, 0.3333333f), new Keyframe(0.9489914f, 0.7920651f, 3.497599f, 3.497599f, 0.3333333f, 0.3333333f), new Keyframe(1f, 1f, 4.076463f, 4.076463f, 0.3333333f, 0f), });

                // Bounce
                case EaseInternal.InBounce: return _unityCurveInBounce ??= new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f, 0f, 0.6874897f, 0f, 0.3333663f), new Keyframe(0.0909f, 0f, -0.687694f, 1.374792f, 0.3332673f, 0.3334159f), new Keyframe(0.2727f, 0f, -1.375608f, 2.749388f, 0.3332179f, 0.3333489f), new Keyframe(0.6364f, 0f, -2.749183f, 5.501642f, 0.3333737f, 0.3332673f), new Keyframe(1f, 1f, 0f, 0f, 0.3333663f, 0f), });
                case EaseInternal.OutBounce: return _unityCurveOutBounce ??= new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f, 0f, 0f, 0f, 0.3333663f), new Keyframe(0.3636f, 1f, 5.501643f, -2.749183f, 0.3332673f, 0.3333737f), new Keyframe(0.7273f, 1f, 2.749366f, -1.375609f, 0.3333516f, 0.3332178f), new Keyframe(0.9091f, 1f, 1.374792f, -0.6877043f, 0.3334158f, 0.3332673f), new Keyframe(1f, 1f, 0.6875f, 0f, 0.3333663f, 0f), });
                case EaseInternal.InOutBounce: return _unityCurveInOutBounce ??= new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f, 0f, 0.6875001f, 0f, 0.333011f), new Keyframe(0.0455f, 0f, -0.6854643f, 1.377057f, 0.334f, 0.3328713f), new Keyframe(0.1364f, 0f, -1.373381f, 2.751643f, 0.3337624f, 0.3331683f), new Keyframe(0.3182f, 0f, -2.749192f, 5.501634f, 0.3334654f, 0.3332673f), new Keyframe(0.5f, 0.5f, 0f, 0f, 0.3333663f, 0.3333663f), new Keyframe(0.6818f, 1f, 5.501634f, -2.749191f, 0.3332673f, 0.3334653f), new Keyframe(0.8636f, 1f, 2.751642f, -1.37338f, 0.3331683f, 0.3319367f), new Keyframe(0.955f, 1f, 1.354673f, -0.7087823f, 0.3365205f, 0.3266002f), new Keyframe(1f, 1f, 0.6875f, 0f, 0.3367105f, 0f), });
                case EaseInternal.OutInBounce: return _unityCurveOutInBounce ??= new AnimationCurve(new Keyframe[] { new Keyframe(0f, 0f, 0.33275f, 0.33275f, 0.3333333f, 0.3333333f), new Keyframe(0.022f, 0.007320501f, 0.6730623f, 0.6730623f, 0.3333333f, 0.3333333f), new Keyframe(0.04499998f, 0.0306281f, 1.535187f, 1.535187f, 0.3333333f, 0.3333333f), new Keyframe(0.09100001f, 0.1252501f, 2.745188f, 2.745188f, 0.3333333f, 0.3333333f), new Keyframe(0.1360001f, 0.2797524f, 4.105244f, 4.105244f, 0.3333333f, 0.3333333f), new Keyframe(0.1820002f, 0.4995f, 4.777112f, -2.396619f, 0.3333333f, 0.3333333f), new Keyframe(0.2050002f, 0.4443776f, -2.048743f, -2.048743f, 0.3333333f, 0.3333333f), new Keyframe(0.2280003f, 0.4052576f, -1.360554f, -1.360554f, 0.3333333f, 0.3333333f), new Keyframe(0.2500003f, 0.3828123f, -0.6799299f, -0.6799299f, 0.3333333f, 0.3333333f), new Keyframe(0.273f, 0.3750011f, 0.0006885529f, 0.0006885529f, 0.3333333f, 0.3333333f), new Keyframe(0.2949997f, 0.3825029f, 0.6813046f, 0.6813046f, 0.3333333f, 0.3333333f), new Keyframe(0.3179995f, 0.4059997f, 1.527165f, 1.527165f, 0.3333333f, 0.3333333f), new Keyframe(0.3639989f, 0.4995036f, 2.032717f, -1.031289f, 0.3333333f, 0.3333333f), new Keyframe(0.3859986f, 0.4768155f, -0.6909808f, -0.6909808f, 0.3333333f, 0.3333333f), new Keyframe(0.4089983f, 0.4687501f, -0.01036425f, -0.01036425f, 0.3333333f, 0.3333333f), new Keyframe(0.430998f, 0.4760088f, 0.6583821f, 0.6583821f, 0.3333333f, 0.3333333f), new Keyframe(0.4549977f, 0.4996922f, 0.3304357f, 0.3304357f, 0.3333333f, 0.3333333f), new Keyframe(0.4779974f, 0.4921955f, 0.02491324f, 0.02491324f, 0.3333333f, 0.3333333f), new Keyframe(0.5189969f, 0.507602f, 0.04768628f, 0.04768628f, 0.3333333f, 0.3333333f), new Keyframe(0.5449966f, 0.5003117f, 0.3729249f, 0.3729249f, 0.3333333f, 0.3333333f), new Keyframe(0.5659963f, 0.5218627f, 0.7386848f, 0.7386848f, 0.3333333f, 0.3333333f), new Keyframe(0.585996f, 0.5308849f, 0.1108088f, 0.1108088f, 0.3333333f, 0.3333333f), new Keyframe(0.6109957f, 0.5251475f, -0.6076199f, -0.6076199f, 0.3333333f, 0.3333333f), new Keyframe(0.6359954f, 0.5005043f, -0.98574f, 2.075445f, 0.3333333f, 0.3333333f), new Keyframe(0.6789948f, 0.5897473f, 1.616679f, 1.616679f, 0.3333333f, 0.3333333f), new Keyframe(0.6989946f, 0.6129053f, 0.8478519f, 0.8478519f, 0.3333333f, 0.3333333f), new Keyframe(0.7199943f, 0.6241987f, 0.1974846f, 0.1974846f, 0.3333333f, 0.3333333f), new Keyframe(0.743994f, 0.6207711f, -0.5133803f, -0.5133803f, 0.3333333f, 0.3333333f), new Keyframe(0.7689937f, 0.5986729f, -1.262059f, -1.262059f, 0.3333333f, 0.3333333f), new Keyframe(0.7939934f, 0.5576689f, -2.010737f, -2.010737f, 0.3333333f, 0.3333333f), new Keyframe(0.817993f, 0.5005186f, -2.381296f, 4.776113f, 0.3333333f, 0.3333333f), new Keyframe(0.8639925f, 0.7202169f, 4.104863f, 4.104863f, 0.3333333f, 0.3333333f), new Keyframe(0.9089919f, 0.8747275f, 2.745433f, 2.745433f, 0.3333333f, 0.3333333f), new Keyframe(0.9549913f, 0.96936f, 1.53545f, 1.53545f, 0.3333333f, 0.3333333f), new Keyframe(0.977991f, 0.9926735f, 0.673265f, 0.673265f, 0.3333333f, 0.3333333f), new Keyframe(1f, 1f, 0.3328856f, 0.3328856f, 0.3333333f, 0.3333333f), });
            }
        }
#endif
        #endregion
    }

    public delegate float EaseFunction(float t);
    public delegate float ExtendedEaseFunction(float time, float duration, float amplitude, float period);
}

#region EaseInternal
namespace DCFApixels.DataMath.Internal
{
    internal enum EaseInternal : uint
    {
        InNone = EaseInOutType.In,
        OutNone = EaseInOutType.Out,
        InOutNone = EaseInOutType.InOut,
        OutInNone = EaseInOutType.InOut + 1, // preserved EaseInOutType.OutIn

        InLinear = EaseType.Linear | InNone,
        OutLinear = EaseType.Linear | OutNone,
        InOutLinear = EaseType.Linear | InOutNone,
        OutInLinear = EaseType.Linear | OutInNone,

        InSine = EaseType.Sine | InNone,
        OutSine = EaseType.Sine | OutNone,
        InOutSine = EaseType.Sine | InOutNone,
        OutInSine = EaseType.Sine | OutInNone,

        InQuad = EaseType.Quad | InNone,
        OutQuad = EaseType.Quad | OutNone,
        InOutQuad = EaseType.Quad | InOutNone,
        OutInQuad = EaseType.Quad | OutInNone,

        InCubic = EaseType.Cubic | InNone,
        OutCubic = EaseType.Cubic | OutNone,
        InOutCubic = EaseType.Cubic | InOutNone,
        OutInCubic = EaseType.Cubic | OutInNone,

        InQuart = EaseType.Quart | InNone,
        OutQuart = EaseType.Quart | OutNone,
        InOutQuart = EaseType.Quart | InOutNone,
        OutInQuart = EaseType.Quart | OutInNone,

        InQuint = EaseType.Quint | InNone,
        OutQuint = EaseType.Quint | OutNone,
        InOutQuint = EaseType.Quint | InOutNone,
        OutInQuint = EaseType.Quint | OutInNone,

        InExpo = EaseType.Expo | InNone,
        OutExpo = EaseType.Expo | OutNone,
        InOutExpo = EaseType.Expo | InOutNone,
        OutInExpo = EaseType.Expo | OutInNone,

        InCirc = EaseType.Circ | InNone,
        OutCirc = EaseType.Circ | OutNone,
        InOutCirc = EaseType.Circ | InOutNone,
        OutInCirc = EaseType.Circ | OutInNone,

        InElastic = EaseType.Elastic | InNone,
        OutElastic = EaseType.Elastic | OutNone,
        InOutElastic = EaseType.Elastic | InOutNone,
        OutInElastic = EaseType.Elastic | OutInNone,

        InBack = EaseType.Back | InNone,
        OutBack = EaseType.Back | OutNone,
        InOutBack = EaseType.Back | InOutNone,
        OutInBack = EaseType.Back | OutInNone,

        InBounce = EaseType.Bounce | InNone,
        OutBounce = EaseType.Bounce | OutNone,
        InOutBounce = EaseType.Bounce | InOutNone,
        OutInBounce = EaseType.Bounce | OutInNone,
    }
}
#endregion