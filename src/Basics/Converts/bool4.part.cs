using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct bool4
    {
        #region Convert operators
        [IN(LINE)] public static implicit operator bool4((bool, bool, bool, bool) v) => new bool4(v);

        [IN(LINE)] public static implicit operator bool4(bool v) => new bool4(v);
        //[IN(LINE)] public static implicit operator bool4(bool4 v) => new bool4(v);
        [IN(LINE)] public static implicit operator bool4(int v) => new bool4(v);
        [IN(LINE)] public static implicit operator bool4(int4 v) => new bool4(v);
        [IN(LINE)] public static explicit operator bool4(uint v) => new bool4(v);
        [IN(LINE)] public static explicit operator bool4(uint4 v) => new bool4(v);
        [IN(LINE)] public static explicit operator bool4(float v) => new bool4(v);
        [IN(LINE)] public static explicit operator bool4(float4 v) => new bool4(v);
        [IN(LINE)] public static explicit operator bool4(double v) => new bool4(v);
        [IN(LINE)] public static explicit operator bool4(double4 v) => new bool4(v);
        #endregion
    }

    public static partial class DM
    {
        [IN(LINE)] public static bool4 Bool4((bool, bool, bool, bool) v) => new bool4(v);
        [IN(LINE)] public static bool4 Bool4(bool v) => new bool4(v);
        [IN(LINE)] public static bool4 Bool4(bool4 v) => new bool4(v);
        [IN(LINE)] public static bool4 Bool4(int v) => new bool4(v);
        [IN(LINE)] public static bool4 Bool4(int4 v) => new bool4(v);
        [IN(LINE)] public static bool4 Bool4(uint v) => new bool4(v);
        [IN(LINE)] public static bool4 Bool4(uint4 v) => new bool4(v);
        [IN(LINE)] public static bool4 Bool4(float v) => new bool4(v);
        [IN(LINE)] public static bool4 Bool4(float4 v) => new bool4(v);
        [IN(LINE)] public static bool4 Bool4(double v) => new bool4(v);
        [IN(LINE)] public static bool4 Bool4(double4 v) => new bool4(v);
    }

    public static partial class DMBasic
    {

    }
}
