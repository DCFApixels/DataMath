using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct uint4
    {
        #region Convert operators
        [IN(LINE)] public static implicit operator uint4((uint, uint, uint, uint) v) => new uint4(v.Item1, v.Item2, v.Item3, v.Item4);

        [IN(LINE)] public static explicit operator uint4(bool v) => new uint4(v);
        [IN(LINE)] public static explicit operator uint4(bool4 v) => new uint4(v);
        [IN(LINE)] public static explicit operator uint4(int v) => new uint4(v);
        [IN(LINE)] public static explicit operator uint4(int4 v) => new uint4(v);
        [IN(LINE)] public static implicit operator uint4(uint v) => new uint4(v);
        //[IN(LINE)] public static implicit operator uint4(uint4 v) => new uint4(v);
        [IN(LINE)] public static explicit operator uint4(float v) => new uint4(v);
        [IN(LINE)] public static explicit operator uint4(float4 v) => new uint4(v);
        [IN(LINE)] public static explicit operator uint4(double v) => new uint4(v);
        [IN(LINE)] public static explicit operator uint4(double4 v) => new uint4(v);
        #endregion

        #region Bool constructors
        [IN(LINE)]
        public uint4(bool x, bool y, bool z, bool w)
        {
            this.x = x ? 1u : 0u; this.y = y ? 1u : 0u;
            this.z = z ? 1u : 0u; this.w = w ? 1u : 0u;
        }
        [IN(LINE)]
        public uint4(bool v)
        {
            x = v ? 1u : 0u; y = v ? 1u : 0u;
            z = v ? 1u : 0u; w = v ? 1u : 0u;
        }
        [IN(LINE)]
        public uint4(bool4 v)
        {
            x = v.x ? 1u : 0u; y = v.y ? 1u : 0u;
            z = v.z ? 1u : 0u; w = v.w ? 1u : 0u;
        }
        #endregion
    }

    public static partial class math
    {
        [IN(LINE)] public static uint4 UInt4((uint, uint, uint, uint) v) => new uint4(v);
        [IN(LINE)] public static uint4 UInt4<T>(T v) where T : IVector4<uint> => new uint4(v.x, v.y, v.z, v.w);
        [IN(LINE)] public static uint4 UInt4(bool v) => new uint4(v);
        [IN(LINE)] public static uint4 UInt4(bool x, bool y, bool z, bool w) => new uint4(x, y, z, w);
        [IN(LINE)] public static uint4 UInt4(bool4 v) => new uint4(v);
        [IN(LINE)] public static uint4 UInt4(int v) => new uint4(v);
        [IN(LINE)] public static uint4 UInt4(int x, int y, int z, int w) => new uint4(x, y, z, w);
        [IN(LINE)] public static uint4 UInt4(int4 v) => new uint4(v);
        [IN(LINE)] public static uint4 UInt4(uint v) => new uint4(v);
        [IN(LINE)] public static uint4 UInt4(uint x, uint y, uint z, uint w) => new uint4(x, y, z, w);
        [IN(LINE)] public static uint4 UInt4(uint4 v) => new uint4(v);
        [IN(LINE)] public static uint4 UInt4(float v) => new uint4(v);
        [IN(LINE)] public static uint4 UInt4(float x, float y, float z, float w) => new uint4(x, y, z, w);
        [IN(LINE)] public static uint4 UInt4(float4 v) => new uint4(v);
        [IN(LINE)] public static uint4 UInt4(double v) => new uint4(v);
        [IN(LINE)] public static uint4 UInt4(double x, double y, double z, double w) => new uint4(x, y, z, w);
        [IN(LINE)] public static uint4 UInt4(double4 v) => new uint4(v);
    }
}
