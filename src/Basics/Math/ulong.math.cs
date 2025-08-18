#if DISABLE_DEBUG
#undef DEBUG
#endif
using DCFApixels.DataMath.Internal;
using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public static partial class DM // ulong self
    {

    }
    public static partial class DM // ulong
    {
        #region Abs/Sign
        [IN(LINE)] public static ulong Abs(ulong a) { return a; }
        [IN(LINE)] public static ulong Sign(ulong a) { return a > 0u ? 1u : 0u; }
        #endregion

        #region Clamp/Repeat/PingPong
        /// <summary> Clamps the value between min and max. </summary>
        [IN(LINE)]
        public static ulong Clamp(ulong a, ulong min, ulong max)
        {
            if (a < min) { return min; }
            if (a > max) { return max; }
            return a;
        }

        [IN(LINE)] public static ulong Repeat(ulong a, ulong length) { return a % length; }
        [IN(LINE)] public static ulong Repeat(ulong a, ulong min, ulong max) { return Repeat(a, max - min) + min; }

        [IN(LINE)] public static ulong PingPong(ulong a, ulong length) { return length - Abs(Repeat(a, length * 2) - length); }
        [IN(LINE)] public static ulong PingPong(ulong a, ulong min, ulong max) { return PingPong(a, max - min) + min; }
        #endregion

        #region All/Any
        [IN(LINE)] public static bool All(ulong a) { return a != default; }
        [IN(LINE)] public static bool Any(ulong a) { return a != default; }
        #endregion

        #region Min/Max/Sum
        [IN(LINE)] public static ulong Max(ulong a, ulong b) { return a > b ? a : b; }
        [IN(LINE)] public static ulong AbsMax(ulong a, ulong b) { return a > b ? a : b; }
        [IN(LINE)] public static ulong Min(ulong a, ulong b) { return a < b ? a : b; }
        [IN(LINE)] public static ulong AbsMin(ulong a, ulong b) { return a < b ? a : b; }
        [IN(LINE)] public static ulong CMax(ulong a) { return a; }
        [IN(LINE)] public static ulong CAbsMax(ulong a) { return a; }
        [IN(LINE)] public static ulong CMin(ulong a) { return a; }
        [IN(LINE)] public static ulong CAbsMin(ulong a) { return a; }
        [IN(LINE)] public static ulong CSum(ulong a) { return a; }
        #endregion

        #region Pow2
        [IN(LINE)]
        public static ulong CeilPow2(ulong value)
        {
            value--;
            value |= value >> 16;
            value |= value >> 8;
            value |= value >> 4;
            value |= value >> 2;
            value |= value >> 1;
            return value + 1;
        }
        [IN(LINE)]
        public static ulong FloorPow2(ulong value)
        {
            var result = CeilPow2(value);
            return result == value ? value : result >> 1;
        }
        [IN(LINE)]
        public static ulong RoundPow2(ulong value)
        {
            value = CeilPow2(value);
            ulong floor = value >> 1;
            if (value - floor < value - value)
            {
                return floor;
            }
            return value;
        }
        [IN(LINE)] public static bool IsPow2(ulong value) { return (value & (value - 1)) == 0; }
        #endregion

        #region Other
        //Length - float
        //Distance - float
        //Sqrt - float
        [IN(LINE)] public static ulong LengthSqr(ulong a) { return Sqr(a); }
        [IN(LINE)] public static ulong DistanceSqr(ulong a, ulong b) { return Sqr(b - a); }
        [IN(LINE)] public static ulong Dot(ulong a, ulong b) { return a * b; }
        [IN(LINE)] public static ulong Sqr(ulong a) { return a * a; }
        [IN(LINE)] public static ulong Pow(ulong a, ulong b) { return InternalMath.Pow(a, b); }
        [IN(LINE)] public static ulong Select(ulong falseValue, ulong trueValue, bool test) { return test ? trueValue : falseValue; }
        #endregion


        #region Hash
        [IN(LINE)] public static ulong UHash(ulong v) { return v; }
        [IN(LINE)] public static int Hash(ulong v) { return unchecked((int)v); }
        #endregion

        #region Component iteration operations
        [IN(LINE)] public static ulong CMax(ulong a, ulong b) { return Max(a, b); }
        [IN(LINE)] public static ulong CMax(ulong a, ulong b, ulong c) { return Max(Max(a, b), c); }
        [IN(LINE)] public static ulong CMax(ulong a, ulong b, ulong c, ulong d) { return Max(Max(a, b), Max(c, d)); }
        [IN(LINE)] public static ulong CMax(ulong a, ulong b, ulong c, ulong d, ulong e) { return Max(CMax(a, b, c, d), e); }
        [IN(LINE)] public static ulong CMax(ulong a, ulong b, ulong c, ulong d, ulong e, ulong f) { return Max(CMax(a, b, c, d), Max(e, f)); }
        [IN(LINE)] public static ulong CMax(ulong a, ulong b, ulong c, ulong d, ulong e, ulong f, ulong g) { return Max(CMax(a, b, c, d), Max(Max(a, b), c)); }
        [IN(LINE)] public static ulong CMax(ulong a, ulong b, ulong c, ulong d, ulong e, ulong f, ulong g, ulong h) { return Max(CMax(a, b, c, d), CMax(e, f, g, h)); }

        [IN(LINE)] public static ulong CAbsMax(ulong a, ulong b) { return AbsMax(a, b); }
        [IN(LINE)] public static ulong CAbsMax(ulong a, ulong b, ulong c) { return AbsMax(AbsMax(a, b), c); }
        [IN(LINE)] public static ulong CAbsMax(ulong a, ulong b, ulong c, ulong d) { return AbsMax(AbsMax(a, b), AbsMax(c, d)); }
        [IN(LINE)] public static ulong CAbsMax(ulong a, ulong b, ulong c, ulong d, ulong e) { return AbsMax(CAbsMax(a, b, c, d), e); }
        [IN(LINE)] public static ulong CAbsMax(ulong a, ulong b, ulong c, ulong d, ulong e, ulong f) { return AbsMax(CAbsMax(a, b, c, d), AbsMax(e, f)); }
        [IN(LINE)] public static ulong CAbsMax(ulong a, ulong b, ulong c, ulong d, ulong e, ulong f, ulong g) { return AbsMax(CAbsMax(a, b, c, d), AbsMax(AbsMax(a, b), c)); }
        [IN(LINE)] public static ulong CAbsMax(ulong a, ulong b, ulong c, ulong d, ulong e, ulong f, ulong g, ulong h) { return AbsMax(CAbsMax(a, b, c, d), CAbsMax(e, f, g, h)); }

        [IN(LINE)] public static ulong CMin(ulong a, ulong b) { return Min(a, b); }
        [IN(LINE)] public static ulong CMin(ulong a, ulong b, ulong c) { return Min(Min(a, b), c); }
        [IN(LINE)] public static ulong CMin(ulong a, ulong b, ulong c, ulong d) { return Min(Min(a, b), Min(c, d)); }
        [IN(LINE)] public static ulong CMin(ulong a, ulong b, ulong c, ulong d, ulong e) { return Min(CMin(a, b, c, d), e); }
        [IN(LINE)] public static ulong CMin(ulong a, ulong b, ulong c, ulong d, ulong e, ulong f) { return Min(CMin(a, b, c, d), Min(e, f)); }
        [IN(LINE)] public static ulong CMin(ulong a, ulong b, ulong c, ulong d, ulong e, ulong f, ulong g) { return Min(CMin(a, b, c, d), Min(Min(a, b), c)); }
        [IN(LINE)] public static ulong CMin(ulong a, ulong b, ulong c, ulong d, ulong e, ulong f, ulong g, ulong h) { return Min(CMin(a, b, c, d), CMin(e, f, g, h)); }

        [IN(LINE)] public static ulong CAbsMin(ulong a, ulong b) { return AbsMin(a, b); }
        [IN(LINE)] public static ulong CAbsMin(ulong a, ulong b, ulong c) { return AbsMin(AbsMin(a, b), c); }
        [IN(LINE)] public static ulong CAbsMin(ulong a, ulong b, ulong c, ulong d) { return AbsMin(AbsMin(a, b), AbsMin(c, d)); }
        [IN(LINE)] public static ulong CAbsMin(ulong a, ulong b, ulong c, ulong d, ulong e) { return AbsMin(CAbsMin(a, b, c, d), e); }
        [IN(LINE)] public static ulong CAbsMin(ulong a, ulong b, ulong c, ulong d, ulong e, ulong f) { return AbsMin(CAbsMin(a, b, c, d), AbsMin(e, f)); }
        [IN(LINE)] public static ulong CAbsMin(ulong a, ulong b, ulong c, ulong d, ulong e, ulong f, ulong g) { return AbsMin(CAbsMin(a, b, c, d), AbsMin(AbsMin(a, b), c)); }
        [IN(LINE)] public static ulong CAbsMin(ulong a, ulong b, ulong c, ulong d, ulong e, ulong f, ulong g, ulong h) { return AbsMin(CAbsMin(a, b, c, d), CAbsMin(e, f, g, h)); }


        [IN(LINE)]
        public static ulong CMax<T>(T a, ulong _ = default) where T : IVectorN<ulong>
        {
            switch (a.count)
            {
                case 0: Throw.ZeroLengthArgument(nameof(a)); break;
                case 1: return a[0];
                case 2: return CMax(a[0], a[1]);
                case 3: return CMax(a[0], a[1], a[2]);
                case 4: return CMax(a[0], a[1], a[2], a[3]);
                default:
                    var result = a[0];
                    for (int i = 1; i < a.count; i++)
                    {
                        result = CMax(result, a[i]);
                    }
                    return result;
            }
            return default;
        }
        [IN(LINE)]
        public static ulong CAbsMax<T>(T a, ulong _ = default) where T : IVectorN<ulong>
        {
            switch (a.count)
            {
                case 0: Throw.ZeroLengthArgument(nameof(a)); break;
                case 1: return a[0];
                case 2: return CAbsMax(a[0], a[1]);
                case 3: return CAbsMax(a[0], a[1], a[2]);
                case 4: return CAbsMax(a[0], a[1], a[2], a[3]);
                default:
                    var result = a[0];
                    for (int i = 1; i < a.count; i++)
                    {
                        result = CAbsMax(result, a[i]);
                    }
                    return result;
            }
            return default;
        }
        [IN(LINE)]
        public static ulong CMin<T>(T a, ulong _ = default) where T : IVectorN<ulong>
        {
            switch (a.count)
            {
                case 0: Throw.ZeroLengthArgument(nameof(a)); break;
                case 1: return a[0];
                case 2: return CMin(a[0], a[1]);
                case 3: return CMin(a[0], a[1], a[2]);
                case 4: return CMin(a[0], a[1], a[2], a[3]);
                default:
                    var result = a[0];
                    for (int i = 1; i < a.count; i++)
                    {
                        result = CMin(result, a[i]);
                    }
                    return result;
            }
            return default;
        }
        [IN(LINE)]
        public static ulong CAbsMin<T>(T a, ulong _ = default) where T : IVectorN<ulong>
        {
            switch (a.count)
            {
                case 0: Throw.ZeroLengthArgument(nameof(a)); break;
                case 1: return a[0];
                case 2: return CAbsMin(a[0], a[1]);
                case 3: return CAbsMin(a[0], a[1], a[2]);
                case 4: return CAbsMin(a[0], a[1], a[2], a[3]);
                default:
                    var result = a[0];
                    for (int i = 1; i < a.count; i++)
                    {
                        result = CAbsMin(result, a[i]);
                    }
                    return result;
            }
            return default;
        }

        [IN(LINE)]
        public static ulong Sum<T>(T a, ulong _ = default) where T : IVectorN<ulong>
        {
            switch (a.count)
            {
                case 0: return 0;
                case 1: return a[0];
                case 2: return a[0] + a[1];
                case 3: return a[0] + a[1] + a[2];
                case 4: return a[0] + a[1] + a[2] + a[3];
                default:
                    var result = a[0] + a[1] + a[2] + a[3];
                    for (int i = 4; i < a.count; i++)
                    {
                        result += a[i];
                    }
                    return result;
            }
        }
        [IN(LINE)]
        public static ulong UHash<TVector>(TVector v, ulong _ = default) where TVector : IVectorN<ulong>
        {
            ulong bits = 0;
            for (int i = 0; i < v.count; i++)
            {
                bits ^= UHash(v[i]);
            }
            return bits;
        }
        [IN(LINE)] public static int Hash<TVector>(TVector v, ulong _ = default) where TVector : IVectorN<ulong> { return unchecked((int)UHash<TVector>(v)); }
        #endregion
    }

    public static partial class DMBits // ulong
    {
        #region Rnd
        [IN(LINE)] public static ulong NextXorShiftState(ulong a) { unchecked { return InternalBits.NextXorShiftState(a); } }
        #endregion

        #region Other
        [IN(LINE)] public static int Count(ulong a) { unchecked { return InternalBits.CountBits(a); } }
        [IN(LINE)] public static ulong Reverse(ulong a) { unchecked { return InternalBits.Reverse(a); } }
        #endregion
    }
}
