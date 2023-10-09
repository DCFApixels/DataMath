using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

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
        public float r { [IN(LINE)] get => (float)x; [IN(LINE)] set => x = (float)value; }
        public float g { [IN(LINE)] get => (float)y; [IN(LINE)] set => y = (float)value; }
        public float b { [IN(LINE)] get => (float)z; [IN(LINE)] set => z = (float)value; }
        public float a { [IN(LINE)] get => 1f; [IN(LINE)] set {} }
        #endregion

        #region IVectorN
        [EditorBrowsable(EditorBrowsableState.Never)]
        float IVector1<float>.x { [IN(LINE)] get => x; [IN(LINE)] set => x = value; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        float IVector2<float>.y { [IN(LINE)] get => y; [IN(LINE)] set => y = value; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        float IVector3<float>.z { [IN(LINE)] get => z; [IN(LINE)] set => z = value; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int length { [IN(LINE)] get => LENGTH; }

        public unsafe float this[int index]
        {
            get
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > LENGTH) throw new IndexOutOfRangeException($"Index must be between[0..{(LENGTH - 1)}].");
#endif
                fixed (float3* array = &this) { return ((float*)array)[index]; }
            }
            set
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > LENGTH) throw new IndexOutOfRangeException($"Index must be between[0..{(LENGTH - 1)}].");
#endif
                fixed (float* array = &x) { array[index] = value; }
            }
        }
        #endregion

        #region Constructors
        [IN(LINE)]
        public float3(float x, float y, float z)
        {
            this.x = x; this.y = y; this.z = z;
        }
        [IN(LINE)]
        public float3(float v)
        {
            x = v; y = v; z = v;
        }
        [IN(LINE)]
        public float3(float3 v)
        {
            x = v.x; y = v.y; z = v.z;
        }
        [IN(LINE)]
        public float3(double x, double y, double z)
        {
            this.x = (float)x; this.y = (float)y; this.z = (float)z;
        }
        [IN(LINE)]
        public float3(double v)
        {
            x = (float)v; y = (float)v; z = (float)v;
        }
        [IN(LINE)]
        public float3(double3 v)
        {
            x = (float)v.x; y = (float)v.y; z = (float)v.z;
        }
        [IN(LINE)]
        public float3(int x, int y, int z)
        {
            this.x = (float)x; this.y = (float)y; this.z = (float)z;
        }
        [IN(LINE)]
        public float3(int v)
        {
            x = (float)v; y = (float)v; z = (float)v;
        }
        [IN(LINE)]
        public float3(int3 v)
        {
            x = (float)v.x; y = (float)v.y; z = (float)v.z;
        }
        [IN(LINE)]
        public float3(uint x, uint y, uint z)
        {
            this.x = (float)x; this.y = (float)y; this.z = (float)z;
        }
        [IN(LINE)]
        public float3(uint v)
        {
            x = (float)v; y = (float)v; z = (float)v;
        }
        [IN(LINE)]
        public float3(uint3 v)
        {
            x = (float)v.x; y = (float)v.y; z = (float)v.z;
        }

        #endregion

        #region Arithmetic operators
        [IN(LINE)]
        public static float3 operator *(float3 a, float3 b) => new float3(a.x * b.x, a.y * b.y, a.z * b.z);
        [IN(LINE)]
        public static float3 operator *(float3 a, float b) => new float3(a.x * b, a.y * b, a.z * b);
        [IN(LINE)]
        public static float3 operator *(float a, float3 b) => new float3(a * b.x, a * b.y, a * b.z);

        [IN(LINE)]
        public static float3 operator +(float3 a, float3 b) => new float3(a.x + b.x, a.y + b.y, a.z + b.z);
        [IN(LINE)]
        public static float3 operator +(float3 a, float b) => new float3(a.x + b, a.y + b, a.z + b);
        [IN(LINE)]
        public static float3 operator +(float a, float3 b) => new float3(a + b.x, a + b.y, a + b.z);

        [IN(LINE)]
        public static float3 operator -(float3 a, float3 b) => new float3(a.x - b.x, a.y - b.y, a.z - b.z);
        [IN(LINE)]
        public static float3 operator -(float3 a, float b) => new float3(a.x - b, a.y - b, a.z - b);
        [IN(LINE)]
        public static float3 operator -(float a, float3 b) => new float3(a - b.x, a - b.y, a - b.z);

        [IN(LINE)]
        public static float3 operator /(float3 a, float3 b) => new float3(a.x / b.x, a.y / b.y, a.z / b.z);
        [IN(LINE)]
        public static float3 operator /(float3 a, float b) => new float3(a.x / b, a.y / b, a.z / b);
        [IN(LINE)]
        public static float3 operator /(float a, float3 b) => new float3(a / b.x, a / b.y, a / b.z);

        [IN(LINE)]
        public static float3 operator %(float3 a, float3 b) => new float3(a.x % b.x, a.y % b.y, a.z % b.z);
        [IN(LINE)]
        public static float3 operator %(float3 a, float b) => new float3(a.x % b, a.y % b, a.z % b);
        [IN(LINE)]
        public static float3 operator %(float a, float3 b) => new float3(a % b.x, a % b.y, a % b.z);

        [IN(LINE)]
        public static float3 operator ++(float3 a) => new float3(++a.x, ++a.y, ++a.z);
        [IN(LINE)]
        public static float3 operator --(float3 a) => new float3(--a.x, --a.y, --a.z);
        [IN(LINE)]
        public static float3 operator -(float3 a) => new float3(-a.x, -a.y, -a.z);
        [IN(LINE)]
        public static float3 operator +(float3 a) => new float3(+a.x, +a.y, +a.z);
        #endregion

        #region Boolean operators
        [IN(LINE)]
        public static bool operator ==(float3 a, float3 b) => a.x == b.x && a.y == b.y && a.z == b.z;
        [IN(LINE)]
        public static bool operator ==(float3 a, float b) => a.x == b && a.y == b && a.z == b;
        [IN(LINE)]
        public static bool operator ==(float a, float3 b) => a == b.x && a == b.y && a == b.z;

        [IN(LINE)]
        public static bool operator !=(float3 a, float3 b) => a.x != b.x || a.y != b.y || a.z != b.z;
        [IN(LINE)]
        public static bool operator !=(float3 a, float b) => a.x != b || a.y != b || a.z != b;
        [IN(LINE)]
        public static bool operator !=(float a, float3 b) => a != b.x || a != b.y || a != b.z;
        #endregion

        #region Swap2
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 xx { [IN(LINE)] get => new float2(x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 xy { [IN(LINE)] get => new float2(x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 xz { [IN(LINE)] get => new float2(x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 x_ { [IN(LINE)] get => new float2(x, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 yx { [IN(LINE)] get => new float2(y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 yy { [IN(LINE)] get => new float2(y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 yz { [IN(LINE)] get => new float2(y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 y_ { [IN(LINE)] get => new float2(y, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 zx { [IN(LINE)] get => new float2(z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 zy { [IN(LINE)] get => new float2(z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 zz { [IN(LINE)] get => new float2(z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 z_ { [IN(LINE)] get => new float2(z, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 _x { [IN(LINE)] get => new float2(0f, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 _y { [IN(LINE)] get => new float2(0f, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float2 _z { [IN(LINE)] get => new float2(0f, z); }
        #endregion

        #region Swap3
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xxx { [IN(LINE)] get => new float3(x, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xxy { [IN(LINE)] get => new float3(x, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xxz { [IN(LINE)] get => new float3(x, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xx_ { [IN(LINE)] get => new float3(x, x, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xyx { [IN(LINE)] get => new float3(x, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xyy { [IN(LINE)] get => new float3(x, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xyz { [IN(LINE)] get => new float3(x, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xy_ { [IN(LINE)] get => new float3(x, y, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xzx { [IN(LINE)] get => new float3(x, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xzy { [IN(LINE)] get => new float3(x, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xzz { [IN(LINE)] get => new float3(x, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 xz_ { [IN(LINE)] get => new float3(x, z, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 x_x { [IN(LINE)] get => new float3(x, 0f, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 x_y { [IN(LINE)] get => new float3(x, 0f, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 x_z { [IN(LINE)] get => new float3(x, 0f, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 x__ { [IN(LINE)] get => new float3(x, 0f, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yxx { [IN(LINE)] get => new float3(y, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yxy { [IN(LINE)] get => new float3(y, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yxz { [IN(LINE)] get => new float3(y, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yx_ { [IN(LINE)] get => new float3(y, x, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yyx { [IN(LINE)] get => new float3(y, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yyy { [IN(LINE)] get => new float3(y, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yyz { [IN(LINE)] get => new float3(y, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yy_ { [IN(LINE)] get => new float3(y, y, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yzx { [IN(LINE)] get => new float3(y, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yzy { [IN(LINE)] get => new float3(y, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yzz { [IN(LINE)] get => new float3(y, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 yz_ { [IN(LINE)] get => new float3(y, z, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 y_x { [IN(LINE)] get => new float3(y, 0f, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 y_y { [IN(LINE)] get => new float3(y, 0f, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 y_z { [IN(LINE)] get => new float3(y, 0f, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 y__ { [IN(LINE)] get => new float3(y, 0f, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 zxx { [IN(LINE)] get => new float3(z, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 zxy { [IN(LINE)] get => new float3(z, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 zxz { [IN(LINE)] get => new float3(z, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 zx_ { [IN(LINE)] get => new float3(z, x, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 zyx { [IN(LINE)] get => new float3(z, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 zyy { [IN(LINE)] get => new float3(z, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 zyz { [IN(LINE)] get => new float3(z, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 zy_ { [IN(LINE)] get => new float3(z, y, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 zzx { [IN(LINE)] get => new float3(z, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 zzy { [IN(LINE)] get => new float3(z, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 zzz { [IN(LINE)] get => new float3(z, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 zz_ { [IN(LINE)] get => new float3(z, z, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 z_x { [IN(LINE)] get => new float3(z, 0f, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 z_y { [IN(LINE)] get => new float3(z, 0f, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 z_z { [IN(LINE)] get => new float3(z, 0f, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 z__ { [IN(LINE)] get => new float3(z, 0f, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 _xx { [IN(LINE)] get => new float3(0f, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 _xy { [IN(LINE)] get => new float3(0f, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 _xz { [IN(LINE)] get => new float3(0f, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 _x_ { [IN(LINE)] get => new float3(0f, x, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 _yx { [IN(LINE)] get => new float3(0f, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 _yy { [IN(LINE)] get => new float3(0f, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 _yz { [IN(LINE)] get => new float3(0f, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 _y_ { [IN(LINE)] get => new float3(0f, y, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 _zx { [IN(LINE)] get => new float3(0f, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 _zy { [IN(LINE)] get => new float3(0f, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 _zz { [IN(LINE)] get => new float3(0f, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 _z_ { [IN(LINE)] get => new float3(0f, z, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 __x { [IN(LINE)] get => new float3(0f, 0f, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 __y { [IN(LINE)] get => new float3(0f, 0f, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float3 __z { [IN(LINE)] get => new float3(0f, 0f, z); }
        #endregion

        #region Swap4
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxxx { [IN(LINE)] get => new float4(x, x, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxxy { [IN(LINE)] get => new float4(x, x, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxxz { [IN(LINE)] get => new float4(x, x, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxx_ { [IN(LINE)] get => new float4(x, x, x, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxyx { [IN(LINE)] get => new float4(x, x, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxyy { [IN(LINE)] get => new float4(x, x, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxyz { [IN(LINE)] get => new float4(x, x, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxy_ { [IN(LINE)] get => new float4(x, x, y, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxzx { [IN(LINE)] get => new float4(x, x, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxzy { [IN(LINE)] get => new float4(x, x, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxzz { [IN(LINE)] get => new float4(x, x, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xxz_ { [IN(LINE)] get => new float4(x, x, z, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xx_x { [IN(LINE)] get => new float4(x, x, 0f, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xx_y { [IN(LINE)] get => new float4(x, x, 0f, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xx_z { [IN(LINE)] get => new float4(x, x, 0f, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xx__ { [IN(LINE)] get => new float4(x, x, 0f, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyxx { [IN(LINE)] get => new float4(x, y, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyxy { [IN(LINE)] get => new float4(x, y, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyxz { [IN(LINE)] get => new float4(x, y, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyx_ { [IN(LINE)] get => new float4(x, y, x, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyyx { [IN(LINE)] get => new float4(x, y, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyyy { [IN(LINE)] get => new float4(x, y, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyyz { [IN(LINE)] get => new float4(x, y, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyy_ { [IN(LINE)] get => new float4(x, y, y, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyzx { [IN(LINE)] get => new float4(x, y, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyzy { [IN(LINE)] get => new float4(x, y, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyzz { [IN(LINE)] get => new float4(x, y, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xyz_ { [IN(LINE)] get => new float4(x, y, z, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xy_x { [IN(LINE)] get => new float4(x, y, 0f, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xy_y { [IN(LINE)] get => new float4(x, y, 0f, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xy_z { [IN(LINE)] get => new float4(x, y, 0f, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xy__ { [IN(LINE)] get => new float4(x, y, 0f, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xzxx { [IN(LINE)] get => new float4(x, z, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xzxy { [IN(LINE)] get => new float4(x, z, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xzxz { [IN(LINE)] get => new float4(x, z, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xzx_ { [IN(LINE)] get => new float4(x, z, x, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xzyx { [IN(LINE)] get => new float4(x, z, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xzyy { [IN(LINE)] get => new float4(x, z, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xzyz { [IN(LINE)] get => new float4(x, z, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xzy_ { [IN(LINE)] get => new float4(x, z, y, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xzzx { [IN(LINE)] get => new float4(x, z, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xzzy { [IN(LINE)] get => new float4(x, z, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xzzz { [IN(LINE)] get => new float4(x, z, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xzz_ { [IN(LINE)] get => new float4(x, z, z, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xz_x { [IN(LINE)] get => new float4(x, z, 0f, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xz_y { [IN(LINE)] get => new float4(x, z, 0f, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xz_z { [IN(LINE)] get => new float4(x, z, 0f, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 xz__ { [IN(LINE)] get => new float4(x, z, 0f, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x_xx { [IN(LINE)] get => new float4(x, 0f, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x_xy { [IN(LINE)] get => new float4(x, 0f, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x_xz { [IN(LINE)] get => new float4(x, 0f, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x_x_ { [IN(LINE)] get => new float4(x, 0f, x, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x_yx { [IN(LINE)] get => new float4(x, 0f, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x_yy { [IN(LINE)] get => new float4(x, 0f, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x_yz { [IN(LINE)] get => new float4(x, 0f, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x_y_ { [IN(LINE)] get => new float4(x, 0f, y, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x_zx { [IN(LINE)] get => new float4(x, 0f, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x_zy { [IN(LINE)] get => new float4(x, 0f, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x_zz { [IN(LINE)] get => new float4(x, 0f, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x_z_ { [IN(LINE)] get => new float4(x, 0f, z, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x__x { [IN(LINE)] get => new float4(x, 0f, 0f, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x__y { [IN(LINE)] get => new float4(x, 0f, 0f, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x__z { [IN(LINE)] get => new float4(x, 0f, 0f, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 x___ { [IN(LINE)] get => new float4(x, 0f, 0f, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxxx { [IN(LINE)] get => new float4(y, x, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxxy { [IN(LINE)] get => new float4(y, x, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxxz { [IN(LINE)] get => new float4(y, x, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxx_ { [IN(LINE)] get => new float4(y, x, x, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxyx { [IN(LINE)] get => new float4(y, x, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxyy { [IN(LINE)] get => new float4(y, x, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxyz { [IN(LINE)] get => new float4(y, x, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxy_ { [IN(LINE)] get => new float4(y, x, y, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxzx { [IN(LINE)] get => new float4(y, x, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxzy { [IN(LINE)] get => new float4(y, x, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxzz { [IN(LINE)] get => new float4(y, x, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yxz_ { [IN(LINE)] get => new float4(y, x, z, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yx_x { [IN(LINE)] get => new float4(y, x, 0f, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yx_y { [IN(LINE)] get => new float4(y, x, 0f, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yx_z { [IN(LINE)] get => new float4(y, x, 0f, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yx__ { [IN(LINE)] get => new float4(y, x, 0f, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyxx { [IN(LINE)] get => new float4(y, y, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyxy { [IN(LINE)] get => new float4(y, y, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyxz { [IN(LINE)] get => new float4(y, y, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyx_ { [IN(LINE)] get => new float4(y, y, x, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyyx { [IN(LINE)] get => new float4(y, y, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyyy { [IN(LINE)] get => new float4(y, y, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyyz { [IN(LINE)] get => new float4(y, y, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyy_ { [IN(LINE)] get => new float4(y, y, y, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyzx { [IN(LINE)] get => new float4(y, y, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyzy { [IN(LINE)] get => new float4(y, y, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyzz { [IN(LINE)] get => new float4(y, y, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yyz_ { [IN(LINE)] get => new float4(y, y, z, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yy_x { [IN(LINE)] get => new float4(y, y, 0f, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yy_y { [IN(LINE)] get => new float4(y, y, 0f, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yy_z { [IN(LINE)] get => new float4(y, y, 0f, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yy__ { [IN(LINE)] get => new float4(y, y, 0f, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yzxx { [IN(LINE)] get => new float4(y, z, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yzxy { [IN(LINE)] get => new float4(y, z, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yzxz { [IN(LINE)] get => new float4(y, z, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yzx_ { [IN(LINE)] get => new float4(y, z, x, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yzyx { [IN(LINE)] get => new float4(y, z, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yzyy { [IN(LINE)] get => new float4(y, z, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yzyz { [IN(LINE)] get => new float4(y, z, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yzy_ { [IN(LINE)] get => new float4(y, z, y, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yzzx { [IN(LINE)] get => new float4(y, z, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yzzy { [IN(LINE)] get => new float4(y, z, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yzzz { [IN(LINE)] get => new float4(y, z, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yzz_ { [IN(LINE)] get => new float4(y, z, z, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yz_x { [IN(LINE)] get => new float4(y, z, 0f, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yz_y { [IN(LINE)] get => new float4(y, z, 0f, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yz_z { [IN(LINE)] get => new float4(y, z, 0f, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 yz__ { [IN(LINE)] get => new float4(y, z, 0f, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y_xx { [IN(LINE)] get => new float4(y, 0f, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y_xy { [IN(LINE)] get => new float4(y, 0f, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y_xz { [IN(LINE)] get => new float4(y, 0f, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y_x_ { [IN(LINE)] get => new float4(y, 0f, x, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y_yx { [IN(LINE)] get => new float4(y, 0f, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y_yy { [IN(LINE)] get => new float4(y, 0f, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y_yz { [IN(LINE)] get => new float4(y, 0f, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y_y_ { [IN(LINE)] get => new float4(y, 0f, y, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y_zx { [IN(LINE)] get => new float4(y, 0f, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y_zy { [IN(LINE)] get => new float4(y, 0f, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y_zz { [IN(LINE)] get => new float4(y, 0f, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y_z_ { [IN(LINE)] get => new float4(y, 0f, z, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y__x { [IN(LINE)] get => new float4(y, 0f, 0f, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y__y { [IN(LINE)] get => new float4(y, 0f, 0f, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y__z { [IN(LINE)] get => new float4(y, 0f, 0f, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 y___ { [IN(LINE)] get => new float4(y, 0f, 0f, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zxxx { [IN(LINE)] get => new float4(z, x, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zxxy { [IN(LINE)] get => new float4(z, x, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zxxz { [IN(LINE)] get => new float4(z, x, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zxx_ { [IN(LINE)] get => new float4(z, x, x, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zxyx { [IN(LINE)] get => new float4(z, x, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zxyy { [IN(LINE)] get => new float4(z, x, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zxyz { [IN(LINE)] get => new float4(z, x, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zxy_ { [IN(LINE)] get => new float4(z, x, y, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zxzx { [IN(LINE)] get => new float4(z, x, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zxzy { [IN(LINE)] get => new float4(z, x, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zxzz { [IN(LINE)] get => new float4(z, x, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zxz_ { [IN(LINE)] get => new float4(z, x, z, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zx_x { [IN(LINE)] get => new float4(z, x, 0f, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zx_y { [IN(LINE)] get => new float4(z, x, 0f, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zx_z { [IN(LINE)] get => new float4(z, x, 0f, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zx__ { [IN(LINE)] get => new float4(z, x, 0f, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zyxx { [IN(LINE)] get => new float4(z, y, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zyxy { [IN(LINE)] get => new float4(z, y, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zyxz { [IN(LINE)] get => new float4(z, y, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zyx_ { [IN(LINE)] get => new float4(z, y, x, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zyyx { [IN(LINE)] get => new float4(z, y, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zyyy { [IN(LINE)] get => new float4(z, y, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zyyz { [IN(LINE)] get => new float4(z, y, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zyy_ { [IN(LINE)] get => new float4(z, y, y, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zyzx { [IN(LINE)] get => new float4(z, y, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zyzy { [IN(LINE)] get => new float4(z, y, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zyzz { [IN(LINE)] get => new float4(z, y, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zyz_ { [IN(LINE)] get => new float4(z, y, z, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zy_x { [IN(LINE)] get => new float4(z, y, 0f, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zy_y { [IN(LINE)] get => new float4(z, y, 0f, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zy_z { [IN(LINE)] get => new float4(z, y, 0f, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zy__ { [IN(LINE)] get => new float4(z, y, 0f, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zzxx { [IN(LINE)] get => new float4(z, z, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zzxy { [IN(LINE)] get => new float4(z, z, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zzxz { [IN(LINE)] get => new float4(z, z, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zzx_ { [IN(LINE)] get => new float4(z, z, x, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zzyx { [IN(LINE)] get => new float4(z, z, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zzyy { [IN(LINE)] get => new float4(z, z, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zzyz { [IN(LINE)] get => new float4(z, z, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zzy_ { [IN(LINE)] get => new float4(z, z, y, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zzzx { [IN(LINE)] get => new float4(z, z, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zzzy { [IN(LINE)] get => new float4(z, z, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zzzz { [IN(LINE)] get => new float4(z, z, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zzz_ { [IN(LINE)] get => new float4(z, z, z, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zz_x { [IN(LINE)] get => new float4(z, z, 0f, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zz_y { [IN(LINE)] get => new float4(z, z, 0f, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zz_z { [IN(LINE)] get => new float4(z, z, 0f, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 zz__ { [IN(LINE)] get => new float4(z, z, 0f, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 z_xx { [IN(LINE)] get => new float4(z, 0f, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 z_xy { [IN(LINE)] get => new float4(z, 0f, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 z_xz { [IN(LINE)] get => new float4(z, 0f, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 z_x_ { [IN(LINE)] get => new float4(z, 0f, x, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 z_yx { [IN(LINE)] get => new float4(z, 0f, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 z_yy { [IN(LINE)] get => new float4(z, 0f, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 z_yz { [IN(LINE)] get => new float4(z, 0f, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 z_y_ { [IN(LINE)] get => new float4(z, 0f, y, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 z_zx { [IN(LINE)] get => new float4(z, 0f, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 z_zy { [IN(LINE)] get => new float4(z, 0f, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 z_zz { [IN(LINE)] get => new float4(z, 0f, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 z_z_ { [IN(LINE)] get => new float4(z, 0f, z, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 z__x { [IN(LINE)] get => new float4(z, 0f, 0f, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 z__y { [IN(LINE)] get => new float4(z, 0f, 0f, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 z__z { [IN(LINE)] get => new float4(z, 0f, 0f, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 z___ { [IN(LINE)] get => new float4(z, 0f, 0f, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _xxx { [IN(LINE)] get => new float4(0f, x, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _xxy { [IN(LINE)] get => new float4(0f, x, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _xxz { [IN(LINE)] get => new float4(0f, x, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _xx_ { [IN(LINE)] get => new float4(0f, x, x, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _xyx { [IN(LINE)] get => new float4(0f, x, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _xyy { [IN(LINE)] get => new float4(0f, x, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _xyz { [IN(LINE)] get => new float4(0f, x, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _xy_ { [IN(LINE)] get => new float4(0f, x, y, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _xzx { [IN(LINE)] get => new float4(0f, x, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _xzy { [IN(LINE)] get => new float4(0f, x, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _xzz { [IN(LINE)] get => new float4(0f, x, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _xz_ { [IN(LINE)] get => new float4(0f, x, z, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _x_x { [IN(LINE)] get => new float4(0f, x, 0f, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _x_y { [IN(LINE)] get => new float4(0f, x, 0f, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _x_z { [IN(LINE)] get => new float4(0f, x, 0f, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _x__ { [IN(LINE)] get => new float4(0f, x, 0f, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _yxx { [IN(LINE)] get => new float4(0f, y, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _yxy { [IN(LINE)] get => new float4(0f, y, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _yxz { [IN(LINE)] get => new float4(0f, y, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _yx_ { [IN(LINE)] get => new float4(0f, y, x, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _yyx { [IN(LINE)] get => new float4(0f, y, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _yyy { [IN(LINE)] get => new float4(0f, y, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _yyz { [IN(LINE)] get => new float4(0f, y, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _yy_ { [IN(LINE)] get => new float4(0f, y, y, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _yzx { [IN(LINE)] get => new float4(0f, y, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _yzy { [IN(LINE)] get => new float4(0f, y, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _yzz { [IN(LINE)] get => new float4(0f, y, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _yz_ { [IN(LINE)] get => new float4(0f, y, z, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _y_x { [IN(LINE)] get => new float4(0f, y, 0f, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _y_y { [IN(LINE)] get => new float4(0f, y, 0f, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _y_z { [IN(LINE)] get => new float4(0f, y, 0f, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _y__ { [IN(LINE)] get => new float4(0f, y, 0f, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _zxx { [IN(LINE)] get => new float4(0f, z, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _zxy { [IN(LINE)] get => new float4(0f, z, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _zxz { [IN(LINE)] get => new float4(0f, z, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _zx_ { [IN(LINE)] get => new float4(0f, z, x, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _zyx { [IN(LINE)] get => new float4(0f, z, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _zyy { [IN(LINE)] get => new float4(0f, z, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _zyz { [IN(LINE)] get => new float4(0f, z, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _zy_ { [IN(LINE)] get => new float4(0f, z, y, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _zzx { [IN(LINE)] get => new float4(0f, z, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _zzy { [IN(LINE)] get => new float4(0f, z, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _zzz { [IN(LINE)] get => new float4(0f, z, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _zz_ { [IN(LINE)] get => new float4(0f, z, z, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _z_x { [IN(LINE)] get => new float4(0f, z, 0f, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _z_y { [IN(LINE)] get => new float4(0f, z, 0f, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _z_z { [IN(LINE)] get => new float4(0f, z, 0f, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 _z__ { [IN(LINE)] get => new float4(0f, z, 0f, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 __xx { [IN(LINE)] get => new float4(0f, 0f, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 __xy { [IN(LINE)] get => new float4(0f, 0f, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 __xz { [IN(LINE)] get => new float4(0f, 0f, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 __x_ { [IN(LINE)] get => new float4(0f, 0f, x, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 __yx { [IN(LINE)] get => new float4(0f, 0f, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 __yy { [IN(LINE)] get => new float4(0f, 0f, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 __yz { [IN(LINE)] get => new float4(0f, 0f, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 __y_ { [IN(LINE)] get => new float4(0f, 0f, y, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 __zx { [IN(LINE)] get => new float4(0f, 0f, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 __zy { [IN(LINE)] get => new float4(0f, 0f, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 __zz { [IN(LINE)] get => new float4(0f, 0f, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 __z_ { [IN(LINE)] get => new float4(0f, 0f, z, 0f); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 ___x { [IN(LINE)] get => new float4(0f, 0f, 0f, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 ___y { [IN(LINE)] get => new float4(0f, 0f, 0f, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public float4 ___z { [IN(LINE)] get => new float4(0f, 0f, 0f, z); }
        #endregion


        #region Other 
        [IN(LINE)]
        public override int GetHashCode() => math.hash(this);
        [IN(LINE)]
        public override bool Equals(object o) => o is float3 target && Equals(target); 
        [IN(LINE)]
        public bool Equals(float3 a) => x == a.x && y == a.y && z == a.z; 
        [IN(LINE)]
        public override string ToString() => $"float3({x}, {y}, {z})";
        [IN(LINE)]
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
            [IN(LINE)]
            public Enumerator(in float3 value)
            {
                fixed (float3* array = &value)
                {
                    _pointer = (float*)array;
                    _index = -1;
                }
            }
            public float Current => _pointer[_index];
            [IN(LINE)]
            public void Dispose() { }
            [IN(LINE)]
            public bool MoveNext() => ++_index < LENGTH;
            [IN(LINE)]
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
