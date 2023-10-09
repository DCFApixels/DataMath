using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public static partial class math
    {
        [IN(LINE)] public static double double1(float v) => (double)v;
        [IN(LINE)] public static double double1(int v) => v;
        [IN(LINE)] public static double double1(uint v) => v;
        [IN(LINE)] public static double double1(double v) => v;
    }
}
