using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public static partial class DM
    {
        [IN(LINE)] public static double Double1(bool v) => v ? 1d : 0d;
        [IN(LINE)] public static double Double1(int v) => v;
        [IN(LINE)] public static double Double1(uint v) => v;
        [IN(LINE)] public static double Double1(float v) => (double)v;
        [IN(LINE)] public static double Double1(double v) => v;
    }

    public static partial class DMDoubleExtensions
    {
        #region Swaps
        [IN(LINE)] public static double2 To_X(this double self) => new double2(0d, self);
        [IN(LINE)] public static double2 ToX_(this double self) => new double2(self, 0d);
        [IN(LINE)] public static double3 To__X(this double self) => new double3(0d, 0d, self);
        [IN(LINE)] public static double3 To_X_(this double self) => new double3(0d, self, 0d);
        [IN(LINE)] public static double3 To_XX(this double self) => new double3(0d, self, self);
        [IN(LINE)] public static double3 ToX__(this double self) => new double3(self, 0d, 0d);
        [IN(LINE)] public static double3 ToX_X(this double self) => new double3(self, 0d, self);
        [IN(LINE)] public static double3 ToXX_(this double self) => new double3(self, self, 0d);
        [IN(LINE)] public static double4 To___X(this double self) => new double4(0d, 0d, 0d, self);
        [IN(LINE)] public static double4 To__X_(this double self) => new double4(0d, 0d, self, 0d);
        [IN(LINE)] public static double4 To__XX(this double self) => new double4(0d, 0d, self, self);
        [IN(LINE)] public static double4 To_X__(this double self) => new double4(0d, self, 0d, 0d);
        [IN(LINE)] public static double4 To_X_X(this double self) => new double4(0d, self, 0d, self);
        [IN(LINE)] public static double4 To_XX_(this double self) => new double4(0d, self, self, 0d);
        [IN(LINE)] public static double4 To_XXX(this double self) => new double4(0d, self, self, self);
        [IN(LINE)] public static double4 ToX___(this double self) => new double4(self, 0d, 0d, 0d);
        [IN(LINE)] public static double4 ToX__X(this double self) => new double4(self, 0d, 0d, self);
        [IN(LINE)] public static double4 ToX_X_(this double self) => new double4(self, 0d, self, 0d);
        [IN(LINE)] public static double4 ToX_XX(this double self) => new double4(self, 0d, self, self);
        [IN(LINE)] public static double4 ToXX__(this double self) => new double4(self, self, 0d, 0d);
        [IN(LINE)] public static double4 ToXX_X(this double self) => new double4(self, self, 0d, self);
        [IN(LINE)] public static double4 ToXXX_(this double self) => new double4(self, self, self, 0d);
        #endregion
    }
}
