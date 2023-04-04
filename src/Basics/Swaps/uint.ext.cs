using System.Runtime.CompilerServices;

namespace DCFApixels.DataMath
{
    public static partial class UIntExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 To_X(this uint self) => new uint2(0, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 ToX_(this uint self) => new uint2(self, 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint2 ToXX(this uint self) => new uint2(self, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 To__X(this uint self) => new uint3(0, 0, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 To_X_(this uint self) => new uint3(0, self, 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 To_XX(this uint self) => new uint3(0, self, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 ToX__(this uint self) => new uint3(self, 0, 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 ToX_X(this uint self) => new uint3(self, 0, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 ToXX_(this uint self) => new uint3(self, self, 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 ToXXX(this uint self) => new uint3(self, self, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 To___X(this uint self) => new uint4(0, 0, 0, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 To__X_(this uint self) => new uint4(0, 0, self, 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 To__XX(this uint self) => new uint4(0, 0, self, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 To_X__(this uint self) => new uint4(0, self, 0, 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 To_X_X(this uint self) => new uint4(0, self, 0, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 To_XX_(this uint self) => new uint4(0, self, self, 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 To_XXX(this uint self) => new uint4(0, self, self, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 ToX___(this uint self) => new uint4(self, 0, 0, 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 ToX__X(this uint self) => new uint4(self, 0, 0, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 ToX_X_(this uint self) => new uint4(self, 0, self, 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 ToX_XX(this uint self) => new uint4(self, 0, self, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 ToXX__(this uint self) => new uint4(self, self, 0, 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 ToXX_X(this uint self) => new uint4(self, self, 0, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 ToXXX_(this uint self) => new uint4(self, self, self, 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 ToXXXX(this uint self) => new uint4(self, self, self, self);

    }
}
