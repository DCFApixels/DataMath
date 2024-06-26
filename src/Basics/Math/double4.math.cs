using System.Runtime.CompilerServices;
using SMath = System.Math;

namespace DCFApixels.DataMath
{
    public partial struct double4
    {

    }
    public static partial class math
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 one_minus(double4 v) => 1d - v;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 abs(double4 v)
        {
            return new double4(SMath.Abs(v.x), SMath.Abs(v.y), SMath.Abs(v.z), SMath.Abs(v.w));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 sign(double4 v)
        {
            return new int4(SMath.Sign(v.x), SMath.Sign(v.y), SMath.Sign(v.z), SMath.Sign(v.w));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 round(double4 v)
        {
            return new double4(SMath.Round(v.x), SMath.Round(v.y), SMath.Round(v.z), SMath.Round(v.w));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 round2int(double4 v)
        {
            return new int4((int)SMath.Round(v.x), (int)SMath.Round(v.y), (int)SMath.Round(v.z), (int)SMath.Round(v.w));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 floor(double4 v)
        {
            return new double4(SMath.Floor(v.x), SMath.Floor(v.y), SMath.Floor(v.z), SMath.Floor(v.w));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 floor2int(double4 v)
        {
            return new int4((int)SMath.Floor(v.x), (int)SMath.Floor(v.y), (int)SMath.Floor(v.z), (int)SMath.Floor(v.w));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 ceil(double4 v)
        {
            return new double4(SMath.Ceiling(v.x), SMath.Ceiling(v.y), SMath.Ceiling(v.z), SMath.Ceiling(v.w));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int4 ceil2int(double4 v)
        {
            return new int4((int)SMath.Ceiling(v.x), (int)SMath.Ceiling(v.y), (int)SMath.Ceiling(v.z), (int)SMath.Ceiling(v.w));
        }

    }
}
