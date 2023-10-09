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
        public float r { [IN(LINE)] get => (float)x; [IN(LINE)] set => x = (uint)value; }
        public float g { [IN(LINE)] get => (float)y; [IN(LINE)] set => y = (uint)value; }
        public float b { [IN(LINE)] get => (float)z; [IN(LINE)] set => z = (uint)value; }
        public float a { [IN(LINE)] get => (float)w; [IN(LINE)] set => w = (uint)value; }
        #endregion

        #region IVectorN
        [EditorBrowsable(EditorBrowsableState.Never)]
        uint IVector1<uint>.x { [IN(LINE)] get => x; [IN(LINE)] set => x = value; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        uint IVector2<uint>.y { [IN(LINE)] get => y; [IN(LINE)] set => y = value; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        uint IVector3<uint>.z { [IN(LINE)] get => z; [IN(LINE)] set => z = value; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        uint IVector4<uint>.w { [IN(LINE)] get => w; [IN(LINE)] set => w = value; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int length { [IN(LINE)] get => LENGTH; }

        public unsafe uint this[int index]
        {
            get
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > LENGTH) throw new IndexOutOfRangeException($"Index must be between[0..{(LENGTH - 1)}].");
#endif
                fixed (uint4* array = &this) { return ((uint*)array)[index]; }
            }
            set
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > LENGTH) throw new IndexOutOfRangeException($"Index must be between[0..{(LENGTH - 1)}].");
#endif
                fixed (uint* array = &x) { array[index] = value; }
            }
        }
        #endregion

        #region Constructors
        [IN(LINE)]
        public uint4(float x, float y, float z, float w)
        {
            this.x = (uint)x; this.y = (uint)y;
            this.z = (uint)z; this.w = (uint)w;
        }
        [IN(LINE)]
        public uint4(float v)
        {
            x = (uint)v; y = (uint)v;
            z = (uint)v; w = (uint)v;
        }
        [IN(LINE)]
        public uint4(float4 v)
        {
            x = (uint)v.x; y = (uint)v.y;
            z = (uint)v.z; w = (uint)v.w;
        }
        [IN(LINE)]
        public uint4(double x, double y, double z, double w)
        {
            this.x = (uint)x; this.y = (uint)y;
            this.z = (uint)z; this.w = (uint)w;
        }
        [IN(LINE)]
        public uint4(double v)
        {
            x = (uint)v; y = (uint)v;
            z = (uint)v; w = (uint)v;
        }
        [IN(LINE)]
        public uint4(double4 v)
        {
            x = (uint)v.x; y = (uint)v.y;
            z = (uint)v.z; w = (uint)v.w;
        }
        [IN(LINE)]
        public uint4(int x, int y, int z, int w)
        {
            this.x = (uint)x; this.y = (uint)y;
            this.z = (uint)z; this.w = (uint)w;
        }
        [IN(LINE)]
        public uint4(int v)
        {
            x = (uint)v; y = (uint)v;
            z = (uint)v; w = (uint)v;
        }
        [IN(LINE)]
        public uint4(int4 v)
        {
            x = (uint)v.x; y = (uint)v.y;
            z = (uint)v.z; w = (uint)v.w;
        }
        [IN(LINE)]
        public uint4(uint x, uint y, uint z, uint w)
        {
            this.x = x; this.y = y;
            this.z = z; this.w = w;
        }
        [IN(LINE)]
        public uint4(uint v)
        {
            x = v; y = v;
            z = v; w = v;
        }
        [IN(LINE)]
        public uint4(uint4 v)
        {
            x = v.x; y = v.y;
            z = v.z; w = v.w;
        }

        #endregion

        #region operators

        #region Arithmetic
        [IN(LINE)] public static uint4 operator *(uint4 a, uint4 b) => new uint4(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w);
        [IN(LINE)] public static uint4 operator *(uint4 a, uint b) => new uint4(a.x * b, a.y * b, a.z * b, a.w * b);
        [IN(LINE)] public static uint4 operator *(uint a, uint4 b) => new uint4(a * b.x, a * b.y, a * b.z, a * b.w);

        [IN(LINE)] public static uint4 operator +(uint4 a, uint4 b) => new uint4(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
        [IN(LINE)] public static uint4 operator +(uint4 a, uint b) => new uint4(a.x + b, a.y + b, a.z + b, a.w + b);
        [IN(LINE)] public static uint4 operator +(uint a, uint4 b) => new uint4(a + b.x, a + b.y, a + b.z, a + b.w);

        [IN(LINE)] public static uint4 operator -(uint4 a, uint4 b) => new uint4(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);
        [IN(LINE)] public static uint4 operator -(uint4 a, uint b) => new uint4(a.x - b, a.y - b, a.z - b, a.w - b);
        [IN(LINE)] public static uint4 operator -(uint a, uint4 b) => new uint4(a - b.x, a - b.y, a - b.z, a - b.w);

        [IN(LINE)] public static uint4 operator /(uint4 a, uint4 b) => new uint4(a.x / b.x, a.y / b.y, a.z / b.z, a.w / b.w);
        [IN(LINE)] public static uint4 operator /(uint4 a, uint b) => new uint4(a.x / b, a.y / b, a.z / b, a.w / b);
        [IN(LINE)] public static uint4 operator /(uint a, uint4 b) => new uint4(a / b.x, a / b.y, a / b.z, a / b.w);

        [IN(LINE)] public static uint4 operator %(uint4 a, uint4 b) => new uint4(a.x % b.x, a.y % b.y, a.z % b.z, a.w % b.w);
        [IN(LINE)] public static uint4 operator %(uint4 a, uint b) => new uint4(a.x % b, a.y % b, a.z % b, a.w % b);
        [IN(LINE)] public static uint4 operator %(uint a, uint4 b) => new uint4(a % b.x, a % b.y, a % b.z, a % b.w);

        [IN(LINE)] public static uint4 operator ++(uint4 a) => new uint4(++a.x, ++a.y, ++a.z, ++a.w);
        [IN(LINE)] public static uint4 operator --(uint4 a) => new uint4(--a.x, --a.y, --a.z, --a.w);
        [IN(LINE)] public static uint4 operator -(uint4 a) => new uint4(-a.x, -a.y, -a.z, -a.w);
        [IN(LINE)] public static uint4 operator +(uint4 a) => new uint4(+a.x, +a.y, +a.z, +a.w);
        #endregion

        #region Bits
        [IN(LINE)] public static uint4 operator ~(uint4 a) => new uint4(~a.x, ~a.y, ~a.z, ~a.w);
        [IN(LINE)] public static uint4 operator <<(uint4 a, int n) => new uint4(a.x << n, a.y << n, a.z << n, a.w << n);
        [IN(LINE)] public static uint4 operator >>(uint4 a, int n) => new uint4(a.x >> n, a.y >> n, a.z >> n, a.w >> n);

        [IN(LINE)] public static uint4 operator |(uint4 a, uint4 b) => new uint4(a.x | b.x, a.y | b.y, a.z | b.z, a.w | b.w);
        [IN(LINE)] public static uint4 operator |(uint4 a, uint b) => new uint4(a.x | b, a.y | b, a.z | b, a.w | b);
        [IN(LINE)] public static uint4 operator |(uint a, uint4 b) => new uint4(a | b.x, a | b.y, a | b.z, a | b.w);

        [IN(LINE)] public static uint4 operator &(uint4 a, uint4 b) => new uint4(a.x & b.x, a.y & b.y, a.z & b.z, a.w & b.w);
        [IN(LINE)] public static uint4 operator &(uint4 a, uint b) => new uint4(a.x & b, a.y & b, a.z & b, a.w & b);
        [IN(LINE)] public static uint4 operator &(uint a, uint4 b) => new uint4(a & b.x, a & b.y, a & b.z, a & b.w);

        [IN(LINE)] public static uint4 operator ^(uint4 a, uint4 b) => new uint4(a.x ^ b.x, a.y ^ b.y, a.z ^ b.z, a.w ^ b.w);
        [IN(LINE)] public static uint4 operator ^(uint4 a, uint b) => new uint4(a.x ^ b, a.y ^ b, a.z ^ b, a.w ^ b);
        [IN(LINE)] public static uint4 operator ^(uint a, uint4 b) => new uint4(a ^ b.x, a ^ b.y, a ^ b.z, a ^ b.w);
        #endregion

        #region Boolean
        [IN(LINE)] public static bool operator ==(uint4 a, uint4 b) => a.x == b.x && a.y == b.y && a.z == b.z && a.w == b.w;
        [IN(LINE)] public static bool operator ==(uint4 a, uint b) => a.x == b && a.y == b && a.z == b && a.w == b;
        [IN(LINE)] public static bool operator ==(uint a, uint4 b) => a == b.x && a == b.y && a == b.z && a == b.w;

        [IN(LINE)] public static bool operator !=(uint4 a, uint4 b) => a.x != b.x || a.y != b.y || a.z != b.z || a.w != b.w;
        [IN(LINE)] public static bool operator !=(uint4 a, uint b) => a.x != b || a.y != b || a.z != b || a.w != b;
        [IN(LINE)] public static bool operator !=(uint a, uint4 b) => a != b.x || a != b.y || a != b.z || a != b.w;
        #endregion

        #endregion

        #region Swaps

        #region Swap2
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint2 xx { [IN(LINE)] get => new uint2(x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint2 xy { [IN(LINE)] get => new uint2(x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint2 xz { [IN(LINE)] get => new uint2(x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint2 xw { [IN(LINE)] get => new uint2(x, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint2 yx { [IN(LINE)] get => new uint2(y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint2 yy { [IN(LINE)] get => new uint2(y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint2 yz { [IN(LINE)] get => new uint2(y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint2 yw { [IN(LINE)] get => new uint2(y, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint2 zx { [IN(LINE)] get => new uint2(z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint2 zy { [IN(LINE)] get => new uint2(z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint2 zz { [IN(LINE)] get => new uint2(z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint2 zw { [IN(LINE)] get => new uint2(z, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint2 wx { [IN(LINE)] get => new uint2(w, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint2 wy { [IN(LINE)] get => new uint2(w, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint2 wz { [IN(LINE)] get => new uint2(w, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint2 ww { [IN(LINE)] get => new uint2(w, w); }
        #endregion

        #region Swap3
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 xxx { [IN(LINE)] get => new uint3(x, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 xxy { [IN(LINE)] get => new uint3(x, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 xxz { [IN(LINE)] get => new uint3(x, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 xxw { [IN(LINE)] get => new uint3(x, x, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 xyx { [IN(LINE)] get => new uint3(x, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 xyy { [IN(LINE)] get => new uint3(x, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 xyz { [IN(LINE)] get => new uint3(x, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 xyw { [IN(LINE)] get => new uint3(x, y, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 xzx { [IN(LINE)] get => new uint3(x, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 xzy { [IN(LINE)] get => new uint3(x, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 xzz { [IN(LINE)] get => new uint3(x, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 xzw { [IN(LINE)] get => new uint3(x, z, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 xwx { [IN(LINE)] get => new uint3(x, w, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 xwy { [IN(LINE)] get => new uint3(x, w, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 xwz { [IN(LINE)] get => new uint3(x, w, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 xww { [IN(LINE)] get => new uint3(x, w, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 yxx { [IN(LINE)] get => new uint3(y, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 yxy { [IN(LINE)] get => new uint3(y, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 yxz { [IN(LINE)] get => new uint3(y, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 yxw { [IN(LINE)] get => new uint3(y, x, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 yyx { [IN(LINE)] get => new uint3(y, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 yyy { [IN(LINE)] get => new uint3(y, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 yyz { [IN(LINE)] get => new uint3(y, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 yyw { [IN(LINE)] get => new uint3(y, y, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 yzx { [IN(LINE)] get => new uint3(y, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 yzy { [IN(LINE)] get => new uint3(y, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 yzz { [IN(LINE)] get => new uint3(y, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 yzw { [IN(LINE)] get => new uint3(y, z, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 ywx { [IN(LINE)] get => new uint3(y, w, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 ywy { [IN(LINE)] get => new uint3(y, w, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 ywz { [IN(LINE)] get => new uint3(y, w, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 yww { [IN(LINE)] get => new uint3(y, w, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 zxx { [IN(LINE)] get => new uint3(z, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 zxy { [IN(LINE)] get => new uint3(z, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 zxz { [IN(LINE)] get => new uint3(z, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 zxw { [IN(LINE)] get => new uint3(z, x, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 zyx { [IN(LINE)] get => new uint3(z, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 zyy { [IN(LINE)] get => new uint3(z, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 zyz { [IN(LINE)] get => new uint3(z, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 zyw { [IN(LINE)] get => new uint3(z, y, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 zzx { [IN(LINE)] get => new uint3(z, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 zzy { [IN(LINE)] get => new uint3(z, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 zzz { [IN(LINE)] get => new uint3(z, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 zzw { [IN(LINE)] get => new uint3(z, z, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 zwx { [IN(LINE)] get => new uint3(z, w, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 zwy { [IN(LINE)] get => new uint3(z, w, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 zwz { [IN(LINE)] get => new uint3(z, w, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 zww { [IN(LINE)] get => new uint3(z, w, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 wxx { [IN(LINE)] get => new uint3(w, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 wxy { [IN(LINE)] get => new uint3(w, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 wxz { [IN(LINE)] get => new uint3(w, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 wxw { [IN(LINE)] get => new uint3(w, x, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 wyx { [IN(LINE)] get => new uint3(w, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 wyy { [IN(LINE)] get => new uint3(w, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 wyz { [IN(LINE)] get => new uint3(w, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 wyw { [IN(LINE)] get => new uint3(w, y, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 wzx { [IN(LINE)] get => new uint3(w, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 wzy { [IN(LINE)] get => new uint3(w, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 wzz { [IN(LINE)] get => new uint3(w, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 wzw { [IN(LINE)] get => new uint3(w, z, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 wwx { [IN(LINE)] get => new uint3(w, w, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 wwy { [IN(LINE)] get => new uint3(w, w, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 wwz { [IN(LINE)] get => new uint3(w, w, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint3 www { [IN(LINE)] get => new uint3(w, w, w); }
        #endregion

        #region Swap4
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xxxx { [IN(LINE)] get => new uint4(x, x, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xxxy { [IN(LINE)] get => new uint4(x, x, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xxxz { [IN(LINE)] get => new uint4(x, x, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xxxw { [IN(LINE)] get => new uint4(x, x, x, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xxyx { [IN(LINE)] get => new uint4(x, x, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xxyy { [IN(LINE)] get => new uint4(x, x, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xxyz { [IN(LINE)] get => new uint4(x, x, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xxyw { [IN(LINE)] get => new uint4(x, x, y, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xxzx { [IN(LINE)] get => new uint4(x, x, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xxzy { [IN(LINE)] get => new uint4(x, x, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xxzz { [IN(LINE)] get => new uint4(x, x, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xxzw { [IN(LINE)] get => new uint4(x, x, z, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xxwx { [IN(LINE)] get => new uint4(x, x, w, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xxwy { [IN(LINE)] get => new uint4(x, x, w, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xxwz { [IN(LINE)] get => new uint4(x, x, w, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xxww { [IN(LINE)] get => new uint4(x, x, w, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xyxx { [IN(LINE)] get => new uint4(x, y, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xyxy { [IN(LINE)] get => new uint4(x, y, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xyxz { [IN(LINE)] get => new uint4(x, y, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xyxw { [IN(LINE)] get => new uint4(x, y, x, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xyyx { [IN(LINE)] get => new uint4(x, y, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xyyy { [IN(LINE)] get => new uint4(x, y, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xyyz { [IN(LINE)] get => new uint4(x, y, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xyyw { [IN(LINE)] get => new uint4(x, y, y, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xyzx { [IN(LINE)] get => new uint4(x, y, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xyzy { [IN(LINE)] get => new uint4(x, y, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xyzz { [IN(LINE)] get => new uint4(x, y, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xyzw { [IN(LINE)] get => new uint4(x, y, z, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xywx { [IN(LINE)] get => new uint4(x, y, w, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xywy { [IN(LINE)] get => new uint4(x, y, w, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xywz { [IN(LINE)] get => new uint4(x, y, w, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xyww { [IN(LINE)] get => new uint4(x, y, w, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xzxx { [IN(LINE)] get => new uint4(x, z, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xzxy { [IN(LINE)] get => new uint4(x, z, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xzxz { [IN(LINE)] get => new uint4(x, z, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xzxw { [IN(LINE)] get => new uint4(x, z, x, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xzyx { [IN(LINE)] get => new uint4(x, z, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xzyy { [IN(LINE)] get => new uint4(x, z, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xzyz { [IN(LINE)] get => new uint4(x, z, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xzyw { [IN(LINE)] get => new uint4(x, z, y, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xzzx { [IN(LINE)] get => new uint4(x, z, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xzzy { [IN(LINE)] get => new uint4(x, z, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xzzz { [IN(LINE)] get => new uint4(x, z, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xzzw { [IN(LINE)] get => new uint4(x, z, z, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xzwx { [IN(LINE)] get => new uint4(x, z, w, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xzwy { [IN(LINE)] get => new uint4(x, z, w, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xzwz { [IN(LINE)] get => new uint4(x, z, w, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xzww { [IN(LINE)] get => new uint4(x, z, w, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xwxx { [IN(LINE)] get => new uint4(x, w, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xwxy { [IN(LINE)] get => new uint4(x, w, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xwxz { [IN(LINE)] get => new uint4(x, w, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xwxw { [IN(LINE)] get => new uint4(x, w, x, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xwyx { [IN(LINE)] get => new uint4(x, w, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xwyy { [IN(LINE)] get => new uint4(x, w, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xwyz { [IN(LINE)] get => new uint4(x, w, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xwyw { [IN(LINE)] get => new uint4(x, w, y, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xwzx { [IN(LINE)] get => new uint4(x, w, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xwzy { [IN(LINE)] get => new uint4(x, w, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xwzz { [IN(LINE)] get => new uint4(x, w, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xwzw { [IN(LINE)] get => new uint4(x, w, z, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xwwx { [IN(LINE)] get => new uint4(x, w, w, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xwwy { [IN(LINE)] get => new uint4(x, w, w, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xwwz { [IN(LINE)] get => new uint4(x, w, w, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 xwww { [IN(LINE)] get => new uint4(x, w, w, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yxxx { [IN(LINE)] get => new uint4(y, x, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yxxy { [IN(LINE)] get => new uint4(y, x, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yxxz { [IN(LINE)] get => new uint4(y, x, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yxxw { [IN(LINE)] get => new uint4(y, x, x, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yxyx { [IN(LINE)] get => new uint4(y, x, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yxyy { [IN(LINE)] get => new uint4(y, x, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yxyz { [IN(LINE)] get => new uint4(y, x, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yxyw { [IN(LINE)] get => new uint4(y, x, y, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yxzx { [IN(LINE)] get => new uint4(y, x, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yxzy { [IN(LINE)] get => new uint4(y, x, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yxzz { [IN(LINE)] get => new uint4(y, x, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yxzw { [IN(LINE)] get => new uint4(y, x, z, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yxwx { [IN(LINE)] get => new uint4(y, x, w, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yxwy { [IN(LINE)] get => new uint4(y, x, w, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yxwz { [IN(LINE)] get => new uint4(y, x, w, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yxww { [IN(LINE)] get => new uint4(y, x, w, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yyxx { [IN(LINE)] get => new uint4(y, y, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yyxy { [IN(LINE)] get => new uint4(y, y, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yyxz { [IN(LINE)] get => new uint4(y, y, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yyxw { [IN(LINE)] get => new uint4(y, y, x, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yyyx { [IN(LINE)] get => new uint4(y, y, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yyyy { [IN(LINE)] get => new uint4(y, y, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yyyz { [IN(LINE)] get => new uint4(y, y, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yyyw { [IN(LINE)] get => new uint4(y, y, y, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yyzx { [IN(LINE)] get => new uint4(y, y, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yyzy { [IN(LINE)] get => new uint4(y, y, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yyzz { [IN(LINE)] get => new uint4(y, y, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yyzw { [IN(LINE)] get => new uint4(y, y, z, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yywx { [IN(LINE)] get => new uint4(y, y, w, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yywy { [IN(LINE)] get => new uint4(y, y, w, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yywz { [IN(LINE)] get => new uint4(y, y, w, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yyww { [IN(LINE)] get => new uint4(y, y, w, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yzxx { [IN(LINE)] get => new uint4(y, z, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yzxy { [IN(LINE)] get => new uint4(y, z, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yzxz { [IN(LINE)] get => new uint4(y, z, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yzxw { [IN(LINE)] get => new uint4(y, z, x, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yzyx { [IN(LINE)] get => new uint4(y, z, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yzyy { [IN(LINE)] get => new uint4(y, z, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yzyz { [IN(LINE)] get => new uint4(y, z, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yzyw { [IN(LINE)] get => new uint4(y, z, y, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yzzx { [IN(LINE)] get => new uint4(y, z, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yzzy { [IN(LINE)] get => new uint4(y, z, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yzzz { [IN(LINE)] get => new uint4(y, z, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yzzw { [IN(LINE)] get => new uint4(y, z, z, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yzwx { [IN(LINE)] get => new uint4(y, z, w, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yzwy { [IN(LINE)] get => new uint4(y, z, w, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yzwz { [IN(LINE)] get => new uint4(y, z, w, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 yzww { [IN(LINE)] get => new uint4(y, z, w, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 ywxx { [IN(LINE)] get => new uint4(y, w, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 ywxy { [IN(LINE)] get => new uint4(y, w, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 ywxz { [IN(LINE)] get => new uint4(y, w, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 ywxw { [IN(LINE)] get => new uint4(y, w, x, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 ywyx { [IN(LINE)] get => new uint4(y, w, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 ywyy { [IN(LINE)] get => new uint4(y, w, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 ywyz { [IN(LINE)] get => new uint4(y, w, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 ywyw { [IN(LINE)] get => new uint4(y, w, y, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 ywzx { [IN(LINE)] get => new uint4(y, w, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 ywzy { [IN(LINE)] get => new uint4(y, w, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 ywzz { [IN(LINE)] get => new uint4(y, w, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 ywzw { [IN(LINE)] get => new uint4(y, w, z, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 ywwx { [IN(LINE)] get => new uint4(y, w, w, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 ywwy { [IN(LINE)] get => new uint4(y, w, w, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 ywwz { [IN(LINE)] get => new uint4(y, w, w, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 ywww { [IN(LINE)] get => new uint4(y, w, w, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zxxx { [IN(LINE)] get => new uint4(z, x, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zxxy { [IN(LINE)] get => new uint4(z, x, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zxxz { [IN(LINE)] get => new uint4(z, x, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zxxw { [IN(LINE)] get => new uint4(z, x, x, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zxyx { [IN(LINE)] get => new uint4(z, x, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zxyy { [IN(LINE)] get => new uint4(z, x, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zxyz { [IN(LINE)] get => new uint4(z, x, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zxyw { [IN(LINE)] get => new uint4(z, x, y, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zxzx { [IN(LINE)] get => new uint4(z, x, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zxzy { [IN(LINE)] get => new uint4(z, x, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zxzz { [IN(LINE)] get => new uint4(z, x, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zxzw { [IN(LINE)] get => new uint4(z, x, z, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zxwx { [IN(LINE)] get => new uint4(z, x, w, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zxwy { [IN(LINE)] get => new uint4(z, x, w, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zxwz { [IN(LINE)] get => new uint4(z, x, w, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zxww { [IN(LINE)] get => new uint4(z, x, w, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zyxx { [IN(LINE)] get => new uint4(z, y, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zyxy { [IN(LINE)] get => new uint4(z, y, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zyxz { [IN(LINE)] get => new uint4(z, y, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zyxw { [IN(LINE)] get => new uint4(z, y, x, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zyyx { [IN(LINE)] get => new uint4(z, y, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zyyy { [IN(LINE)] get => new uint4(z, y, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zyyz { [IN(LINE)] get => new uint4(z, y, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zyyw { [IN(LINE)] get => new uint4(z, y, y, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zyzx { [IN(LINE)] get => new uint4(z, y, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zyzy { [IN(LINE)] get => new uint4(z, y, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zyzz { [IN(LINE)] get => new uint4(z, y, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zyzw { [IN(LINE)] get => new uint4(z, y, z, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zywx { [IN(LINE)] get => new uint4(z, y, w, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zywy { [IN(LINE)] get => new uint4(z, y, w, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zywz { [IN(LINE)] get => new uint4(z, y, w, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zyww { [IN(LINE)] get => new uint4(z, y, w, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zzxx { [IN(LINE)] get => new uint4(z, z, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zzxy { [IN(LINE)] get => new uint4(z, z, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zzxz { [IN(LINE)] get => new uint4(z, z, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zzxw { [IN(LINE)] get => new uint4(z, z, x, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zzyx { [IN(LINE)] get => new uint4(z, z, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zzyy { [IN(LINE)] get => new uint4(z, z, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zzyz { [IN(LINE)] get => new uint4(z, z, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zzyw { [IN(LINE)] get => new uint4(z, z, y, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zzzx { [IN(LINE)] get => new uint4(z, z, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zzzy { [IN(LINE)] get => new uint4(z, z, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zzzz { [IN(LINE)] get => new uint4(z, z, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zzzw { [IN(LINE)] get => new uint4(z, z, z, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zzwx { [IN(LINE)] get => new uint4(z, z, w, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zzwy { [IN(LINE)] get => new uint4(z, z, w, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zzwz { [IN(LINE)] get => new uint4(z, z, w, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zzww { [IN(LINE)] get => new uint4(z, z, w, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zwxx { [IN(LINE)] get => new uint4(z, w, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zwxy { [IN(LINE)] get => new uint4(z, w, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zwxz { [IN(LINE)] get => new uint4(z, w, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zwxw { [IN(LINE)] get => new uint4(z, w, x, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zwyx { [IN(LINE)] get => new uint4(z, w, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zwyy { [IN(LINE)] get => new uint4(z, w, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zwyz { [IN(LINE)] get => new uint4(z, w, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zwyw { [IN(LINE)] get => new uint4(z, w, y, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zwzx { [IN(LINE)] get => new uint4(z, w, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zwzy { [IN(LINE)] get => new uint4(z, w, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zwzz { [IN(LINE)] get => new uint4(z, w, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zwzw { [IN(LINE)] get => new uint4(z, w, z, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zwwx { [IN(LINE)] get => new uint4(z, w, w, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zwwy { [IN(LINE)] get => new uint4(z, w, w, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zwwz { [IN(LINE)] get => new uint4(z, w, w, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 zwww { [IN(LINE)] get => new uint4(z, w, w, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wxxx { [IN(LINE)] get => new uint4(w, x, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wxxy { [IN(LINE)] get => new uint4(w, x, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wxxz { [IN(LINE)] get => new uint4(w, x, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wxxw { [IN(LINE)] get => new uint4(w, x, x, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wxyx { [IN(LINE)] get => new uint4(w, x, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wxyy { [IN(LINE)] get => new uint4(w, x, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wxyz { [IN(LINE)] get => new uint4(w, x, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wxyw { [IN(LINE)] get => new uint4(w, x, y, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wxzx { [IN(LINE)] get => new uint4(w, x, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wxzy { [IN(LINE)] get => new uint4(w, x, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wxzz { [IN(LINE)] get => new uint4(w, x, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wxzw { [IN(LINE)] get => new uint4(w, x, z, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wxwx { [IN(LINE)] get => new uint4(w, x, w, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wxwy { [IN(LINE)] get => new uint4(w, x, w, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wxwz { [IN(LINE)] get => new uint4(w, x, w, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wxww { [IN(LINE)] get => new uint4(w, x, w, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wyxx { [IN(LINE)] get => new uint4(w, y, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wyxy { [IN(LINE)] get => new uint4(w, y, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wyxz { [IN(LINE)] get => new uint4(w, y, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wyxw { [IN(LINE)] get => new uint4(w, y, x, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wyyx { [IN(LINE)] get => new uint4(w, y, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wyyy { [IN(LINE)] get => new uint4(w, y, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wyyz { [IN(LINE)] get => new uint4(w, y, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wyyw { [IN(LINE)] get => new uint4(w, y, y, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wyzx { [IN(LINE)] get => new uint4(w, y, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wyzy { [IN(LINE)] get => new uint4(w, y, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wyzz { [IN(LINE)] get => new uint4(w, y, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wyzw { [IN(LINE)] get => new uint4(w, y, z, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wywx { [IN(LINE)] get => new uint4(w, y, w, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wywy { [IN(LINE)] get => new uint4(w, y, w, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wywz { [IN(LINE)] get => new uint4(w, y, w, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wyww { [IN(LINE)] get => new uint4(w, y, w, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wzxx { [IN(LINE)] get => new uint4(w, z, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wzxy { [IN(LINE)] get => new uint4(w, z, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wzxz { [IN(LINE)] get => new uint4(w, z, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wzxw { [IN(LINE)] get => new uint4(w, z, x, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wzyx { [IN(LINE)] get => new uint4(w, z, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wzyy { [IN(LINE)] get => new uint4(w, z, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wzyz { [IN(LINE)] get => new uint4(w, z, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wzyw { [IN(LINE)] get => new uint4(w, z, y, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wzzx { [IN(LINE)] get => new uint4(w, z, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wzzy { [IN(LINE)] get => new uint4(w, z, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wzzz { [IN(LINE)] get => new uint4(w, z, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wzzw { [IN(LINE)] get => new uint4(w, z, z, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wzwx { [IN(LINE)] get => new uint4(w, z, w, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wzwy { [IN(LINE)] get => new uint4(w, z, w, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wzwz { [IN(LINE)] get => new uint4(w, z, w, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wzww { [IN(LINE)] get => new uint4(w, z, w, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wwxx { [IN(LINE)] get => new uint4(w, w, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wwxy { [IN(LINE)] get => new uint4(w, w, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wwxz { [IN(LINE)] get => new uint4(w, w, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wwxw { [IN(LINE)] get => new uint4(w, w, x, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wwyx { [IN(LINE)] get => new uint4(w, w, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wwyy { [IN(LINE)] get => new uint4(w, w, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wwyz { [IN(LINE)] get => new uint4(w, w, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wwyw { [IN(LINE)] get => new uint4(w, w, y, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wwzx { [IN(LINE)] get => new uint4(w, w, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wwzy { [IN(LINE)] get => new uint4(w, w, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wwzz { [IN(LINE)] get => new uint4(w, w, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wwzw { [IN(LINE)] get => new uint4(w, w, z, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wwwx { [IN(LINE)] get => new uint4(w, w, w, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wwwy { [IN(LINE)] get => new uint4(w, w, w, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wwwz { [IN(LINE)] get => new uint4(w, w, w, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public uint4 wwww { [IN(LINE)] get => new uint4(w, w, w, w); }
        #endregion

        #endregion


        #region Other 
        [IN(LINE)] public override int GetHashCode() => math.hash(this);
        [IN(LINE)] public override bool Equals(object o) => o is uint4 target && Equals(target); 
        [IN(LINE)] public bool Equals(uint4 a) => x == a.x && y == a.y && z == a.z && w == a.w; 
        [IN(LINE)] public override string ToString() => $"uint4({x}, {y}, {z}, {w})";
        [IN(LINE)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"uint4({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)}, {w.ToString(format, formatProvider)})";
        }

        internal class DebuggerProxy
        {
            public uint x, y, z, w;
            public DebuggerProxy(uint4 v) { x = v.x; y = v.y; z = v.z; w = v.w; }
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
            [IN(LINE)]
            public Enumerator(in uint4 value)
            {
                fixed (uint4* array = &value)
                {
                    _pointer = (uint*)array;
                    _index = -1;
                }
            }
            public uint Current { [IN(LINE)] get => _pointer[_index]; }
            [IN(LINE)] public void Dispose() { }
            [IN(LINE)] public bool MoveNext() => ++_index < LENGTH;
            [IN(LINE)] public void Reset() { }
        }
        #endregion
    }
}
