#pragma warning disable CS8981
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct double4
    {
        #region Convert operators
        [IN(LINE)] public static implicit operator double4(Axis v) => new double4(v);
        [IN(LINE)] public static implicit operator double4((double, double, double, double) v) => new double4(v);

        [IN(LINE)] public static explicit operator double4(bool v) => new double4(v);
        [IN(LINE)] public static explicit operator double4(bool4 v) => new double4(v);
        [IN(LINE)] public static implicit operator double4(int v) => new double4(v);
        [IN(LINE)] public static implicit operator double4(int4 v) => new double4(v);
        [IN(LINE)] public static implicit operator double4(uint v) => new double4(v);
        [IN(LINE)] public static implicit operator double4(uint4 v) => new double4(v);
        [IN(LINE)] public static implicit operator double4(float v) => new double4(v);
        [IN(LINE)] public static implicit operator double4(float4 v) => new double4(v);
        [IN(LINE)] public static implicit operator double4(double v) => new double4(v);
        //[IN(LINE)] public static explicit operator double4(double4 v) => new double4(v);
        #endregion

        #region Bool constructors
        [IN(LINE)]
        public double4(bool x, bool y, bool z, bool w)
        {
            this.x = x ? 1d : 0d; this.y = y ? 1d : 0d;
            this.z = z ? 1d : 0d; this.w = w ? 1d : 0d;
        }
        [IN(LINE)]
        public double4(bool v)
        {
            x = v ? 1d : 0d; y = v ? 1d : 0d;
            z = v ? 1d : 0d; w = v ? 1d : 0d;
        }
        [IN(LINE)]
        public double4(bool4 v)
        {
            x = v.x ? 1d : 0d; y = v.y ? 1d : 0d;
            z = v.z ? 1d : 0d; w = v.w ? 1d : 0d;
        }
        #endregion

        public double4(Axis v)
        {
            switch (v)
            {
                case Axis.X: x = 1; y = 0; z = 0; w = 0; break;
                case Axis.Y: x = 0; y = 1; z = 0; w = 0; break;
                case Axis.Z: x = 0; y = 0; z = 1; w = 0; break;
                case Axis.W: x = 0; y = 0; z = 0; w = 1; break;
                default: x = 0; y = 0; z = 0; w = 0; break;
            }
        }
        public double4(AADirection v)
        {
            switch (v)
            {
                case AADirection.Left: x = -1; y = 0; z = 0; w = 0; break;
                case AADirection.Right: x = 1; y = 0; z = 0; w = 0; break;
                case AADirection.Down: x = 0; y = -1; z = 0; w = 0; break;
                case AADirection.Up: x = 0; y = 1; z = 0; w = 0; break;
                case AADirection.Back: x = 0; y = 0; z = -1; w = 0; break;
                case AADirection.Forward: x = 0; y = 0; z = 1; w = 0; break;
                case AADirection.Before: x = 0; y = 0; z = 0; w = -1; break;
                case AADirection.After: x = 0; y = 0; z = 0; w = 1; break;
                default: x = 0; y = 0; z = 0; w = 0; break;
            }
        }
        public double4(double v, Swizzle swizzle, bool _ = false) : this()
        {
            int swizzleRaw = (int)swizzle;
            x = ((swizzleRaw & 7) - 1) == 1 ? 1 : 0; swizzleRaw >>= 3;
            y = ((swizzleRaw & 7) - 1) == 1 ? 1 : 0; swizzleRaw >>= 3;
            z = ((swizzleRaw & 7) - 1) == 1 ? 1 : 0; swizzleRaw >>= 3;
            w = ((swizzleRaw & 7) - 1) == 1 ? 1 : 0;
        }
        public double4(double2 v, Swizzle swizzle, bool _ = false) : this()
        {
            int swizzleRaw = (int)swizzle;
            x = v[(swizzleRaw & 7) - 1]; swizzleRaw >>= 3;
            y = v[(swizzleRaw & 7) - 1]; swizzleRaw >>= 3;
            z = v[(swizzleRaw & 7) - 1]; swizzleRaw >>= 3;
            w = v[(swizzleRaw & 7) - 1];
        }
        public double4(double3 v, Swizzle swizzle, bool _ = false) : this()
        {
            int swizzleRaw = (int)swizzle;
            x = v[(swizzleRaw & 7) - 1]; swizzleRaw >>= 3;
            y = v[(swizzleRaw & 7) - 1]; swizzleRaw >>= 3;
            z = v[(swizzleRaw & 7) - 1]; swizzleRaw >>= 3;
            w = v[(swizzleRaw & 7) - 1];
        }
        public double4(double4 v, Swizzle swizzle, bool _ = false) : this()
        {
            int swizzleRaw = (int)swizzle;
            x = v[(swizzleRaw & 7) - 1]; swizzleRaw >>= 3;
            y = v[(swizzleRaw & 7) - 1]; swizzleRaw >>= 3;
            z = v[(swizzleRaw & 7) - 1]; swizzleRaw >>= 3;
            w = v[(swizzleRaw & 7) - 1];
        }
    }

    public static partial class DM
    {
        [IN(LINE)] public static double4 Double4((double, double, double, double) v) => new double4(v);
        [IN(LINE)] public static double4 Double4<T>(T v) where T : IVector4<double> => new double4(v.x, v.y, v.z, v.w);
        [IN(LINE)] public static double4 Double4(bool v) => new double4(v);
        [IN(LINE)] public static double4 Double4(bool4 v) => new double4(v);
        [IN(LINE)] public static double4 Double4(int v) => new double4(v);
        [IN(LINE)] public static double4 Double4(int4 v) => new double4(v);
        [IN(LINE)] public static double4 Double4(uint v) => new double4(v);
        [IN(LINE)] public static double4 Double4(uint4 v) => new double4(v);
        [IN(LINE)] public static double4 Double4(float v) => new double4(v);
        [IN(LINE)] public static double4 Double4(float4 v) => new double4(v);
        [IN(LINE)] public static double4 Double4(double v) => new double4(v);
        [IN(LINE)] public static double4 Double4(double4 v) => new double4(v);
    }
}