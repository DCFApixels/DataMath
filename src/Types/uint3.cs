using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.ComponentModel;
using SMath = System.Math;
using SMathF = System.MathF;

namespace DCFApixels.DataMath
{
    [DebuggerTypeProxy(typeof(DebuggerProxy))]
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 4, Size = 12)]
    public partial struct uint3 : IEquatable<uint3>, IFormattable, IValue3<uint>
    {
        #region Consts
        public const int length = 3;

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

        #region IValueN
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint X 
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => x; 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => x = value; 
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint Y 
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => y; 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => y = value; 
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint Z 
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => z;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => z = value;
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Length
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => length;
        }

        public unsafe ref uint this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > length) throw new IndexOutOfRangeException($"index must be between[0...{(length - 1)}]");
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

        #region Convert operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(float v) => new uint3(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(float3 v) => new uint3(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(int v) => new uint3(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(int3 v) => new uint3(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint3(uint v) => new uint3(v);
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static implicit operator uint3(uint3 v) => new uint3(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(double v) => new uint3(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator uint3(double3 v) => new uint3(v);
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
            private byte _pointer;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Enumerator(uint3 value) { _value = value; _pointer = 0; }
            public uint Current => _value[_pointer];

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Dispose() { }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool MoveNext() => ++_pointer < _value.Length;

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

    public static partial class math
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 one_minus(uint3 v) => 1u - v;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint3 abs(uint3 v)
        {
            return new uint3(SMathF.Abs(v.x), SMathF.Abs(v.y), SMathF.Abs(v.z));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 sign(uint3 v)
        {
            return new int3(SMath.Sign(v.x), SMath.Sign(v.y), SMath.Sign(v.z));
        }
        
    }
}
