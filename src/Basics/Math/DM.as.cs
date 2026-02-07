#pragma warning disable CS8981
using DCFApixels.DataMath.Internal;
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public static partial class DM // as
    {
        #region asfloat from int/uint
        [IN(LINE)] public unsafe static float AsFloat(int value) { return *(float*)&value; }
        [IN(LINE)] public unsafe static float2 AsFloat2(int2 value) { return *(float2*)&value; }
        [IN(LINE)] public unsafe static float3 AsFloat3(int3 value) { return *(float3*)&value; }
        [IN(LINE)] public unsafe static float4 AsFloat4(int4 value) { return *(float4*)&value; }

        [IN(LINE)] public unsafe static float AsFloat(uint value) { return *(float*)&value; }
        [IN(LINE)] public unsafe static float2 AsFloat2(uint2 value) { return *(float2*)&value; }
        [IN(LINE)] public unsafe static float3 AsFloat3(uint3 value) { return *(float3*)&value; }
        [IN(LINE)] public unsafe static float4 AsFloat4(uint4 value) { return *(float4*)&value; }
        #endregion

        #region asint/asuint from float
        [IN(LINE)] public unsafe static int AsInt(float value) { return *(int*)&value; }
        [IN(LINE)] public unsafe static int2 AsInt2(float2 value) { return *(int2*)&value; }
        [IN(LINE)] public unsafe static int3 AsInt3(float3 value) { return *(int3*)&value; }
        [IN(LINE)] public unsafe static int4 AsInt4(float4 value) { return *(int4*)&value; }


        [IN(LINE)] public unsafe static uint AsUInt(float value) { return *(uint*)&value; }
        [IN(LINE)] public unsafe static uint2 AsUInt2(float2 value) { return *(uint2*)&value; }
        [IN(LINE)] public unsafe static uint3 AsUInt3(float3 value) { return *(uint3*)&value; }
        [IN(LINE)] public unsafe static uint4 AsUInt4(float4 value) { return *(uint4*)&value; }
        #endregion

        #region asdouble from long/ulong
        [IN(LINE)] public unsafe static double AsDouble(long value) { return *(double*)&value; }
        [IN(LINE)] public unsafe static double AsDouble(ulong value) { return *(double*)&value; }
        #endregion

        #region aslong/asulong from double
        [IN(LINE)] public unsafe static long AsLong(double value) { return *(long*)&value; }
        [IN(LINE)] public unsafe static ulong AsULong(double value) { return *(ulong*)&value; }
        #endregion


        [IN(LINE)] public static float AsFloatFraction(int a) { unchecked { return AsFloatFraction((uint)a); } }
        [IN(LINE)] public static double AsDoubleFraction(int a) { unchecked { return AsDoubleFraction((uint)a); } }
        [IN(LINE)] public static float AsFloatFraction(uint a) { unchecked { return InternalBits.Q32ToFloat(a); } }
        [IN(LINE)]
        public static double AsDoubleFraction(uint a)
        {
            unchecked
            {
                UInt2ULongUnion u = default;
                u.uint2Value.x = a;
                return InternalBits.Q64ToDouble(u.ulongValue);
            }
        }
        [IN(LINE)] public static float AsFloatFraction(long a) { unchecked { return AsFloatFraction((ulong)a); } }
        [IN(LINE)] public static double AsDoubleFraction(long a) { unchecked { return AsDoubleFraction((ulong)a); } }
        [IN(LINE)]
        public static float AsFloatFraction(ulong a)
        {
            unchecked
            {
                UInt2ULongUnion u = default;
                u.ulongValue = a;
                return InternalBits.Q32ToFloat(u.uint2Value.x);
            }
        }
        [IN(LINE)] public static double AsDoubleFraction(ulong a) { unchecked { return InternalBits.Q64ToDouble(a); } }
    }
}
