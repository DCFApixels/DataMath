using System.Runtime.CompilerServices;

namespace DCFApixels.DataMath
{
    public static partial class DoubleExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 To_X(this double self) => new double2(0d, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 ToX_(this double self) => new double2(self, 0d);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double2 ToXX(this double self) => new double2(self, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 To__X(this double self) => new double3(0d, 0d, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 To_X_(this double self) => new double3(0d, self, 0d);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 To_XX(this double self) => new double3(0d, self, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 ToX__(this double self) => new double3(self, 0d, 0d);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 ToX_X(this double self) => new double3(self, 0d, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 ToXX_(this double self) => new double3(self, self, 0d);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 ToXXX(this double self) => new double3(self, self, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 To___X(this double self) => new double4(0d, 0d, 0d, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 To__X_(this double self) => new double4(0d, 0d, self, 0d);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 To__XX(this double self) => new double4(0d, 0d, self, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 To_X__(this double self) => new double4(0d, self, 0d, 0d);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 To_X_X(this double self) => new double4(0d, self, 0d, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 To_XX_(this double self) => new double4(0d, self, self, 0d);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 To_XXX(this double self) => new double4(0d, self, self, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 ToX___(this double self) => new double4(self, 0d, 0d, 0d);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 ToX__X(this double self) => new double4(self, 0d, 0d, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 ToX_X_(this double self) => new double4(self, 0d, self, 0d);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 ToX_XX(this double self) => new double4(self, 0d, self, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 ToXX__(this double self) => new double4(self, self, 0d, 0d);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 ToXX_X(this double self) => new double4(self, self, 0d, self);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 ToXXX_(this double self) => new double4(self, self, self, 0d);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 ToXXXX(this double self) => new double4(self, self, self, self);

    }
}
