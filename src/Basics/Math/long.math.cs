#if DISABLE_DEBUG
#undef DEBUG
#endif
using DCFApixels.DataMath.Internal;
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public static partial class DM // long self
    {

    }
    public static partial class DM // long
    {
        #region Abs/Sign
        [IN(LINE)] public static long Abs(long a) { return InternalMath.Abs(a); }
        [IN(LINE)] public static long Sign(long a) { return (a > 0 ? 1 : 0) - (a < 0 ? 1 : 0); }
        #endregion

        #region Clamp/Repeat/PingPong
        /// <summary> Clamps the value between min and max. </summary>
        [IN(LINE)]
        public static long Clamp(long a, long min, long max)
        {
            if (a < min) { return min; }
            if (a > max) { return max; }
            return a;
        }

        [IN(LINE)]
        public static long Repeat(long a, long length)
        {
            if (length < 0) { return 0; }
            long mod = a % length;
            return mod < 0 ? mod + length : mod;
        }
        [IN(LINE)] public static long Repeat(long a, long min, long max) { return Repeat(a, max - min) + min; }

        [IN(LINE)] public static long PingPong(long a, long length) { return length - Abs(Repeat(a, length * 2) - length); }
        [IN(LINE)] public static long PingPong(long a, long min, long max) { return PingPong(a, max - min) + min; }
        #endregion

        #region All/Any
        [IN(LINE)] public static bool All(long a) { return a != default; }
        [IN(LINE)] public static bool Any(long a) { return a != default; }
        #endregion

        #region Min/Max/Sum
        [IN(LINE)] public static long Max(long a, long b) { return a > b ? a : b; }
        [IN(LINE)] public static long AbsMax(long a, long b) { return InternalMath.Abs(a) > InternalMath.Abs(b) ? a : b; }
        [IN(LINE)] public static long Min(long a, long b) { return a < b ? a : b; }
        [IN(LINE)] public static long AbsMin(long a, long b) { return InternalMath.Abs(a) < InternalMath.Abs(b) ? a : b; }
        [IN(LINE)] public static long CMax(long a) { return a; }
        [IN(LINE)] public static long CAbsMax(long a) { return a; }
        [IN(LINE)] public static long CMin(long a) { return a; }
        [IN(LINE)] public static long CAbsMin(long a) { return a; }
        [IN(LINE)] public static long CSum(long a) { return a; }
        #endregion

        #region Pow2
        [IN(LINE)] public static long CeilPow2(long value) { unchecked { return (long)CeilPow2((ulong)value); } }
        [IN(LINE)] public static long FloorPow2(long value) { unchecked { return (long)FloorPow2((ulong)value); } }
        [IN(LINE)] public static long RoundPow2(long value) { unchecked { return (long)RoundPow2((ulong)value); } }
        [IN(LINE)] public static bool IsPow2(long value) { return (value & (value - 1)) == 0; }
        #endregion

        #region Other
        //Length - float
        //Distance - float
        //Sqrt - float
        [IN(LINE)] public static long LengthSqr(long a) { return Sqr(a); }
        [IN(LINE)] public static long DistanceSqr(long a, long b) { return Sqr(b - a); }
        [IN(LINE)] public static long Dot(long a, long b) { return a * b; }
        [IN(LINE)] public static long Sqr(long a) { return a * a; }
        [IN(LINE)] public static long Pow(long a, long b) { return InternalMath.Pow(a, b); }
        [IN(LINE)] public static long Select(long falseValue, long trueValue, bool test) { return test ? trueValue : falseValue; }
        #endregion


        #region Hash
        [IN(LINE)] public static uint UHash(long v) { return unchecked((uint)Hash(v)); }
        [IN(LINE)] public static int Hash(long v) { return v.GetHashCode(); }
        #endregion

        #region Component iteration operations
        [IN(LINE)] public static long CMax(long a, long b) { return Max(a, b); }
        [IN(LINE)] public static long CMax(long a, long b, long c) { return Max(Max(a, b), c); }
        [IN(LINE)] public static long CMax(long a, long b, long c, long d) { return Max(Max(a, b), Max(c, d)); }
        [IN(LINE)] public static long CMax(long a, long b, long c, long d, long e) { return Max(CMax(a, b, c, d), e); }
        [IN(LINE)] public static long CMax(long a, long b, long c, long d, long e, long f) { return Max(CMax(a, b, c, d), Max(e, f)); }
        [IN(LINE)] public static long CMax(long a, long b, long c, long d, long e, long f, long g) { return Max(CMax(a, b, c, d), Max(Max(a, b), c)); }
        [IN(LINE)] public static long CMax(long a, long b, long c, long d, long e, long f, long g, long h) { return Max(CMax(a, b, c, d), CMax(e, f, g, h)); }

        [IN(LINE)] public static long CAbsMax(long a, long b) { return AbsMax(a, b); }
        [IN(LINE)] public static long CAbsMax(long a, long b, long c) { return AbsMax(AbsMax(a, b), c); }
        [IN(LINE)] public static long CAbsMax(long a, long b, long c, long d) { return AbsMax(AbsMax(a, b), AbsMax(c, d)); }
        [IN(LINE)] public static long CAbsMax(long a, long b, long c, long d, long e) { return AbsMax(CAbsMax(a, b, c, d), e); }
        [IN(LINE)] public static long CAbsMax(long a, long b, long c, long d, long e, long f) { return AbsMax(CAbsMax(a, b, c, d), AbsMax(e, f)); }
        [IN(LINE)] public static long CAbsMax(long a, long b, long c, long d, long e, long f, long g) { return AbsMax(CAbsMax(a, b, c, d), AbsMax(AbsMax(a, b), c)); }
        [IN(LINE)] public static long CAbsMax(long a, long b, long c, long d, long e, long f, long g, long h) { return AbsMax(CAbsMax(a, b, c, d), CAbsMax(e, f, g, h)); }

        [IN(LINE)] public static long CMin(long a, long b) { return Min(a, b); }
        [IN(LINE)] public static long CMin(long a, long b, long c) { return Min(Min(a, b), c); }
        [IN(LINE)] public static long CMin(long a, long b, long c, long d) { return Min(Min(a, b), Min(c, d)); }
        [IN(LINE)] public static long CMin(long a, long b, long c, long d, long e) { return Min(CMin(a, b, c, d), e); }
        [IN(LINE)] public static long CMin(long a, long b, long c, long d, long e, long f) { return Min(CMin(a, b, c, d), Min(e, f)); }
        [IN(LINE)] public static long CMin(long a, long b, long c, long d, long e, long f, long g) { return Min(CMin(a, b, c, d), Min(Min(a, b), c)); }
        [IN(LINE)] public static long CMin(long a, long b, long c, long d, long e, long f, long g, long h) { return Min(CMin(a, b, c, d), CMin(e, f, g, h)); }

        [IN(LINE)] public static long CAbsMin(long a, long b) { return AbsMin(a, b); }
        [IN(LINE)] public static long CAbsMin(long a, long b, long c) { return AbsMin(AbsMin(a, b), c); }
        [IN(LINE)] public static long CAbsMin(long a, long b, long c, long d) { return AbsMin(AbsMin(a, b), AbsMin(c, d)); }
        [IN(LINE)] public static long CAbsMin(long a, long b, long c, long d, long e) { return AbsMin(CAbsMin(a, b, c, d), e); }
        [IN(LINE)] public static long CAbsMin(long a, long b, long c, long d, long e, long f) { return AbsMin(CAbsMin(a, b, c, d), AbsMin(e, f)); }
        [IN(LINE)] public static long CAbsMin(long a, long b, long c, long d, long e, long f, long g) { return AbsMin(CAbsMin(a, b, c, d), AbsMin(AbsMin(a, b), c)); }
        [IN(LINE)] public static long CAbsMin(long a, long b, long c, long d, long e, long f, long g, long h) { return AbsMin(CAbsMin(a, b, c, d), CAbsMin(e, f, g, h)); }


        [IN(LINE)]
        public static long CMax<T>(T a, long _ = default) where T : IVectorN<long>
        {
            switch (a.Count)
            {
                case 0: Throw.ZeroLengthArgument(nameof(a)); break;
                case 1: return a[0];
                case 2: return CMax(a[0], a[1]);
                case 3: return CMax(a[0], a[1], a[2]);
                case 4: return CMax(a[0], a[1], a[2], a[3]);
                default:
                    var result = a[0];
                    for (int i = 1; i < a.Count; i++)
                    {
                        result = CMax(result, a[i]);
                    }
                    return result;
            }
            return default;
        }
        [IN(LINE)]
        public static long CAbsMax<T>(T a, long _ = default) where T : IVectorN<long>
        {
            switch (a.Count)
            {
                case 0: Throw.ZeroLengthArgument(nameof(a)); break;
                case 1: return a[0];
                case 2: return CAbsMax(a[0], a[1]);
                case 3: return CAbsMax(a[0], a[1], a[2]);
                case 4: return CAbsMax(a[0], a[1], a[2], a[3]);
                default:
                    var result = a[0];
                    for (int i = 1; i < a.Count; i++)
                    {
                        result = CAbsMax(result, a[i]);
                    }
                    return result;
            }
            return default;
        }
        [IN(LINE)]
        public static long CMin<T>(T a, long _ = default) where T : IVectorN<long>
        {
            switch (a.Count)
            {
                case 0: Throw.ZeroLengthArgument(nameof(a)); break;
                case 1: return a[0];
                case 2: return CMin(a[0], a[1]);
                case 3: return CMin(a[0], a[1], a[2]);
                case 4: return CMin(a[0], a[1], a[2], a[3]);
                default:
                    var result = a[0];
                    for (int i = 1; i < a.Count; i++)
                    {
                        result = CMin(result, a[i]);
                    }
                    return result;
            }
            return default;
        }
        [IN(LINE)]
        public static long CAbsMin<T>(T a, long _ = default) where T : IVectorN<long>
        {
            switch (a.Count)
            {
                case 0: Throw.ZeroLengthArgument(nameof(a)); break;
                case 1: return a[0];
                case 2: return CAbsMin(a[0], a[1]);
                case 3: return CAbsMin(a[0], a[1], a[2]);
                case 4: return CAbsMin(a[0], a[1], a[2], a[3]);
                default:
                    var result = a[0];
                    for (int i = 1; i < a.Count; i++)
                    {
                        result = CAbsMin(result, a[i]);
                    }
                    return result;
            }
            return default;
        }
        [IN(LINE)]
        public static long CSum<T>(T a, long _ = default) where T : IVectorN<long>
        {
            switch (a.Count)
            {
                case 0: return 0;
                case 1: return a[0];
                case 2: return a[0] + a[1];
                case 3: return a[0] + a[1] + a[2];
                case 4: return a[0] + a[1] + a[2] + a[3];
                default:
                    var result = a[0] + a[1] + a[2] + a[3];
                    for (int i = 4; i < a.Count; i++)
                    {
                        result += a[i];
                    }
                    return result;
            }
        }
        [IN(LINE)] public static ulong UHash<TVector>(TVector v, long _ = default) where TVector : IVectorN<long> { return unchecked((ulong)Hash<TVector>(v)); }
        [IN(LINE)]
        public static long Hash<TVector>(TVector v, long _ = default) where TVector : IVectorN<long>
        {
            long bits = 0;
            for (int i = 0; i < v.Count; i++)
            {
                bits ^= Hash(v[i]);
            }
            return bits;
        }
        #endregion
    }

    public static partial class DMBits // long
    {
        #region Rnd
        [IN(LINE)] public static long NextXorShiftState(long a) { unchecked { return InternalBits.NextXorShiftState(a); } }
        #endregion

        #region Other
        [IN(LINE)] public static long Count(long a) { unchecked { return InternalBits.CountBits((ulong)a); } }
        [IN(LINE)] public static long Reverse(long a) { unchecked { return InternalBits.Reverse(a); } }
        [IN(LINE)] public static float AsFloatFraction(long a) { unchecked { return AsFloatFraction((ulong)a); } }
        [IN(LINE)] public static double AsDoubleFraction(long a) { unchecked { return AsDoubleFraction((ulong)a); } }
        #endregion
    }
}
