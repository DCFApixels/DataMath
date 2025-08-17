using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public static partial class DM // bool3
    {
        #region Hash
        [IN(LINE)] public unsafe static uint UHash(bool3 v) { return (*(uint*)&v) & 0x00FF_FFFF; }
        [IN(LINE)] public static int Hash(bool3 v) { return unchecked((int)UHash(v)); }
        #endregion

        #region All/Any
        [IN(LINE)] public static bool All(bool3 a) { return a.x && a.y && a.z; }
        [IN(LINE)] public static bool Any(bool3 a) { return a.x || a.y || a.z; }
        #endregion
    }
    public static partial class DMBits // bool2
    {
        #region Bits
        [IN(LINE)]
        public static int BitMask(bool3 value)
        {
            int mask = 0;
            if (value.x) { mask |= 0x01; }
            if (value.y) { mask |= 0x02; }
            if (value.z) { mask |= 0x04; }
            return mask;
        }
        #endregion
    }
}
