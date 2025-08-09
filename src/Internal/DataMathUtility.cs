using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath.Internal
{
    internal static class DataMathUtility
    {
        [IN(LINE)] public static unsafe float AsFloat(uint value) => *(float*)&value;
        [IN(LINE)] public static unsafe double AsDouble(ulong value) => *(double*)&value;

        [IN(LINE)] public static unsafe int AsInteger(float value) => *(int*)&value;
        [IN(LINE)] public static unsafe long AsInteger(double value) => *(long*)&value;

        [IN(LINE)] public static unsafe uint AsUInteger(float value) => *(uint*)&value;
        [IN(LINE)] public static unsafe ulong AsUInteger(double value) => *(ulong*)&value;
    }
}
