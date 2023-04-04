using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections;

namespace DCFApixels.DataMath
{
    [DebuggerTypeProxy(typeof(DebuggerProxy))]
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 4, Size = 16)]
    public partial struct uint4 : 
        IEquatable<uint4>, 
        IFormattable, 
        IVector4<uint>, 
        IColor,
        IEnumerableVector<uint, uint4>
    {
        #region Consts
        public const int LENGTH = 4;

        ///<summary>(0, 0, 0, 0)</summary>
        public static readonly uint4 zero = new uint4(0u, 0u, 0u, 0u);
        ///<summary>(1, 1, 1, 1)</summary>
        public static readonly uint4 one = new uint4(1u, 1u, 1u, 1u);

        ///<summary>(-1, 0, 0, 0)</summary>
        public static readonly uint4 left = new uint4(-1u, 0u, 0u, 0u);
        ///<summary>(1, 0, 0, 0)</summary>
        public static readonly uint4 right = new uint4(1u, 0u, 0u, 0u);
        ///<summary>(0, -1, 0, 0)</summary>
        public static readonly uint4 down = new uint4(0u, -1u, 0u, 0u);
        ///<summary>(0, 1, 0, 0)</summary>
        public static readonly uint4 up = new uint4(0u, 1u, 0u, 0u);
        ///<summary>(0, 0, -1, 0)</summary>
        public static readonly uint4 back = new uint4(0u, 0u, -1u, 0u);
        ///<summary>(0, 0, 1, 0)</summary>
        public static readonly uint4 forward = new uint4(0u, 0u, 1u, 0u);
        ///<summary>(0, 0, 0, -1)</summary>
        public static readonly uint4 before = new uint4(0u, 0u, 0u, -1u);
        ///<summary>(0, 0, 0, 1)</summary>
        public static readonly uint4 after = new uint4(0u, 0u, 0u, 1u);
        #endregion

        public uint x;
        public uint y;
        public uint z;
        public uint w;

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
            get => (float)w;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => w = (uint)value;
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
        uint IVector4<uint>.w 
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => w;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => w = value;
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
                fixed (uint4* array = &this) { return ref ((uint*)array)[index]; }
            }
        }
        #endregion

        #region Constructors
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4(float x, float y, float z, float w)
        {
            this.x = (uint)x; this.y = (uint)y;
            this.z = (uint)z; this.w = (uint)w;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4(float v)
        {
            x = (uint)v; y = (uint)v;
            z = (uint)v; w = (uint)v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4(float4 v)
        {
            x = (uint)v.x; y = (uint)v.y;
            z = (uint)v.z; w = (uint)v.w;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4(double x, double y, double z, double w)
        {
            this.x = (uint)x; this.y = (uint)y;
            this.z = (uint)z; this.w = (uint)w;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4(double v)
        {
            x = (uint)v; y = (uint)v;
            z = (uint)v; w = (uint)v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4(double4 v)
        {
            x = (uint)v.x; y = (uint)v.y;
            z = (uint)v.z; w = (uint)v.w;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4(int x, int y, int z, int w)
        {
            this.x = (uint)x; this.y = (uint)y;
            this.z = (uint)z; this.w = (uint)w;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4(int v)
        {
            x = (uint)v; y = (uint)v;
            z = (uint)v; w = (uint)v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4(int4 v)
        {
            x = (uint)v.x; y = (uint)v.y;
            z = (uint)v.z; w = (uint)v.w;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4(uint x, uint y, uint z, uint w)
        {
            this.x = x; this.y = y;
            this.z = z; this.w = w;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4(uint v)
        {
            x = v; y = v;
            z = v; w = v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public uint4(uint4 v)
        {
            x = v.x; y = v.y;
            z = v.z; w = v.w;
        }

        #endregion

        #region Arithmetic operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator *(uint4 a, uint4 b) => new uint4(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator *(uint4 a, uint b) => new uint4(a.x * b, a.y * b, a.z * b, a.w * b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator *(uint a, uint4 b) => new uint4(a * b.x, a * b.y, a * b.z, a * b.w);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator +(uint4 a, uint4 b) => new uint4(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator +(uint4 a, uint b) => new uint4(a.x + b, a.y + b, a.z + b, a.w + b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator +(uint a, uint4 b) => new uint4(a + b.x, a + b.y, a + b.z, a + b.w);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator -(uint4 a, uint4 b) => new uint4(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator -(uint4 a, uint b) => new uint4(a.x - b, a.y - b, a.z - b, a.w - b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator -(uint a, uint4 b) => new uint4(a - b.x, a - b.y, a - b.z, a - b.w);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator /(uint4 a, uint4 b) => new uint4(a.x / b.x, a.y / b.y, a.z / b.z, a.w / b.w);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator /(uint4 a, uint b) => new uint4(a.x / b, a.y / b, a.z / b, a.w / b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator /(uint a, uint4 b) => new uint4(a / b.x, a / b.y, a / b.z, a / b.w);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator %(uint4 a, uint4 b) => new uint4(a.x % b.x, a.y % b.y, a.z % b.z, a.w % b.w);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator %(uint4 a, uint b) => new uint4(a.x % b, a.y % b, a.z % b, a.w % b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator %(uint a, uint4 b) => new uint4(a % b.x, a % b.y, a % b.z, a % b.w);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator ++(uint4 a) => new uint4(++a.x, ++a.y, ++a.z, ++a.w);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator --(uint4 a) => new uint4(--a.x, --a.y, --a.z, --a.w);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator -(uint4 a) => new uint4(-a.x, -a.y, -a.z, -a.w);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator +(uint4 a) => new uint4(+a.x, +a.y, +a.z, +a.w);
        #endregion

        #region Bit operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator ~(uint4 a) => new uint4(~a.x, ~a.y, ~a.z, ~a.w);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator <<(uint4 a, int n) => new uint4(a.x << n, a.y << n, a.z << n, a.w << n);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator >>(uint4 a, int n) => new uint4(a.x >> n, a.y >> n, a.z >> n, a.w >> n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator |(uint4 a, uint4 b) => new uint4(a.x | b.x, a.y | b.y, a.z | b.z, a.w | b.w);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator |(uint4 a, uint b) => new uint4(a.x | b, a.y | b, a.z | b, a.w | b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator |(uint a, uint4 b) => new uint4(a | b.x, a | b.y, a | b.z, a | b.w);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator &(uint4 a, uint4 b) => new uint4(a.x & b.x, a.y & b.y, a.z & b.z, a.w & b.w);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator &(uint4 a, uint b) => new uint4(a.x & b, a.y & b, a.z & b, a.w & b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator &(uint a, uint4 b) => new uint4(a & b.x, a & b.y, a & b.z, a & b.w);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator ^(uint4 a, uint4 b) => new uint4(a.x ^ b.x, a.y ^ b.y, a.z ^ b.z, a.w ^ b.w);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator ^(uint4 a, uint b) => new uint4(a.x ^ b, a.y ^ b, a.z ^ b, a.w ^ b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint4 operator ^(uint a, uint4 b) => new uint4(a ^ b.x, a ^ b.y, a ^ b.z, a ^ b.w);
        #endregion

        #region Boolean operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(uint4 a, uint4 b) => a.x == b.x && a.y == b.y && a.z == b.z && a.w == b.w;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(uint4 a, uint b) => a.x == b && a.y == b && a.z == b && a.w == b;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(uint a, uint4 b) => a == b.x && a == b.y && a == b.z && a == b.w;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(uint4 a, uint4 b) => a.x != b.x || a.y != b.y || a.z != b.z || a.w != b.w;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(uint4 a, uint b) => a.x != b || a.y != b || a.z != b || a.w != b;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(uint a, uint4 b) => a != b.x || a != b.y || a != b.z || a != b.w;
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
         public uint2 xw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint2(x, w);
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
         public uint2 yw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint2(y, w);
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
         public uint2 zw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint2(z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint2 wx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint2(w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint2 wy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint2(w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint2 wz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint2(w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint2 ww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint2(w, w);
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
         public uint3 xxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(x, x, w);
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
         public uint3 xyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(x, y, w);
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
         public uint3 xzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(x, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 xwx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(x, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 xwy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(x, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 xwz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(x, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 xww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(x, w, w);
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
         public uint3 yxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(y, x, w);
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
         public uint3 yyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(y, y, w);
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
         public uint3 yzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(y, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 ywx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(y, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 ywy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(y, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 ywz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(y, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 yww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(y, w, w);
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
         public uint3 zxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(z, x, w);
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
         public uint3 zyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(z, y, w);
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
         public uint3 zzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(z, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 zwx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(z, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 zwy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(z, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 zwz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(z, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 zww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(z, w, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 wxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(w, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 wxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(w, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 wxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(w, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 wxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(w, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 wyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(w, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 wyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(w, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 wyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(w, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 wyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(w, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 wzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(w, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 wzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(w, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 wzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(w, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 wzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(w, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 wwx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(w, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 wwy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(w, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 wwz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(w, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 www
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint3(w, w, w);
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
         public uint4 xxxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, x, x, w);
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
         public uint4 xxyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, x, y, w);
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
         public uint4 xxzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, x, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xxwx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, x, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xxwy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, x, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xxwz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, x, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xxww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, x, w, w);
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
         public uint4 xyxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, y, x, w);
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
         public uint4 xyyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, y, y, w);
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
         public uint4 xyzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, y, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xywx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, y, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xywy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, y, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xywz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, y, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xyww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, y, w, w);
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
         public uint4 xzxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, z, x, w);
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
         public uint4 xzyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, z, y, w);
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
         public uint4 xzzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, z, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xzwx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, z, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xzwy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, z, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xzwz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, z, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xzww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, z, w, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xwxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, w, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xwxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, w, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xwxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, w, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xwxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, w, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xwyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, w, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xwyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, w, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xwyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, w, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xwyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, w, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xwzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, w, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xwzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, w, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xwzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, w, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xwzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, w, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xwwx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, w, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xwwy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, w, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xwwz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, w, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xwww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(x, w, w, w);
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
         public uint4 yxxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, x, x, w);
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
         public uint4 yxyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, x, y, w);
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
         public uint4 yxzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, x, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yxwx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, x, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yxwy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, x, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yxwz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, x, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yxww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, x, w, w);
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
         public uint4 yyxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, y, x, w);
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
         public uint4 yyyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, y, y, w);
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
         public uint4 yyzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, y, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yywx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, y, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yywy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, y, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yywz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, y, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yyww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, y, w, w);
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
         public uint4 yzxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, z, x, w);
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
         public uint4 yzyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, z, y, w);
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
         public uint4 yzzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, z, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yzwx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, z, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yzwy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, z, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yzwz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, z, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yzww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, z, w, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 ywxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, w, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 ywxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, w, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 ywxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, w, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 ywxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, w, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 ywyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, w, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 ywyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, w, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 ywyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, w, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 ywyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, w, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 ywzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, w, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 ywzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, w, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 ywzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, w, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 ywzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, w, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 ywwx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, w, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 ywwy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, w, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 ywwz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, w, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 ywww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(y, w, w, w);
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
         public uint4 zxxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, x, x, w);
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
         public uint4 zxyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, x, y, w);
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
         public uint4 zxzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, x, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zxwx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, x, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zxwy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, x, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zxwz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, x, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zxww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, x, w, w);
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
         public uint4 zyxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, y, x, w);
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
         public uint4 zyyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, y, y, w);
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
         public uint4 zyzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, y, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zywx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, y, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zywy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, y, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zywz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, y, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zyww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, y, w, w);
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
         public uint4 zzxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, z, x, w);
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
         public uint4 zzyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, z, y, w);
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
         public uint4 zzzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, z, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zzwx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, z, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zzwy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, z, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zzwz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, z, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zzww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, z, w, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zwxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, w, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zwxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, w, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zwxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, w, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zwxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, w, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zwyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, w, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zwyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, w, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zwyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, w, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zwyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, w, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zwzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, w, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zwzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, w, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zwzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, w, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zwzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, w, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zwwx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, w, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zwwy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, w, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zwwz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, w, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zwww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(z, w, w, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wxxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, x, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wxxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, x, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wxxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, x, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wxxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, x, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wxyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, x, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wxyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, x, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wxyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, x, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wxyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, x, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wxzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, x, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wxzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, x, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wxzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, x, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wxzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, x, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wxwx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, x, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wxwy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, x, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wxwz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, x, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wxww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, x, w, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wyxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, y, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wyxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, y, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wyxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, y, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wyxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, y, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wyyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, y, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wyyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, y, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wyyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, y, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wyyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, y, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wyzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, y, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wyzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, y, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wyzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, y, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wyzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, y, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wywx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, y, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wywy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, y, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wywz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, y, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wyww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, y, w, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wzxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, z, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wzxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, z, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wzxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, z, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wzxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, z, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wzyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, z, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wzyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, z, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wzyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, z, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wzyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, z, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wzzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, z, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wzzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, z, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wzzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, z, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wzzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, z, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wzwx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, z, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wzwy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, z, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wzwz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, z, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wzww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, z, w, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wwxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, w, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wwxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, w, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wwxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, w, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wwxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, w, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wwyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, w, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wwyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, w, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wwyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, w, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wwyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, w, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wwzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, w, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wwzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, w, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wwzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, w, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wwzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, w, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wwwx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, w, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wwwy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, w, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wwwz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, w, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wwww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new uint4(w, w, w, w);
         }
        #endregion


        #region Object
        public override bool Equals(object o) => o is uint4 target && Equals(target); 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => math.hash(this);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => $"uint4({x}, {y}, {z}, {w})";
        #endregion

        #region IEquatable/IFormattable
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(uint4 a) => x == a.x && y == a.y && z == a.z && w == a.w; 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"uint4({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)}, {w.ToString(format, formatProvider)})";
        }
        #endregion

        #region Enumerator
        VectorEnumerator<uint, uint4> IEnumerableVector<uint, uint4>.GetEnumerator() => new VectorEnumerator<uint, uint4>(this);
        IEnumerator<uint> IEnumerable<uint>.GetEnumerator() => new VectorEnumerator<uint, uint4>(this);
        IEnumerator IEnumerable.GetEnumerator() => new VectorEnumerator<uint, uint4>(this);
        public Enumerator GetEnumerator() => new Enumerator(this);
        public unsafe ref struct Enumerator
        {
            private readonly uint* _pointer;
            private sbyte _index;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Enumerator(in uint4 value)
            {
                fixed (uint4* array = &value)
                {
                    _pointer = (uint*)array;
                    _index = -1;
                }
            }
            public uint Current => _pointer[_index];
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public void Dispose() { }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool MoveNext() => ++_index < LENGTH;
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
            public uint w;
            public DebuggerProxy(uint4 v)
            {
                x = v.x;
                y = v.y;
                z = v.z;
                w = v.w;
            }
        }
        #endregion
    }
}
