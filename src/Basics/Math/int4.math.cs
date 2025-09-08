#pragma warning disable CS8981
#if DISABLE_DEBUG
#undef DEBUG
#endif
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct int4
    {
        #region Length/Normalized
        public float Length { [IN(LINE)] get { return DM.Length(this); } }
        public int LengthSqr { [IN(LINE)] get { return DM.LengthSqr(this); } }
        public float4 Normalized { [IN(LINE)] get { return DM.Normalize(this); } }
        #endregion
    }
    public static partial class DM // int4
    {
        #region Abs/Sign
        [IN(LINE)] public static int4 Abs(int4 a) { return a; }
        [IN(LINE)] public static int4 Sign(int4 a) { return new int4(Sign(a.x), Sign(a.y), Sign(a.z), Sign(a.w)); }
        #endregion

        #region Clamp/Repeat/PingPong
        /// <summary> Clamps the value between min and max. </summary>
        [IN(LINE)] public static int4 Clamp(int4 a, int4 min, int4 max) { return Max(min, Min(max, a)); }

        [IN(LINE)] public static int4 Repeat(int4 a, int4 length) { return a % length; }
        [IN(LINE)] public static int4 Repeat(int4 a, int4 min, int4 max) { return Repeat(a, max - min) + min; }

        [IN(LINE)] public static int4 PingPong(int4 a, int4 length) { return length - Abs(Repeat(a, length * 2) - length); }
        [IN(LINE)] public static int4 PingPong(int4 a, int4 min, int4 max) { return PingPong(a, max - min) + min; }
        #endregion

        #region All/Any
        [IN(LINE)] public static bool All(int4 a) { return a.x != default && a.y != default && a.z != default && a.w != default; }
        [IN(LINE)] public static bool Any(int4 a) { return a.x != default || a.y != default || a.z != default || a.w != default; }
        #endregion

        #region Min/Max/Sum
        [IN(LINE)] public static int4 Max(int4 a, int4 b) { return new int4(Max(a.x, b.x), Max(a.y, b.y), Max(a.z, b.z), Max(a.w, b.w)); }
        [IN(LINE)] public static int4 AbsMax(int4 a, int4 b) { return new int4(AbsMax(a.x, b.x), AbsMax(a.y, b.y), AbsMax(a.z, b.z), AbsMax(a.w, b.w)); }
        [IN(LINE)] public static int4 Min(int4 a, int4 b) { return new int4(Min(a.x, b.x), Min(a.y, b.y), Min(a.z, b.z), Min(a.w, b.w)); }
        [IN(LINE)] public static int4 AbsMin(int4 a, int4 b) { return new int4(AbsMin(a.x, b.x), AbsMin(a.y, b.y), AbsMin(a.z, b.z), AbsMin(a.w, b.w)); }
        [IN(LINE)] public static int CMax(int4 a) { return CMax(a.x, a.y, a.z, a.w); }
        [IN(LINE)] public static int CAbsMax(int4 a) { return CAbsMax(a.x, a.y, a.z, a.w); }
        [IN(LINE)] public static int CMin(int4 a) { return CMin(a.x, a.y, a.z, a.w); }
        [IN(LINE)] public static int CAbsMin(int4 a) { return CAbsMin(a.x, a.y, a.z, a.w); }
        [IN(LINE)] public static int CSum(int4 a) { return (a.x + a.y) + (a.z + a.w); }
        #endregion

        #region Pow2
        [IN(LINE)] public static int4 CeilPow2(int4 value) { return new int4(CeilPow2(value.x), CeilPow2(value.y), CeilPow2(value.z), CeilPow2(value.w)); }
        [IN(LINE)] public static int4 FloorPow2(int4 value) { return new int4(FloorPow2(value.x), FloorPow2(value.y), FloorPow2(value.z), FloorPow2(value.w)); }
        [IN(LINE)] public static int4 RoundPow2(int4 value) { return new int4(RoundPow2(value.x), RoundPow2(value.y), RoundPow2(value.z), RoundPow2(value.w)); }
        [IN(LINE)] public static bool4 IsPow2(int4 value) { return new bool4(IsPow2(value.x), IsPow2(value.y), IsPow2(value.z), IsPow2(value.w)); }
        #endregion

        #region Length/Normalize/Distance
        //Length - float
        //Distance - float
        [IN(LINE)] public static int LengthSqr(int4 a) { return Dot(a, a); }
        [IN(LINE)] public static int4 DistanceSqr(int4 a, int4 b) { return Sqr(b - a); }
        #endregion

        #region Other
        //Sqrt - float
        [IN(LINE)] public static int Dot(int4 a, int4 b) { return a.x * b.x + a.y * b.y + a.z * b.z + a.w * b.w; }
        [IN(LINE)] public static int4 Sqr(int4 a) { return a * a; }
        [IN(LINE)] public static int4 Pow(int4 a, int4 b) { return new int4(Pow(a.x, b.x), Pow(a.y, b.y), Pow(a.z, b.z), Pow(a.w, b.w)); }
        [IN(LINE)] public static int4 Select(int4 falseValue, int4 trueValue, bool4 test) { return new int4(test.x ? trueValue.x : falseValue.x, test.y ? trueValue.y : falseValue.y, test.z ? trueValue.z : falseValue.z, test.w ? trueValue.w : falseValue.w); }
        [IN(LINE)] public static int4 Select(int4 falseValue, int4 trueValue, bool test) { return test ? trueValue : falseValue; }
        #endregion


        #region Hash
        [IN(LINE)] public static uint UHash(int4 v) { return UHash<int4>(v); }
        [IN(LINE)] public static int Hash(int4 v) { return unchecked((int)UHash(v)); }
        #endregion
    }

    public static partial class DMBits // int4
    {
        #region Rnd
        [IN(LINE)] public static int4 NextXorShiftState(int4 a) { unchecked { return new int4(NextXorShiftState(a.x), NextXorShiftState(a.y), NextXorShiftState(a.z), NextXorShiftState(a.w)); } }
        #endregion

        #region Other
        [IN(LINE)] public static int4 Count(int4 a) { unchecked { return new int4(Count(a.x), Count(a.y), Count(a.z), Count(a.w)); } }
        [IN(LINE)] public static int4 Reverse(int4 a) { unchecked { return new int4(Reverse(a.x), Reverse(a.y), Reverse(a.z), Reverse(a.w)); } }
        #endregion
    }
}