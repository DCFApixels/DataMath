using System;
using static DCFApixels.DataMath.RandomUtility;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;
using q32 = System.UInt32;
using q64 = System.UInt64;

namespace DCFApixels.DataMath
{
    /// <summary> Quasi Random. Use R algoritm </summary>
    [Serializable]
    public struct QuasiRandom :
        IEquatable<QuasiRandom>, 
        IFormattable, 
        IReadOnlyVectorN<uint>
    {
        #region Consts
        private const q32 Q32_MAX = q32.MaxValue;
        private const q64 Q64_MAX = q64.MaxValue;

        private const decimal G1 = 1.6180339887498948482045868383m;
        private const q32 X1_Q32 = (q32)(1m / G1 * Q32_MAX) + 1;
        private const q64 X1_Q64 = (q64)(1m / G1 * Q32_MAX) + 1;

        private const decimal G2 = 1.3247179572447460259609088563m;
        private const q32 X2_Q32 = (q32)(1m / G2 * Q32_MAX) + 1;
        private const q32 Y2_Q32 = (q32)(1m / (G2 * G2) * Q32_MAX) + 1;
        private const q64 X2_Q64 = (q64)(1m / G2 * Q64_MAX) + 1;
        private const q64 Y2_Q64 = (q64)(1m / (G2 * G2) * Q64_MAX) + 1;

        private const decimal G3 = 1.2207440846057594753616853503m;
        private const q32 X3_Q32 = (q32)(1m / G3 * Q32_MAX) + 1;
        private const q32 Y3_Q32 = (q32)(1m / (G3 * G3) * Q32_MAX) + 1;
        private const q32 Z3_Q32 = (q32)(1m / (G3 * G3 * G3) * Q32_MAX) + 1;
        private const q64 X3_Q64 = (q64)(1m / G3 * Q64_MAX) + 1;
        private const q64 Y3_Q64 = (q64)(1m / (G3 * G3) * Q64_MAX) + 1;
        private const q64 Z3_Q64 = (q64)(1m / (G3 * G3 * G3) * Q64_MAX) + 1;

        private const decimal G4 = 1.1673039782614186842560459007m;
        private const q32 X4_Q32 = (q32)(1m / G4 * Q32_MAX) + 1;
        private const q32 Y4_Q32 = (q32)(1m / (G4 * G4) * Q32_MAX) + 1;
        private const q32 Z4_Q32 = (q32)(1m / (G4 * G4 * G4) * Q32_MAX) + 1;
        private const q32 W4_Q32 = (q32)(1m / (G4 * G4 * G4 * G4) * Q32_MAX) + 1;
        private const q64 X4_Q64 = (q64)(1m / G4 * Q64_MAX) + 1;
        private const q64 Y4_Q64 = (q64)(1m / (G4 * G4) * Q64_MAX) + 1;
        private const q64 Z4_Q64 = (q64)(1m / (G4 * G4 * G4) * Q64_MAX) + 1;
        private const q64 W4_Q64 = (q64)(1m / (G4 * G4 * G4 * G4) * Q64_MAX) + 1;
        #endregion

        #region Math
        /*----------------------------------------------------------------------------------------------------------------*/

        [IN(LINE)]
        private readonly uint GetX1_Q32(uint state) => X1_Q32 * state;
        [IN(LINE)]
        private readonly ulong GetX1_Q64(uint state) => X1_Q64 * state;

        [IN(LINE)]
        private readonly float GetX1_F(uint state) => Q32ToFloat(GetX1_Q32(state));
        [IN(LINE)]
        private readonly double GetX1_D(uint state) => Q64ToDouble(GetX1_Q64(state));

        /*----------------------------------------------------------------------------------------------------------------*/

        [IN(LINE)]
        private readonly uint GetX2_Q32(uint state) => X2_Q32 * state;
        [IN(LINE)]
        private readonly uint GetY2_Q32(uint state) => Y2_Q32 * state;

        [IN(LINE)]
        private readonly ulong GetX2_Q64(uint state) => X2_Q64 * state;
        [IN(LINE)]
        private readonly ulong GetY2_Q64(uint state) => Y2_Q64 * state;

        [IN(LINE)]
        private readonly float GetX2_F(uint state) => Q32ToFloat(GetX2_Q32(state));
        [IN(LINE)]
        private readonly float GetY2_F(uint state) => Q32ToFloat(GetY2_Q32(state));

        [IN(LINE)]
        private readonly double GetX2_D(uint state) => Q64ToDouble(GetX2_Q64(state));
        [IN(LINE)]
        private readonly double GetY2_D(uint state) => Q64ToDouble(GetY2_Q64(state));

        /*----------------------------------------------------------------------------------------------------------------*/

        [IN(LINE)]
        private readonly uint GetX3_Q32(uint state) => X3_Q32 * state;
        [IN(LINE)]
        private readonly uint GetY3_Q32(uint state) => Y3_Q32 * state;
        [IN(LINE)]
        private readonly uint GetZ3_Q32(uint state) => Z3_Q32 * state;

        [IN(LINE)]
        private readonly ulong GetX3_Q64(uint state) => X3_Q64 * state;
        [IN(LINE)]
        private readonly ulong GetY3_Q64(uint state) => Y3_Q64 * state;
        [IN(LINE)]
        private readonly ulong GetZ3_Q64(uint state) => Z3_Q64 * state;

        [IN(LINE)]
        private readonly float GetX3_F(uint state) => Q32ToFloat(GetX3_Q32(state));
        [IN(LINE)]
        private readonly float GetY3_F(uint state) => Q32ToFloat(GetY3_Q32(state));
        [IN(LINE)]
        private readonly float GetZ3_F(uint state) => Q32ToFloat(GetZ3_Q32(state));

        [IN(LINE)]
        private readonly double GetX3_D(uint state) => Q64ToDouble(GetX3_Q64(state));
        [IN(LINE)]
        private readonly double GetY3_D(uint state) => Q64ToDouble(GetY3_Q64(state));
        [IN(LINE)]
        private readonly double GetZ3_D(uint state) => Q64ToDouble(GetZ3_Q64(state));

        /*----------------------------------------------------------------------------------------------------------------*/

        [IN(LINE)]
        private readonly uint GetX4_Q32(uint state) => X4_Q32 * state;
        [IN(LINE)]
        private readonly uint GetY4_Q32(uint state) => Y4_Q32 * state;
        [IN(LINE)]
        private readonly uint GetZ4_Q32(uint state) => Z4_Q32 * state;
        [IN(LINE)]
        private readonly uint GetW4_Q32(uint state) => W4_Q32 * state;

        [IN(LINE)]
        private readonly ulong GetX4_Q64(uint state) => X4_Q64 * state;
        [IN(LINE)]
        private readonly ulong GetY4_Q64(uint state) => Y4_Q64 * state;
        [IN(LINE)]
        private readonly ulong GetZ4_Q64(uint state) => Z4_Q64 * state;
        [IN(LINE)]
        private readonly ulong GetW4_Q64(uint state) => W4_Q64 * state;

        [IN(LINE)]
        private readonly float GetX4_F(uint state) => Q32ToFloat(GetX4_Q32(state));
        [IN(LINE)]
        private readonly float GetY4_F(uint state) => Q32ToFloat(GetY4_Q32(state));
        [IN(LINE)]
        private readonly float GetZ4_F(uint state) => Q32ToFloat(GetZ4_Q32(state));
        [IN(LINE)]
        private readonly float GetW4_F(uint state) => Q32ToFloat(GetW4_Q32(state));

        [IN(LINE)]
        private readonly double GetX4_D(uint state) => Q64ToDouble(GetX4_Q64(state));
        [IN(LINE)]
        private readonly double GetY4_D(uint state) => Q64ToDouble(GetY4_Q64(state));
        [IN(LINE)]
        private readonly double GetZ4_D(uint state) => Q64ToDouble(GetZ4_Q64(state));
        [IN(LINE)]
        private readonly double GetW4_D(uint state) => Q64ToDouble(GetW4_Q64(state));

        /*----------------------------------------------------------------------------------------------------------------*/
        #endregion

        private uint _state;
        int IReadOnlyVectorN<uint>.length => 1;

        #region Constructors
        [IN(LINE)]
        public QuasiRandom(int seed)
        {
            _state = (uint)seed;
        }
        [IN(LINE)]
        public QuasiRandom(uint seed)
        {
            _state = seed;
        }
        public static QuasiRandom AutoSeed()
        {
            return new QuasiRandom(GetAutoSeeed());
        }
        #endregion


        #region Int
        [IN(LINE)]
        public int NextInt()
        {
            return (int)GetX1_Q32(++_state);
        }
        [IN(LINE)]
        public int NextInt(int max)
        {
            return Compresse32(GetX1_Q32(++_state), max);
        }
        [IN(LINE)]
        public int NextInt(int min, int max)
        {
            return Compresse32(GetX1_Q32(++_state), min, (ulong)(max - min));
        }

        public int2 NextInt2()
        {
            return new int2(
                    (int)GetX2_Q32(++_state),
                    (int)GetY2_Q32(_state));
        }
        public int2 NextInt2(int max)
        {
            return new int2(
                    Compresse32(GetX2_Q32(++_state), max),
                    Compresse32(GetY2_Q32(_state), max));
        }
        public int2 NextInt2(int min, int max)
        {
            ulong range = (ulong)(max - min);
            return new int2(
                    Compresse32(GetX2_Q32(++_state), min, range),
                    Compresse32(GetY2_Q32(_state), min, range));
        }

        public int3 NextInt3()
        {
            return new int3(
                    (int)GetX3_Q32(++_state),
                    (int)GetY3_Q32(_state),
                    (int)GetZ3_Q32(_state));
        }
        public int3 NextInt3(int max)
        {
            return new int3(
                    Compresse32(GetX3_Q32(++_state), max),
                    Compresse32(GetY3_Q32(_state), max),
                    Compresse32(GetZ3_Q32(_state), max));
        }
        public int3 NextInt3(int min, int max)
        {
            ulong range = (ulong)(max - min);
            return new int3(
                    Compresse32(GetX3_Q32(++_state), min, range),
                    Compresse32(GetY3_Q32(_state), min, range),
                    Compresse32(GetZ3_Q32(_state), min, range));
        }

        public int4 NextInt4()
        {
            return new int4(
                    (int)GetX4_Q32(++_state),
                    (int)GetY4_Q32(_state),
                    (int)GetZ4_Q32(_state),
                    (int)GetW4_Q32(_state));
        }
        public int4 NextInt4(int max)
        {
            return new int4(
                    Compresse32(GetX4_Q32(++_state), max),
                    Compresse32(GetY4_Q32(_state), max),
                    Compresse32(GetZ4_Q32(_state), max),
                    Compresse32(GetW4_Q32(_state), max));
        }
        public int4 NextInt4(int min, int max)
        {
            ulong range = (ulong)(max - min);
            return new int4(
                    Compresse32(GetX4_Q32(++_state), min, range),
                    Compresse32(GetY4_Q32(_state), min, range),
                    Compresse32(GetZ4_Q32(_state), min, range),
                    Compresse32(GetW4_Q32(_state), min, range));
        }
        #endregion

        #region UInt
        [IN(LINE)]
        public uint NextUInt()
        {
            return GetX1_Q32(++_state);
        }
        [IN(LINE)]
        public uint NextUInt(int max)
        {
            return CompresseU32(GetX1_Q32(++_state), max);
        }
        [IN(LINE)]
        public uint NextUInt(int min, int max)
        {
            return CompresseU32(GetX1_Q32(++_state), min, (ulong)(max - min));
        }

        public uint2 NextUInt2()
        {
            return new uint2(
                    GetX2_Q32(++_state),
                    GetY2_Q32(_state));
        }
        public uint2 NextUInt2(int max)
        {
            return new uint2(
                    CompresseU32(GetX2_Q32(++_state), max),
                    CompresseU32(GetY2_Q32(_state), max));
        }
        public uint2 NextUInt2(int min, int max)
        {
            ulong range = (ulong)(max - min);
            return new uint2(
                    CompresseU32(GetX2_Q32(++_state), min, range),
                    CompresseU32(GetY2_Q32(_state), min, range));
        }

        public uint3 NextUInt3()
        {
            return new uint3(
                    GetX3_Q32(++_state),
                    GetY3_Q32(_state),
                    GetZ3_Q32(_state));
        }
        public uint3 NextUInt3(int max)
        {
            return new uint3(
                    CompresseU32(GetX3_Q32(++_state), max),
                    CompresseU32(GetY3_Q32(_state), max),
                    CompresseU32(GetZ3_Q32(_state), max));
        }
        public uint3 NextUInt3(int min, int max)
        {
            ulong range = (ulong)(max - min);
            return new uint3(
                    CompresseU32(GetX3_Q32(++_state), min, range),
                    CompresseU32(GetY3_Q32(_state), min, range),
                    CompresseU32(GetZ3_Q32(_state), min, range));
        }
        public uint4 NextUInt4()
        {
            return new uint4(
                    GetX4_Q32(++_state),
                    GetY4_Q32(_state),
                    GetZ4_Q32(_state),
                    GetW4_Q32(_state));
        }
        public uint4 NextUInt4(int max)
        {
            return new uint4(
                    CompresseU32(GetX4_Q32(++_state), max),
                    CompresseU32(GetY4_Q32(_state), max),
                    CompresseU32(GetZ4_Q32(_state), max),
                    CompresseU32(GetW4_Q32(_state), max));
        }
        public uint4 NextUInt4(int min, int max)
        {
            ulong range = (ulong)(max - min);
            return new uint4(
                    CompresseU32(GetX4_Q32(++_state), min, range),
                    CompresseU32(GetY4_Q32(_state), min, range),
                    CompresseU32(GetZ4_Q32(_state), min, range),
                    CompresseU32(GetW4_Q32(_state), min, range));
        }
        #endregion

        #region Long
        [IN(LINE)]
        public long NextLong()
        {
            return (long)GetX1_Q64(++_state);
        }
        #endregion

        #region Ulong
        [IN(LINE)]
        public ulong NextULong()
        {
            return GetX1_Q64(++_state);
        }
        #endregion

        #region Float
        [IN(LINE)]
        public float NextFloat()
        {
            return GetX1_F(++_state);
        }
        public float2 NextFloat2()
        {
            return new float2(
                GetX2_F(++_state), 
                GetY2_F(_state));
        }
        public float3 NextFloat3()
        {
            return new float3(
                GetX3_F(++_state),
                GetY3_F(_state),
                GetZ3_F(_state));
        }
        public float4 NextFloat4()
        {
            return new float4(
                GetX4_F(++_state),
                GetY4_F(_state),
                GetZ4_F(_state),
                GetW4_F(_state));
        }
        #endregion

        #region Double
        [IN(LINE)]
        public double NextDouble()
        {
            return GetX1_D(++_state);
        }
        public double2 NextDouble2()
        {
            return new double2(
                GetX2_D(++_state), 
                GetY2_D(_state));
        }
        public double3 NextDouble3()
        {
            return new double3(
                GetX3_D(++_state), 
                GetY3_D(_state), 
                GetZ3_D(_state));
        }
        public double4 NextDouble4()
        {
            return new double4(
                GetX4_D(++_state),
                GetY4_D(_state),
                GetZ4_D(_state),
                GetW4_D(_state));
        }
        #endregion


        #region Other
        [IN(LINE)]
        public override int GetHashCode() => (int)_state;

        [IN(LINE)]
        public override bool Equals(object o) => o is QuasiRandom target && Equals(target);

        [IN(LINE)]
        public bool Equals(QuasiRandom a) => a._state == _state;

        [IN(LINE)]
        public override string ToString() => $"{nameof(QuasiRandom)}({_state})";
        [IN(LINE)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"{nameof(QuasiRandom)}({_state.ToString(format, formatProvider)})";
        }
        #endregion
    }
}