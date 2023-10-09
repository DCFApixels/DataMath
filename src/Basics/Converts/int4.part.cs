using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct int4
    {
        #region Convert operators
        [IN(LINE)] public static implicit operator int4((int, int, int, int) v) => new int4(v.Item1, v.Item2, v.Item3, v.Item4);

        [IN(LINE)] public static explicit operator int4(float v) => new int4(v);
        [IN(LINE)] public static explicit operator int4(float4 v) => new int4(v);
        [IN(LINE)] public static implicit operator int4(int v) => new int4(v);
        //[IN(LINE)] public static implicit operator int4(int4 v) => new int4(v);
        [IN(LINE)] public static explicit operator int4(uint v) => new int4(v);
        [IN(LINE)] public static explicit operator int4(uint4 v) => new int4(v);
        [IN(LINE)] public static explicit operator int4(double v) => new int4(v);
        [IN(LINE)] public static explicit operator int4(double4 v) => new int4(v);
        #endregion
    }

    public static partial class math
    {
        [IN(LINE)] public static int4 int4((int, int, int, int) v) => new int4(v);

        [IN(LINE)] public static int4 int4(float v) => new int4(v);
        [IN(LINE)] public static int4 int4(float4 v) => new int4(v);
        [IN(LINE)] public static int4 int4(int v) => new int4(v);
        [IN(LINE)] public static int4 int4(int4 v) => new int4(v);
        [IN(LINE)] public static int4 int4(uint v) => new int4(v);
        [IN(LINE)] public static int4 int4(uint4 v) => new int4(v);
        [IN(LINE)] public static int4 int4(double v) => new int4(v);
        [IN(LINE)] public static int4 int4(double4 v) => new int4(v);
    }
}
