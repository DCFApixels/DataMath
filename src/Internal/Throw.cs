using System;
using System.Runtime.CompilerServices;

namespace DCFApixels.DataMath.Internal
{
    internal static class Throw
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void UndefinedException()
        {
            throw new Exception();
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Exception(string message)
        {
            throw new Exception(message);
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ZeroLengthArgument(string argumentName = null)
        {
            if (string.IsNullOrEmpty(argumentName))
            {
                argumentName = "value";
            }
            throw new ArgumentException($"{argumentName}.length == 0");
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ArgumentOutOfRange(string argumentName = null)
        {
            if (string.IsNullOrEmpty(argumentName))
            {
                argumentName = "value";
            }
            throw new ArgumentOutOfRangeException(argumentName);
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ArgumentDestinationTooShort(string argumentName = null)
        {
            if (string.IsNullOrEmpty(argumentName))
            {
                argumentName = "value";
            }
            throw new ArgumentOutOfRangeException("Destination Too Short");
        }


        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void IndexOutOfRange(int length) { IndexOutOfRange(0, length); }
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void IndexOutOfRange(int startIndex, int length)
        {
            throw new IndexOutOfRangeException($"Index must be between[{startIndex}..{length - 1}].");
        }
    }
}
