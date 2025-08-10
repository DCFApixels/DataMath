using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;
using SMath = System.Math;
#if !DOTNET_FRAMEWORK || UNITY_5_3_OR_NEWER
using SMathF = System.MathF;
#else
using SMathF = DCFApixels.DataMath.Internal.MathDM;
#endif

namespace DCFApixels.DataMath
{
    public partial struct uint2 : IBoolVector
    {
        public bool all { [IN(LINE)] get { return x != 0 & y != 0; } }
        public bool any { [IN(LINE)] get { return x != 0 | y != 0; } }
    }
    public static partial class DM
    {
        [IN(LINE)]
        public static uint2 one_minus(uint2 v) => 1u - v;
        [IN(LINE)]
        public static uint2 abs(uint2 v)
        {
            return new uint2(SMathF.Abs(v.x), SMathF.Abs(v.y));
        }
        [IN(LINE)]
        public static int2 sign(uint2 v)
        {
            return new int2(SMath.Sign(v.x), SMath.Sign(v.y));
        }

    }
}
