using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace DCFApixels.DataMath
{
    [DebuggerTypeProxy(typeof(DebuggerProxy))]
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 32)]
    public partial struct double4 : 
        IEquatable<double4>, 
        IFormattable, 
        IVector4<double>, 
        IColor
    {
        #region Consts
        public const int LENGTH = 4;

        ///<summary>(0, 0, 0, 0)</summary>
        public static readonly double4 zero = new double4(0d, 0d, 0d, 0d);
        ///<summary>(1, 1, 1, 1)</summary>
        public static readonly double4 one = new double4(1d, 1d, 1d, 1d);

        ///<summary>(-1, 0, 0, 0)</summary>
        public static readonly double4 left = new double4(-1d, 0d, 0d, 0d);
        ///<summary>(1, 0, 0, 0)</summary>
        public static readonly double4 right = new double4(1d, 0d, 0d, 0d);
        ///<summary>(0, -1, 0, 0)</summary>
        public static readonly double4 down = new double4(0d, -1d, 0d, 0d);
        ///<summary>(0, 1, 0, 0)</summary>
        public static readonly double4 up = new double4(0d, 1d, 0d, 0d);
        ///<summary>(0, 0, -1, 0)</summary>
        public static readonly double4 back = new double4(0d, 0d, -1d, 0d);
        ///<summary>(0, 0, 1, 0)</summary>
        public static readonly double4 forward = new double4(0d, 0d, 1d, 0d);
        ///<summary>(0, 0, 0, -1)</summary>
        public static readonly double4 before = new double4(0d, 0d, 0d, -1d);
        ///<summary>(0, 0, 0, 1)</summary>
        public static readonly double4 after = new double4(0d, 0d, 0d, 1d);
        #endregion

        public double x;
        public double y;
        public double z;
        public double w;

        #region IColor
        public float r 
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => (float)x;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => x = (double)value;
        }
        public float g 
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => (float)y;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => y = (double)value;
        }
        public float b 
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => (float)z;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => z = (double)value;
        }
        public float a 
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => (float)w;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => w = (double)value;
        }
        #endregion

        #region IVectorN
        [EditorBrowsable(EditorBrowsableState.Never)]
        double IVector1<double>.x 
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => x; 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => x = value; 
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        double IVector2<double>.y 
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => y; 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => y = value; 
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        double IVector3<double>.z 
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => z;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => z = value;
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        double IVector4<double>.w 
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

        public unsafe ref double this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > LENGTH) throw new IndexOutOfRangeException($"index must be between[0...{(LENGTH - 1)}]");
#endif
                fixed (double4* array = &this) { return ref ((double*)array)[index]; }
            }
        }
        #endregion

        #region Constructors
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4(float x, float y, float z, float w)
        {
            this.x = (double)x; this.y = (double)y;
            this.z = (double)z; this.w = (double)w;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4(float v)
        {
            x = (double)v; y = (double)v;
            z = (double)v; w = (double)v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4(float4 v)
        {
            x = (double)v.x; y = (double)v.y;
            z = (double)v.z; w = (double)v.w;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4(double x, double y, double z, double w)
        {
            this.x = x; this.y = y;
            this.z = z; this.w = w;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4(double v)
        {
            x = v; y = v;
            z = v; w = v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4(double4 v)
        {
            x = v.x; y = v.y;
            z = v.z; w = v.w;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4(int x, int y, int z, int w)
        {
            this.x = (double)x; this.y = (double)y;
            this.z = (double)z; this.w = (double)w;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4(int v)
        {
            x = (double)v; y = (double)v;
            z = (double)v; w = (double)v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4(int4 v)
        {
            x = (double)v.x; y = (double)v.y;
            z = (double)v.z; w = (double)v.w;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4(uint x, uint y, uint z, uint w)
        {
            this.x = (double)x; this.y = (double)y;
            this.z = (double)z; this.w = (double)w;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4(uint v)
        {
            x = (double)v; y = (double)v;
            z = (double)v; w = (double)v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double4(uint4 v)
        {
            x = (double)v.x; y = (double)v.y;
            z = (double)v.z; w = (double)v.w;
        }

        #endregion

        #region Arithmetic operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator *(double4 a, double4 b) => new double4(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator *(double4 a, double b) => new double4(a.x * b, a.y * b, a.z * b, a.w * b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator *(double a, double4 b) => new double4(a * b.x, a * b.y, a * b.z, a * b.w);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator +(double4 a, double4 b) => new double4(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator +(double4 a, double b) => new double4(a.x + b, a.y + b, a.z + b, a.w + b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator +(double a, double4 b) => new double4(a + b.x, a + b.y, a + b.z, a + b.w);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator -(double4 a, double4 b) => new double4(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator -(double4 a, double b) => new double4(a.x - b, a.y - b, a.z - b, a.w - b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator -(double a, double4 b) => new double4(a - b.x, a - b.y, a - b.z, a - b.w);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator /(double4 a, double4 b) => new double4(a.x / b.x, a.y / b.y, a.z / b.z, a.w / b.w);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator /(double4 a, double b) => new double4(a.x / b, a.y / b, a.z / b, a.w / b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator /(double a, double4 b) => new double4(a / b.x, a / b.y, a / b.z, a / b.w);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator %(double4 a, double4 b) => new double4(a.x % b.x, a.y % b.y, a.z % b.z, a.w % b.w);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator %(double4 a, double b) => new double4(a.x % b, a.y % b, a.z % b, a.w % b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator %(double a, double4 b) => new double4(a % b.x, a % b.y, a % b.z, a % b.w);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator ++(double4 a) => new double4(++a.x, ++a.y, ++a.z, ++a.w);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator --(double4 a) => new double4(--a.x, --a.y, --a.z, --a.w);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator -(double4 a) => new double4(-a.x, -a.y, -a.z, -a.w);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double4 operator +(double4 a) => new double4(+a.x, +a.y, +a.z, +a.w);
        #endregion

        #region Boolean operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(double4 a, double4 b) => a.x == b.x && a.y == b.y && a.z == b.z && a.w == b.w;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(double4 a, double b) => a.x == b && a.y == b && a.z == b && a.w == b;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(double a, double4 b) => a == b.x && a == b.y && a == b.z && a == b.w;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(double4 a, double4 b) => a.x != b.x || a.y != b.y || a.z != b.z || a.w != b.w;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(double4 a, double b) => a.x != b || a.y != b || a.z != b || a.w != b;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(double a, double4 b) => a != b.x || a != b.y || a != b.z || a != b.w;
        #endregion

        #region Swap2
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double2 xx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double2(x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double2 xy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double2(x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double2 xz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double2(x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double2 xw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double2(x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double2 yx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double2(y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double2 yy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double2(y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double2 yz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double2(y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double2 yw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double2(y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double2 zx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double2(z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double2 zy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double2(z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double2 zz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double2(z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double2 zw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double2(z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double2 wx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double2(w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double2 wy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double2(w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double2 wz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double2(w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double2 ww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double2(w, w);
         }
        #endregion

        #region Swap3
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 xxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(x, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 xxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(x, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 xxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(x, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 xxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(x, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 xyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(x, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 xyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(x, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 xyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(x, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 xyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(x, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 xzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(x, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 xzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(x, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 xzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(x, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 xzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(x, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 xwx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(x, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 xwy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(x, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 xwz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(x, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 xww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(x, w, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 yxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(y, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 yxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(y, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 yxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(y, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 yxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(y, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 yyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(y, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 yyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(y, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 yyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(y, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 yyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(y, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 yzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(y, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 yzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(y, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 yzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(y, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 yzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(y, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 ywx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(y, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 ywy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(y, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 ywz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(y, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 yww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(y, w, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 zxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(z, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 zxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(z, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 zxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(z, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 zxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(z, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 zyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(z, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 zyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(z, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 zyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(z, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 zyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(z, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 zzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(z, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 zzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(z, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 zzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(z, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 zzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(z, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 zwx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(z, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 zwy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(z, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 zwz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(z, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 zww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(z, w, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 wxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(w, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 wxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(w, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 wxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(w, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 wxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(w, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 wyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(w, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 wyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(w, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 wyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(w, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 wyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(w, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 wzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(w, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 wzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(w, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 wzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(w, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 wzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(w, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 wwx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(w, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 wwy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(w, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 wwz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(w, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 www
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(w, w, w);
         }
        #endregion

        #region Swap4
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xxxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, x, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xxxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, x, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xxxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, x, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xxxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, x, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xxyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, x, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xxyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, x, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xxyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, x, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xxyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, x, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xxzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, x, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xxzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, x, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xxzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, x, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xxzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, x, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xxwx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, x, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xxwy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, x, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xxwz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, x, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xxww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, x, w, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xyxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, y, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xyxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, y, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xyxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, y, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xyxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, y, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xyyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, y, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xyyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, y, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xyyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, y, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xyyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, y, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xyzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, y, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xyzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, y, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xyzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, y, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xyzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, y, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xywx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, y, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xywy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, y, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xywz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, y, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xyww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, y, w, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xzxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, z, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xzxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, z, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xzxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, z, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xzxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, z, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xzyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, z, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xzyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, z, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xzyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, z, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xzyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, z, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xzzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, z, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xzzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, z, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xzzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, z, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xzzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, z, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xzwx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, z, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xzwy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, z, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xzwz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, z, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xzww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, z, w, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xwxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, w, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xwxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, w, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xwxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, w, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xwxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, w, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xwyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, w, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xwyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, w, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xwyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, w, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xwyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, w, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xwzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, w, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xwzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, w, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xwzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, w, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xwzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, w, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xwwx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, w, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xwwy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, w, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xwwz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, w, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xwww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, w, w, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yxxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, x, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yxxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, x, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yxxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, x, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yxxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, x, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yxyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, x, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yxyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, x, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yxyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, x, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yxyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, x, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yxzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, x, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yxzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, x, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yxzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, x, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yxzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, x, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yxwx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, x, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yxwy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, x, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yxwz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, x, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yxww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, x, w, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yyxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, y, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yyxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, y, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yyxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, y, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yyxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, y, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yyyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, y, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yyyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, y, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yyyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, y, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yyyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, y, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yyzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, y, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yyzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, y, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yyzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, y, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yyzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, y, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yywx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, y, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yywy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, y, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yywz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, y, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yyww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, y, w, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yzxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, z, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yzxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, z, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yzxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, z, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yzxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, z, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yzyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, z, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yzyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, z, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yzyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, z, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yzyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, z, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yzzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, z, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yzzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, z, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yzzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, z, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yzzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, z, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yzwx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, z, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yzwy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, z, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yzwz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, z, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yzww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, z, w, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 ywxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, w, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 ywxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, w, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 ywxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, w, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 ywxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, w, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 ywyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, w, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 ywyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, w, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 ywyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, w, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 ywyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, w, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 ywzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, w, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 ywzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, w, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 ywzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, w, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 ywzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, w, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 ywwx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, w, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 ywwy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, w, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 ywwz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, w, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 ywww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, w, w, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zxxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, x, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zxxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, x, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zxxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, x, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zxxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, x, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zxyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, x, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zxyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, x, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zxyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, x, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zxyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, x, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zxzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, x, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zxzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, x, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zxzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, x, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zxzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, x, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zxwx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, x, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zxwy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, x, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zxwz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, x, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zxww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, x, w, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zyxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, y, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zyxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, y, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zyxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, y, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zyxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, y, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zyyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, y, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zyyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, y, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zyyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, y, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zyyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, y, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zyzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, y, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zyzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, y, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zyzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, y, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zyzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, y, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zywx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, y, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zywy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, y, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zywz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, y, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zyww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, y, w, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zzxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, z, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zzxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, z, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zzxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, z, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zzxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, z, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zzyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, z, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zzyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, z, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zzyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, z, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zzyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, z, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zzzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, z, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zzzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, z, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zzzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, z, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zzzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, z, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zzwx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, z, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zzwy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, z, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zzwz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, z, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zzww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, z, w, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zwxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, w, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zwxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, w, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zwxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, w, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zwxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, w, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zwyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, w, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zwyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, w, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zwyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, w, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zwyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, w, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zwzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, w, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zwzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, w, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zwzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, w, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zwzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, w, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zwwx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, w, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zwwy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, w, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zwwz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, w, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zwww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, w, w, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wxxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, x, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wxxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, x, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wxxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, x, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wxxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, x, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wxyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, x, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wxyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, x, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wxyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, x, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wxyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, x, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wxzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, x, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wxzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, x, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wxzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, x, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wxzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, x, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wxwx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, x, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wxwy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, x, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wxwz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, x, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wxww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, x, w, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wyxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, y, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wyxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, y, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wyxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, y, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wyxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, y, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wyyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, y, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wyyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, y, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wyyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, y, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wyyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, y, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wyzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, y, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wyzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, y, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wyzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, y, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wyzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, y, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wywx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, y, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wywy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, y, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wywz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, y, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wyww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, y, w, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wzxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, z, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wzxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, z, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wzxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, z, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wzxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, z, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wzyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, z, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wzyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, z, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wzyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, z, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wzyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, z, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wzzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, z, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wzzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, z, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wzzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, z, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wzzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, z, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wzwx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, z, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wzwy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, z, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wzwz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, z, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wzww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, z, w, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wwxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, w, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wwxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, w, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wwxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, w, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wwxw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, w, x, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wwyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, w, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wwyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, w, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wwyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, w, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wwyw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, w, y, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wwzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, w, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wwzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, w, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wwzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, w, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wwzw
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, w, z, w);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wwwx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, w, w, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wwwy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, w, w, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wwwz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, w, w, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 wwww
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(w, w, w, w);
         }
        #endregion


        #region Object
        public override bool Equals(object o) => o is double4 target && Equals(target); 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => math.hash(this);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => $"double4({x}, {y}, {z}, {w})";
        #endregion

        #region IEquatable/IFormattable
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(double4 a) => x == a.x && y == a.y && z == a.z && w == a.w; 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"double4({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)}, {w.ToString(format, formatProvider)})";
        }
        #endregion

        #region Enumerator
        public Enumerator GetEnumerator() => new Enumerator(this);
        public ref struct Enumerator
        {
            private readonly double4 _value;
            private sbyte _pointer;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Enumerator(double4 value) { _value = value; _pointer = -1; }
            public double Current => _value[_pointer];

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
            public double x;
            public double y;
            public double z;
            public double w;
            public DebuggerProxy(double4 v)
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
