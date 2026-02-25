#pragma warning disable CS8981
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public static partial class DM
    {
        [IN(LINE)] public static float Float1(bool v) => v ? 1f : 0f;
        [IN(LINE)] public static float Float1(int v) => v;
        [IN(LINE)] public static float Float1(uint v) => v;
        [IN(LINE)] public static float Float1(float v) => v;
        [IN(LINE)] public static float Float1(double v) => (float)v;
    }

    public static partial class DMFloatExtensions
    {
        #region Swizzles
        [IN(LINE)] public static float2 To_X(this float self) => new float2(0, self);
        [IN(LINE)] public static float2 ToX_(this float self) => new float2(self, 0);
        [IN(LINE)] public static float3 To__X(this float self) => new float3(0, 0, self);
        [IN(LINE)] public static float3 To_X_(this float self) => new float3(0, self, 0);
        [IN(LINE)] public static float3 To_XX(this float self) => new float3(0, self, self);
        [IN(LINE)] public static float3 ToX__(this float self) => new float3(self, 0, 0);
        [IN(LINE)] public static float3 ToX_X(this float self) => new float3(self, 0, self);
        [IN(LINE)] public static float3 ToXX_(this float self) => new float3(self, self, 0);
        [IN(LINE)] public static float4 To___X(this float self) => new float4(0, 0, 0, self);
        [IN(LINE)] public static float4 To__X_(this float self) => new float4(0, 0, self, 0);
        [IN(LINE)] public static float4 To__XX(this float self) => new float4(0, 0, self, self);
        [IN(LINE)] public static float4 To_X__(this float self) => new float4(0, self, 0, 0);
        [IN(LINE)] public static float4 To_X_X(this float self) => new float4(0, self, 0, self);
        [IN(LINE)] public static float4 To_XX_(this float self) => new float4(0, self, self, 0);
        [IN(LINE)] public static float4 To_XXX(this float self) => new float4(0, self, self, self);
        [IN(LINE)] public static float4 ToX___(this float self) => new float4(self, 0, 0, 0);
        [IN(LINE)] public static float4 ToX__X(this float self) => new float4(self, 0, 0, self);
        [IN(LINE)] public static float4 ToX_X_(this float self) => new float4(self, 0, self, 0);
        [IN(LINE)] public static float4 ToX_XX(this float self) => new float4(self, 0, self, self);
        [IN(LINE)] public static float4 ToXX__(this float self) => new float4(self, self, 0, 0);
        [IN(LINE)] public static float4 ToXX_X(this float self) => new float4(self, self, 0, self);
        [IN(LINE)] public static float4 ToXXX_(this float self) => new float4(self, self, self, 0);
        #endregion
    }
}
