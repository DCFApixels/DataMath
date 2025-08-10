using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct uint3
    {
        #region Convert operators
        [IN(LINE)] public static implicit operator uint3((uint, uint, uint) v) => new uint3(v.Item1, v.Item2, v.Item3);

        [IN(LINE)] public static explicit operator uint3(bool v) => new uint3(v);
        [IN(LINE)] public static explicit operator uint3(bool3 v) => new uint3(v);
        [IN(LINE)] public static explicit operator uint3(int v) => new uint3(v);
        [IN(LINE)] public static explicit operator uint3(int3 v) => new uint3(v);
        [IN(LINE)] public static implicit operator uint3(uint v) => new uint3(v);
        //[IN(LINE)] public static implicit operator uint3(uint3 v) => new uint3(v);
        [IN(LINE)] public static explicit operator uint3(float v) => new uint3(v);
        [IN(LINE)] public static explicit operator uint3(float3 v) => new uint3(v);
        [IN(LINE)] public static explicit operator uint3(double v) => new uint3(v);
        [IN(LINE)] public static explicit operator uint3(double3 v) => new uint3(v);
        #endregion

        #region Bool constructors
        [IN(LINE)]
        public uint3(bool x, bool y, bool z)
        {
            this.x = x ? 1u : 0u; this.y = y ? 1u : 0u;
            this.z = z ? 1u : 0u;
        }
        [IN(LINE)]
        public uint3(bool v)
        {
            x = v ? 1u : 0u; y = v ? 1u : 0u;
            z = v ? 1u : 0u;
        }
        [IN(LINE)]
        public uint3(bool3 v)
        {
            x = v.x ? 1u : 0u; y = v.y ? 1u : 0u;
            z = v.z ? 1u : 0u;
        }
        #endregion
    }

    public static partial class DM
    {
        [IN(LINE)] public static uint3 UInt3((uint, uint, uint) v) => new uint3(v);
        [IN(LINE)] public static uint3 UInt3<T>(T v) where T : IVector3<uint> => new uint3(v.x, v.y, v.z);
        [IN(LINE)] public static uint3 UInt3(bool v) => new uint3(v);
        [IN(LINE)] public static uint3 UInt3(bool x, bool y, bool z) => new uint3(x, y, z);
        [IN(LINE)] public static uint3 UInt3(bool3 v) => new uint3(v);
        [IN(LINE)] public static uint3 UInt3(int v) => new uint3(v);
        [IN(LINE)] public static uint3 UInt3(int x, int y, int z) => new uint3(x, y, z);
        [IN(LINE)] public static uint3 UInt3(int3 v) => new uint3(v);
        [IN(LINE)] public static uint3 UInt3(uint v) => new uint3(v);
        [IN(LINE)] public static uint3 UInt3(uint x, uint y, uint z) => new uint3(x, y, z);
        [IN(LINE)] public static uint3 UInt3(uint3 v) => new uint3(v);
        [IN(LINE)] public static uint3 UInt3(float v) => new uint3(v);
        [IN(LINE)] public static uint3 UInt3(float x, float y, float z) => new uint3(x, y, z);
        [IN(LINE)] public static uint3 UInt3(float3 v) => new uint3(v);
        [IN(LINE)] public static uint3 UInt3(double v) => new uint3(v);
        [IN(LINE)] public static uint3 UInt3(double x, double y, double z) => new uint3(x, y, z);
        [IN(LINE)] public static uint3 UInt3(double3 v) => new uint3(v);
    }
}
