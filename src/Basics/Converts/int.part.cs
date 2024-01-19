using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public static partial class math
    {
        [IN(LINE)] public static int int1(bool v) => v ? 1 : 0;
        [IN(LINE)] public static int int1(int v) => v;
        [IN(LINE)] public static int int1(uint v) => (int)v;
        [IN(LINE)] public static int int1(float v) => (int)v;
        [IN(LINE)] public static int int1(double v) => (int)v;
    }
}
