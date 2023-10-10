using System;
using System.Runtime.CompilerServices;

namespace DCFApixels.DataMath
{
    public static partial class math
    {
        #region Bool
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static uint uhash(bool v) => *(uint*)&v & 0x0000_00FF;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int hash(bool v) => unchecked((int)uhash(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static uint uhash(bool2 v) => *(uint*)&v & 0x0000_FFFF;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int hash(bool2 v) => unchecked((int)uhash(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static uint uhash(bool3 v) => (*(uint*)&v) & 0x00FF_FFFF;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int hash(bool3 v) => unchecked((int)uhash(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static uint uhash(bool4 v) => *(uint*)&v;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int hash(bool4 v) => unchecked((int)uhash(v));
        #endregion

        #region Double
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint uhash(double v) => unchecked((uint)hash(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe int hash(double v)
        {
            long bits = *(long*)&v;
            // Optimized check for IsNan() || IsZero()
            if (((bits - 1) & 0x7FFFFFFFFFFFFFFF) >= 0x7FF0000000000000)
            {
                // Ensure that all NaNs and both zeros have the same hash code
                bits &= 0x7FF0000000000000;
            }
            return unchecked((int)bits) ^ ((int)(bits >> 32));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint uhash(double2 v) => unchecked((uint)hash(v));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int hash(double2 v)
        {
            throw new NotImplementedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint uhash(double3 v) => unchecked((uint)hash(v));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int hash(double3 v)
        {
            throw new NotImplementedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint uhash(double4 v) => unchecked((uint)hash(v));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int hash(double4 v)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Float
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint uhash(float v) => unchecked((uint)hash(v));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe int hash(float v)
        {
            int bits = *(int*)&v;
            // Optimized check for IsNan() || IsZero()
            if (((bits - 1) & 0x7FFFFFFF) >= 0x7F800000)
            {
                // Ensure that all NaNs and both zeros have the same hash code
                bits &= 0x7F800000;
            }
            return bits;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint uhash(float2 v) => unchecked((uint)hash(v));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int hash(float2 v)
        {
            throw new NotImplementedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint uhash(float3 v) => unchecked((uint)hash(v));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int hash(float3 v)
        {
            throw new NotImplementedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint uhash(float4 v) => unchecked((uint)hash(v));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int hash(float4 v)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Int
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint uhash(int v) => unchecked((uint)v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int hash(int v) => v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint uhash(int2 v) => unchecked((uint)hash(v));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int hash(int2 v)
        {
            throw new NotImplementedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint uhash(int3 v) => unchecked((uint)hash(v));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int hash(int3 v)
        {
            throw new NotImplementedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint uhash(int4 v) => unchecked((uint)hash(v));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int hash(int4 v)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region UInt
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint uhash(uint v) => v;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int hash(uint v) => unchecked((int)v);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint uhash(uint2 v) => unchecked((uint)hash(v));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int hash(uint2 v)
        {
            throw new NotImplementedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint uhash(uint3 v) => unchecked((uint)hash(v));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int hash(uint3 v)
        {
            throw new NotImplementedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint uhash(uint4 v) => unchecked((uint)hash(v));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int hash(uint4 v)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
