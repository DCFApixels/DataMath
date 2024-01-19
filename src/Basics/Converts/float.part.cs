using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public static partial class math
    {
        [IN(LINE)] public static float float1(bool v) => v ? 1f : 0f;
        [IN(LINE)] public static float float1(int v) => v;
        [IN(LINE)] public static float float1(uint v) => v;
        [IN(LINE)] public static float float1(float v) => v;
        [IN(LINE)] public static float float1(double v) => (float)v;
    }
}
