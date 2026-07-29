#pragma warning disable CS8981
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct intray4
    {
        [IN(LINE)] public static explicit operator intray4(ray4 v) { return new intray4(v); }
    }
}
