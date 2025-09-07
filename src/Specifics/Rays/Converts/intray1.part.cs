using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct intray1
    {
        [IN(LINE)] public static explicit operator intray1(ray1 v) { return new intray1(v); }
    }
}
