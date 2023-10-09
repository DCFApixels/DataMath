using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct float4
    {
        #region Convert operators
        [IN(LINE)] public static implicit operator float4((float, float, float, float) v) => new float4(v.Item1, v.Item2, v.Item3, v.Item4);

        [IN(LINE)] public static implicit operator float4(float v) => new float4(v);
        //[IN(LINE)] public static explicit operator float4(float4 v) => new float4(v);
        [IN(LINE)] public static implicit operator float4(int v) => new float4(v);
        [IN(LINE)] public static implicit operator float4(int4 v) => new float4(v);
        [IN(LINE)] public static implicit operator float4(uint v) => new float4(v);
        [IN(LINE)] public static implicit operator float4(uint4 v) => new float4(v);
        [IN(LINE)] public static explicit operator float4(double v) => new float4(v);
        [IN(LINE)] public static explicit operator float4(double4 v) => new float4(v);
        #endregion
    }

    public static partial class math
    {
        [IN(LINE)] public static float4 float4((float, float, float, float) v) => new float4(v);

        [IN(LINE)] public static float4 float4(float v) => new float4(v);
        [IN(LINE)] public static float4 float4(float4 v) => new float4(v);
        [IN(LINE)] public static float4 float4(int v) => new float4(v);
        [IN(LINE)] public static float4 float4(int4 v) => new float4(v);
        [IN(LINE)] public static float4 float4(uint v) => new float4(v);
        [IN(LINE)] public static float4 float4(uint4 v) => new float4(v);
        [IN(LINE)] public static float4 float4(double v) => new float4(v);
        [IN(LINE)] public static float4 float4(double4 v) => new float4(v);
    }
}
