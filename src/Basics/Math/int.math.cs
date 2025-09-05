#if DISABLE_DEBUG
#undef DEBUG
#endif
using DCFApixels.DataMath.Internal;
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public static partial class DM // int self
    {

    }
    public static partial class DM // int
    {
        #region Abs/Sign
        [IN(LINE)] public static int Abs(int a) { return InternalMath.Abs(a); }
        [IN(LINE)] public static int Sign(int a) { return (a > 0 ? 1 : 0) - (a < 0 ? 1 : 0); }
        #endregion

        #region Clamp/Repeat/PingPong
        /// <summary> Clamps the value between min and max. </summary>
        [IN(LINE)]
        public static int Clamp(int a, int min, int max)
        {
            if (a < min) { return min; }
            if (a > max) { return max; }
            return a;
        }

        [IN(LINE)]
        public static int Repeat(int a, int length)
        {
            if (length < 0) { return 0; }
            int mod = a % length;
            return mod < 0 ? mod + length : mod;
        }
        [IN(LINE)] public static int Repeat(int a, int min, int max) { return Repeat(a, max - min) + min; }

        [IN(LINE)] public static int PingPong(int a, int length) { return length - Abs(Repeat(a, length * 2) - length); }
        [IN(LINE)] public static int PingPong(int a, int min, int max) { return PingPong(a, max - min) + min; }
        #endregion

        #region All/Any
        [IN(LINE)] public static bool All(int a) { return a != default; }
        [IN(LINE)] public static bool Any(int a) { return a != default; }
        #endregion

        #region Min/Max/Sum
        [IN(LINE)] public static int Max(int a, int b) { return a > b ? a : b; }
        [IN(LINE)] public static int AbsMax(int a, int b) { return InternalMath.Abs(a) > InternalMath.Abs(b) ? a : b; }
        [IN(LINE)] public static int Min(int a, int b) { return a < b ? a : b; }
        [IN(LINE)] public static int AbsMin(int a, int b) { return InternalMath.Abs(a) < InternalMath.Abs(b) ? a : b; }
        [IN(LINE)] public static int CMax(int a) { return a; }
        [IN(LINE)] public static int CAbsMax(int a) { return a; }
        [IN(LINE)] public static int CMin(int a) { return a; }
        [IN(LINE)] public static int CAbsMin(int a) { return a; }
        [IN(LINE)] public static int CSum(int a) { return a; }
        #endregion

        #region Pow2
        [IN(LINE)] public static int CeilPow2(int value) { unchecked { return (int)CeilPow2((uint)value); } }
        [IN(LINE)] public static int FloorPow2(int value) { unchecked { return (int)FloorPow2((uint)value); } }
        [IN(LINE)] public static int RoundPow2(int value) { unchecked { return (int)RoundPow2((uint)value); } }
        [IN(LINE)] public static bool IsPow2(int value) { return (value & (value - 1)) == 0; }
        #endregion

        #region Other
        //Length - float
        //Distance - float
        //Sqrt - float
        [IN(LINE)] public static int LengthSqr(int a) { return Sqr(a); }
        [IN(LINE)] public static int DistanceSqr(int a, int b) { return Sqr(b - a); }
        [IN(LINE)] public static int Dot(int a, int b) { return a * b; }
        [IN(LINE)] public static int Sqr(int a) { return a * a; }
        [IN(LINE)] public static int Pow(int a, int b) { return InternalMath.Pow(a, b); }
        [IN(LINE)] public static int Select(int falseValue, int trueValue, bool test) { return test ? trueValue : falseValue; }
        #endregion


        #region Hash
        [IN(LINE)] public static uint UHash(int v) { return unchecked((uint)v); }
        [IN(LINE)] public static int Hash(int v) { return v; }
        #endregion

        #region Component iteration operations
        [IN(LINE)] public static int CMax(int a, int b) { return Max(a, b); }
        [IN(LINE)] public static int CMax(int a, int b, int c) { return Max(Max(a, b), c); }
        [IN(LINE)] public static int CMax(int a, int b, int c, int d) { return Max(Max(a, b), Max(c, d)); }
        [IN(LINE)] public static int CMax(int a, int b, int c, int d, int e) { return Max(CMax(a, b, c, d), e); }
        [IN(LINE)] public static int CMax(int a, int b, int c, int d, int e, int f) { return Max(CMax(a, b, c, d), Max(e, f)); }
        [IN(LINE)] public static int CMax(int a, int b, int c, int d, int e, int f, int g) { return Max(CMax(a, b, c, d), Max(Max(a, b), c)); }
        [IN(LINE)] public static int CMax(int a, int b, int c, int d, int e, int f, int g, int h) { return Max(CMax(a, b, c, d), CMax(e, f, g, h)); }

        [IN(LINE)] public static int CAbsMax(int a, int b) { return AbsMax(a, b); }
        [IN(LINE)] public static int CAbsMax(int a, int b, int c) { return AbsMax(AbsMax(a, b), c); }
        [IN(LINE)] public static int CAbsMax(int a, int b, int c, int d) { return AbsMax(AbsMax(a, b), AbsMax(c, d)); }
        [IN(LINE)] public static int CAbsMax(int a, int b, int c, int d, int e) { return AbsMax(CAbsMax(a, b, c, d), e); }
        [IN(LINE)] public static int CAbsMax(int a, int b, int c, int d, int e, int f) { return AbsMax(CAbsMax(a, b, c, d), AbsMax(e, f)); }
        [IN(LINE)] public static int CAbsMax(int a, int b, int c, int d, int e, int f, int g) { return AbsMax(CAbsMax(a, b, c, d), AbsMax(AbsMax(a, b), c)); }
        [IN(LINE)] public static int CAbsMax(int a, int b, int c, int d, int e, int f, int g, int h) { return AbsMax(CAbsMax(a, b, c, d), CAbsMax(e, f, g, h)); }

        [IN(LINE)] public static int CMin(int a, int b) { return Min(a, b); }
        [IN(LINE)] public static int CMin(int a, int b, int c) { return Min(Min(a, b), c); }
        [IN(LINE)] public static int CMin(int a, int b, int c, int d) { return Min(Min(a, b), Min(c, d)); }
        [IN(LINE)] public static int CMin(int a, int b, int c, int d, int e) { return Min(CMin(a, b, c, d), e); }
        [IN(LINE)] public static int CMin(int a, int b, int c, int d, int e, int f) { return Min(CMin(a, b, c, d), Min(e, f)); }
        [IN(LINE)] public static int CMin(int a, int b, int c, int d, int e, int f, int g) { return Min(CMin(a, b, c, d), Min(Min(a, b), c)); }
        [IN(LINE)] public static int CMin(int a, int b, int c, int d, int e, int f, int g, int h) { return Min(CMin(a, b, c, d), CMin(e, f, g, h)); }

        [IN(LINE)] public static int CAbsMin(int a, int b) { return AbsMin(a, b); }
        [IN(LINE)] public static int CAbsMin(int a, int b, int c) { return AbsMin(AbsMin(a, b), c); }
        [IN(LINE)] public static int CAbsMin(int a, int b, int c, int d) { return AbsMin(AbsMin(a, b), AbsMin(c, d)); }
        [IN(LINE)] public static int CAbsMin(int a, int b, int c, int d, int e) { return AbsMin(CAbsMin(a, b, c, d), e); }
        [IN(LINE)] public static int CAbsMin(int a, int b, int c, int d, int e, int f) { return AbsMin(CAbsMin(a, b, c, d), AbsMin(e, f)); }
        [IN(LINE)] public static int CAbsMin(int a, int b, int c, int d, int e, int f, int g) { return AbsMin(CAbsMin(a, b, c, d), AbsMin(AbsMin(a, b), c)); }
        [IN(LINE)] public static int CAbsMin(int a, int b, int c, int d, int e, int f, int g, int h) { return AbsMin(CAbsMin(a, b, c, d), CAbsMin(e, f, g, h)); }


        [IN(LINE)]
        public static int CMax<T>(T a, int _ = default) where T : IVectorN<int>
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
        public static int CAbsMax<T>(T a, int _ = default) where T : IVectorN<int>
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
        public static int CMin<T>(T a, int _ = default) where T : IVectorN<int>
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
        public static int CAbsMin<T>(T a, int _ = default) where T : IVectorN<int>
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
        public static int CSum<T>(T a, int _ = default) where T : IVectorN<int>
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
        [IN(LINE)] public static uint UHash<TVector>(TVector v, int _ = default) where TVector : IVectorN<int> { return unchecked((uint)Hash<TVector>(v)); }
        [IN(LINE)]
        public static int Hash<TVector>(TVector v, int _ = default) where TVector : IVectorN<int>
        {
            int bits = 0;
            for (int i = 0; i < v.Count; i++)
            {
                bits ^= Hash(v[i]);
            }
            return bits;
        }
        #endregion
    }

    public static partial class DMBits // int
    {
        #region Rnd
        [IN(LINE)] public static int NextXorShiftState(int a) { unchecked { return InternalBits.NextXorShiftState(a); } }
        #endregion

        #region Other
        [IN(LINE)] public static int Count(int a) { unchecked { return InternalBits.CountBits((uint)a); } }
        [IN(LINE)] public static int Reverse(int a) { unchecked { return InternalBits.Reverse(a); } }
        [IN(LINE)] public static float AsFloatFraction(int a) { unchecked { return AsFloatFraction((uint)a); } }
        [IN(LINE)] public static double AsDoubleFraction(int a) { unchecked { return AsDoubleFraction((uint)a); } }
        #endregion
    }
}
