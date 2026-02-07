#pragma warning disable CS8981
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct double3
    {
        #region Convert operators
        [IN(LINE)] public static implicit operator double3(Axis v) => new double3(v);
        [IN(LINE)] public static implicit operator double3((double, double, double) v) => new double3(v);

        [IN(LINE)] public static explicit operator double3(bool v) => new double3(v);
        [IN(LINE)] public static explicit operator double3(bool3 v) => new double3(v);
        [IN(LINE)] public static implicit operator double3(int v) => new double3(v);
        [IN(LINE)] public static implicit operator double3(int3 v) => new double3(v);
        [IN(LINE)] public static implicit operator double3(uint v) => new double3(v);
        [IN(LINE)] public static implicit operator double3(uint3 v) => new double3(v);
        [IN(LINE)] public static implicit operator double3(float v) => new double3(v);
        [IN(LINE)] public static implicit operator double3(float3 v) => new double3(v);
        [IN(LINE)] public static implicit operator double3(double v) => new double3(v);
        //[IN(LINE)] public static explicit operator double3(double3 v) => new double3(v);
        #endregion

        #region Bool constructors
        [IN(LINE)]
        public double3(bool x, bool y, bool z)
        {
            this.x = x ? 1d : 0d; this.y = y ? 1d : 0d;
            this.z = z ? 1d : 0d;
        }
        [IN(LINE)]
        public double3(bool v)
        {
            x = v ? 1d : 0d; y = v ? 1d : 0d;
            z = v ? 1d : 0d;
        }
        [IN(LINE)]
        public double3(bool3 v)
        {
            x = v.x ? 1d : 0d; y = v.y ? 1d : 0d;
            z = v.z ? 1d : 0d;
        }
        #endregion

        [IN(LINE)]
        public double3(Axis v)
        {
            switch (v)
            {
                case Axis.X: x = 1; y = 0; z = 0; break;
                case Axis.Y: x = 0; y = 1; z = 0; break;
                case Axis.Z: x = 0; y = 0; z = 1; break;
                default: x = 0; y = 0; z = 0; break;
            }
        }
        public double3(AADirection v)
        {
            switch (v)
            {
                case AADirection.Left: x = -1; y = 0; z = 0; break;
                case AADirection.Right: x = 1; y = 0; z = 0; break;
                case AADirection.Down: x = 0; y = -1; z = 0; break;
                case AADirection.Up: x = 0; y = 1; z = 0; break;
                case AADirection.Back: x = 0; y = 0; z = -1; break;
                case AADirection.Forward: x = 0; y = 0; z = 1; break;
                default: x = 0; y = 0; z = 0; break;
            }
        }
    }

    public static partial class DM
    {
        [IN(LINE)] public static double3 Double3((double, double, double) v) => new double3(v);
        [IN(LINE)] public static double3 Double3<T>(T v) where T : IVector3<double> => new double3(v.x, v.y, v.z);
        [IN(LINE)] public static double3 Double3(bool v) => new double3(v);
        [IN(LINE)] public static double3 Double3(bool3 v) => new double3(v);
        [IN(LINE)] public static double3 Double3(int v) => new double3(v);
        [IN(LINE)] public static double3 Double3(int3 v) => new double3(v);
        [IN(LINE)] public static double3 Double3(uint v) => new double3(v);
        [IN(LINE)] public static double3 Double3(uint3 v) => new double3(v);
        [IN(LINE)] public static double3 Double3(float v) => new double3(v);
        [IN(LINE)] public static double3 Double3(float3 v) => new double3(v);
        [IN(LINE)] public static double3 Double3(double v) => new double3(v);
        [IN(LINE)] public static double3 Double3(double3 v) => new double3(v);
    }
}
