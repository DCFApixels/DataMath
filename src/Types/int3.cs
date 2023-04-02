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
    public partial struct int3 : IEquatable<int3>, IFormattable, IValue3<int>
    {
        #region Consts
        public const int length = 3;

        ///<summary>(0, 0, 0)</summary>
        public static readonly int3 zero = new int3(0, 0, 0);
        ///<summary>(1, 1, 1)</summary>
        public static readonly int3 one = new int3(1, 1, 1);

        ///<summary>(-1, 0, 0)</summary>
        public static readonly int3 left = new int3(-1, 0, 0);
        ///<summary>(1, 0, 0)</summary>
        public static readonly int3 right = new int3(1, 0, 0);
        ///<summary>(0, -1, 0)</summary>
        public static readonly int3 down = new int3(0, -1, 0);
        ///<summary>(0, 1, 0)</summary>
        public static readonly int3 up = new int3(0, 1, 0);
        ///<summary>(0, 0, -1)</summary>
        public static readonly int3 back = new int3(0, 0, -1);
        ///<summary>(0, 0, 1)</summary>
        public static readonly int3 forward = new int3(0, 0, 1);
        #endregion

        public int x;
        public int y;
        public int z;

        #region IValueN
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int X 
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => x; 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => x = value; 
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Y 
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => y; 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => y = value; 
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Z 
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

        public unsafe ref int this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > length) throw new IndexOutOfRangeException($"index must be between[0...{(length - 1)}]");
#endif
                fixed (int3* array = &this) { return ref ((int*)array)[index]; }
            }
        }
        #endregion

        #region Constructors
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(float x, float y, float z)
        {
            this.x = (int)x; this.y = (int)y; this.z = (int)z;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(float v)
        {
            x = (int)v; y = (int)v; z = (int)v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(float3 v)
        {
            x = (int)v.x; y = (int)v.y; z = (int)v.z;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(double x, double y, double z)
        {
            this.x = (int)x; this.y = (int)y; this.z = (int)z;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(double v)
        {
            x = (int)v; y = (int)v; z = (int)v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(double3 v)
        {
            x = (int)v.x; y = (int)v.y; z = (int)v.z;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(int x, int y, int z)
        {
            this.x = x; this.y = y; this.z = z;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(int v)
        {
            x = v; y = v; z = v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(int3 v)
        {
            x = v.x; y = v.y; z = v.z;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(uint x, uint y, uint z)
        {
            this.x = (int)x; this.y = (int)y; this.z = (int)z;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(uint v)
        {
            x = (int)v; y = (int)v; z = (int)v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int3(uint3 v)
        {
            x = (int)v.x; y = (int)v.y; z = (int)v.z;
        }

        #endregion

        #region Convert operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(float v) => new int3(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(float3 v) => new int3(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int3(int v) => new int3(v);
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static implicit operator int3(int3 v) => new int3(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(uint v) => new int3(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(uint3 v) => new int3(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(double v) => new int3(v);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int3(double3 v) => new int3(v);
        #endregion

        #region Arithmetic operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator *(int3 a, int3 b) => new int3(a.x * b.x, a.y * b.y, a.z * b.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator *(int3 a, int b) => new int3(a.x * b, a.y * b, a.z * b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator *(int a, int3 b) => new int3(a * b.x, a * b.y, a * b.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator +(int3 a, int3 b) => new int3(a.x + b.x, a.y + b.y, a.z + b.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator +(int3 a, int b) => new int3(a.x + b, a.y + b, a.z + b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator +(int a, int3 b) => new int3(a + b.x, a + b.y, a + b.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator -(int3 a, int3 b) => new int3(a.x - b.x, a.y - b.y, a.z - b.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator -(int3 a, int b) => new int3(a.x - b, a.y - b, a.z - b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator -(int a, int3 b) => new int3(a - b.x, a - b.y, a - b.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator /(int3 a, int3 b) => new int3(a.x / b.x, a.y / b.y, a.z / b.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator /(int3 a, int b) => new int3(a.x / b, a.y / b, a.z / b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator /(int a, int3 b) => new int3(a / b.x, a / b.y, a / b.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator %(int3 a, int3 b) => new int3(a.x % b.x, a.y % b.y, a.z % b.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator %(int3 a, int b) => new int3(a.x % b, a.y % b, a.z % b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator %(int a, int3 b) => new int3(a % b.x, a % b.y, a % b.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator ++(int3 a) => new int3(++a.x, ++a.y, ++a.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator --(int3 a) => new int3(--a.x, --a.y, --a.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator -(int3 a) => new int3(-a.x, -a.y, -a.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator +(int3 a) => new int3(+a.x, +a.y, +a.z);
        #endregion

        #region Bit operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator ~(int3 a) => new int3(~a.x, ~a.y, ~a.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator <<(int3 a, int n) => new int3(a.x << n, a.y << n, a.z << n);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator >>(int3 a, int n) => new int3(a.x >> n, a.y >> n, a.z >> n);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator |(int3 a, int3 b) => new int3(a.x | b.x, a.y | b.y, a.z | b.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator |(int3 a, int b) => new int3(a.x | b, a.y | b, a.z | b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator |(int a, int3 b) => new int3(a | b.x, a | b.y, a | b.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator &(int3 a, int3 b) => new int3(a.x & b.x, a.y & b.y, a.z & b.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator &(int3 a, int b) => new int3(a.x & b, a.y & b, a.z & b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator &(int a, int3 b) => new int3(a & b.x, a & b.y, a & b.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator ^(int3 a, int3 b) => new int3(a.x ^ b.x, a.y ^ b.y, a.z ^ b.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator ^(int3 a, int b) => new int3(a.x ^ b, a.y ^ b, a.z ^ b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 operator ^(int a, int3 b) => new int3(a ^ b.x, a ^ b.y, a ^ b.z);
        #endregion

        #region Boolean operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(int3 a, int3 b) => a.x == b.x && a.y == b.y && a.z == b.z;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(int3 a, int b) => a.x == b && a.y == b && a.z == b;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(int a, int3 b) => a == b.x && a == b.y && a == b.z;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(int3 a, int3 b) => a.x != b.x || a.y != b.y || a.z != b.z;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(int3 a, int b) => a.x != b || a.y != b || a.z != b;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(int a, int3 b) => a != b.x || a != b.y || a != b.z;
        #endregion

        #region Swap2
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int2 xx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int2(x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int2 xy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int2(x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int2 xz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int2(x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int2 yx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int2(y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int2 yy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int2(y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int2 yz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int2(y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int2 zx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int2(z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int2 zy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int2(z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int2 zz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int2(z, z);
         }
        #endregion

        #region Swap3
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 xxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(x, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 xxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(x, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 xxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(x, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 xyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(x, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 xyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(x, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 xyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(x, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 xzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(x, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 xzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(x, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 xzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(x, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 yxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(y, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 yxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(y, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 yxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(y, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 yyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(y, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 yyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(y, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 yyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(y, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 yzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(y, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 yzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(y, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 yzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(y, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 zxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(z, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 zxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(z, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 zxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(z, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 zyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(z, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 zyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(z, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 zyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(z, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 zzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(z, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 zzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(z, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 zzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(z, z, z);
         }
        #endregion

        #region Swap4
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xxxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, x, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xxxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, x, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xxxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, x, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xxyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, x, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xxyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, x, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xxyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, x, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xxzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, x, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xxzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, x, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xxzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, x, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xyxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, y, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xyxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, y, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xyxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, y, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xyyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, y, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xyyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, y, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xyyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, y, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xyzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, y, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xyzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, y, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xyzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, y, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xzxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, z, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xzxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, z, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xzxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, z, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xzyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, z, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xzyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, z, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xzyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, z, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xzzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, z, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xzzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, z, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xzzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, z, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yxxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, x, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yxxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, x, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yxxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, x, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yxyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, x, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yxyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, x, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yxyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, x, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yxzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, x, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yxzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, x, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yxzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, x, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yyxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, y, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yyxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, y, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yyxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, y, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yyyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, y, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yyyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, y, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yyyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, y, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yyzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, y, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yyzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, y, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yyzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, y, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yzxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, z, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yzxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, z, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yzxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, z, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yzyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, z, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yzyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, z, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yzyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, z, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yzzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, z, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yzzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, z, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yzzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, z, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 zxxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, x, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 zxxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, x, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 zxxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, x, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 zxyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, x, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 zxyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, x, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 zxyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, x, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 zxzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, x, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 zxzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, x, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 zxzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, x, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 zyxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, y, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 zyxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, y, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 zyxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, y, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 zyyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, y, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 zyyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, y, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 zyyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, y, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 zyzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, y, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 zyzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, y, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 zyzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, y, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 zzxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, z, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 zzxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, z, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 zzxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, z, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 zzyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, z, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 zzyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, z, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 zzyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, z, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 zzzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, z, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 zzzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, z, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 zzzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, z, z, z);
         }
        #endregion


        #region Object
        public override bool Equals(object o) => o is int3 target && Equals(target); 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => math.hash(this);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => $"int3({x}, {y}, {z})";
        #endregion

        #region IEquatable/IFormattable
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(int3 a) => x == a.x && y == a.y && z == a.z; 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"int3({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)})";
        }
        #endregion

        #region Enumerator
        public Enumerator GetEnumerator() => new Enumerator(this);
        public ref struct Enumerator
        {
            private readonly int3 _value;
            private byte _pointer;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Enumerator(int3 value) { _value = value; _pointer = 0; }
            public int Current => _value[_pointer];

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
            public int x;
            public int y;
            public int z;
            public DebuggerProxy(int3 v)
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
        public static int3 one_minus(int3 v) => 1 - v;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 abs(int3 v)
        {
            return new int3(SMathF.Abs(v.x), SMathF.Abs(v.y), SMathF.Abs(v.z));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int3 sign(int3 v)
        {
            return new int3(SMath.Sign(v.x), SMath.Sign(v.y), SMath.Sign(v.z));
        }
        
    }
}
