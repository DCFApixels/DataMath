using System;
using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public static partial class DM // bool2
    {
        #region Hash
        [IN(LINE)] public unsafe static uint UHash(bool2 v) { return *(uint*)&v & 0x0000_FFFF; }
        [IN(LINE)] public static int Hash(bool2 v) { return unchecked((int)UHash(v)); }
        #endregion

        #region All/Any
        [IN(LINE)] public static bool All(bool2 a) { return a.x && a.y; }
        [IN(LINE)] public static bool Any(bool2 a) { return a.x || a.y; }
        #endregion
    }
}
