using System.Runtime.CompilerServices;

namespace DCFApixels.DataMath
{
    public static partial class DM // vector hashes
    {
        #region Bool
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static uint UHash(bool v) => *(uint*)&v & 0x0000_00FF;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Hash(bool v) => unchecked((int)UHash(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static uint UHash(bool2 v) => *(uint*)&v & 0x0000_FFFF;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Hash(bool2 v) => unchecked((int)UHash(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static uint UHash(bool3 v) => (*(uint*)&v) & 0x00FF_FFFF;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Hash(bool3 v) => unchecked((int)UHash(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static uint UHash(bool4 v) => *(uint*)&v;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Hash(bool4 v) => unchecked((int)UHash(v));
        #endregion

        #region Double
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint UHash(double v) => unchecked((uint)Hash(v));

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe int Hash(double v)
        {
            long bits = *(long*)&v;
            // Optimized check for IsNan() || IsZero()
            if (((bits - 1) & 0x7FFFFFFFFFFFFFFF) >= 0x7FF0000000000000)
            {
                // Ensure that all NaNs and both zeros have the same Hash code
                bits &= 0x7FF0000000000000;
            }
            return unchecked((int)bits) ^ ((int)(bits >> 32));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint UHash(double2 v) => unchecked((uint)Hash(v));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Hash(double2 v)
        {
            throw new NotImplementedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint UHash(double3 v) => unchecked((uint)Hash(v));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Hash(double3 v)
        {
            throw new NotImplementedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint UHash(double4 v) => unchecked((uint)Hash(v));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Hash(double4 v)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Float
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint UHash(float v) => unchecked((uint)Hash(v));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe int Hash(float v)
        {
            int bits = *(int*)&v;
            // Optimized check for IsNan() || IsZero()
            if (((bits - 1) & 0x7FFFFFFF) >= 0x7F800000)
            {
                // Ensure that all NaNs and both zeros have the same Hash code
                bits &= 0x7F800000;
            }
            return bits;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint UHash(float2 v) => unchecked((uint)Hash(v));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Hash(float2 v)
        {
            throw new NotImplementedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint UHash(float3 v) => unchecked((uint)Hash(v));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Hash(float3 v)
        {
            throw new NotImplementedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint UHash(float4 v) => unchecked((uint)Hash(v));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Hash(float4 v)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Int
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint UHash(int v) => unchecked((uint)v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Hash(int v) => v;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint UHash(int2 v) => unchecked((uint)Hash(v));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Hash(int2 v)
        {
            throw new NotImplementedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint UHash(int3 v) => unchecked((uint)Hash(v));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Hash(int3 v)
        {
            throw new NotImplementedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint UHash(int4 v) => unchecked((uint)Hash(v));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Hash(int4 v)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region UInt
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint UHash(uint v) => v;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Hash(uint v) => unchecked((int)v);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint UHash(uint2 v) => unchecked((uint)Hash(v));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Hash(uint2 v)
        {
            throw new NotImplementedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint UHash(uint3 v) => unchecked((uint)Hash(v));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Hash(uint3 v)
        {
            throw new NotImplementedException();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint UHash(uint4 v) => unchecked((uint)Hash(v));
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Hash(uint4 v)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
