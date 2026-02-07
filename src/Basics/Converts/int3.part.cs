#pragma warning disable CS8981
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct int3
    {
        #region Convert operators
        [IN(LINE)] public static implicit operator int3(Axis v) => new int3(v);
        [IN(LINE)] public static implicit operator int3((int, int, int) v) => new int3(v);

        [IN(LINE)] public static explicit operator int3(bool v) => new int3(v);
        [IN(LINE)] public static explicit operator int3(bool3 v) => new int3(v);
        [IN(LINE)] public static implicit operator int3(int v) => new int3(v);
        //[IN(LINE)] public static implicit operator int3(int3 v) => new int3(v);
        [IN(LINE)] public static explicit operator int3(uint v) => new int3(v);
        [IN(LINE)] public static explicit operator int3(uint3 v) => new int3(v);
        [IN(LINE)] public static explicit operator int3(float v) => new int3(v);
        [IN(LINE)] public static explicit operator int3(float3 v) => new int3(v);
        [IN(LINE)] public static explicit operator int3(double v) => new int3(v);
        [IN(LINE)] public static explicit operator int3(double3 v) => new int3(v);
        #endregion

        #region Bool constructors
        [IN(LINE)]
        public int3(bool x, bool y, bool z)
        {
            this.x = x ? 1 : 0; this.y = y ? 1 : 0;
            this.z = z ? 1 : 0;
        }
        [IN(LINE)]
        public int3(bool v)
        {
            x = v ? 1 : 0; y = v ? 1 : 0;
            z = v ? 1 : 0;
        }
        [IN(LINE)]
        public int3(bool3 v)
        {
            x = v.x ? 1 : 0; y = v.y ? 1 : 0;
            z = v.z ? 1 : 0;
        }
        #endregion

        public int3(Axis v)
        {
            switch (v)
            {
                case Axis.X: x = 1; y = 0; z = 0; break;
                case Axis.Y: x = 0; y = 1; z = 0; break;
                case Axis.Z: x = 0; y = 0; z = 1; break;
                default: x = 0; y = 0; z = 0; break;
            }
        }
        public int3(AADirection v)
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
        public int3(AADirectionFlags v)
        {
            int vi = (int)v;
            x = ((vi & (int)AADirectionFlags.Right) >> 1) - (vi & (int)AADirectionFlags.Left);
            y = ((vi & (int)AADirectionFlags.Up) >> 3) - ((vi & (int)AADirectionFlags.Down) >> 2);
            z = ((vi & (int)AADirectionFlags.Forward) >> 5) - ((vi & (int)AADirectionFlags.Back) >> 4);
        }

        #region Arithmetic float
        [IN(LINE)] public static float3 operator +(int3 a, float b) { return new float3(a.x + b, a.y + b, a.z + b); }
        [IN(LINE)] public static float3 operator +(float a, int3 b) { return new float3(a + b.x, a + b.y, a + b.z); }
        [IN(LINE)] public static float3 operator -(int3 a, float b) { return new float3(a.x - b, a.y - b, a.z - b); }
        [IN(LINE)] public static float3 operator -(float a, int3 b) { return new float3(a - b.x, a - b.y, a - b.z); }
        [IN(LINE)] public static float3 operator *(int3 a, float b) { return new float3(a.x * b, a.y * b, a.z * b); }
        [IN(LINE)] public static float3 operator *(float a, int3 b) { return new float3(a * b.x, a * b.y, a * b.z); }
        [IN(LINE)] public static float3 operator /(int3 a, float b) { return new float3(a.x / b, a.y / b, a.z / b); }
        [IN(LINE)] public static float3 operator /(float a, int3 b) { return new float3(a / b.x, a / b.y, a / b.z); }
        [IN(LINE)] public static float3 operator %(int3 a, float b) { return new float3(a.x % b, a.y % b, a.z % b); }
        [IN(LINE)] public static float3 operator %(float a, int3 b) { return new float3(a % b.x, a % b.y, a % b.z); }
        #endregion

        #region Arithmetic double
        [IN(LINE)] public static double3 operator +(int3 a, double b) { return new double3(a.x + b, a.y + b, a.z + b); }
        [IN(LINE)] public static double3 operator +(double a, int3 b) { return new double3(a + b.x, a + b.y, a + b.z); }
        [IN(LINE)] public static double3 operator -(int3 a, double b) { return new double3(a.x - b, a.y - b, a.z - b); }
        [IN(LINE)] public static double3 operator -(double a, int3 b) { return new double3(a - b.x, a - b.y, a - b.z); }
        [IN(LINE)] public static double3 operator *(int3 a, double b) { return new double3(a.x * b, a.y * b, a.z * b); }
        [IN(LINE)] public static double3 operator *(double a, int3 b) { return new double3(a * b.x, a * b.y, a * b.z); }
        [IN(LINE)] public static double3 operator /(int3 a, double b) { return new double3(a.x / b, a.y / b, a.z / b); }
        [IN(LINE)] public static double3 operator /(double a, int3 b) { return new double3(a / b.x, a / b.y, a / b.z); }
        [IN(LINE)] public static double3 operator %(int3 a, double b) { return new double3(a.x % b, a.y % b, a.z % b); }
        [IN(LINE)] public static double3 operator %(double a, int3 b) { return new double3(a % b.x, a % b.y, a % b.z); }
        #endregion
    }

    public static partial class DM
    {
        [IN(LINE)] public static int3 Int3((int, int, int) v) => new int3(v);
        [IN(LINE)] public static int3 Int3<T>(T v) where T : IVector3<int> => new int3(v.x, v.y, v.z);
        [IN(LINE)] public static int3 Int3(bool v) => new int3(v);
        [IN(LINE)] public static int3 Int3(bool3 v) => new int3(v);
        [IN(LINE)] public static int3 Int3(int v) => new int3(v);
        [IN(LINE)] public static int3 Int3(int3 v) => new int3(v);
        [IN(LINE)] public static int3 Int3(uint v) => new int3(v);
        [IN(LINE)] public static int3 Int3(uint3 v) => new int3(v);
        [IN(LINE)] public static int3 Int3(float v) => new int3(v);
        [IN(LINE)] public static int3 Int3(float3 v) => new int3(v);
        [IN(LINE)] public static int3 Int3(double v) => new int3(v);
        [IN(LINE)] public static int3 Int3(double3 v) => new int3(v);
    }
}
