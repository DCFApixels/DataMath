using System.Runtime.CompilerServices;

namespace DCFApixels.DataMath
{
    public static partial class math // as
    {
        #region asfloat from int/uint
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static float AsFloat(int value) => *(float*)&value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static float2 AsFloat2(int2 value) => *(float2*)&value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static float3 AsFloat3(int3 value) => *(float3*)&value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static float4 AsFloat4(int4 value) => *(float4*)&value;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static float asfloat(uint value) => *(float*)&value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static float2 asfloat2(uint2 value) => *(float2*)&value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static float3 asfloat3(uint3 value) => *(float3*)&value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static float4 asfloat4(uint4 value) => *(float4*)&value;
        #endregion

        #region asint/asuint from float
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static int asint(float value) => *(int*)&value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static int2 asint2(float2 value) => *(int2*)&value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static int3 asint3(float3 value) => *(int3*)&value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static int4 asint4(float4 value) => *(int4*)&value;


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static uint asuint(float value) => *(uint*)&value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static uint2 asuint2(float2 value) => *(uint2*)&value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static uint3 asuint3(float3 value) => *(uint3*)&value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static uint4 asuint4(float4 value) => *(uint4*)&value;
        #endregion

        #region asdouble from long/ulong
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static double asdouble(long value) => *(double*)&value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static double asdouble(ulong value) => *(double*)&value;
        #endregion

        #region aslong/asulong from double
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static long aslong(double value) => *(long*)&value;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static ulong asulong(double value) => *(ulong*)&value;
        #endregion
    }
}
