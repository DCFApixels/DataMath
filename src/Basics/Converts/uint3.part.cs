#pragma warning disable CS8981
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct uint3
    {
        #region Convert operators
        [IN(LINE)] public static implicit operator uint3(Axis v) => new uint3(v);
        [IN(LINE)] public static implicit operator uint3((uint, uint, uint) v) => new uint3(v);

        [IN(LINE)] public static explicit operator uint3(bool v) => new uint3(v);
        [IN(LINE)] public static explicit operator uint3(bool3 v) => new uint3(v);
        [IN(LINE)] public static explicit operator uint3(int v) => new uint3(v);
        [IN(LINE)] public static explicit operator uint3(int3 v) => new uint3(v);
        [IN(LINE)] public static implicit operator uint3(uint v) => new uint3(v);
        //[IN(LINE)] public static implicit operator uint3(uint3 v) => new uint3(v);
        [IN(LINE)] public static explicit operator uint3(float v) => new uint3(v);
        [IN(LINE)] public static explicit operator uint3(float3 v) => new uint3(v);
        [IN(LINE)] public static explicit operator uint3(double v) => new uint3(v);
        [IN(LINE)] public static explicit operator uint3(double3 v) => new uint3(v);
        #endregion

        #region Bool constructors
        [IN(LINE)]
        public uint3(bool x, bool y, bool z)
        {
            this.x = x ? 1u : 0u; this.y = y ? 1u : 0u;
            this.z = z ? 1u : 0u;
        }
        [IN(LINE)]
        public uint3(bool v)
        {
            x = v ? 1u : 0u; y = v ? 1u : 0u;
            z = v ? 1u : 0u;
        }
        [IN(LINE)]
        public uint3(bool3 v)
        {
            x = v.x ? 1u : 0u; y = v.y ? 1u : 0u;
            z = v.z ? 1u : 0u;
        }
        #endregion

        public uint3(Axis v)
        {
            switch (v)
            {
                case Axis.X: x = 1; y = 0; z = 0; break;
                case Axis.Y: x = 0; y = 1; z = 0; break;
                case Axis.Z: x = 0; y = 0; z = 1; break;
                default: x = 0; y = 0; z = 0; break;
            }
        }
        public uint3(AADirection v)
        {
            switch (v)
            {
                case AADirection.Left: x = unchecked((uint)-1u); y = 0; z = 0; break;
                case AADirection.Right: x = 1; y = 0; z = 0; break;
                case AADirection.Down: x = 0; y = unchecked((uint)-1u); z = 0; break;
                case AADirection.Up: x = 0; y = 1; z = 0; break;
                case AADirection.Back: x = 0; y = 0; z = unchecked((uint)-1u); break;
                case AADirection.Forward: x = 0; y = 0; z = 1; break;
                default: x = 0; y = 0; z = 0; break;
            }
        }

        #region Arithmetic float
        [IN(LINE)] public static float3 operator +(uint3 a, float b) { return new float3(a.x + b, a.y + b, a.z + b); }
        [IN(LINE)] public static float3 operator +(float a, uint3 b) { return new float3(a + b.x, a + b.y, a + b.z); }
        [IN(LINE)] public static float3 operator -(uint3 a, float b) { return new float3(a.x - b, a.y - b, a.z - b); }
        [IN(LINE)] public static float3 operator -(float a, uint3 b) { return new float3(a - b.x, a - b.y, a - b.z); }
        [IN(LINE)] public static float3 operator *(uint3 a, float b) { return new float3(a.x * b, a.y * b, a.z * b); }
        [IN(LINE)] public static float3 operator *(float a, uint3 b) { return new float3(a * b.x, a * b.y, a * b.z); }
        [IN(LINE)] public static float3 operator /(uint3 a, float b) { return new float3(a.x / b, a.y / b, a.z / b); }
        [IN(LINE)] public static float3 operator /(float a, uint3 b) { return new float3(a / b.x, a / b.y, a / b.z); }
        [IN(LINE)] public static float3 operator %(uint3 a, float b) { return new float3(a.x % b, a.y % b, a.z % b); }
        [IN(LINE)] public static float3 operator %(float a, uint3 b) { return new float3(a % b.x, a % b.y, a % b.z); }
        #endregion

        #region Arithmetic double
        [IN(LINE)] public static double3 operator +(uint3 a, double b) { return new double3(a.x + b, a.y + b, a.z + b); }
        [IN(LINE)] public static double3 operator +(double a, uint3 b) { return new double3(a + b.x, a + b.y, a + b.z); }
        [IN(LINE)] public static double3 operator -(uint3 a, double b) { return new double3(a.x - b, a.y - b, a.z - b); }
        [IN(LINE)] public static double3 operator -(double a, uint3 b) { return new double3(a - b.x, a - b.y, a - b.z); }
        [IN(LINE)] public static double3 operator *(uint3 a, double b) { return new double3(a.x * b, a.y * b, a.z * b); }
        [IN(LINE)] public static double3 operator *(double a, uint3 b) { return new double3(a * b.x, a * b.y, a * b.z); }
        [IN(LINE)] public static double3 operator /(uint3 a, double b) { return new double3(a.x / b, a.y / b, a.z / b); }
        [IN(LINE)] public static double3 operator /(double a, uint3 b) { return new double3(a / b.x, a / b.y, a / b.z); }
        [IN(LINE)] public static double3 operator %(uint3 a, double b) { return new double3(a.x % b, a.y % b, a.z % b); }
        [IN(LINE)] public static double3 operator %(double a, uint3 b) { return new double3(a % b.x, a % b.y, a % b.z); }
        #endregion
    }

    public static partial class DM
    {
        [IN(LINE)] public static uint3 UInt3((uint, uint, uint) v) => new uint3(v);
        [IN(LINE)] public static uint3 UInt3<T>(T v) where T : IVector3<uint> => new uint3(v.x, v.y, v.z);
        [IN(LINE)] public static uint3 UInt3(bool v) => new uint3(v);
        [IN(LINE)] public static uint3 UInt3(bool3 v) => new uint3(v);
        [IN(LINE)] public static uint3 UInt3(int v) => new uint3(v);
        [IN(LINE)] public static uint3 UInt3(int3 v) => new uint3(v);
        [IN(LINE)] public static uint3 UInt3(uint v) => new uint3(v);
        [IN(LINE)] public static uint3 UInt3(uint3 v) => new uint3(v);
        [IN(LINE)] public static uint3 UInt3(float v) => new uint3(v);
        [IN(LINE)] public static uint3 UInt3(float3 v) => new uint3(v);
        [IN(LINE)] public static uint3 UInt3(double v) => new uint3(v);
        [IN(LINE)] public static uint3 UInt3(double3 v) => new uint3(v);
    }
}
