using System;
using static DCFApixels.DataMath.DMRnd;
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    /// <summary>Sobol quasi-random low-discrepancy generator for one to four dimensions. State is the point index.</summary>
    [Serializable]
    public struct SobolRandom :
        IRandom4,
        IEquatable<SobolRandom>,
        IFormattable
    {
        private const double U32ToDouble = 1d / 4294967296d;

        private uint _index;
        private uint4 _state;

        public uint State
        {
            [IN(LINE)] get { return _index; }
            [IN(LINE)] set
            {
                _index = value;
                _state = GetState(value);
            }
        }

        #region Constructors
        [IN(LINE)]
        public SobolRandom(int seed)
        {
            _index = (uint)seed;
            _state = GetState(_index);
        }
        [IN(LINE)]
        public SobolRandom(uint seed)
        {
            _index = seed;
            _state = GetState(_index);
        }
        public static SobolRandom AutoSeed(uint offset = 0)
        {
            return new SobolRandom(NewAutoSeed() + offset);
        }
        #endregion

        #region Math
        [IN(LINE)]
        private static uint4 GetState(uint index)
        {
            uint gray = index ^ (index >> 1);
            uint x = 0u;
            uint y = 0u;
            uint z = 0u;
            uint w = 0u;

            int bit = 0;
            while (gray != 0u)
            {
                if ((gray & 1u) != 0u)
                {
                    x ^= Direction0(bit);
                    y ^= Direction1(bit);
                    z ^= Direction2(bit);
                    w ^= Direction3(bit);
                }
                gray >>= 1;
                bit++;
            }

            return new uint4(x, y, z, w);
        }
        [IN(LINE)]
        private uint4 NextState()
        {
            int bit = FirstZeroBit(_index);
            _index++;

            if (_index == 0u)
            {
                _state = default;
                return _state;
            }

            _state = new uint4(
                _state.x ^ Direction0(bit),
                _state.y ^ Direction1(bit),
                _state.z ^ Direction2(bit),
                _state.w ^ Direction3(bit));
            return _state;
        }
        [IN(LINE)]
        private static int FirstZeroBit(uint value)
        {
            int bit = 0;
            while ((value & 1u) != 0u)
            {
                value >>= 1;
                bit++;
            }
            return bit;
        }
        [IN(LINE)] private static uint Direction0(int bit) { return 1u << (31 - bit); }
        [IN(LINE)]
        private static uint Direction1(int bit)
        {
            uint v0 = 0x80000000u;
            for (int i = 1; i <= bit; i++) { v0 ^= v0 >> 1; }
            return v0;
        }
        [IN(LINE)]
        private static uint Direction2(int bit)
        {
            uint v0 = 0x80000000u;
            uint v1 = 0xC0000000u;
            if (bit == 0) { return v0; }
            if (bit == 1) { return v1; }

            for (int i = 2; i <= bit; i++)
            {
                uint next = v0 ^ (v0 >> 2) ^ v1;
                v0 = v1;
                v1 = next;
            }
            return v1;
        }
        [IN(LINE)]
        private static uint Direction3(int bit)
        {
            uint v0 = 0x80000000u;
            uint v1 = 0xC0000000u;
            uint v2 = 0x20000000u;
            if (bit == 0) { return v0; }
            if (bit == 1) { return v1; }
            if (bit == 2) { return v2; }

            for (int i = 3; i <= bit; i++)
            {
                uint next = v0 ^ (v0 >> 3) ^ v1;
                v0 = v1;
                v1 = v2;
                v2 = next;
            }
            return v2;
        }
        [IN(LINE)] private static double U32ToDouble01(uint value) { return value * U32ToDouble; }
        #endregion

        #region Int

        #region 1
        [IN(LINE)] public int NextInt() { return (int)NextState().x; }
        [IN(LINE)] public int NextInt(int max) { return Compresse32(NextState().x, max); }
        [IN(LINE)] public int NextInt(int min, int max) { return Compresse32(NextState().x, min, (ulong)(max - min)); }
        #endregion

        #region 2
        public int2 NextInt2()
        {
            uint4 s = NextState();
            return new int2((int)s.x, (int)s.y);
        }
        public int2 NextInt2(int max)
        {
            uint4 s = NextState();
            return new int2(Compresse32(s.x, max), Compresse32(s.y, max));
        }
        public int2 NextInt2(int min, int max)
        {
            uint4 s = NextState();
            ulong range = (ulong)(max - min);
            return new int2(Compresse32(s.x, min, range), Compresse32(s.y, min, range));
        }
        public int2 NextInt2(int2 max)
        {
            uint4 s = NextState();
            return new int2(Compresse32(s.x, max.x), Compresse32(s.y, max.y));
        }
        public int2 NextInt2(int2 min, int2 max)
        {
            uint4 s = NextState();
            int2 range = max - min;
            return new int2(Compresse32(s.x, min.x, (ulong)range.x), Compresse32(s.y, min.y, (ulong)range.y));
        }
        #endregion

        #region 3
        public int3 NextInt3()
        {
            uint4 s = NextState();
            return new int3((int)s.x, (int)s.y, (int)s.z);
        }
        public int3 NextInt3(int max)
        {
            uint4 s = NextState();
            return new int3(Compresse32(s.x, max), Compresse32(s.y, max), Compresse32(s.z, max));
        }
        public int3 NextInt3(int min, int max)
        {
            uint4 s = NextState();
            ulong range = (ulong)(max - min);
            return new int3(Compresse32(s.x, min, range), Compresse32(s.y, min, range), Compresse32(s.z, min, range));
        }
        public int3 NextInt3(int3 max)
        {
            uint4 s = NextState();
            return new int3(Compresse32(s.x, max.x), Compresse32(s.y, max.y), Compresse32(s.z, max.z));
        }
        public int3 NextInt3(int3 min, int3 max)
        {
            uint4 s = NextState();
            int3 range = max - min;
            return new int3(Compresse32(s.x, min.x, (ulong)range.x), Compresse32(s.y, min.y, (ulong)range.y), Compresse32(s.z, min.z, (ulong)range.z));
        }
        #endregion

        #region 4
        public int4 NextInt4()
        {
            uint4 s = NextState();
            return new int4((int)s.x, (int)s.y, (int)s.z, (int)s.w);
        }
        public int4 NextInt4(int max)
        {
            uint4 s = NextState();
            return new int4(Compresse32(s.x, max), Compresse32(s.y, max), Compresse32(s.z, max), Compresse32(s.w, max));
        }
        public int4 NextInt4(int min, int max)
        {
            uint4 s = NextState();
            ulong range = (ulong)(max - min);
            return new int4(Compresse32(s.x, min, range), Compresse32(s.y, min, range), Compresse32(s.z, min, range), Compresse32(s.w, min, range));
        }
        public int4 NextInt4(int4 max)
        {
            uint4 s = NextState();
            return new int4(Compresse32(s.x, max.x), Compresse32(s.y, max.y), Compresse32(s.z, max.z), Compresse32(s.w, max.w));
        }
        public int4 NextInt4(int4 min, int4 max)
        {
            uint4 s = NextState();
            int4 range = max - min;
            return new int4(Compresse32(s.x, min.x, (ulong)range.x), Compresse32(s.y, min.y, (ulong)range.y), Compresse32(s.z, min.z, (ulong)range.z), Compresse32(s.w, min.w, (ulong)range.w));
        }
        #endregion

        #endregion

        #region UInt

        #region 1
        [IN(LINE)] public uint NextUInt() { return NextState().x; }
        [IN(LINE)] public uint NextUInt(uint max) { return CompresseU32(NextState().x, max); }
        [IN(LINE)] public uint NextUInt(uint min, uint max) { return CompresseU32(NextState().x, min, max - min); }
        #endregion

        #region 2
        public uint2 NextUInt2()
        {
            uint4 s = NextState();
            return new uint2(s.x, s.y);
        }
        public uint2 NextUInt2(uint max)
        {
            uint4 s = NextState();
            return new uint2(CompresseU32(s.x, max), CompresseU32(s.y, max));
        }
        public uint2 NextUInt2(uint min, uint max)
        {
            uint4 s = NextState();
            ulong range = max - min;
            return new uint2(CompresseU32(s.x, min, range), CompresseU32(s.y, min, range));
        }
        public uint2 NextUInt2(uint2 max)
        {
            uint4 s = NextState();
            return new uint2(CompresseU32(s.x, max.x), CompresseU32(s.y, max.y));
        }
        public uint2 NextUInt2(uint2 min, uint2 max)
        {
            uint4 s = NextState();
            uint2 range = max - min;
            return new uint2(CompresseU32(s.x, min.x, range.x), CompresseU32(s.y, min.y, range.y));
        }
        #endregion

        #region 3
        public uint3 NextUInt3()
        {
            uint4 s = NextState();
            return new uint3(s.x, s.y, s.z);
        }
        public uint3 NextUInt3(uint max)
        {
            uint4 s = NextState();
            return new uint3(CompresseU32(s.x, max), CompresseU32(s.y, max), CompresseU32(s.z, max));
        }
        public uint3 NextUInt3(uint min, uint max)
        {
            uint4 s = NextState();
            ulong range = max - min;
            return new uint3(CompresseU32(s.x, min, range), CompresseU32(s.y, min, range), CompresseU32(s.z, min, range));
        }
        public uint3 NextUInt3(uint3 max)
        {
            uint4 s = NextState();
            return new uint3(CompresseU32(s.x, max.x), CompresseU32(s.y, max.y), CompresseU32(s.z, max.z));
        }
        public uint3 NextUInt3(uint3 min, uint3 max)
        {
            uint4 s = NextState();
            uint3 range = max - min;
            return new uint3(CompresseU32(s.x, min.x, range.x), CompresseU32(s.y, min.y, range.y), CompresseU32(s.z, min.z, range.z));
        }
        #endregion

        #region 4
        public uint4 NextUInt4()
        {
            return NextState();
        }
        public uint4 NextUInt4(uint max)
        {
            uint4 s = NextState();
            return new uint4(CompresseU32(s.x, max), CompresseU32(s.y, max), CompresseU32(s.z, max), CompresseU32(s.w, max));
        }
        public uint4 NextUInt4(uint min, uint max)
        {
            uint4 s = NextState();
            ulong range = max - min;
            return new uint4(CompresseU32(s.x, min, range), CompresseU32(s.y, min, range), CompresseU32(s.z, min, range), CompresseU32(s.w, min, range));
        }
        public uint4 NextUInt4(uint4 max)
        {
            uint4 s = NextState();
            return new uint4(CompresseU32(s.x, max.x), CompresseU32(s.y, max.y), CompresseU32(s.z, max.z), CompresseU32(s.w, max.w));
        }
        public uint4 NextUInt4(uint4 min, uint4 max)
        {
            uint4 s = NextState();
            uint4 range = max - min;
            return new uint4(CompresseU32(s.x, min.x, range.x), CompresseU32(s.y, min.y, range.y), CompresseU32(s.z, min.z, range.z), CompresseU32(s.w, min.w, range.w));
        }
        #endregion

        #endregion

        #region Long
        [IN(LINE)] public long NextLong() { return (long)NextULong(); }
        [IN(LINE)] public long NextLong(long max) { return (long)(NextULong() % (ulong)max); }
        [IN(LINE)] public long NextLong(long min, long max) { return (long)(NextULong() % (ulong)(max - min)) + min; }
        #endregion

        #region ULong
        [IN(LINE)]
        public ulong NextULong()
        {
            uint4 s = NextState();
            return ((ulong)s.x << 32) ^ s.y;
        }
        [IN(LINE)] public ulong NextULong(ulong max) { return NextULong() % max; }
        [IN(LINE)] public ulong NextULong(ulong min, ulong max) { return NextULong() % (max - min) + min; }
        #endregion

        #region Float

        #region 1
        [IN(LINE)] public float NextFloat() { return Q32ToFloat(NextState().x); }
        [IN(LINE)] public float NextFloat(float max) { return NextFloat() * max; }
        [IN(LINE)] public float NextFloat(float min, float max) { return NextFloat() * (max - min) + min; }
        #endregion

        #region 2
        public float2 NextFloat2()
        {
            uint4 s = NextState();
            return new float2(Q32ToFloat(s.x), Q32ToFloat(s.y));
        }
        [IN(LINE)] public float2 NextFloat2(float max) { return NextFloat2() * max; }
        [IN(LINE)] public float2 NextFloat2(float min, float max) { return NextFloat2() * (max - min) + min; }
        [IN(LINE)] public float2 NextFloat2(float2 max) { return NextFloat2() * max; }
        [IN(LINE)] public float2 NextFloat2(float2 min, float2 max) { return NextFloat2() * (max - min) + min; }
        #endregion

        #region 3
        public float3 NextFloat3()
        {
            uint4 s = NextState();
            return new float3(Q32ToFloat(s.x), Q32ToFloat(s.y), Q32ToFloat(s.z));
        }
        [IN(LINE)] public float3 NextFloat3(float max) { return NextFloat3() * max; }
        [IN(LINE)] public float3 NextFloat3(float min, float max) { return NextFloat3() * (max - min) + min; }
        [IN(LINE)] public float3 NextFloat3(float3 max) { return NextFloat3() * max; }
        [IN(LINE)] public float3 NextFloat3(float3 min, float3 max) { return NextFloat3() * (max - min) + min; }
        #endregion

        #region 4
        public float4 NextFloat4()
        {
            uint4 s = NextState();
            return new float4(Q32ToFloat(s.x), Q32ToFloat(s.y), Q32ToFloat(s.z), Q32ToFloat(s.w));
        }
        [IN(LINE)] public float4 NextFloat4(float max) { return NextFloat4() * max; }
        [IN(LINE)] public float4 NextFloat4(float min, float max) { return NextFloat4() * (max - min) + min; }
        [IN(LINE)] public float4 NextFloat4(float4 max) { return NextFloat4() * max; }
        [IN(LINE)] public float4 NextFloat4(float4 min, float4 max) { return NextFloat4() * (max - min) + min; }
        #endregion

        #endregion

        #region Double

        #region 1
        [IN(LINE)] public double NextDouble() { return U32ToDouble01(NextState().x); }
        [IN(LINE)] public double NextDouble(double max) { return NextDouble() * max; }
        [IN(LINE)] public double NextDouble(double min, double max) { return NextDouble() * (max - min) + min; }
        #endregion

        #region 2
        public double2 NextDouble2()
        {
            uint4 s = NextState();
            return new double2(U32ToDouble01(s.x), U32ToDouble01(s.y));
        }
        [IN(LINE)] public double2 NextDouble2(double max) { return NextDouble2() * max; }
        [IN(LINE)] public double2 NextDouble2(double min, double max) { return NextDouble2() * (max - min) + min; }
        [IN(LINE)] public double2 NextDouble2(double2 max) { return NextDouble2() * max; }
        [IN(LINE)] public double2 NextDouble2(double2 min, double2 max) { return NextDouble2() * (max - min) + min; }
        #endregion

        #region 3
        public double3 NextDouble3()
        {
            uint4 s = NextState();
            return new double3(U32ToDouble01(s.x), U32ToDouble01(s.y), U32ToDouble01(s.z));
        }
        [IN(LINE)] public double3 NextDouble3(double max) { return NextDouble3() * max; }
        [IN(LINE)] public double3 NextDouble3(double min, double max) { return NextDouble3() * (max - min) + min; }
        [IN(LINE)] public double3 NextDouble3(double3 max) { return NextDouble3() * max; }
        [IN(LINE)] public double3 NextDouble3(double3 min, double3 max) { return NextDouble3() * (max - min) + min; }
        #endregion

        #region 4
        public double4 NextDouble4()
        {
            uint4 s = NextState();
            return new double4(U32ToDouble01(s.x), U32ToDouble01(s.y), U32ToDouble01(s.z), U32ToDouble01(s.w));
        }
        [IN(LINE)] public double4 NextDouble4(double max) { return NextDouble4() * max; }
        [IN(LINE)] public double4 NextDouble4(double min, double max) { return NextDouble4() * (max - min) + min; }
        [IN(LINE)] public double4 NextDouble4(double4 max) { return NextDouble4() * max; }
        [IN(LINE)] public double4 NextDouble4(double4 min, double4 max) { return NextDouble4() * (max - min) + min; }
        #endregion

        #endregion

        #region Other
        [IN(LINE)] public override int GetHashCode() { return (int)_index; }
        [IN(LINE)] public override bool Equals(object o) { return o is SobolRandom target && Equals(target); }
        [IN(LINE)] public bool Equals(SobolRandom a) { return a._index == _index; }
        [IN(LINE)] public override string ToString() { return $"{nameof(SobolRandom)}({_index})"; }
        [IN(LINE)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"{nameof(SobolRandom)}({_index.ToString(format, formatProvider)})";
        }
        #endregion
    }
}
