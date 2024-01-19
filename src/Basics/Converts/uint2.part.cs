using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct uint2
    {
        #region Convert operators
        [IN(LINE)] public static implicit operator uint2((uint, uint) v) => new uint2(v.Item1, v.Item2);

        [IN(LINE)] public static explicit operator uint2(bool v) => new uint2(v);
        [IN(LINE)] public static explicit operator uint2(bool2 v) => new uint2(v);
        [IN(LINE)] public static explicit operator uint2(int v) => new uint2(v);
        [IN(LINE)] public static explicit operator uint2(int2 v) => new uint2(v);
        [IN(LINE)] public static implicit operator uint2(uint v) => new uint2(v);
        //[IN(LINE)] public static implicit operator uint2(uint2 v) => new uint2(v);
        [IN(LINE)] public static explicit operator uint2(float v) => new uint2(v);
        [IN(LINE)] public static explicit operator uint2(float2 v) => new uint2(v);
        [IN(LINE)] public static explicit operator uint2(double v) => new uint2(v);
        [IN(LINE)] public static explicit operator uint2(double2 v) => new uint2(v);
        #endregion

        #region Bool constructors
        [IN(LINE)]
        public uint2(bool x, bool y)
        {
            this.x = x ? 1u : 0u; this.y = y ? 1u : 0u;
        }
        [IN(LINE)]
        public uint2(bool v)
        {
            x = v ? 1u : 0u; y = v ? 1u : 0u;
        }
        [IN(LINE)]
        public uint2(bool2 v)
        {
            x = v.x ? 1u : 0u; y = v.y ? 1u : 0u;
        }
        #endregion
    }

    public static partial class math
    {
        [IN(LINE)] public static uint2 uint2((uint, uint) v) => new uint2(v);

        [IN(LINE)] public static uint2 uint2(bool v) => new uint2(v);
        [IN(LINE)] public static uint2 uint2(bool2 v) => new uint2(v);
        [IN(LINE)] public static uint2 uint2(int v) => new uint2(v);
        [IN(LINE)] public static uint2 uint2(int2 v) => new uint2(v);
        [IN(LINE)] public static uint2 uint2(uint v) => new uint2(v);
        [IN(LINE)] public static uint2 uint2(uint2 v) => new uint2(v);
        [IN(LINE)] public static uint2 uint2(float v) => new uint2(v);
        [IN(LINE)] public static uint2 uint2(float2 v) => new uint2(v);
        [IN(LINE)] public static uint2 uint2(double v) => new uint2(v);
        [IN(LINE)] public static uint2 uint2(double2 v) => new uint2(v);
    }
}
