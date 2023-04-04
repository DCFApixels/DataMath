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
    [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 24)]
    public partial struct double3 : 
        IEquatable<double3>, 
        IFormattable, 
        IVector3<double>, 
        IColor,
        IEnumerableVector<double, double3>
    {
        #region Consts
        public const int LENGTH = 3;

        ///<summary>(0, 0, 0)</summary>
        public static readonly double3 zero = new double3(0d, 0d, 0d);
        ///<summary>(1, 1, 1)</summary>
        public static readonly double3 one = new double3(1d, 1d, 1d);

        ///<summary>(-1, 0, 0)</summary>
        public static readonly double3 left = new double3(-1d, 0d, 0d);
        ///<summary>(1, 0, 0)</summary>
        public static readonly double3 right = new double3(1d, 0d, 0d);
        ///<summary>(0, -1, 0)</summary>
        public static readonly double3 down = new double3(0d, -1d, 0d);
        ///<summary>(0, 1, 0)</summary>
        public static readonly double3 up = new double3(0d, 1d, 0d);
        ///<summary>(0, 0, -1)</summary>
        public static readonly double3 back = new double3(0d, 0d, -1d);
        ///<summary>(0, 0, 1)</summary>
        public static readonly double3 forward = new double3(0d, 0d, 1d);
        #endregion

        public double x;
        public double y;
        public double z;

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
            get => 0f;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {}
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
                fixed (double3* array = &this) { return ref ((double*)array)[index]; }
            }
        }
        #endregion

        #region Constructors
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(float x, float y, float z)
        {
            this.x = (double)x; this.y = (double)y; this.z = (double)z;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(float v)
        {
            x = (double)v; y = (double)v; z = (double)v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(float3 v)
        {
            x = (double)v.x; y = (double)v.y; z = (double)v.z;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(double x, double y, double z)
        {
            this.x = x; this.y = y; this.z = z;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(double v)
        {
            x = v; y = v; z = v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(double3 v)
        {
            x = v.x; y = v.y; z = v.z;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(int x, int y, int z)
        {
            this.x = (double)x; this.y = (double)y; this.z = (double)z;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(int v)
        {
            x = (double)v; y = (double)v; z = (double)v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(int3 v)
        {
            x = (double)v.x; y = (double)v.y; z = (double)v.z;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(uint x, uint y, uint z)
        {
            this.x = (double)x; this.y = (double)y; this.z = (double)z;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(uint v)
        {
            x = (double)v; y = (double)v; z = (double)v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double3(uint3 v)
        {
            x = (double)v.x; y = (double)v.y; z = (double)v.z;
        }

        #endregion

        #region Arithmetic operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator *(double3 a, double3 b) => new double3(a.x * b.x, a.y * b.y, a.z * b.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator *(double3 a, double b) => new double3(a.x * b, a.y * b, a.z * b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator *(double a, double3 b) => new double3(a * b.x, a * b.y, a * b.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator +(double3 a, double3 b) => new double3(a.x + b.x, a.y + b.y, a.z + b.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator +(double3 a, double b) => new double3(a.x + b, a.y + b, a.z + b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator +(double a, double3 b) => new double3(a + b.x, a + b.y, a + b.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator -(double3 a, double3 b) => new double3(a.x - b.x, a.y - b.y, a.z - b.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator -(double3 a, double b) => new double3(a.x - b, a.y - b, a.z - b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator -(double a, double3 b) => new double3(a - b.x, a - b.y, a - b.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator /(double3 a, double3 b) => new double3(a.x / b.x, a.y / b.y, a.z / b.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator /(double3 a, double b) => new double3(a.x / b, a.y / b, a.z / b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator /(double a, double3 b) => new double3(a / b.x, a / b.y, a / b.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator %(double3 a, double3 b) => new double3(a.x % b.x, a.y % b.y, a.z % b.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator %(double3 a, double b) => new double3(a.x % b, a.y % b, a.z % b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator %(double a, double3 b) => new double3(a % b.x, a % b.y, a % b.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator ++(double3 a) => new double3(++a.x, ++a.y, ++a.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator --(double3 a) => new double3(--a.x, --a.y, --a.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator -(double3 a) => new double3(-a.x, -a.y, -a.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static double3 operator +(double3 a) => new double3(+a.x, +a.y, +a.z);
        #endregion

        #region Boolean operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(double3 a, double3 b) => a.x == b.x && a.y == b.y && a.z == b.z;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(double3 a, double b) => a.x == b && a.y == b && a.z == b;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(double a, double3 b) => a == b.x && a == b.y && a == b.z;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(double3 a, double3 b) => a.x != b.x || a.y != b.y || a.z != b.z;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(double3 a, double b) => a.x != b || a.y != b || a.z != b;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(double a, double3 b) => a != b.x || a != b.y || a != b.z;
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
         public double2 x_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double2(x, 0d);
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
         public double2 y_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double2(y, 0d);
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
         public double2 z_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double2(z, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double2 _x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double2(0d, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double2 _y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double2(0d, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double2 _z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double2(0d, z);
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
         public double3 xx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(x, x, 0d);
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
         public double3 xy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(x, y, 0d);
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
         public double3 xz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(x, z, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 x_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(x, 0d, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 x_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(x, 0d, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 x_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(x, 0d, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 x__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(x, 0d, 0d);
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
         public double3 yx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(y, x, 0d);
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
         public double3 yy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(y, y, 0d);
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
         public double3 yz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(y, z, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 y_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(y, 0d, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 y_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(y, 0d, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 y_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(y, 0d, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 y__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(y, 0d, 0d);
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
         public double3 zx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(z, x, 0d);
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
         public double3 zy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(z, y, 0d);
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
         public double3 zz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(z, z, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 z_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(z, 0d, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 z_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(z, 0d, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 z_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(z, 0d, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 z__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(z, 0d, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 _xx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(0d, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 _xy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(0d, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 _xz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(0d, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 _x_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(0d, x, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 _yx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(0d, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 _yy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(0d, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 _yz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(0d, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 _y_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(0d, y, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 _zx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(0d, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 _zy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(0d, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 _zz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(0d, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 _z_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(0d, z, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 __x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(0d, 0d, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 __y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(0d, 0d, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double3 __z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double3(0d, 0d, z);
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
         public double4 xxx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, x, x, 0d);
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
         public double4 xxy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, x, y, 0d);
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
         public double4 xxz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, x, z, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xx_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, x, 0d, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xx_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, x, 0d, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xx_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, x, 0d, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xx__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, x, 0d, 0d);
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
         public double4 xyx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, y, x, 0d);
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
         public double4 xyy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, y, y, 0d);
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
         public double4 xyz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, y, z, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xy_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, y, 0d, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xy_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, y, 0d, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xy_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, y, 0d, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xy__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, y, 0d, 0d);
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
         public double4 xzx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, z, x, 0d);
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
         public double4 xzy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, z, y, 0d);
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
         public double4 xzz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, z, z, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xz_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, z, 0d, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xz_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, z, 0d, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xz_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, z, 0d, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 xz__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, z, 0d, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 x_xx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, 0d, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 x_xy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, 0d, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 x_xz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, 0d, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 x_x_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, 0d, x, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 x_yx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, 0d, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 x_yy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, 0d, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 x_yz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, 0d, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 x_y_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, 0d, y, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 x_zx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, 0d, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 x_zy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, 0d, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 x_zz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, 0d, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 x_z_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, 0d, z, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 x__x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, 0d, 0d, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 x__y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, 0d, 0d, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 x__z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, 0d, 0d, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 x___
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(x, 0d, 0d, 0d);
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
         public double4 yxx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, x, x, 0d);
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
         public double4 yxy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, x, y, 0d);
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
         public double4 yxz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, x, z, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yx_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, x, 0d, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yx_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, x, 0d, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yx_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, x, 0d, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yx__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, x, 0d, 0d);
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
         public double4 yyx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, y, x, 0d);
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
         public double4 yyy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, y, y, 0d);
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
         public double4 yyz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, y, z, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yy_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, y, 0d, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yy_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, y, 0d, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yy_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, y, 0d, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yy__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, y, 0d, 0d);
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
         public double4 yzx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, z, x, 0d);
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
         public double4 yzy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, z, y, 0d);
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
         public double4 yzz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, z, z, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yz_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, z, 0d, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yz_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, z, 0d, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yz_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, z, 0d, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 yz__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, z, 0d, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 y_xx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, 0d, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 y_xy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, 0d, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 y_xz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, 0d, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 y_x_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, 0d, x, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 y_yx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, 0d, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 y_yy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, 0d, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 y_yz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, 0d, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 y_y_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, 0d, y, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 y_zx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, 0d, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 y_zy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, 0d, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 y_zz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, 0d, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 y_z_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, 0d, z, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 y__x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, 0d, 0d, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 y__y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, 0d, 0d, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 y__z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, 0d, 0d, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 y___
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(y, 0d, 0d, 0d);
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
         public double4 zxx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, x, x, 0d);
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
         public double4 zxy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, x, y, 0d);
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
         public double4 zxz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, x, z, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zx_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, x, 0d, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zx_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, x, 0d, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zx_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, x, 0d, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zx__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, x, 0d, 0d);
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
         public double4 zyx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, y, x, 0d);
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
         public double4 zyy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, y, y, 0d);
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
         public double4 zyz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, y, z, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zy_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, y, 0d, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zy_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, y, 0d, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zy_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, y, 0d, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zy__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, y, 0d, 0d);
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
         public double4 zzx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, z, x, 0d);
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
         public double4 zzy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, z, y, 0d);
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
         public double4 zzz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, z, z, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zz_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, z, 0d, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zz_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, z, 0d, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zz_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, z, 0d, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 zz__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, z, 0d, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 z_xx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, 0d, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 z_xy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, 0d, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 z_xz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, 0d, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 z_x_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, 0d, x, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 z_yx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, 0d, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 z_yy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, 0d, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 z_yz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, 0d, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 z_y_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, 0d, y, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 z_zx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, 0d, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 z_zy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, 0d, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 z_zz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, 0d, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 z_z_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, 0d, z, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 z__x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, 0d, 0d, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 z__y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, 0d, 0d, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 z__z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, 0d, 0d, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 z___
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(z, 0d, 0d, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _xxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, x, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _xxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, x, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _xxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, x, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _xx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, x, x, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _xyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, x, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _xyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, x, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _xyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, x, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _xy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, x, y, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _xzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, x, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _xzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, x, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _xzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, x, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _xz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, x, z, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _x_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, x, 0d, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _x_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, x, 0d, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _x_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, x, 0d, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _x__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, x, 0d, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _yxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, y, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _yxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, y, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _yxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, y, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _yx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, y, x, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _yyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, y, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _yyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, y, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _yyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, y, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _yy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, y, y, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _yzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, y, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _yzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, y, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _yzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, y, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _yz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, y, z, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _y_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, y, 0d, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _y_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, y, 0d, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _y_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, y, 0d, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _y__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, y, 0d, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _zxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, z, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _zxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, z, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _zxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, z, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _zx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, z, x, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _zyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, z, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _zyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, z, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _zyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, z, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _zy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, z, y, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _zzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, z, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _zzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, z, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _zzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, z, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _zz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, z, z, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _z_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, z, 0d, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _z_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, z, 0d, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _z_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, z, 0d, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 _z__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, z, 0d, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 __xx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, 0d, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 __xy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, 0d, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 __xz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, 0d, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 __x_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, 0d, x, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 __yx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, 0d, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 __yy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, 0d, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 __yz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, 0d, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 __y_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, 0d, y, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 __zx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, 0d, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 __zy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, 0d, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 __zz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, 0d, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 __z_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, 0d, z, 0d);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 ___x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, 0d, 0d, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 ___y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, 0d, 0d, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public double4 ___z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new double4(0d, 0d, 0d, z);
         }
        #endregion


        #region Object
        public override bool Equals(object o) => o is double3 target && Equals(target); 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => math.hash(this);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => $"double3({x}, {y}, {z})";
        #endregion

        #region IEquatable/IFormattable
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(double3 a) => x == a.x && y == a.y && z == a.z; 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"double3({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)})";
        }
        #endregion

        #region Enumerator
        VectorEnumerator<double, double3> IEnumerableVector<double, double3>.GetEnumerator() => new VectorEnumerator<double, double3>(this);
        IEnumerator<double> IEnumerable<double>.GetEnumerator() => new VectorEnumerator<double, double3>(this);
        IEnumerator IEnumerable.GetEnumerator() => new VectorEnumerator<double, double3>(this);
        public Enumerator GetEnumerator() => new Enumerator(this);
        public unsafe ref struct Enumerator
        {
            private readonly double* _pointer;
            private sbyte _index;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Enumerator(in double3 value)
            {
                fixed (double3* array = &value)
                {
                    _pointer = (double*)array;
                    _index = -1;
                }
            }
            public double Current => _pointer[_index];
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
            public double x;
            public double y;
            public double z;
            public DebuggerProxy(double3 v)
            {
                x = v.x;
                y = v.y;
                z = v.z;
            }
        }
        #endregion
    }
}
