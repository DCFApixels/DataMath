#pragma warning disable CS8981
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct ray2
    {
        [IN(LINE)] public static implicit operator ray2(intray2 v) { return new ray2(v); }
    }
}
