using System;
using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    internal static class RandomUtility
    {
        [IN(LINE)] private static unsafe float AsFloat(uint value) => *(float*)&value;
        [IN(LINE)] private static unsafe double AsDouble(ulong value) => *(double*)&value;

        //основано на стандарте IEEE754
        //Агоритм дает отличную производительность(Быстрее раз в 7 или более, по сравнению с другими),
        //но с потерей точности(Хотя другие алгоритмы тоже дают потерю в точности).
        //По IEEE754 диапозон 1f <= x < 2f ведет к изменению только мантиссы, а экспонента всегда 0111_1111.
        //Так как увеличение мантиссы это линейный рост, то число можно просто свдинуть в мантиссу(>> 9),
        //экспонента ставится как 0111_1111(| 0x3F80_0000), что будет соответсвовать диапозону 1f <= x < 2f.
        //
        //Расчет в виде целыхчисел и дальнейшем преобразовании в вещественное этим алгоритмом
        //быстрее в несколько раз, чем изначальный расчет в вещественных числах + убирает серьзную
        //потерю точности при больших значениях состояния
        [IN(LINE)] public static float Q32ToFloat(uint value) => AsFloat((value >> 9) | 0x3F80_0000) - 1f;
        [IN(LINE)] public static double Q64ToDouble(ulong value) => AsDouble((value >> 12) | 0x7FF0_0000_0000_0000) - 1d;

        [IN(LINE)] public static uint CompresseU32(uint value, int range) => (uint)((value * (ulong)range) >> 32);
        [IN(LINE)] public static int Compresse32(uint value, int range) => (int)((value * (ulong)range) >> 32);
        [IN(LINE)] public static uint CompresseU32(uint value, ulong ulrange) => (uint)((value * ulrange) >> 32);
        [IN(LINE)] public static int Compresse32(uint value, ulong range) => (int)((value * range) >> 32);

        [IN(LINE)] public static uint CompresseU32(uint value, int min, ulong ulrange) => (uint)((value * ulrange) >> 32 + min);
        [IN(LINE)] public static int Compresse32(uint value, int min, ulong range) => (int)((value * range) >> 32) + min;

        [IN(LINE)] public static uint CompresseU32(uint value, uint min, ulong ulrange) => (uint)((value * ulrange) >> 32) + min;

        public static uint GetAutoSeeed()
        {
            uint seed = (uint)DateTime.Now.Ticks;
            seed ^= seed << 13;
            seed ^= seed >> 17;
            seed ^= seed << 5;
            return seed;
        }


        [IN(LINE)]
        public static int NextXorShiftState(int state)
        {
            unchecked { return (state << 13) ^ (state >> 17) ^ (state << 5); };
        }
        [IN(LINE)]
        public static uint NextXorShiftState(uint state)
        {
            unchecked { return (state << 13) ^ (state >> 17) ^ (state << 5); };
        }
    }
}
