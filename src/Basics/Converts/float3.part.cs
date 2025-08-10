using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct float3
    {
        #region Convert operators
        [IN(LINE)] public static implicit operator float3((float, float, float) v) => new float3(v.Item1, v.Item2, v.Item3);

        [IN(LINE)] public static explicit operator float3(bool v) => new float3(v);
        [IN(LINE)] public static explicit operator float3(bool3 v) => new float3(v);
        [IN(LINE)] public static implicit operator float3(int v) => new float3(v);
        [IN(LINE)] public static implicit operator float3(int3 v) => new float3(v);
        [IN(LINE)] public static implicit operator float3(uint v) => new float3(v);
        [IN(LINE)] public static implicit operator float3(uint3 v) => new float3(v);
        [IN(LINE)] public static implicit operator float3(float v) => new float3(v);
        //[IN(LINE)] public static explicit operator float3(float3 v) => new float3(v);
        [IN(LINE)] public static explicit operator float3(double v) => new float3(v);
        [IN(LINE)] public static explicit operator float3(double3 v) => new float3(v);
        #endregion

        #region Bool constructors
        [IN(LINE)]
        public float3(bool x, bool y, bool z)
        {
            this.x = x ? 1f : 0f; this.y = y ? 1f : 0f;
            this.z = z ? 1f : 0f;
        }
        [IN(LINE)]
        public float3(bool v)
        {
            x = v ? 1f : 0f; y = v ? 1f : 0f;
            z = v ? 1f : 0f;
        }
        [IN(LINE)]
        public float3(bool3 v)
        {
            x = v.x ? 1f : 0f; y = v.y ? 1f : 0f;
            z = v.z ? 1f : 0f;
        }
        #endregion
    }

    public static partial class DM
    {
        [IN(LINE)] public static float3 Float3((float, float, float) v) => new float3(v);
        [IN(LINE)] public static float3 Float3<T>(T v) where T : IVector3<float> => new float3(v.x, v.y, v.z);
        [IN(LINE)] public static float3 Float3(bool v) => new float3(v);
        [IN(LINE)] public static float3 Float3(bool x, bool y, bool z) => new float3(x, y, z);
        [IN(LINE)] public static float3 Float3(bool3 v) => new float3(v);
        [IN(LINE)] public static float3 Float3(int v) => new float3(v);
        [IN(LINE)] public static float3 Float3(int x, int y, int z) => new float3(x, y, z);
        [IN(LINE)] public static float3 Float3(int3 v) => new float3(v);
        [IN(LINE)] public static float3 Float3(uint v) => new float3(v);
        [IN(LINE)] public static float3 Float3(uint x, uint y, uint z) => new float3(x, y, z);
        [IN(LINE)] public static float3 Float3(uint3 v) => new float3(v);
        [IN(LINE)] public static float3 Float3(float v) => new float3(v);
        [IN(LINE)] public static float3 Float3(float x, float y, float z) => new float3(x, y, z);
        [IN(LINE)] public static float3 Float3(float3 v) => new float3(v);
        [IN(LINE)] public static float3 Float3(double v) => new float3(v);
        [IN(LINE)] public static float3 Float3(double x, double y, double z) => new float3(x, y, z);
        [IN(LINE)] public static float3 Float3(double3 v) => new float3(v);
    }
}
