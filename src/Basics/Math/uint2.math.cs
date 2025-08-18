#if DISABLE_DEBUG
#undef DEBUG
#endif
using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct uint2
    {
    }
    public static partial class DM // uint2
    {
        #region Abs/Sign
        [IN(LINE)] public static uint2 Abs(uint2 a) { return a; }
        [IN(LINE)] public static uint2 Sign(uint2 a) { return new uint2(Sign(a.x), Sign(a.y)); }
        #endregion

        #region Clamp/Repeat/PingPong
        /// <summary> Clamps the value between min and max. </summary>
        [IN(LINE)] public static uint2 Clamp(uint2 a, uint2 min, uint2 max) { return Max(min, Min(max, a)); }

        [IN(LINE)] public static uint2 Repeat(uint2 a, uint2 length) { return a % length; }
        [IN(LINE)] public static uint2 Repeat(uint2 a, uint2 min, uint2 max) { return Repeat(a, max - min) + min; }

        [IN(LINE)] public static uint2 PingPong(uint2 a, uint2 length) { return length - Abs(Repeat(a, length * 2) - length); }
        [IN(LINE)] public static uint2 PingPong(uint2 a, uint2 min, uint2 max) { return PingPong(a, max - min) + min; }
        #endregion

        #region All/Any
        [IN(LINE)] public static bool All(uint2 a) { return a.x != default && a.y != default; }
        [IN(LINE)] public static bool Any(uint2 a) { return a.x != default || a.y != default; }
        #endregion

        #region Min/Max/Sum
        [IN(LINE)] public static uint2 Max(uint2 a, uint2 b) { return new uint2(Max(a.x, b.x), Max(a.y, b.y)); }
        [IN(LINE)] public static uint2 AbsMax(uint2 a, uint2 b) { return new uint2(AbsMax(a.x, b.x), AbsMax(a.y, b.y)); }
        [IN(LINE)] public static uint2 Min(uint2 a, uint2 b) { return new uint2(Min(a.x, b.x), Min(a.y, b.y)); }
        [IN(LINE)] public static uint2 AbsMin(uint2 a, uint2 b) { return new uint2(AbsMin(a.x, b.x), AbsMin(a.y, b.y)); }
        [IN(LINE)] public static uint CMax(uint2 a) { return CMax(a.x, a.y); }
        [IN(LINE)] public static uint CAbsMax(uint2 a) { return CAbsMax(a.x, a.y); }
        [IN(LINE)] public static uint CMin(uint2 a) { return CMin(a.x, a.y); }
        [IN(LINE)] public static uint CAbsMin(uint2 a) { return CAbsMin(a.x, a.y); }
        [IN(LINE)] public static uint CSum(uint2 a) { return a.x + a.y; }
        #endregion

        #region Pow2
        [IN(LINE)] public static uint2 CeilPow2(uint2 value) { return new uint2(CeilPow2(value.x), CeilPow2(value.y)); }
        [IN(LINE)] public static uint2 FloorPow2(uint2 value) { return new uint2(FloorPow2(value.x), FloorPow2(value.y)); }
        [IN(LINE)] public static uint2 RoundPow2(uint2 value) { return new uint2(RoundPow2(value.x), RoundPow2(value.y)); }
        [IN(LINE)] public static bool2 IsPow2(uint2 value) { return new bool2(IsPow2(value.x), IsPow2(value.y)); }
        #endregion

        #region Other
        //Length - float
        //Distance - float
        //Sqrt - float
        [IN(LINE)] public static uint2 LengthSqr(uint2 a) { return Sqr(a); }
        [IN(LINE)] public static uint2 DistanceSqr(uint2 a, uint2 b) { return Sqr(b - a); }
        [IN(LINE)] public static uint2 Dot(uint2 a, uint2 b) { return a * b; }
        [IN(LINE)] public static uint2 Sqr(uint2 a) { return a * a; }
        [IN(LINE)] public static uint2 Pow(uint2 a, uint2 b) { return new uint2(Pow(a.x, b.x), Pow(a.y, b.y)); }
        [IN(LINE)] public static uint2 Select(uint2 falseValue, uint2 trueValue, bool2 test) { return test ? trueValue : falseValue; }
        #endregion


        #region Hash
        [IN(LINE)] public static uint UHash(uint2 v) { return UHash<uint2>(v); }
        [IN(LINE)] public static int Hash(uint2 v) { return unchecked((int)UHash(v)); }
        #endregion
    }

    public static partial class DMBits // uint2
    {
        #region Rnd
        [IN(LINE)] public static uint2 NextXorShiftState(uint2 a) { unchecked { return new uint2(NextXorShiftState(a.x), NextXorShiftState(a.y)); } }
        #endregion

        #region Other
        [IN(LINE)] public static int2 Count(uint2 a) { unchecked { return new int2(Count(a.x), Count(a.y)); } }
        [IN(LINE)] public static uint2 Reverse(uint2 a) { unchecked { return new uint2(Reverse(a.x), Reverse(a.y)); } }
        #endregion
    }
}