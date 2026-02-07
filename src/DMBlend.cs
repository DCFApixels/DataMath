using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath.Blends
{
    public enum BlendMode
    {
        None,
        Add,
        Subtract,
        Multiply,
        Divide,
        Screen,
        Overlay,
        Darken,
        Lighten,
        Dodge,
        Burn,
        LinearDodge,
        LinearBurn,
        LinearLight,
        LinearLightAddSub,
        VividLight,
        PinLight,
        HardMix,
        HardLight,
        SoftLight,
        Difference,
        Exclusion,
        Negation,
        Overwrite,
    }

    public static class DMBlend
    {
        private const float DIFF_OFFSET = 0.000000000001f;

        #region BlendMode
        public static float Blend(float a, float b, float t, BlendMode mode)
        {
            switch (mode)
            {
                case BlendMode.None: return a;
                case BlendMode.Add: return Add(a, b, t);
                case BlendMode.Subtract: return Subtract(a, b, t);
                case BlendMode.Multiply: return Multiply(a, b, t);
                case BlendMode.Divide: return Divide(a, b, t);
                case BlendMode.Screen: return Screen(a, b, t);
                case BlendMode.Overlay: return Overlay(a, b, t);
                case BlendMode.Darken: return Darken(a, b, t);
                case BlendMode.Lighten: return Lighten(a, b, t);
                case BlendMode.Dodge: return Dodge(a, b, t);
                case BlendMode.Burn: return Burn(a, b, t);
                case BlendMode.LinearDodge: return LinearDodge(a, b, t);
                case BlendMode.LinearBurn: return LinearBurn(a, b, t);
                case BlendMode.LinearLight: return LinearLight(a, b, t);
                case BlendMode.LinearLightAddSub: return LinearLightAddSub(a, b, t);
                case BlendMode.VividLight: return VividLight(a, b, t);
                case BlendMode.PinLight: return PinLight(a, b, t);
                case BlendMode.HardMix: return HardMix(a, b, t);
                case BlendMode.HardLight: return HardLight(a, b, t);
                case BlendMode.SoftLight: return SoftLight(a, b, t);
                case BlendMode.Difference: return Difference(a, b, t);
                case BlendMode.Exclusion: return Exclusion(a, b, t);
                case BlendMode.Negation: return Negation(a, b, t);
                case BlendMode.Overwrite: default: return Overwrite(a, b, t);
            }
        }

        public static float2 Blend(float2 a, float2 b, float t, BlendMode mode)
        {
            switch (mode)
            {
                case BlendMode.None: return a;
                case BlendMode.Add: return Add(a, b, t);
                case BlendMode.Subtract: return Subtract(a, b, t);
                case BlendMode.Multiply: return Multiply(a, b, t);
                case BlendMode.Divide: return Divide(a, b, t);
                case BlendMode.Screen: return Screen(a, b, t);
                case BlendMode.Overlay: return Overlay(a, b, t);
                case BlendMode.Darken: return Darken(a, b, t);
                case BlendMode.Lighten: return Lighten(a, b, t);
                case BlendMode.Dodge: return Dodge(a, b, t);
                case BlendMode.Burn: return Burn(a, b, t);
                case BlendMode.LinearDodge: return LinearDodge(a, b, t);
                case BlendMode.LinearBurn: return LinearBurn(a, b, t);
                case BlendMode.LinearLight: return LinearLight(a, b, t);
                case BlendMode.LinearLightAddSub: return LinearLightAddSub(a, b, t);
                case BlendMode.VividLight: return VividLight(a, b, t);
                case BlendMode.PinLight: return PinLight(a, b, t);
                case BlendMode.HardMix: return HardMix(a, b, t);
                case BlendMode.HardLight: return HardLight(a, b, t);
                case BlendMode.SoftLight: return SoftLight(a, b, t);
                case BlendMode.Difference: return Difference(a, b, t);
                case BlendMode.Exclusion: return Exclusion(a, b, t);
                case BlendMode.Negation: return Negation(a, b, t);
                case BlendMode.Overwrite: default: return Overwrite(a, b, t);
            }
        }

        public static float3 Blend(float3 a, float3 b, float t, BlendMode mode)
        {
            switch (mode)
            {
                case BlendMode.None: return a;
                case BlendMode.Add: return Add(a, b, t);
                case BlendMode.Subtract: return Subtract(a, b, t);
                case BlendMode.Multiply: return Multiply(a, b, t);
                case BlendMode.Divide: return Divide(a, b, t);
                case BlendMode.Screen: return Screen(a, b, t);
                case BlendMode.Overlay: return Overlay(a, b, t);
                case BlendMode.Darken: return Darken(a, b, t);
                case BlendMode.Lighten: return Lighten(a, b, t);
                case BlendMode.Dodge: return Dodge(a, b, t);
                case BlendMode.Burn: return Burn(a, b, t);
                case BlendMode.LinearDodge: return LinearDodge(a, b, t);
                case BlendMode.LinearBurn: return LinearBurn(a, b, t);
                case BlendMode.LinearLight: return LinearLight(a, b, t);
                case BlendMode.LinearLightAddSub: return LinearLightAddSub(a, b, t);
                case BlendMode.VividLight: return VividLight(a, b, t);
                case BlendMode.PinLight: return PinLight(a, b, t);
                case BlendMode.HardMix: return HardMix(a, b, t);
                case BlendMode.HardLight: return HardLight(a, b, t);
                case BlendMode.SoftLight: return SoftLight(a, b, t);
                case BlendMode.Difference: return Difference(a, b, t);
                case BlendMode.Exclusion: return Exclusion(a, b, t);
                case BlendMode.Negation: return Negation(a, b, t);
                case BlendMode.Overwrite: default: return Overwrite(a, b, t);
            }
        }

        public static float4 Blend(float4 a, float4 b, float t, BlendMode mode)
        {
            switch (mode)
            {
                case BlendMode.None: return a;
                case BlendMode.Add: return Add(a, b, t);
                case BlendMode.Subtract: return Subtract(a, b, t);
                case BlendMode.Multiply: return Multiply(a, b, t);
                case BlendMode.Divide: return Divide(a, b, t);
                case BlendMode.Screen: return Screen(a, b, t);
                case BlendMode.Overlay: return Overlay(a, b, t);
                case BlendMode.Darken: return Darken(a, b, t);
                case BlendMode.Lighten: return Lighten(a, b, t);
                case BlendMode.Dodge: return Dodge(a, b, t);
                case BlendMode.Burn: return Burn(a, b, t);
                case BlendMode.LinearDodge: return LinearDodge(a, b, t);
                case BlendMode.LinearBurn: return LinearBurn(a, b, t);
                case BlendMode.LinearLight: return LinearLight(a, b, t);
                case BlendMode.LinearLightAddSub: return LinearLightAddSub(a, b, t);
                case BlendMode.VividLight: return VividLight(a, b, t);
                case BlendMode.PinLight: return PinLight(a, b, t);
                case BlendMode.HardMix: return HardMix(a, b, t);
                case BlendMode.HardLight: return HardLight(a, b, t);
                case BlendMode.SoftLight: return SoftLight(a, b, t);
                case BlendMode.Difference: return Difference(a, b, t);
                case BlendMode.Exclusion: return Exclusion(a, b, t);
                case BlendMode.Negation: return Negation(a, b, t);
                case BlendMode.Overwrite: default: return Overwrite(a, b, t);
            }
        }
        #endregion

        #region float
        [IN(LINE)] public static float Add(float a, float b, float t) { return DM.Lerp(a, a + b, t); }
        [IN(LINE)] public static float Subtract(float a, float b, float t) { return DM.Lerp(a, a - b, t); }
        [IN(LINE)] public static float Multiply(float a, float b, float t) { return DM.Lerp(a, a * b, t); }
        [IN(LINE)] public static float Divide(float a, float b, float t) { return DM.Lerp(a, b == 0f ? 0f : a / b, t); }

        [IN(LINE)] public static float Screen(float a, float b, float t) { return DM.Lerp(a, 1f - (1f - a) * (1f - b), t); }
        [IN(LINE)]
        public static float Overlay(float a, float b, float t)
        {
            float r1 = 1f - 2f * (1f - a) * (1f - b);
            float r2 = 2f * a * b;
            float zeroOrOne = DM.Step(a, 0.5f);
            float r = r2 * zeroOrOne + (1f - zeroOrOne) * r1;
            return DM.Lerp(a, r, t);
        }
        [IN(LINE)] public static float Darken(float a, float b, float t) { return DM.Lerp(a, DM.Min(a, b), t); }
        [IN(LINE)] public static float Lighten(float a, float b, float t) { return DM.Lerp(a, DM.Max(a, b), t); }

        [IN(LINE)] public static float Dodge(float a, float b, float t) { return DM.Lerp(a, a / (1f - (b == 1f ? b + DIFF_OFFSET : b)), t); }
        [IN(LINE)] public static float Burn(float a, float b, float t) { return DM.Lerp(a, b == 0f ? 0f : 1f - DM.Min(1f, (1f - a) / b), t); }
        [IN(LINE)] public static float LinearDodge(float a, float b, float t) { return DM.Lerp(a, a + b, t); }
        [IN(LINE)] public static float LinearBurn(float a, float b, float t) { return DM.Lerp(a, DM.Max(a + b - 1f, 0f), t); }

        [IN(LINE)] public static float LinearLight(float a, float b, float t) { return DM.Lerp(a, b < 0.5f ? DM.Max(a + (2f * b) - 1f, 0f) : DM.Min(a + 2f * (b - 0.5f), 1f), t); }
        [IN(LINE)] public static float LinearLightAddSub(float a, float b, float t) { return DM.Lerp(a, b + 2f * a - 1f, t); }
        [IN(LINE)]
        public static float VividLight(float a, float b, float t)
        {
            float r1 = 1f - (1f - b) / (2f * a);
            float r2 = b / (2f * (1f - a));
            float zeroOrOne = DM.Step(0.5f, a);
            float r = r2 * zeroOrOne + (1f - zeroOrOne) * r1;
            return DM.Lerp(a, r, t);
        }
        [IN(LINE)]
        public static float PinLight(float a, float b, float t)
        {
            float check = DM.Step(0.5f, b);
            float r1 = check * DM.Max(2f * (a - 0.5f), b);
            float r = r1 + (1f - check) * DM.Min(2f * a, b);
            return DM.Lerp(a, r, t);
        }
        [IN(LINE)] public static float HardMix(float a, float b, float t) { return DM.Lerp(a, DM.Step(1f - a, b), t); }
        [IN(LINE)]
        public static float HardLight(float a, float b, float t)
        {
            float r1 = 1f - 2f * (1f - a) * (1f - b);
            float r2 = 2f * a * b;
            float zeroOrOne = DM.Step(b, 0.5f);
            float r = r2 * zeroOrOne + (1f - zeroOrOne) * r1;
            return DM.Lerp(a, r, t);
        }

        [IN(LINE)]
        public static float SoftLight(float a, float b, float t)
        {
            float r1 = 2f * a * b + a * a * (1f - 2f * b);
            float r2 = DM.Sqrt(a) * (2f * b - 1f) + 2f * a * (1f - b);
            float zeroOrOne = DM.Step(0.5f, b);
            float r = r2 * zeroOrOne + (1f - zeroOrOne) * r1;
            return DM.Lerp(a, r, t);
        }

        [IN(LINE)] public static float Difference(float a, float b, float t) { return DM.Lerp(a, DM.Abs(a - b), t); }
        [IN(LINE)] public static float Exclusion(float a, float b, float t) { return DM.Lerp(a, a + b - 2f * a * b, t); }
        [IN(LINE)] public static float Negation(float a, float b, float t) { return DM.Lerp(a, 1 - DM.Abs(1 - b - a), t); }
        [IN(LINE)] public static float Overwrite(float a, float b, float t) { return DM.Lerp(a, b, t); }
        #endregion

        #region float2
        [IN(LINE)] public static float2 Add(float2 a, float2 b, float2 t) { return DM.Lerp(a, a + b, t); }
        [IN(LINE)] public static float2 Subtract(float2 a, float2 b, float2 t) { return DM.Lerp(a, a - b, t); }
        [IN(LINE)] public static float2 Multiply(float2 a, float2 b, float2 t) { return DM.Lerp(a, a * b, t); }
        [IN(LINE)] public static float2 Divide(float2 a, float2 b, float2 t) { return DM.Lerp(a, b == 0f ? 0f : a / b, t); }

        [IN(LINE)] public static float2 Screen(float2 a, float2 b, float2 t) { return DM.Lerp(a, 1f - (1f - a) * (1f - b), t); }
        [IN(LINE)]
        public static float2 Overlay(float2 a, float2 b, float2 t)
        {
            float2 r1 = 1f - 2f * (1f - a) * (1f - b);
            float2 r2 = 2f * a * b;
            float2 zeroOrOne = DM.Step(a, 0.5f);
            float2 r = r2 * zeroOrOne + (1f - zeroOrOne) * r1;
            return DM.Lerp(a, r, t);
        }
        [IN(LINE)] public static float2 Darken(float2 a, float2 b, float2 t) { return DM.Lerp(a, DM.Min(a, b), t); }
        [IN(LINE)] public static float2 Lighten(float2 a, float2 b, float2 t) { return DM.Lerp(a, DM.Max(a, b), t); }

        [IN(LINE)] public static float2 Dodge(float2 a, float2 b, float2 t) { return DM.Lerp(a, a / (1f - (b == 1f ? b + DIFF_OFFSET : b)), t); }
        [IN(LINE)] public static float2 Burn(float2 a, float2 b, float2 t) { return DM.Lerp(a, b == 0f ? 0f : 1f - DM.Min(1f, (1f - a) / b), t); }
        [IN(LINE)] public static float2 LinearDodge(float2 a, float2 b, float2 t) { return DM.Lerp(a, a + b, t); }
        [IN(LINE)] public static float2 LinearBurn(float2 a, float2 b, float2 t) { return DM.Lerp(a, DM.Max(a + b - 1f, 0f), t); }

        [IN(LINE)] public static float2 LinearLight(float2 a, float2 b, float2 t) { return DM.Lerp(a, b < 0.5f ? DM.Max(a + (2f * b) - 1f, 0f) : DM.Min(a + 2f * (b - 0.5f), 1f), t); }
        [IN(LINE)] public static float2 LinearLightAddSub(float2 a, float2 b, float2 t) { return DM.Lerp(a, b + 2f * a - 1f, t); }
        [IN(LINE)]
        public static float2 VividLight(float2 a, float2 b, float2 t)
        {
            float2 r1 = 1f - (1f - b) / (2f * a);
            float2 r2 = b / (2f * (1f - a));
            float2 zeroOrOne = DM.Step(0.5f, a);
            float2 r = r2 * zeroOrOne + (1f - zeroOrOne) * r1;
            return DM.Lerp(a, r, t);
        }
        [IN(LINE)]
        public static float2 PinLight(float2 a, float2 b, float2 t)
        {
            float2 check = DM.Step(0.5f, b);
            float2 r1 = check * DM.Max(2f * (a - 0.5f), b);
            float2 r = r1 + (1f - check) * DM.Min(2f * a, b);
            return DM.Lerp(a, r, t);
        }
        [IN(LINE)] public static float2 HardMix(float2 a, float2 b, float2 t) { return DM.Lerp(a, DM.Step(1f - a, b), t); }
        [IN(LINE)]
        public static float2 HardLight(float2 a, float2 b, float2 t)
        {
            float2 r1 = 1f - 2f * (1f - a) * (1f - b);
            float2 r2 = 2f * a * b;
            float2 zeroOrOne = DM.Step(b, 0.5f);
            float2 r = r2 * zeroOrOne + (1f - zeroOrOne) * r1;
            return DM.Lerp(a, r, t);
        }

        [IN(LINE)]
        public static float2 SoftLight(float2 a, float2 b, float2 t)
        {
            float2 r1 = 2f * a * b + a * a * (1f - 2f * b);
            float2 r2 = DM.Sqrt(a) * (2f * b - 1f) + 2f * a * (1f - b);
            float2 zeroOrOne = DM.Step(0.5f, b);
            float2 r = r2 * zeroOrOne + (1f - zeroOrOne) * r1;
            return DM.Lerp(a, r, t);
        }

        [IN(LINE)] public static float2 Difference(float2 a, float2 b, float2 t) { return DM.Lerp(a, DM.Abs(a - b), t); }
        [IN(LINE)] public static float2 Exclusion(float2 a, float2 b, float2 t) { return DM.Lerp(a, a + b - 2f * a * b, t); }
        [IN(LINE)] public static float2 Negation(float2 a, float2 b, float2 t) { return DM.Lerp(a, 1 - DM.Abs(1 - b - a), t); }
        [IN(LINE)] public static float2 Overwrite(float2 a, float2 b, float2 t) { return DM.Lerp(a, b, t); }
        #endregion

        #region float3
        [IN(LINE)] public static float3 Add(float3 a, float3 b, float3 t) { return DM.Lerp(a, a + b, t); }
        [IN(LINE)] public static float3 Subtract(float3 a, float3 b, float3 t) { return DM.Lerp(a, a - b, t); }
        [IN(LINE)] public static float3 Multiply(float3 a, float3 b, float3 t) { return DM.Lerp(a, a * b, t); }
        [IN(LINE)] public static float3 Divide(float3 a, float3 b, float3 t) { return DM.Lerp(a, b == 0f ? 0f : a / b, t); }

        [IN(LINE)] public static float3 Screen(float3 a, float3 b, float3 t) { return DM.Lerp(a, 1f - (1f - a) * (1f - b), t); }
        [IN(LINE)]
        public static float3 Overlay(float3 a, float3 b, float3 t)
        {
            float3 r1 = 1f - 2f * (1f - a) * (1f - b);
            float3 r2 = 2f * a * b;
            float3 zeroOrOne = DM.Step(a, 0.5f);
            float3 r = r2 * zeroOrOne + (1f - zeroOrOne) * r1;
            return DM.Lerp(a, r, t);
        }
        [IN(LINE)] public static float3 Darken(float3 a, float3 b, float3 t) { return DM.Lerp(a, DM.Min(a, b), t); }
        [IN(LINE)] public static float3 Lighten(float3 a, float3 b, float3 t) { return DM.Lerp(a, DM.Max(a, b), t); }

        [IN(LINE)] public static float3 Dodge(float3 a, float3 b, float3 t) { return DM.Lerp(a, a / (1f - (b == 1f ? b + DIFF_OFFSET : b)), t); }
        [IN(LINE)] public static float3 Burn(float3 a, float3 b, float3 t) { return DM.Lerp(a, b == 0f ? 0f : 1f - DM.Min(1f, (1f - a) / b), t); }
        [IN(LINE)] public static float3 LinearDodge(float3 a, float3 b, float3 t) { return DM.Lerp(a, a + b, t); }
        [IN(LINE)] public static float3 LinearBurn(float3 a, float3 b, float3 t) { return DM.Lerp(a, DM.Max(a + b - 1f, 0f), t); }

        [IN(LINE)] public static float3 LinearLight(float3 a, float3 b, float3 t) { return DM.Lerp(a, b < 0.5f ? DM.Max(a + (2f * b) - 1f, 0f) : DM.Min(a + 2f * (b - 0.5f), 1f), t); }
        [IN(LINE)] public static float3 LinearLightAddSub(float3 a, float3 b, float3 t) { return DM.Lerp(a, b + 2f * a - 1f, t); }
        [IN(LINE)]
        public static float3 VividLight(float3 a, float3 b, float3 t)
        {
            float3 r1 = 1f - (1f - b) / (2f * a);
            float3 r2 = b / (2f * (1f - a));
            float3 zeroOrOne = DM.Step(0.5f, a);
            float3 r = r2 * zeroOrOne + (1f - zeroOrOne) * r1;
            return DM.Lerp(a, r, t);
        }
        [IN(LINE)]
        public static float3 PinLight(float3 a, float3 b, float3 t)
        {
            float3 check = DM.Step(0.5f, b);
            float3 r1 = check * DM.Max(2f * (a - 0.5f), b);
            float3 r = r1 + (1f - check) * DM.Min(2f * a, b);
            return DM.Lerp(a, r, t);
        }
        [IN(LINE)] public static float3 HardMix(float3 a, float3 b, float3 t) { return DM.Lerp(a, DM.Step(1f - a, b), t); }
        [IN(LINE)]
        public static float3 HardLight(float3 a, float3 b, float3 t)
        {
            float3 r1 = 1f - 2f * (1f - a) * (1f - b);
            float3 r2 = 2f * a * b;
            float3 zeroOrOne = DM.Step(b, 0.5f);
            float3 r = r2 * zeroOrOne + (1f - zeroOrOne) * r1;
            return DM.Lerp(a, r, t);
        }

        [IN(LINE)]
        public static float3 SoftLight(float3 a, float3 b, float3 t)
        {
            float3 r1 = 2f * a * b + a * a * (1f - 2f * b);
            float3 r2 = DM.Sqrt(a) * (2f * b - 1f) + 2f * a * (1f - b);
            float3 zeroOrOne = DM.Step(0.5f, b);
            float3 r = r2 * zeroOrOne + (1f - zeroOrOne) * r1;
            return DM.Lerp(a, r, t);
        }

        [IN(LINE)] public static float3 Difference(float3 a, float3 b, float3 t) { return DM.Lerp(a, DM.Abs(a - b), t); }
        [IN(LINE)] public static float3 Exclusion(float3 a, float3 b, float3 t) { return DM.Lerp(a, a + b - 2f * a * b, t); }
        [IN(LINE)] public static float3 Negation(float3 a, float3 b, float3 t) { return DM.Lerp(a, 1 - DM.Abs(1 - b - a), t); }
        [IN(LINE)] public static float3 Overwrite(float3 a, float3 b, float3 t) { return DM.Lerp(a, b, t); }
        #endregion

        #region float4
        [IN(LINE)] public static float4 Add(float4 a, float4 b, float4 t) { return DM.Lerp(a, a + b, t); }
        [IN(LINE)] public static float4 Subtract(float4 a, float4 b, float4 t) { return DM.Lerp(a, a - b, t); }
        [IN(LINE)] public static float4 Multiply(float4 a, float4 b, float4 t) { return DM.Lerp(a, a * b, t); }
        [IN(LINE)] public static float4 Divide(float4 a, float4 b, float4 t) { return DM.Lerp(a, b == 0f ? 0f : a / b, t); }

        [IN(LINE)] public static float4 Screen(float4 a, float4 b, float4 t) { return DM.Lerp(a, 1f - (1f - a) * (1f - b), t); }
        [IN(LINE)]
        public static float4 Overlay(float4 a, float4 b, float4 t)
        {
            float4 r1 = 1f - 2f * (1f - a) * (1f - b);
            float4 r2 = 2f * a * b;
            float4 zeroOrOne = DM.Step(a, 0.5f);
            float4 r = r2 * zeroOrOne + (1f - zeroOrOne) * r1;
            return DM.Lerp(a, r, t);
        }
        [IN(LINE)] public static float4 Darken(float4 a, float4 b, float4 t) { return DM.Lerp(a, DM.Min(a, b), t); }
        [IN(LINE)] public static float4 Lighten(float4 a, float4 b, float4 t) { return DM.Lerp(a, DM.Max(a, b), t); }

        [IN(LINE)] public static float4 Dodge(float4 a, float4 b, float4 t) { return DM.Lerp(a, a / (1f - (b == 1f ? b + DIFF_OFFSET : b)), t); }
        [IN(LINE)] public static float4 Burn(float4 a, float4 b, float4 t) { return DM.Lerp(a, b == 0f ? 0f : 1f - DM.Min(1f, (1f - a) / b), t); }
        [IN(LINE)] public static float4 LinearDodge(float4 a, float4 b, float4 t) { return DM.Lerp(a, a + b, t); }
        [IN(LINE)] public static float4 LinearBurn(float4 a, float4 b, float4 t) { return DM.Lerp(a, DM.Max(a + b - 1f, 0f), t); }

        [IN(LINE)] public static float4 LinearLight(float4 a, float4 b, float4 t) { return DM.Lerp(a, b < 0.5f ? DM.Max(a + (2f * b) - 1f, 0f) : DM.Min(a + 2f * (b - 0.5f), 1f), t); }
        [IN(LINE)] public static float4 LinearLightAddSub(float4 a, float4 b, float4 t) { return DM.Lerp(a, b + 2f * a - 1f, t); }
        [IN(LINE)]
        public static float4 VividLight(float4 a, float4 b, float4 t)
        {
            float4 r1 = 1f - (1f - b) / (2f * a);
            float4 r2 = b / (2f * (1f - a));
            float4 zeroOrOne = DM.Step(0.5f, a);
            float4 r = r2 * zeroOrOne + (1f - zeroOrOne) * r1;
            return DM.Lerp(a, r, t);
        }
        [IN(LINE)]
        public static float4 PinLight(float4 a, float4 b, float4 t)
        {
            float4 check = DM.Step(0.5f, b);
            float4 r1 = check * DM.Max(2f * (a - 0.5f), b);
            float4 r = r1 + (1f - check) * DM.Min(2f * a, b);
            return DM.Lerp(a, r, t);
        }
        [IN(LINE)] public static float4 HardMix(float4 a, float4 b, float4 t) { return DM.Lerp(a, DM.Step(1f - a, b), t); }
        [IN(LINE)]
        public static float4 HardLight(float4 a, float4 b, float4 t)
        {
            float4 r1 = 1f - 2f * (1f - a) * (1f - b);
            float4 r2 = 2f * a * b;
            float4 zeroOrOne = DM.Step(b, 0.5f);
            float4 r = r2 * zeroOrOne + (1f - zeroOrOne) * r1;
            return DM.Lerp(a, r, t);
        }

        [IN(LINE)]
        public static float4 SoftLight(float4 a, float4 b, float4 t)
        {
            float4 r1 = 2f * a * b + a * a * (1f - 2f * b);
            float4 r2 = DM.Sqrt(a) * (2f * b - 1f) + 2f * a * (1f - b);
            float4 zeroOrOne = DM.Step(0.5f, b);
            float4 r = r2 * zeroOrOne + (1f - zeroOrOne) * r1;
            return DM.Lerp(a, r, t);
        }

        [IN(LINE)] public static float4 Difference(float4 a, float4 b, float4 t) { return DM.Lerp(a, DM.Abs(a - b), t); }
        [IN(LINE)] public static float4 Exclusion(float4 a, float4 b, float4 t) { return DM.Lerp(a, a + b - 2f * a * b, t); }
        [IN(LINE)] public static float4 Negation(float4 a, float4 b, float4 t) { return DM.Lerp(a, 1 - DM.Abs(1 - b - a), t); }
        [IN(LINE)] public static float4 Overwrite(float4 a, float4 b, float4 t) { return DM.Lerp(a, b, t); }
        #endregion
    }
}