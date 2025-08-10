using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public static partial class DM // vector hashes
    {
        #region Bool
        [IN(LINE)] public unsafe static uint UHash(bool v) { return *(uint*)&v & 0x0000_00FF; }
        [IN(LINE)] public static int Hash(bool v) { return unchecked((int)UHash(v)); }

        [IN(LINE)] public unsafe static uint UHash(bool2 v) { return *(uint*)&v & 0x0000_FFFF; }
        [IN(LINE)] public static int Hash(bool2 v) { return unchecked((int)UHash(v)); }

        [IN(LINE)] public unsafe static uint UHash(bool3 v) { return (*(uint*)&v) & 0x00FF_FFFF; }
        [IN(LINE)] public static int Hash(bool3 v) { return unchecked((int)UHash(v)); }

        [IN(LINE)] public unsafe static uint UHash(bool4 v) { return *(uint*)&v; }
        [IN(LINE)] public static int Hash(bool4 v) { return unchecked((int)UHash(v)); }
        #endregion

        #region Double
        [IN(LINE)] public static uint UHash(double v) => unchecked((uint)Hash(v));

        [IN(LINE)]
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

        [IN(LINE)]
        public static uint UHash(double2 v) => unchecked((uint)Hash(v));
        [IN(LINE)]
        public static int Hash(double2 v)
        {
            throw new NotImplementedException();
        }

        [IN(LINE)]
        public static uint UHash(double3 v) => unchecked((uint)Hash(v));
        [IN(LINE)]
        public static int Hash(double3 v)
        {
            throw new NotImplementedException();
        }

        [IN(LINE)]
        public static uint UHash(double4 v) => unchecked((uint)Hash(v));
        [IN(LINE)]
        public static int Hash(double4 v)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Float
        [IN(LINE)]
        public static uint UHash(float v) => unchecked((uint)Hash(v));
        [IN(LINE)]
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

        [IN(LINE)]
        public static uint UHash(float2 v) => unchecked((uint)Hash(v));
        [IN(LINE)]
        public static int Hash(float2 v)
        {
            throw new NotImplementedException();
        }

        [IN(LINE)]
        public static uint UHash(float3 v) => unchecked((uint)Hash(v));
        [IN(LINE)]
        public static int Hash(float3 v)
        {
            throw new NotImplementedException();
        }

        [IN(LINE)]
        public static uint UHash(float4 v) => unchecked((uint)Hash(v));
        [IN(LINE)]
        public static int Hash(float4 v)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Int
        [IN(LINE)]
        public static uint UHash(int v) => unchecked((uint)v);
        [IN(LINE)]
        public static int Hash(int v) => v;

        [IN(LINE)]
        public static uint UHash(int2 v) => unchecked((uint)Hash(v));
        [IN(LINE)]
        public static int Hash(int2 v)
        {
            throw new NotImplementedException();
        }

        [IN(LINE)]
        public static uint UHash(int3 v) => unchecked((uint)Hash(v));
        [IN(LINE)]
        public static int Hash(int3 v)
        {
            throw new NotImplementedException();
        }

        [IN(LINE)]
        public static uint UHash(int4 v) => unchecked((uint)Hash(v));
        [IN(LINE)]
        public static int Hash(int4 v)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region UInt
        [IN(LINE)]
        public static uint UHash(uint v) => v;
        [IN(LINE)]
        public static int Hash(uint v) => unchecked((int)v);

        [IN(LINE)]
        public static uint UHash(uint2 v) => unchecked((uint)Hash(v));
        [IN(LINE)]
        public static int Hash(uint2 v)
        {
            throw new NotImplementedException();
        }

        [IN(LINE)]
        public static uint UHash(uint3 v) => unchecked((uint)Hash(v));
        [IN(LINE)]
        public static int Hash(uint3 v)
        {
            throw new NotImplementedException();
        }

        [IN(LINE)]
        public static uint UHash(uint4 v) => unchecked((uint)Hash(v));
        [IN(LINE)]
        public static int Hash(uint4 v)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
