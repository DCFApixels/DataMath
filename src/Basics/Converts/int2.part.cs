#pragma warning disable CS8981
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct int2
    {
        #region Convert operators
        [IN(LINE)] public static implicit operator int2(Axis v) => new int2(v);
        [IN(LINE)] public static implicit operator int2((int, int) v) => new int2(v);

        [IN(LINE)] public static explicit operator int2(bool v) => new int2(v);
        [IN(LINE)] public static explicit operator int2(bool2 v) => new int2(v);
        [IN(LINE)] public static implicit operator int2(int v) => new int2(v);
        //[IN(LINE)] public static implicit operator int2(int2 v) => new int2(v);
        [IN(LINE)] public static explicit operator int2(uint v) => new int2(v);
        [IN(LINE)] public static explicit operator int2(uint2 v) => new int2(v);
        [IN(LINE)] public static explicit operator int2(float v) => new int2(v);
        [IN(LINE)] public static explicit operator int2(float2 v) => new int2(v);
        [IN(LINE)] public static explicit operator int2(double v) => new int2(v);
        [IN(LINE)] public static explicit operator int2(double2 v) => new int2(v);
        #endregion

        #region Bool constructors
        [IN(LINE)]
        public int2(bool x, bool y)
        {
            this.x = x ? 1 : 0; this.y = y ? 1 : 0;
        }
        [IN(LINE)]
        public int2(bool v)
        {
            x = v ? 1 : 0; y = v ? 1 : 0;
        }
        [IN(LINE)]
        public int2(bool2 v)
        {
            x = v.x ? 1 : 0; y = v.y ? 1 : 0;
        }
        #endregion

        [IN(LINE)] public int2((int x, int y) v) { x = v.x; y = v.y; }
        [IN(LINE)]
        public int2(Axis v)
        {
            switch (v)
            {
                case Axis.X: x = 1; y = 0; break;
                case Axis.Y: x = 0; y = 1; break;
                default: x = 0; y = 0; break;
            }
        }
        public int2(AADirection v)
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
        public int2(AADirectionFlags v)
        {
            int vi = (int)v;
            x = ((vi & (int)AADirectionFlags.Right) >> 1) - (vi & (int)AADirectionFlags.Left);
            y = ((vi & (int)AADirectionFlags.Up) >> 3) - ((vi & (int)AADirectionFlags.Down) >> 2);
        }
        public int2(int v, Swizzle swizzle, bool _ = false) : this()
        {
            int swizzleRaw = (int)swizzle;
            x = ((swizzleRaw & 7) - 1) == 1 ? 1 : 0; swizzleRaw >>= 3;
            y = ((swizzleRaw & 7) - 1) == 1 ? 1 : 0;
        }
        public int2(int2 v, Swizzle swizzle, bool _ = false) : this()
        {
            int swizzleRaw = (int)swizzle;
            x = v[(swizzleRaw & 7) - 1]; swizzleRaw >>= 3;
            y = v[(swizzleRaw & 7) - 1];
        }
        public int2(int3 v, Swizzle swizzle, bool _ = false) : this()
        {
            int swizzleRaw = (int)swizzle;
            x = v[(swizzleRaw & 7) - 1]; swizzleRaw >>= 3;
            y = v[(swizzleRaw & 7) - 1];
        }
        public int2(int4 v, Swizzle swizzle, bool _ = false) : this()
        {
            int swizzleRaw = (int)swizzle;
            x = v[(swizzleRaw & 7) - 1]; swizzleRaw >>= 3;
            y = v[(swizzleRaw & 7) - 1];
        }

        #region Arithmetic float
        [IN(LINE)] public static float2 operator +(int2 a, float b) { return new float2(a.x + b, a.y + b); }
        [IN(LINE)] public static float2 operator +(float a, int2 b) { return new float2(a + b.x, a + b.y); }
        [IN(LINE)] public static float2 operator -(int2 a, float b) { return new float2(a.x - b, a.y - b); }
        [IN(LINE)] public static float2 operator -(float a, int2 b) { return new float2(a - b.x, a - b.y); }
        [IN(LINE)] public static float2 operator *(int2 a, float b) { return new float2(a.x * b, a.y * b); }
        [IN(LINE)] public static float2 operator *(float a, int2 b) { return new float2(a * b.x, a * b.y); }
        [IN(LINE)] public static float2 operator /(int2 a, float b) { return new float2(a.x / b, a.y / b); }
        [IN(LINE)] public static float2 operator /(float a, int2 b) { return new float2(a / b.x, a / b.y); }
        [IN(LINE)] public static float2 operator %(int2 a, float b) { return new float2(a.x % b, a.y % b); }
        [IN(LINE)] public static float2 operator %(float a, int2 b) { return new float2(a % b.x, a % b.y); }
        #endregion

        #region Arithmetic double
        [IN(LINE)] public static double2 operator +(int2 a, double b) { return new double2(a.x + b, a.y + b); }
        [IN(LINE)] public static double2 operator +(double a, int2 b) { return new double2(a + b.x, a + b.y); }
        [IN(LINE)] public static double2 operator -(int2 a, double b) { return new double2(a.x - b, a.y - b); }
        [IN(LINE)] public static double2 operator -(double a, int2 b) { return new double2(a - b.x, a - b.y); }
        [IN(LINE)] public static double2 operator *(int2 a, double b) { return new double2(a.x * b, a.y * b); }
        [IN(LINE)] public static double2 operator *(double a, int2 b) { return new double2(a * b.x, a * b.y); }
        [IN(LINE)] public static double2 operator /(int2 a, double b) { return new double2(a.x / b, a.y / b); }
        [IN(LINE)] public static double2 operator /(double a, int2 b) { return new double2(a / b.x, a / b.y); }
        [IN(LINE)] public static double2 operator %(int2 a, double b) { return new double2(a.x % b, a.y % b); }
        [IN(LINE)] public static double2 operator %(double a, int2 b) { return new double2(a % b.x, a % b.y); }
        #endregion
    }

    public static partial class DM
    {
        [IN(LINE)] public static int2 Int2((int, int) v) => new int2(v);
        [IN(LINE)] public static int2 Int2<T>(T v) where T : IVector2<int> => new int2(v.x, v.y);
        [IN(LINE)] public static int2 Int2(bool v) => new int2(v);
        [IN(LINE)] public static int2 Int2(bool2 v) => new int2(v);
        [IN(LINE)] public static int2 Int2(int v) => new int2(v);
        [IN(LINE)] public static int2 Int2(int2 v) => new int2(v);
        [IN(LINE)] public static int2 Int2(uint v) => new int2(v);
        [IN(LINE)] public static int2 Int2(uint2 v) => new int2(v);
        [IN(LINE)] public static int2 Int2(float v) => new int2(v);
        [IN(LINE)] public static int2 Int2(float2 v) => new int2(v);
        [IN(LINE)] public static int2 Int2(double v) => new int2(v);
        [IN(LINE)] public static int2 Int2(double2 v) => new int2(v);
    }
}
