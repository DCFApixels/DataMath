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
}
