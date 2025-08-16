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
    public partial struct uint3
    {
    }
    public static partial class DM // uint3
    {
        #region Hash
        [IN(LINE)] public static uint UHash(uint3 v) { return UHash<uint3>(v); }
        [IN(LINE)] public static int Hash(uint3 v) { return unchecked((int)UHash(v)); }
        #endregion

        [IN(LINE)]
        public static uint3 one_minus(uint3 v) => 1u - v;
        [IN(LINE)]
        public static uint3 abs(uint3 v)
        {
            return new uint3(SMathF.Abs(v.x), SMathF.Abs(v.y), SMathF.Abs(v.z));
        }
        [IN(LINE)]
        public static int3 sign(uint3 v)
        {
            return new int3(SMath.Sign(v.x), SMath.Sign(v.y), SMath.Sign(v.z));
        }

    }
}
