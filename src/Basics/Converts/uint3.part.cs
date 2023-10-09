using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct uint3
    {
        #region Convert operators
        [IN(LINE)] public static implicit operator uint3((uint, uint, uint) v) => new uint3(v.Item1, v.Item2, v.Item3);

        [IN(LINE)] public static explicit operator uint3(float v) => new uint3(v);
        [IN(LINE)] public static explicit operator uint3(float3 v) => new uint3(v);
        [IN(LINE)] public static explicit operator uint3(int v) => new uint3(v);
        [IN(LINE)] public static explicit operator uint3(int3 v) => new uint3(v);
        [IN(LINE)] public static implicit operator uint3(uint v) => new uint3(v);
        //[IN(LINE)] public static implicit operator uint3(uint3 v) => new uint3(v);
        [IN(LINE)] public static explicit operator uint3(double v) => new uint3(v);
        [IN(LINE)] public static explicit operator uint3(double3 v) => new uint3(v);
        #endregion
    }

    public static partial class math
    {
        [IN(LINE)] public static uint3 uint3((uint, uint, uint) v) => new uint3(v);

        [IN(LINE)] public static uint3 uint3(float v) => new uint3(v);
        [IN(LINE)] public static uint3 uint3(float3 v) => new uint3(v);
        [IN(LINE)] public static uint3 uint3(int v) => new uint3(v);
        [IN(LINE)] public static uint3 uint3(int3 v) => new uint3(v);
        [IN(LINE)] public static uint3 uint3(uint v) => new uint3(v);
        [IN(LINE)] public static uint3 uint3(uint3 v) => new uint3(v);
        [IN(LINE)] public static uint3 uint3(double v) => new uint3(v);
        [IN(LINE)] public static uint3 uint3(double3 v) => new uint3(v);
    }
}
