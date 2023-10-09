using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct float2
    {
        #region Convert operators
        [IN(LINE)] public static implicit operator float2((float, float) v) => new float2(v.Item1, v.Item2);

        [IN(LINE)] public static implicit operator float2(float v) => new float2(v);
        //[IN(LINE)] public static explicit operator float2(float2 v) => new float2(v);
        [IN(LINE)] public static implicit operator float2(int v) => new float2(v);
        [IN(LINE)] public static implicit operator float2(int2 v) => new float2(v);
        [IN(LINE)] public static implicit operator float2(uint v) => new float2(v);
        [IN(LINE)] public static implicit operator float2(uint2 v) => new float2(v);
        [IN(LINE)] public static explicit operator float2(double v) => new float2(v);
        [IN(LINE)] public static explicit operator float2(double2 v) => new float2(v);
        #endregion
    }

    public static partial class math
    {
        [IN(LINE)] public static float2 float2((float, float) v) => new float2(v);

        [IN(LINE)] public static float2 float2(float v) => new float2(v);
        [IN(LINE)] public static float2 float2(float2 v) => new float2(v);
        [IN(LINE)] public static float2 float2(int v) => new float2(v);
        [IN(LINE)] public static float2 float2(int2 v) => new float2(v);
        [IN(LINE)] public static float2 float2(uint v) => new float2(v);
        [IN(LINE)] public static float2 float2(uint2 v) => new float2(v);
        [IN(LINE)] public static float2 float2(double v) => new float2(v);
        [IN(LINE)] public static float2 float2(double2 v) => new float2(v);
    }
}