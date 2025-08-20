using static DCFApixels.DataMath.Consts;
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
}
