using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public static partial class math
    {
        [IN(LINE)] public static uint uint1(float v) => (uint)v;
        [IN(LINE)] public static uint uint1(int v) => (uint)v;
        [IN(LINE)] public static uint uint1(uint v) => v;
        [IN(LINE)] public static uint uint1(double v) => (uint)v;
    }
}
