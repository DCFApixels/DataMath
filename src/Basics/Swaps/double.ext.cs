using System.Runtime.CompilerServices;

namespace DCFApixels.DataMath
{
    public static partial class FloatExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 To_X(this float self) => new float2(0f, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 ToX_(this float self) => new float2(self, 0f);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 To__X(this float self) => new float3(0f, 0f, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 To_X_(this float self) => new float3(0f, self, 0f);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 To_XX(this float self) => new float3(0f, self, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 ToX__(this float self) => new float3(self, 0f, 0f);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 ToX_X(this float self) => new float3(self, 0f, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 ToXX_(this float self) => new float3(self, self, 0f);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 To___X(this float self) => new float4(0f, 0f, 0f, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 To__X_(this float self) => new float4(0f, 0f, self, 0f);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 To__XX(this float self) => new float4(0f, 0f, self, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 To_X__(this float self) => new float4(0f, self, 0f, 0f);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 To_X_X(this float self) => new float4(0f, self, 0f, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 To_XX_(this float self) => new float4(0f, self, self, 0f);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 To_XXX(this float self) => new float4(0f, self, self, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 ToX___(this float self) => new float4(self, 0f, 0f, 0f);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 ToX__X(this float self) => new float4(self, 0f, 0f, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 ToX_X_(this float self) => new float4(self, 0f, self, 0f);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 ToX_XX(this float self) => new float4(self, 0f, self, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 ToXX__(this float self) => new float4(self, self, 0f, 0f);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 ToXX_X(this float self) => new float4(self, self, 0f, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float4 ToXXX_(this float self) => new float4(self, self, self, 0f);
    }
}
