using System.Text.RegularExpressions;

namespace DataMath.src.Utils
{
    public unsafe static class BitsUtility
    {
        private const char DEFAULT_SEPARATOR = '_';
        private const int BYTE_BITS = 8;

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
            {
                str[length - i - 1] = (bytes[i / BYTE_BITS] & 1 << (i % BYTE_BITS)) > 0 ? '1' : '0';
            }

            if (separateRange > 0)
                return Regex.Replace(new string(str, 0, length), ".{" + separateRange + "}", "$0" + separator + "");
            else
                return new string(str, 0, length);
        }


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
    }
}
