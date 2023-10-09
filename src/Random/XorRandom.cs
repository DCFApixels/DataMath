using System;
using static DCFApixels.DataMath.Consts;
using static DCFApixels.DataMath.RandomUtility;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    [Serializable]
    public struct XorRandom :
        IEquatable<XorRandom>, 
        IFormattable
    {
        private uint _state;

        #region Constructors
        [IN(LINE)]
        public XorRandom(int seed)
        {
            _state = (uint)seed;
        }
        [IN(LINE)]
        public XorRandom(uint seed)
        {
            _state = seed;
        }
        public static XorRandom AutoSeed()
        {
            return new XorRandom(GetAutoSeeed());
        }
        #endregion


        #region Int

        #region 1
        [IN(LINE)]
        public int NextInt()
        {
            _state = NextXorShiftState(_state);
            return (int)_state;
        }
        public int NextInt(int max)
        {
            return Compresse32(NextUInt(), max);
        }
        public int NextInt(int min, int max)
        {
            ulong range = (ulong)(max - min);
            return Compresse32(NextUInt(), min, range);
        }
        #endregion

        #region 2
        public int2 NextInt2()
        {
            return new int2(
                NextInt(),
                NextInt());
        }
        public int2 NextInt2(int max)
        {
            return new int2(
                Compresse32(NextUInt(), max),
                Compresse32(NextUInt(), max));
        }
        public int2 NextInt2(int min, int max)
        {
            ulong range = (ulong)(max - min);
            return new int2(
                Compresse32(NextUInt(), min, range),
                Compresse32(NextUInt(), min, range));
        }
        public int2 NextInt2(int2 max)
        {
            return new int2(
                Compresse32(NextUInt(), max.x),
                Compresse32(NextUInt(), max.y));
        }
        public int2 NextInt2(int2 min, int2 max)
        {
            int2 range = max - min;
            return new int2(
                Compresse32(NextUInt(), min.x, (ulong)range.x),
                Compresse32(NextUInt(), min.y, (ulong)range.y));
        }
        #endregion

        #region 3
        public int3 NextInt3()
        {
            return new int3(
                NextInt(),
                NextInt(),
                NextInt());
        }
        public int3 NextInt3(int max)
        {
            return new int3(
                Compresse32(NextUInt(), max),
                Compresse32(NextUInt(), max),
                Compresse32(NextUInt(), max));
        }
        public int3 NextInt3(int min, int max)
        {
            ulong range = (ulong)(max - min);
            return new int3(
                Compresse32(NextUInt(), min, range),
                Compresse32(NextUInt(), min, range),
                Compresse32(NextUInt(), min, range));
        }
        public int3 NextInt3(int3 max)
        {
            return new int3(
                Compresse32(NextUInt(), max.x),
                Compresse32(NextUInt(), max.y),
                Compresse32(NextUInt(), max.z));
        }
        public int3 NextInt3(int3 min, int3 max)
        {
            int3 range = max - min;
            return new int3(
                Compresse32(NextUInt(), min.x, (ulong)range.x),
                Compresse32(NextUInt(), min.y, (ulong)range.y),
                Compresse32(NextUInt(), min.z, (ulong)range.z));
        }
        #endregion

        #region 4
        public int4 NextInt4()
        {
            return new int4(
                NextInt(),
                NextInt(),
                NextInt(),
                NextInt());
        }
        public int4 NextInt4(int max)
        {
            return new int4(
                Compresse32(NextUInt(), max),
                Compresse32(NextUInt(), max),
                Compresse32(NextUInt(), max),
                Compresse32(NextUInt(), max));
        }
        public int4 NextInt4(int min, int max)
        {
            ulong range = (ulong)(max - min);
            return new int4(
                Compresse32(NextUInt(), min, range),
                Compresse32(NextUInt(), min, range),
                Compresse32(NextUInt(), min, range),
                Compresse32(NextUInt(), min, range));
        }
        public int4 NextInt3(int4 max)
        {
            return new int4(
                Compresse32(NextUInt(), max.x),
                Compresse32(NextUInt(), max.y),
                Compresse32(NextUInt(), max.z),
                Compresse32(NextUInt(), max.w));
        }
        public int4 NextInt3(int4 min, int4 max)
        {
            int4 range = max - min;
            return new int4(
                Compresse32(NextUInt(), min.x, (ulong)range.x),
                Compresse32(NextUInt(), min.y, (ulong)range.y),
                Compresse32(NextUInt(), min.z, (ulong)range.z),
                Compresse32(NextUInt(), min.w, (ulong)range.w));
        }
        #endregion

        #endregion

        #region Uint

        #region 1
        [IN(LINE)]
        public uint NextUInt()
        {
            _state = NextXorShiftState(_state);
            return _state;
        }
        public uint NextUInt(uint max)
        {
            return CompresseU32(NextUInt(), max);
        }
        public uint NextUInt(uint min, uint max)
        {
            ulong range = max - min;
            return CompresseU32(NextUInt(), min, range);
        }
        #endregion

        #region 2
        public uint2 NextUInt2()
        {
            return new uint2(
                NextUInt(),
                NextUInt());
        }
        public uint2 NextUInt2(uint max)
        {
            return new uint2(
                CompresseU32(NextUInt(), max),
                CompresseU32(NextUInt(), max));
        }
        public uint2 NextUInt2(uint min, uint max)
        {
            ulong range = max - min;
            return new uint2(
                CompresseU32(NextUInt(), min, range),
                CompresseU32(NextUInt(), min, range));
        }
        public uint2 NextInt2(uint2 max)
        {
            return new uint2(
                CompresseU32(NextUInt(), max.x),
                CompresseU32(NextUInt(), max.y));
        }
        public uint2 NextInt2(uint2 min, uint2 max)
        {
            uint2 range = max - min;
            return new uint2(
                CompresseU32(NextUInt(), min.x, range.x),
                CompresseU32(NextUInt(), min.y, range.y));
        }
        #endregion

        #region 3
        public uint3 NextUInt3()
        {
            return new uint3(
                NextUInt(),
                NextUInt(),
                NextUInt());
        }
        public uint3 NextUInt3(uint max)
        {
            return new uint3(
                CompresseU32(NextUInt(), max),
                CompresseU32(NextUInt(), max),
                CompresseU32(NextUInt(), max));
        }
        public uint3 NextUInt3(uint min, uint max)
        {
            ulong range = max - min;
            return new uint3(
                CompresseU32(NextUInt(), min, range),
                CompresseU32(NextUInt(), min, range),
                CompresseU32(NextUInt(), min, range));
        }
        public uint3 NextUInt3(uint3 max)
        {
            return new uint3(
                CompresseU32(NextUInt(), max.x),
                CompresseU32(NextUInt(), max.y),
                CompresseU32(NextUInt(), max.z));
        }
        public uint3 NextUInt3(uint3 min, uint3 max)
        {
            uint3 range = max - min;
            return new uint3(
                CompresseU32(NextUInt(), min.x, range.x),
                CompresseU32(NextUInt(), min.y, range.y),
                CompresseU32(NextUInt(), min.z, range.z));
        }
        #endregion

        #region 4
        public uint4 NextUInt4()
        {
            return new uint4(
                NextUInt(),
                NextUInt(),
                NextUInt(),
                NextUInt());
        }
        public uint4 NextUInt4(uint max)
        {
            return new uint4(
                CompresseU32(NextUInt(), max),
                CompresseU32(NextUInt(), max),
                CompresseU32(NextUInt(), max),
                CompresseU32(NextUInt(), max));
        }
        public uint4 NextUInt4(uint min, uint max)
        {
            ulong range = max - min;
            return new uint4(
                CompresseU32(NextUInt(), min, range),
                CompresseU32(NextUInt(), min, range),
                CompresseU32(NextUInt(), min, range),
                CompresseU32(NextUInt(), min, range));
        }
        public uint4 NextUInt4(uint4 max)
        {
            return new uint4(
                CompresseU32(NextUInt(), max.x),
                CompresseU32(NextUInt(), max.y),
                CompresseU32(NextUInt(), max.z),
                CompresseU32(NextUInt(), max.w));
        }
        public uint4 NextUInt4(uint4 min, uint4 max)
        {
            uint4 range = max - min;
            return new uint4(
                CompresseU32(NextUInt(), min.x, range.x),
                CompresseU32(NextUInt(), min.y, range.y),
                CompresseU32(NextUInt(), min.z, range.z),
                CompresseU32(NextUInt(), min.w, range.w));
        }
        #endregion

        #endregion

        #region Long
        [IN(LINE)] public long NextLong() => (long)((ulong)NextUInt() << 32) ^ NextUInt();
        [IN(LINE)] public long NextLong(long max) => (long)NextULong() % max;
        [IN(LINE)] public long NextLong(long min, long max) => (long)NextULong() % (max - min) + min;
        #endregion

        #region ULong
        [IN(LINE)] public ulong NextULong() => ((ulong)NextUInt() << 32) ^ NextUInt();
        [IN(LINE)] public ulong NextULong(ulong max) => NextULong() % max;
        [IN(LINE)] public ulong NextULong(ulong min, ulong max) => NextULong() % max - min + min;
        #endregion

        #region Float
        [IN(LINE)]
        public float NextFloat()
        {
            return Q32ToFloat(NextUInt());
        }
        public float2 NextFloat2()
        {
            return new float2(
                NextFloat(),
                NextFloat());
        }
        public float3 NextFloat3()
        {
            return new float3(
                NextFloat(),
                NextFloat(),
                NextFloat());
        }
        public float4 NextFloat4()
        {
            return new float4(
                NextFloat(),
                NextFloat(),
                NextFloat(),
                NextFloat());
        }
        #endregion

        #region Double
        [IN(LINE)]
        public double NextDouble()
        {
            return (0x3ff0000000000000 | ( ((ulong)NextUInt() << 20) ^ NextUInt()) ) - 1d;
        }
        public double2 NextDouble2()
        {
            return new double2(
                NextDouble(),
                NextDouble());
        }
        public double3 NextDouble3()
        {
            return new double3(
                NextDouble(),
                NextDouble(),
                NextDouble());
        }
        public double4 NextDouble4()
        {
            return new double4(
                NextDouble(),
                NextDouble(),
                NextDouble(),
                NextDouble());
        }
        #endregion


        #region Other
        [IN(LINE)] public override int GetHashCode() => (int)_state;
        [IN(LINE)] public override bool Equals(object o) => o is XorRandom target && Equals(target);
        [IN(LINE)] public bool Equals(XorRandom a) => a._state == _state;
        [IN(LINE)] public override string ToString() => $"{nameof(XorRandom)}({_state})";
        [IN(LINE)] 
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"{nameof(XorRandom)}({_state.ToString(format, formatProvider)})";
        }
        #endregion
    }
}
