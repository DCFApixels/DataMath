using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct ray1
    {
        [IN(LINE)] public static implicit operator ray1(intray1 v) { return new ray1(v); }
    }
}
