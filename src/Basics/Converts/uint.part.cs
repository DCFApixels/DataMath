using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public static partial class DM
    {
        [IN(LINE)] public static uint UInt1(bool v) => v ? 1u : 0u;
        [IN(LINE)] public static uint UInt1(int v) => (uint)v;
        [IN(LINE)] public static uint UInt1(uint v) => v;
        [IN(LINE)] public static uint UInt1(float v) => (uint)v;
        [IN(LINE)] public static uint UInt1(double v) => (uint)v;
    }

    public static partial class DMUIntExtensions
    {
        #region Swaps
        [IN(LINE)] public static uint2 To_X(this uint self) => new uint2(0, self);
        [IN(LINE)] public static uint2 ToX_(this uint self) => new uint2(self, 0);
        [IN(LINE)] public static uint3 To__X(this uint self) => new uint3(0, 0, self);
        [IN(LINE)] public static uint3 To_X_(this uint self) => new uint3(0, self, 0);
        [IN(LINE)] public static uint3 To_XX(this uint self) => new uint3(0, self, self);
        [IN(LINE)] public static uint3 ToX__(this uint self) => new uint3(self, 0, 0);
        [IN(LINE)] public static uint3 ToX_X(this uint self) => new uint3(self, 0, self);
        [IN(LINE)] public static uint3 ToXX_(this uint self) => new uint3(self, self, 0);
        [IN(LINE)] public static uint4 To___X(this uint self) => new uint4(0, 0, 0, self);
        [IN(LINE)] public static uint4 To__X_(this uint self) => new uint4(0, 0, self, 0);
        [IN(LINE)] public static uint4 To__XX(this uint self) => new uint4(0, 0, self, self);
        [IN(LINE)] public static uint4 To_X__(this uint self) => new uint4(0, self, 0, 0);
        [IN(LINE)] public static uint4 To_X_X(this uint self) => new uint4(0, self, 0, self);
        [IN(LINE)] public static uint4 To_XX_(this uint self) => new uint4(0, self, self, 0);
        [IN(LINE)] public static uint4 To_XXX(this uint self) => new uint4(0, self, self, self);
        [IN(LINE)] public static uint4 ToX___(this uint self) => new uint4(self, 0, 0, 0);
        [IN(LINE)] public static uint4 ToX__X(this uint self) => new uint4(self, 0, 0, self);
        [IN(LINE)] public static uint4 ToX_X_(this uint self) => new uint4(self, 0, self, 0);
        [IN(LINE)] public static uint4 ToX_XX(this uint self) => new uint4(self, 0, self, self);
        [IN(LINE)] public static uint4 ToXX__(this uint self) => new uint4(self, self, 0, 0);
        [IN(LINE)] public static uint4 ToXX_X(this uint self) => new uint4(self, self, 0, self);
        [IN(LINE)] public static uint4 ToXXX_(this uint self) => new uint4(self, self, self, 0);
        #endregion
    }
}
