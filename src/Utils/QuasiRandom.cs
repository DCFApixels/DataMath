using DCFApixels.DataMath;
using System.Runtime.CompilerServices;
using q64 = System.UInt64;
using q32 = System.UInt32;
using System;
using System.ComponentModel;

namespace DataMath.src.Utils
{
    /// <summary> Quasi Random. Use R algoritm </summary>
    public struct QuasiRandom
    {


        private const int X = 1065353216;

        private static q64 DecimalToQ64(decimal v) => (ulong)(v * Q64_MAX) + 1;
        private const ulong Q64_MAX = ulong.MaxValue;
        private const uint Q32_MAX = uint.MaxValue;

        private const decimal G_1D = 1.6180339887498948482m;
        private const q64 X1_Q64 = ((ulong)(1m / G_1D) * Q64_MAX) + 1;
        private const float X1_F = (float)(1m / G_1D);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ulong GetX_1D_Q64(uint state) => X1_Q64 * state;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private float GetX_1D_F(uint state) => (X1_F * state) % 1f;

        private const decimal G_2D = 1.32471795724474602596m;
        private const float G_2D_F = 1.32471795724474602596f;
        private static readonly q64 X2_Q64 = (q64)((1m / G_2D) * Q64_MAX) + 1;
        private static readonly q64 Y2_Q64 = (q64)((1m / (G_2D * G_2D)) * Q64_MAX) + 1;
        private static readonly q32 X2_Q32 = (q32)((1m / G_2D) * Q32_MAX) + 1;
        private static readonly q32 Y2_Q32 = (q32)((1m / (G_2D * G_2D)) * Q32_MAX) + 1;

        private const float X2_F = (float)(1m / G_2D);
        private const float Y2_F = (float)(1m / (G_2D * G_2D));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ulong GetX_2D_Q64(uint state) => X2_Q64 * state;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ulong GetY_2D_Q64(uint state) => Y2_Q64 * state;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ulong GetX_2D_Q32(uint state) => X2_Q32 * state;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ulong GetY_2D_Q32(uint state) => Y2_Q32 * state;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private float GetX_2D_F(uint state) => ToFloat((X2_Q32 * state) >> 9 | 0x3F80_0000) - 1f; //для unsigned происходил логический сдвиг
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private float GetY_2D_F(uint state) => ToFloat((Y2_Q32 * state) >> 9 | 0x3F80_0000) - 1f; //для unsigned происходил логический сдвиг


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private unsafe float ToFloat(uint v) => *(float*)&v;

        private const decimal G_3D = 1.22074408460575947536m;
        private const q64 X3_Q64 = (ulong)((1m / G_3D) * Q64_MAX) + 1;
        private const q64 Y3_Q64 = (ulong)((1m / (G_3D * G_3D)) * Q64_MAX) + 1;
        private const q64 Z3_Q64 = (ulong)((1m / (G_3D * G_3D * G_3D)) * Q64_MAX) + 1;
        private const float X3_F = (float)(1m / G_3D);
        private const float Y3_F = (float)(1m / (G_3D * G_3D));
        private const float Z3_F = (float)(1m / (G_3D * G_3D * G_3D));

        private uint _state;

        public QuasiRandom(uint seed)
        {
            _state = seed;
        }



        public int2 NextInt2(ulong range)
        {
            return new int2(
                    (int)(GetX_2D_Q32(++_state) / (Q32_MAX / range)),
                    (int)(GetY_2D_Q32(_state) / (Q32_MAX / range))
                );
        }
        public float2 NextFloat2()
        {
            return new float2(
                    GetX_2D_F(++_state),
                    GetY_2D_F(_state)
                );
        }









        public float2 Naive_NextFloat2()
        {
            _state++;
            return new float2(
                    (_state * X2_F) % 1f,
                    (_state * Y2_F) % 1f
                );
        }
    }
}
