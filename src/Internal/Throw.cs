using System;
using System.Runtime.CompilerServices;
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath.Internal
{
    internal static class Throw
    {
        [IN(NO_LINE)]
        public static void UndefinedException()
        {
            throw new Exception();
        }
        [IN(NO_LINE)]
        public static void Exception(string message)
        {
            throw new Exception(message);
        }
        [IN(NO_LINE)]
        public static void ZeroLengthArgument(string argumentName = null)
        {
            if (string.IsNullOrEmpty(argumentName))
            {
                argumentName = "value";
            }
            throw new ArgumentException($"{argumentName}.length == 0");
        }
        [IN(NO_LINE)]
        public static void ArgumentOutOfRange(string argumentName = null)
        {
            if (string.IsNullOrEmpty(argumentName))
            {
                argumentName = "value";
            }
            throw new ArgumentOutOfRangeException(argumentName);
        }
        [IN(NO_LINE)]
        public static void ArgumentDestinationTooShort(string argumentName = null)
        {
            if (string.IsNullOrEmpty(argumentName))
            {
                argumentName = "value";
            }
            throw new ArgumentOutOfRangeException("Destination Too Short");
        }


        [IN(NO_LINE)]
        public static void IndexOutOfRange(int length) { IndexOutOfRange(0, length); }
        [IN(NO_LINE)]
        public static void IndexOutOfRange(int startIndex, int length)
        {
            throw new IndexOutOfRangeException($"Index must be between[{startIndex}..{length - 1}].");
        }
    }
}
