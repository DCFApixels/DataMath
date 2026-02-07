#pragma warning disable CS8981
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct float2
    {
        #region Convert operators
        [IN(LINE)] public static implicit operator float2(Axis v) => new float2(v);
        [IN(LINE)] public static implicit operator float2((float, float) v) => new float2(v);

        [IN(LINE)] public static explicit operator float2(bool v) => new float2(v);
        [IN(LINE)] public static explicit operator float2(bool2 v) => new float2(v);
        [IN(LINE)] public static implicit operator float2(int v) => new float2(v);
        [IN(LINE)] public static implicit operator float2(int2 v) => new float2(v);
        [IN(LINE)] public static implicit operator float2(uint v) => new float2(v);
        [IN(LINE)] public static implicit operator float2(uint2 v) => new float2(v);
        [IN(LINE)] public static implicit operator float2(float v) => new float2(v);
        //[IN(LINE)] public static explicit operator float2(float2 v) => new float2(v);
        [IN(LINE)] public static explicit operator float2(double v) => new float2(v);
        [IN(LINE)] public static explicit operator float2(double2 v) => new float2(v);
        #endregion

        #region Bool constructors
        [IN(LINE)]
        public float2(bool x, bool y)
        {
            this.x = x ? 1f : 0f; this.y = y ? 1f : 0f;
        }
        [IN(LINE)]
        public float2(bool v)
        {
            x = v ? 1f : 0f; y = v ? 1f : 0f;
        }
        [IN(LINE)]
        public float2(bool2 v)
        {
            x = v.x ? 1f : 0f; y = v.y ? 1f : 0f;
        }
        #endregion

        [IN(LINE)] public float2((float x, float y) v) { x = v.x; y = v.y; }
        [IN(LINE)]
        public float2(Axis v)
        {
            switch (v)
            {
                case Axis.X: x = 1; y = 0; break;
                case Axis.Y: x = 0; y = 1; break;
                default: x = 0; y = 0; break;
            }
        }
        public float2(AADirection v)
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

        //#region Arithmetic int
        //[IN(LINE)] public static float2 operator +(float2 a, int b) { return new float2(a.x + b, a.y + b); }
        //[IN(LINE)] public static float2 operator +(int a, float2 b) { return new float2(a + b.x, a + b.y); }
        //[IN(LINE)] public static float2 operator -(float2 a, int b) { return new float2(a.x - b, a.y - b); }
        //[IN(LINE)] public static float2 operator -(int a, float2 b) { return new float2(a - b.x, a - b.y); }
        //[IN(LINE)] public static float2 operator *(float2 a, int b) { return new float2(a.x * b, a.y * b); }
        //[IN(LINE)] public static float2 operator *(int a, float2 b) { return new float2(a * b.x, a * b.y); }
        //[IN(LINE)] public static float2 operator /(float2 a, int b) { return new float2(a.x / b, a.y / b); }
        //[IN(LINE)] public static float2 operator /(int a, float2 b) { return new float2(a / b.x, a / b.y); }
        //[IN(LINE)] public static float2 operator %(float2 a, int b) { return new float2(a.x % b, a.y % b); }
        //[IN(LINE)] public static float2 operator %(int a, float2 b) { return new float2(a % b.x, a % b.y); }
        //#endregion
        //
        //#region Boolean int
        //[IN(LINE)] public static bool2 operator <(float2 a, int b) { return new bool2(a.x < b, a.y < b); }
        //[IN(LINE)] public static bool2 operator <(int a, float2 b) { return new bool2(a < b.x, a < b.y); }
        //[IN(LINE)] public static bool2 operator <=(float2 a, int b) { return new bool2(a.x <= b, a.y <= b); }
        //[IN(LINE)] public static bool2 operator <=(int a, float2 b) { return new bool2(a <= b.x, a <= b.y); }
        //[IN(LINE)] public static bool2 operator >(float2 a, int b) { return new bool2(a.x > b, a.y > b); }
        //[IN(LINE)] public static bool2 operator >(int a, float2 b) { return new bool2(a > b.x, a > b.y); }
        //[IN(LINE)] public static bool2 operator >=(float2 a, int b) { return new bool2(a.x >= b, a.y >= b); }
        //[IN(LINE)] public static bool2 operator >=(int a, float2 b) { return new bool2(a >= b.x, a >= b.y); }
        //[IN(LINE)] public static bool2 operator ==(float2 a, int b) { return new bool2(a.x == b, a.y == b); }
        //[IN(LINE)] public static bool2 operator ==(int a, float2 b) { return new bool2(a == b.x, a == b.y); }
        //[IN(LINE)] public static bool2 operator !=(float2 a, int b) { return new bool2(a.x != b, a.y != b); }
        //[IN(LINE)] public static bool2 operator !=(int a, float2 b) { return new bool2(a != b.x, a != b.y); }
        //#endregion
        //
        //#region Arithmetic long
        //[IN(LINE)] public static float2 operator +(float2 a, long b) { return new float2(a.x + b, a.y + b); }
        //[IN(LINE)] public static float2 operator +(long a, float2 b) { return new float2(a + b.x, a + b.y); }
        //[IN(LINE)] public static float2 operator -(float2 a, long b) { return new float2(a.x - b, a.y - b); }
        //[IN(LINE)] public static float2 operator -(long a, float2 b) { return new float2(a - b.x, a - b.y); }
        //[IN(LINE)] public static float2 operator *(float2 a, long b) { return new float2(a.x * b, a.y * b); }
        //[IN(LINE)] public static float2 operator *(long a, float2 b) { return new float2(a * b.x, a * b.y); }
        //[IN(LINE)] public static float2 operator /(float2 a, long b) { return new float2(a.x / b, a.y / b); }
        //[IN(LINE)] public static float2 operator /(long a, float2 b) { return new float2(a / b.x, a / b.y); }
        //[IN(LINE)] public static float2 operator %(float2 a, long b) { return new float2(a.x % b, a.y % b); }
        //[IN(LINE)] public static float2 operator %(long a, float2 b) { return new float2(a % b.x, a % b.y); }
        //#endregion
        //
        //#region Boolean long
        //[IN(LINE)] public static bool2 operator <(float2 a, long b) { return new bool2(a.x < b, a.y < b); }
        //[IN(LINE)] public static bool2 operator <(long a, float2 b) { return new bool2(a < b.x, a < b.y); }
        //[IN(LINE)] public static bool2 operator <=(float2 a, long b) { return new bool2(a.x <= b, a.y <= b); }
        //[IN(LINE)] public static bool2 operator <=(long a, float2 b) { return new bool2(a <= b.x, a <= b.y); }
        //[IN(LINE)] public static bool2 operator >(float2 a, long b) { return new bool2(a.x > b, a.y > b); }
        //[IN(LINE)] public static bool2 operator >(long a, float2 b) { return new bool2(a > b.x, a > b.y); }
        //[IN(LINE)] public static bool2 operator >=(float2 a, long b) { return new bool2(a.x >= b, a.y >= b); }
        //[IN(LINE)] public static bool2 operator >=(long a, float2 b) { return new bool2(a >= b.x, a >= b.y); }
        //[IN(LINE)] public static bool2 operator ==(float2 a, long b) { return new bool2(a.x == b, a.y == b); }
        //[IN(LINE)] public static bool2 operator ==(long a, float2 b) { return new bool2(a == b.x, a == b.y); }
        //[IN(LINE)] public static bool2 operator !=(float2 a, long b) { return new bool2(a.x != b, a.y != b); }
        //[IN(LINE)] public static bool2 operator !=(long a, float2 b) { return new bool2(a != b.x, a != b.y); }
        //#endregion
        //
        //#region Arithmetic uint
        //[IN(LINE)] public static float2 operator +(float2 a, uint b) { return new float2(a.x + b, a.y + b); }
        //[IN(LINE)] public static float2 operator +(uint a, float2 b) { return new float2(a + b.x, a + b.y); }
        //[IN(LINE)] public static float2 operator -(float2 a, uint b) { return new float2(a.x - b, a.y - b); }
        //[IN(LINE)] public static float2 operator -(uint a, float2 b) { return new float2(a - b.x, a - b.y); }
        //[IN(LINE)] public static float2 operator *(float2 a, uint b) { return new float2(a.x * b, a.y * b); }
        //[IN(LINE)] public static float2 operator *(uint a, float2 b) { return new float2(a * b.x, a * b.y); }
        //[IN(LINE)] public static float2 operator /(float2 a, uint b) { return new float2(a.x / b, a.y / b); }
        //[IN(LINE)] public static float2 operator /(uint a, float2 b) { return new float2(a / b.x, a / b.y); }
        //[IN(LINE)] public static float2 operator %(float2 a, uint b) { return new float2(a.x % b, a.y % b); }
        //[IN(LINE)] public static float2 operator %(uint a, float2 b) { return new float2(a % b.x, a % b.y); }
        //#endregion
        //
        //#region Boolean uint
        //[IN(LINE)] public static bool2 operator <(float2 a, uint b) { return new bool2(a.x < b, a.y < b); }
        //[IN(LINE)] public static bool2 operator <(uint a, float2 b) { return new bool2(a < b.x, a < b.y); }
        //[IN(LINE)] public static bool2 operator <=(float2 a, uint b) { return new bool2(a.x <= b, a.y <= b); }
        //[IN(LINE)] public static bool2 operator <=(uint a, float2 b) { return new bool2(a <= b.x, a <= b.y); }
        //[IN(LINE)] public static bool2 operator >(float2 a, uint b) { return new bool2(a.x > b, a.y > b); }
        //[IN(LINE)] public static bool2 operator >(uint a, float2 b) { return new bool2(a > b.x, a > b.y); }
        //[IN(LINE)] public static bool2 operator >=(float2 a, uint b) { return new bool2(a.x >= b, a.y >= b); }
        //[IN(LINE)] public static bool2 operator >=(uint a, float2 b) { return new bool2(a >= b.x, a >= b.y); }
        //[IN(LINE)] public static bool2 operator ==(float2 a, uint b) { return new bool2(a.x == b, a.y == b); }
        //[IN(LINE)] public static bool2 operator ==(uint a, float2 b) { return new bool2(a == b.x, a == b.y); }
        //[IN(LINE)] public static bool2 operator !=(float2 a, uint b) { return new bool2(a.x != b, a.y != b); }
        //[IN(LINE)] public static bool2 operator !=(uint a, float2 b) { return new bool2(a != b.x, a != b.y); }
        //#endregion
        //
        //#region Arithmetic ulong
        //[IN(LINE)] public static float2 operator +(float2 a, ulong b) { return new float2(a.x + b, a.y + b); }
        //[IN(LINE)] public static float2 operator +(ulong a, float2 b) { return new float2(a + b.x, a + b.y); }
        //[IN(LINE)] public static float2 operator -(float2 a, ulong b) { return new float2(a.x - b, a.y - b); }
        //[IN(LINE)] public static float2 operator -(ulong a, float2 b) { return new float2(a - b.x, a - b.y); }
        //[IN(LINE)] public static float2 operator *(float2 a, ulong b) { return new float2(a.x * b, a.y * b); }
        //[IN(LINE)] public static float2 operator *(ulong a, float2 b) { return new float2(a * b.x, a * b.y); }
        //[IN(LINE)] public static float2 operator /(float2 a, ulong b) { return new float2(a.x / b, a.y / b); }
        //[IN(LINE)] public static float2 operator /(ulong a, float2 b) { return new float2(a / b.x, a / b.y); }
        //[IN(LINE)] public static float2 operator %(float2 a, ulong b) { return new float2(a.x % b, a.y % b); }
        //[IN(LINE)] public static float2 operator %(ulong a, float2 b) { return new float2(a % b.x, a % b.y); }
        //#endregion
        //
        //#region Boolean ulong
        //[IN(LINE)] public static bool2 operator <(float2 a, ulong b) { return new bool2(a.x < b, a.y < b); }
        //[IN(LINE)] public static bool2 operator <(ulong a, float2 b) { return new bool2(a < b.x, a < b.y); }
        //[IN(LINE)] public static bool2 operator <=(float2 a, ulong b) { return new bool2(a.x <= b, a.y <= b); }
        //[IN(LINE)] public static bool2 operator <=(ulong a, float2 b) { return new bool2(a <= b.x, a <= b.y); }
        //[IN(LINE)] public static bool2 operator >(float2 a, ulong b) { return new bool2(a.x > b, a.y > b); }
        //[IN(LINE)] public static bool2 operator >(ulong a, float2 b) { return new bool2(a > b.x, a > b.y); }
        //[IN(LINE)] public static bool2 operator >=(float2 a, ulong b) { return new bool2(a.x >= b, a.y >= b); }
        //[IN(LINE)] public static bool2 operator >=(ulong a, float2 b) { return new bool2(a >= b.x, a >= b.y); }
        //[IN(LINE)] public static bool2 operator ==(float2 a, ulong b) { return new bool2(a.x == b, a.y == b); }
        //[IN(LINE)] public static bool2 operator ==(ulong a, float2 b) { return new bool2(a == b.x, a == b.y); }
        //[IN(LINE)] public static bool2 operator !=(float2 a, ulong b) { return new bool2(a.x != b, a.y != b); }
        //[IN(LINE)] public static bool2 operator !=(ulong a, float2 b) { return new bool2(a != b.x, a != b.y); }
        //#endregion
    }

    public static partial class DM
    {
        [IN(LINE)] public static float2 Float2((float, float) v) => new float2(v);
        [IN(LINE)] public static float2 Float2<T>(T v) where T : IVector2<float> => new float2(v.x, v.y);
        [IN(LINE)] public static float2 Float2(bool v) => new float2(v);
        [IN(LINE)] public static float2 Float2(bool2 v) => new float2(v);
        [IN(LINE)] public static float2 Float2(int v) => new float2(v);
        [IN(LINE)] public static float2 Float2(int2 v) => new float2(v);
        [IN(LINE)] public static float2 Float2(uint v) => new float2(v);
        [IN(LINE)] public static float2 Float2(uint2 v) => new float2(v);
        [IN(LINE)] public static float2 Float2(float v) => new float2(v);
        [IN(LINE)] public static float2 Float2(float2 v) => new float2(v);
        [IN(LINE)] public static float2 Float2(double v) => new float2(v);
        [IN(LINE)] public static float2 Float2(double2 v) => new float2(v);
    }
}