using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct double2
    {
        #region Convert operators
        [IN(LINE)] public static implicit operator double2((double, double) v) => new double2(v.Item1, v.Item2);

        [IN(LINE)] public static implicit operator double2(float v) => new double2(v);
        [IN(LINE)] public static implicit operator double2(float2 v) => new double2(v);
        [IN(LINE)] public static implicit operator double2(int v) => new double2(v);
        [IN(LINE)] public static implicit operator double2(int2 v) => new double2(v);
        [IN(LINE)] public static implicit operator double2(uint v) => new double2(v);
        [IN(LINE)] public static implicit operator double2(uint2 v) => new double2(v);
        [IN(LINE)] public static implicit operator double2(double v) => new double2(v);
        //[IN(LINE)] public static explicit operator double2(double2 v) => new double2(v);
        #endregion
    }

    public static partial class math
    {
        [IN(LINE)] public static double2 double2((double, double) v) => new double2(v);

        [IN(LINE)] public static double2 double2(float v) => new double2(v);
        [IN(LINE)] public static double2 double2(float2 v) => new double2(v);
        [IN(LINE)] public static double2 double2(int v) => new double2(v);
        [IN(LINE)] public static double2 double2(int2 v) => new double2(v);
        [IN(LINE)] public static double2 double2(uint v) => new double2(v);
        [IN(LINE)] public static double2 double2(uint2 v) => new double2(v);
        [IN(LINE)] public static double2 double2(double v) => new double2(v);
        [IN(LINE)] public static double2 double2(double2 v) => new double2(v);
    }
}
