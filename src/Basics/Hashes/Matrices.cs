using System;
using System.Runtime.CompilerServices;

namespace DCFApixels.DataMath.TODO
{
    public static partial class math
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint uhash(in float2x2 v) => unchecked((uint)hash(v));
        public static int hash(in float2x2 v)
        {
            throw new NotImplementedException();
        }
    }
}
