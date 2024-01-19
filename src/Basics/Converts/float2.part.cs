using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct float2
    {
        #region Convert operators
        [IN(LINE)] public static implicit operator float2((float, float) v) => new float2(v.Item1, v.Item2);

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
    }

    public static partial class math
    {
        [IN(LINE)] public static float2 Float2((float, float) v) => new float2(v);
        [IN(LINE)] public static float2 Float2<T>(T v) where T : IVector2<float> => new float2(v.x, v.y);
        [IN(LINE)] public static float2 Float2(bool v) => new float2(v);
        [IN(LINE)] public static float2 Float2(bool x, bool y) => new float2(x, y);
        [IN(LINE)] public static float2 Float2(bool2 v) => new float2(v);
        [IN(LINE)] public static float2 Float2(int v) => new float2(v);
        [IN(LINE)] public static float2 Float2(int x, int y) => new float2(x, y);
        [IN(LINE)] public static float2 Float2(int2 v) => new float2(v);
        [IN(LINE)] public static float2 Float2(uint v) => new float2(v);
        [IN(LINE)] public static float2 Float2(uint x, uint y) => new float2(x, y);
        [IN(LINE)] public static float2 Float2(uint2 v) => new float2(v);
        [IN(LINE)] public static float2 Float2(float v) => new float2(v);
        [IN(LINE)] public static float2 Float2(float x, float y) => new float2(x, y);
        [IN(LINE)] public static float2 Float2(float2 v) => new float2(v);
        [IN(LINE)] public static float2 Float2(double v) => new float2(v);
        [IN(LINE)] public static float2 Float2(double x, double y) => new float2(x, y);
        [IN(LINE)] public static float2 Float2(double2 v) => new float2(v);
    }
}