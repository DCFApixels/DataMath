using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct float4
    {
        #region Convert operators
        [IN(LINE)] public static implicit operator float4((float, float, float, float) v) => new float4(v.Item1, v.Item2, v.Item3, v.Item4);

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
    }

    public static partial class math
    {
        [IN(LINE)] public static float4 float4((float, float, float, float) v) => new float4(v);

        [IN(LINE)] public static float4 float4(bool v) => new float4(v);
        [IN(LINE)] public static float4 float4(bool4 v) => new float4(v);
        [IN(LINE)] public static float4 float4(int v) => new float4(v);
        [IN(LINE)] public static float4 float4(int4 v) => new float4(v);
        [IN(LINE)] public static float4 float4(uint v) => new float4(v);
        [IN(LINE)] public static float4 float4(uint4 v) => new float4(v);
        [IN(LINE)] public static float4 float4(float v) => new float4(v);
        [IN(LINE)] public static float4 float4(float4 v) => new float4(v);
        [IN(LINE)] public static float4 float4(double v) => new float4(v);
        [IN(LINE)] public static float4 float4(double4 v) => new float4(v);
    }
}
