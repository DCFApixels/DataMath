using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public static partial class math
    {
        [IN(LINE)] public static uint UInt1(bool v) => v ? 1u : 0u;
        [IN(LINE)] public static uint UInt1(int v) => (uint)v;
        [IN(LINE)] public static uint UInt1(uint v) => v;
        [IN(LINE)] public static uint UInt1(float v) => (uint)v;
        [IN(LINE)] public static uint UInt1(double v) => (uint)v;
    }
}
