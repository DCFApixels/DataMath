using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace DCFApixels.DataMath
{
    [DebuggerTypeProxy(typeof(DebuggerProxy))]
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 4, Size = 12)]
    public partial struct uint3 : 
        IEquatable<uint3>, 
        IFormattable, 
        IVector3<uint>, 
        IColor
    {
        #region Consts
        public const int LENGTH = 3;

        ///<summary>(0, 0, 0)</summary>
        public static readonly uint3 zero = new uint3(0u, 0u, 0u);
        ///<summary>(1, 1, 1)</summary>
        public static readonly uint3 one = new uint3(1u, 1u, 1u);

        ///<summary>(-1, 0, 0)</summary>
        public static readonly uint3 left = new uint3(-1u, 0u, 0u);
        ///<summary>(1, 0, 0)</summary>
        public static readonly uint3 right = new uint3(1u, 0u, 0u);
        ///<summary>(0, -1, 0)</summary>
        public static readonly uint3 down = new uint3(0u, -1u, 0u);
        ///<summary>(0, 1, 0)</summary>
        public static readonly uint3 up = new uint3(0u, 1u, 0u);
        ///<summary>(0, 0, -1)</summary>
        public static readonly uint3 back = new uint3(0u, 0u, -1u);
        ///<summary>(0, 0, 1)</summary>
        public static readonly uint3 forward = new uint3(0u, 0u, 1u);
        #endregion

        public uint x;
        public uint y;
        public uint z;

        #region IColor
        public float r 
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => (float)x;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => x = (uint)value;
        }
        public float g 
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => (float)y;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => y = (uint)value;
        }
        public float b 
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => (float)z;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => z = (uint)value;
        }
        public float a 
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 0f;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {}
        }
        #endregion

        #region IVectorN
        [EditorBrowsable(EditorBrowsableState.Never)]
        uint IVector1<uint>.x 
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => x; 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => x = value; 
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        uint IVector2<uint>.y
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => y; 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => y = value; 
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        uint IVector3<uint>.z 
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => z;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => z = value;
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int length
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => LENGTH;
        }

        public unsafe ref uint this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > LENGTH) throw new IndexOutOfRangeException($"index must be between[0...{(LENGTH - 1)}]");
#endif
                fixed (uint3* array = &this) { return ref ((uint*)array)[index]; }
            }
        }
        #endregion

        #region Constructors
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(float x, float y, float z)
        {
            this.x = (uint)x; this.y = (uint)y; this.z = (uint)z;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(float v)
        {
            x = (uint)v; y = (uint)v; z = (uint)v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(float3 v)
        {
            x = (uint)v.x; y = (uint)v.y; z = (uint)v.z;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(double x, double y, double z)
        {
            this.x = (uint)x; this.y = (uint)y; this.z = (uint)z;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(double v)
        {
            x = (uint)v; y = (uint)v; z = (uint)v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(double3 v)
        {
            x = (uint)v.x; y = (uint)v.y; z = (uint)v.z;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(int x, int y, int z)
        {
            this.x = (uint)x; this.y = (uint)y; this.z = (uint)z;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(int v)
        {
            x = (uint)v; y = (uint)v; z = (uint)v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(int3 v)
        {
            x = (uint)v.x; y = (uint)v.y; z = (uint)v.z;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(uint x, uint y, uint z)
        {
            this.x = x; this.y = y; this.z = z;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(uint v)
        {
            x = v; y = v; z = v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint3(uint3 v)
        {
            x = v.x; y = v.y; z = v.z;
        }

        #endregion

        #region Arithmetic operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator *(uint3 a, uint3 b) => new uint3(a.x * b.x, a.y * b.y, a.z * b.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator *(uint3 a, uint b) => new uint3(a.x * b, a.y * b, a.z * b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator *(uint a, uint3 b) => new uint3(a * b.x, a * b.y, a * b.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator +(uint3 a, uint3 b) => new uint3(a.x + b.x, a.y + b.y, a.z + b.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator +(uint3 a, uint b) => new uint3(a.x + b, a.y + b, a.z + b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator +(uint a, uint3 b) => new uint3(a + b.x, a + b.y, a + b.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator -(uint3 a, uint3 b) => new uint3(a.x - b.x, a.y - b.y, a.z - b.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator -(uint3 a, uint b) => new uint3(a.x - b, a.y - b, a.z - b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator -(uint a, uint3 b) => new uint3(a - b.x, a - b.y, a - b.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator /(uint3 a, uint3 b) => new uint3(a.x / b.x, a.y / b.y, a.z / b.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator /(uint3 a, uint b) => new uint3(a.x / b, a.y / b, a.z / b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator /(uint a, uint3 b) => new uint3(a / b.x, a / b.y, a / b.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator %(uint3 a, uint3 b) => new uint3(a.x % b.x, a.y % b.y, a.z % b.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator %(uint3 a, uint b) => new uint3(a.x % b, a.y % b, a.z % b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator %(uint a, uint3 b) => new uint3(a % b.x, a % b.y, a % b.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator ++(uint3 a) => new uint3(++a.x, ++a.y, ++a.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator --(uint3 a) => new uint3(--a.x, --a.y, --a.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator -(uint3 a) => new uint3(-a.x, -a.y, -a.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator +(uint3 a) => new uint3(+a.x, +a.y, +a.z);
        #endregion

        #region Bit operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator ~(uint3 a) => new uint3(~a.x, ~a.y, ~a.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator <<(uint3 a, int n) => new uint3(a.x << n, a.y << n, a.z << n);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator >>(uint3 a, int n) => new uint3(a.x >> n, a.y >> n, a.z >> n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator |(uint3 a, uint3 b) => new uint3(a.x | b.x, a.y | b.y, a.z | b.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator |(uint3 a, uint b) => new uint3(a.x | b, a.y | b, a.z | b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator |(uint a, uint3 b) => new uint3(a | b.x, a | b.y, a | b.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator &(uint3 a, uint3 b) => new uint3(a.x & b.x, a.y & b.y, a.z & b.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator &(uint3 a, uint b) => new uint3(a.x & b, a.y & b, a.z & b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator &(uint a, uint3 b) => new uint3(a & b.x, a & b.y, a & b.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator ^(uint3 a, uint3 b) => new uint3(a.x ^ b.x, a.y ^ b.y, a.z ^ b.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator ^(uint3 a, uint b) => new uint3(a.x ^ b, a.y ^ b, a.z ^ b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 operator ^(uint a, uint3 b) => new uint3(a ^ b.x, a ^ b.y, a ^ b.z);
        #endregion

        #region Boolean operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(uint3 a, uint3 b) => a.x == b.x && a.y == b.y && a.z == b.z;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(uint3 a, uint b) => a.x == b && a.y == b && a.z == b;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(uint a, uint3 b) => a == b.x && a == b.y && a == b.z;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(uint3 a, uint3 b) => a.x != b.x || a.y != b.y || a.z != b.z;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(uint3 a, uint b) => a.x != b || a.y != b || a.z != b;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(uint a, uint3 b) => a != b.x || a != b.y || a != b.z;
        #endregion

        #region Swap2
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint2 xx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint2(x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint2 xy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint2(x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint2 xz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint2(x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint2 x_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint2(x, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint2 yx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint2(y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint2 yy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint2(y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint2 yz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint2(y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint2 y_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint2(y, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint2 zx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint2(z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint2 zy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint2(z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint2 zz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint2(z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint2 z_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint2(z, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint2 _x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint2(0u, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint2 _y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint2(0u, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint2 _z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint2(0u, z);
         }
        #endregion

        #region Swap3
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 xxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(x, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 xxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(x, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 xxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(x, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 xx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(x, x, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 xyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(x, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 xyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(x, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 xyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(x, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 xy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(x, y, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 xzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(x, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 xzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(x, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 xzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(x, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 xz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(x, z, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 x_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(x, 0u, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 x_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(x, 0u, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 x_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(x, 0u, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 x__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(x, 0u, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 yxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(y, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 yxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(y, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 yxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(y, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 yx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(y, x, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 yyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(y, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 yyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(y, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 yyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(y, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 yy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(y, y, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 yzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(y, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 yzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(y, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 yzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(y, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 yz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(y, z, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 y_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(y, 0u, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 y_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(y, 0u, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 y_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(y, 0u, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 y__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(y, 0u, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 zxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(z, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 zxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(z, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 zxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(z, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 zx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(z, x, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 zyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(z, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 zyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(z, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 zyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(z, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 zy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(z, y, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 zzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(z, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 zzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(z, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 zzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(z, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 zz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(z, z, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 z_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(z, 0u, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 z_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(z, 0u, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 z_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(z, 0u, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 z__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(z, 0u, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 _xx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(0u, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 _xy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(0u, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 _xz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(0u, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 _x_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(0u, x, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 _yx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(0u, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 _yy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(0u, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 _yz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(0u, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 _y_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(0u, y, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 _zx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(0u, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 _zy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(0u, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 _zz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(0u, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 _z_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(0u, z, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 __x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(0u, 0u, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 __y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(0u, 0u, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 __z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(0u, 0u, z);
         }
        #endregion

        #region Swap4
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xxxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, x, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xxxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, x, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xxxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, x, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xxx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, x, x, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xxyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, x, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xxyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, x, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xxyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, x, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xxy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, x, y, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xxzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, x, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xxzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, x, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xxzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, x, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xxz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, x, z, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xx_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, x, 0u, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xx_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, x, 0u, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xx_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, x, 0u, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xx__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, x, 0u, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xyxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, y, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xyxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, y, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xyxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, y, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xyx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, y, x, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xyyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, y, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xyyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, y, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xyyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, y, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xyy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, y, y, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xyzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, y, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xyzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, y, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xyzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, y, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xyz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, y, z, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xy_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, y, 0u, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xy_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, y, 0u, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xy_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, y, 0u, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xy__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, y, 0u, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xzxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, z, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xzxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, z, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xzxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, z, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xzx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, z, x, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xzyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, z, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xzyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, z, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xzyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, z, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xzy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, z, y, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xzzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, z, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xzzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, z, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xzzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, z, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xzz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, z, z, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xz_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, z, 0u, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xz_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, z, 0u, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xz_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, z, 0u, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xz__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, z, 0u, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 x_xx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, 0u, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 x_xy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, 0u, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 x_xz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, 0u, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 x_x_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, 0u, x, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 x_yx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, 0u, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 x_yy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, 0u, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 x_yz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, 0u, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 x_y_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, 0u, y, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 x_zx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, 0u, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 x_zy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, 0u, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 x_zz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, 0u, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 x_z_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, 0u, z, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 x__x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, 0u, 0u, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 x__y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, 0u, 0u, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 x__z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, 0u, 0u, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 x___
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, 0u, 0u, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yxxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, x, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yxxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, x, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yxxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, x, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yxx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, x, x, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yxyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, x, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yxyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, x, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yxyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, x, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yxy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, x, y, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yxzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, x, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yxzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, x, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yxzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, x, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yxz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, x, z, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yx_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, x, 0u, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yx_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, x, 0u, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yx_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, x, 0u, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yx__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, x, 0u, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yyxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, y, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yyxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, y, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yyxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, y, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yyx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, y, x, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yyyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, y, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yyyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, y, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yyyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, y, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yyy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, y, y, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yyzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, y, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yyzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, y, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yyzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, y, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yyz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, y, z, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yy_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, y, 0u, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yy_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, y, 0u, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yy_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, y, 0u, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yy__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, y, 0u, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yzxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, z, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yzxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, z, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yzxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, z, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yzx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, z, x, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yzyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, z, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yzyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, z, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yzyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, z, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yzy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, z, y, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yzzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, z, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yzzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, z, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yzzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, z, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yzz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, z, z, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yz_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, z, 0u, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yz_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, z, 0u, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yz_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, z, 0u, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yz__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, z, 0u, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 y_xx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, 0u, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 y_xy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, 0u, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 y_xz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, 0u, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 y_x_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, 0u, x, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 y_yx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, 0u, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 y_yy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, 0u, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 y_yz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, 0u, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 y_y_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, 0u, y, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 y_zx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, 0u, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 y_zy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, 0u, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 y_zz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, 0u, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 y_z_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, 0u, z, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 y__x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, 0u, 0u, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 y__y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, 0u, 0u, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 y__z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, 0u, 0u, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 y___
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, 0u, 0u, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zxxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, x, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zxxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, x, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zxxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, x, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zxx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, x, x, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zxyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, x, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zxyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, x, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zxyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, x, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zxy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, x, y, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zxzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, x, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zxzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, x, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zxzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, x, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zxz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, x, z, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zx_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, x, 0u, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zx_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, x, 0u, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zx_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, x, 0u, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zx__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, x, 0u, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zyxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, y, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zyxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, y, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zyxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, y, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zyx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, y, x, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zyyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, y, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zyyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, y, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zyyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, y, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zyy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, y, y, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zyzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, y, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zyzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, y, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zyzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, y, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zyz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, y, z, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zy_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, y, 0u, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zy_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, y, 0u, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zy_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, y, 0u, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zy__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, y, 0u, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zzxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, z, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zzxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, z, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zzxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, z, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zzx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, z, x, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zzyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, z, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zzyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, z, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zzyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, z, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zzy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, z, y, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zzzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, z, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zzzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, z, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zzzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, z, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zzz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, z, z, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zz_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, z, 0u, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zz_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, z, 0u, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zz_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, z, 0u, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zz__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, z, 0u, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 z_xx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, 0u, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 z_xy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, 0u, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 z_xz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, 0u, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 z_x_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, 0u, x, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 z_yx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, 0u, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 z_yy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, 0u, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 z_yz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, 0u, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 z_y_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, 0u, y, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 z_zx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, 0u, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 z_zy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, 0u, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 z_zz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, 0u, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 z_z_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, 0u, z, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 z__x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, 0u, 0u, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 z__y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, 0u, 0u, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 z__z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, 0u, 0u, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 z___
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, 0u, 0u, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _xxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, x, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _xxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, x, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _xxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, x, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _xx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, x, x, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _xyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, x, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _xyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, x, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _xyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, x, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _xy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, x, y, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _xzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, x, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _xzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, x, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _xzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, x, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _xz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, x, z, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _x_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, x, 0u, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _x_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, x, 0u, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _x_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, x, 0u, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _x__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, x, 0u, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _yxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, y, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _yxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, y, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _yxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, y, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _yx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, y, x, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _yyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, y, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _yyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, y, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _yyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, y, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _yy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, y, y, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _yzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, y, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _yzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, y, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _yzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, y, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _yz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, y, z, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _y_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, y, 0u, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _y_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, y, 0u, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _y_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, y, 0u, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _y__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, y, 0u, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _zxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, z, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _zxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, z, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _zxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, z, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _zx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, z, x, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _zyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, z, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _zyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, z, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _zyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, z, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _zy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, z, y, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _zzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, z, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _zzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, z, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _zzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, z, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _zz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, z, z, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _z_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, z, 0u, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _z_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, z, 0u, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _z_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, z, 0u, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 _z__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, z, 0u, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 __xx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, 0u, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 __xy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, 0u, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 __xz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, 0u, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 __x_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, 0u, x, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 __yx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, 0u, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 __yy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, 0u, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 __yz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, 0u, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 __y_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, 0u, y, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 __zx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, 0u, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 __zy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, 0u, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 __zz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, 0u, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 __z_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, 0u, z, 0u);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 ___x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, 0u, 0u, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 ___y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, 0u, 0u, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 ___z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(0u, 0u, 0u, z);
         }
        #endregion


        #region Object
        public override bool Equals(object o) => o is uint3 target && Equals(target); 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => math.hash(this);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => $"uint3({x}, {y}, {z})";
        #endregion

        #region IEquatable/IFormattable
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(uint3 a) => x == a.x && y == a.y && z == a.z; 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"uint3({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)})";
        }
        #endregion

        #region Enumerator
        public Enumerator GetEnumerator() => new Enumerator(this);
        public ref struct Enumerator
        {
            private readonly uint3 _value;
            private sbyte _pointer;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Enumerator(uint3 value) { _value = value; _pointer = -1; }
            public uint Current => _value[_pointer];

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Dispose() { }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool MoveNext() => ++_pointer < LENGTH;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Reset() { }
        }
        #endregion

        #region Utils
        internal class DebuggerProxy
        {
            public uint x;
            public uint y;
            public uint z;
            public DebuggerProxy(uint3 v)
            {
                x = v.x;
                y = v.y;
                z = v.z;
            }
        }
        #endregion
    }
}
