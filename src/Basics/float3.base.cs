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
    public partial struct float3 : 
        IEquatable<float3>, 
        IFormattable, 
        IVector3<float>, 
        IColor,
        IEnumerableVector<float, float3>
    {
        #region Consts
        public const int LENGTH = 3;

        ///<summary>(0, 0, 0)</summary>
        public static readonly float3 zero = new float3(0f, 0f, 0f);
        ///<summary>(1, 1, 1)</summary>
        public static readonly float3 one = new float3(1f, 1f, 1f);

        ///<summary>(-1, 0, 0)</summary>
        public static readonly float3 left = new float3(-1f, 0f, 0f);
        ///<summary>(1, 0, 0)</summary>
        public static readonly float3 right = new float3(1f, 0f, 0f);
        ///<summary>(0, -1, 0)</summary>
        public static readonly float3 down = new float3(0f, -1f, 0f);
        ///<summary>(0, 1, 0)</summary>
        public static readonly float3 up = new float3(0f, 1f, 0f);
        ///<summary>(0, 0, -1)</summary>
        public static readonly float3 back = new float3(0f, 0f, -1f);
        ///<summary>(0, 0, 1)</summary>
        public static readonly float3 forward = new float3(0f, 0f, 1f);
        #endregion

        public float x;
        public float y;
        public float z;

        #region IColor
        public float r 
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => (float)x;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => x = (float)value;
        }
        public float g 
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => (float)y;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => y = (float)value;
        }
        public float b 
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => (float)z;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => z = (float)value;
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
        float IVector1<float>.x 
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => x; 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => x = value; 
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        float IVector2<float>.y
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => y; 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => y = value; 
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        float IVector3<float>.z 
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

        public unsafe ref float this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > LENGTH) throw new IndexOutOfRangeException($"index must be between[0...{(LENGTH - 1)}]");
#endif
                fixed (float3* array = &this) { return ref ((float*)array)[index]; }
            }
        }
        #endregion

        #region Constructors
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(float x, float y, float z)
        {
            this.x = x; this.y = y; this.z = z;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(float v)
        {
            x = v; y = v; z = v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(float3 v)
        {
            x = v.x; y = v.y; z = v.z;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(double x, double y, double z)
        {
            this.x = (float)x; this.y = (float)y; this.z = (float)z;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(double v)
        {
            x = (float)v; y = (float)v; z = (float)v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(double3 v)
        {
            x = (float)v.x; y = (float)v.y; z = (float)v.z;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(int x, int y, int z)
        {
            this.x = (float)x; this.y = (float)y; this.z = (float)z;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(int v)
        {
            x = (float)v; y = (float)v; z = (float)v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(int3 v)
        {
            x = (float)v.x; y = (float)v.y; z = (float)v.z;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(uint x, uint y, uint z)
        {
            this.x = (float)x; this.y = (float)y; this.z = (float)z;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(uint v)
        {
            x = (float)v; y = (float)v; z = (float)v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float3(uint3 v)
        {
            x = (float)v.x; y = (float)v.y; z = (float)v.z;
        }

        #endregion

        #region Arithmetic operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator *(float3 a, float3 b) => new float3(a.x * b.x, a.y * b.y, a.z * b.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator *(float3 a, float b) => new float3(a.x * b, a.y * b, a.z * b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator *(float a, float3 b) => new float3(a * b.x, a * b.y, a * b.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator +(float3 a, float3 b) => new float3(a.x + b.x, a.y + b.y, a.z + b.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator +(float3 a, float b) => new float3(a.x + b, a.y + b, a.z + b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator +(float a, float3 b) => new float3(a + b.x, a + b.y, a + b.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator -(float3 a, float3 b) => new float3(a.x - b.x, a.y - b.y, a.z - b.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator -(float3 a, float b) => new float3(a.x - b, a.y - b, a.z - b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator -(float a, float3 b) => new float3(a - b.x, a - b.y, a - b.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator /(float3 a, float3 b) => new float3(a.x / b.x, a.y / b.y, a.z / b.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator /(float3 a, float b) => new float3(a.x / b, a.y / b, a.z / b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator /(float a, float3 b) => new float3(a / b.x, a / b.y, a / b.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator %(float3 a, float3 b) => new float3(a.x % b.x, a.y % b.y, a.z % b.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator %(float3 a, float b) => new float3(a.x % b, a.y % b, a.z % b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator %(float a, float3 b) => new float3(a % b.x, a % b.y, a % b.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator ++(float3 a) => new float3(++a.x, ++a.y, ++a.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator --(float3 a) => new float3(--a.x, --a.y, --a.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator -(float3 a) => new float3(-a.x, -a.y, -a.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float3 operator +(float3 a) => new float3(+a.x, +a.y, +a.z);
        #endregion

        #region Boolean operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(float3 a, float3 b) => a.x == b.x && a.y == b.y && a.z == b.z;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(float3 a, float b) => a.x == b && a.y == b && a.z == b;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(float a, float3 b) => a == b.x && a == b.y && a == b.z;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(float3 a, float3 b) => a.x != b.x || a.y != b.y || a.z != b.z;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(float3 a, float b) => a.x != b || a.y != b || a.z != b;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(float a, float3 b) => a != b.x || a != b.y || a != b.z;
        #endregion

        #region Swap2
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 xx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float2(x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 xy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float2(x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 xz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float2(x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 x_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float2(x, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 yx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float2(y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 yy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float2(y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 yz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float2(y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 y_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float2(y, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 zx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float2(z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 zy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float2(z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 zz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float2(z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 z_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float2(z, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 _x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float2(0f, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 _y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float2(0f, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 _z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float2(0f, z);
         }
        #endregion

        #region Swap3
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(x, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(x, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(x, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(x, x, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(x, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(x, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(x, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(x, y, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(x, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(x, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(x, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(x, z, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 x_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(x, 0f, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 x_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(x, 0f, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 x_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(x, 0f, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 x__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(x, 0f, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(y, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(y, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(y, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(y, x, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(y, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(y, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(y, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(y, y, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(y, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(y, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(y, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(y, z, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 y_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(y, 0f, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 y_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(y, 0f, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 y_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(y, 0f, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 y__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(y, 0f, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 zxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(z, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 zxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(z, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 zxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(z, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 zx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(z, x, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 zyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(z, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 zyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(z, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 zyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(z, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 zy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(z, y, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 zzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(z, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 zzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(z, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 zzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(z, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 zz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(z, z, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 z_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(z, 0f, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 z_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(z, 0f, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 z_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(z, 0f, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 z__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(z, 0f, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 _xx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(0f, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 _xy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(0f, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 _xz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(0f, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 _x_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(0f, x, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 _yx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(0f, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 _yy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(0f, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 _yz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(0f, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 _y_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(0f, y, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 _zx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(0f, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 _zy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(0f, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 _zz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(0f, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 _z_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(0f, z, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 __x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(0f, 0f, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 __y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(0f, 0f, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 __z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float3(0f, 0f, z);
         }
        #endregion

        #region Swap4
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, x, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, x, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, x, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, x, x, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, x, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, x, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, x, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, x, y, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, x, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, x, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, x, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, x, z, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xx_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, x, 0f, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xx_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, x, 0f, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xx_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, x, 0f, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xx__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, x, 0f, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, y, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, y, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, y, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, y, x, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, y, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, y, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, y, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, y, y, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, y, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, y, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, y, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, y, z, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xy_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, y, 0f, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xy_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, y, 0f, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xy_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, y, 0f, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xy__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, y, 0f, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xzxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, z, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xzxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, z, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xzxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, z, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xzx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, z, x, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xzyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, z, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xzyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, z, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xzyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, z, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xzy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, z, y, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xzzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, z, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xzzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, z, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xzzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, z, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xzz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, z, z, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xz_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, z, 0f, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xz_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, z, 0f, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xz_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, z, 0f, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xz__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, z, 0f, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x_xx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, 0f, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x_xy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, 0f, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x_xz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, 0f, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x_x_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, 0f, x, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x_yx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, 0f, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x_yy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, 0f, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x_yz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, 0f, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x_y_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, 0f, y, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x_zx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, 0f, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x_zy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, 0f, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x_zz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, 0f, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x_z_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, 0f, z, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x__x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, 0f, 0f, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x__y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, 0f, 0f, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x__z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, 0f, 0f, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x___
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(x, 0f, 0f, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, x, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, x, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, x, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, x, x, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, x, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, x, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, x, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, x, y, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, x, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, x, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, x, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, x, z, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yx_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, x, 0f, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yx_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, x, 0f, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yx_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, x, 0f, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yx__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, x, 0f, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, y, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, y, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, y, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, y, x, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, y, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, y, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, y, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, y, y, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, y, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, y, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, y, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, y, z, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yy_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, y, 0f, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yy_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, y, 0f, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yy_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, y, 0f, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yy__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, y, 0f, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yzxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, z, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yzxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, z, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yzxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, z, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yzx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, z, x, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yzyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, z, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yzyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, z, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yzyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, z, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yzy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, z, y, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yzzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, z, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yzzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, z, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yzzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, z, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yzz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, z, z, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yz_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, z, 0f, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yz_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, z, 0f, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yz_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, z, 0f, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yz__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, z, 0f, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y_xx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, 0f, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y_xy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, 0f, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y_xz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, 0f, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y_x_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, 0f, x, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y_yx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, 0f, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y_yy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, 0f, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y_yz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, 0f, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y_y_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, 0f, y, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y_zx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, 0f, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y_zy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, 0f, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y_zz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, 0f, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y_z_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, 0f, z, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y__x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, 0f, 0f, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y__y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, 0f, 0f, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y__z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, 0f, 0f, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y___
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(y, 0f, 0f, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zxxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, x, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zxxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, x, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zxxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, x, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zxx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, x, x, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zxyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, x, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zxyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, x, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zxyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, x, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zxy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, x, y, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zxzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, x, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zxzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, x, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zxzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, x, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zxz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, x, z, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zx_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, x, 0f, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zx_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, x, 0f, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zx_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, x, 0f, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zx__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, x, 0f, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zyxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, y, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zyxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, y, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zyxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, y, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zyx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, y, x, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zyyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, y, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zyyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, y, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zyyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, y, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zyy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, y, y, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zyzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, y, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zyzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, y, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zyzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, y, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zyz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, y, z, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zy_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, y, 0f, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zy_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, y, 0f, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zy_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, y, 0f, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zy__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, y, 0f, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zzxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, z, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zzxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, z, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zzxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, z, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zzx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, z, x, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zzyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, z, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zzyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, z, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zzyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, z, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zzy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, z, y, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zzzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, z, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zzzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, z, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zzzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, z, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zzz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, z, z, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zz_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, z, 0f, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zz_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, z, 0f, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zz_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, z, 0f, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zz__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, z, 0f, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 z_xx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, 0f, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 z_xy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, 0f, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 z_xz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, 0f, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 z_x_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, 0f, x, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 z_yx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, 0f, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 z_yy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, 0f, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 z_yz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, 0f, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 z_y_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, 0f, y, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 z_zx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, 0f, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 z_zy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, 0f, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 z_zz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, 0f, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 z_z_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, 0f, z, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 z__x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, 0f, 0f, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 z__y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, 0f, 0f, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 z__z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, 0f, 0f, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 z___
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(z, 0f, 0f, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _xxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, x, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _xxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, x, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _xxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, x, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _xx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, x, x, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _xyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, x, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _xyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, x, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _xyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, x, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _xy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, x, y, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _xzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, x, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _xzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, x, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _xzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, x, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _xz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, x, z, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _x_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, x, 0f, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _x_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, x, 0f, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _x_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, x, 0f, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _x__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, x, 0f, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _yxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, y, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _yxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, y, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _yxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, y, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _yx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, y, x, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _yyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, y, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _yyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, y, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _yyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, y, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _yy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, y, y, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _yzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, y, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _yzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, y, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _yzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, y, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _yz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, y, z, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _y_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, y, 0f, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _y_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, y, 0f, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _y_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, y, 0f, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _y__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, y, 0f, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _zxx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, z, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _zxy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, z, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _zxz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, z, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _zx_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, z, x, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _zyx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, z, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _zyy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, z, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _zyz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, z, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _zy_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, z, y, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _zzx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, z, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _zzy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, z, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _zzz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, z, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _zz_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, z, z, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _z_x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, z, 0f, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _z_y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, z, 0f, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _z_z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, z, 0f, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _z__
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, z, 0f, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 __xx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, 0f, x, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 __xy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, 0f, x, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 __xz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, 0f, x, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 __x_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, 0f, x, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 __yx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, 0f, y, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 __yy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, 0f, y, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 __yz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, 0f, y, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 __y_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, 0f, y, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 __zx
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, 0f, z, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 __zy
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, 0f, z, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 __zz
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, 0f, z, z);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 __z_
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, 0f, z, 0f);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 ___x
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, 0f, 0f, x);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 ___y
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, 0f, 0f, y);
         }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 ___z
         {
             [MethodImpl(MethodImplOptions.AggressiveInlining)]
             get => new float4(0f, 0f, 0f, z);
         }
        #endregion


        #region Object
        public override bool Equals(object o) => o is float3 target && Equals(target); 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => math.hash(this);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => $"float3({x}, {y}, {z})";
        #endregion

        #region IEquatable/IFormattable
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(float3 a) => x == a.x && y == a.y && z == a.z; 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"float3({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)})";
        }
        #endregion

        #region Enumerator
        VectorEnumerator<float, float3> IEnumerableVector<float, float3>.GetEnumerator() => new VectorEnumerator<float, float3>(this);
        IEnumerator<float> IEnumerable<float>.GetEnumerator() => new VectorEnumerator<float, float3>(this);
        IEnumerator IEnumerable.GetEnumerator() => new VectorEnumerator<float, float3>(this);
        public Enumerator GetEnumerator() => new Enumerator(this);
        public unsafe ref struct Enumerator
        {
            private readonly float* _pointer;
            private sbyte _index;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Enumerator(in float3 value)
            {
                fixed (float3* array = &value)
                {
                    _pointer = (float*)array;
                    _index = -1;
                }
            }
            public float Current => _pointer[_index];
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
            public float x;
            public float y;
            public float z;
            public DebuggerProxy(float3 v)
            {
                x = v.x;
                y = v.y;
                z = v.z;
            }
        }
        #endregion
    }
}
