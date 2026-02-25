#pragma warning disable CS8981
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct int4
    {
        #region Convert operators
        [IN(LINE)] public static implicit operator int4(Axis v) => new int4(v);
        [IN(LINE)] public static implicit operator int4((int, int, int, int) v) => new int4(v);

        [IN(LINE)] public static explicit operator int4(bool v) => new int4(v);
        [IN(LINE)] public static explicit operator int4(bool4 v) => new int4(v);
        [IN(LINE)] public static implicit operator int4(int v) => new int4(v);
        //[IN(LINE)] public static implicit operator int4(int4 v) => new int4(v);
        [IN(LINE)] public static explicit operator int4(uint v) => new int4(v);
        [IN(LINE)] public static explicit operator int4(uint4 v) => new int4(v);
        [IN(LINE)] public static explicit operator int4(float v) => new int4(v);
        [IN(LINE)] public static explicit operator int4(float4 v) => new int4(v);
        [IN(LINE)] public static explicit operator int4(double v) => new int4(v);
        [IN(LINE)] public static explicit operator int4(double4 v) => new int4(v);
        #endregion

        #region Bool constructors
        [IN(LINE)]
        public int4(bool x, bool y, bool z, bool w)
        {
            this.x = x ? 1 : 0; this.y = y ? 1 : 0;
            this.z = z ? 1 : 0; this.w = w ? 1 : 0;
        }
        [IN(LINE)]
        public int4(bool v)
        {
            x = v ? 1 : 0; y = v ? 1 : 0;
            z = v ? 1 : 0; w = v ? 1 : 0;
        }
        [IN(LINE)]
        public int4(bool4 v)
        {
            x = v.x ? 1 : 0; y = v.y ? 1 : 0;
            z = v.z ? 1 : 0; w = v.w ? 1 : 0;
        }
        #endregion

        public int4(Axis v)
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
        public int4(AADirection v)
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
        public int4(AADirectionFlags v)
        {
            int vi = (int)v;
            x = ((vi & (int)AADirectionFlags.Right) >> 1) - (vi & (int)AADirectionFlags.Left);
            y = ((vi & (int)AADirectionFlags.Up) >> 3) - ((vi & (int)AADirectionFlags.Down) >> 2);
            z = ((vi & (int)AADirectionFlags.Forward) >> 5) - ((vi & (int)AADirectionFlags.Back) >> 4);
            w = ((vi & (int)AADirectionFlags.After) >> 7) - ((vi & (int)AADirectionFlags.Before) >> 6);
        }
        public int4(int v, Swizzle swizzle, bool _ = false) : this()
        {
            int swizzleRaw = (int)swizzle;
            x = ((swizzleRaw & 7) - 1) == 1 ? 1 : 0; swizzleRaw >>= 3;
            y = ((swizzleRaw & 7) - 1) == 1 ? 1 : 0; swizzleRaw >>= 3;
            z = ((swizzleRaw & 7) - 1) == 1 ? 1 : 0; swizzleRaw >>= 3;
            w = ((swizzleRaw & 7) - 1) == 1 ? 1 : 0;
        }
        public int4(int2 v, Swizzle swizzle, bool _ = false) : this()
        {
            int swizzleRaw = (int)swizzle;
            x = v[(swizzleRaw & 7) - 1]; swizzleRaw >>= 3;
            y = v[(swizzleRaw & 7) - 1]; swizzleRaw >>= 3;
            z = v[(swizzleRaw & 7) - 1]; swizzleRaw >>= 3;
            w = v[(swizzleRaw & 7) - 1];
        }
        public int4(int3 v, Swizzle swizzle, bool _ = false) : this()
        {
            int swizzleRaw = (int)swizzle;
            x = v[(swizzleRaw & 7) - 1]; swizzleRaw >>= 3;
            y = v[(swizzleRaw & 7) - 1]; swizzleRaw >>= 3;
            z = v[(swizzleRaw & 7) - 1]; swizzleRaw >>= 3;
            w = v[(swizzleRaw & 7) - 1];
        }
        public int4(int4 v, Swizzle swizzle, bool _ = false) : this()
        {
            int swizzleRaw = (int)swizzle;
            x = v[(swizzleRaw & 7) - 1]; swizzleRaw >>= 3;
            y = v[(swizzleRaw & 7) - 1]; swizzleRaw >>= 3;
            z = v[(swizzleRaw & 7) - 1]; swizzleRaw >>= 3;
            w = v[(swizzleRaw & 7) - 1];
        }

        #region Arithmetic float
        [IN(LINE)] public static float4 operator +(int4 a, float b) { return new float4(a.x + b, a.y + b, a.z + b, a.w + b); }
        [IN(LINE)] public static float4 operator +(float a, int4 b) { return new float4(a + b.x, a + b.y, a + b.z, a + b.w); }
        [IN(LINE)] public static float4 operator -(int4 a, float b) { return new float4(a.x - b, a.y - b, a.z - b, a.w - b); }
        [IN(LINE)] public static float4 operator -(float a, int4 b) { return new float4(a - b.x, a - b.y, a - b.z, a - b.w); }
        [IN(LINE)] public static float4 operator *(int4 a, float b) { return new float4(a.x * b, a.y * b, a.z * b, a.w * b); }
        [IN(LINE)] public static float4 operator *(float a, int4 b) { return new float4(a * b.x, a * b.y, a * b.z, a * b.w); }
        [IN(LINE)] public static float4 operator /(int4 a, float b) { return new float4(a.x / b, a.y / b, a.z / b, a.w / b); }
        [IN(LINE)] public static float4 operator /(float a, int4 b) { return new float4(a / b.x, a / b.y, a / b.z, a / b.w); }
        [IN(LINE)] public static float4 operator %(int4 a, float b) { return new float4(a.x % b, a.y % b, a.z % b, a.w % b); }
        [IN(LINE)] public static float4 operator %(float a, int4 b) { return new float4(a % b.x, a % b.y, a % b.z, a % b.w); }
        #endregion

        #region Arithmetic double
        [IN(LINE)] public static double4 operator +(int4 a, double b) { return new double4(a.x + b, a.y + b, a.z + b, a.w + b); }
        [IN(LINE)] public static double4 operator +(double a, int4 b) { return new double4(a + b.x, a + b.y, a + b.z, a + b.w); }
        [IN(LINE)] public static double4 operator -(int4 a, double b) { return new double4(a.x - b, a.y - b, a.z - b, a.w - b); }
        [IN(LINE)] public static double4 operator -(double a, int4 b) { return new double4(a - b.x, a - b.y, a - b.z, a - b.w); }
        [IN(LINE)] public static double4 operator *(int4 a, double b) { return new double4(a.x * b, a.y * b, a.z * b, a.w * b); }
        [IN(LINE)] public static double4 operator *(double a, int4 b) { return new double4(a * b.x, a * b.y, a * b.z, a * b.w); }
        [IN(LINE)] public static double4 operator /(int4 a, double b) { return new double4(a.x / b, a.y / b, a.z / b, a.w / b); }
        [IN(LINE)] public static double4 operator /(double a, int4 b) { return new double4(a / b.x, a / b.y, a / b.z, a / b.w); }
        [IN(LINE)] public static double4 operator %(int4 a, double b) { return new double4(a.x % b, a.y % b, a.z % b, a.w % b); }
        [IN(LINE)] public static double4 operator %(double a, int4 b) { return new double4(a % b.x, a % b.y, a % b.z, a % b.w); }
        #endregion
    }

    public static partial class DM
    {
        [IN(LINE)] public static int4 Int4((int, int, int, int) v) => new int4(v);
        [IN(LINE)] public static int4 Int4<T>(T v) where T : IVector4<int> => new int4(v.x, v.y, v.z, v.w);
        [IN(LINE)] public static int4 Int4(bool v) => new int4(v);
        [IN(LINE)] public static int4 Int4(bool4 v) => new int4(v);
        [IN(LINE)] public static int4 Int4(int v) => new int4(v);
        [IN(LINE)] public static int4 Int4(int4 v) => new int4(v);
        [IN(LINE)] public static int4 Int4(uint v) => new int4(v);
        [IN(LINE)] public static int4 Int4(uint4 v) => new int4(v);
        [IN(LINE)] public static int4 Int4(float v) => new int4(v);
        [IN(LINE)] public static int4 Int4(float4 v) => new int4(v);
        [IN(LINE)] public static int4 Int4(double v) => new int4(v);
        [IN(LINE)] public static int4 Int4(double4 v) => new int4(v);
    }
}
