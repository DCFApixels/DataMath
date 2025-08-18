using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct int3
    {
    }
    public static partial class DM // int3
    {
        #region Abs/Sign
        [IN(LINE)] public static int3 Abs(int3 a) { return a; }
        [IN(LINE)] public static int3 Sign(int3 a) { return new int3(Sign(a.x), Sign(a.y), Sign(a.z)); }
        #endregion

        #region Clamp/Repeat/PingPong
        /// <summary> Clamps the value between min and max. </summary>
        [IN(LINE)] public static int3 Clamp(int3 a, int3 min, int3 max) { return Max(min, Min(max, a)); }

        [IN(LINE)] public static int3 Repeat(int3 a, int3 length) { return a % length; }
        [IN(LINE)] public static int3 Repeat(int3 a, int3 min, int3 max) { return Repeat(a, max - min) + min; }

        [IN(LINE)] public static int3 PingPong(int3 a, int3 length) { return length - Abs(Repeat(a, length * 2) - length); }
        [IN(LINE)] public static int3 PingPong(int3 a, int3 min, int3 max) { return PingPong(a, max - min) + min; }
        #endregion

        #region All/Any
        [IN(LINE)] public static bool All(int3 a) { return a.x != default && a.y != default && a.z != default; }
        [IN(LINE)] public static bool Any(int3 a) { return a.x != default || a.y != default || a.z != default; }
        #endregion

        #region Min/Max/Sum
        [IN(LINE)] public static int3 Max(int3 a, int3 b) { return new int3(Max(a.x, b.x), Max(a.y, b.y), Max(a.z, b.z)); }
        [IN(LINE)] public static int3 AbsMax(int3 a, int3 b) { return new int3(AbsMax(a.x, b.x), AbsMax(a.y, b.y), AbsMax(a.z, b.z)); }
        [IN(LINE)] public static int3 Min(int3 a, int3 b) { return new int3(Min(a.x, b.x), Min(a.y, b.y), Min(a.z, b.z)); }
        [IN(LINE)] public static int3 AbsMin(int3 a, int3 b) { return new int3(AbsMin(a.x, b.x), AbsMin(a.y, b.y), AbsMin(a.z, b.z)); }
        [IN(LINE)] public static int CMax(int3 a) { return CMax(a.x, a.y, a.z); }
        [IN(LINE)] public static int CAbsMax(int3 a) { return CAbsMax(a.x, a.y, a.z); }
        [IN(LINE)] public static int CMin(int3 a) { return CMin(a.x, a.y, a.z); }
        [IN(LINE)] public static int CAbsMin(int3 a) { return CAbsMin(a.x, a.y, a.z); }
        [IN(LINE)] public static int CSum(int3 a) { return a.x + a.y + a.z; }
        #endregion

        #region Pow2
        [IN(LINE)] public static int3 CeilPow2(int3 value) { return new int3(CeilPow2(value.x), CeilPow2(value.y), CeilPow2(value.z)); }
        [IN(LINE)] public static int3 FloorPow2(int3 value) { return new int3(FloorPow2(value.x), FloorPow2(value.y), FloorPow2(value.z)); }
        [IN(LINE)] public static int3 RoundPow2(int3 value) { return new int3(RoundPow2(value.x), RoundPow2(value.y), RoundPow2(value.z)); }
        [IN(LINE)] public static bool3 IsPow2(int3 value) { return new bool3(IsPow2(value.x), IsPow2(value.y), IsPow2(value.z)); }
        #endregion

        #region Other
        //Length - float
        //Distance - float
        //Sqrt - float
        [IN(LINE)] public static int3 LengthSqr(int3 a) { return Sqr(a); }
        [IN(LINE)] public static int3 DistanceSqr(int3 a, int3 b) { return Sqr(b - a); }
        [IN(LINE)] public static int3 Sqr(int3 a) { return a * a; }
        [IN(LINE)] public static int3 Pow(int3 a, int3 b) { return new int3(Pow(a.x, b.x), Pow(a.y, b.y), Pow(a.z, b.z)); }
        [IN(LINE)] public static int3 Dot(int3 a, int3 b) { return a * b; }
        [IN(LINE)] public static int3 Select(int3 falseValue, int3 trueValue, bool2 test) { return test ? trueValue : falseValue; }
        #endregion


        #region Hash
        [IN(LINE)] public static uint UHash(int3 v) { return UHash<int3>(v); }
        [IN(LINE)] public static int Hash(int3 v) { return unchecked((int)UHash(v)); }
        #endregion

        #region Specific
        [IN(LINE)] public static int3 Cross(int3 a, int3 b) { return (a * b.yzx - a.yzx * b).yzx; }
        #endregion
    }

    public static partial class DMBits // int3
    {
        #region Rnd
        [IN(LINE)] public static int3 NextXorShiftState(int3 a) { unchecked { return new int3(NextXorShiftState(a.x), NextXorShiftState(a.y), NextXorShiftState(a.z)); } }
        #endregion

        #region Other
        [IN(LINE)] public static int3 Count(int3 a) { unchecked { return new int3(Count(a.x), Count(a.y), Count(a.z)); } }
        [IN(LINE)] public static int3 Reverse(int3 a) { unchecked { return new int3(Reverse(a.x), Reverse(a.y), Reverse(a.z)); } }
        #endregion
    }
}