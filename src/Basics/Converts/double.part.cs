using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace toDCFApixels.DataMath
{
    public static partial class math
    {
        [IN(LINE)] public static double Double1(bool v) => v ? 1d : 0d;
        [IN(LINE)] public static double Double1(int v) => v;
        [IN(LINE)] public static double Double1(uint v) => v;
        [IN(LINE)] public static double Double1(float v) => (double)v;
        [IN(LINE)] public static double Double1(double v) => v;
    }
}
