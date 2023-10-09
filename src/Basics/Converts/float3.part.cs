using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct float3
    {
        #region Convert operators
        [IN(LINE)] public static implicit operator float3((float, float, float) v) => new float3(v.Item1, v.Item2, v.Item3);

        [IN(LINE)] public static implicit operator float3(float v) => new float3(v);
        //[IN(LINE)] public static explicit operator float3(float3 v) => new float3(v);
        [IN(LINE)] public static implicit operator float3(int v) => new float3(v);
        [IN(LINE)] public static implicit operator float3(int3 v) => new float3(v);
        [IN(LINE)] public static implicit operator float3(uint v) => new float3(v);
        [IN(LINE)] public static implicit operator float3(uint3 v) => new float3(v);
        [IN(LINE)] public static explicit operator float3(double v) => new float3(v);
        [IN(LINE)] public static explicit operator float3(double3 v) => new float3(v);
        #endregion
    }

    public static partial class math
    {
        [IN(LINE)] public static float3 float3((float, float, float) v) => new float3(v);

        [IN(LINE)] public static float3 float3(float v) => new float3(v);
        [IN(LINE)] public static float3 float3(float3 v) => new float3(v);
        [IN(LINE)] public static float3 float3(int v) => new float3(v);
        [IN(LINE)] public static float3 float3(int3 v) => new float3(v);
        [IN(LINE)] public static float3 float3(uint v) => new float3(v);
        [IN(LINE)] public static float3 float3(uint3 v) => new float3(v);
        [IN(LINE)] public static float3 float3(double v) => new float3(v);
        [IN(LINE)] public static float3 float3(double3 v) => new float3(v);
    }
}
