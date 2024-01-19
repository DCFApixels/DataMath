using System.Windows.Documents;
using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct float2
    {
        #region Convert operators
        [IN(LINE)] public static implicit operator float2((float, float) v) => new float2(v.Item1, v.Item2);

        [IN(LINE)] public static explicit operator float2(bool v) => new float2(v);
        [IN(LINE)] public static explicit operator float2(bool2 v) => new float2(v);
        [IN(LINE)] public static implicit operator float2(int v) => new float2(v);
        [IN(LINE)] public static implicit operator float2(int2 v) => new float2(v);
        [IN(LINE)] public static implicit operator float2(uint v) => new float2(v);
        [IN(LINE)] public static implicit operator float2(uint2 v) => new float2(v);
        [IN(LINE)] public static implicit operator float2(float v) => new float2(v);
        //[IN(LINE)] public static explicit operator float2(float2 v) => new float2(v);
        [IN(LINE)] public static explicit operator float2(double v) => new float2(v);
        [IN(LINE)] public static explicit operator float2(double2 v) => new float2(v);
        #endregion

        #region Bool constructors
        [IN(LINE)]
        public float2(bool x, bool y)
        {
            this.x = x ? 1f : 0f; this.y = y ? 1f : 0f;
        }
        [IN(LINE)]
        public float2(bool v)
        {
            x = v ? 1f : 0f; y = v ? 1f : 0f;
        }
        [IN(LINE)]
        public float2(bool2 v)
        {
            x = v.x ? 1f : 0f; y = v.y ? 1f : 0f;
        }
        #endregion
    }

    public static partial class math
    {
        [IN(LINE)] public static float2 float2((float, float) v) => new float2(v);

        [IN(LINE)] public static float2 float2(bool v) => new float2(v);
        [IN(LINE)] public static float2 float2(bool2 v) => new float2(v);
        [IN(LINE)] public static float2 float2(int v) => new float2(v);
        [IN(LINE)] public static float2 float2(int2 v) => new float2(v);
        [IN(LINE)] public static float2 float2(uint v) => new float2(v);
        [IN(LINE)] public static float2 float2(uint2 v) => new float2(v);
        [IN(LINE)] public static float2 float2(float v) => new float2(v);
        [IN(LINE)] public static float2 float2(float2 v) => new float2(v);
        [IN(LINE)] public static float2 float2(double v) => new float2(v);
        [IN(LINE)] public static float2 float2(double2 v) => new float2(v);
    }
}