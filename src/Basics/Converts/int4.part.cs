using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct int4
    {
        #region Convert operators
        [IN(LINE)] public static implicit operator int4((int, int, int, int) v) => new int4(v.Item1, v.Item2, v.Item3, v.Item4);

        [IN(LINE)] public static explicit operator int4(bool v) => new int4(v);
        [IN(LINE)] public static explicit operator int4(bool4 v) => new int4(v);
        [IN(LINE)] public static implicit operator int4(int v) => new int4(v);
        //[IN(LINE)] public static implicit operator int4(int4 v) => new int4(v);
        [IN(LINE)] public static explicit operator int4(uint v) => new int4(v);
        [IN(LINE)] public static explicit operator int4(uint4 v) => new int4(v);
        [IN(LINE)] public static explicit operator int4(float v) => new int4(v);
        [IN(LINE)] public static explicit operator int4(float4 v) => new int4(v);
        [IN(LINE)] public static explicit operator int4(double v) => new int4(v);
        [IN(LINE)] public static explicit operator int4(double4 v) => new int4(v);
        #endregion

        #region Bool constructors
        [IN(LINE)]
        public int4(bool x, bool y, bool z, bool w)
        {
            this.x = x ? 1 : 0; this.y = y ? 1 : 0;
            this.z = z ? 1 : 0; this.w = w ? 1 : 0;
        }
        [IN(LINE)]
        public int4(bool v)
        {
            x = v ? 1 : 0; y = v ? 1 : 0;
            z = v ? 1 : 0; w = v ? 1 : 0;
        }
        [IN(LINE)]
        public int4(bool4 v)
        {
            x = v.x ? 1 : 0; y = v.y ? 1 : 0;
            z = v.z ? 1 : 0; w = v.w ? 1 : 0;
        }
        #endregion
    }

    public static partial class math
    {
        [IN(LINE)] public static int4 int4((int, int, int, int) v) => new int4(v);

        [IN(LINE)] public static int4 int4(bool v) => new int4(v);
        [IN(LINE)] public static int4 int4(bool4 v) => new int4(v);
        [IN(LINE)] public static int4 int4(int v) => new int4(v);
        [IN(LINE)] public static int4 int4(int4 v) => new int4(v);
        [IN(LINE)] public static int4 int4(uint v) => new int4(v);
        [IN(LINE)] public static int4 int4(uint4 v) => new int4(v);
        [IN(LINE)] public static int4 int4(float v) => new int4(v);
        [IN(LINE)] public static int4 int4(float4 v) => new int4(v);
        [IN(LINE)] public static int4 int4(double v) => new int4(v);
        [IN(LINE)] public static int4 int4(double4 v) => new int4(v);
    }
}
