using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct int2
    {
        #region Convert operators
        [IN(LINE)] public static implicit operator int2((int, int) v) => new int2(v.Item1, v.Item2);

        [IN(LINE)] public static explicit operator int2(bool v) => new int2(v);
        [IN(LINE)] public static explicit operator int2(bool2 v) => new int2(v);
        [IN(LINE)] public static implicit operator int2(int v) => new int2(v);
        //[IN(LINE)] public static implicit operator int2(int2 v) => new int2(v);
        [IN(LINE)] public static explicit operator int2(uint v) => new int2(v);
        [IN(LINE)] public static explicit operator int2(uint2 v) => new int2(v);
        [IN(LINE)] public static explicit operator int2(float v) => new int2(v);
        [IN(LINE)] public static explicit operator int2(float2 v) => new int2(v);
        [IN(LINE)] public static explicit operator int2(double v) => new int2(v);
        [IN(LINE)] public static explicit operator int2(double2 v) => new int2(v);
        #endregion

        #region Bool constructors
        [IN(LINE)]
        public int2(bool x, bool y)
        {
            this.x = x ? 1 : 0; this.y = y ? 1 : 0;
        }
        [IN(LINE)]
        public int2(bool v)
        {
            x = v ? 1 : 0; y = v ? 1 : 0;
        }
        [IN(LINE)]
        public int2(bool2 v)
        {
            x = v.x ? 1 : 0; y = v.y ? 1 : 0;
        }
        #endregion
    }

    public static partial class math
    {
        [IN(LINE)] public static int2 int2((int, int) v) => new int2(v);

        [IN(LINE)] public static int2 int2(bool v) => new int2(v);
        [IN(LINE)] public static int2 int2(bool2 v) => new int2(v);
        [IN(LINE)] public static int2 int2(int v) => new int2(v);
        [IN(LINE)] public static int2 int2(int2 v) => new int2(v);
        [IN(LINE)] public static int2 int2(uint v) => new int2(v);
        [IN(LINE)] public static int2 int2(uint2 v) => new int2(v);
        [IN(LINE)] public static int2 int2(float v) => new int2(v);
        [IN(LINE)] public static int2 int2(float2 v) => new int2(v);
        [IN(LINE)] public static int2 int2(double v) => new int2(v);
        [IN(LINE)] public static int2 int2(double2 v) => new int2(v);
    }
}
