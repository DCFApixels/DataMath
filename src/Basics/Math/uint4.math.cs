#if DISABLE_DEBUG
#undef DEBUG
#endif
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct uint4
    {
    }
    public static partial class DM // uint4
    {
        #region Abs/Sign
        [IN(LINE)] public static uint4 Abs(uint4 a) { return a; }
        [IN(LINE)] public static uint4 Sign(uint4 a) { return new uint4(Sign(a.x), Sign(a.y), Sign(a.z), Sign(a.w)); }
        #endregion

        #region Clamp/Repeat/PingPong
        /// <summary> Clamps the value between min and max. </summary>
        [IN(LINE)] public static uint4 Clamp(uint4 a, uint4 min, uint4 max) { return Max(min, Min(max, a)); }

        [IN(LINE)] public static uint4 Repeat(uint4 a, uint4 length) { return a % length; }
        [IN(LINE)] public static uint4 Repeat(uint4 a, uint4 min, uint4 max) { return Repeat(a, max - min) + min; }

        [IN(LINE)] public static uint4 PingPong(uint4 a, uint4 length) { return length - Abs(Repeat(a, length * 2) - length); }
        [IN(LINE)] public static uint4 PingPong(uint4 a, uint4 min, uint4 max) { return PingPong(a, max - min) + min; }
        #endregion

        #region All/Any
        [IN(LINE)] public static bool All(uint4 a) { return a.x != default && a.y != default && a.z != default && a.w != default; }
        [IN(LINE)] public static bool Any(uint4 a) { return a.x != default || a.y != default || a.z != default || a.w != default; }
        #endregion

        #region Min/Max/Sum
        [IN(LINE)] public static uint4 Max(uint4 a, uint4 b) { return new uint4(Max(a.x, b.x), Max(a.y, b.y), Max(a.z, b.z), Max(a.w, b.w)); }
        [IN(LINE)] public static uint4 AbsMax(uint4 a, uint4 b) { return new uint4(AbsMax(a.x, b.x), AbsMax(a.y, b.y), AbsMax(a.z, b.z), AbsMax(a.w, b.w)); }
        [IN(LINE)] public static uint4 Min(uint4 a, uint4 b) { return new uint4(Min(a.x, b.x), Min(a.y, b.y), Min(a.z, b.z), Min(a.w, b.w)); }
        [IN(LINE)] public static uint4 AbsMin(uint4 a, uint4 b) { return new uint4(AbsMin(a.x, b.x), AbsMin(a.y, b.y), AbsMin(a.z, b.z), AbsMin(a.w, b.w)); }
        [IN(LINE)] public static uint CMax(uint4 a) { return CMax(a.x, a.y, a.z, a.w); }
        [IN(LINE)] public static uint CAbsMax(uint4 a) { return CAbsMax(a.x, a.y, a.z, a.w); }
        [IN(LINE)] public static uint CMin(uint4 a) { return CMin(a.x, a.y, a.z, a.w); }
        [IN(LINE)] public static uint CAbsMin(uint4 a) { return CAbsMin(a.x, a.y, a.z, a.w); }
        [IN(LINE)] public static uint CSum(uint4 a) { return (a.x + a.y) + (a.z + a.w); }
        #endregion

        #region Pow2
        [IN(LINE)] public static uint4 CeilPow2(uint4 value) { return new uint4(CeilPow2(value.x), CeilPow2(value.y), CeilPow2(value.z), CeilPow2(value.w)); }
        [IN(LINE)] public static uint4 FloorPow2(uint4 value) { return new uint4(FloorPow2(value.x), FloorPow2(value.y), FloorPow2(value.z), FloorPow2(value.w)); }
        [IN(LINE)] public static uint4 RoundPow2(uint4 value) { return new uint4(RoundPow2(value.x), RoundPow2(value.y), RoundPow2(value.z), RoundPow2(value.w)); }
        [IN(LINE)] public static bool4 IsPow2(uint4 value) { return new bool4(IsPow2(value.x), IsPow2(value.y), IsPow2(value.z), IsPow2(value.w)); }
        #endregion

        #region Length/Normalize/Distance
        //Length - float
        //Distance - float
        [IN(LINE)] public static uint4 LengthSqr(uint4 a) { return Sqr(a); }
        [IN(LINE)] public static uint4 DistanceSqr(uint4 a, uint4 b) { return Sqr(b - a); }
        #endregion

        #region Other
        //Sqrt - float
        [IN(LINE)] public static uint4 Dot(uint4 a, uint4 b) { return a * b; }
        [IN(LINE)] public static uint4 Sqr(uint4 a) { return a * a; }
        [IN(LINE)] public static uint4 Pow(uint4 a, uint4 b) { return new uint4(Pow(a.x, b.x), Pow(a.y, b.y), Pow(a.z, b.z), Pow(a.w, b.w)); }
        [IN(LINE)] public static uint4 Select(uint4 falseValue, uint4 trueValue, bool4 test) { return test ? trueValue : falseValue; }
        #endregion


        #region Hash
        [IN(LINE)] public static uint UHash(uint4 v) { return UHash<uint4>(v); }
        [IN(LINE)] public static int Hash(uint4 v) { return unchecked((int)UHash(v)); }
        #endregion
    }

    public static partial class DMBits // uint4
    {
        #region Rnd
        [IN(LINE)] public static uint4 NextXorShiftState(uint4 a) { unchecked { return new uint4(NextXorShiftState(a.x), NextXorShiftState(a.y), NextXorShiftState(a.z), NextXorShiftState(a.w)); } }
        #endregion

        #region Other
        [IN(LINE)] public static int4 Count(uint4 a) { unchecked { return new int4(Count(a.x), Count(a.y), Count(a.z), Count(a.w)); } }
        [IN(LINE)] public static uint4 Reverse(uint4 a) { unchecked { return new uint4(Reverse(a.x), Reverse(a.y), Reverse(a.z), Reverse(a.w)); } }
        #endregion
    }
}