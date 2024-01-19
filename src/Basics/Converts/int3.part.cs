using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct int3
    {
        #region Convert operators
        [IN(LINE)] public static implicit operator int3((int, int, int) v) => new int3(v.Item1, v.Item2, v.Item3);

        [IN(LINE)] public static explicit operator int3(bool v) => new int3(v);
        [IN(LINE)] public static explicit operator int3(bool3 v) => new int3(v);
        [IN(LINE)] public static implicit operator int3(int v) => new int3(v);
        //[IN(LINE)] public static implicit operator int3(int3 v) => new int3(v);
        [IN(LINE)] public static explicit operator int3(uint v) => new int3(v);
        [IN(LINE)] public static explicit operator int3(uint3 v) => new int3(v);
        [IN(LINE)] public static explicit operator int3(float v) => new int3(v);
        [IN(LINE)] public static explicit operator int3(float3 v) => new int3(v);
        [IN(LINE)] public static explicit operator int3(double v) => new int3(v);
        [IN(LINE)] public static explicit operator int3(double3 v) => new int3(v);
        #endregion

        #region Bool constructors
        [IN(LINE)]
        public int3(bool x, bool y, bool z)
        {
            this.x = x ? 1 : 0; this.y = y ? 1 : 0;
            this.z = z ? 1 : 0;
        }
        [IN(LINE)]
        public int3(bool v)
        {
            x = v ? 1 : 0; y = v ? 1 : 0;
            z = v ? 1 : 0;
        }
        [IN(LINE)]
        public int3(bool3 v)
        {
            x = v.x ? 1 : 0; y = v.y ? 1 : 0;
            z = v.z ? 1 : 0;
        }
        #endregion
    }

    public static partial class math
    {
        [IN(LINE)] public static int3 Int3((int, int, int) v) => new int3(v);
        [IN(LINE)] public static int3 Int3<T>(T v) where T : IVector3<int> => new int3(v.x, v.y, v.z);
        [IN(LINE)] public static int3 Int3(bool v) => new int3(v);
        [IN(LINE)] public static int3 Int3(bool x, bool y, bool z) => new int3(x, y, z);
        [IN(LINE)] public static int3 Int3(bool3 v) => new int3(v);
        [IN(LINE)] public static int3 Int3(int v) => new int3(v);
        [IN(LINE)] public static int3 Int3(int x, int y, int z) => new int3(x, y, z);
        [IN(LINE)] public static int3 Int3(int3 v) => new int3(v);
        [IN(LINE)] public static int3 Int3(uint v) => new int3(v);
        [IN(LINE)] public static int3 Int3(uint x, uint y, uint z) => new int3(x, y, z);
        [IN(LINE)] public static int3 Int3(uint3 v) => new int3(v);
        [IN(LINE)] public static int3 Int3(float v) => new int3(v);
        [IN(LINE)] public static int3 Int3(float x, float y, float z) => new int3(x, y, z);
        [IN(LINE)] public static int3 Int3(float3 v) => new int3(v);
        [IN(LINE)] public static int3 Int3(double v) => new int3(v);
        [IN(LINE)] public static int3 Int3(double x, double y, double z) => new int3(x, y, z);
        [IN(LINE)] public static int3 Int3(double3 v) => new int3(v);
    }
}
