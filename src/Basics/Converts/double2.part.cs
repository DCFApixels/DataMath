#pragma warning disable CS8981
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct double2
    {
        #region Convert operators
        [IN(LINE)] public static implicit operator double2(Axis v) => new double2(v);
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

        [IN(LINE)] public double2((double x, double y) v) { x = v.x; y = v.y; }
        [IN(LINE)]
        public double2(Axis v)
        {
            switch (v)
            {
                case Axis.X: x = 1; y = 0; break;
                case Axis.Y: x = 0; y = 1; break;
                default: x = 0; y = 0; break;
            }
        }
        public double2(AADirection v)
        {
            switch (v)
            {
                case AADirection.Left: x = -1; y = 0; break;
                case AADirection.Right: x = 1; y = 0; break;
                case AADirection.Down: x = 0; y = -1; break;
                case AADirection.Up: x = 0; y = 1; break;
                default: x = 0; y = 0; break;
            }
        }
        public double2(double v, Swizzle swizzle, bool _ = false) : this()
        {
            int swizzleRaw = (int)swizzle;
            x = ((swizzleRaw & 7) - 1) == 1 ? 1 : 0; swizzleRaw >>= 3;
            y = ((swizzleRaw & 7) - 1) == 1 ? 1 : 0;
        }
        public double2(double2 v, Swizzle swizzle, bool _ = false) : this()
        {
            int swizzleRaw = (int)swizzle;
            x = v[(swizzleRaw & 7) - 1]; swizzleRaw >>= 3;
            y = v[(swizzleRaw & 7) - 1];
        }
        public double2(double3 v, Swizzle swizzle, bool _ = false) : this()
        {
            int swizzleRaw = (int)swizzle;
            x = v[(swizzleRaw & 7) - 1]; swizzleRaw >>= 3;
            y = v[(swizzleRaw & 7) - 1];
        }
        public double2(double4 v, Swizzle swizzle, bool _ = false) : this()
        {
            int swizzleRaw = (int)swizzle;
            x = v[(swizzleRaw & 7) - 1]; swizzleRaw >>= 3;
            y = v[(swizzleRaw & 7) - 1];
        }
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
