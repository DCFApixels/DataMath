using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace DataMath.src.Utils
{
    public unsafe static class BitsUtility
    {
        private const char DEFAULT_SEPARATOR = '_';
        private const int BYTE_BITS = 8;

        public static string ToBitsString<T>(T value, bool withSeparator) where T : struct
        {
            return ToBitsStringInaternal(value, withSeparator ? BYTE_BITS : 0, DEFAULT_SEPARATOR);
        }
        public static string ToBitsString<T>(T value, int separateRange) where T : struct
        {
            return ToBitsStringInaternal(value, separateRange, DEFAULT_SEPARATOR);
        }
        public static string ToBitsString<T>(T value, char separator = DEFAULT_SEPARATOR, int separateRange = BYTE_BITS) where T : struct
        {
            return ToBitsStringInaternal(value, separateRange, separator);
        }


        private static string ToBitsStringInaternal<T>(T value, int separateRange, char separator) where T : struct
        {

            int size = Marshal.SizeOf(value);
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
            ulong result = 0;
            int stringMouse = 0;
            for (int i = 0; i < 64 && stringMouse < bitsString.Length; i++, stringMouse++)
            {
                char chr = bitsString[stringMouse];

                if (chr == '1')
                {
                    result |= (ulong)1 << (64 - i - 1);
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
    }
}
