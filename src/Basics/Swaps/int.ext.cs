using System.Runtime.CompilerServices;

namespace DCFApixels.DataMath
{
    public static partial class IntExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 To_X(this int self) => new int2(0, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 ToX_(this int self) => new int2(self, 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int2 ToXX(this int self) => new int2(self, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 To__X(this int self) => new int3(0, 0, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 To_X_(this int self) => new int3(0, self, 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 To_XX(this int self) => new int3(0, self, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 ToX__(this int self) => new int3(self, 0, 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 ToX_X(this int self) => new int3(self, 0, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 ToXX_(this int self) => new int3(self, self, 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 ToXXX(this int self) => new int3(self, self, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 To___X(this int self) => new int4(0, 0, 0, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 To__X_(this int self) => new int4(0, 0, self, 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 To__XX(this int self) => new int4(0, 0, self, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 To_X__(this int self) => new int4(0, self, 0, 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 To_X_X(this int self) => new int4(0, self, 0, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 To_XX_(this int self) => new int4(0, self, self, 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 To_XXX(this int self) => new int4(0, self, self, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 ToX___(this int self) => new int4(self, 0, 0, 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 ToX__X(this int self) => new int4(self, 0, 0, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 ToX_X_(this int self) => new int4(self, 0, self, 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 ToX_XX(this int self) => new int4(self, 0, self, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 ToXX__(this int self) => new int4(self, self, 0, 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 ToXX_X(this int self) => new int4(self, self, 0, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 ToXXX_(this int self) => new int4(self, self, self, 0);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 ToXXXX(this int self) => new int4(self, self, self, self);

    }
}
