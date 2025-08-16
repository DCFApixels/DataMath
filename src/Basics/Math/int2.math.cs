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
    public partial struct int2
    {
    }
    public static partial class DM // int2
    {
        #region Hash
        [IN(LINE)] public static uint UHash(int2 v) { return unchecked((uint)Hash(v)); }
        [IN(LINE)] public static int Hash(int2 v) { return Hash<int2>(v); }
        #endregion

        [IN(LINE)]
        public static int2 one_minus(int2 v) => 1 - v;
        [IN(LINE)]
        public static int2 abs(int2 v)
        {
            return new int2(SMathF.Abs(v.x), SMathF.Abs(v.y));
        }
        [IN(LINE)]
        public static int2 sign(int2 v)
        {
            return new int2(SMath.Sign(v.x), SMath.Sign(v.y));
        }

    }
}
