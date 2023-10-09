using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct int2
    {
        #region Convert operators
        [IN(LINE)] public static implicit operator int2((int, int) v) => new int2(v.Item1, v.Item2);

        [IN(LINE)] public static explicit operator int2(float v) => new int2(v);
        [IN(LINE)] public static explicit operator int2(float2 v) => new int2(v);
        [IN(LINE)] public static implicit operator int2(int v) => new int2(v);
        //[IN(LINE)] public static implicit operator int2(int2 v) => new int2(v);
        [IN(LINE)] public static explicit operator int2(uint v) => new int2(v);
        [IN(LINE)] public static explicit operator int2(uint2 v) => new int2(v);
        [IN(LINE)] public static explicit operator int2(double v) => new int2(v);
        [IN(LINE)] public static explicit operator int2(double2 v) => new int2(v);
        #endregion
    }

    public static partial class math
    {
        [IN(LINE)] public static int2 int2((int, int) v) => new int2(v);

        [IN(LINE)] public static int2 int2(float v) => new int2(v);
        [IN(LINE)] public static int2 int2(float2 v) => new int2(v);
        [IN(LINE)] public static int2 int2(int v) => new int2(v);
        [IN(LINE)] public static int2 int2(int2 v) => new int2(v);
        [IN(LINE)] public static int2 int2(uint v) => new int2(v);
        [IN(LINE)] public static int2 int2(uint2 v) => new int2(v);
        [IN(LINE)] public static int2 int2(double v) => new int2(v);
        [IN(LINE)] public static int2 int2(double2 v) => new int2(v);
    }
}
