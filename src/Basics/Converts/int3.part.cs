using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct int3
    {
        #region Convert operators
        [IN(LINE)] public static implicit operator int3((int, int, int) v) => new int3(v.Item1, v.Item2, v.Item3);

        [IN(LINE)] public static explicit operator int3(float v) => new int3(v);
        [IN(LINE)] public static explicit operator int3(float3 v) => new int3(v);
        [IN(LINE)] public static implicit operator int3(int v) => new int3(v);
        //[IN(LINE)] public static implicit operator int3(int3 v) => new int3(v);
        [IN(LINE)] public static explicit operator int3(uint v) => new int3(v);
        [IN(LINE)] public static explicit operator int3(uint3 v) => new int3(v);
        [IN(LINE)] public static explicit operator int3(double v) => new int3(v);
        [IN(LINE)] public static explicit operator int3(double3 v) => new int3(v);
        #endregion
    }

    public static partial class math
    {
        [IN(LINE)] public static int3 int3((int, int, int) v) => new int3(v);

        [IN(LINE)] public static int3 int3(float v) => new int3(v);
        [IN(LINE)] public static int3 int3(float3 v) => new int3(v);
        [IN(LINE)] public static int3 int3(int v) => new int3(v);
        [IN(LINE)] public static int3 int3(int3 v) => new int3(v);
        [IN(LINE)] public static int3 int3(uint v) => new int3(v);
        [IN(LINE)] public static int3 int3(uint3 v) => new int3(v);
        [IN(LINE)] public static int3 int3(double v) => new int3(v);
        [IN(LINE)] public static int3 int3(double3 v) => new int3(v);
    }
}
