using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct bool3
    {
        #region Convert operators
        [IN(LINE)] public static implicit operator bool3((bool, bool, bool) v) => new bool3(v);

        [IN(LINE)] public static implicit operator bool3(bool v) => new bool3(v);
        //[IN(LINE)] public static implicit operator bool3(bool3 v) => new bool3(v);
        [IN(LINE)] public static implicit operator bool3(int v) => new bool3(v);
        [IN(LINE)] public static implicit operator bool3(int3 v) => new bool3(v);
        [IN(LINE)] public static explicit operator bool3(uint v) => new bool3(v);
        [IN(LINE)] public static explicit operator bool3(uint3 v) => new bool3(v);
        [IN(LINE)] public static explicit operator bool3(float v) => new bool3(v);
        [IN(LINE)] public static explicit operator bool3(float3 v) => new bool3(v);
        [IN(LINE)] public static explicit operator bool3(double v) => new bool3(v);
        [IN(LINE)] public static explicit operator bool3(double3 v) => new bool3(v);
        #endregion
    }

    public static partial class DM
    {
        [IN(LINE)] public static bool3 Bool3((bool, bool, bool) v) => new bool3(v);
        [IN(LINE)] public static bool3 Bool3(bool v) => new bool3(v);
        [IN(LINE)] public static bool3 Bool3(bool3 v) => new bool3(v);
        [IN(LINE)] public static bool3 Bool3(int v) => new bool3(v);
        [IN(LINE)] public static bool3 Bool3(int3 v) => new bool3(v);
        [IN(LINE)] public static bool3 Bool3(uint v) => new bool3(v);
        [IN(LINE)] public static bool3 Bool3(uint3 v) => new bool3(v);
        [IN(LINE)] public static bool3 Bool3(float v) => new bool3(v);
        [IN(LINE)] public static bool3 Bool3(float3 v) => new bool3(v);
        [IN(LINE)] public static bool3 Bool3(double v) => new bool3(v);
        [IN(LINE)] public static bool3 Bool3(double3 v) => new bool3(v);
    }
}
