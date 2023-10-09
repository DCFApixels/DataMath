using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct double4 
    {
        #region Convert operators
        [IN(LINE)] public static implicit operator double4((double, double, double, double) v) => new double4(v.Item1, v.Item2, v.Item3, v.Item4);

        [IN(LINE)] public static implicit operator double4(float v) => new double4(v);
        [IN(LINE)] public static implicit operator double4(float4 v) => new double4(v);
        [IN(LINE)] public static implicit operator double4(int v) => new double4(v);
        [IN(LINE)] public static implicit operator double4(int4 v) => new double4(v);
        [IN(LINE)] public static implicit operator double4(uint v) => new double4(v);
        [IN(LINE)] public static implicit operator double4(uint4 v) => new double4(v);
        [IN(LINE)] public static implicit operator double4(double v) => new double4(v);
        //[IN(LINE)] public static explicit operator double4(double4 v) => new double4(v);
        #endregion
    }

    public static partial class math
    {
        [IN(LINE)] public static double4 double4((double, double, double, double) v) => new double4(v);

        [IN(LINE)] public static double4 double4(float v) => new double4(v);
        [IN(LINE)] public static double4 double4(float4 v) => new double4(v);
        [IN(LINE)] public static double4 double4(int v) => new double4(v);
        [IN(LINE)] public static double4 double4(int4 v) => new double4(v);
        [IN(LINE)] public static double4 double4(uint v) => new double4(v);
        [IN(LINE)] public static double4 double4(uint4 v) => new double4(v);
        [IN(LINE)] public static double4 double4(double v) => new double4(v);
        [IN(LINE)] public static double4 double4(double4 v) => new double4(v);
    }
}
