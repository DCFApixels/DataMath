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
    public partial struct int3 : IBoolVector
    {
        public bool all { [IN(LINE)] get { return x != 0 & y != 0 & z != 0; } }
        public bool any { [IN(LINE)] get { return x != 0 | y != 0 | z != 0; } }
    }
    public static partial class DM
    {
        [IN(LINE)]
        public static int3 one_minus(int3 v) => 1 - v;
        [IN(LINE)]
        public static int3 abs(int3 v)
        {
            return new int3(SMathF.Abs(v.x), SMathF.Abs(v.y), SMathF.Abs(v.z));
        }
        [IN(LINE)]
        public static int3 sign(int3 v)
        {
            return new int3(SMath.Sign(v.x), SMath.Sign(v.y), SMath.Sign(v.z));
        }

    }
}
