using System.Runtime.CompilerServices;
using SMath = System.Math;
#if NETCORE || UNITY_5_3_OR_NEWER
using SMathF = System.MathF;
#else
using SMathF = DCFApixels.DataMath.Internal.MathF;
#endif

namespace DCFApixels.DataMath
{
    public partial struct int4
    {

    }
    public static partial class math
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 one_minus(int4 v) => 1 - v;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 abs(int4 v)
        {
            return new int4(SMathF.Abs(v.x), SMathF.Abs(v.y), SMathF.Abs(v.z), SMathF.Abs(v.w));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 sign(int4 v)
        {
            return new int4(SMath.Sign(v.x), SMath.Sign(v.y), SMath.Sign(v.z), SMath.Sign(v.w));
        }

    }
}
