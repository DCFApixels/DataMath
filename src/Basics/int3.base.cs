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
    [StructLayout(LayoutKind.Sequential, Pack = 4, Size = 12)]
    public partial struct int3 : 
        IEquatable<int3>, 
        IFormattable, 
        IVector3<int>, 
        IColor,
        IEnumerableVector<int, int3>
    {
        #region Consts
        public const int LENGTH = 3;

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

        #region IColor
        public float r 
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => (float)x;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => x = (int)value;
        }
        public float g 
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => (float)y;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => y = (int)value;
        }
        public float b 
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => (float)z;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => z = (int)value;
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
        int IVector1<int>.x 
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => x; 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => x = value; 
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        int IVector2<int>.y
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => y; 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => y = value; 
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        int IVector3<int>.z 
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

        public unsafe ref int this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > LENGTH) throw new IndexOutOfRangeException($"index must be between[0...{(LENGTH - 1)}]");
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
         public int2 x_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int2(x, 0);
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
         public int2 y_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int2(y, 0);
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
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int2 z_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int2(z, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int2 _x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int2(0, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int2 _y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int2(0, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int2 _z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int2(0, z);
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
         public int3 xx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(x, x, 0);
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
         public int3 xy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(x, y, 0);
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
         public int3 xz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(x, z, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 x_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(x, 0, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 x_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(x, 0, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 x_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(x, 0, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 x__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(x, 0, 0);
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
         public int3 yx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(y, x, 0);
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
         public int3 yy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(y, y, 0);
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
         public int3 yz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(y, z, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 y_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(y, 0, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 y_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(y, 0, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 y_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(y, 0, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 y__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(y, 0, 0);
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
         public int3 zx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(z, x, 0);
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
         public int3 zy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(z, y, 0);
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
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 zz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(z, z, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 z_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(z, 0, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 z_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(z, 0, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 z_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(z, 0, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 z__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(z, 0, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 _xx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(0, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 _xy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(0, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 _xz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(0, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 _x_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(0, x, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 _yx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(0, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 _yy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(0, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 _yz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(0, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 _y_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(0, y, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 _zx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(0, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 _zy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(0, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 _zz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(0, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 _z_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(0, z, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 __x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(0, 0, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 __y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(0, 0, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int3 __z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int3(0, 0, z);
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
         public int4 xxx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, x, x, 0);
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
         public int4 xxy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, x, y, 0);
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
         public int4 xxz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, x, z, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xx_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, x, 0, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xx_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, x, 0, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xx_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, x, 0, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xx__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, x, 0, 0);
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
         public int4 xyx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, y, x, 0);
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
         public int4 xyy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, y, y, 0);
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
         public int4 xyz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, y, z, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xy_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, y, 0, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xy_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, y, 0, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xy_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, y, 0, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xy__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, y, 0, 0);
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
         public int4 xzx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, z, x, 0);
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
         public int4 xzy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, z, y, 0);
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
         public int4 xzz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, z, z, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xz_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, z, 0, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xz_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, z, 0, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xz_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, z, 0, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 xz__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, z, 0, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 x_xx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, 0, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 x_xy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, 0, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 x_xz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, 0, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 x_x_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, 0, x, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 x_yx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, 0, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 x_yy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, 0, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 x_yz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, 0, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 x_y_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, 0, y, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 x_zx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, 0, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 x_zy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, 0, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 x_zz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, 0, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 x_z_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, 0, z, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 x__x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, 0, 0, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 x__y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, 0, 0, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 x__z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, 0, 0, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 x___
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(x, 0, 0, 0);
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
         public int4 yxx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, x, x, 0);
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
         public int4 yxy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, x, y, 0);
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
         public int4 yxz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, x, z, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yx_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, x, 0, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yx_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, x, 0, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yx_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, x, 0, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yx__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, x, 0, 0);
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
         public int4 yyx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, y, x, 0);
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
         public int4 yyy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, y, y, 0);
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
         public int4 yyz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, y, z, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yy_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, y, 0, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yy_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, y, 0, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yy_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, y, 0, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yy__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, y, 0, 0);
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
         public int4 yzx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, z, x, 0);
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
         public int4 yzy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, z, y, 0);
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
         public int4 yzz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, z, z, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yz_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, z, 0, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yz_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, z, 0, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yz_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, z, 0, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 yz__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, z, 0, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 y_xx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, 0, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 y_xy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, 0, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 y_xz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, 0, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 y_x_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, 0, x, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 y_yx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, 0, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 y_yy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, 0, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 y_yz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, 0, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 y_y_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, 0, y, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 y_zx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, 0, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 y_zy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, 0, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 y_zz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, 0, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 y_z_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, 0, z, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 y__x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, 0, 0, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 y__y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, 0, 0, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 y__z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, 0, 0, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 y___
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(y, 0, 0, 0);
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
         public int4 zxx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, x, x, 0);
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
         public int4 zxy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, x, y, 0);
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
         public int4 zxz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, x, z, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 zx_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, x, 0, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 zx_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, x, 0, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 zx_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, x, 0, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 zx__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, x, 0, 0);
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
         public int4 zyx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, y, x, 0);
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
         public int4 zyy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, y, y, 0);
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
         public int4 zyz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, y, z, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 zy_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, y, 0, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 zy_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, y, 0, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 zy_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, y, 0, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 zy__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, y, 0, 0);
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
         public int4 zzx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, z, x, 0);
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
         public int4 zzy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, z, y, 0);
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
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 zzz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, z, z, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 zz_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, z, 0, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 zz_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, z, 0, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 zz_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, z, 0, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 zz__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, z, 0, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 z_xx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, 0, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 z_xy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, 0, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 z_xz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, 0, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 z_x_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, 0, x, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 z_yx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, 0, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 z_yy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, 0, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 z_yz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, 0, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 z_y_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, 0, y, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 z_zx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, 0, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 z_zy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, 0, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 z_zz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, 0, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 z_z_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, 0, z, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 z__x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, 0, 0, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 z__y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, 0, 0, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 z__z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, 0, 0, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 z___
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(z, 0, 0, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _xxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, x, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _xxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, x, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _xxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, x, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _xx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, x, x, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _xyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, x, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _xyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, x, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _xyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, x, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _xy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, x, y, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _xzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, x, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _xzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, x, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _xzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, x, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _xz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, x, z, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _x_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, x, 0, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _x_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, x, 0, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _x_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, x, 0, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _x__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, x, 0, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _yxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, y, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _yxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, y, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _yxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, y, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _yx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, y, x, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _yyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, y, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _yyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, y, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _yyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, y, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _yy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, y, y, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _yzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, y, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _yzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, y, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _yzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, y, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _yz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, y, z, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _y_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, y, 0, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _y_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, y, 0, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _y_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, y, 0, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _y__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, y, 0, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _zxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, z, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _zxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, z, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _zxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, z, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _zx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, z, x, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _zyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, z, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _zyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, z, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _zyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, z, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _zy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, z, y, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _zzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, z, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _zzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, z, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _zzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, z, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _zz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, z, z, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _z_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, z, 0, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _z_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, z, 0, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _z_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, z, 0, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 _z__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, z, 0, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 __xx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, 0, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 __xy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, 0, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 __xz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, 0, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 __x_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, 0, x, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 __yx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, 0, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 __yy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, 0, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 __yz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, 0, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 __y_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, 0, y, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 __zx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, 0, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 __zy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, 0, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 __zz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, 0, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 __z_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, 0, z, 0);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 ___x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, 0, 0, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 ___y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, 0, 0, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public int4 ___z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new int4(0, 0, 0, z);
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
        VectorEnumerator<int, int3> IEnumerableVector<int, int3>.GetEnumerator() => new VectorEnumerator<int, int3>(this);
        IEnumerator<int> IEnumerable<int>.GetEnumerator() => new VectorEnumerator<int, int3>(this);
        IEnumerator IEnumerable.GetEnumerator() => new VectorEnumerator<int, int3>(this);
        public Enumerator GetEnumerator() => new Enumerator(this);
        public unsafe ref struct Enumerator
        {
            private readonly int* _pointer;
            private sbyte _index;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Enumerator(in int3 value)
            {
                fixed (int3* array = &value)
                {
                    _pointer = (int*)array;
                    _index = -1;
                }
            }
            public int Current => _pointer[_index];
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
}
