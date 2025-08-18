using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct uint3
    {
    }
    public static partial class DM // uint3
    {
        #region Abs/Sign
        [IN(LINE)] public static uint3 Abs(uint3 a) { return a; }
        [IN(LINE)] public static uint3 Sign(uint3 a) { return new uint3(Sign(a.x), Sign(a.y), Sign(a.z)); }
        #endregion

        #region Clamp/Repeat/PingPong
        /// <summary> Clamps the value between min and max. </summary>
        [IN(LINE)] public static uint3 Clamp(uint3 a, uint3 min, uint3 max) { return Max(min, Min(max, a)); }

        [IN(LINE)] public static uint3 Repeat(uint3 a, uint3 length) { return a % length; }
        [IN(LINE)] public static uint3 Repeat(uint3 a, uint3 min, uint3 max) { return Repeat(a, max - min) + min; }

        [IN(LINE)] public static uint3 PingPong(uint3 a, uint3 length) { return length - Abs(Repeat(a, length * 2) - length); }
        [IN(LINE)] public static uint3 PingPong(uint3 a, uint3 min, uint3 max) { return PingPong(a, max - min) + min; }
        #endregion

        #region All/Any
        [IN(LINE)] public static bool All(uint3 a) { return a.x != default && a.y != default && a.z != default; }
        [IN(LINE)] public static bool Any(uint3 a) { return a.x != default || a.y != default || a.z != default; }
        #endregion

        #region Min/Max/Sum
        [IN(LINE)] public static uint3 Max(uint3 a, uint3 b) { return new uint3(Max(a.x, b.x), Max(a.y, b.y), Max(a.z, b.z)); }
        [IN(LINE)] public static uint3 AbsMax(uint3 a, uint3 b) { return new uint3(AbsMax(a.x, b.x), AbsMax(a.y, b.y), AbsMax(a.z, b.z)); }
        [IN(LINE)] public static uint3 Min(uint3 a, uint3 b) { return new uint3(Min(a.x, b.x), Min(a.y, b.y), Min(a.z, b.z)); }
        [IN(LINE)] public static uint3 AbsMin(uint3 a, uint3 b) { return new uint3(AbsMin(a.x, b.x), AbsMin(a.y, b.y), AbsMin(a.z, b.z)); }
        [IN(LINE)] public static uint CMax(uint3 a) { return CMax(a.x, a.y, a.z); }
        [IN(LINE)] public static uint CAbsMax(uint3 a) { return CAbsMax(a.x, a.y, a.z); }
        [IN(LINE)] public static uint CMin(uint3 a) { return CMin(a.x, a.y, a.z); }
        [IN(LINE)] public static uint CAbsMin(uint3 a) { return CAbsMin(a.x, a.y, a.z); }
        [IN(LINE)] public static uint CSum(uint3 a) { return a.x + a.y + a.z; }
        #endregion

        #region Pow2
        [IN(LINE)] public static uint3 CeilPow2(uint3 value) { return new uint3(CeilPow2(value.x), CeilPow2(value.y), CeilPow2(value.z)); }
        [IN(LINE)] public static uint3 FloorPow2(uint3 value) { return new uint3(FloorPow2(value.x), FloorPow2(value.y), FloorPow2(value.z)); }
        [IN(LINE)] public static uint3 RoundPow2(uint3 value) { return new uint3(RoundPow2(value.x), RoundPow2(value.y), RoundPow2(value.z)); }
        [IN(LINE)] public static bool3 IsPow2(uint3 value) { return new bool3(IsPow2(value.x), IsPow2(value.y), IsPow2(value.z)); }
        #endregion

        #region Other
        //Length - float
        //Distance - float
        //Sqrt - float
        [IN(LINE)] public static uint3 LengthSqr(uint3 a) { return Sqr(a); }
        [IN(LINE)] public static uint3 DistanceSqr(uint3 a, uint3 b) { return Sqr(b - a); }
        [IN(LINE)] public static uint3 Sqr(uint3 a) { return a * a; }
        [IN(LINE)] public static uint3 Pow(uint3 a, uint3 b) { return new uint3(Pow(a.x, b.x), Pow(a.y, b.y), Pow(a.z, b.z)); }
        [IN(LINE)] public static uint3 Dot(uint3 a, uint3 b) { return a * b; }
        [IN(LINE)] public static uint3 Select(uint3 falseValue, uint3 trueValue, bool2 test) { return test ? trueValue : falseValue; }
        #endregion


        #region Hash
        [IN(LINE)] public static uint UHash(uint3 v) { return UHash<uint3>(v); }
        [IN(LINE)] public static int Hash(uint3 v) { return unchecked((int)UHash(v)); }
        #endregion
    }

    public static partial class DMBits // uint3
    {
        #region Rnd
        [IN(LINE)] public static uint3 NextXorShiftState(uint3 a) { unchecked { return new uint3(NextXorShiftState(a.x), NextXorShiftState(a.y), NextXorShiftState(a.z)); } }
        #endregion

        #region Other
        [IN(LINE)] public static int3 Count(uint3 a) { unchecked { return new int3(Count(a.x), Count(a.y), Count(a.z)); } }
        [IN(LINE)] public static uint3 Reverse(uint3 a) { unchecked { return new uint3(Reverse(a.x), Reverse(a.y), Reverse(a.z)); } }
        #endregion
    }
}