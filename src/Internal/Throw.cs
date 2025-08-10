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
        public static void Argument()
        {
            throw new ArgumentException();
        }
    }
}
