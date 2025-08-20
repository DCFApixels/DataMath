using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public static partial class DM
    {
        [IN(LINE)] public static int Int1(bool v) => v ? 1 : 0;
        [IN(LINE)] public static int Int1(int v) => v;
        [IN(LINE)] public static int Int1(uint v) => (int)v;
        [IN(LINE)] public static int Int1(float v) => (int)v;
        [IN(LINE)] public static int Int1(double v) => (int)v;
    }

    public static partial class DMIntExtensions
    {
        #region Swaps
        [IN(LINE)] public static int2 To_X(this int self) => new int2(0, self);
        [IN(LINE)] public static int2 ToX_(this int self) => new int2(self, 0);
        [IN(LINE)] public static int3 To__X(this int self) => new int3(0, 0, self);
        [IN(LINE)] public static int3 To_X_(this int self) => new int3(0, self, 0);
        [IN(LINE)] public static int3 To_XX(this int self) => new int3(0, self, self);
        [IN(LINE)] public static int3 ToX__(this int self) => new int3(self, 0, 0);
        [IN(LINE)] public static int3 ToX_X(this int self) => new int3(self, 0, self);
        [IN(LINE)] public static int3 ToXX_(this int self) => new int3(self, self, 0);
        [IN(LINE)] public static int4 To___X(this int self) => new int4(0, 0, 0, self);
        [IN(LINE)] public static int4 To__X_(this int self) => new int4(0, 0, self, 0);
        [IN(LINE)] public static int4 To__XX(this int self) => new int4(0, 0, self, self);
        [IN(LINE)] public static int4 To_X__(this int self) => new int4(0, self, 0, 0);
        [IN(LINE)] public static int4 To_X_X(this int self) => new int4(0, self, 0, self);
        [IN(LINE)] public static int4 To_XX_(this int self) => new int4(0, self, self, 0);
        [IN(LINE)] public static int4 To_XXX(this int self) => new int4(0, self, self, self);
        [IN(LINE)] public static int4 ToX___(this int self) => new int4(self, 0, 0, 0);
        [IN(LINE)] public static int4 ToX__X(this int self) => new int4(self, 0, 0, self);
        [IN(LINE)] public static int4 ToX_X_(this int self) => new int4(self, 0, self, 0);
        [IN(LINE)] public static int4 ToX_XX(this int self) => new int4(self, 0, self, self);
        [IN(LINE)] public static int4 ToXX__(this int self) => new int4(self, self, 0, 0);
        [IN(LINE)] public static int4 ToXX_X(this int self) => new int4(self, self, 0, self);
        [IN(LINE)] public static int4 ToXXX_(this int self) => new int4(self, self, self, 0);
        #endregion
    }
}
