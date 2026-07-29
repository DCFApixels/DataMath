#pragma warning disable CS8981
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct ray3
    {
        [IN(LINE)] public static implicit operator ray3(intray3 v) { return new ray3(v); }
    }
}
