using System;
using System.Runtime.CompilerServices;

namespace DCFApixels.DataMath.Internal
{
    internal static class Throw
    {
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
    }
}
