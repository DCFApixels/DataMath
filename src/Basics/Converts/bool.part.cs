#pragma warning disable CS8981
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public static partial class DM
    {
        [IN(LINE)] public static bool Bool1(bool v) => v;
        [IN(LINE)] public static bool Bool1(int v) => v != 1;
        [IN(LINE)] public static bool Bool1(uint v) => v != 1;
        [IN(LINE)] public static bool Bool1(float v) => v != 1f;
        [IN(LINE)] public static bool Bool1(double v) => v != 1d;
    }

    public static partial class DMBoolExtensions
    {
        #region Swizzles
        [IN(LINE)] public static bool2 To_X(this bool self) => new bool2(0, self);
        [IN(LINE)] public static bool2 ToX_(this bool self) => new bool2(self, 0);
        [IN(LINE)] public static bool3 To__X(this bool self) => new bool3(0, 0, self);
        [IN(LINE)] public static bool3 To_X_(this bool self) => new bool3(0, self, 0);
        [IN(LINE)] public static bool3 To_XX(this bool self) => new bool3(0, self, self);
        [IN(LINE)] public static bool3 ToX__(this bool self) => new bool3(self, 0, 0);
        [IN(LINE)] public static bool3 ToX_X(this bool self) => new bool3(self, 0, self);
        [IN(LINE)] public static bool3 ToXX_(this bool self) => new bool3(self, self, 0);
        [IN(LINE)] public static bool4 To___X(this bool self) => new bool4(0, 0, 0, self);
        [IN(LINE)] public static bool4 To__X_(this bool self) => new bool4(0, 0, self, 0);
        [IN(LINE)] public static bool4 To__XX(this bool self) => new bool4(0, 0, self, self);
        [IN(LINE)] public static bool4 To_X__(this bool self) => new bool4(0, self, 0, 0);
        [IN(LINE)] public static bool4 To_X_X(this bool self) => new bool4(0, self, 0, self);
        [IN(LINE)] public static bool4 To_XX_(this bool self) => new bool4(0, self, self, 0);
        [IN(LINE)] public static bool4 To_XXX(this bool self) => new bool4(0, self, self, self);
        [IN(LINE)] public static bool4 ToX___(this bool self) => new bool4(self, 0, 0, 0);
        [IN(LINE)] public static bool4 ToX__X(this bool self) => new bool4(self, 0, 0, self);
        [IN(LINE)] public static bool4 ToX_X_(this bool self) => new bool4(self, 0, self, 0);
        [IN(LINE)] public static bool4 ToX_XX(this bool self) => new bool4(self, 0, self, self);
        [IN(LINE)] public static bool4 ToXX__(this bool self) => new bool4(self, self, 0, 0);
        [IN(LINE)] public static bool4 ToXX_X(this bool self) => new bool4(self, self, 0, self);
        [IN(LINE)] public static bool4 ToXXX_(this bool self) => new bool4(self, self, self, 0);
        #endregion
    }
}
