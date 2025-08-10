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
    public partial struct uint4 : IBoolVector
    {
        public bool all { [IN(LINE)] get { return x != 0 & y != 0 & z != 0 & w != 0; } }
        public bool any { [IN(LINE)] get { return x != 0 | y != 0 | z != 0 | w != 0; } }
    }
    public static partial class DM
    {
        [IN(LINE)]
        public static uint4 one_minus(uint4 v) => 1u - v;
        [IN(LINE)]
        public static uint4 abs(uint4 v)
        {
            return new uint4(SMathF.Abs(v.x), SMathF.Abs(v.y), SMathF.Abs(v.z), SMathF.Abs(v.w));
        }
        [IN(LINE)]
        public static int4 sign(uint4 v)
        {
            return new int4(SMath.Sign(v.x), SMath.Sign(v.y), SMath.Sign(v.z), SMath.Sign(v.w));
        }

    }
}
