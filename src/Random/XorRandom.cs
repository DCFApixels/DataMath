using System;
using static DCFApixels.DataMath.RandomUtility;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    [Serializable]
    public struct XorRandom :
        IEquatable<XorRandom>, 
        IFormattable, 
        IReadOnlyVectorN<uint>
    {
        private uint _state;

        int IReadOnlyVectorN<uint>.length => 1;

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
        #endregion

        #region Uint
        [IN(LINE)]
        public uint NextUInt()
        {
            _state = NextXorShiftState(_state);
            return _state;
        }
        public uint NextUInt(int max)
        {
            return CompresseU32(NextUInt(), max);
        }
        public uint NextUInt(int min, int max)
        {
            ulong range = (ulong)(max - min);
            return CompresseU32(NextUInt(), min, range);
        }

        public uint2 NextUInt2()
        {
            return new uint2(
                NextUInt(),
                NextUInt());
        }
        public uint2 NextUInt2(int max)
        {
            return new uint2(
                CompresseU32(NextUInt(), max),
                CompresseU32(NextUInt(), max));
        }
        public uint2 NextUInt2(int min, int max)
        {
            ulong range = (ulong)(max - min);
            return new uint2(
                CompresseU32(NextUInt(), min, range),
                CompresseU32(NextUInt(), min, range));
        }

        public uint3 NextUInt3()
        {
            return new uint3(
                NextUInt(),
                NextUInt(),
                NextUInt());
        }
        public uint3 NextUInt3(int max)
        {
            return new uint3(
                CompresseU32(NextUInt(), max),
                CompresseU32(NextUInt(), max),
                CompresseU32(NextUInt(), max));
        }
        public uint3 NextUInt3(int min, int max)
        {
            ulong range = (ulong)(max - min);
            return new uint3(
                CompresseU32(NextUInt(), min, range),
                CompresseU32(NextUInt(), min, range),
                CompresseU32(NextUInt(), min, range));
        }

        public uint4 NextUInt4()
        {
            return new uint4(
                NextUInt(),
                NextUInt(),
                NextUInt(),
                NextUInt());
        }
        public uint4 NextUInt4(int max)
        {
            return new uint4(
                CompresseU32(NextUInt(), max),
                CompresseU32(NextUInt(), max),
                CompresseU32(NextUInt(), max),
                CompresseU32(NextUInt(), max));
        }
        public uint4 NextUInt4(int min, int max)
        {
            ulong range = (ulong)(max - min);
            return new uint4(
                CompresseU32(NextUInt(), min, range),
                CompresseU32(NextUInt(), min, range),
                CompresseU32(NextUInt(), min, range),
                CompresseU32(NextUInt(), min, range));
        }
        #endregion

        #region Long
        [IN(LINE)]
        public long NextLong()
        {
            return (long)((ulong)NextUInt() << 32) ^ NextUInt();
        }
        #endregion

        #region ULong
        [IN(LINE)]
        public ulong NextULong()
        {
            return ((ulong)NextUInt() << 32) ^ NextUInt();
        }
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
        [IN(LINE)]
        public override int GetHashCode() => (int)_state;

        [IN(LINE)]
        public override bool Equals(object o) => o is XorRandom target && Equals(target);

        [IN(LINE)]
        public bool Equals(XorRandom a) => a._state == _state;

        [IN(LINE)]
        public override string ToString() => $"{nameof(XorRandom)}({_state})";
        [IN(LINE)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"{nameof(XorRandom)}({_state.ToString(format, formatProvider)})";
        }
        #endregion
    }
}
