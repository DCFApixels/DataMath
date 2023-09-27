using System.Runtime.CompilerServices;
using q32 = System.UInt32;
using q64 = System.UInt64;

namespace DCFApixels.DataMath
{
    /// <summary> Quasi Random. Use R algoritm </summary>
    public struct QuasiRandom
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static q64 DecimalToQ64(decimal v) => (q64)(v * Q64_MAX) + 1;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static q32 DecimalToQ32(decimal v) => (q32)(v * Q64_MAX) + 1;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private unsafe float AsFloat(uint v) => *(float*)&v;

        private const q32 F_ONE = 0x3F80_0000;

        private const q64 Q64_MAX = q64.MaxValue;
        private const q32 Q32_MAX = q32.MaxValue;

        private const decimal G_1D = 1.6180339887498948482m;
        private const q64 X1_Q64 = ((q64)(1m / G_1D) * Q64_MAX) + 1;
        private const q32 X1_Q32 = ((q32)(1m / G_1D) * Q32_MAX) + 1;

        private const decimal G_2D = 1.32471795724474602596m;
        private const q64 X2_Q64 = (q64)((1m / G_2D) * Q64_MAX) + 1;
        private const q64 Y2_Q64 = (q64)((1m / (G_2D * G_2D)) * Q64_MAX) + 1;
        private const q32 X2_Q32 = (q32)((1m / G_2D) * Q32_MAX) + 1;
        private const q32 Y2_Q32 = (q32)((1m / (G_2D * G_2D)) * Q32_MAX) + 1;

        private const decimal G_3D = 1.22074408460575947536m;
        private const q64 X3_Q64 = (q64)((1m / G_3D) * Q64_MAX) + 1;
        private const q64 Y3_Q64 = (q64)((1m / (G_3D * G_3D)) * Q64_MAX) + 1;
        private const q64 Z3_Q64 = (q64)((1m / (G_3D * G_3D * G_3D)) * Q64_MAX) + 1;
        private const q32 X3_Q32 = (q32)((1m / G_3D) * Q32_MAX) + 1;
        private const q32 Y3_Q32 = (q32)((1m / (G_3D * G_3D)) * Q32_MAX) + 1;
        private const q32 Z3_Q32 = (q32)((1m / (G_3D * G_3D * G_3D)) * Q32_MAX) + 1;

        /*----------------------------------------------------------------------------------------------------------------*/

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ulong GetX_1D_Q64(uint state) => X1_Q64 * state;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private uint GetX_1D_Q32(uint state) => X1_Q32 * state;
        //основано на стандарте IEEE754
        //Агоритм дает отличную производительность(Быстрее раз в 7 или более, по сравнению с другими),
        //но с потерей точности(Хотя другие алгоритмы тоже дают потерю в точности).
        //По IEEE754 диапозон 1f <= x < 2f ведет к изменению только мантиссы, а экспонента всегда 0111_1111.
        //Так как увеличение мантиссы это линейный рост, то число сдвигается все в мантиссу(>> 9),
        //экспонента ставится как 0111_1111(| F_ONE), что будет соответсвовать диапозону 1f <= x < 2f.
        //
        //Расчет в виде целыхчисел и дальнейшом преобразовании в вещественное этим алгоритмом
        //быстрее в несколько раз, чем изначальный расчет в вещественных числах + убрирает серьзную
        //потерю точности при больших значениях _state
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private float GetX1_F(uint state) => AsFloat((X1_Q32 * state) >> 9 | F_ONE) - 1f;

        /*----------------------------------------------------------------------------------------------------------------*/

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ulong GetX2_Q64(uint state) => X2_Q64 * state;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ulong GetY2_Q64(uint state) => Y2_Q64 * state;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private uint GetX2_Q32(uint state) => X2_Q32 * state;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private uint GetY2_Q32(uint state) => Y2_Q32 * state;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private float GetX2_F(uint state) => AsFloat((X2_Q32 * state) >> 9 | F_ONE) - 1f;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private float GetY2_F(uint state) => AsFloat((Y2_Q32 * state) >> 9 | F_ONE) - 1f;

        /*----------------------------------------------------------------------------------------------------------------*/

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ulong GetX3_Q64(uint state) => X3_Q64 * state;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ulong GetY3_Q64(uint state) => Y3_Q64 * state;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private ulong GetZ3_Q64(uint state) => Z3_Q64 * state;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private uint GetX3_Q32(uint state) => X3_Q32 * state;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private uint GetY3_Q32(uint state) => Y3_Q32 * state;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private uint GetZ3_Q32(uint state) => Z3_Q32 * state;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private float GetX3_F(uint state) => AsFloat((X3_Q32 * state) >> 9 | F_ONE) - 1f;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private float GetY3_F(uint state) => AsFloat((Y3_Q32 * state) >> 9 | F_ONE) - 1f;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private float GetZ3__F(uint state) => AsFloat((Z3_Q32 * state) >> 9 | F_ONE) - 1f;

        /*----------------------------------------------------------------------------------------------------------------*/

        private uint _state;
        public QuasiRandom(uint seed)
        {
            _state = seed;
        }



        public int2 NextInt2(ulong range)
        {
            return new int2(
                    (int)(GetX2_Q32(++_state) / (Q32_MAX / range)),
                    (int)(GetY2_Q32(_state) / (Q32_MAX / range))
                );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float NextFloat()
        {
            return GetX1_F(++_state);
        }
        public float2 NextFloat2()
        {
            return new float2(GetX2_F(++_state), GetY2_F(_state));
        }
        public float3 NextFloat3()
        {
            return new float3(GetX3_F(++_state), GetY3_F(_state), GetZ3__F(_state));
        }
    }
}
