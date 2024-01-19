using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct bool2
    {
        #region Convert operators
        [IN(LINE)] public static implicit operator bool2((bool, bool) v) => new bool2(v.Item1, v.Item2);

        [IN(LINE)] public static implicit operator bool2(bool v) => new bool2(v);
        //[IN(LINE)] public static implicit operator bool2(bool2 v) => new bool2(v);
        [IN(LINE)] public static implicit operator bool2(int v) => new bool2(v);
        [IN(LINE)] public static implicit operator bool2(int2 v) => new bool2(v);
        [IN(LINE)] public static explicit operator bool2(uint v) => new bool2(v);
        [IN(LINE)] public static explicit operator bool2(uint2 v) => new bool2(v);
        [IN(LINE)] public static explicit operator bool2(float v) => new bool2(v);
        [IN(LINE)] public static explicit operator bool2(float2 v) => new bool2(v);
        [IN(LINE)] public static explicit operator bool2(double v) => new bool2(v);
        [IN(LINE)] public static explicit operator bool2(double2 v) => new bool2(v);
        #endregion
    }

    public static partial class math
    {
        [IN(LINE)] public static bool2 Bool2((bool, bool) v) => new bool2(v);
        [IN(LINE)] public static bool2 Bool2(bool v) => new bool2(v);
        [IN(LINE)] public static bool2 Bool2(bool2 v) => new bool2(v);
        [IN(LINE)] public static bool2 Bool2(int v) => new bool2(v);
        [IN(LINE)] public static bool2 Bool2(int2 v) => new bool2(v);
        [IN(LINE)] public static bool2 Bool2(uint v) => new bool2(v);
        [IN(LINE)] public static bool2 Bool2(uint2 v) => new bool2(v);
        [IN(LINE)] public static bool2 Bool2(float v) => new bool2(v);
        [IN(LINE)] public static bool2 Bool2(float2 v) => new bool2(v);
        [IN(LINE)] public static bool2 Bool2(double v) => new bool2(v);
        [IN(LINE)] public static bool2 Bool2(double2 v) => new bool2(v);
    }
}
