#pragma warning disable CS8981
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct ray4
    {
        [IN(LINE)] public static implicit operator ray4(intray4 v) { return new ray4(v); }
    }
}
