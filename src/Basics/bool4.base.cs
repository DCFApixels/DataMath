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
    [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 4)]
    public partial struct bool4 : 
        IEquatable<bool4>, 
        IVector4<bool>, 
        IBoolVector,
        IColor,
        IEnumerableVector<bool, bool4>
    {
        #region Consts
        public const int LENGTH = 4;

        ///<summary>(0, 0, 0, 0)</summary>
        public static readonly bool4 zero = new bool4(0, 0, 0, 0);
        ///<summary>(1, 1, 1, 1)</summary>
        public static readonly bool4 one = new bool4(1, 1, 1, 1);

        ///<summary>(-1, 0, 0, 0)</summary>
        public static readonly bool4 left = new bool4(-1, 0, 0, 0);
        ///<summary>(1, 0, 0, 0)</summary>
        public static readonly bool4 right = new bool4(1, 0, 0, 0);
        ///<summary>(0, -1, 0, 0)</summary>
        public static readonly bool4 down = new bool4(0, -1, 0, 0);
        ///<summary>(0, 1, 0, 0)</summary>
        public static readonly bool4 up = new bool4(0, 1, 0, 0);
        ///<summary>(0, 0, -1, 0)</summary>
        public static readonly bool4 back = new bool4(0, 0, -1, 0);
        ///<summary>(0, 0, 1, 0)</summary>
        public static readonly bool4 forward = new bool4(0, 0, 1, 0);
        ///<summary>(0, 0, 0, -1)</summary>
        public static readonly bool4 before = new bool4(0, 0, 0, -1);
        ///<summary>(0, 0, 0, 1)</summary>
        public static readonly bool4 after = new bool4(0, 0, 0, 1);
        #endregion

        public bool x;
        public bool y;
        public bool z;
        public bool w;

        #region IBoolVector
        public bool all { [IN(LINE)] get => x & y & z & w; [IN(LINE)] set { x = value; y = value; z = value; w = value; } }
        public bool any { [IN(LINE)] get => x | y | z | w; }
        #endregion

        #region IColor
        public float r { [IN(LINE)] get => x ? 1f : 0f; [IN(LINE)] set => x = value > 0f; }
        public float g { [IN(LINE)] get => y ? 1f : 0f; [IN(LINE)] set => y = value > 0f; }
        public float b { [IN(LINE)] get => z ? 1f : 0f; [IN(LINE)] set => z = value > 0f; }
        public float a { [IN(LINE)] get => w ? 1f : 0f; [IN(LINE)] set => w = value > 0f; }
        #endregion

        #region IVectorN
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool IVector1<bool>.x { [IN(LINE)] get => x; [IN(LINE)] set => x = value; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool IVector2<bool>.y { [IN(LINE)] get => y; [IN(LINE)] set => y = value; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool IVector3<bool>.z { [IN(LINE)] get => z; [IN(LINE)] set => z = value; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool IVector4<bool>.w { [IN(LINE)] get => w; [IN(LINE)] set => w = value; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int length { [IN(LINE)] get => LENGTH; }

        public unsafe bool this[int index]
        {
            get
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > LENGTH) throw new IndexOutOfRangeException($"Index must be between[0..{(LENGTH - 1)}].");
#endif
                fixed (bool4* array = &this) { return ((bool*)array)[index]; }
            }
            set
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > LENGTH) throw new IndexOutOfRangeException($"Index must be between[0..{(LENGTH - 1)}].");
#endif
                fixed (bool* array = &x) { array[index] = value; }
            }
        }
        #endregion

        #region Constructors
        [IN(LINE)]
        public bool4(bool x, bool y, bool z, bool w)
        {
            this.x = x; this.y = y;
            this.z = z; this.w = w;
        }
        [IN(LINE)]
        public bool4(bool v)
        {
            x = v; y = v;
            z = v; w = v;
        }
        [IN(LINE)]
        public bool4(bool4 v)
        {
            x = v.x; y = v.y;
            z = v.z; w = v.w;
        }
        [IN(LINE)]
        public bool4(float x, float y, float z, float w)
        {
            this.x = x > 0f; this.y = y > 0f;
            this.z = z > 0f; this.w = w > 0f;
        }
        [IN(LINE)]
        public bool4(float v)
        {
            x = v > 0f; y = v > 0f;
            z = v > 0f; w = v > 0f;
        }
        [IN(LINE)]
        public bool4(float4 v)
        {
            x = v.x > 0f; y = v.y > 0f;
            z = v.z > 0f; w = v.w > 0f;
        }
        [IN(LINE)]
        public bool4(double x, double y, double z, double w)
        {
            this.x = x > 0d; this.y = y > 0d;
            this.z = z > 0d; this.w = w > 0d;
        }
        [IN(LINE)]
        public bool4(double v)
        {
            x = v > 0d; y = v > 0d;
            z = v > 0d; w = v > 0d;
        }
        [IN(LINE)]
        public bool4(double4 v)
        {
            x = v.x > 0d; y = v.y > 0d;
            z = v.z > 0d; w = v.w > 0d;
        }
        [IN(LINE)]
        public bool4(int x, int y, int z, int w)
        {
            this.x = x > 0; this.y = y > 0;
            this.z = z > 0; this.w = w > 0;
        }
        [IN(LINE)]
        public bool4(int v)
        {
            x = v > 0; y = v > 0;
            z = v > 0; w = v > 0;
        }
        [IN(LINE)]
        public bool4(int4 v)
        {
            x = v.x > 0; y = v.y > 0;
            z = v.z > 0; w = v.w > 0;
        }
        [IN(LINE)]
        public bool4(uint x, uint y, uint z, uint w)
        {
            this.x = x > 0; this.y = y > 0;
            this.z = z > 0; this.w = w > 0;
        }
        [IN(LINE)]
        public bool4(uint v)
        {
            x = v > 0; y = v > 0;
            z = v > 0; w = v > 0;
        }
        [IN(LINE)]
        public bool4(uint4 v)
        {
            x = v.x > 0; y = v.y > 0;
            z = v.z > 0; w = v.w > 0;
        }
        #endregion

        #region operators

        #region Bits
        [IN(LINE)] public static bool4 operator !(bool4 a) => new bool4(!a.x, !a.y, !a.z, !a.w);

        [IN(LINE)] public static bool4 operator |(bool4 a, bool4 b) => new bool4(a.x | b.x, a.y | b.y, a.z | b.z, a.w | b.w);
        [IN(LINE)] public static bool4 operator |(bool4 a, bool b) => new bool4(a.x | b, a.y | b, a.z | b, a.w | b);
        [IN(LINE)] public static bool4 operator |(bool a, bool4 b) => new bool4(a | b.x, a | b.y, a | b.z, a | b.w);

        [IN(LINE)] public static bool4 operator &(bool4 a, bool4 b) => new bool4(a.x & b.x, a.y & b.y, a.z & b.z, a.w & b.w);
        [IN(LINE)] public static bool4 operator &(bool4 a, bool b) => new bool4(a.x & b, a.y & b, a.z & b, a.w & b);
        [IN(LINE)] public static bool4 operator &(bool a, bool4 b) => new bool4(a & b.x, a & b.y, a & b.z, a & b.w);

        [IN(LINE)] public static bool4 operator ^(bool4 a, bool4 b) => new bool4(a.x ^ b.x, a.y ^ b.y, a.z ^ b.z, a.w ^ b.w);
        [IN(LINE)] public static bool4 operator ^(bool4 a, bool b) => new bool4(a.x ^ b, a.y ^ b, a.z ^ b, a.w ^ b);
        [IN(LINE)] public static bool4 operator ^(bool a, bool4 b) => new bool4(a ^ b.x, a ^ b.y, a ^ b.z, a ^ b.w);
        #endregion

        #region Boolean
        [IN(LINE)] public static bool operator ==(bool4 a, bool4 b) => a.x == b.x && a.y == b.y && a.z == b.z && a.w == b.w;
        [IN(LINE)] public static bool operator ==(bool4 a, bool b) => a.x == b && a.y == b && a.z == b && a.w == b;
        [IN(LINE)] public static bool operator ==(bool a, bool4 b) => a == b.x && a == b.y && a == b.z && a == b.w;

        [IN(LINE)] public static bool operator !=(bool4 a, bool4 b) => a.x != b.x || a.y != b.y || a.z != b.z || a.w != b.w;
        [IN(LINE)] public static bool operator !=(bool4 a, bool b) => a.x != b || a.y != b || a.z != b || a.w != b;
        [IN(LINE)] public static bool operator !=(bool a, bool4 b) => a != b.x || a != b.y || a != b.z || a != b.w;
        #endregion

        #endregion

        #region Swaps

        #region Swap2
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool2 xx { [IN(LINE)] get => new bool2(x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool2 xy { [IN(LINE)] get => new bool2(x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool2 xz { [IN(LINE)] get => new bool2(x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool2 xw { [IN(LINE)] get => new bool2(x, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool2 yx { [IN(LINE)] get => new bool2(y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool2 yy { [IN(LINE)] get => new bool2(y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool2 yz { [IN(LINE)] get => new bool2(y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool2 yw { [IN(LINE)] get => new bool2(y, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool2 zx { [IN(LINE)] get => new bool2(z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool2 zy { [IN(LINE)] get => new bool2(z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool2 zz { [IN(LINE)] get => new bool2(z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool2 zw { [IN(LINE)] get => new bool2(z, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool2 wx { [IN(LINE)] get => new bool2(w, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool2 wy { [IN(LINE)] get => new bool2(w, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool2 wz { [IN(LINE)] get => new bool2(w, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool2 ww { [IN(LINE)] get => new bool2(w, w); }
        #endregion

        #region Swap3
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 xxx { [IN(LINE)] get => new bool3(x, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 xxy { [IN(LINE)] get => new bool3(x, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 xxz { [IN(LINE)] get => new bool3(x, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 xxw { [IN(LINE)] get => new bool3(x, x, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 xyx { [IN(LINE)] get => new bool3(x, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 xyy { [IN(LINE)] get => new bool3(x, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 xyz { [IN(LINE)] get => new bool3(x, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 xyw { [IN(LINE)] get => new bool3(x, y, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 xzx { [IN(LINE)] get => new bool3(x, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 xzy { [IN(LINE)] get => new bool3(x, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 xzz { [IN(LINE)] get => new bool3(x, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 xzw { [IN(LINE)] get => new bool3(x, z, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 xwx { [IN(LINE)] get => new bool3(x, w, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 xwy { [IN(LINE)] get => new bool3(x, w, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 xwz { [IN(LINE)] get => new bool3(x, w, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 xww { [IN(LINE)] get => new bool3(x, w, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 yxx { [IN(LINE)] get => new bool3(y, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 yxy { [IN(LINE)] get => new bool3(y, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 yxz { [IN(LINE)] get => new bool3(y, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 yxw { [IN(LINE)] get => new bool3(y, x, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 yyx { [IN(LINE)] get => new bool3(y, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 yyy { [IN(LINE)] get => new bool3(y, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 yyz { [IN(LINE)] get => new bool3(y, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 yyw { [IN(LINE)] get => new bool3(y, y, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 yzx { [IN(LINE)] get => new bool3(y, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 yzy { [IN(LINE)] get => new bool3(y, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 yzz { [IN(LINE)] get => new bool3(y, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 yzw { [IN(LINE)] get => new bool3(y, z, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 ywx { [IN(LINE)] get => new bool3(y, w, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 ywy { [IN(LINE)] get => new bool3(y, w, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 ywz { [IN(LINE)] get => new bool3(y, w, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 yww { [IN(LINE)] get => new bool3(y, w, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 zxx { [IN(LINE)] get => new bool3(z, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 zxy { [IN(LINE)] get => new bool3(z, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 zxz { [IN(LINE)] get => new bool3(z, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 zxw { [IN(LINE)] get => new bool3(z, x, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 zyx { [IN(LINE)] get => new bool3(z, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 zyy { [IN(LINE)] get => new bool3(z, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 zyz { [IN(LINE)] get => new bool3(z, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 zyw { [IN(LINE)] get => new bool3(z, y, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 zzx { [IN(LINE)] get => new bool3(z, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 zzy { [IN(LINE)] get => new bool3(z, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 zzz { [IN(LINE)] get => new bool3(z, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 zzw { [IN(LINE)] get => new bool3(z, z, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 zwx { [IN(LINE)] get => new bool3(z, w, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 zwy { [IN(LINE)] get => new bool3(z, w, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 zwz { [IN(LINE)] get => new bool3(z, w, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 zww { [IN(LINE)] get => new bool3(z, w, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 wxx { [IN(LINE)] get => new bool3(w, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 wxy { [IN(LINE)] get => new bool3(w, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 wxz { [IN(LINE)] get => new bool3(w, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 wxw { [IN(LINE)] get => new bool3(w, x, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 wyx { [IN(LINE)] get => new bool3(w, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 wyy { [IN(LINE)] get => new bool3(w, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 wyz { [IN(LINE)] get => new bool3(w, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 wyw { [IN(LINE)] get => new bool3(w, y, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 wzx { [IN(LINE)] get => new bool3(w, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 wzy { [IN(LINE)] get => new bool3(w, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 wzz { [IN(LINE)] get => new bool3(w, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 wzw { [IN(LINE)] get => new bool3(w, z, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 wwx { [IN(LINE)] get => new bool3(w, w, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 wwy { [IN(LINE)] get => new bool3(w, w, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 wwz { [IN(LINE)] get => new bool3(w, w, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool3 www { [IN(LINE)] get => new bool3(w, w, w); }
        #endregion

        #region Swap4
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xxxx { [IN(LINE)] get => new bool4(x, x, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xxxy { [IN(LINE)] get => new bool4(x, x, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xxxz { [IN(LINE)] get => new bool4(x, x, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xxxw { [IN(LINE)] get => new bool4(x, x, x, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xxyx { [IN(LINE)] get => new bool4(x, x, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xxyy { [IN(LINE)] get => new bool4(x, x, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xxyz { [IN(LINE)] get => new bool4(x, x, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xxyw { [IN(LINE)] get => new bool4(x, x, y, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xxzx { [IN(LINE)] get => new bool4(x, x, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xxzy { [IN(LINE)] get => new bool4(x, x, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xxzz { [IN(LINE)] get => new bool4(x, x, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xxzw { [IN(LINE)] get => new bool4(x, x, z, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xxwx { [IN(LINE)] get => new bool4(x, x, w, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xxwy { [IN(LINE)] get => new bool4(x, x, w, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xxwz { [IN(LINE)] get => new bool4(x, x, w, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xxww { [IN(LINE)] get => new bool4(x, x, w, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xyxx { [IN(LINE)] get => new bool4(x, y, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xyxy { [IN(LINE)] get => new bool4(x, y, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xyxz { [IN(LINE)] get => new bool4(x, y, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xyxw { [IN(LINE)] get => new bool4(x, y, x, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xyyx { [IN(LINE)] get => new bool4(x, y, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xyyy { [IN(LINE)] get => new bool4(x, y, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xyyz { [IN(LINE)] get => new bool4(x, y, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xyyw { [IN(LINE)] get => new bool4(x, y, y, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xyzx { [IN(LINE)] get => new bool4(x, y, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xyzy { [IN(LINE)] get => new bool4(x, y, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xyzz { [IN(LINE)] get => new bool4(x, y, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xyzw { [IN(LINE)] get => new bool4(x, y, z, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xywx { [IN(LINE)] get => new bool4(x, y, w, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xywy { [IN(LINE)] get => new bool4(x, y, w, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xywz { [IN(LINE)] get => new bool4(x, y, w, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xyww { [IN(LINE)] get => new bool4(x, y, w, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xzxx { [IN(LINE)] get => new bool4(x, z, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xzxy { [IN(LINE)] get => new bool4(x, z, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xzxz { [IN(LINE)] get => new bool4(x, z, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xzxw { [IN(LINE)] get => new bool4(x, z, x, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xzyx { [IN(LINE)] get => new bool4(x, z, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xzyy { [IN(LINE)] get => new bool4(x, z, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xzyz { [IN(LINE)] get => new bool4(x, z, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xzyw { [IN(LINE)] get => new bool4(x, z, y, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xzzx { [IN(LINE)] get => new bool4(x, z, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xzzy { [IN(LINE)] get => new bool4(x, z, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xzzz { [IN(LINE)] get => new bool4(x, z, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xzzw { [IN(LINE)] get => new bool4(x, z, z, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xzwx { [IN(LINE)] get => new bool4(x, z, w, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xzwy { [IN(LINE)] get => new bool4(x, z, w, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xzwz { [IN(LINE)] get => new bool4(x, z, w, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xzww { [IN(LINE)] get => new bool4(x, z, w, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xwxx { [IN(LINE)] get => new bool4(x, w, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xwxy { [IN(LINE)] get => new bool4(x, w, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xwxz { [IN(LINE)] get => new bool4(x, w, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xwxw { [IN(LINE)] get => new bool4(x, w, x, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xwyx { [IN(LINE)] get => new bool4(x, w, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xwyy { [IN(LINE)] get => new bool4(x, w, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xwyz { [IN(LINE)] get => new bool4(x, w, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xwyw { [IN(LINE)] get => new bool4(x, w, y, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xwzx { [IN(LINE)] get => new bool4(x, w, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xwzy { [IN(LINE)] get => new bool4(x, w, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xwzz { [IN(LINE)] get => new bool4(x, w, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xwzw { [IN(LINE)] get => new bool4(x, w, z, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xwwx { [IN(LINE)] get => new bool4(x, w, w, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xwwy { [IN(LINE)] get => new bool4(x, w, w, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xwwz { [IN(LINE)] get => new bool4(x, w, w, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 xwww { [IN(LINE)] get => new bool4(x, w, w, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yxxx { [IN(LINE)] get => new bool4(y, x, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yxxy { [IN(LINE)] get => new bool4(y, x, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yxxz { [IN(LINE)] get => new bool4(y, x, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yxxw { [IN(LINE)] get => new bool4(y, x, x, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yxyx { [IN(LINE)] get => new bool4(y, x, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yxyy { [IN(LINE)] get => new bool4(y, x, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yxyz { [IN(LINE)] get => new bool4(y, x, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yxyw { [IN(LINE)] get => new bool4(y, x, y, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yxzx { [IN(LINE)] get => new bool4(y, x, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yxzy { [IN(LINE)] get => new bool4(y, x, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yxzz { [IN(LINE)] get => new bool4(y, x, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yxzw { [IN(LINE)] get => new bool4(y, x, z, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yxwx { [IN(LINE)] get => new bool4(y, x, w, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yxwy { [IN(LINE)] get => new bool4(y, x, w, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yxwz { [IN(LINE)] get => new bool4(y, x, w, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yxww { [IN(LINE)] get => new bool4(y, x, w, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yyxx { [IN(LINE)] get => new bool4(y, y, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yyxy { [IN(LINE)] get => new bool4(y, y, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yyxz { [IN(LINE)] get => new bool4(y, y, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yyxw { [IN(LINE)] get => new bool4(y, y, x, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yyyx { [IN(LINE)] get => new bool4(y, y, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yyyy { [IN(LINE)] get => new bool4(y, y, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yyyz { [IN(LINE)] get => new bool4(y, y, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yyyw { [IN(LINE)] get => new bool4(y, y, y, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yyzx { [IN(LINE)] get => new bool4(y, y, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yyzy { [IN(LINE)] get => new bool4(y, y, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yyzz { [IN(LINE)] get => new bool4(y, y, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yyzw { [IN(LINE)] get => new bool4(y, y, z, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yywx { [IN(LINE)] get => new bool4(y, y, w, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yywy { [IN(LINE)] get => new bool4(y, y, w, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yywz { [IN(LINE)] get => new bool4(y, y, w, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yyww { [IN(LINE)] get => new bool4(y, y, w, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yzxx { [IN(LINE)] get => new bool4(y, z, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yzxy { [IN(LINE)] get => new bool4(y, z, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yzxz { [IN(LINE)] get => new bool4(y, z, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yzxw { [IN(LINE)] get => new bool4(y, z, x, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yzyx { [IN(LINE)] get => new bool4(y, z, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yzyy { [IN(LINE)] get => new bool4(y, z, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yzyz { [IN(LINE)] get => new bool4(y, z, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yzyw { [IN(LINE)] get => new bool4(y, z, y, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yzzx { [IN(LINE)] get => new bool4(y, z, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yzzy { [IN(LINE)] get => new bool4(y, z, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yzzz { [IN(LINE)] get => new bool4(y, z, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yzzw { [IN(LINE)] get => new bool4(y, z, z, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yzwx { [IN(LINE)] get => new bool4(y, z, w, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yzwy { [IN(LINE)] get => new bool4(y, z, w, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yzwz { [IN(LINE)] get => new bool4(y, z, w, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 yzww { [IN(LINE)] get => new bool4(y, z, w, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 ywxx { [IN(LINE)] get => new bool4(y, w, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 ywxy { [IN(LINE)] get => new bool4(y, w, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 ywxz { [IN(LINE)] get => new bool4(y, w, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 ywxw { [IN(LINE)] get => new bool4(y, w, x, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 ywyx { [IN(LINE)] get => new bool4(y, w, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 ywyy { [IN(LINE)] get => new bool4(y, w, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 ywyz { [IN(LINE)] get => new bool4(y, w, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 ywyw { [IN(LINE)] get => new bool4(y, w, y, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 ywzx { [IN(LINE)] get => new bool4(y, w, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 ywzy { [IN(LINE)] get => new bool4(y, w, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 ywzz { [IN(LINE)] get => new bool4(y, w, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 ywzw { [IN(LINE)] get => new bool4(y, w, z, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 ywwx { [IN(LINE)] get => new bool4(y, w, w, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 ywwy { [IN(LINE)] get => new bool4(y, w, w, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 ywwz { [IN(LINE)] get => new bool4(y, w, w, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 ywww { [IN(LINE)] get => new bool4(y, w, w, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zxxx { [IN(LINE)] get => new bool4(z, x, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zxxy { [IN(LINE)] get => new bool4(z, x, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zxxz { [IN(LINE)] get => new bool4(z, x, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zxxw { [IN(LINE)] get => new bool4(z, x, x, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zxyx { [IN(LINE)] get => new bool4(z, x, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zxyy { [IN(LINE)] get => new bool4(z, x, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zxyz { [IN(LINE)] get => new bool4(z, x, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zxyw { [IN(LINE)] get => new bool4(z, x, y, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zxzx { [IN(LINE)] get => new bool4(z, x, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zxzy { [IN(LINE)] get => new bool4(z, x, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zxzz { [IN(LINE)] get => new bool4(z, x, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zxzw { [IN(LINE)] get => new bool4(z, x, z, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zxwx { [IN(LINE)] get => new bool4(z, x, w, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zxwy { [IN(LINE)] get => new bool4(z, x, w, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zxwz { [IN(LINE)] get => new bool4(z, x, w, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zxww { [IN(LINE)] get => new bool4(z, x, w, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zyxx { [IN(LINE)] get => new bool4(z, y, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zyxy { [IN(LINE)] get => new bool4(z, y, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zyxz { [IN(LINE)] get => new bool4(z, y, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zyxw { [IN(LINE)] get => new bool4(z, y, x, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zyyx { [IN(LINE)] get => new bool4(z, y, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zyyy { [IN(LINE)] get => new bool4(z, y, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zyyz { [IN(LINE)] get => new bool4(z, y, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zyyw { [IN(LINE)] get => new bool4(z, y, y, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zyzx { [IN(LINE)] get => new bool4(z, y, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zyzy { [IN(LINE)] get => new bool4(z, y, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zyzz { [IN(LINE)] get => new bool4(z, y, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zyzw { [IN(LINE)] get => new bool4(z, y, z, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zywx { [IN(LINE)] get => new bool4(z, y, w, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zywy { [IN(LINE)] get => new bool4(z, y, w, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zywz { [IN(LINE)] get => new bool4(z, y, w, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zyww { [IN(LINE)] get => new bool4(z, y, w, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zzxx { [IN(LINE)] get => new bool4(z, z, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zzxy { [IN(LINE)] get => new bool4(z, z, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zzxz { [IN(LINE)] get => new bool4(z, z, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zzxw { [IN(LINE)] get => new bool4(z, z, x, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zzyx { [IN(LINE)] get => new bool4(z, z, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zzyy { [IN(LINE)] get => new bool4(z, z, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zzyz { [IN(LINE)] get => new bool4(z, z, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zzyw { [IN(LINE)] get => new bool4(z, z, y, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zzzx { [IN(LINE)] get => new bool4(z, z, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zzzy { [IN(LINE)] get => new bool4(z, z, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zzzz { [IN(LINE)] get => new bool4(z, z, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zzzw { [IN(LINE)] get => new bool4(z, z, z, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zzwx { [IN(LINE)] get => new bool4(z, z, w, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zzwy { [IN(LINE)] get => new bool4(z, z, w, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zzwz { [IN(LINE)] get => new bool4(z, z, w, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zzww { [IN(LINE)] get => new bool4(z, z, w, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zwxx { [IN(LINE)] get => new bool4(z, w, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zwxy { [IN(LINE)] get => new bool4(z, w, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zwxz { [IN(LINE)] get => new bool4(z, w, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zwxw { [IN(LINE)] get => new bool4(z, w, x, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zwyx { [IN(LINE)] get => new bool4(z, w, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zwyy { [IN(LINE)] get => new bool4(z, w, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zwyz { [IN(LINE)] get => new bool4(z, w, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zwyw { [IN(LINE)] get => new bool4(z, w, y, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zwzx { [IN(LINE)] get => new bool4(z, w, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zwzy { [IN(LINE)] get => new bool4(z, w, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zwzz { [IN(LINE)] get => new bool4(z, w, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zwzw { [IN(LINE)] get => new bool4(z, w, z, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zwwx { [IN(LINE)] get => new bool4(z, w, w, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zwwy { [IN(LINE)] get => new bool4(z, w, w, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zwwz { [IN(LINE)] get => new bool4(z, w, w, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 zwww { [IN(LINE)] get => new bool4(z, w, w, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wxxx { [IN(LINE)] get => new bool4(w, x, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wxxy { [IN(LINE)] get => new bool4(w, x, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wxxz { [IN(LINE)] get => new bool4(w, x, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wxxw { [IN(LINE)] get => new bool4(w, x, x, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wxyx { [IN(LINE)] get => new bool4(w, x, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wxyy { [IN(LINE)] get => new bool4(w, x, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wxyz { [IN(LINE)] get => new bool4(w, x, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wxyw { [IN(LINE)] get => new bool4(w, x, y, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wxzx { [IN(LINE)] get => new bool4(w, x, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wxzy { [IN(LINE)] get => new bool4(w, x, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wxzz { [IN(LINE)] get => new bool4(w, x, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wxzw { [IN(LINE)] get => new bool4(w, x, z, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wxwx { [IN(LINE)] get => new bool4(w, x, w, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wxwy { [IN(LINE)] get => new bool4(w, x, w, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wxwz { [IN(LINE)] get => new bool4(w, x, w, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wxww { [IN(LINE)] get => new bool4(w, x, w, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wyxx { [IN(LINE)] get => new bool4(w, y, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wyxy { [IN(LINE)] get => new bool4(w, y, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wyxz { [IN(LINE)] get => new bool4(w, y, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wyxw { [IN(LINE)] get => new bool4(w, y, x, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wyyx { [IN(LINE)] get => new bool4(w, y, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wyyy { [IN(LINE)] get => new bool4(w, y, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wyyz { [IN(LINE)] get => new bool4(w, y, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wyyw { [IN(LINE)] get => new bool4(w, y, y, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wyzx { [IN(LINE)] get => new bool4(w, y, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wyzy { [IN(LINE)] get => new bool4(w, y, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wyzz { [IN(LINE)] get => new bool4(w, y, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wyzw { [IN(LINE)] get => new bool4(w, y, z, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wywx { [IN(LINE)] get => new bool4(w, y, w, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wywy { [IN(LINE)] get => new bool4(w, y, w, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wywz { [IN(LINE)] get => new bool4(w, y, w, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wyww { [IN(LINE)] get => new bool4(w, y, w, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wzxx { [IN(LINE)] get => new bool4(w, z, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wzxy { [IN(LINE)] get => new bool4(w, z, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wzxz { [IN(LINE)] get => new bool4(w, z, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wzxw { [IN(LINE)] get => new bool4(w, z, x, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wzyx { [IN(LINE)] get => new bool4(w, z, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wzyy { [IN(LINE)] get => new bool4(w, z, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wzyz { [IN(LINE)] get => new bool4(w, z, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wzyw { [IN(LINE)] get => new bool4(w, z, y, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wzzx { [IN(LINE)] get => new bool4(w, z, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wzzy { [IN(LINE)] get => new bool4(w, z, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wzzz { [IN(LINE)] get => new bool4(w, z, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wzzw { [IN(LINE)] get => new bool4(w, z, z, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wzwx { [IN(LINE)] get => new bool4(w, z, w, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wzwy { [IN(LINE)] get => new bool4(w, z, w, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wzwz { [IN(LINE)] get => new bool4(w, z, w, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wzww { [IN(LINE)] get => new bool4(w, z, w, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wwxx { [IN(LINE)] get => new bool4(w, w, x, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wwxy { [IN(LINE)] get => new bool4(w, w, x, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wwxz { [IN(LINE)] get => new bool4(w, w, x, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wwxw { [IN(LINE)] get => new bool4(w, w, x, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wwyx { [IN(LINE)] get => new bool4(w, w, y, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wwyy { [IN(LINE)] get => new bool4(w, w, y, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wwyz { [IN(LINE)] get => new bool4(w, w, y, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wwyw { [IN(LINE)] get => new bool4(w, w, y, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wwzx { [IN(LINE)] get => new bool4(w, w, z, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wwzy { [IN(LINE)] get => new bool4(w, w, z, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wwzz { [IN(LINE)] get => new bool4(w, w, z, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wwzw { [IN(LINE)] get => new bool4(w, w, z, w); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wwwx { [IN(LINE)] get => new bool4(w, w, w, x); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wwwy { [IN(LINE)] get => new bool4(w, w, w, y); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wwwz { [IN(LINE)] get => new bool4(w, w, w, z); }
         [EditorBrowsable(EditorBrowsableState.Never)]
         public bool4 wwww { [IN(LINE)] get => new bool4(w, w, w, w); }
        #endregion

        #endregion


        #region Other 
        [IN(LINE)] public override int GetHashCode() => math.Hash(this);
        public override bool Equals(object o) => o is bool4 target && Equals(target); 
        [IN(LINE)] public bool Equals(bool4 a) => x == a.x && y == a.y && z == a.z && w == a.w; 
        public override string ToString() => $"bool4({x}, {y}, {z}, {w})";

        internal class DebuggerProxy
        {
            public bool x, y, z, w;
            public DebuggerProxy(bool4 v) { x = v.x; y = v.y; z = v.z; w = v.w; }
        }
        #endregion

        #region Enumerator
        VectorEnumerator<bool, bool4> IEnumerableVector<bool, bool4>.GetEnumerator() => new VectorEnumerator<bool, bool4>(this);
        IEnumerator<bool> IEnumerable<bool>.GetEnumerator() => new VectorEnumerator<bool, bool4>(this);
        IEnumerator IEnumerable.GetEnumerator() => new VectorEnumerator<bool, bool4>(this);
        public Enumerator GetEnumerator() => new Enumerator(this);
        public unsafe ref struct Enumerator
        {
            private readonly bool* _pointer;
            private sbyte _index;
            [IN(LINE)]
            public Enumerator(in bool4 value)
            {
                fixed (bool4* array = &value)
                {
                    _pointer = (bool*)array;
                    _index = -1;
                }
            }
            public bool Current { [IN(LINE)] get => _pointer[_index]; }
            [IN(LINE)] public void Dispose() { }
            [IN(LINE)] public bool MoveNext() => ++_index < LENGTH;
            [IN(LINE)] public void Reset() { }
        }
        #endregion
    }
}
