#pragma warning disable CS8981
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct float3
    {
        #region Convert operators
        [IN(LINE)] public static implicit operator float3(Axis v) => new float3(v);
        [IN(LINE)] public static implicit operator float3((float, float, float) v) => new float3(v);

        [IN(LINE)] public static explicit operator float3(bool v) => new float3(v);
        [IN(LINE)] public static explicit operator float3(bool3 v) => new float3(v);
        [IN(LINE)] public static implicit operator float3(int v) => new float3(v);
        [IN(LINE)] public static implicit operator float3(int3 v) => new float3(v);
        [IN(LINE)] public static implicit operator float3(uint v) => new float3(v);
        [IN(LINE)] public static implicit operator float3(uint3 v) => new float3(v);
        [IN(LINE)] public static implicit operator float3(float v) => new float3(v);
        //[IN(LINE)] public static explicit operator float3(float3 v) => new float3(v);
        [IN(LINE)] public static explicit operator float3(double v) => new float3(v);
        [IN(LINE)] public static explicit operator float3(double3 v) => new float3(v);
        #endregion

        #region Bool constructors
        [IN(LINE)]
        public float3(bool x, bool y, bool z)
        {
            this.x = x ? 1f : 0f; this.y = y ? 1f : 0f;
            this.z = z ? 1f : 0f;
        }
        [IN(LINE)]
        public float3(bool v)
        {
            x = v ? 1f : 0f; y = v ? 1f : 0f;
            z = v ? 1f : 0f;
        }
        [IN(LINE)]
        public float3(bool3 v)
        {
            x = v.x ? 1f : 0f; y = v.y ? 1f : 0f;
            z = v.z ? 1f : 0f;
        }
        #endregion

        public float3(Axis v)
        {
            switch (v)
            {
                case Axis.X: x = 1; y = 0; z = 0; break;
                case Axis.Y: x = 0; y = 1; z = 0; break;
                case Axis.Z: x = 0; y = 0; z = 1; break;
                default: x = 0; y = 0; z = 0; break;
            }
        }
        public float3(AADirection v)
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

        //#region Arithmetic int
        //[IN(LINE)] public static float3 operator +(float3 a, int b) { return new float3(a.x + b, a.y + b, a.z + b); }
        //[IN(LINE)] public static float3 operator +(int a, float3 b) { return new float3(a + b.x, a + b.y, a + b.z); }
        //[IN(LINE)] public static float3 operator -(float3 a, int b) { return new float3(a.x - b, a.y - b, a.z - b); }
        //[IN(LINE)] public static float3 operator -(int a, float3 b) { return new float3(a - b.x, a - b.y, a - b.z); }
        //[IN(LINE)] public static float3 operator *(float3 a, int b) { return new float3(a.x * b, a.y * b, a.z * b); }
        //[IN(LINE)] public static float3 operator *(int a, float3 b) { return new float3(a * b.x, a * b.y, a * b.z); }
        //[IN(LINE)] public static float3 operator /(float3 a, int b) { return new float3(a.x / b, a.y / b, a.z / b); }
        //[IN(LINE)] public static float3 operator /(int a, float3 b) { return new float3(a / b.x, a / b.y, a / b.z); }
        //[IN(LINE)] public static float3 operator %(float3 a, int b) { return new float3(a.x % b, a.y % b, a.z % b); }
        //[IN(LINE)] public static float3 operator %(int a, float3 b) { return new float3(a % b.x, a % b.y, a % b.z); }
        //#endregion
        //
        //#region Boolean int
        //[IN(LINE)] public static bool3 operator <(float3 a, int b) { return new bool3(a.x < b, a.y < b, a.z < b); }
        //[IN(LINE)] public static bool3 operator <(int a, float3 b) { return new bool3(a < b.x, a < b.y, a < b.z); }
        //[IN(LINE)] public static bool3 operator <=(float3 a, int b) { return new bool3(a.x <= b, a.y <= b, a.z <= b); }
        //[IN(LINE)] public static bool3 operator <=(int a, float3 b) { return new bool3(a <= b.x, a <= b.y, a <= b.z); }
        //[IN(LINE)] public static bool3 operator >(float3 a, int b) { return new bool3(a.x > b, a.y > b, a.z > b); }
        //[IN(LINE)] public static bool3 operator >(int a, float3 b) { return new bool3(a > b.x, a > b.y, a > b.z); }
        //[IN(LINE)] public static bool3 operator >=(float3 a, int b) { return new bool3(a.x >= b, a.y >= b, a.z >= b); }
        //[IN(LINE)] public static bool3 operator >=(int a, float3 b) { return new bool3(a >= b.x, a >= b.y, a >= b.z); }
        //[IN(LINE)] public static bool3 operator ==(float3 a, int b) { return new bool3(a.x == b, a.y == b, a.z == b); }
        //[IN(LINE)] public static bool3 operator ==(int a, float3 b) { return new bool3(a == b.x, a == b.y, a == b.z); }
        //[IN(LINE)] public static bool3 operator !=(float3 a, int b) { return new bool3(a.x != b, a.y != b, a.z != b); }
        //[IN(LINE)] public static bool3 operator !=(int a, float3 b) { return new bool3(a != b.x, a != b.y, a != b.z); }
        //#endregion
        //
        //#region Arithmetic long
        //[IN(LINE)] public static float3 operator +(float3 a, long b) { return new float3(a.x + b, a.y + b, a.z + b); }
        //[IN(LINE)] public static float3 operator +(long a, float3 b) { return new float3(a + b.x, a + b.y, a + b.z); }
        //[IN(LINE)] public static float3 operator -(float3 a, long b) { return new float3(a.x - b, a.y - b, a.z - b); }
        //[IN(LINE)] public static float3 operator -(long a, float3 b) { return new float3(a - b.x, a - b.y, a - b.z); }
        //[IN(LINE)] public static float3 operator *(float3 a, long b) { return new float3(a.x * b, a.y * b, a.z * b); }
        //[IN(LINE)] public static float3 operator *(long a, float3 b) { return new float3(a * b.x, a * b.y, a * b.z); }
        //[IN(LINE)] public static float3 operator /(float3 a, long b) { return new float3(a.x / b, a.y / b, a.z / b); }
        //[IN(LINE)] public static float3 operator /(long a, float3 b) { return new float3(a / b.x, a / b.y, a / b.z); }
        //[IN(LINE)] public static float3 operator %(float3 a, long b) { return new float3(a.x % b, a.y % b, a.z % b); }
        //[IN(LINE)] public static float3 operator %(long a, float3 b) { return new float3(a % b.x, a % b.y, a % b.z); }
        //#endregion
        //
        //#region Boolean long
        //[IN(LINE)] public static bool3 operator <(float3 a, long b) { return new bool3(a.x < b, a.y < b, a.z < b); }
        //[IN(LINE)] public static bool3 operator <(long a, float3 b) { return new bool3(a < b.x, a < b.y, a < b.z); }
        //[IN(LINE)] public static bool3 operator <=(float3 a, long b) { return new bool3(a.x <= b, a.y <= b, a.z <= b); }
        //[IN(LINE)] public static bool3 operator <=(long a, float3 b) { return new bool3(a <= b.x, a <= b.y, a <= b.z); }
        //[IN(LINE)] public static bool3 operator >(float3 a, long b) { return new bool3(a.x > b, a.y > b, a.z > b); }
        //[IN(LINE)] public static bool3 operator >(long a, float3 b) { return new bool3(a > b.x, a > b.y, a > b.z); }
        //[IN(LINE)] public static bool3 operator >=(float3 a, long b) { return new bool3(a.x >= b, a.y >= b, a.z >= b); }
        //[IN(LINE)] public static bool3 operator >=(long a, float3 b) { return new bool3(a >= b.x, a >= b.y, a >= b.z); }
        //[IN(LINE)] public static bool3 operator ==(float3 a, long b) { return new bool3(a.x == b, a.y == b, a.z == b); }
        //[IN(LINE)] public static bool3 operator ==(long a, float3 b) { return new bool3(a == b.x, a == b.y, a == b.z); }
        //[IN(LINE)] public static bool3 operator !=(float3 a, long b) { return new bool3(a.x != b, a.y != b, a.z != b); }
        //[IN(LINE)] public static bool3 operator !=(long a, float3 b) { return new bool3(a != b.x, a != b.y, a != b.z); }
        //#endregion
        //
        //#region Arithmetic uint
        //[IN(LINE)] public static float3 operator +(float3 a, uint b) { return new float3(a.x + b, a.y + b, a.z + b); }
        //[IN(LINE)] public static float3 operator +(uint a, float3 b) { return new float3(a + b.x, a + b.y, a + b.z); }
        //[IN(LINE)] public static float3 operator -(float3 a, uint b) { return new float3(a.x - b, a.y - b, a.z - b); }
        //[IN(LINE)] public static float3 operator -(uint a, float3 b) { return new float3(a - b.x, a - b.y, a - b.z); }
        //[IN(LINE)] public static float3 operator *(float3 a, uint b) { return new float3(a.x * b, a.y * b, a.z * b); }
        //[IN(LINE)] public static float3 operator *(uint a, float3 b) { return new float3(a * b.x, a * b.y, a * b.z); }
        //[IN(LINE)] public static float3 operator /(float3 a, uint b) { return new float3(a.x / b, a.y / b, a.z / b); }
        //[IN(LINE)] public static float3 operator /(uint a, float3 b) { return new float3(a / b.x, a / b.y, a / b.z); }
        //[IN(LINE)] public static float3 operator %(float3 a, uint b) { return new float3(a.x % b, a.y % b, a.z % b); }
        //[IN(LINE)] public static float3 operator %(uint a, float3 b) { return new float3(a % b.x, a % b.y, a % b.z); }
        //#endregion
        //
        //#region Boolean uint
        //[IN(LINE)] public static bool3 operator <(float3 a, uint b) { return new bool3(a.x < b, a.y < b, a.z < b); }
        //[IN(LINE)] public static bool3 operator <(uint a, float3 b) { return new bool3(a < b.x, a < b.y, a < b.z); }
        //[IN(LINE)] public static bool3 operator <=(float3 a, uint b) { return new bool3(a.x <= b, a.y <= b, a.z <= b); }
        //[IN(LINE)] public static bool3 operator <=(uint a, float3 b) { return new bool3(a <= b.x, a <= b.y, a <= b.z); }
        //[IN(LINE)] public static bool3 operator >(float3 a, uint b) { return new bool3(a.x > b, a.y > b, a.z > b); }
        //[IN(LINE)] public static bool3 operator >(uint a, float3 b) { return new bool3(a > b.x, a > b.y, a > b.z); }
        //[IN(LINE)] public static bool3 operator >=(float3 a, uint b) { return new bool3(a.x >= b, a.y >= b, a.z >= b); }
        //[IN(LINE)] public static bool3 operator >=(uint a, float3 b) { return new bool3(a >= b.x, a >= b.y, a >= b.z); }
        //[IN(LINE)] public static bool3 operator ==(float3 a, uint b) { return new bool3(a.x == b, a.y == b, a.z == b); }
        //[IN(LINE)] public static bool3 operator ==(uint a, float3 b) { return new bool3(a == b.x, a == b.y, a == b.z); }
        //[IN(LINE)] public static bool3 operator !=(float3 a, uint b) { return new bool3(a.x != b, a.y != b, a.z != b); }
        //[IN(LINE)] public static bool3 operator !=(uint a, float3 b) { return new bool3(a != b.x, a != b.y, a != b.z); }
        //#endregion
        //
        //#region Arithmetic ulong
        //[IN(LINE)] public static float3 operator +(float3 a, ulong b) { return new float3(a.x + b, a.y + b, a.z + b); }
        //[IN(LINE)] public static float3 operator +(ulong a, float3 b) { return new float3(a + b.x, a + b.y, a + b.z); }
        //[IN(LINE)] public static float3 operator -(float3 a, ulong b) { return new float3(a.x - b, a.y - b, a.z - b); }
        //[IN(LINE)] public static float3 operator -(ulong a, float3 b) { return new float3(a - b.x, a - b.y, a - b.z); }
        //[IN(LINE)] public static float3 operator *(float3 a, ulong b) { return new float3(a.x * b, a.y * b, a.z * b); }
        //[IN(LINE)] public static float3 operator *(ulong a, float3 b) { return new float3(a * b.x, a * b.y, a * b.z); }
        //[IN(LINE)] public static float3 operator /(float3 a, ulong b) { return new float3(a.x / b, a.y / b, a.z / b); }
        //[IN(LINE)] public static float3 operator /(ulong a, float3 b) { return new float3(a / b.x, a / b.y, a / b.z); }
        //[IN(LINE)] public static float3 operator %(float3 a, ulong b) { return new float3(a.x % b, a.y % b, a.z % b); }
        //[IN(LINE)] public static float3 operator %(ulong a, float3 b) { return new float3(a % b.x, a % b.y, a % b.z); }
        //#endregion
        //
        //#region Boolean ulong
        //[IN(LINE)] public static bool3 operator <(float3 a, ulong b) { return new bool3(a.x < b, a.y < b, a.z < b); }
        //[IN(LINE)] public static bool3 operator <(ulong a, float3 b) { return new bool3(a < b.x, a < b.y, a < b.z); }
        //[IN(LINE)] public static bool3 operator <=(float3 a, ulong b) { return new bool3(a.x <= b, a.y <= b, a.z <= b); }
        //[IN(LINE)] public static bool3 operator <=(ulong a, float3 b) { return new bool3(a <= b.x, a <= b.y, a <= b.z); }
        //[IN(LINE)] public static bool3 operator >(float3 a, ulong b) { return new bool3(a.x > b, a.y > b, a.z > b); }
        //[IN(LINE)] public static bool3 operator >(ulong a, float3 b) { return new bool3(a > b.x, a > b.y, a > b.z); }
        //[IN(LINE)] public static bool3 operator >=(float3 a, ulong b) { return new bool3(a.x >= b, a.y >= b, a.z >= b); }
        //[IN(LINE)] public static bool3 operator >=(ulong a, float3 b) { return new bool3(a >= b.x, a >= b.y, a >= b.z); }
        //[IN(LINE)] public static bool3 operator ==(float3 a, ulong b) { return new bool3(a.x == b, a.y == b, a.z == b); }
        //[IN(LINE)] public static bool3 operator ==(ulong a, float3 b) { return new bool3(a == b.x, a == b.y, a == b.z); }
        //[IN(LINE)] public static bool3 operator !=(float3 a, ulong b) { return new bool3(a.x != b, a.y != b, a.z != b); }
        //[IN(LINE)] public static bool3 operator !=(ulong a, float3 b) { return new bool3(a != b.x, a != b.y, a != b.z); }
        //#endregion
    }

    public static partial class DM
    {
        [IN(LINE)] public static float3 Float3((float, float, float) v) => new float3(v);
        [IN(LINE)] public static float3 Float3<T>(T v) where T : IVector3<float> => new float3(v.x, v.y, v.z);
        [IN(LINE)] public static float3 Float3(bool v) => new float3(v);
        [IN(LINE)] public static float3 Float3(bool3 v) => new float3(v);
        [IN(LINE)] public static float3 Float3(int v) => new float3(v);
        [IN(LINE)] public static float3 Float3(int3 v) => new float3(v);
        [IN(LINE)] public static float3 Float3(uint v) => new float3(v);
        [IN(LINE)] public static float3 Float3(uint3 v) => new float3(v);
        [IN(LINE)] public static float3 Float3(float v) => new float3(v);
        [IN(LINE)] public static float3 Float3(float3 v) => new float3(v);
        [IN(LINE)] public static float3 Float3(double v) => new float3(v);
        [IN(LINE)] public static float3 Float3(double3 v) => new float3(v);
    }
}
