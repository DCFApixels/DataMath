#pragma warning disable CS8981
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct float4
    {
        #region Convert operators
        [IN(LINE)] public static implicit operator float4(Axis v) => new float4(v);
        [IN(LINE)] public static implicit operator float4((float, float, float, float) v) => new float4(v);

        [IN(LINE)] public static explicit operator float4(bool v) => new float4(v);
        [IN(LINE)] public static explicit operator float4(bool4 v) => new float4(v);
        [IN(LINE)] public static implicit operator float4(int v) => new float4(v);
        [IN(LINE)] public static implicit operator float4(int4 v) => new float4(v);
        [IN(LINE)] public static implicit operator float4(uint v) => new float4(v);
        [IN(LINE)] public static implicit operator float4(uint4 v) => new float4(v);
        [IN(LINE)] public static implicit operator float4(float v) => new float4(v);
        //[IN(LINE)] public static explicit operator float4(float4 v) => new float4(v);
        [IN(LINE)] public static explicit operator float4(double v) => new float4(v);
        [IN(LINE)] public static explicit operator float4(double4 v) => new float4(v);
        #endregion

        #region Bool constructors
        [IN(LINE)]
        public float4(bool x, bool y, bool z, bool w)
        {
            this.x = x ? 1f : 0f; this.y = y ? 1f : 0f;
            this.z = z ? 1f : 0f; this.w = w ? 1f : 0f;
        }
        [IN(LINE)]
        public float4(bool v)
        {
            x = v ? 1f : 0f; y = v ? 1f : 0f;
            z = v ? 1f : 0f; w = v ? 1f : 0f;
        }
        [IN(LINE)]
        public float4(bool4 v)
        {
            x = v.x ? 1f : 0f; y = v.y ? 1f : 0f;
            z = v.z ? 1f : 0f; w = v.w ? 1f : 0f;
        }
        #endregion

        public float4(Axis v)
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
        public float4(AADirection v)
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

        //#region Arithmetic int
        //[IN(LINE)] public static float4 operator +(float4 a, int b) { return new float4(a.x + b, a.y + b, a.z + b, a.w + b); }
        //[IN(LINE)] public static float4 operator +(int a, float4 b) { return new float4(a + b.x, a + b.y, a + b.z, a + b.w); }
        //[IN(LINE)] public static float4 operator -(float4 a, int b) { return new float4(a.x - b, a.y - b, a.z - b, a.w - b); }
        //[IN(LINE)] public static float4 operator -(int a, float4 b) { return new float4(a - b.x, a - b.y, a - b.z, a - b.w); }
        //[IN(LINE)] public static float4 operator *(float4 a, int b) { return new float4(a.x * b, a.y * b, a.z * b, a.w * b); }
        //[IN(LINE)] public static float4 operator *(int a, float4 b) { return new float4(a * b.x, a * b.y, a * b.z, a * b.w); }
        //[IN(LINE)] public static float4 operator /(float4 a, int b) { return new float4(a.x / b, a.y / b, a.z / b, a.w / b); }
        //[IN(LINE)] public static float4 operator /(int a, float4 b) { return new float4(a / b.x, a / b.y, a / b.z, a / b.w); }
        //[IN(LINE)] public static float4 operator %(float4 a, int b) { return new float4(a.x % b, a.y % b, a.z % b, a.w % b); }
        //[IN(LINE)] public static float4 operator %(int a, float4 b) { return new float4(a % b.x, a % b.y, a % b.z, a % b.w); }
        //#endregion
        //
        //#region Boolean int
        //[IN(LINE)] public static bool4 operator <(float4 a, int b) { return new bool4(a.x < b, a.y < b, a.z < b, a.w < b); }
        //[IN(LINE)] public static bool4 operator <(int a, float4 b) { return new bool4(a < b.x, a < b.y, a < b.z, a < b.w); }
        //[IN(LINE)] public static bool4 operator <=(float4 a, int b) { return new bool4(a.x <= b, a.y <= b, a.z <= b, a.w <= b); }
        //[IN(LINE)] public static bool4 operator <=(int a, float4 b) { return new bool4(a <= b.x, a <= b.y, a <= b.z, a <= b.w); }
        //[IN(LINE)] public static bool4 operator >(float4 a, int b) { return new bool4(a.x > b, a.y > b, a.z > b, a.w > b); }
        //[IN(LINE)] public static bool4 operator >(int a, float4 b) { return new bool4(a > b.x, a > b.y, a > b.z, a > b.w); }
        //[IN(LINE)] public static bool4 operator >=(float4 a, int b) { return new bool4(a.x >= b, a.y >= b, a.z >= b, a.w >= b); }
        //[IN(LINE)] public static bool4 operator >=(int a, float4 b) { return new bool4(a >= b.x, a >= b.y, a >= b.z, a >= b.w); }
        //[IN(LINE)] public static bool4 operator ==(float4 a, int b) { return new bool4(a.x == b, a.y == b, a.z == b, a.w == b); }
        //[IN(LINE)] public static bool4 operator ==(int a, float4 b) { return new bool4(a == b.x, a == b.y, a == b.z, a == b.w); }
        //[IN(LINE)] public static bool4 operator !=(float4 a, int b) { return new bool4(a.x != b, a.y != b, a.z != b, a.w != b); }
        //[IN(LINE)] public static bool4 operator !=(int a, float4 b) { return new bool4(a != b.x, a != b.y, a != b.z, a != b.w); }
        //#endregion
        //
        //#region Arithmetic long
        //[IN(LINE)] public static float4 operator +(float4 a, long b) { return new float4(a.x + b, a.y + b, a.z + b, a.w + b); }
        //[IN(LINE)] public static float4 operator +(long a, float4 b) { return new float4(a + b.x, a + b.y, a + b.z, a + b.w); }
        //[IN(LINE)] public static float4 operator -(float4 a, long b) { return new float4(a.x - b, a.y - b, a.z - b, a.w - b); }
        //[IN(LINE)] public static float4 operator -(long a, float4 b) { return new float4(a - b.x, a - b.y, a - b.z, a - b.w); }
        //[IN(LINE)] public static float4 operator *(float4 a, long b) { return new float4(a.x * b, a.y * b, a.z * b, a.w * b); }
        //[IN(LINE)] public static float4 operator *(long a, float4 b) { return new float4(a * b.x, a * b.y, a * b.z, a * b.w); }
        //[IN(LINE)] public static float4 operator /(float4 a, long b) { return new float4(a.x / b, a.y / b, a.z / b, a.w / b); }
        //[IN(LINE)] public static float4 operator /(long a, float4 b) { return new float4(a / b.x, a / b.y, a / b.z, a / b.w); }
        //[IN(LINE)] public static float4 operator %(float4 a, long b) { return new float4(a.x % b, a.y % b, a.z % b, a.w % b); }
        //[IN(LINE)] public static float4 operator %(long a, float4 b) { return new float4(a % b.x, a % b.y, a % b.z, a % b.w); }
        //#endregion
        //
        //#region Boolean long
        //[IN(LINE)] public static bool4 operator <(float4 a, long b) { return new bool4(a.x < b, a.y < b, a.z < b, a.w < b); }
        //[IN(LINE)] public static bool4 operator <(long a, float4 b) { return new bool4(a < b.x, a < b.y, a < b.z, a < b.w); }
        //[IN(LINE)] public static bool4 operator <=(float4 a, long b) { return new bool4(a.x <= b, a.y <= b, a.z <= b, a.w <= b); }
        //[IN(LINE)] public static bool4 operator <=(long a, float4 b) { return new bool4(a <= b.x, a <= b.y, a <= b.z, a <= b.w); }
        //[IN(LINE)] public static bool4 operator >(float4 a, long b) { return new bool4(a.x > b, a.y > b, a.z > b, a.w > b); }
        //[IN(LINE)] public static bool4 operator >(long a, float4 b) { return new bool4(a > b.x, a > b.y, a > b.z, a > b.w); }
        //[IN(LINE)] public static bool4 operator >=(float4 a, long b) { return new bool4(a.x >= b, a.y >= b, a.z >= b, a.w >= b); }
        //[IN(LINE)] public static bool4 operator >=(long a, float4 b) { return new bool4(a >= b.x, a >= b.y, a >= b.z, a >= b.w); }
        //[IN(LINE)] public static bool4 operator ==(float4 a, long b) { return new bool4(a.x == b, a.y == b, a.z == b, a.w == b); }
        //[IN(LINE)] public static bool4 operator ==(long a, float4 b) { return new bool4(a == b.x, a == b.y, a == b.z, a == b.w); }
        //[IN(LINE)] public static bool4 operator !=(float4 a, long b) { return new bool4(a.x != b, a.y != b, a.z != b, a.w != b); }
        //[IN(LINE)] public static bool4 operator !=(long a, float4 b) { return new bool4(a != b.x, a != b.y, a != b.z, a != b.w); }
        //#endregion
        //
        //#region Arithmetic uint
        //[IN(LINE)] public static float4 operator +(float4 a, uint b) { return new float4(a.x + b, a.y + b, a.z + b, a.w + b); }
        //[IN(LINE)] public static float4 operator +(uint a, float4 b) { return new float4(a + b.x, a + b.y, a + b.z, a + b.w); }
        //[IN(LINE)] public static float4 operator -(float4 a, uint b) { return new float4(a.x - b, a.y - b, a.z - b, a.w - b); }
        //[IN(LINE)] public static float4 operator -(uint a, float4 b) { return new float4(a - b.x, a - b.y, a - b.z, a - b.w); }
        //[IN(LINE)] public static float4 operator *(float4 a, uint b) { return new float4(a.x * b, a.y * b, a.z * b, a.w * b); }
        //[IN(LINE)] public static float4 operator *(uint a, float4 b) { return new float4(a * b.x, a * b.y, a * b.z, a * b.w); }
        //[IN(LINE)] public static float4 operator /(float4 a, uint b) { return new float4(a.x / b, a.y / b, a.z / b, a.w / b); }
        //[IN(LINE)] public static float4 operator /(uint a, float4 b) { return new float4(a / b.x, a / b.y, a / b.z, a / b.w); }
        //[IN(LINE)] public static float4 operator %(float4 a, uint b) { return new float4(a.x % b, a.y % b, a.z % b, a.w % b); }
        //[IN(LINE)] public static float4 operator %(uint a, float4 b) { return new float4(a % b.x, a % b.y, a % b.z, a % b.w); }
        //#endregion
        //
        //#region Boolean uint
        //[IN(LINE)] public static bool4 operator <(float4 a, uint b) { return new bool4(a.x < b, a.y < b, a.z < b, a.w < b); }
        //[IN(LINE)] public static bool4 operator <(uint a, float4 b) { return new bool4(a < b.x, a < b.y, a < b.z, a < b.w); }
        //[IN(LINE)] public static bool4 operator <=(float4 a, uint b) { return new bool4(a.x <= b, a.y <= b, a.z <= b, a.w <= b); }
        //[IN(LINE)] public static bool4 operator <=(uint a, float4 b) { return new bool4(a <= b.x, a <= b.y, a <= b.z, a <= b.w); }
        //[IN(LINE)] public static bool4 operator >(float4 a, uint b) { return new bool4(a.x > b, a.y > b, a.z > b, a.w > b); }
        //[IN(LINE)] public static bool4 operator >(uint a, float4 b) { return new bool4(a > b.x, a > b.y, a > b.z, a > b.w); }
        //[IN(LINE)] public static bool4 operator >=(float4 a, uint b) { return new bool4(a.x >= b, a.y >= b, a.z >= b, a.w >= b); }
        //[IN(LINE)] public static bool4 operator >=(uint a, float4 b) { return new bool4(a >= b.x, a >= b.y, a >= b.z, a >= b.w); }
        //[IN(LINE)] public static bool4 operator ==(float4 a, uint b) { return new bool4(a.x == b, a.y == b, a.z == b, a.w == b); }
        //[IN(LINE)] public static bool4 operator ==(uint a, float4 b) { return new bool4(a == b.x, a == b.y, a == b.z, a == b.w); }
        //[IN(LINE)] public static bool4 operator !=(float4 a, uint b) { return new bool4(a.x != b, a.y != b, a.z != b, a.w != b); }
        //[IN(LINE)] public static bool4 operator !=(uint a, float4 b) { return new bool4(a != b.x, a != b.y, a != b.z, a != b.w); }
        //#endregion
        //
        //#region Arithmetic ulong
        //[IN(LINE)] public static float4 operator +(float4 a, ulong b) { return new float4(a.x + b, a.y + b, a.z + b, a.w + b); }
        //[IN(LINE)] public static float4 operator +(ulong a, float4 b) { return new float4(a + b.x, a + b.y, a + b.z, a + b.w); }
        //[IN(LINE)] public static float4 operator -(float4 a, ulong b) { return new float4(a.x - b, a.y - b, a.z - b, a.w - b); }
        //[IN(LINE)] public static float4 operator -(ulong a, float4 b) { return new float4(a - b.x, a - b.y, a - b.z, a - b.w); }
        //[IN(LINE)] public static float4 operator *(float4 a, ulong b) { return new float4(a.x * b, a.y * b, a.z * b, a.w * b); }
        //[IN(LINE)] public static float4 operator *(ulong a, float4 b) { return new float4(a * b.x, a * b.y, a * b.z, a * b.w); }
        //[IN(LINE)] public static float4 operator /(float4 a, ulong b) { return new float4(a.x / b, a.y / b, a.z / b, a.w / b); }
        //[IN(LINE)] public static float4 operator /(ulong a, float4 b) { return new float4(a / b.x, a / b.y, a / b.z, a / b.w); }
        //[IN(LINE)] public static float4 operator %(float4 a, ulong b) { return new float4(a.x % b, a.y % b, a.z % b, a.w % b); }
        //[IN(LINE)] public static float4 operator %(ulong a, float4 b) { return new float4(a % b.x, a % b.y, a % b.z, a % b.w); }
        //#endregion
        //
        //#region Boolean ulong
        //[IN(LINE)] public static bool4 operator <(float4 a, ulong b) { return new bool4(a.x < b, a.y < b, a.z < b, a.w < b); }
        //[IN(LINE)] public static bool4 operator <(ulong a, float4 b) { return new bool4(a < b.x, a < b.y, a < b.z, a < b.w); }
        //[IN(LINE)] public static bool4 operator <=(float4 a, ulong b) { return new bool4(a.x <= b, a.y <= b, a.z <= b, a.w <= b); }
        //[IN(LINE)] public static bool4 operator <=(ulong a, float4 b) { return new bool4(a <= b.x, a <= b.y, a <= b.z, a <= b.w); }
        //[IN(LINE)] public static bool4 operator >(float4 a, ulong b) { return new bool4(a.x > b, a.y > b, a.z > b, a.w > b); }
        //[IN(LINE)] public static bool4 operator >(ulong a, float4 b) { return new bool4(a > b.x, a > b.y, a > b.z, a > b.w); }
        //[IN(LINE)] public static bool4 operator >=(float4 a, ulong b) { return new bool4(a.x >= b, a.y >= b, a.z >= b, a.w >= b); }
        //[IN(LINE)] public static bool4 operator >=(ulong a, float4 b) { return new bool4(a >= b.x, a >= b.y, a >= b.z, a >= b.w); }
        //[IN(LINE)] public static bool4 operator ==(float4 a, ulong b) { return new bool4(a.x == b, a.y == b, a.z == b, a.w == b); }
        //[IN(LINE)] public static bool4 operator ==(ulong a, float4 b) { return new bool4(a == b.x, a == b.y, a == b.z, a == b.w); }
        //[IN(LINE)] public static bool4 operator !=(float4 a, ulong b) { return new bool4(a.x != b, a.y != b, a.z != b, a.w != b); }
        //[IN(LINE)] public static bool4 operator !=(ulong a, float4 b) { return new bool4(a != b.x, a != b.y, a != b.z, a != b.w); }
        //#endregion
    }

    public static partial class DM
    {
        [IN(LINE)] public static float4 Float4((float, float, float, float) v) => new float4(v);
        [IN(LINE)] public static float4 Float4<T>(T v) where T : IVector4<float> => new float4(v.x, v.y, v.z, v.w);
        [IN(LINE)] public static float4 Float4(bool v) => new float4(v);
        [IN(LINE)] public static float4 Float4(bool4 v) => new float4(v);
        [IN(LINE)] public static float4 Float4(int v) => new float4(v);
        [IN(LINE)] public static float4 Float4(int4 v) => new float4(v);
        [IN(LINE)] public static float4 Float4(uint v) => new float4(v);
        [IN(LINE)] public static float4 Float4(uint4 v) => new float4(v);
        [IN(LINE)] public static float4 Float4(float v) => new float4(v);
        [IN(LINE)] public static float4 Float4(float4 v) => new float4(v);
        [IN(LINE)] public static float4 Float4(double v) => new float4(v);
        [IN(LINE)] public static float4 Float4(double4 v) => new float4(v);
    }
}
