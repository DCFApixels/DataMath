using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace DCFApixels
{
    public unsafe static class BitsUtility
    {
        private const char DEFAULT_SEPARATOR = '_';
        private const int BYTE_BITS = 8;

        #region CountBits
        public static unsafe int CountBits8<T>(T bits) where T : unmanaged
        {
            return CountBits((uint)*(byte*)&bits);
        }
        public static unsafe int CountBits16<T>(T bits) where T : unmanaged
        {
            return CountBits((uint)*(ushort*)&bits);
        }

        public static unsafe int CountBits32<T>(T bits) where T : unmanaged
        {
            return CountBits(*(uint*)&bits);
        }
        public static unsafe int CountBits(float bits)
        {
            return CountBits32(bits);
        }
        public static unsafe int CountBits(int bits)
        {
            return CountBits((uint)bits);
        }
        public static unsafe int CountBits(uint bits)
        {
            bits = bits - ((bits >> 1) & 0x55555555);
            bits = (bits & 0x33333333) + ((bits >> 2) & 0x33333333);
            return (int)(((bits + (bits >> 4) & 0xF0F0F0F) * 0x1010101) >> 24);
        }

        public static unsafe int CountBits64<T>(T bits) where T : unmanaged
        {
            return CountBits(*(ulong*)&bits);
        }
        public static unsafe int CountBits(double bits)
        {
            return CountBits64(bits);
        }
        public static unsafe int CountBits(long bits)
        {
            return CountBits((ulong)bits);
        }
        public static unsafe int CountBits(ulong bits)
        {
            bits = bits - ((bits >> 1) & 0x55555555_55555555);
            bits = (bits & 0x33333333_33333333) + ((bits >> 2) & 0x33333333_33333333);
            return (int)(((bits + (bits >> 4) & 0x0F0F0F0F_0F0F0F0F) * 0x01010101_01010101) >> (24 + 32));
        }
        #endregion

        #region GetHighBitNumber
        public static unsafe int GetHighBitNumber8<T>(T bits) where T : unmanaged
        {
            return GetHighBitNumber(*(byte*)&bits);
        }
        public static int GetHighBitNumber(sbyte bits)
        {
            return GetHighBitNumber((byte)bits);
        }
        public static int GetHighBitNumber(byte bits)
        {
            if (bits == 0)
            {
                return -1;
            }
            int bit = 0;
            if ((bits & 0xF0) != 0)
            {
                bits >>= 4;
                bit |= 4;
            }
            if ((bits & 0xC) != 0)
            {
                bits >>= 2;
                bit |= 2;
            }
            if ((bits & 0x2) != 0)
            {
                bit |= 1;
            }
            return bit;
        }

        public static unsafe int GetHighBitNumber16<T>(T bits) where T : unmanaged
        {
            return GetHighBitNumber(*(ushort*)&bits);
        }
        public static int GetHighBitNumber(short bits)
        {
            return GetHighBitNumber((ushort)bits);
        }
        public static int GetHighBitNumber(ushort bits)
        {
            if (bits == 0)
            {
                return -1;
            }
            int bit = 0;
            if ((bits & 0xFF00) != 0)
            {
                bits >>= 8;
                bit |= 8;
            }
            if ((bits & 0xF0) != 0)
            {
                bits >>= 4;
                bit |= 4;
            }
            if ((bits & 0xC) != 0)
            {
                bits >>= 2;
                bit |= 2;
            }
            if ((bits & 0x2) != 0)
            {
                bit |= 1;
            }
            return bit;
        }

        public static unsafe int GetHighBitNumber32<T>(T bits) where T : unmanaged
        {
            return GetHighBitNumber(*(uint*)&bits);
        }
        public static int GetHighBitNumber(float bits)
        {
            return GetHighBitNumber(*(uint*)&bits);
        }
        public static int GetHighBitNumber(int bits)
        {
            return GetHighBitNumber((uint)bits);
        }
        public static int GetHighBitNumber(uint bits)
        {
            if (bits == 0)
            {
                return -1;
            }
            int bit = 0;
            if ((bits & 0xFFFF0000) != 0)
            {
                bits >>= 16;
                bit |= 16;
            }
            if ((bits & 0xFF00) != 0)
            {
                bits >>= 8;
                bit |= 8;
            }
            if ((bits & 0xF0) != 0)
            {
                bits >>= 4;
                bit |= 4;
            }
            if ((bits & 0xC) != 0)
            {
                bits >>= 2;
                bit |= 2;
            }
            if ((bits & 0x2) != 0)
            {
                bit |= 1;
            }
            return bit;
        }

        public static unsafe int GetHighBitNumber64<T>(T bits) where T : unmanaged
        {
            return GetHighBitNumber(*(ulong*)&bits);
        }
        public static int GetHighBitNumber(double bits)
        {
            return GetHighBitNumber(*(ulong*)&bits);
        }
        public static int GetHighBitNumber(long bits)
        {
            return GetHighBitNumber((ulong)bits);
        }
        public static int GetHighBitNumber(ulong bits)
        {
            if (bits == 0)
            {
                return -1;
            }
            int bit = 0;
            if ((bits & 0xFFFFFFFF00000000) != 0)
            {
                bits >>= 32;
                bit |= 32;
            }
            if ((bits & 0xFFFF0000) != 0)
            {
                bits >>= 16;
                bit |= 16;
            }
            if ((bits & 0xFF00) != 0)
            {
                bits >>= 8;
                bit |= 8;
            }
            if ((bits & 0xF0) != 0)
            {
                bits >>= 4;
                bit |= 4;
            }
            if ((bits & 0xC) != 0)
            {
                bits >>= 2;
                bit |= 2;
            }
            if ((bits & 0x2) != 0)
            {
                bit |= 1;
            }
            return bit;
        }
        #endregion

        #region GetBitNumbers
        public static unsafe int[] GetBitNumbers32<T>(T bits) where T : unmanaged
        {
            return GetBitNumbers(*(uint*)&bits);
        }
        public static unsafe int[] GetBitNumbers(float bits)
        {
            return GetBitNumbers(*(uint*)&bits);
        }
        public static int[] GetBitNumbers(int bits)
        {
            return GetBitNumbers((uint)bits);
        }
        public static int[] GetBitNumbers(uint bits)
        {
            int[] result = new int[CountBits(bits)];
            for (int i = 0; i < result.Length; i++)
            {
                int number = GetHighBitNumber(bits);
                result[i] = number;
                bits ^= 1u << number;
            }
            return result;
        }

        public static unsafe int GetBitNumbersNoAlloc32<T>(T bits, ref int[] numbers) where T : unmanaged
        {
            return GetBitNumbersNoAlloc(*(uint*)&bits, ref numbers);
        }
        public static unsafe int GetBitNumbersNoAlloc(float bits, ref int[] numbers)
        {
            return GetBitNumbersNoAlloc(*(uint*)&bits, ref numbers);
        }
        public static int GetBitNumbersNoAlloc(int bits, ref int[] numbers)
        {
            return GetBitNumbersNoAlloc((uint)bits, ref numbers);
        }
        public static int GetBitNumbersNoAlloc(uint bits, ref int[] numbers)
        {
            int iMax = CountBits(bits);
            if (iMax >= numbers.Length)
                Array.Resize(ref numbers, iMax);
            for (int i = 0; i < iMax; i++)
            {
                int number = GetHighBitNumber(bits);
                numbers[i] = number;
                bits ^= 1u << number;
            }
            return iMax;
        }
        public static unsafe void GetBitNumbersNoAlloc32<T>(T bits, List<int> numbers) where T : unmanaged
        {
            GetBitNumbersNoAlloc(*(uint*)&bits, numbers);
        }
        public static unsafe void GetBitNumbersNoAlloc(float bits, List<int> numbers)
        {
            GetBitNumbersNoAlloc(*(uint*)&bits, numbers);
        }
        public static void GetBitNumbersNoAlloc(int bits, List<int> numbers)
        {
            GetBitNumbersNoAlloc((uint)bits, numbers);
        }
        public static void GetBitNumbersNoAlloc(uint bits, List<int> numbers)
        {
            numbers.Clear();
            int iMax = CountBits(bits);
            for (int i = 0; i < iMax; i++)
            {
                int number = GetHighBitNumber(bits);
                numbers[i] = number;
                bits ^= 1u << number;
            }
        }



        public static unsafe int[] GetBitNumbers64<T>(T bits) where T : unmanaged
        {
            return GetBitNumbers(*(ulong*)&bits);
        }
        public static unsafe int[] GetBitNumbers(double bits)
        {
            return GetBitNumbers(*(ulong*)&bits);
        }
        public static int[] GetBitNumbers(long bits)
        {
            return GetBitNumbers((ulong)bits);
        }
        public static int[] GetBitNumbers(ulong bits)
        {
            int[] result = new int[CountBits(bits)];
            for (int i = 0; i < result.Length; i++)
            {
                int number = GetHighBitNumber(bits);
                result[i] = number;
                bits ^= 1LU << number;
            }
            return result;
        }

        public static unsafe int GetBitNumbersNoAlloc64<T>(T bits, ref int[] numbers) where T : unmanaged
        {
            return GetBitNumbersNoAlloc(*(ulong*)&bits, ref numbers);
        }
        public static unsafe int GetBitNumbersNoAlloc(double bits, ref int[] numbers)
        {
            return GetBitNumbersNoAlloc(*(ulong*)&bits, ref numbers);
        }
        public static int GetBitNumbersNoAlloc(long bits, ref int[] numbers)
        {
            return GetBitNumbersNoAlloc((ulong)bits, ref numbers);
        }
        public static int GetBitNumbersNoAlloc(ulong bits, ref int[] numbers)
        {
            int iMax = CountBits(bits);
            if (iMax >= numbers.Length)
                Array.Resize(ref numbers, iMax);
            for (int i = 0; i < iMax; i++)
            {
                int number = GetHighBitNumber(bits);
                numbers[i] = number;
                bits ^= 1u << number;
            }
            return iMax;
        }
        public static unsafe void GetBitNumbersNoAlloc64<T>(T bits, List<int> numbers) where T : unmanaged
        {
            GetBitNumbersNoAlloc(*(ulong*)&bits, numbers);
        }
        public static unsafe void GetBitNumbersNoAlloc(double bits, List<int> numbers)
        {
            GetBitNumbersNoAlloc(*(ulong*)&bits, numbers);
        }
        public static void GetBitNumbersNoAlloc(long bits, List<int> numbers)
        {
            GetBitNumbersNoAlloc((ulong)bits, numbers);
        }
        public static void GetBitNumbersNoAlloc(ulong bits, List<int> numbers)
        {
            numbers.Clear();
            int iMax = CountBits(bits);
            for (int i = 0; i < iMax; i++)
            {
                int number = GetHighBitNumber(bits);
                numbers[i] = number;
                bits ^= 1u << number;
            }
        }
        #endregion

        #region ToBitsString
        public static string ToBitsString<T>(T value, bool withSeparator) where T : unmanaged
        {
            return ToBitsStringInaternal(value, withSeparator ? BYTE_BITS : 0, DEFAULT_SEPARATOR);
        }
        public static string ToBitsString<T>(T value, int separateRange) where T : unmanaged
        {
            return ToBitsStringInaternal(value, separateRange, DEFAULT_SEPARATOR);
        }
        public static string ToBitsString<T>(T value, char separator = DEFAULT_SEPARATOR, int separateRange = BYTE_BITS) where T : unmanaged
        {
            return ToBitsStringInaternal(value, separateRange, separator);
        }
        private static unsafe string ToBitsStringInaternal<T>(T value, int separateRange, char separator) where T : unmanaged
        {
            int size = sizeof(T);
            int length = size * BYTE_BITS;
            //byte* bytes = stackalloc byte[size / BYTE_BITS];
            byte* bytes = (byte*)&value;
            char* str = stackalloc char[length];

            for (int i = 0; i < length; i++)
                str[length - i - 1] = (bytes[i / BYTE_BITS] & 1 << (i % BYTE_BITS)) > 0 ? '1' : '0';

            if (separateRange > 0)
                return Regex.Replace(new string(str, 0, length), ".{" + separateRange + "}", "$0" + separator + "");
            else
                return new string(str, 0, length);
        }
        #endregion

        #region ParceBitString
        public static ulong ToULong(string bitsString)
        {
            const int BIT_SIZE = 64;
            ulong result = 0;
            int stringMouse = 0;
            for (int i = 0; i < BIT_SIZE && stringMouse < bitsString.Length; i++, stringMouse++)
            {
                char chr = bitsString[stringMouse];

                if (chr == '1')
                {
                    result |= (ulong)1 << (BIT_SIZE - i - 1);
                    continue;
                }

                if (chr != '0')
                {
                    i--;
                    continue;
                }
            }
            return result;
        }

        public static uint ToUInt(string bitsString)
        {
            const int BIT_SIZE = 32;
            uint result = 0;
            int stringMouse = 0;
            for (int i = 0; i < BIT_SIZE && stringMouse < bitsString.Length; i++, stringMouse++)
            {
                char chr = bitsString[stringMouse];

                if (chr == '1')
                {
                    result |= (uint)1 << (BIT_SIZE - i - 1);
                    continue;
                }

                if (chr != '0')
                {
                    i--;
                    continue;
                }
            }
            return result;
        }

        public static ushort ToUShort(string bitsString)
        {
            const int BIT_SIZE = 16;
            ushort result = 0;
            int stringMouse = 0;
            for (int i = 0; i < BIT_SIZE && stringMouse < bitsString.Length; i++, stringMouse++)
            {
                char chr = bitsString[stringMouse];

                if (chr == '1')
                {
                    result |= (ushort)(1 << (BIT_SIZE - i - 1));
                    continue;
                }

                if (chr != '0')
                {
                    i--;
                    continue;
                }
            }
            return result;
        }

        public static byte ToByte(string bitsString)
        {
            const int BIT_SIZE = 8;
            byte result = 0;
            int stringMouse = 0;
            for (int i = 0; i < BIT_SIZE && stringMouse < bitsString.Length; i++, stringMouse++)
            {
                char chr = bitsString[stringMouse];

                if (chr == '1')
                {
                    result |= (byte)(1 << (BIT_SIZE - i - 1));
                    continue;
                }

                if (chr != '0')
                {
                    i--;
                    continue;
                }
            }
            return result;
        }

        public static bool ToBool(string bitsString)
        {
            byte result = ToByte(bitsString);
            return *(bool*)&result;
        }
        public static short ToShort(string bitsString) => (short)ToUShort(bitsString);
        public static int ToInt(string bitsString) => (int)ToUInt(bitsString);
        public static long ToLong(string bitsString) => (long)ToULong(bitsString);
        #endregion

        #region Other
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TEnum AllFlags<TEnum>() where TEnum : unmanaged, Enum
        {
            return EnumCache<TEnum>.allFlags;
        }

        private static class EnumCache<TEnum> where TEnum : unmanaged, Enum
        {
            public readonly static TEnum empty;
            public readonly static TEnum allFlags;
            public readonly static int valuesCount;
            public readonly static int size;

            static EnumCache()
            {
                Array values = Enum.GetValues(typeof(TEnum));
                size = sizeof(TEnum);

                long result = 0;
                valuesCount = values.Length;
                for (int i = 0; i < valuesCount; i++)
                {
                    result |= (long)values.GetValue(i);
                }
                ulong emptyBits = 0;

                allFlags = *(TEnum*)&result;
                empty = *(TEnum*)&emptyBits;
                return;
            }
        }
        #endregion
    }
}