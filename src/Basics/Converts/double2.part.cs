#pragma warning disable CS8981
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct double2
    {
        #region Convert operators
        [IN(LINE)] public static implicit operator double2((double, double) v) => new double2(v);

        [IN(LINE)] public static explicit operator double2(bool v) => new double2(v);
        [IN(LINE)] public static explicit operator double2(bool2 v) => new double2(v);
        [IN(LINE)] public static implicit operator double2(int v) => new double2(v);
        [IN(LINE)] public static implicit operator double2(int2 v) => new double2(v);
        [IN(LINE)] public static implicit operator double2(uint v) => new double2(v);
        [IN(LINE)] public static implicit operator double2(uint2 v) => new double2(v);
        [IN(LINE)] public static implicit operator double2(float v) => new double2(v);
        [IN(LINE)] public static implicit operator double2(float2 v) => new double2(v);
        [IN(LINE)] public static implicit operator double2(double v) => new double2(v);
        //[IN(LINE)] public static explicit operator double2(double2 v) => new double2(v);
        #endregion

        #region Bool constructors
        [IN(LINE)]
        public double2(bool x, bool y)
        {
            this.x = x ? 1d : 0d; this.y = y ? 1d : 0d;
        }
        [IN(LINE)]
        public double2(bool v)
        {
            x = v ? 1d : 0d; y = v ? 1d : 0d;
        }
        [IN(LINE)]
        public double2(bool2 v)
        {
            x = v.x ? 1d : 0d; y = v.y ? 1d : 0d;
        }
        #endregion
    }

    public static partial class DM
    {
        [IN(LINE)] public static double2 Double2((double, double) v) => new double2(v);
        [IN(LINE)] public static double2 Double2<T>(T v) where T : IVector2<double> => new double2(v.x, v.y);
        [IN(LINE)] public static double2 Double2(bool v) => new double2(v);
        [IN(LINE)] public static double2 Double2(bool2 v) => new double2(v);
        [IN(LINE)] public static double2 Double2(int v) => new double2(v);
        [IN(LINE)] public static double2 Double2(int2 v) => new double2(v);
        [IN(LINE)] public static double2 Double2(uint v) => new double2(v);
        [IN(LINE)] public static double2 Double2(uint2 v) => new double2(v);
        [IN(LINE)] public static double2 Double2(float v) => new double2(v);
        [IN(LINE)] public static double2 Double2(float2 v) => new double2(v);
        [IN(LINE)] public static double2 Double2(double v) => new double2(v);
        [IN(LINE)] public static double2 Double2(double2 v) => new double2(v);
    }
}
