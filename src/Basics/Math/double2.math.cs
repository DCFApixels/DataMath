using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;
using SMath = System.Math;

namespace DCFApixels.DataMath
{
    public partial struct double2
    {
        public bool all { [IN(LINE)] get => x != 0 & y != 0; }
        public bool any { [IN(LINE)] get => x != 0 | y != 0; }
    }
    public static partial class DM
    {
        [IN(LINE)]
        public static double2 one_minus(double2 v) => 1d - v;
        [IN(LINE)]
        public static double2 abs(double2 v)
        {
            return new double2(SMath.Abs(v.x), SMath.Abs(v.y));
        }
        [IN(LINE)]
        public static int2 sign(double2 v)
        {
            return new int2(SMath.Sign(v.x), SMath.Sign(v.y));
        }

        [IN(LINE)]
        public static double2 round(double2 v)
        {
            return new double2(SMath.Round(v.x), SMath.Round(v.y));
        }
        [IN(LINE)]
        public static int2 round2int(double2 v)
        {
            return new int2((int)SMath.Round(v.x), (int)SMath.Round(v.y));
        }
        [IN(LINE)]
        public static double2 floor(double2 v)
        {
            return new double2(SMath.Floor(v.x), SMath.Floor(v.y));
        }
        [IN(LINE)]
        public static int2 floor2int(double2 v)
        {
            return new int2((int)SMath.Floor(v.x), (int)SMath.Floor(v.y));
        }
        [IN(LINE)]
        public static double2 ceil(double2 v)
        {
            return new double2(SMath.Ceiling(v.x), SMath.Ceiling(v.y));
        }
        [IN(LINE)]
        public static int2 ceil2int(double2 v)
        {
            return new int2((int)SMath.Ceiling(v.x), (int)SMath.Ceiling(v.y));
        }

    }
}
