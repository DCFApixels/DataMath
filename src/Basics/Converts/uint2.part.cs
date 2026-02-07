#pragma warning disable CS8981
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct uint2
    {
        #region Convert operators
        [IN(LINE)] public static implicit operator uint2(Axis v) => new uint2(v);
        [IN(LINE)] public static implicit operator uint2((uint, uint) v) => new uint2(v);

        [IN(LINE)] public static explicit operator uint2(bool v) => new uint2(v);
        [IN(LINE)] public static explicit operator uint2(bool2 v) => new uint2(v);
        [IN(LINE)] public static explicit operator uint2(int v) => new uint2(v);
        [IN(LINE)] public static explicit operator uint2(int2 v) => new uint2(v);
        [IN(LINE)] public static implicit operator uint2(uint v) => new uint2(v);
        //[IN(LINE)] public static implicit operator uint2(uint2 v) => new uint2(v);
        [IN(LINE)] public static explicit operator uint2(float v) => new uint2(v);
        [IN(LINE)] public static explicit operator uint2(float2 v) => new uint2(v);
        [IN(LINE)] public static explicit operator uint2(double v) => new uint2(v);
        [IN(LINE)] public static explicit operator uint2(double2 v) => new uint2(v);
        #endregion

        #region Bool constructors
        [IN(LINE)]
        public uint2(bool x, bool y)
        {
            this.x = x ? 1u : 0u; this.y = y ? 1u : 0u;
        }
        [IN(LINE)]
        public uint2(bool v)
        {
            x = v ? 1u : 0u; y = v ? 1u : 0u;
        }
        [IN(LINE)]
        public uint2(bool2 v)
        {
            x = v.x ? 1u : 0u; y = v.y ? 1u : 0u;
        }
        #endregion

        [IN(LINE)] public uint2((uint x, uint y) v) { x = v.x; y = v.y; }
        [IN(LINE)]
        public uint2(Axis v)
        {
            switch (v)
            {
                case Axis.X: x = 1; y = 0; break;
                case Axis.Y: x = 0; y = 1; break;
                default: x = 0; y = 0; break;
            }
        }
        public uint2(AADirection v)
        {
            switch (v)
            {
                case AADirection.Left: x = unchecked((uint)-1u); y = 0; break;
                case AADirection.Right: x = 1; y = 0; break;
                case AADirection.Down: x = 0; y = unchecked((uint)-1u); break;
                case AADirection.Up: x = 0; y = 1; break;
                default: x = 0; y = 0; break;
            }
        }

        #region Arithmetic float
        [IN(LINE)] public static float2 operator +(uint2 a, float b) { return new float2(a.x + b, a.y + b); }
        [IN(LINE)] public static float2 operator +(float a, uint2 b) { return new float2(a + b.x, a + b.y); }
        [IN(LINE)] public static float2 operator -(uint2 a, float b) { return new float2(a.x - b, a.y - b); }
        [IN(LINE)] public static float2 operator -(float a, uint2 b) { return new float2(a - b.x, a - b.y); }
        [IN(LINE)] public static float2 operator *(uint2 a, float b) { return new float2(a.x * b, a.y * b); }
        [IN(LINE)] public static float2 operator *(float a, uint2 b) { return new float2(a * b.x, a * b.y); }
        [IN(LINE)] public static float2 operator /(uint2 a, float b) { return new float2(a.x / b, a.y / b); }
        [IN(LINE)] public static float2 operator /(float a, uint2 b) { return new float2(a / b.x, a / b.y); }
        [IN(LINE)] public static float2 operator %(uint2 a, float b) { return new float2(a.x % b, a.y % b); }
        [IN(LINE)] public static float2 operator %(float a, uint2 b) { return new float2(a % b.x, a % b.y); }
        #endregion

        #region Arithmetic double
        [IN(LINE)] public static double2 operator +(uint2 a, double b) { return new double2(a.x + b, a.y + b); }
        [IN(LINE)] public static double2 operator +(double a, uint2 b) { return new double2(a + b.x, a + b.y); }
        [IN(LINE)] public static double2 operator -(uint2 a, double b) { return new double2(a.x - b, a.y - b); }
        [IN(LINE)] public static double2 operator -(double a, uint2 b) { return new double2(a - b.x, a - b.y); }
        [IN(LINE)] public static double2 operator *(uint2 a, double b) { return new double2(a.x * b, a.y * b); }
        [IN(LINE)] public static double2 operator *(double a, uint2 b) { return new double2(a * b.x, a * b.y); }
        [IN(LINE)] public static double2 operator /(uint2 a, double b) { return new double2(a.x / b, a.y / b); }
        [IN(LINE)] public static double2 operator /(double a, uint2 b) { return new double2(a / b.x, a / b.y); }
        [IN(LINE)] public static double2 operator %(uint2 a, double b) { return new double2(a.x % b, a.y % b); }
        [IN(LINE)] public static double2 operator %(double a, uint2 b) { return new double2(a % b.x, a % b.y); }
        #endregion
    }

    public static partial class DM
    {
        [IN(LINE)] public static uint2 UInt2((uint, uint) v) => new uint2(v);
        [IN(LINE)] public static uint2 UInt2<T>(T v) where T : IVector2<uint> => new uint2(v.x, v.y);
        [IN(LINE)] public static uint2 UInt2(bool v) => new uint2(v);
        [IN(LINE)] public static uint2 UInt2(bool2 v) => new uint2(v);
        [IN(LINE)] public static uint2 UInt2(int v) => new uint2(v);
        [IN(LINE)] public static uint2 UInt2(int2 v) => new uint2(v);
        [IN(LINE)] public static uint2 UInt2(uint v) => new uint2(v);
        [IN(LINE)] public static uint2 UInt2(uint2 v) => new uint2(v);
        [IN(LINE)] public static uint2 UInt2(float v) => new uint2(v);
        [IN(LINE)] public static uint2 UInt2(float2 v) => new uint2(v);
        [IN(LINE)] public static uint2 UInt2(double v) => new uint2(v);
        [IN(LINE)] public static uint2 UInt2(double2 v) => new uint2(v);
    }
}
