#pragma warning disable CS8981
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct intray3
    {
        [IN(LINE)] public static explicit operator intray3(ray3 v) { return new intray3(v); }
    }
}
