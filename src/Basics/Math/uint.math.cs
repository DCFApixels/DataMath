using DCFApixels.DataMath.Internal;
#if !DOTNET_FRAMEWORK || UNITY_5_3_OR_NEWER
#else
#endif
using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    //uint
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
            if (a < min) return min;
            if (a > max) return max;
            return a;
        }

        [IN(LINE)] public static uint Repeat(uint a, uint length) { return Clamp(a - ((uint)Floor(a / (float)length)) * length, 0u, length); }
        [IN(LINE)] public static uint Repeat(uint a, uint min, uint max) { return Repeat(a, max - min) + min; }

        [IN(LINE)] public static uint PingPong(uint a, uint length) { return length - Abs(Repeat(a, length * 2) - length); }
        [IN(LINE)] public static uint PingPong(uint a, uint min, uint max) { return PingPong(a, max - min) + min; }
        #endregion

        #region SmoothStep
        /// <summary> Clamps the value between from and to. </summary>
        [IN(LINE)]
        public static uint SmoothStep(uint from, uint to, uint a)
        {
            var t = Clamp01(((float)a - from) / (to - from));
            return ((uint)Floor(t * t * (3 - (2 * t))));
        }
        #endregion

        #region Min/Max
        [IN(LINE)] public static uint Max(uint a, uint b) { return a > b ? a : b; }
        [IN(LINE)] public static uint AbsMax(uint a, uint b) { return InternalMath.Abs(a) > InternalMath.Abs(b) ? a : b; }
        [IN(LINE)] public static uint Min(uint a, uint b) { return a < b ? a : b; }
        [IN(LINE)] public static uint AbsMin(uint a, uint b) { return InternalMath.Abs(a) < InternalMath.Abs(b) ? a : b; }
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
            value = CeilPow2(value);
            uint floor = value >> 1;
            if (value - floor < value - value)
            {
                return floor;
            }
            return value;
        }
        [IN(LINE)] public static bool IsPow2(uint value) { return (value & (value - 1)) == 0; }
        #endregion

        #region Other
        [IN(LINE)] public static uint Dot(uint a, uint b) { return a * b; }
        [IN(LINE)] public static uint Select(uint falseValue, uint trueValue, bool test) { return test ? trueValue : falseValue; }
        #endregion


        #region Hash
        [IN(LINE)] public static uint UHash(uint v) { return v; }
        [IN(LINE)] public static int Hash(uint v) { return unchecked((int)v); }
        #endregion

        #region Component iteration operations
        // Max overloads (3-8 args)
        [IN(LINE)] public static uint Max(uint a, uint b, uint c) { return Max(Max(a, b), c); }
        [IN(LINE)] public static uint Max(uint a, uint b, uint c, uint d) { return Max(Max(a, b, c), d); }
        [IN(LINE)] public static uint Max(uint a, uint b, uint c, uint d, uint e) { return Max(Max(a, b, c, d), e); }
        [IN(LINE)] public static uint Max(uint a, uint b, uint c, uint d, uint e, uint f) { return Max(Max(a, b, c, d, e), f); }
        [IN(LINE)] public static uint Max(uint a, uint b, uint c, uint d, uint e, uint f, uint g) { return Max(Max(a, b, c, d, e, f), g); }
        [IN(LINE)] public static uint Max(uint a, uint b, uint c, uint d, uint e, uint f, uint g, uint h) { return Max(Max(a, b, c, d, e, f, g), h); }

        // AbsMax overloads (3-8 args)
        [IN(LINE)] public static uint AbsMax(uint a, uint b, uint c) { return AbsMax(AbsMax(a, b), c); }
        [IN(LINE)] public static uint AbsMax(uint a, uint b, uint c, uint d) { return AbsMax(AbsMax(a, b, c), d); }
        [IN(LINE)] public static uint AbsMax(uint a, uint b, uint c, uint d, uint e) { return AbsMax(AbsMax(a, b, c, d), e); }
        [IN(LINE)] public static uint AbsMax(uint a, uint b, uint c, uint d, uint e, uint f) { return AbsMax(AbsMax(a, b, c, d, e), f); }
        [IN(LINE)] public static uint AbsMax(uint a, uint b, uint c, uint d, uint e, uint f, uint g) { return AbsMax(AbsMax(a, b, c, d, e, f), g); }
        [IN(LINE)] public static uint AbsMax(uint a, uint b, uint c, uint d, uint e, uint f, uint g, uint h) { return AbsMax(AbsMax(a, b, c, d, e, f, g), h); }

        // Min overloads (3-8 args)
        [IN(LINE)] public static uint Min(uint a, uint b, uint c) { return Min(Min(a, b), c); }
        [IN(LINE)] public static uint Min(uint a, uint b, uint c, uint d) { return Min(Min(a, b, c), d); }
        [IN(LINE)] public static uint Min(uint a, uint b, uint c, uint d, uint e) { return Min(Min(a, b, c, d), e); }
        [IN(LINE)] public static uint Min(uint a, uint b, uint c, uint d, uint e, uint f) { return Min(Min(a, b, c, d, e), f); }
        [IN(LINE)] public static uint Min(uint a, uint b, uint c, uint d, uint e, uint f, uint g) { return Min(Min(a, b, c, d, e, f), g); }
        [IN(LINE)] public static uint Min(uint a, uint b, uint c, uint d, uint e, uint f, uint g, uint h) { return Min(Min(a, b, c, d, e, f, g), h); }

        // AbsMin overloads (3-8 args)
        [IN(LINE)] public static uint AbsMin(uint a, uint b, uint c) { return AbsMin(AbsMin(a, b), c); }
        [IN(LINE)] public static uint AbsMin(uint a, uint b, uint c, uint d) { return AbsMin(AbsMin(a, b, c), d); }
        [IN(LINE)] public static uint AbsMin(uint a, uint b, uint c, uint d, uint e) { return AbsMin(AbsMin(a, b, c, d), e); }
        [IN(LINE)] public static uint AbsMin(uint a, uint b, uint c, uint d, uint e, uint f) { return AbsMin(AbsMin(a, b, c, d, e), f); }
        [IN(LINE)] public static uint AbsMin(uint a, uint b, uint c, uint d, uint e, uint f, uint g) { return AbsMin(AbsMin(a, b, c, d, e, f), g); }
        [IN(LINE)] public static uint AbsMin(uint a, uint b, uint c, uint d, uint e, uint f, uint g, uint h) { return AbsMin(AbsMin(a, b, c, d, e, f, g), h); }

        // overloads (vectorN args)
        [IN(LINE)]
        public static uint Max<T>(T a, uint _ = default) where T : IVectorN<uint>
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
        public static uint AbsMax<T>(T a, uint _ = default) where T : IVectorN<uint>
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
        public static uint Min<T>(T a, uint _ = default) where T : IVectorN<uint>
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
        public static uint AbsMin<T>(T a, uint _ = default) where T : IVectorN<uint>
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

        [IN(LINE)] public static uint Sum(uint2 a) { return a.x + a.y; }
        [IN(LINE)] public static uint Sum(uint3 a) { return a.x + a.y + a.z; }
        [IN(LINE)] public static uint Sum(uint4 a) { return a.x + a.y + a.z + a.w; }
        [IN(LINE)]
        public static uint Sum<T>(T a, uint _ = default) where T : IVectorN<uint>
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
        public static uint UHash<TVector>(TVector v, uint _ = default) where TVector : IVectorN<uint>
        {
            uint bits = 0;
            for (int i = 0; i < v.count; i++)
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
        [IN(LINE)] public static int CountBits(uint a) { unchecked { return InternalBits.CountBits(a); } }
    }
}
