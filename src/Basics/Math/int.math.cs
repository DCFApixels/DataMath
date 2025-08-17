using DCFApixels.DataMath.Internal;
using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    //int
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
            if (a < min) return min;
            if (a > max) return max;
            return a;
        }

        [IN(LINE)] public static int Repeat(int a, int length) { return Clamp(a - Floor2Int(a / (float)length) * length, 0, length); }
        [IN(LINE)] public static int Repeat(int a, int min, int max) { return Repeat(a, max - min) + min; }

        [IN(LINE)] public static int PingPong(int a, int length) { return length - Abs(Repeat(a, length * 2) - length); }
        [IN(LINE)] public static int PingPong(int a, int min, int max) { return PingPong(a, max - min) + min; }
        #endregion

        #region SmoothStep
        /// <summary> Clamps the value between from and to. </summary>
        [IN(LINE)]
        public static int SmoothStep(int from, int to, int a)
        {
            var t = Clamp01(((float)a - from) / (to - from));
            return Floor2Int(t * t * (3 - (2 * t)));
        }
        #endregion

        #region Min/Max
        [IN(LINE)] public static int Max(int a, int b) { return a > b ? a : b; }
        [IN(LINE)] public static int AbsMax(int a, int b) { return InternalMath.Abs(a) > InternalMath.Abs(b) ? a : b; }
        [IN(LINE)] public static int Min(int a, int b) { return a < b ? a : b; }
        [IN(LINE)] public static int AbsMin(int a, int b) { return InternalMath.Abs(a) < InternalMath.Abs(b) ? a : b; }
        #endregion

        #region Pow2
        [IN(LINE)]
        public static int CeilPow2(int value)
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
        public static int FloorPow2(int value)
        {
            var result = CeilPow2(value);
            return result == value ? value : result >> 1;
        }
        [IN(LINE)]
        public static int RoundPow2(int value)
        {
            value = CeilPow2(value);
            int floor = value >> 1;
            if (value - floor < value - value)
            {
                return floor;
            }
            return value;
        }
        [IN(LINE)] public static bool IsPow2(int value) { return (value & (value - 1)) == 0; }
        #endregion

        #region Other
        [IN(LINE)] public static int Dot(int a, int b) { return a * b; }
        [IN(LINE)] public static int Select(int falseValue, int trueValue, bool test) { return test ? trueValue : falseValue; }
        #endregion


        #region Hash
        [IN(LINE)] public static uint UHash(int v) { return unchecked((uint)v); }
        [IN(LINE)] public static int Hash(int v) { return v; }
        #endregion

        #region Component iteration operations
        // Max overloads (3-8 args)
        [IN(LINE)] public static int Max(int a, int b, int c) { return Max(Max(a, b), c); }
        [IN(LINE)] public static int Max(int a, int b, int c, int d) { return Max(Max(a, b, c), d); }
        [IN(LINE)] public static int Max(int a, int b, int c, int d, int e) { return Max(Max(a, b, c, d), e); }
        [IN(LINE)] public static int Max(int a, int b, int c, int d, int e, int f) { return Max(Max(a, b, c, d, e), f); }
        [IN(LINE)] public static int Max(int a, int b, int c, int d, int e, int f, int g) { return Max(Max(a, b, c, d, e, f), g); }
        [IN(LINE)] public static int Max(int a, int b, int c, int d, int e, int f, int g, int h) { return Max(Max(a, b, c, d, e, f, g), h); }

        // AbsMax overloads (3-8 args)
        [IN(LINE)] public static int AbsMax(int a, int b, int c) { return AbsMax(AbsMax(a, b), c); }
        [IN(LINE)] public static int AbsMax(int a, int b, int c, int d) { return AbsMax(AbsMax(a, b, c), d); }
        [IN(LINE)] public static int AbsMax(int a, int b, int c, int d, int e) { return AbsMax(AbsMax(a, b, c, d), e); }
        [IN(LINE)] public static int AbsMax(int a, int b, int c, int d, int e, int f) { return AbsMax(AbsMax(a, b, c, d, e), f); }
        [IN(LINE)] public static int AbsMax(int a, int b, int c, int d, int e, int f, int g) { return AbsMax(AbsMax(a, b, c, d, e, f), g); }
        [IN(LINE)] public static int AbsMax(int a, int b, int c, int d, int e, int f, int g, int h) { return AbsMax(AbsMax(a, b, c, d, e, f, g), h); }

        // Min overloads (3-8 args)
        [IN(LINE)] public static int Min(int a, int b, int c) { return Min(Min(a, b), c); }
        [IN(LINE)] public static int Min(int a, int b, int c, int d) { return Min(Min(a, b, c), d); }
        [IN(LINE)] public static int Min(int a, int b, int c, int d, int e) { return Min(Min(a, b, c, d), e); }
        [IN(LINE)] public static int Min(int a, int b, int c, int d, int e, int f) { return Min(Min(a, b, c, d, e), f); }
        [IN(LINE)] public static int Min(int a, int b, int c, int d, int e, int f, int g) { return Min(Min(a, b, c, d, e, f), g); }
        [IN(LINE)] public static int Min(int a, int b, int c, int d, int e, int f, int g, int h) { return Min(Min(a, b, c, d, e, f, g), h); }

        // AbsMin overloads (3-8 args)
        [IN(LINE)] public static int AbsMin(int a, int b, int c) { return AbsMin(AbsMin(a, b), c); }
        [IN(LINE)] public static int AbsMin(int a, int b, int c, int d) { return AbsMin(AbsMin(a, b, c), d); }
        [IN(LINE)] public static int AbsMin(int a, int b, int c, int d, int e) { return AbsMin(AbsMin(a, b, c, d), e); }
        [IN(LINE)] public static int AbsMin(int a, int b, int c, int d, int e, int f) { return AbsMin(AbsMin(a, b, c, d, e), f); }
        [IN(LINE)] public static int AbsMin(int a, int b, int c, int d, int e, int f, int g) { return AbsMin(AbsMin(a, b, c, d, e, f), g); }
        [IN(LINE)] public static int AbsMin(int a, int b, int c, int d, int e, int f, int g, int h) { return AbsMin(AbsMin(a, b, c, d, e, f, g), h); }

        // overloads (vectorN args)
        [IN(LINE)]
        public static int Max<T>(T a, int _ = default) where T : IVectorN<int>
        {
            switch (a.count)
            {
                case 0: Throw.ZeroLengthArgument(nameof(a)); break;
                case 1: return a[0];
                case 2: return Max(a[0], a[1]);
                case 3: return Max(a[0], a[1], a[2]);
                case 4: return Max(a[0], a[1], a[2], a[3]);
                default:
                    var result = a[0];
                    for (int i = 1; i < a.count; i++)
                    {
                        result = Max(result, a[i]);
                    }
                    return result;
            }
            return default;
        }
        [IN(LINE)]
        public static int AbsMax<T>(T a, int _ = default) where T : IVectorN<int>
        {
            switch (a.count)
            {
                case 0: Throw.ZeroLengthArgument(nameof(a)); break;
                case 1: return a[0];
                case 2: return AbsMax(a[0], a[1]);
                case 3: return AbsMax(a[0], a[1], a[2]);
                case 4: return AbsMax(a[0], a[1], a[2], a[3]);
                default:
                    var result = a[0];
                    for (int i = 1; i < a.count; i++)
                    {
                        result = AbsMax(result, a[i]);
                    }
                    return result;
            }
            return default;
        }
        [IN(LINE)]
        public static int Min<T>(T a, int _ = default) where T : IVectorN<int>
        {
            switch (a.count)
            {
                case 0: Throw.ZeroLengthArgument(nameof(a)); break;
                case 1: return a[0];
                case 2: return Min(a[0], a[1]);
                case 3: return Min(a[0], a[1], a[2]);
                case 4: return Min(a[0], a[1], a[2], a[3]);
                default:
                    var result = a[0];
                    for (int i = 1; i < a.count; i++)
                    {
                        result = Min(result, a[i]);
                    }
                    return result;
            }
            return default;
        }
        [IN(LINE)]
        public static int AbsMin<T>(T a, int _ = default) where T : IVectorN<int>
        {
            switch (a.count)
            {
                case 0: Throw.ZeroLengthArgument(nameof(a)); break;
                case 1: return a[0];
                case 2: return AbsMin(a[0], a[1]);
                case 3: return AbsMin(a[0], a[1], a[2]);
                case 4: return AbsMin(a[0], a[1], a[2], a[3]);
                default:
                    var result = a[0];
                    for (int i = 1; i < a.count; i++)
                    {
                        result = AbsMin(result, a[i]);
                    }
                    return result;
            }
            return default;
        }

        [IN(LINE)] public static int Sum(int2 a) { return a.x + a.y; }
        [IN(LINE)] public static int Sum(int3 a) { return a.x + a.y + a.z; }
        [IN(LINE)] public static int Sum(int4 a) { return a.x + a.y + a.z + a.w; }
        [IN(LINE)]
        public static int Sum<T>(T a, int _ = default) where T : IVectorN<int>
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
        [IN(LINE)] public static uint UHash<TVector>(TVector v, int _ = default) where TVector : IVectorN<int> { return unchecked((uint)Hash<TVector>(v)); }
        [IN(LINE)]
        public static int Hash<TVector>(TVector v, int _ = default) where TVector : IVectorN<int>
        {
            int bits = 0;
            for (int i = 0; i < v.count; i++)
            {
                bits ^= Hash(v[i]);
            }
            return bits;
        }
        #endregion
    }

    public static partial class DMBits // int
    {
        [IN(LINE)] public static int CountBits(int a) { unchecked { return InternalBits.CountBits((uint)a); } }
    }
}
