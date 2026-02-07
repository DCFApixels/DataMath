#pragma warning disable CS8981
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct uint4
    {
        #region Convert operators
        [IN(LINE)] public static implicit operator uint4(Axis v) => new uint4(v);
        [IN(LINE)] public static implicit operator uint4((uint, uint, uint, uint) v) => new uint4(v);

        [IN(LINE)] public static explicit operator uint4(bool v) => new uint4(v);
        [IN(LINE)] public static explicit operator uint4(bool4 v) => new uint4(v);
        [IN(LINE)] public static explicit operator uint4(int v) => new uint4(v);
        [IN(LINE)] public static explicit operator uint4(int4 v) => new uint4(v);
        [IN(LINE)] public static implicit operator uint4(uint v) => new uint4(v);
        //[IN(LINE)] public static implicit operator uint4(uint4 v) => new uint4(v);
        [IN(LINE)] public static explicit operator uint4(float v) => new uint4(v);
        [IN(LINE)] public static explicit operator uint4(float4 v) => new uint4(v);
        [IN(LINE)] public static explicit operator uint4(double v) => new uint4(v);
        [IN(LINE)] public static explicit operator uint4(double4 v) => new uint4(v);
        #endregion

        #region Bool constructors
        [IN(LINE)]
        public uint4(bool x, bool y, bool z, bool w)
        {
            this.x = x ? 1u : 0u; this.y = y ? 1u : 0u;
            this.z = z ? 1u : 0u; this.w = w ? 1u : 0u;
        }
        [IN(LINE)]
        public uint4(bool v)
        {
            x = v ? 1u : 0u; y = v ? 1u : 0u;
            z = v ? 1u : 0u; w = v ? 1u : 0u;
        }
        [IN(LINE)]
        public uint4(bool4 v)
        {
            x = v.x ? 1u : 0u; y = v.y ? 1u : 0u;
            z = v.z ? 1u : 0u; w = v.w ? 1u : 0u;
        }
        #endregion

        public uint4(Axis v)
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
        public uint4(AADirection v)
        {
            switch (v)
            {
                case AADirection.Left: x = unchecked((uint)-1u); y = 0; z = 0; w = 0; break;
                case AADirection.Right: x = 1; y = 0; z = 0; w = 0; break;
                case AADirection.Down: x = 0; y = unchecked((uint)-1u); z = 0; w = 0; break;
                case AADirection.Up: x = 0; y = 1; z = 0; w = 0; break;
                case AADirection.Back: x = 0; y = 0; z = unchecked((uint)-1u); w = 0; break;
                case AADirection.Forward: x = 0; y = 0; z = 1; w = 0; break;
                case AADirection.Before: x = 0; y = 0; z = 0; w = unchecked((uint)-1u); break;
                case AADirection.After: x = 0; y = 0; z = 0; w = 1; break;
                default: x = 0; y = 0; z = 0; w = 0; break;
            }
        }

        #region Arithmetic float
        [IN(LINE)] public static float4 operator +(uint4 a, float b) { return new float4(a.x + b, a.y + b, a.z + b, a.w + b); }
        [IN(LINE)] public static float4 operator +(float a, uint4 b) { return new float4(a + b.x, a + b.y, a + b.z, a + b.w); }
        [IN(LINE)] public static float4 operator -(uint4 a, float b) { return new float4(a.x - b, a.y - b, a.z - b, a.w - b); }
        [IN(LINE)] public static float4 operator -(float a, uint4 b) { return new float4(a - b.x, a - b.y, a - b.z, a - b.w); }
        [IN(LINE)] public static float4 operator *(uint4 a, float b) { return new float4(a.x * b, a.y * b, a.z * b, a.w * b); }
        [IN(LINE)] public static float4 operator *(float a, uint4 b) { return new float4(a * b.x, a * b.y, a * b.z, a * b.w); }
        [IN(LINE)] public static float4 operator /(uint4 a, float b) { return new float4(a.x / b, a.y / b, a.z / b, a.w / b); }
        [IN(LINE)] public static float4 operator /(float a, uint4 b) { return new float4(a / b.x, a / b.y, a / b.z, a / b.w); }
        [IN(LINE)] public static float4 operator %(uint4 a, float b) { return new float4(a.x % b, a.y % b, a.z % b, a.w % b); }
        [IN(LINE)] public static float4 operator %(float a, uint4 b) { return new float4(a % b.x, a % b.y, a % b.z, a % b.w); }
        #endregion

        #region Arithmetic double
        [IN(LINE)] public static double4 operator +(uint4 a, double b) { return new double4(a.x + b, a.y + b, a.z + b, a.w + b); }
        [IN(LINE)] public static double4 operator +(double a, uint4 b) { return new double4(a + b.x, a + b.y, a + b.z, a + b.w); }
        [IN(LINE)] public static double4 operator -(uint4 a, double b) { return new double4(a.x - b, a.y - b, a.z - b, a.w - b); }
        [IN(LINE)] public static double4 operator -(double a, uint4 b) { return new double4(a - b.x, a - b.y, a - b.z, a - b.w); }
        [IN(LINE)] public static double4 operator *(uint4 a, double b) { return new double4(a.x * b, a.y * b, a.z * b, a.w * b); }
        [IN(LINE)] public static double4 operator *(double a, uint4 b) { return new double4(a * b.x, a * b.y, a * b.z, a * b.w); }
        [IN(LINE)] public static double4 operator /(uint4 a, double b) { return new double4(a.x / b, a.y / b, a.z / b, a.w / b); }
        [IN(LINE)] public static double4 operator /(double a, uint4 b) { return new double4(a / b.x, a / b.y, a / b.z, a / b.w); }
        [IN(LINE)] public static double4 operator %(uint4 a, double b) { return new double4(a.x % b, a.y % b, a.z % b, a.w % b); }
        [IN(LINE)] public static double4 operator %(double a, uint4 b) { return new double4(a % b.x, a % b.y, a % b.z, a % b.w); }
        #endregion
    }

    public static partial class DM
    {
        [IN(LINE)] public static uint4 UInt4((uint, uint, uint, uint) v) => new uint4(v);
        [IN(LINE)] public static uint4 UInt4<T>(T v) where T : IVector4<uint> => new uint4(v.x, v.y, v.z, v.w);
        [IN(LINE)] public static uint4 UInt4(bool v) => new uint4(v);
        [IN(LINE)] public static uint4 UInt4(bool4 v) => new uint4(v);
        [IN(LINE)] public static uint4 UInt4(int v) => new uint4(v);
        [IN(LINE)] public static uint4 UInt4(int4 v) => new uint4(v);
        [IN(LINE)] public static uint4 UInt4(uint v) => new uint4(v);
        [IN(LINE)] public static uint4 UInt4(uint4 v) => new uint4(v);
        [IN(LINE)] public static uint4 UInt4(float v) => new uint4(v);
        [IN(LINE)] public static uint4 UInt4(float4 v) => new uint4(v);
        [IN(LINE)] public static uint4 UInt4(double v) => new uint4(v);
        [IN(LINE)] public static uint4 UInt4(double4 v) => new uint4(v);
    }
}
