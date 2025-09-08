#pragma warning disable CS8981
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct intray2
    {
        [IN(LINE)] public static explicit operator intray2(ray2 v) { return new intray2(v); }
    }
}
