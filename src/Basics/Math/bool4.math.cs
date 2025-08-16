using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public static partial class DM // bool4
    {
        #region Hash
        [IN(LINE)] public unsafe static uint UHash(bool4 v) { return *(uint*)&v; }
        [IN(LINE)] public static int Hash(bool4 v) { return unchecked((int)UHash(v)); }
        #endregion

        #region All/Any
        [IN(LINE)] public static bool All(bool4 a) { return a.x && a.y && a.z && a.w; }
        [IN(LINE)] public static bool Any(bool4 a) { return a.x || a.y || a.z || a.w; }
        #endregion
    }
}
