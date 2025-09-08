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
        #region Swaps
        [IN(LINE)] public static bool2 To_X(this bool self) => new bool2(false, self);
        [IN(LINE)] public static bool2 ToX_(this bool self) => new bool2(self, false);
        [IN(LINE)] public static bool3 To__X(this bool self) => new bool3(false, false, self);
        [IN(LINE)] public static bool3 To_X_(this bool self) => new bool3(false, self, false);
        [IN(LINE)] public static bool3 To_XX(this bool self) => new bool3(false, self, self);
        [IN(LINE)] public static bool3 ToX__(this bool self) => new bool3(self, false, false);
        [IN(LINE)] public static bool3 ToX_X(this bool self) => new bool3(self, false, self);
        [IN(LINE)] public static bool3 ToXX_(this bool self) => new bool3(self, self, false);
        [IN(LINE)] public static bool4 To___X(this bool self) => new bool4(false, false, false, self);
        [IN(LINE)] public static bool4 To__X_(this bool self) => new bool4(false, false, self, false);
        [IN(LINE)] public static bool4 To__XX(this bool self) => new bool4(false, false, self, self);
        [IN(LINE)] public static bool4 To_X__(this bool self) => new bool4(false, self, false, false);
        [IN(LINE)] public static bool4 To_X_X(this bool self) => new bool4(false, self, false, self);
        [IN(LINE)] public static bool4 To_XX_(this bool self) => new bool4(false, self, self, false);
        [IN(LINE)] public static bool4 To_XXX(this bool self) => new bool4(false, self, self, self);
        [IN(LINE)] public static bool4 ToX___(this bool self) => new bool4(self, false, false, false);
        [IN(LINE)] public static bool4 ToX__X(this bool self) => new bool4(self, false, false, self);
        [IN(LINE)] public static bool4 ToX_X_(this bool self) => new bool4(self, false, self, false);
        [IN(LINE)] public static bool4 ToX_XX(this bool self) => new bool4(self, false, self, self);
        [IN(LINE)] public static bool4 ToXX__(this bool self) => new bool4(self, self, false, false);
        [IN(LINE)] public static bool4 ToXX_X(this bool self) => new bool4(self, self, false, self);
        [IN(LINE)] public static bool4 ToXXX_(this bool self) => new bool4(self, self, self, false);
        #endregion
    }
}
