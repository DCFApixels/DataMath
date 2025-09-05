#if DISABLE_DEBUG
#undef DEBUG
#endif
using DCFApixels.DataMath.Internal;
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public static partial class DM // uint self
    {

    }
    public static partial class DM // uint
    {
        #region Abs/Sign
        [IN(LINE)] public static uint Abs(uint a) { return a; }
        [IN(LINE)] public static uint Sign(uint a) { return a > 0u ? 1u : 0u; }
        #endregion

        #region Clamp/Repeat/PingPong
        /// <summary> Clamps the value between min and max. </summary>
        [IN(LINE)]
        public static uint Clamp(uint a, uint min, uint max)
        {
            if (a < min) { return min; }
            if (a > max) { return max; }
            return a;
        }

        [IN(LINE)] public static uint Repeat(uint a, uint length) { return a % length; }
        [IN(LINE)] public static uint Repeat(uint a, uint min, uint max) { return Repeat(a, max - min) + min; }

        [IN(LINE)] public static uint PingPong(uint a, uint length) { return length - Abs(Repeat(a, length * 2) - length); }
        [IN(LINE)] public static uint PingPong(uint a, uint min, uint max) { return PingPong(a, max - min) + min; }
        #endregion

        #region All/Any
        [IN(LINE)] public static bool All(uint a) { return a != default; }
        [IN(LINE)] public static bool Any(uint a) { return a != default; }
        #endregion

        #region Min/Max/Sum
        [IN(LINE)] public static uint Max(uint a, uint b) { return a > b ? a : b; }
        [IN(LINE)] public static uint AbsMax(uint a, uint b) { return a > b ? a : b; }
        [IN(LINE)] public static uint Min(uint a, uint b) { return a < b ? a : b; }
        [IN(LINE)] public static uint AbsMin(uint a, uint b) { return a < b ? a : b; }
        [IN(LINE)] public static uint CMax(uint a) { return a; }
        [IN(LINE)] public static uint CAbsMax(uint a) { return a; }
        [IN(LINE)] public static uint CMin(uint a) { return a; }
        [IN(LINE)] public static uint CAbsMin(uint a) { return a; }
        [IN(LINE)] public static uint CSum(uint a) { return a; }
        #endregion

        #region Pow2
        [IN(LINE)]
        public static uint CeilPow2(uint value)
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
        public static uint FloorPow2(uint value)
        {
            var result = CeilPow2(value);
            return result == value ? value : result >> 1;
        }
        [IN(LINE)]
        public static uint RoundPow2(uint value)
        {
            uint ceil = CeilPow2(value);
            uint floor = value >> 1;
            if (value - floor < ceil - value)
            {
                return floor;
            }
            return ceil;
        }
        [IN(LINE)] public static bool IsPow2(uint value) { return (value & (value - 1)) == 0; }
        #endregion

        #region Other
        //Length - float
        //Distance - float
        //Sqrt - float
        [IN(LINE)] public static uint LengthSqr(uint a) { return Sqr(a); }
        [IN(LINE)] public static uint DistanceSqr(uint a, uint b) { return Sqr(b - a); }
        [IN(LINE)] public static uint Dot(uint a, uint b) { return a * b; }
        [IN(LINE)] public static uint Sqr(uint a) { return a * a; }
        [IN(LINE)] public static uint Pow(uint a, uint b) { return InternalMath.Pow(a, b); }
        [IN(LINE)] public static uint Select(uint falseValue, uint trueValue, bool test) { return test ? trueValue : falseValue; }
        #endregion


        #region Hash
        [IN(LINE)] public static uint UHash(uint v) { return v; }
        [IN(LINE)] public static int Hash(uint v) { return unchecked((int)v); }
        #endregion

        #region Component iteration operations
        [IN(LINE)] public static uint CMax(uint a, uint b) { return Max(a, b); }
        [IN(LINE)] public static uint CMax(uint a, uint b, uint c) { return Max(Max(a, b), c); }
        [IN(LINE)] public static uint CMax(uint a, uint b, uint c, uint d) { return Max(Max(a, b), Max(c, d)); }
        [IN(LINE)] public static uint CMax(uint a, uint b, uint c, uint d, uint e) { return Max(CMax(a, b, c, d), e); }
        [IN(LINE)] public static uint CMax(uint a, uint b, uint c, uint d, uint e, uint f) { return Max(CMax(a, b, c, d), Max(e, f)); }
        [IN(LINE)] public static uint CMax(uint a, uint b, uint c, uint d, uint e, uint f, uint g) { return Max(CMax(a, b, c, d), Max(Max(a, b), c)); }
        [IN(LINE)] public static uint CMax(uint a, uint b, uint c, uint d, uint e, uint f, uint g, uint h) { return Max(CMax(a, b, c, d), CMax(e, f, g, h)); }

        [IN(LINE)] public static uint CAbsMax(uint a, uint b) { return AbsMax(a, b); }
        [IN(LINE)] public static uint CAbsMax(uint a, uint b, uint c) { return AbsMax(AbsMax(a, b), c); }
        [IN(LINE)] public static uint CAbsMax(uint a, uint b, uint c, uint d) { return AbsMax(AbsMax(a, b), AbsMax(c, d)); }
        [IN(LINE)] public static uint CAbsMax(uint a, uint b, uint c, uint d, uint e) { return AbsMax(CAbsMax(a, b, c, d), e); }
        [IN(LINE)] public static uint CAbsMax(uint a, uint b, uint c, uint d, uint e, uint f) { return AbsMax(CAbsMax(a, b, c, d), AbsMax(e, f)); }
        [IN(LINE)] public static uint CAbsMax(uint a, uint b, uint c, uint d, uint e, uint f, uint g) { return AbsMax(CAbsMax(a, b, c, d), AbsMax(AbsMax(a, b), c)); }
        [IN(LINE)] public static uint CAbsMax(uint a, uint b, uint c, uint d, uint e, uint f, uint g, uint h) { return AbsMax(CAbsMax(a, b, c, d), CAbsMax(e, f, g, h)); }

        [IN(LINE)] public static uint CMin(uint a, uint b) { return Min(a, b); }
        [IN(LINE)] public static uint CMin(uint a, uint b, uint c) { return Min(Min(a, b), c); }
        [IN(LINE)] public static uint CMin(uint a, uint b, uint c, uint d) { return Min(Min(a, b), Min(c, d)); }
        [IN(LINE)] public static uint CMin(uint a, uint b, uint c, uint d, uint e) { return Min(CMin(a, b, c, d), e); }
        [IN(LINE)] public static uint CMin(uint a, uint b, uint c, uint d, uint e, uint f) { return Min(CMin(a, b, c, d), Min(e, f)); }
        [IN(LINE)] public static uint CMin(uint a, uint b, uint c, uint d, uint e, uint f, uint g) { return Min(CMin(a, b, c, d), Min(Min(a, b), c)); }
        [IN(LINE)] public static uint CMin(uint a, uint b, uint c, uint d, uint e, uint f, uint g, uint h) { return Min(CMin(a, b, c, d), CMin(e, f, g, h)); }

        [IN(LINE)] public static uint CAbsMin(uint a, uint b) { return AbsMin(a, b); }
        [IN(LINE)] public static uint CAbsMin(uint a, uint b, uint c) { return AbsMin(AbsMin(a, b), c); }
        [IN(LINE)] public static uint CAbsMin(uint a, uint b, uint c, uint d) { return AbsMin(AbsMin(a, b), AbsMin(c, d)); }
        [IN(LINE)] public static uint CAbsMin(uint a, uint b, uint c, uint d, uint e) { return AbsMin(CAbsMin(a, b, c, d), e); }
        [IN(LINE)] public static uint CAbsMin(uint a, uint b, uint c, uint d, uint e, uint f) { return AbsMin(CAbsMin(a, b, c, d), AbsMin(e, f)); }
        [IN(LINE)] public static uint CAbsMin(uint a, uint b, uint c, uint d, uint e, uint f, uint g) { return AbsMin(CAbsMin(a, b, c, d), AbsMin(AbsMin(a, b), c)); }
        [IN(LINE)] public static uint CAbsMin(uint a, uint b, uint c, uint d, uint e, uint f, uint g, uint h) { return AbsMin(CAbsMin(a, b, c, d), CAbsMin(e, f, g, h)); }


        [IN(LINE)]
        public static uint CMax<T>(T a, uint _ = default) where T : IVectorN<uint>
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
        public static uint CAbsMax<T>(T a, uint _ = default) where T : IVectorN<uint>
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
        public static uint CMin<T>(T a, uint _ = default) where T : IVectorN<uint>
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
        public static uint CAbsMin<T>(T a, uint _ = default) where T : IVectorN<uint>
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
        public static uint Sum<T>(T a, uint _ = default) where T : IVectorN<uint>
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
        [IN(LINE)]
        public static uint UHash<TVector>(TVector v, uint _ = default) where TVector : IVectorN<uint>
        {
            uint bits = 0;
            for (int i = 0; i < v.Count; i++)
            {
                bits ^= UHash(v[i]);
            }
            return bits;
        }
        [IN(LINE)] public static int Hash<TVector>(TVector v, uint _ = default) where TVector : IVectorN<uint> { return unchecked((int)UHash<TVector>(v)); }
        #endregion
    }

    public static partial class DMBits // uint
    {
        #region Rnd
        [IN(LINE)] public static uint NextXorShiftState(uint a) { unchecked { return InternalBits.NextXorShiftState(a); } }
        #endregion

        #region Other
        [IN(LINE)] public static int Count(uint a) { unchecked { return InternalBits.CountBits(a); } }
        [IN(LINE)] public static uint Reverse(uint a) { unchecked { return InternalBits.Reverse(a); } }
        [IN(LINE)] public static float AsFloatFraction(uint a) { unchecked { return InternalBits.Q32ToFloat(a); } }
        [IN(LINE)] public static double AsDoubleFraction(uint a)
        {
            unchecked
            {
                UInt2ULongUnion u = default;
                u.uint2Value.x = a;
                return InternalBits.Q64ToDouble(u.ulongValue);
            }
        }
        #endregion
    }
}
