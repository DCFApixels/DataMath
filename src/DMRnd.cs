using System;
using System.Runtime.InteropServices;
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public static class DMRnd
    {
        private static uint AutoSeed = InitAutoSeed();
        private static uint InitAutoSeed()
        {
            var ptr = Marshal.AllocHGlobal(1);
            var result = (uint)ptr;
            result ^= (uint)DateTime.Now.Ticks;
            Marshal.FreeHGlobal(ptr);
            return result;
        }
        [IN(LINE)] private static unsafe float AsFloat(uint value) => *(float*)&value;
        [IN(LINE)] private static unsafe double AsDouble(ulong value) => *(double*)&value;

        [IN(LINE)] public static float Q32ToFloat(uint value) => AsFloat((value >> 9) | 0x3F80_0000) - 1f;
        [IN(LINE)] public static double Q64ToDouble(ulong value) => AsDouble((value >> 12) | 0x7FF0_0000_0000_0000) - 1d;

        [IN(LINE)] public static uint CompresseU32(uint value, int range) => (uint)((value * (ulong)range) >> 32);
        [IN(LINE)] public static int Compresse32(uint value, int range) => (int)((value * (ulong)range) >> 32);
        [IN(LINE)] public static uint CompresseU32(uint value, ulong ulrange) => (uint)((value * ulrange) >> 32);
        [IN(LINE)] public static int Compresse32(uint value, ulong range) => (int)((value * range) >> 32);

        [IN(LINE)] public static uint CompresseU32(uint value, int min, ulong ulrange) => (uint)((value * ulrange) >> 32 + min);
        [IN(LINE)] public static int Compresse32(uint value, int min, ulong range) => (int)((value * range) >> 32) + min;

        [IN(LINE)] public static uint CompresseU32(uint value, uint min, ulong ulrange) => (uint)((value * ulrange) >> 32) + min;

        public static uint NewAutoSeed()
        {
            AutoSeed ^= AutoSeed << 13;
            AutoSeed ^= AutoSeed >> 17;
            AutoSeed ^= AutoSeed << 5;
            return AutoSeed;
        }

        [IN(LINE)]
        public static int NextXorShiftState(int state)
        {
            unchecked
            {
                return (int)NextXorShiftState((uint)state);
            }
        }
        [IN(LINE)]
        public static uint NextXorShiftState(uint state)
        {
            unchecked
            {
                state ^= state << 13;
                state ^= state >> 17;
                state ^= state << 5;
                return state;
            }
        }
    }
}
