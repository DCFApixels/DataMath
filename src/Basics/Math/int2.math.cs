using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct int2
    {
    }
    public static partial class DM // int2
    {
        #region Abs/Sign
        [IN(LINE)] public static int2 Abs(int2 a) { return a; }
        [IN(LINE)] public static int2 Sign(int2 a) { return new int2(Sign(a.x), Sign(a.y)); }
        #endregion

        #region Clamp/Repeat/PingPong
        /// <summary> Clamps the value between min and max. </summary>
        [IN(LINE)] public static int2 Clamp(int2 a, int2 min, int2 max) { return Max(min, Min(max, a)); }

        [IN(LINE)] public static int2 Repeat(int2 a, int2 length) { return a % length; }
        [IN(LINE)] public static int2 Repeat(int2 a, int2 min, int2 max) { return Repeat(a, max - min) + min; }

        [IN(LINE)] public static int2 PingPong(int2 a, int2 length) { return length - Abs(Repeat(a, length * 2) - length); }
        [IN(LINE)] public static int2 PingPong(int2 a, int2 min, int2 max) { return PingPong(a, max - min) + min; }
        #endregion

        #region All/Any
        [IN(LINE)] public static bool All(int2 a) { return a.x != default && a.y != default; }
        [IN(LINE)] public static bool Any(int2 a) { return a.x != default || a.y != default; }
        #endregion

        #region Min/Max/Sum
        [IN(LINE)] public static int2 Max(int2 a, int2 b) { return new int2(Max(a.x, b.x), Max(a.y, b.y)); }
        [IN(LINE)] public static int2 AbsMax(int2 a, int2 b) { return new int2(AbsMax(a.x, b.x), AbsMax(a.y, b.y)); }
        [IN(LINE)] public static int2 Min(int2 a, int2 b) { return new int2(Min(a.x, b.x), Min(a.y, b.y)); }
        [IN(LINE)] public static int2 AbsMin(int2 a, int2 b) { return new int2(AbsMin(a.x, b.x), AbsMin(a.y, b.y)); }
        [IN(LINE)] public static int CMax(int2 a) { return CMax(a.x, a.y); }
        [IN(LINE)] public static int CAbsMax(int2 a) { return CAbsMax(a.x, a.y); }
        [IN(LINE)] public static int CMin(int2 a) { return CMin(a.x, a.y); }
        [IN(LINE)] public static int CAbsMin(int2 a) { return CAbsMin(a.x, a.y); }
        [IN(LINE)] public static int CSum(int2 a) { return a.x + a.y; }
        #endregion

        #region Pow2
        [IN(LINE)] public static int2 CeilPow2(int2 value) { return new int2(CeilPow2(value.x), CeilPow2(value.y)); }
        [IN(LINE)] public static int2 FloorPow2(int2 value) { return new int2(FloorPow2(value.x), FloorPow2(value.y)); }
        [IN(LINE)] public static int2 RoundPow2(int2 value) { return new int2(RoundPow2(value.x), RoundPow2(value.y)); }
        [IN(LINE)] public static bool2 IsPow2(int2 value) { return new bool2(IsPow2(value.x), IsPow2(value.y)); }
        #endregion

        #region Other
        //Length - float
        //Distance - float
        //Sqrt - float
        [IN(LINE)] public static int2 LengthSqr(int2 a) { return Sqr(a); }
        [IN(LINE)] public static int2 DistanceSqr(int2 a, int2 b) { return Sqr(b - a); }
        [IN(LINE)] public static int2 Sqr(int2 a) { return a * a; }
        [IN(LINE)] public static int2 Pow(int2 a, int2 b) { return new int2(Pow(a.x, b.x), Pow(a.y, b.y)); }
        [IN(LINE)] public static int2 Dot(int2 a, int2 b) { return a * b; }
        [IN(LINE)] public static int2 Select(int2 falseValue, int2 trueValue, bool2 test) { return test ? trueValue : falseValue; }
        #endregion


        #region Hash
        [IN(LINE)] public static uint UHash(int2 v) { return UHash<int2>(v); }
        [IN(LINE)] public static int Hash(int2 v) { return unchecked((int)UHash(v)); }
        #endregion
    }

    public static partial class DMBits // int2
    {
        #region Rnd
        [IN(LINE)] public static int2 NextXorShiftState(int2 a) { unchecked { return new int2(NextXorShiftState(a.x), NextXorShiftState(a.y)); } }
        #endregion

        #region Other
        [IN(LINE)] public static int2 Count(int2 a) { unchecked { return new int2(Count(a.x), Count(a.y)); } }
        [IN(LINE)] public static int2 Reverse(int2 a) { unchecked { return new int2(Reverse(a.x), Reverse(a.y)); } }
        #endregion
    }
}