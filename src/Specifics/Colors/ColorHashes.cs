#pragma warning disable CS8981
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public static partial class DM // vector hashes
    {
        #region Color
        [IN(LINE)] public unsafe static uint UHash(colorhsv v) { return UHash(*(float4*)&v); }
        [IN(LINE)] public static int Hash(colorhsv v) { return unchecked((int)UHash(v)); }
        [IN(LINE)] public unsafe static uint UHash(color v) { return UHash(*(float4*)&v); }
        [IN(LINE)] public static int Hash(color v) { return unchecked((int)UHash(v)); }
        [IN(LINE)] public unsafe static uint UHash(color32 v) { return *(uint*)&v; }
        [IN(LINE)] public static int Hash(color32 v) { return unchecked((int)UHash(v)); }
        #endregion
    }
}