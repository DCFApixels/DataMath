using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public static partial class math
    {
        [IN(LINE)] public static float Float1(bool v) => v ? 1f : 0f;
        [IN(LINE)] public static float Float1(int v) => v;
        [IN(LINE)] public static float Float1(uint v) => v;
        [IN(LINE)] public static float Float1(float v) => v;
        [IN(LINE)] public static float Float1(double v) => (float)v;
    }
}
