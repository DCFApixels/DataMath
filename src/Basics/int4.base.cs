#pragma warning disable CS8981
#if DISABLE_DEBUG
#undef DEBUG
#endif
#if ENABLE_IL2CPP
using Unity.IL2CPP.CompilerServices;
#endif
using DCFApixels.DataMath.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
#if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
#endif
    [DebuggerTypeProxy(typeof(DebuggerProxy))]
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 4, Size = 16)]
    public unsafe partial struct int4 :
        IEquatable<int4>,
        IFormattable,
        IVector4Impl<int>,
        IColor,
        IEnumerableVector<int, int4>
    {
        #region Consts
        public const int Count = 4;

        ///<summary>(0, 0, 0, 0)</summary>
        public static readonly int4 zero = new int4(0, 0, 0, 0);
        ///<summary>(1, 1, 1, 1)</summary>
        public static readonly int4 one = new int4(1, 1, 1, 1);

        ///<summary>(-1, 0, 0, 0)</summary>
        public static readonly int4 left = new int4(unchecked((int)-1), 0, 0, 0);
        ///<summary>(1, 0, 0, 0)</summary>
        public static readonly int4 right = new int4(1, 0, 0, 0);
        ///<summary>(0, -1, 0, 0)</summary>
        public static readonly int4 down = new int4(0, unchecked((int)-1), 0, 0);
        ///<summary>(0, 1, 0, 0)</summary>
        public static readonly int4 up = new int4(0, 1, 0, 0);
        ///<summary>(0, 0, -1, 0)</summary>
        public static readonly int4 back = new int4(0, 0, unchecked((int)-1), 0);
        ///<summary>(0, 0, 1, 0)</summary>
        public static readonly int4 forward = new int4(0, 0, 1, 0);
        ///<summary>(0, 0, 0, -1)</summary>
        public static readonly int4 before = new int4(0, 0, 0, unchecked((int)-1));
        ///<summary>(0, 0, 0, 1)</summary>
        public static readonly int4 after = new int4(0, 0, 0, 1);
        #endregion

        public int x;
        public int y;
        public int z;
        public int w;

        #region IColor
        public float r { [IN(LINE)] get { return (float)x; } [IN(LINE)] set { x = (int)value; } }
        public float g { [IN(LINE)] get { return (float)y; } [IN(LINE)] set { y = (int)value; } }
        public float b { [IN(LINE)] get { return (float)z; } [IN(LINE)] set { z = (int)value; } }
        public float a { [IN(LINE)] get { return (float)w; } [IN(LINE)] set { w = (int)value; } }
        #endregion

        #region IVector
        [EditorBrowsable(EditorBrowsableState.Never)] int IVector1<int>.x { [IN(LINE)] get { return x; } [IN(LINE)] set { x = value; } }
        [EditorBrowsable(EditorBrowsableState.Never)] int IVector2<int>.y { [IN(LINE)] get { return y; } [IN(LINE)] set { y = value; } }
        [EditorBrowsable(EditorBrowsableState.Never)] int IVector3<int>.z { [IN(LINE)] get { return z; } [IN(LINE)] set { z = value; } }
        [EditorBrowsable(EditorBrowsableState.Never)] int IVector4<int>.w { [IN(LINE)] get { return w; } [IN(LINE)] set { w = value; } }
        [EditorBrowsable(EditorBrowsableState.Never)] int IVectorN.Count { [IN(LINE)] get { return Count; } }

        public int this[int index]
        {
            [IN(LINE)]
            get
            {
#if DEBUG || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > Count) { Throw.IndexOutOfRange(Count); }
#endif
                fixed (int4* array = &this) { return ((int*)array)[index]; }
            }
            [IN(LINE)]
            set
            {
#if DEBUG || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > Count) { Throw.IndexOutOfRange(Count); }
#endif
                fixed (int* array = &x) { array[index] = value; }
            }
        }

        object IVectorN.GetComponentRaw(int index) { return this[index]; }
        void IVectorN.SetComponentRaw(int index, object raw) { if (raw is int cmp) { this[index] = cmp; } }
        [IN(LINE)] Type IVectorN.GetComponentType() { return typeof(int); }
        #endregion

        #region Constructors
        [IN(LINE)]
        public int4((int x, int y, int z, int w) a)
        {
            this.x = a.x; this.y = a.y;
            this.z = a.z; this.w = a.w;
        }
        [IN(LINE)]
        public int4((int x, int y, int z) a, int w)
        {
            this.x = a.x; this.y = a.y;
            this.z = a.z; this.w = w;
        }
        [IN(LINE)]
        public int4(int x, (int x, int y, int z) a)
        {
            this.x = x; this.y = a.x;
            this.z = a.y; this.w = a.z;
        }
        [IN(LINE)]
        public int4((int x, int y) a, int z, int w)
        {
            this.x = a.x; this.y = a.y;
            this.z = z; this.w = w;
        }
        [IN(LINE)]
        public int4(int x, (int x, int y) a, int w)
        {
            this.x = x; this.y = a.x;
            this.z = a.y; this.w = w;
        }
        [IN(LINE)]
        public int4(int x, int y, (int x, int y) a)
        {
            this.x = x; this.y = y;
            this.z = a.x; this.w = a.y;
        }
        [IN(LINE)]
        public int4((int x, int y) a, (int x, int y) b)
        {
            this.x = a.x; this.y = a.y;
            this.z = b.x; this.w = b.y;
        }

        [IN(LINE)]
        public int4(int x, int y, int z, int w)
        {
            this.x = x; this.y = y;
            this.z = z; this.w = w;
        }
        [IN(LINE)]
        public int4(int3 a, int w)
        {
            this.x = a.x; this.y = a.y;
            this.z = a.z; this.w = w;
        }
        [IN(LINE)]
        public int4(int x, int3 a)
        {
            this.x = x; this.y = a.x;
            this.z = a.y; this.w = a.z;
        }
        [IN(LINE)]
        public int4(int2 a, int z, int w)
        {
            this.x = a.x; this.y = a.y;
            this.z = z; this.w = w;
        }
        [IN(LINE)]
        public int4(int x, int2 a, int w)
        {
            this.x = x; this.y = a.x;
            this.z = a.y; this.w = w;
        }
        [IN(LINE)]
        public int4(int x, int y, int2 a)
        {
            this.x = x; this.y = y;
            this.z = a.x; this.w = a.y;
        }
        [IN(LINE)]
        public int4(int2 a, int2 b)
        {
            this.x = a.x; this.y = a.y;
            this.z = b.x; this.w = b.y;
        }

        [IN(LINE)]
        public int4(float v)
        {
            x = (int)v; y = (int)v;
            z = (int)v; w = (int)v;
        }
        [IN(LINE)]
        public int4(float4 v)
        {
            x = (int)v.x; y = (int)v.y;
            z = (int)v.z; w = (int)v.w;
        }
        [IN(LINE)]
        public int4(double v)
        {
            x = (int)v; y = (int)v;
            z = (int)v; w = (int)v;
        }
        [IN(LINE)]
        public int4(double4 v)
        {
            x = (int)v.x; y = (int)v.y;
            z = (int)v.z; w = (int)v.w;
        }
        [IN(LINE)]
        public int4(int v)
        {
            x = v; y = v;
            z = v; w = v;
        }
        [IN(LINE)]
        public int4(int4 v)
        {
            x = v.x; y = v.y;
            z = v.z; w = v.w;
        }
        [IN(LINE)]
        public int4(uint v)
        {
            x = (int)v; y = (int)v;
            z = (int)v; w = (int)v;
        }
        [IN(LINE)]
        public int4(uint4 v)
        {
            x = (int)v.x; y = (int)v.y;
            z = (int)v.z; w = (int)v.w;
        }

        [IN(LINE)]
        public int4(ReadOnlySpan<int> values)
        {
#if DEBUG || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
            if (values.Length < Count) { Throw.ArgumentOutOfRange(nameof(values)); }
#endif
#if UNITY_5_3_OR_NEWER
            x = values[0]; y = values[1]; z = values[2]; w = values[3];
#else
            this = Unsafe.ReadUnaligned<int4>(ref Unsafe.As<int, byte>(ref MemoryMarshal.GetReference(values)));
#endif
        }
        [IN(LINE)] public void Deconstruct(out int x, out int y, out int z, out int w) { x = this.x; y = this.y; z = this.z; w = this.w; }
        #endregion

        #region operators

        #region Arithmetic
        [IN(LINE)] public static int4 operator +(int4 a, int4 b) { return new int4(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w); }
        [IN(LINE)] public static int4 operator +(int4 a, int b) { return new int4(a.x + b, a.y + b, a.z + b, a.w + b); }
        [IN(LINE)] public static int4 operator +(int a, int4 b) { return new int4(a + b.x, a + b.y, a + b.z, a + b.w); }

        [IN(LINE)] public static int4 operator -(int4 a, int4 b) { return new int4(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w); }
        [IN(LINE)] public static int4 operator -(int4 a, int b) { return new int4(a.x - b, a.y - b, a.z - b, a.w - b); }
        [IN(LINE)] public static int4 operator -(int a, int4 b) { return new int4(a - b.x, a - b.y, a - b.z, a - b.w); }

        [IN(LINE)] public static int4 operator *(int4 a, int4 b) { return new int4(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w); }
        [IN(LINE)] public static int4 operator *(int4 a, int b) { return new int4(a.x * b, a.y * b, a.z * b, a.w * b); }
        [IN(LINE)] public static int4 operator *(int a, int4 b) { return new int4(a * b.x, a * b.y, a * b.z, a * b.w); }

        [IN(LINE)] public static int4 operator /(int4 a, int4 b) { return new int4(a.x / b.x, a.y / b.y, a.z / b.z, a.w / b.w); }
        [IN(LINE)] public static int4 operator /(int4 a, int b) { return new int4(a.x / b, a.y / b, a.z / b, a.w / b); }
        [IN(LINE)] public static int4 operator /(int a, int4 b) { return new int4(a / b.x, a / b.y, a / b.z, a / b.w); }

        [IN(LINE)] public static int4 operator %(int4 a, int4 b) { return new int4(a.x % b.x, a.y % b.y, a.z % b.z, a.w % b.w); }
        [IN(LINE)] public static int4 operator %(int4 a, int b) { return new int4(a.x % b, a.y % b, a.z % b, a.w % b); }
        [IN(LINE)] public static int4 operator %(int a, int4 b) { return new int4(a % b.x, a % b.y, a % b.z, a % b.w); }

        [IN(LINE)] public static int4 operator ++(int4 a) { return new int4(++a.x, ++a.y, ++a.z, ++a.w); }
        [IN(LINE)] public static int4 operator --(int4 a) { return new int4(--a.x, --a.y, --a.z, --a.w); }
        [IN(LINE)] public static int4 operator +(int4 a) { return new int4(+a.x, +a.y, +a.z, +a.w); }
        [IN(LINE)] public static int4 operator -(int4 a) { return new int4((int)-a.x, (int)-a.y, (int)-a.z, (int)-a.w); }
        #endregion

        #region Bits
        [IN(LINE)] public static int4 operator ~(int4 a) { return new int4(~a.x, ~a.y, ~a.z, ~a.w); }
        [IN(LINE)] public static int4 operator <<(int4 a, int n) { return new int4(a.x << n, a.y << n, a.z << n, a.w << n); }
        [IN(LINE)] public static int4 operator >>(int4 a, int n) { return new int4(a.x >> n, a.y >> n, a.z >> n, a.w >> n); }

        [IN(LINE)] public static int4 operator |(int4 a, int4 b) { return new int4(a.x | b.x, a.y | b.y, a.z | b.z, a.w | b.w); }
        [IN(LINE)] public static int4 operator |(int4 a, int b) { return new int4(a.x | b, a.y | b, a.z | b, a.w | b); }
        [IN(LINE)] public static int4 operator |(int a, int4 b) { return new int4(a | b.x, a | b.y, a | b.z, a | b.w); }

        [IN(LINE)] public static int4 operator &(int4 a, int4 b) { return new int4(a.x & b.x, a.y & b.y, a.z & b.z, a.w & b.w); }
        [IN(LINE)] public static int4 operator &(int4 a, int b) { return new int4(a.x & b, a.y & b, a.z & b, a.w & b); }
        [IN(LINE)] public static int4 operator &(int a, int4 b) { return new int4(a & b.x, a & b.y, a & b.z, a & b.w); }

        [IN(LINE)] public static int4 operator ^(int4 a, int4 b) { return new int4(a.x ^ b.x, a.y ^ b.y, a.z ^ b.z, a.w ^ b.w); }
        [IN(LINE)] public static int4 operator ^(int4 a, int b) { return new int4(a.x ^ b, a.y ^ b, a.z ^ b, a.w ^ b); }
        [IN(LINE)] public static int4 operator ^(int a, int4 b) { return new int4(a ^ b.x, a ^ b.y, a ^ b.z, a ^ b.w); }
        #endregion

        #region Boolean
        [IN(LINE)] public static bool4 operator <(int4 a, int4 b) { return new bool4(a.x < b.x, a.y < b.y, a.z < b.z, a.w < b.w); }
        [IN(LINE)] public static bool4 operator <(int4 a, int b) { return new bool4(a.x < b, a.y < b, a.z < b, a.w < b); }
        [IN(LINE)] public static bool4 operator <(int a, int4 b) { return new bool4(a < b.x, a < b.y, a < b.z, a < b.w); }

        [IN(LINE)] public static bool4 operator <=(int4 a, int4 b) { return new bool4(a.x <= b.x, a.y <= b.y, a.z <= b.z, a.w <= b.w); }
        [IN(LINE)] public static bool4 operator <=(int4 a, int b) { return new bool4(a.x <= b, a.y <= b, a.z <= b, a.w <= b); }
        [IN(LINE)] public static bool4 operator <=(int a, int4 b) { return new bool4(a <= b.x, a <= b.y, a <= b.z, a <= b.w); }

        [IN(LINE)] public static bool4 operator >(int4 a, int4 b) { return new bool4(a.x > b.x, a.y > b.y, a.z > b.z, a.w > b.w); }
        [IN(LINE)] public static bool4 operator >(int4 a, int b) { return new bool4(a.x > b, a.y > b, a.z > b, a.w > b); }
        [IN(LINE)] public static bool4 operator >(int a, int4 b) { return new bool4(a > b.x, a > b.y, a > b.z, a > b.w); }

        [IN(LINE)] public static bool4 operator >=(int4 a, int4 b) { return new bool4(a.x >= b.x, a.y >= b.y, a.z >= b.z, a.w >= b.w); }
        [IN(LINE)] public static bool4 operator >=(int4 a, int b) { return new bool4(a.x >= b, a.y >= b, a.z >= b, a.w >= b); }
        [IN(LINE)] public static bool4 operator >=(int a, int4 b) { return new bool4(a >= b.x, a >= b.y, a >= b.z, a >= b.w); }

        [IN(LINE)] public static bool4 operator ==(int4 a, int4 b) { return new bool4(a.x == b.x, a.y == b.y, a.z == b.z, a.w == b.w); }
        [IN(LINE)] public static bool4 operator ==(int4 a, int b) { return new bool4(a.x == b, a.y == b, a.z == b, a.w == b); }
        [IN(LINE)] public static bool4 operator ==(int a, int4 b) { return new bool4(a == b.x, a == b.y, a == b.z, a == b.w); }

        [IN(LINE)] public static bool4 operator !=(int4 a, int4 b) { return new bool4(a.x != b.x, a.y != b.y, a.z != b.z, a.w != b.w); }
        [IN(LINE)] public static bool4 operator !=(int4 a, int b) { return new bool4(a.x != b, a.y != b, a.z != b, a.w != b); }
        [IN(LINE)] public static bool4 operator !=(int a, int4 b) { return new bool4(a != b.x, a != b.y, a != b.z, a != b.w); }
        #endregion

        #region Other
        [IN(LINE)] public static int4 operator !(int4 a) { return 1 - a; }
        #endregion

        #endregion

        #region Swizzles

        #region Swizzle2
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 xx { [IN(LINE)] get => new int2(x, x); [IN(LINE)] set { x = value.x; x = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 xy { [IN(LINE)] get => new int2(x, y); [IN(LINE)] set { x = value.x; y = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 xz { [IN(LINE)] get => new int2(x, z); [IN(LINE)] set { x = value.x; z = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 xw { [IN(LINE)] get => new int2(x, w); [IN(LINE)] set { x = value.x; w = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 x_ { [IN(LINE)] get => new int2(x, 0); [IN(LINE)] set { x = value.x; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 yx { [IN(LINE)] get => new int2(y, x); [IN(LINE)] set { y = value.x; x = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 yy { [IN(LINE)] get => new int2(y, y); [IN(LINE)] set { y = value.x; y = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 yz { [IN(LINE)] get => new int2(y, z); [IN(LINE)] set { y = value.x; z = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 yw { [IN(LINE)] get => new int2(y, w); [IN(LINE)] set { y = value.x; w = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 y_ { [IN(LINE)] get => new int2(y, 0); [IN(LINE)] set { y = value.x; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 zx { [IN(LINE)] get => new int2(z, x); [IN(LINE)] set { z = value.x; x = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 zy { [IN(LINE)] get => new int2(z, y); [IN(LINE)] set { z = value.x; y = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 zz { [IN(LINE)] get => new int2(z, z); [IN(LINE)] set { z = value.x; z = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 zw { [IN(LINE)] get => new int2(z, w); [IN(LINE)] set { z = value.x; w = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 z_ { [IN(LINE)] get => new int2(z, 0); [IN(LINE)] set { z = value.x; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 wx { [IN(LINE)] get => new int2(w, x); [IN(LINE)] set { w = value.x; x = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 wy { [IN(LINE)] get => new int2(w, y); [IN(LINE)] set { w = value.x; y = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 wz { [IN(LINE)] get => new int2(w, z); [IN(LINE)] set { w = value.x; z = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 ww { [IN(LINE)] get => new int2(w, w); [IN(LINE)] set { w = value.x; w = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 w_ { [IN(LINE)] get => new int2(w, 0); [IN(LINE)] set { w = value.x; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 _x { [IN(LINE)] get => new int2(0, x); [IN(LINE)] set { x = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 _y { [IN(LINE)] get => new int2(0, y); [IN(LINE)] set { y = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 _z { [IN(LINE)] get => new int2(0, z); [IN(LINE)] set { z = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int2 _w { [IN(LINE)] get => new int2(0, w); [IN(LINE)] set { w = value.y; } }
        #endregion

        #region Swizzle3
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xxx { [IN(LINE)] get => new int3(x, x, x); [IN(LINE)] set { x = value.x; x = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xxy { [IN(LINE)] get => new int3(x, x, y); [IN(LINE)] set { x = value.x; x = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xxz { [IN(LINE)] get => new int3(x, x, z); [IN(LINE)] set { x = value.x; x = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xxw { [IN(LINE)] get => new int3(x, x, w); [IN(LINE)] set { x = value.x; x = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xx_ { [IN(LINE)] get => new int3(x, x, 0); [IN(LINE)] set { x = value.x; x = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xyx { [IN(LINE)] get => new int3(x, y, x); [IN(LINE)] set { x = value.x; y = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xyy { [IN(LINE)] get => new int3(x, y, y); [IN(LINE)] set { x = value.x; y = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xyz { [IN(LINE)] get => new int3(x, y, z); [IN(LINE)] set { x = value.x; y = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xyw { [IN(LINE)] get => new int3(x, y, w); [IN(LINE)] set { x = value.x; y = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xy_ { [IN(LINE)] get => new int3(x, y, 0); [IN(LINE)] set { x = value.x; y = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xzx { [IN(LINE)] get => new int3(x, z, x); [IN(LINE)] set { x = value.x; z = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xzy { [IN(LINE)] get => new int3(x, z, y); [IN(LINE)] set { x = value.x; z = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xzz { [IN(LINE)] get => new int3(x, z, z); [IN(LINE)] set { x = value.x; z = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xzw { [IN(LINE)] get => new int3(x, z, w); [IN(LINE)] set { x = value.x; z = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xz_ { [IN(LINE)] get => new int3(x, z, 0); [IN(LINE)] set { x = value.x; z = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xwx { [IN(LINE)] get => new int3(x, w, x); [IN(LINE)] set { x = value.x; w = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xwy { [IN(LINE)] get => new int3(x, w, y); [IN(LINE)] set { x = value.x; w = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xwz { [IN(LINE)] get => new int3(x, w, z); [IN(LINE)] set { x = value.x; w = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xww { [IN(LINE)] get => new int3(x, w, w); [IN(LINE)] set { x = value.x; w = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 xw_ { [IN(LINE)] get => new int3(x, w, 0); [IN(LINE)] set { x = value.x; w = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 x_x { [IN(LINE)] get => new int3(x, 0, x); [IN(LINE)] set { x = value.x; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 x_y { [IN(LINE)] get => new int3(x, 0, y); [IN(LINE)] set { x = value.x; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 x_z { [IN(LINE)] get => new int3(x, 0, z); [IN(LINE)] set { x = value.x; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 x_w { [IN(LINE)] get => new int3(x, 0, w); [IN(LINE)] set { x = value.x; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 x__ { [IN(LINE)] get => new int3(x, 0, 0); [IN(LINE)] set { x = value.x; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 yxx { [IN(LINE)] get => new int3(y, x, x); [IN(LINE)] set { y = value.x; x = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 yxy { [IN(LINE)] get => new int3(y, x, y); [IN(LINE)] set { y = value.x; x = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 yxz { [IN(LINE)] get => new int3(y, x, z); [IN(LINE)] set { y = value.x; x = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 yxw { [IN(LINE)] get => new int3(y, x, w); [IN(LINE)] set { y = value.x; x = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 yx_ { [IN(LINE)] get => new int3(y, x, 0); [IN(LINE)] set { y = value.x; x = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 yyx { [IN(LINE)] get => new int3(y, y, x); [IN(LINE)] set { y = value.x; y = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 yyy { [IN(LINE)] get => new int3(y, y, y); [IN(LINE)] set { y = value.x; y = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 yyz { [IN(LINE)] get => new int3(y, y, z); [IN(LINE)] set { y = value.x; y = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 yyw { [IN(LINE)] get => new int3(y, y, w); [IN(LINE)] set { y = value.x; y = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 yy_ { [IN(LINE)] get => new int3(y, y, 0); [IN(LINE)] set { y = value.x; y = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 yzx { [IN(LINE)] get => new int3(y, z, x); [IN(LINE)] set { y = value.x; z = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 yzy { [IN(LINE)] get => new int3(y, z, y); [IN(LINE)] set { y = value.x; z = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 yzz { [IN(LINE)] get => new int3(y, z, z); [IN(LINE)] set { y = value.x; z = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 yzw { [IN(LINE)] get => new int3(y, z, w); [IN(LINE)] set { y = value.x; z = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 yz_ { [IN(LINE)] get => new int3(y, z, 0); [IN(LINE)] set { y = value.x; z = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 ywx { [IN(LINE)] get => new int3(y, w, x); [IN(LINE)] set { y = value.x; w = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 ywy { [IN(LINE)] get => new int3(y, w, y); [IN(LINE)] set { y = value.x; w = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 ywz { [IN(LINE)] get => new int3(y, w, z); [IN(LINE)] set { y = value.x; w = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 yww { [IN(LINE)] get => new int3(y, w, w); [IN(LINE)] set { y = value.x; w = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 yw_ { [IN(LINE)] get => new int3(y, w, 0); [IN(LINE)] set { y = value.x; w = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 y_x { [IN(LINE)] get => new int3(y, 0, x); [IN(LINE)] set { y = value.x; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 y_y { [IN(LINE)] get => new int3(y, 0, y); [IN(LINE)] set { y = value.x; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 y_z { [IN(LINE)] get => new int3(y, 0, z); [IN(LINE)] set { y = value.x; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 y_w { [IN(LINE)] get => new int3(y, 0, w); [IN(LINE)] set { y = value.x; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 y__ { [IN(LINE)] get => new int3(y, 0, 0); [IN(LINE)] set { y = value.x; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zxx { [IN(LINE)] get => new int3(z, x, x); [IN(LINE)] set { z = value.x; x = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zxy { [IN(LINE)] get => new int3(z, x, y); [IN(LINE)] set { z = value.x; x = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zxz { [IN(LINE)] get => new int3(z, x, z); [IN(LINE)] set { z = value.x; x = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zxw { [IN(LINE)] get => new int3(z, x, w); [IN(LINE)] set { z = value.x; x = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zx_ { [IN(LINE)] get => new int3(z, x, 0); [IN(LINE)] set { z = value.x; x = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zyx { [IN(LINE)] get => new int3(z, y, x); [IN(LINE)] set { z = value.x; y = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zyy { [IN(LINE)] get => new int3(z, y, y); [IN(LINE)] set { z = value.x; y = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zyz { [IN(LINE)] get => new int3(z, y, z); [IN(LINE)] set { z = value.x; y = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zyw { [IN(LINE)] get => new int3(z, y, w); [IN(LINE)] set { z = value.x; y = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zy_ { [IN(LINE)] get => new int3(z, y, 0); [IN(LINE)] set { z = value.x; y = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zzx { [IN(LINE)] get => new int3(z, z, x); [IN(LINE)] set { z = value.x; z = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zzy { [IN(LINE)] get => new int3(z, z, y); [IN(LINE)] set { z = value.x; z = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zzz { [IN(LINE)] get => new int3(z, z, z); [IN(LINE)] set { z = value.x; z = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zzw { [IN(LINE)] get => new int3(z, z, w); [IN(LINE)] set { z = value.x; z = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zz_ { [IN(LINE)] get => new int3(z, z, 0); [IN(LINE)] set { z = value.x; z = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zwx { [IN(LINE)] get => new int3(z, w, x); [IN(LINE)] set { z = value.x; w = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zwy { [IN(LINE)] get => new int3(z, w, y); [IN(LINE)] set { z = value.x; w = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zwz { [IN(LINE)] get => new int3(z, w, z); [IN(LINE)] set { z = value.x; w = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zww { [IN(LINE)] get => new int3(z, w, w); [IN(LINE)] set { z = value.x; w = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 zw_ { [IN(LINE)] get => new int3(z, w, 0); [IN(LINE)] set { z = value.x; w = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 z_x { [IN(LINE)] get => new int3(z, 0, x); [IN(LINE)] set { z = value.x; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 z_y { [IN(LINE)] get => new int3(z, 0, y); [IN(LINE)] set { z = value.x; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 z_z { [IN(LINE)] get => new int3(z, 0, z); [IN(LINE)] set { z = value.x; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 z_w { [IN(LINE)] get => new int3(z, 0, w); [IN(LINE)] set { z = value.x; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 z__ { [IN(LINE)] get => new int3(z, 0, 0); [IN(LINE)] set { z = value.x; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 wxx { [IN(LINE)] get => new int3(w, x, x); [IN(LINE)] set { w = value.x; x = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 wxy { [IN(LINE)] get => new int3(w, x, y); [IN(LINE)] set { w = value.x; x = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 wxz { [IN(LINE)] get => new int3(w, x, z); [IN(LINE)] set { w = value.x; x = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 wxw { [IN(LINE)] get => new int3(w, x, w); [IN(LINE)] set { w = value.x; x = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 wx_ { [IN(LINE)] get => new int3(w, x, 0); [IN(LINE)] set { w = value.x; x = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 wyx { [IN(LINE)] get => new int3(w, y, x); [IN(LINE)] set { w = value.x; y = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 wyy { [IN(LINE)] get => new int3(w, y, y); [IN(LINE)] set { w = value.x; y = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 wyz { [IN(LINE)] get => new int3(w, y, z); [IN(LINE)] set { w = value.x; y = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 wyw { [IN(LINE)] get => new int3(w, y, w); [IN(LINE)] set { w = value.x; y = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 wy_ { [IN(LINE)] get => new int3(w, y, 0); [IN(LINE)] set { w = value.x; y = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 wzx { [IN(LINE)] get => new int3(w, z, x); [IN(LINE)] set { w = value.x; z = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 wzy { [IN(LINE)] get => new int3(w, z, y); [IN(LINE)] set { w = value.x; z = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 wzz { [IN(LINE)] get => new int3(w, z, z); [IN(LINE)] set { w = value.x; z = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 wzw { [IN(LINE)] get => new int3(w, z, w); [IN(LINE)] set { w = value.x; z = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 wz_ { [IN(LINE)] get => new int3(w, z, 0); [IN(LINE)] set { w = value.x; z = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 wwx { [IN(LINE)] get => new int3(w, w, x); [IN(LINE)] set { w = value.x; w = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 wwy { [IN(LINE)] get => new int3(w, w, y); [IN(LINE)] set { w = value.x; w = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 wwz { [IN(LINE)] get => new int3(w, w, z); [IN(LINE)] set { w = value.x; w = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 www { [IN(LINE)] get => new int3(w, w, w); [IN(LINE)] set { w = value.x; w = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 ww_ { [IN(LINE)] get => new int3(w, w, 0); [IN(LINE)] set { w = value.x; w = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 w_x { [IN(LINE)] get => new int3(w, 0, x); [IN(LINE)] set { w = value.x; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 w_y { [IN(LINE)] get => new int3(w, 0, y); [IN(LINE)] set { w = value.x; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 w_z { [IN(LINE)] get => new int3(w, 0, z); [IN(LINE)] set { w = value.x; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 w_w { [IN(LINE)] get => new int3(w, 0, w); [IN(LINE)] set { w = value.x; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 w__ { [IN(LINE)] get => new int3(w, 0, 0); [IN(LINE)] set { w = value.x; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 _xx { [IN(LINE)] get => new int3(0, x, x); [IN(LINE)] set { x = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 _xy { [IN(LINE)] get => new int3(0, x, y); [IN(LINE)] set { x = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 _xz { [IN(LINE)] get => new int3(0, x, z); [IN(LINE)] set { x = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 _xw { [IN(LINE)] get => new int3(0, x, w); [IN(LINE)] set { x = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 _x_ { [IN(LINE)] get => new int3(0, x, 0); [IN(LINE)] set { x = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 _yx { [IN(LINE)] get => new int3(0, y, x); [IN(LINE)] set { y = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 _yy { [IN(LINE)] get => new int3(0, y, y); [IN(LINE)] set { y = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 _yz { [IN(LINE)] get => new int3(0, y, z); [IN(LINE)] set { y = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 _yw { [IN(LINE)] get => new int3(0, y, w); [IN(LINE)] set { y = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 _y_ { [IN(LINE)] get => new int3(0, y, 0); [IN(LINE)] set { y = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 _zx { [IN(LINE)] get => new int3(0, z, x); [IN(LINE)] set { z = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 _zy { [IN(LINE)] get => new int3(0, z, y); [IN(LINE)] set { z = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 _zz { [IN(LINE)] get => new int3(0, z, z); [IN(LINE)] set { z = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 _zw { [IN(LINE)] get => new int3(0, z, w); [IN(LINE)] set { z = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 _z_ { [IN(LINE)] get => new int3(0, z, 0); [IN(LINE)] set { z = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 _wx { [IN(LINE)] get => new int3(0, w, x); [IN(LINE)] set { w = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 _wy { [IN(LINE)] get => new int3(0, w, y); [IN(LINE)] set { w = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 _wz { [IN(LINE)] get => new int3(0, w, z); [IN(LINE)] set { w = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 _ww { [IN(LINE)] get => new int3(0, w, w); [IN(LINE)] set { w = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 _w_ { [IN(LINE)] get => new int3(0, w, 0); [IN(LINE)] set { w = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 __x { [IN(LINE)] get => new int3(0, 0, x); [IN(LINE)] set { x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 __y { [IN(LINE)] get => new int3(0, 0, y); [IN(LINE)] set { y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 __z { [IN(LINE)] get => new int3(0, 0, z); [IN(LINE)] set { z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int3 __w { [IN(LINE)] get => new int3(0, 0, w); [IN(LINE)] set { w = value.z; } }
        #endregion

        #region Swizzle4
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxxx { [IN(LINE)] get => new int4(x, x, x, x); [IN(LINE)] set { x = value.x; x = value.y; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxxy { [IN(LINE)] get => new int4(x, x, x, y); [IN(LINE)] set { x = value.x; x = value.y; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxxz { [IN(LINE)] get => new int4(x, x, x, z); [IN(LINE)] set { x = value.x; x = value.y; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxxw { [IN(LINE)] get => new int4(x, x, x, w); [IN(LINE)] set { x = value.x; x = value.y; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxx_ { [IN(LINE)] get => new int4(x, x, x, 0); [IN(LINE)] set { x = value.x; x = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxyx { [IN(LINE)] get => new int4(x, x, y, x); [IN(LINE)] set { x = value.x; x = value.y; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxyy { [IN(LINE)] get => new int4(x, x, y, y); [IN(LINE)] set { x = value.x; x = value.y; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxyz { [IN(LINE)] get => new int4(x, x, y, z); [IN(LINE)] set { x = value.x; x = value.y; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxyw { [IN(LINE)] get => new int4(x, x, y, w); [IN(LINE)] set { x = value.x; x = value.y; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxy_ { [IN(LINE)] get => new int4(x, x, y, 0); [IN(LINE)] set { x = value.x; x = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxzx { [IN(LINE)] get => new int4(x, x, z, x); [IN(LINE)] set { x = value.x; x = value.y; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxzy { [IN(LINE)] get => new int4(x, x, z, y); [IN(LINE)] set { x = value.x; x = value.y; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxzz { [IN(LINE)] get => new int4(x, x, z, z); [IN(LINE)] set { x = value.x; x = value.y; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxzw { [IN(LINE)] get => new int4(x, x, z, w); [IN(LINE)] set { x = value.x; x = value.y; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxz_ { [IN(LINE)] get => new int4(x, x, z, 0); [IN(LINE)] set { x = value.x; x = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxwx { [IN(LINE)] get => new int4(x, x, w, x); [IN(LINE)] set { x = value.x; x = value.y; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxwy { [IN(LINE)] get => new int4(x, x, w, y); [IN(LINE)] set { x = value.x; x = value.y; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxwz { [IN(LINE)] get => new int4(x, x, w, z); [IN(LINE)] set { x = value.x; x = value.y; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxww { [IN(LINE)] get => new int4(x, x, w, w); [IN(LINE)] set { x = value.x; x = value.y; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xxw_ { [IN(LINE)] get => new int4(x, x, w, 0); [IN(LINE)] set { x = value.x; x = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xx_x { [IN(LINE)] get => new int4(x, x, 0, x); [IN(LINE)] set { x = value.x; x = value.y; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xx_y { [IN(LINE)] get => new int4(x, x, 0, y); [IN(LINE)] set { x = value.x; x = value.y; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xx_z { [IN(LINE)] get => new int4(x, x, 0, z); [IN(LINE)] set { x = value.x; x = value.y; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xx_w { [IN(LINE)] get => new int4(x, x, 0, w); [IN(LINE)] set { x = value.x; x = value.y; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xx__ { [IN(LINE)] get => new int4(x, x, 0, 0); [IN(LINE)] set { x = value.x; x = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xyxx { [IN(LINE)] get => new int4(x, y, x, x); [IN(LINE)] set { x = value.x; y = value.y; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xyxy { [IN(LINE)] get => new int4(x, y, x, y); [IN(LINE)] set { x = value.x; y = value.y; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xyxz { [IN(LINE)] get => new int4(x, y, x, z); [IN(LINE)] set { x = value.x; y = value.y; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xyxw { [IN(LINE)] get => new int4(x, y, x, w); [IN(LINE)] set { x = value.x; y = value.y; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xyx_ { [IN(LINE)] get => new int4(x, y, x, 0); [IN(LINE)] set { x = value.x; y = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xyyx { [IN(LINE)] get => new int4(x, y, y, x); [IN(LINE)] set { x = value.x; y = value.y; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xyyy { [IN(LINE)] get => new int4(x, y, y, y); [IN(LINE)] set { x = value.x; y = value.y; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xyyz { [IN(LINE)] get => new int4(x, y, y, z); [IN(LINE)] set { x = value.x; y = value.y; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xyyw { [IN(LINE)] get => new int4(x, y, y, w); [IN(LINE)] set { x = value.x; y = value.y; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xyy_ { [IN(LINE)] get => new int4(x, y, y, 0); [IN(LINE)] set { x = value.x; y = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xyzx { [IN(LINE)] get => new int4(x, y, z, x); [IN(LINE)] set { x = value.x; y = value.y; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xyzy { [IN(LINE)] get => new int4(x, y, z, y); [IN(LINE)] set { x = value.x; y = value.y; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xyzz { [IN(LINE)] get => new int4(x, y, z, z); [IN(LINE)] set { x = value.x; y = value.y; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xyzw { [IN(LINE)] get => new int4(x, y, z, w); [IN(LINE)] set { x = value.x; y = value.y; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xyz_ { [IN(LINE)] get => new int4(x, y, z, 0); [IN(LINE)] set { x = value.x; y = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xywx { [IN(LINE)] get => new int4(x, y, w, x); [IN(LINE)] set { x = value.x; y = value.y; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xywy { [IN(LINE)] get => new int4(x, y, w, y); [IN(LINE)] set { x = value.x; y = value.y; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xywz { [IN(LINE)] get => new int4(x, y, w, z); [IN(LINE)] set { x = value.x; y = value.y; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xyww { [IN(LINE)] get => new int4(x, y, w, w); [IN(LINE)] set { x = value.x; y = value.y; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xyw_ { [IN(LINE)] get => new int4(x, y, w, 0); [IN(LINE)] set { x = value.x; y = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xy_x { [IN(LINE)] get => new int4(x, y, 0, x); [IN(LINE)] set { x = value.x; y = value.y; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xy_y { [IN(LINE)] get => new int4(x, y, 0, y); [IN(LINE)] set { x = value.x; y = value.y; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xy_z { [IN(LINE)] get => new int4(x, y, 0, z); [IN(LINE)] set { x = value.x; y = value.y; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xy_w { [IN(LINE)] get => new int4(x, y, 0, w); [IN(LINE)] set { x = value.x; y = value.y; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xy__ { [IN(LINE)] get => new int4(x, y, 0, 0); [IN(LINE)] set { x = value.x; y = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzxx { [IN(LINE)] get => new int4(x, z, x, x); [IN(LINE)] set { x = value.x; z = value.y; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzxy { [IN(LINE)] get => new int4(x, z, x, y); [IN(LINE)] set { x = value.x; z = value.y; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzxz { [IN(LINE)] get => new int4(x, z, x, z); [IN(LINE)] set { x = value.x; z = value.y; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzxw { [IN(LINE)] get => new int4(x, z, x, w); [IN(LINE)] set { x = value.x; z = value.y; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzx_ { [IN(LINE)] get => new int4(x, z, x, 0); [IN(LINE)] set { x = value.x; z = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzyx { [IN(LINE)] get => new int4(x, z, y, x); [IN(LINE)] set { x = value.x; z = value.y; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzyy { [IN(LINE)] get => new int4(x, z, y, y); [IN(LINE)] set { x = value.x; z = value.y; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzyz { [IN(LINE)] get => new int4(x, z, y, z); [IN(LINE)] set { x = value.x; z = value.y; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzyw { [IN(LINE)] get => new int4(x, z, y, w); [IN(LINE)] set { x = value.x; z = value.y; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzy_ { [IN(LINE)] get => new int4(x, z, y, 0); [IN(LINE)] set { x = value.x; z = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzzx { [IN(LINE)] get => new int4(x, z, z, x); [IN(LINE)] set { x = value.x; z = value.y; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzzy { [IN(LINE)] get => new int4(x, z, z, y); [IN(LINE)] set { x = value.x; z = value.y; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzzz { [IN(LINE)] get => new int4(x, z, z, z); [IN(LINE)] set { x = value.x; z = value.y; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzzw { [IN(LINE)] get => new int4(x, z, z, w); [IN(LINE)] set { x = value.x; z = value.y; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzz_ { [IN(LINE)] get => new int4(x, z, z, 0); [IN(LINE)] set { x = value.x; z = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzwx { [IN(LINE)] get => new int4(x, z, w, x); [IN(LINE)] set { x = value.x; z = value.y; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzwy { [IN(LINE)] get => new int4(x, z, w, y); [IN(LINE)] set { x = value.x; z = value.y; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzwz { [IN(LINE)] get => new int4(x, z, w, z); [IN(LINE)] set { x = value.x; z = value.y; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzww { [IN(LINE)] get => new int4(x, z, w, w); [IN(LINE)] set { x = value.x; z = value.y; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xzw_ { [IN(LINE)] get => new int4(x, z, w, 0); [IN(LINE)] set { x = value.x; z = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xz_x { [IN(LINE)] get => new int4(x, z, 0, x); [IN(LINE)] set { x = value.x; z = value.y; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xz_y { [IN(LINE)] get => new int4(x, z, 0, y); [IN(LINE)] set { x = value.x; z = value.y; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xz_z { [IN(LINE)] get => new int4(x, z, 0, z); [IN(LINE)] set { x = value.x; z = value.y; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xz_w { [IN(LINE)] get => new int4(x, z, 0, w); [IN(LINE)] set { x = value.x; z = value.y; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xz__ { [IN(LINE)] get => new int4(x, z, 0, 0); [IN(LINE)] set { x = value.x; z = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xwxx { [IN(LINE)] get => new int4(x, w, x, x); [IN(LINE)] set { x = value.x; w = value.y; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xwxy { [IN(LINE)] get => new int4(x, w, x, y); [IN(LINE)] set { x = value.x; w = value.y; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xwxz { [IN(LINE)] get => new int4(x, w, x, z); [IN(LINE)] set { x = value.x; w = value.y; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xwxw { [IN(LINE)] get => new int4(x, w, x, w); [IN(LINE)] set { x = value.x; w = value.y; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xwx_ { [IN(LINE)] get => new int4(x, w, x, 0); [IN(LINE)] set { x = value.x; w = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xwyx { [IN(LINE)] get => new int4(x, w, y, x); [IN(LINE)] set { x = value.x; w = value.y; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xwyy { [IN(LINE)] get => new int4(x, w, y, y); [IN(LINE)] set { x = value.x; w = value.y; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xwyz { [IN(LINE)] get => new int4(x, w, y, z); [IN(LINE)] set { x = value.x; w = value.y; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xwyw { [IN(LINE)] get => new int4(x, w, y, w); [IN(LINE)] set { x = value.x; w = value.y; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xwy_ { [IN(LINE)] get => new int4(x, w, y, 0); [IN(LINE)] set { x = value.x; w = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xwzx { [IN(LINE)] get => new int4(x, w, z, x); [IN(LINE)] set { x = value.x; w = value.y; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xwzy { [IN(LINE)] get => new int4(x, w, z, y); [IN(LINE)] set { x = value.x; w = value.y; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xwzz { [IN(LINE)] get => new int4(x, w, z, z); [IN(LINE)] set { x = value.x; w = value.y; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xwzw { [IN(LINE)] get => new int4(x, w, z, w); [IN(LINE)] set { x = value.x; w = value.y; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xwz_ { [IN(LINE)] get => new int4(x, w, z, 0); [IN(LINE)] set { x = value.x; w = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xwwx { [IN(LINE)] get => new int4(x, w, w, x); [IN(LINE)] set { x = value.x; w = value.y; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xwwy { [IN(LINE)] get => new int4(x, w, w, y); [IN(LINE)] set { x = value.x; w = value.y; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xwwz { [IN(LINE)] get => new int4(x, w, w, z); [IN(LINE)] set { x = value.x; w = value.y; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xwww { [IN(LINE)] get => new int4(x, w, w, w); [IN(LINE)] set { x = value.x; w = value.y; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xww_ { [IN(LINE)] get => new int4(x, w, w, 0); [IN(LINE)] set { x = value.x; w = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xw_x { [IN(LINE)] get => new int4(x, w, 0, x); [IN(LINE)] set { x = value.x; w = value.y; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xw_y { [IN(LINE)] get => new int4(x, w, 0, y); [IN(LINE)] set { x = value.x; w = value.y; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xw_z { [IN(LINE)] get => new int4(x, w, 0, z); [IN(LINE)] set { x = value.x; w = value.y; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xw_w { [IN(LINE)] get => new int4(x, w, 0, w); [IN(LINE)] set { x = value.x; w = value.y; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 xw__ { [IN(LINE)] get => new int4(x, w, 0, 0); [IN(LINE)] set { x = value.x; w = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 x_xx { [IN(LINE)] get => new int4(x, 0, x, x); [IN(LINE)] set { x = value.x; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 x_xy { [IN(LINE)] get => new int4(x, 0, x, y); [IN(LINE)] set { x = value.x; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 x_xz { [IN(LINE)] get => new int4(x, 0, x, z); [IN(LINE)] set { x = value.x; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 x_xw { [IN(LINE)] get => new int4(x, 0, x, w); [IN(LINE)] set { x = value.x; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 x_x_ { [IN(LINE)] get => new int4(x, 0, x, 0); [IN(LINE)] set { x = value.x; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 x_yx { [IN(LINE)] get => new int4(x, 0, y, x); [IN(LINE)] set { x = value.x; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 x_yy { [IN(LINE)] get => new int4(x, 0, y, y); [IN(LINE)] set { x = value.x; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 x_yz { [IN(LINE)] get => new int4(x, 0, y, z); [IN(LINE)] set { x = value.x; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 x_yw { [IN(LINE)] get => new int4(x, 0, y, w); [IN(LINE)] set { x = value.x; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 x_y_ { [IN(LINE)] get => new int4(x, 0, y, 0); [IN(LINE)] set { x = value.x; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 x_zx { [IN(LINE)] get => new int4(x, 0, z, x); [IN(LINE)] set { x = value.x; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 x_zy { [IN(LINE)] get => new int4(x, 0, z, y); [IN(LINE)] set { x = value.x; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 x_zz { [IN(LINE)] get => new int4(x, 0, z, z); [IN(LINE)] set { x = value.x; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 x_zw { [IN(LINE)] get => new int4(x, 0, z, w); [IN(LINE)] set { x = value.x; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 x_z_ { [IN(LINE)] get => new int4(x, 0, z, 0); [IN(LINE)] set { x = value.x; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 x_wx { [IN(LINE)] get => new int4(x, 0, w, x); [IN(LINE)] set { x = value.x; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 x_wy { [IN(LINE)] get => new int4(x, 0, w, y); [IN(LINE)] set { x = value.x; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 x_wz { [IN(LINE)] get => new int4(x, 0, w, z); [IN(LINE)] set { x = value.x; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 x_ww { [IN(LINE)] get => new int4(x, 0, w, w); [IN(LINE)] set { x = value.x; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 x_w_ { [IN(LINE)] get => new int4(x, 0, w, 0); [IN(LINE)] set { x = value.x; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 x__x { [IN(LINE)] get => new int4(x, 0, 0, x); [IN(LINE)] set { x = value.x; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 x__y { [IN(LINE)] get => new int4(x, 0, 0, y); [IN(LINE)] set { x = value.x; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 x__z { [IN(LINE)] get => new int4(x, 0, 0, z); [IN(LINE)] set { x = value.x; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 x__w { [IN(LINE)] get => new int4(x, 0, 0, w); [IN(LINE)] set { x = value.x; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 x___ { [IN(LINE)] get => new int4(x, 0, 0, 0); [IN(LINE)] set { x = value.x; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxxx { [IN(LINE)] get => new int4(y, x, x, x); [IN(LINE)] set { y = value.x; x = value.y; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxxy { [IN(LINE)] get => new int4(y, x, x, y); [IN(LINE)] set { y = value.x; x = value.y; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxxz { [IN(LINE)] get => new int4(y, x, x, z); [IN(LINE)] set { y = value.x; x = value.y; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxxw { [IN(LINE)] get => new int4(y, x, x, w); [IN(LINE)] set { y = value.x; x = value.y; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxx_ { [IN(LINE)] get => new int4(y, x, x, 0); [IN(LINE)] set { y = value.x; x = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxyx { [IN(LINE)] get => new int4(y, x, y, x); [IN(LINE)] set { y = value.x; x = value.y; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxyy { [IN(LINE)] get => new int4(y, x, y, y); [IN(LINE)] set { y = value.x; x = value.y; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxyz { [IN(LINE)] get => new int4(y, x, y, z); [IN(LINE)] set { y = value.x; x = value.y; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxyw { [IN(LINE)] get => new int4(y, x, y, w); [IN(LINE)] set { y = value.x; x = value.y; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxy_ { [IN(LINE)] get => new int4(y, x, y, 0); [IN(LINE)] set { y = value.x; x = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxzx { [IN(LINE)] get => new int4(y, x, z, x); [IN(LINE)] set { y = value.x; x = value.y; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxzy { [IN(LINE)] get => new int4(y, x, z, y); [IN(LINE)] set { y = value.x; x = value.y; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxzz { [IN(LINE)] get => new int4(y, x, z, z); [IN(LINE)] set { y = value.x; x = value.y; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxzw { [IN(LINE)] get => new int4(y, x, z, w); [IN(LINE)] set { y = value.x; x = value.y; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxz_ { [IN(LINE)] get => new int4(y, x, z, 0); [IN(LINE)] set { y = value.x; x = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxwx { [IN(LINE)] get => new int4(y, x, w, x); [IN(LINE)] set { y = value.x; x = value.y; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxwy { [IN(LINE)] get => new int4(y, x, w, y); [IN(LINE)] set { y = value.x; x = value.y; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxwz { [IN(LINE)] get => new int4(y, x, w, z); [IN(LINE)] set { y = value.x; x = value.y; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxww { [IN(LINE)] get => new int4(y, x, w, w); [IN(LINE)] set { y = value.x; x = value.y; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yxw_ { [IN(LINE)] get => new int4(y, x, w, 0); [IN(LINE)] set { y = value.x; x = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yx_x { [IN(LINE)] get => new int4(y, x, 0, x); [IN(LINE)] set { y = value.x; x = value.y; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yx_y { [IN(LINE)] get => new int4(y, x, 0, y); [IN(LINE)] set { y = value.x; x = value.y; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yx_z { [IN(LINE)] get => new int4(y, x, 0, z); [IN(LINE)] set { y = value.x; x = value.y; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yx_w { [IN(LINE)] get => new int4(y, x, 0, w); [IN(LINE)] set { y = value.x; x = value.y; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yx__ { [IN(LINE)] get => new int4(y, x, 0, 0); [IN(LINE)] set { y = value.x; x = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yyxx { [IN(LINE)] get => new int4(y, y, x, x); [IN(LINE)] set { y = value.x; y = value.y; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yyxy { [IN(LINE)] get => new int4(y, y, x, y); [IN(LINE)] set { y = value.x; y = value.y; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yyxz { [IN(LINE)] get => new int4(y, y, x, z); [IN(LINE)] set { y = value.x; y = value.y; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yyxw { [IN(LINE)] get => new int4(y, y, x, w); [IN(LINE)] set { y = value.x; y = value.y; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yyx_ { [IN(LINE)] get => new int4(y, y, x, 0); [IN(LINE)] set { y = value.x; y = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yyyx { [IN(LINE)] get => new int4(y, y, y, x); [IN(LINE)] set { y = value.x; y = value.y; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yyyy { [IN(LINE)] get => new int4(y, y, y, y); [IN(LINE)] set { y = value.x; y = value.y; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yyyz { [IN(LINE)] get => new int4(y, y, y, z); [IN(LINE)] set { y = value.x; y = value.y; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yyyw { [IN(LINE)] get => new int4(y, y, y, w); [IN(LINE)] set { y = value.x; y = value.y; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yyy_ { [IN(LINE)] get => new int4(y, y, y, 0); [IN(LINE)] set { y = value.x; y = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yyzx { [IN(LINE)] get => new int4(y, y, z, x); [IN(LINE)] set { y = value.x; y = value.y; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yyzy { [IN(LINE)] get => new int4(y, y, z, y); [IN(LINE)] set { y = value.x; y = value.y; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yyzz { [IN(LINE)] get => new int4(y, y, z, z); [IN(LINE)] set { y = value.x; y = value.y; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yyzw { [IN(LINE)] get => new int4(y, y, z, w); [IN(LINE)] set { y = value.x; y = value.y; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yyz_ { [IN(LINE)] get => new int4(y, y, z, 0); [IN(LINE)] set { y = value.x; y = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yywx { [IN(LINE)] get => new int4(y, y, w, x); [IN(LINE)] set { y = value.x; y = value.y; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yywy { [IN(LINE)] get => new int4(y, y, w, y); [IN(LINE)] set { y = value.x; y = value.y; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yywz { [IN(LINE)] get => new int4(y, y, w, z); [IN(LINE)] set { y = value.x; y = value.y; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yyww { [IN(LINE)] get => new int4(y, y, w, w); [IN(LINE)] set { y = value.x; y = value.y; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yyw_ { [IN(LINE)] get => new int4(y, y, w, 0); [IN(LINE)] set { y = value.x; y = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yy_x { [IN(LINE)] get => new int4(y, y, 0, x); [IN(LINE)] set { y = value.x; y = value.y; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yy_y { [IN(LINE)] get => new int4(y, y, 0, y); [IN(LINE)] set { y = value.x; y = value.y; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yy_z { [IN(LINE)] get => new int4(y, y, 0, z); [IN(LINE)] set { y = value.x; y = value.y; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yy_w { [IN(LINE)] get => new int4(y, y, 0, w); [IN(LINE)] set { y = value.x; y = value.y; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yy__ { [IN(LINE)] get => new int4(y, y, 0, 0); [IN(LINE)] set { y = value.x; y = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzxx { [IN(LINE)] get => new int4(y, z, x, x); [IN(LINE)] set { y = value.x; z = value.y; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzxy { [IN(LINE)] get => new int4(y, z, x, y); [IN(LINE)] set { y = value.x; z = value.y; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzxz { [IN(LINE)] get => new int4(y, z, x, z); [IN(LINE)] set { y = value.x; z = value.y; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzxw { [IN(LINE)] get => new int4(y, z, x, w); [IN(LINE)] set { y = value.x; z = value.y; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzx_ { [IN(LINE)] get => new int4(y, z, x, 0); [IN(LINE)] set { y = value.x; z = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzyx { [IN(LINE)] get => new int4(y, z, y, x); [IN(LINE)] set { y = value.x; z = value.y; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzyy { [IN(LINE)] get => new int4(y, z, y, y); [IN(LINE)] set { y = value.x; z = value.y; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzyz { [IN(LINE)] get => new int4(y, z, y, z); [IN(LINE)] set { y = value.x; z = value.y; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzyw { [IN(LINE)] get => new int4(y, z, y, w); [IN(LINE)] set { y = value.x; z = value.y; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzy_ { [IN(LINE)] get => new int4(y, z, y, 0); [IN(LINE)] set { y = value.x; z = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzzx { [IN(LINE)] get => new int4(y, z, z, x); [IN(LINE)] set { y = value.x; z = value.y; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzzy { [IN(LINE)] get => new int4(y, z, z, y); [IN(LINE)] set { y = value.x; z = value.y; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzzz { [IN(LINE)] get => new int4(y, z, z, z); [IN(LINE)] set { y = value.x; z = value.y; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzzw { [IN(LINE)] get => new int4(y, z, z, w); [IN(LINE)] set { y = value.x; z = value.y; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzz_ { [IN(LINE)] get => new int4(y, z, z, 0); [IN(LINE)] set { y = value.x; z = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzwx { [IN(LINE)] get => new int4(y, z, w, x); [IN(LINE)] set { y = value.x; z = value.y; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzwy { [IN(LINE)] get => new int4(y, z, w, y); [IN(LINE)] set { y = value.x; z = value.y; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzwz { [IN(LINE)] get => new int4(y, z, w, z); [IN(LINE)] set { y = value.x; z = value.y; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzww { [IN(LINE)] get => new int4(y, z, w, w); [IN(LINE)] set { y = value.x; z = value.y; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yzw_ { [IN(LINE)] get => new int4(y, z, w, 0); [IN(LINE)] set { y = value.x; z = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yz_x { [IN(LINE)] get => new int4(y, z, 0, x); [IN(LINE)] set { y = value.x; z = value.y; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yz_y { [IN(LINE)] get => new int4(y, z, 0, y); [IN(LINE)] set { y = value.x; z = value.y; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yz_z { [IN(LINE)] get => new int4(y, z, 0, z); [IN(LINE)] set { y = value.x; z = value.y; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yz_w { [IN(LINE)] get => new int4(y, z, 0, w); [IN(LINE)] set { y = value.x; z = value.y; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yz__ { [IN(LINE)] get => new int4(y, z, 0, 0); [IN(LINE)] set { y = value.x; z = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 ywxx { [IN(LINE)] get => new int4(y, w, x, x); [IN(LINE)] set { y = value.x; w = value.y; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 ywxy { [IN(LINE)] get => new int4(y, w, x, y); [IN(LINE)] set { y = value.x; w = value.y; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 ywxz { [IN(LINE)] get => new int4(y, w, x, z); [IN(LINE)] set { y = value.x; w = value.y; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 ywxw { [IN(LINE)] get => new int4(y, w, x, w); [IN(LINE)] set { y = value.x; w = value.y; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 ywx_ { [IN(LINE)] get => new int4(y, w, x, 0); [IN(LINE)] set { y = value.x; w = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 ywyx { [IN(LINE)] get => new int4(y, w, y, x); [IN(LINE)] set { y = value.x; w = value.y; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 ywyy { [IN(LINE)] get => new int4(y, w, y, y); [IN(LINE)] set { y = value.x; w = value.y; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 ywyz { [IN(LINE)] get => new int4(y, w, y, z); [IN(LINE)] set { y = value.x; w = value.y; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 ywyw { [IN(LINE)] get => new int4(y, w, y, w); [IN(LINE)] set { y = value.x; w = value.y; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 ywy_ { [IN(LINE)] get => new int4(y, w, y, 0); [IN(LINE)] set { y = value.x; w = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 ywzx { [IN(LINE)] get => new int4(y, w, z, x); [IN(LINE)] set { y = value.x; w = value.y; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 ywzy { [IN(LINE)] get => new int4(y, w, z, y); [IN(LINE)] set { y = value.x; w = value.y; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 ywzz { [IN(LINE)] get => new int4(y, w, z, z); [IN(LINE)] set { y = value.x; w = value.y; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 ywzw { [IN(LINE)] get => new int4(y, w, z, w); [IN(LINE)] set { y = value.x; w = value.y; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 ywz_ { [IN(LINE)] get => new int4(y, w, z, 0); [IN(LINE)] set { y = value.x; w = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 ywwx { [IN(LINE)] get => new int4(y, w, w, x); [IN(LINE)] set { y = value.x; w = value.y; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 ywwy { [IN(LINE)] get => new int4(y, w, w, y); [IN(LINE)] set { y = value.x; w = value.y; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 ywwz { [IN(LINE)] get => new int4(y, w, w, z); [IN(LINE)] set { y = value.x; w = value.y; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 ywww { [IN(LINE)] get => new int4(y, w, w, w); [IN(LINE)] set { y = value.x; w = value.y; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yww_ { [IN(LINE)] get => new int4(y, w, w, 0); [IN(LINE)] set { y = value.x; w = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yw_x { [IN(LINE)] get => new int4(y, w, 0, x); [IN(LINE)] set { y = value.x; w = value.y; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yw_y { [IN(LINE)] get => new int4(y, w, 0, y); [IN(LINE)] set { y = value.x; w = value.y; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yw_z { [IN(LINE)] get => new int4(y, w, 0, z); [IN(LINE)] set { y = value.x; w = value.y; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yw_w { [IN(LINE)] get => new int4(y, w, 0, w); [IN(LINE)] set { y = value.x; w = value.y; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 yw__ { [IN(LINE)] get => new int4(y, w, 0, 0); [IN(LINE)] set { y = value.x; w = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 y_xx { [IN(LINE)] get => new int4(y, 0, x, x); [IN(LINE)] set { y = value.x; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 y_xy { [IN(LINE)] get => new int4(y, 0, x, y); [IN(LINE)] set { y = value.x; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 y_xz { [IN(LINE)] get => new int4(y, 0, x, z); [IN(LINE)] set { y = value.x; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 y_xw { [IN(LINE)] get => new int4(y, 0, x, w); [IN(LINE)] set { y = value.x; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 y_x_ { [IN(LINE)] get => new int4(y, 0, x, 0); [IN(LINE)] set { y = value.x; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 y_yx { [IN(LINE)] get => new int4(y, 0, y, x); [IN(LINE)] set { y = value.x; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 y_yy { [IN(LINE)] get => new int4(y, 0, y, y); [IN(LINE)] set { y = value.x; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 y_yz { [IN(LINE)] get => new int4(y, 0, y, z); [IN(LINE)] set { y = value.x; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 y_yw { [IN(LINE)] get => new int4(y, 0, y, w); [IN(LINE)] set { y = value.x; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 y_y_ { [IN(LINE)] get => new int4(y, 0, y, 0); [IN(LINE)] set { y = value.x; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 y_zx { [IN(LINE)] get => new int4(y, 0, z, x); [IN(LINE)] set { y = value.x; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 y_zy { [IN(LINE)] get => new int4(y, 0, z, y); [IN(LINE)] set { y = value.x; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 y_zz { [IN(LINE)] get => new int4(y, 0, z, z); [IN(LINE)] set { y = value.x; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 y_zw { [IN(LINE)] get => new int4(y, 0, z, w); [IN(LINE)] set { y = value.x; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 y_z_ { [IN(LINE)] get => new int4(y, 0, z, 0); [IN(LINE)] set { y = value.x; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 y_wx { [IN(LINE)] get => new int4(y, 0, w, x); [IN(LINE)] set { y = value.x; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 y_wy { [IN(LINE)] get => new int4(y, 0, w, y); [IN(LINE)] set { y = value.x; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 y_wz { [IN(LINE)] get => new int4(y, 0, w, z); [IN(LINE)] set { y = value.x; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 y_ww { [IN(LINE)] get => new int4(y, 0, w, w); [IN(LINE)] set { y = value.x; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 y_w_ { [IN(LINE)] get => new int4(y, 0, w, 0); [IN(LINE)] set { y = value.x; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 y__x { [IN(LINE)] get => new int4(y, 0, 0, x); [IN(LINE)] set { y = value.x; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 y__y { [IN(LINE)] get => new int4(y, 0, 0, y); [IN(LINE)] set { y = value.x; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 y__z { [IN(LINE)] get => new int4(y, 0, 0, z); [IN(LINE)] set { y = value.x; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 y__w { [IN(LINE)] get => new int4(y, 0, 0, w); [IN(LINE)] set { y = value.x; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 y___ { [IN(LINE)] get => new int4(y, 0, 0, 0); [IN(LINE)] set { y = value.x; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxxx { [IN(LINE)] get => new int4(z, x, x, x); [IN(LINE)] set { z = value.x; x = value.y; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxxy { [IN(LINE)] get => new int4(z, x, x, y); [IN(LINE)] set { z = value.x; x = value.y; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxxz { [IN(LINE)] get => new int4(z, x, x, z); [IN(LINE)] set { z = value.x; x = value.y; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxxw { [IN(LINE)] get => new int4(z, x, x, w); [IN(LINE)] set { z = value.x; x = value.y; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxx_ { [IN(LINE)] get => new int4(z, x, x, 0); [IN(LINE)] set { z = value.x; x = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxyx { [IN(LINE)] get => new int4(z, x, y, x); [IN(LINE)] set { z = value.x; x = value.y; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxyy { [IN(LINE)] get => new int4(z, x, y, y); [IN(LINE)] set { z = value.x; x = value.y; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxyz { [IN(LINE)] get => new int4(z, x, y, z); [IN(LINE)] set { z = value.x; x = value.y; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxyw { [IN(LINE)] get => new int4(z, x, y, w); [IN(LINE)] set { z = value.x; x = value.y; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxy_ { [IN(LINE)] get => new int4(z, x, y, 0); [IN(LINE)] set { z = value.x; x = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxzx { [IN(LINE)] get => new int4(z, x, z, x); [IN(LINE)] set { z = value.x; x = value.y; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxzy { [IN(LINE)] get => new int4(z, x, z, y); [IN(LINE)] set { z = value.x; x = value.y; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxzz { [IN(LINE)] get => new int4(z, x, z, z); [IN(LINE)] set { z = value.x; x = value.y; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxzw { [IN(LINE)] get => new int4(z, x, z, w); [IN(LINE)] set { z = value.x; x = value.y; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxz_ { [IN(LINE)] get => new int4(z, x, z, 0); [IN(LINE)] set { z = value.x; x = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxwx { [IN(LINE)] get => new int4(z, x, w, x); [IN(LINE)] set { z = value.x; x = value.y; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxwy { [IN(LINE)] get => new int4(z, x, w, y); [IN(LINE)] set { z = value.x; x = value.y; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxwz { [IN(LINE)] get => new int4(z, x, w, z); [IN(LINE)] set { z = value.x; x = value.y; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxww { [IN(LINE)] get => new int4(z, x, w, w); [IN(LINE)] set { z = value.x; x = value.y; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zxw_ { [IN(LINE)] get => new int4(z, x, w, 0); [IN(LINE)] set { z = value.x; x = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zx_x { [IN(LINE)] get => new int4(z, x, 0, x); [IN(LINE)] set { z = value.x; x = value.y; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zx_y { [IN(LINE)] get => new int4(z, x, 0, y); [IN(LINE)] set { z = value.x; x = value.y; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zx_z { [IN(LINE)] get => new int4(z, x, 0, z); [IN(LINE)] set { z = value.x; x = value.y; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zx_w { [IN(LINE)] get => new int4(z, x, 0, w); [IN(LINE)] set { z = value.x; x = value.y; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zx__ { [IN(LINE)] get => new int4(z, x, 0, 0); [IN(LINE)] set { z = value.x; x = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zyxx { [IN(LINE)] get => new int4(z, y, x, x); [IN(LINE)] set { z = value.x; y = value.y; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zyxy { [IN(LINE)] get => new int4(z, y, x, y); [IN(LINE)] set { z = value.x; y = value.y; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zyxz { [IN(LINE)] get => new int4(z, y, x, z); [IN(LINE)] set { z = value.x; y = value.y; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zyxw { [IN(LINE)] get => new int4(z, y, x, w); [IN(LINE)] set { z = value.x; y = value.y; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zyx_ { [IN(LINE)] get => new int4(z, y, x, 0); [IN(LINE)] set { z = value.x; y = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zyyx { [IN(LINE)] get => new int4(z, y, y, x); [IN(LINE)] set { z = value.x; y = value.y; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zyyy { [IN(LINE)] get => new int4(z, y, y, y); [IN(LINE)] set { z = value.x; y = value.y; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zyyz { [IN(LINE)] get => new int4(z, y, y, z); [IN(LINE)] set { z = value.x; y = value.y; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zyyw { [IN(LINE)] get => new int4(z, y, y, w); [IN(LINE)] set { z = value.x; y = value.y; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zyy_ { [IN(LINE)] get => new int4(z, y, y, 0); [IN(LINE)] set { z = value.x; y = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zyzx { [IN(LINE)] get => new int4(z, y, z, x); [IN(LINE)] set { z = value.x; y = value.y; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zyzy { [IN(LINE)] get => new int4(z, y, z, y); [IN(LINE)] set { z = value.x; y = value.y; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zyzz { [IN(LINE)] get => new int4(z, y, z, z); [IN(LINE)] set { z = value.x; y = value.y; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zyzw { [IN(LINE)] get => new int4(z, y, z, w); [IN(LINE)] set { z = value.x; y = value.y; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zyz_ { [IN(LINE)] get => new int4(z, y, z, 0); [IN(LINE)] set { z = value.x; y = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zywx { [IN(LINE)] get => new int4(z, y, w, x); [IN(LINE)] set { z = value.x; y = value.y; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zywy { [IN(LINE)] get => new int4(z, y, w, y); [IN(LINE)] set { z = value.x; y = value.y; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zywz { [IN(LINE)] get => new int4(z, y, w, z); [IN(LINE)] set { z = value.x; y = value.y; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zyww { [IN(LINE)] get => new int4(z, y, w, w); [IN(LINE)] set { z = value.x; y = value.y; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zyw_ { [IN(LINE)] get => new int4(z, y, w, 0); [IN(LINE)] set { z = value.x; y = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zy_x { [IN(LINE)] get => new int4(z, y, 0, x); [IN(LINE)] set { z = value.x; y = value.y; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zy_y { [IN(LINE)] get => new int4(z, y, 0, y); [IN(LINE)] set { z = value.x; y = value.y; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zy_z { [IN(LINE)] get => new int4(z, y, 0, z); [IN(LINE)] set { z = value.x; y = value.y; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zy_w { [IN(LINE)] get => new int4(z, y, 0, w); [IN(LINE)] set { z = value.x; y = value.y; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zy__ { [IN(LINE)] get => new int4(z, y, 0, 0); [IN(LINE)] set { z = value.x; y = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzxx { [IN(LINE)] get => new int4(z, z, x, x); [IN(LINE)] set { z = value.x; z = value.y; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzxy { [IN(LINE)] get => new int4(z, z, x, y); [IN(LINE)] set { z = value.x; z = value.y; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzxz { [IN(LINE)] get => new int4(z, z, x, z); [IN(LINE)] set { z = value.x; z = value.y; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzxw { [IN(LINE)] get => new int4(z, z, x, w); [IN(LINE)] set { z = value.x; z = value.y; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzx_ { [IN(LINE)] get => new int4(z, z, x, 0); [IN(LINE)] set { z = value.x; z = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzyx { [IN(LINE)] get => new int4(z, z, y, x); [IN(LINE)] set { z = value.x; z = value.y; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzyy { [IN(LINE)] get => new int4(z, z, y, y); [IN(LINE)] set { z = value.x; z = value.y; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzyz { [IN(LINE)] get => new int4(z, z, y, z); [IN(LINE)] set { z = value.x; z = value.y; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzyw { [IN(LINE)] get => new int4(z, z, y, w); [IN(LINE)] set { z = value.x; z = value.y; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzy_ { [IN(LINE)] get => new int4(z, z, y, 0); [IN(LINE)] set { z = value.x; z = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzzx { [IN(LINE)] get => new int4(z, z, z, x); [IN(LINE)] set { z = value.x; z = value.y; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzzy { [IN(LINE)] get => new int4(z, z, z, y); [IN(LINE)] set { z = value.x; z = value.y; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzzz { [IN(LINE)] get => new int4(z, z, z, z); [IN(LINE)] set { z = value.x; z = value.y; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzzw { [IN(LINE)] get => new int4(z, z, z, w); [IN(LINE)] set { z = value.x; z = value.y; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzz_ { [IN(LINE)] get => new int4(z, z, z, 0); [IN(LINE)] set { z = value.x; z = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzwx { [IN(LINE)] get => new int4(z, z, w, x); [IN(LINE)] set { z = value.x; z = value.y; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzwy { [IN(LINE)] get => new int4(z, z, w, y); [IN(LINE)] set { z = value.x; z = value.y; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzwz { [IN(LINE)] get => new int4(z, z, w, z); [IN(LINE)] set { z = value.x; z = value.y; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzww { [IN(LINE)] get => new int4(z, z, w, w); [IN(LINE)] set { z = value.x; z = value.y; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zzw_ { [IN(LINE)] get => new int4(z, z, w, 0); [IN(LINE)] set { z = value.x; z = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zz_x { [IN(LINE)] get => new int4(z, z, 0, x); [IN(LINE)] set { z = value.x; z = value.y; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zz_y { [IN(LINE)] get => new int4(z, z, 0, y); [IN(LINE)] set { z = value.x; z = value.y; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zz_z { [IN(LINE)] get => new int4(z, z, 0, z); [IN(LINE)] set { z = value.x; z = value.y; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zz_w { [IN(LINE)] get => new int4(z, z, 0, w); [IN(LINE)] set { z = value.x; z = value.y; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zz__ { [IN(LINE)] get => new int4(z, z, 0, 0); [IN(LINE)] set { z = value.x; z = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zwxx { [IN(LINE)] get => new int4(z, w, x, x); [IN(LINE)] set { z = value.x; w = value.y; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zwxy { [IN(LINE)] get => new int4(z, w, x, y); [IN(LINE)] set { z = value.x; w = value.y; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zwxz { [IN(LINE)] get => new int4(z, w, x, z); [IN(LINE)] set { z = value.x; w = value.y; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zwxw { [IN(LINE)] get => new int4(z, w, x, w); [IN(LINE)] set { z = value.x; w = value.y; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zwx_ { [IN(LINE)] get => new int4(z, w, x, 0); [IN(LINE)] set { z = value.x; w = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zwyx { [IN(LINE)] get => new int4(z, w, y, x); [IN(LINE)] set { z = value.x; w = value.y; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zwyy { [IN(LINE)] get => new int4(z, w, y, y); [IN(LINE)] set { z = value.x; w = value.y; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zwyz { [IN(LINE)] get => new int4(z, w, y, z); [IN(LINE)] set { z = value.x; w = value.y; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zwyw { [IN(LINE)] get => new int4(z, w, y, w); [IN(LINE)] set { z = value.x; w = value.y; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zwy_ { [IN(LINE)] get => new int4(z, w, y, 0); [IN(LINE)] set { z = value.x; w = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zwzx { [IN(LINE)] get => new int4(z, w, z, x); [IN(LINE)] set { z = value.x; w = value.y; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zwzy { [IN(LINE)] get => new int4(z, w, z, y); [IN(LINE)] set { z = value.x; w = value.y; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zwzz { [IN(LINE)] get => new int4(z, w, z, z); [IN(LINE)] set { z = value.x; w = value.y; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zwzw { [IN(LINE)] get => new int4(z, w, z, w); [IN(LINE)] set { z = value.x; w = value.y; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zwz_ { [IN(LINE)] get => new int4(z, w, z, 0); [IN(LINE)] set { z = value.x; w = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zwwx { [IN(LINE)] get => new int4(z, w, w, x); [IN(LINE)] set { z = value.x; w = value.y; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zwwy { [IN(LINE)] get => new int4(z, w, w, y); [IN(LINE)] set { z = value.x; w = value.y; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zwwz { [IN(LINE)] get => new int4(z, w, w, z); [IN(LINE)] set { z = value.x; w = value.y; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zwww { [IN(LINE)] get => new int4(z, w, w, w); [IN(LINE)] set { z = value.x; w = value.y; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zww_ { [IN(LINE)] get => new int4(z, w, w, 0); [IN(LINE)] set { z = value.x; w = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zw_x { [IN(LINE)] get => new int4(z, w, 0, x); [IN(LINE)] set { z = value.x; w = value.y; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zw_y { [IN(LINE)] get => new int4(z, w, 0, y); [IN(LINE)] set { z = value.x; w = value.y; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zw_z { [IN(LINE)] get => new int4(z, w, 0, z); [IN(LINE)] set { z = value.x; w = value.y; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zw_w { [IN(LINE)] get => new int4(z, w, 0, w); [IN(LINE)] set { z = value.x; w = value.y; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 zw__ { [IN(LINE)] get => new int4(z, w, 0, 0); [IN(LINE)] set { z = value.x; w = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 z_xx { [IN(LINE)] get => new int4(z, 0, x, x); [IN(LINE)] set { z = value.x; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 z_xy { [IN(LINE)] get => new int4(z, 0, x, y); [IN(LINE)] set { z = value.x; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 z_xz { [IN(LINE)] get => new int4(z, 0, x, z); [IN(LINE)] set { z = value.x; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 z_xw { [IN(LINE)] get => new int4(z, 0, x, w); [IN(LINE)] set { z = value.x; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 z_x_ { [IN(LINE)] get => new int4(z, 0, x, 0); [IN(LINE)] set { z = value.x; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 z_yx { [IN(LINE)] get => new int4(z, 0, y, x); [IN(LINE)] set { z = value.x; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 z_yy { [IN(LINE)] get => new int4(z, 0, y, y); [IN(LINE)] set { z = value.x; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 z_yz { [IN(LINE)] get => new int4(z, 0, y, z); [IN(LINE)] set { z = value.x; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 z_yw { [IN(LINE)] get => new int4(z, 0, y, w); [IN(LINE)] set { z = value.x; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 z_y_ { [IN(LINE)] get => new int4(z, 0, y, 0); [IN(LINE)] set { z = value.x; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 z_zx { [IN(LINE)] get => new int4(z, 0, z, x); [IN(LINE)] set { z = value.x; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 z_zy { [IN(LINE)] get => new int4(z, 0, z, y); [IN(LINE)] set { z = value.x; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 z_zz { [IN(LINE)] get => new int4(z, 0, z, z); [IN(LINE)] set { z = value.x; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 z_zw { [IN(LINE)] get => new int4(z, 0, z, w); [IN(LINE)] set { z = value.x; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 z_z_ { [IN(LINE)] get => new int4(z, 0, z, 0); [IN(LINE)] set { z = value.x; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 z_wx { [IN(LINE)] get => new int4(z, 0, w, x); [IN(LINE)] set { z = value.x; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 z_wy { [IN(LINE)] get => new int4(z, 0, w, y); [IN(LINE)] set { z = value.x; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 z_wz { [IN(LINE)] get => new int4(z, 0, w, z); [IN(LINE)] set { z = value.x; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 z_ww { [IN(LINE)] get => new int4(z, 0, w, w); [IN(LINE)] set { z = value.x; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 z_w_ { [IN(LINE)] get => new int4(z, 0, w, 0); [IN(LINE)] set { z = value.x; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 z__x { [IN(LINE)] get => new int4(z, 0, 0, x); [IN(LINE)] set { z = value.x; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 z__y { [IN(LINE)] get => new int4(z, 0, 0, y); [IN(LINE)] set { z = value.x; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 z__z { [IN(LINE)] get => new int4(z, 0, 0, z); [IN(LINE)] set { z = value.x; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 z__w { [IN(LINE)] get => new int4(z, 0, 0, w); [IN(LINE)] set { z = value.x; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 z___ { [IN(LINE)] get => new int4(z, 0, 0, 0); [IN(LINE)] set { z = value.x; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wxxx { [IN(LINE)] get => new int4(w, x, x, x); [IN(LINE)] set { w = value.x; x = value.y; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wxxy { [IN(LINE)] get => new int4(w, x, x, y); [IN(LINE)] set { w = value.x; x = value.y; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wxxz { [IN(LINE)] get => new int4(w, x, x, z); [IN(LINE)] set { w = value.x; x = value.y; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wxxw { [IN(LINE)] get => new int4(w, x, x, w); [IN(LINE)] set { w = value.x; x = value.y; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wxx_ { [IN(LINE)] get => new int4(w, x, x, 0); [IN(LINE)] set { w = value.x; x = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wxyx { [IN(LINE)] get => new int4(w, x, y, x); [IN(LINE)] set { w = value.x; x = value.y; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wxyy { [IN(LINE)] get => new int4(w, x, y, y); [IN(LINE)] set { w = value.x; x = value.y; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wxyz { [IN(LINE)] get => new int4(w, x, y, z); [IN(LINE)] set { w = value.x; x = value.y; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wxyw { [IN(LINE)] get => new int4(w, x, y, w); [IN(LINE)] set { w = value.x; x = value.y; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wxy_ { [IN(LINE)] get => new int4(w, x, y, 0); [IN(LINE)] set { w = value.x; x = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wxzx { [IN(LINE)] get => new int4(w, x, z, x); [IN(LINE)] set { w = value.x; x = value.y; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wxzy { [IN(LINE)] get => new int4(w, x, z, y); [IN(LINE)] set { w = value.x; x = value.y; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wxzz { [IN(LINE)] get => new int4(w, x, z, z); [IN(LINE)] set { w = value.x; x = value.y; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wxzw { [IN(LINE)] get => new int4(w, x, z, w); [IN(LINE)] set { w = value.x; x = value.y; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wxz_ { [IN(LINE)] get => new int4(w, x, z, 0); [IN(LINE)] set { w = value.x; x = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wxwx { [IN(LINE)] get => new int4(w, x, w, x); [IN(LINE)] set { w = value.x; x = value.y; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wxwy { [IN(LINE)] get => new int4(w, x, w, y); [IN(LINE)] set { w = value.x; x = value.y; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wxwz { [IN(LINE)] get => new int4(w, x, w, z); [IN(LINE)] set { w = value.x; x = value.y; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wxww { [IN(LINE)] get => new int4(w, x, w, w); [IN(LINE)] set { w = value.x; x = value.y; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wxw_ { [IN(LINE)] get => new int4(w, x, w, 0); [IN(LINE)] set { w = value.x; x = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wx_x { [IN(LINE)] get => new int4(w, x, 0, x); [IN(LINE)] set { w = value.x; x = value.y; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wx_y { [IN(LINE)] get => new int4(w, x, 0, y); [IN(LINE)] set { w = value.x; x = value.y; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wx_z { [IN(LINE)] get => new int4(w, x, 0, z); [IN(LINE)] set { w = value.x; x = value.y; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wx_w { [IN(LINE)] get => new int4(w, x, 0, w); [IN(LINE)] set { w = value.x; x = value.y; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wx__ { [IN(LINE)] get => new int4(w, x, 0, 0); [IN(LINE)] set { w = value.x; x = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wyxx { [IN(LINE)] get => new int4(w, y, x, x); [IN(LINE)] set { w = value.x; y = value.y; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wyxy { [IN(LINE)] get => new int4(w, y, x, y); [IN(LINE)] set { w = value.x; y = value.y; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wyxz { [IN(LINE)] get => new int4(w, y, x, z); [IN(LINE)] set { w = value.x; y = value.y; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wyxw { [IN(LINE)] get => new int4(w, y, x, w); [IN(LINE)] set { w = value.x; y = value.y; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wyx_ { [IN(LINE)] get => new int4(w, y, x, 0); [IN(LINE)] set { w = value.x; y = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wyyx { [IN(LINE)] get => new int4(w, y, y, x); [IN(LINE)] set { w = value.x; y = value.y; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wyyy { [IN(LINE)] get => new int4(w, y, y, y); [IN(LINE)] set { w = value.x; y = value.y; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wyyz { [IN(LINE)] get => new int4(w, y, y, z); [IN(LINE)] set { w = value.x; y = value.y; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wyyw { [IN(LINE)] get => new int4(w, y, y, w); [IN(LINE)] set { w = value.x; y = value.y; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wyy_ { [IN(LINE)] get => new int4(w, y, y, 0); [IN(LINE)] set { w = value.x; y = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wyzx { [IN(LINE)] get => new int4(w, y, z, x); [IN(LINE)] set { w = value.x; y = value.y; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wyzy { [IN(LINE)] get => new int4(w, y, z, y); [IN(LINE)] set { w = value.x; y = value.y; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wyzz { [IN(LINE)] get => new int4(w, y, z, z); [IN(LINE)] set { w = value.x; y = value.y; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wyzw { [IN(LINE)] get => new int4(w, y, z, w); [IN(LINE)] set { w = value.x; y = value.y; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wyz_ { [IN(LINE)] get => new int4(w, y, z, 0); [IN(LINE)] set { w = value.x; y = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wywx { [IN(LINE)] get => new int4(w, y, w, x); [IN(LINE)] set { w = value.x; y = value.y; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wywy { [IN(LINE)] get => new int4(w, y, w, y); [IN(LINE)] set { w = value.x; y = value.y; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wywz { [IN(LINE)] get => new int4(w, y, w, z); [IN(LINE)] set { w = value.x; y = value.y; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wyww { [IN(LINE)] get => new int4(w, y, w, w); [IN(LINE)] set { w = value.x; y = value.y; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wyw_ { [IN(LINE)] get => new int4(w, y, w, 0); [IN(LINE)] set { w = value.x; y = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wy_x { [IN(LINE)] get => new int4(w, y, 0, x); [IN(LINE)] set { w = value.x; y = value.y; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wy_y { [IN(LINE)] get => new int4(w, y, 0, y); [IN(LINE)] set { w = value.x; y = value.y; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wy_z { [IN(LINE)] get => new int4(w, y, 0, z); [IN(LINE)] set { w = value.x; y = value.y; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wy_w { [IN(LINE)] get => new int4(w, y, 0, w); [IN(LINE)] set { w = value.x; y = value.y; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wy__ { [IN(LINE)] get => new int4(w, y, 0, 0); [IN(LINE)] set { w = value.x; y = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wzxx { [IN(LINE)] get => new int4(w, z, x, x); [IN(LINE)] set { w = value.x; z = value.y; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wzxy { [IN(LINE)] get => new int4(w, z, x, y); [IN(LINE)] set { w = value.x; z = value.y; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wzxz { [IN(LINE)] get => new int4(w, z, x, z); [IN(LINE)] set { w = value.x; z = value.y; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wzxw { [IN(LINE)] get => new int4(w, z, x, w); [IN(LINE)] set { w = value.x; z = value.y; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wzx_ { [IN(LINE)] get => new int4(w, z, x, 0); [IN(LINE)] set { w = value.x; z = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wzyx { [IN(LINE)] get => new int4(w, z, y, x); [IN(LINE)] set { w = value.x; z = value.y; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wzyy { [IN(LINE)] get => new int4(w, z, y, y); [IN(LINE)] set { w = value.x; z = value.y; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wzyz { [IN(LINE)] get => new int4(w, z, y, z); [IN(LINE)] set { w = value.x; z = value.y; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wzyw { [IN(LINE)] get => new int4(w, z, y, w); [IN(LINE)] set { w = value.x; z = value.y; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wzy_ { [IN(LINE)] get => new int4(w, z, y, 0); [IN(LINE)] set { w = value.x; z = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wzzx { [IN(LINE)] get => new int4(w, z, z, x); [IN(LINE)] set { w = value.x; z = value.y; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wzzy { [IN(LINE)] get => new int4(w, z, z, y); [IN(LINE)] set { w = value.x; z = value.y; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wzzz { [IN(LINE)] get => new int4(w, z, z, z); [IN(LINE)] set { w = value.x; z = value.y; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wzzw { [IN(LINE)] get => new int4(w, z, z, w); [IN(LINE)] set { w = value.x; z = value.y; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wzz_ { [IN(LINE)] get => new int4(w, z, z, 0); [IN(LINE)] set { w = value.x; z = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wzwx { [IN(LINE)] get => new int4(w, z, w, x); [IN(LINE)] set { w = value.x; z = value.y; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wzwy { [IN(LINE)] get => new int4(w, z, w, y); [IN(LINE)] set { w = value.x; z = value.y; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wzwz { [IN(LINE)] get => new int4(w, z, w, z); [IN(LINE)] set { w = value.x; z = value.y; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wzww { [IN(LINE)] get => new int4(w, z, w, w); [IN(LINE)] set { w = value.x; z = value.y; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wzw_ { [IN(LINE)] get => new int4(w, z, w, 0); [IN(LINE)] set { w = value.x; z = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wz_x { [IN(LINE)] get => new int4(w, z, 0, x); [IN(LINE)] set { w = value.x; z = value.y; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wz_y { [IN(LINE)] get => new int4(w, z, 0, y); [IN(LINE)] set { w = value.x; z = value.y; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wz_z { [IN(LINE)] get => new int4(w, z, 0, z); [IN(LINE)] set { w = value.x; z = value.y; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wz_w { [IN(LINE)] get => new int4(w, z, 0, w); [IN(LINE)] set { w = value.x; z = value.y; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wz__ { [IN(LINE)] get => new int4(w, z, 0, 0); [IN(LINE)] set { w = value.x; z = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wwxx { [IN(LINE)] get => new int4(w, w, x, x); [IN(LINE)] set { w = value.x; w = value.y; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wwxy { [IN(LINE)] get => new int4(w, w, x, y); [IN(LINE)] set { w = value.x; w = value.y; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wwxz { [IN(LINE)] get => new int4(w, w, x, z); [IN(LINE)] set { w = value.x; w = value.y; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wwxw { [IN(LINE)] get => new int4(w, w, x, w); [IN(LINE)] set { w = value.x; w = value.y; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wwx_ { [IN(LINE)] get => new int4(w, w, x, 0); [IN(LINE)] set { w = value.x; w = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wwyx { [IN(LINE)] get => new int4(w, w, y, x); [IN(LINE)] set { w = value.x; w = value.y; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wwyy { [IN(LINE)] get => new int4(w, w, y, y); [IN(LINE)] set { w = value.x; w = value.y; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wwyz { [IN(LINE)] get => new int4(w, w, y, z); [IN(LINE)] set { w = value.x; w = value.y; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wwyw { [IN(LINE)] get => new int4(w, w, y, w); [IN(LINE)] set { w = value.x; w = value.y; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wwy_ { [IN(LINE)] get => new int4(w, w, y, 0); [IN(LINE)] set { w = value.x; w = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wwzx { [IN(LINE)] get => new int4(w, w, z, x); [IN(LINE)] set { w = value.x; w = value.y; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wwzy { [IN(LINE)] get => new int4(w, w, z, y); [IN(LINE)] set { w = value.x; w = value.y; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wwzz { [IN(LINE)] get => new int4(w, w, z, z); [IN(LINE)] set { w = value.x; w = value.y; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wwzw { [IN(LINE)] get => new int4(w, w, z, w); [IN(LINE)] set { w = value.x; w = value.y; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wwz_ { [IN(LINE)] get => new int4(w, w, z, 0); [IN(LINE)] set { w = value.x; w = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wwwx { [IN(LINE)] get => new int4(w, w, w, x); [IN(LINE)] set { w = value.x; w = value.y; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wwwy { [IN(LINE)] get => new int4(w, w, w, y); [IN(LINE)] set { w = value.x; w = value.y; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wwwz { [IN(LINE)] get => new int4(w, w, w, z); [IN(LINE)] set { w = value.x; w = value.y; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 wwww { [IN(LINE)] get => new int4(w, w, w, w); [IN(LINE)] set { w = value.x; w = value.y; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 www_ { [IN(LINE)] get => new int4(w, w, w, 0); [IN(LINE)] set { w = value.x; w = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 ww_x { [IN(LINE)] get => new int4(w, w, 0, x); [IN(LINE)] set { w = value.x; w = value.y; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 ww_y { [IN(LINE)] get => new int4(w, w, 0, y); [IN(LINE)] set { w = value.x; w = value.y; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 ww_z { [IN(LINE)] get => new int4(w, w, 0, z); [IN(LINE)] set { w = value.x; w = value.y; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 ww_w { [IN(LINE)] get => new int4(w, w, 0, w); [IN(LINE)] set { w = value.x; w = value.y; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 ww__ { [IN(LINE)] get => new int4(w, w, 0, 0); [IN(LINE)] set { w = value.x; w = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 w_xx { [IN(LINE)] get => new int4(w, 0, x, x); [IN(LINE)] set { w = value.x; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 w_xy { [IN(LINE)] get => new int4(w, 0, x, y); [IN(LINE)] set { w = value.x; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 w_xz { [IN(LINE)] get => new int4(w, 0, x, z); [IN(LINE)] set { w = value.x; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 w_xw { [IN(LINE)] get => new int4(w, 0, x, w); [IN(LINE)] set { w = value.x; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 w_x_ { [IN(LINE)] get => new int4(w, 0, x, 0); [IN(LINE)] set { w = value.x; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 w_yx { [IN(LINE)] get => new int4(w, 0, y, x); [IN(LINE)] set { w = value.x; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 w_yy { [IN(LINE)] get => new int4(w, 0, y, y); [IN(LINE)] set { w = value.x; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 w_yz { [IN(LINE)] get => new int4(w, 0, y, z); [IN(LINE)] set { w = value.x; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 w_yw { [IN(LINE)] get => new int4(w, 0, y, w); [IN(LINE)] set { w = value.x; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 w_y_ { [IN(LINE)] get => new int4(w, 0, y, 0); [IN(LINE)] set { w = value.x; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 w_zx { [IN(LINE)] get => new int4(w, 0, z, x); [IN(LINE)] set { w = value.x; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 w_zy { [IN(LINE)] get => new int4(w, 0, z, y); [IN(LINE)] set { w = value.x; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 w_zz { [IN(LINE)] get => new int4(w, 0, z, z); [IN(LINE)] set { w = value.x; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 w_zw { [IN(LINE)] get => new int4(w, 0, z, w); [IN(LINE)] set { w = value.x; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 w_z_ { [IN(LINE)] get => new int4(w, 0, z, 0); [IN(LINE)] set { w = value.x; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 w_wx { [IN(LINE)] get => new int4(w, 0, w, x); [IN(LINE)] set { w = value.x; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 w_wy { [IN(LINE)] get => new int4(w, 0, w, y); [IN(LINE)] set { w = value.x; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 w_wz { [IN(LINE)] get => new int4(w, 0, w, z); [IN(LINE)] set { w = value.x; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 w_ww { [IN(LINE)] get => new int4(w, 0, w, w); [IN(LINE)] set { w = value.x; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 w_w_ { [IN(LINE)] get => new int4(w, 0, w, 0); [IN(LINE)] set { w = value.x; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 w__x { [IN(LINE)] get => new int4(w, 0, 0, x); [IN(LINE)] set { w = value.x; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 w__y { [IN(LINE)] get => new int4(w, 0, 0, y); [IN(LINE)] set { w = value.x; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 w__z { [IN(LINE)] get => new int4(w, 0, 0, z); [IN(LINE)] set { w = value.x; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 w__w { [IN(LINE)] get => new int4(w, 0, 0, w); [IN(LINE)] set { w = value.x; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 w___ { [IN(LINE)] get => new int4(w, 0, 0, 0); [IN(LINE)] set { w = value.x; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _xxx { [IN(LINE)] get => new int4(0, x, x, x); [IN(LINE)] set { x = value.y; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _xxy { [IN(LINE)] get => new int4(0, x, x, y); [IN(LINE)] set { x = value.y; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _xxz { [IN(LINE)] get => new int4(0, x, x, z); [IN(LINE)] set { x = value.y; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _xxw { [IN(LINE)] get => new int4(0, x, x, w); [IN(LINE)] set { x = value.y; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _xx_ { [IN(LINE)] get => new int4(0, x, x, 0); [IN(LINE)] set { x = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _xyx { [IN(LINE)] get => new int4(0, x, y, x); [IN(LINE)] set { x = value.y; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _xyy { [IN(LINE)] get => new int4(0, x, y, y); [IN(LINE)] set { x = value.y; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _xyz { [IN(LINE)] get => new int4(0, x, y, z); [IN(LINE)] set { x = value.y; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _xyw { [IN(LINE)] get => new int4(0, x, y, w); [IN(LINE)] set { x = value.y; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _xy_ { [IN(LINE)] get => new int4(0, x, y, 0); [IN(LINE)] set { x = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _xzx { [IN(LINE)] get => new int4(0, x, z, x); [IN(LINE)] set { x = value.y; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _xzy { [IN(LINE)] get => new int4(0, x, z, y); [IN(LINE)] set { x = value.y; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _xzz { [IN(LINE)] get => new int4(0, x, z, z); [IN(LINE)] set { x = value.y; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _xzw { [IN(LINE)] get => new int4(0, x, z, w); [IN(LINE)] set { x = value.y; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _xz_ { [IN(LINE)] get => new int4(0, x, z, 0); [IN(LINE)] set { x = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _xwx { [IN(LINE)] get => new int4(0, x, w, x); [IN(LINE)] set { x = value.y; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _xwy { [IN(LINE)] get => new int4(0, x, w, y); [IN(LINE)] set { x = value.y; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _xwz { [IN(LINE)] get => new int4(0, x, w, z); [IN(LINE)] set { x = value.y; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _xww { [IN(LINE)] get => new int4(0, x, w, w); [IN(LINE)] set { x = value.y; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _xw_ { [IN(LINE)] get => new int4(0, x, w, 0); [IN(LINE)] set { x = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _x_x { [IN(LINE)] get => new int4(0, x, 0, x); [IN(LINE)] set { x = value.y; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _x_y { [IN(LINE)] get => new int4(0, x, 0, y); [IN(LINE)] set { x = value.y; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _x_z { [IN(LINE)] get => new int4(0, x, 0, z); [IN(LINE)] set { x = value.y; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _x_w { [IN(LINE)] get => new int4(0, x, 0, w); [IN(LINE)] set { x = value.y; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _x__ { [IN(LINE)] get => new int4(0, x, 0, 0); [IN(LINE)] set { x = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _yxx { [IN(LINE)] get => new int4(0, y, x, x); [IN(LINE)] set { y = value.y; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _yxy { [IN(LINE)] get => new int4(0, y, x, y); [IN(LINE)] set { y = value.y; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _yxz { [IN(LINE)] get => new int4(0, y, x, z); [IN(LINE)] set { y = value.y; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _yxw { [IN(LINE)] get => new int4(0, y, x, w); [IN(LINE)] set { y = value.y; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _yx_ { [IN(LINE)] get => new int4(0, y, x, 0); [IN(LINE)] set { y = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _yyx { [IN(LINE)] get => new int4(0, y, y, x); [IN(LINE)] set { y = value.y; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _yyy { [IN(LINE)] get => new int4(0, y, y, y); [IN(LINE)] set { y = value.y; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _yyz { [IN(LINE)] get => new int4(0, y, y, z); [IN(LINE)] set { y = value.y; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _yyw { [IN(LINE)] get => new int4(0, y, y, w); [IN(LINE)] set { y = value.y; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _yy_ { [IN(LINE)] get => new int4(0, y, y, 0); [IN(LINE)] set { y = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _yzx { [IN(LINE)] get => new int4(0, y, z, x); [IN(LINE)] set { y = value.y; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _yzy { [IN(LINE)] get => new int4(0, y, z, y); [IN(LINE)] set { y = value.y; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _yzz { [IN(LINE)] get => new int4(0, y, z, z); [IN(LINE)] set { y = value.y; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _yzw { [IN(LINE)] get => new int4(0, y, z, w); [IN(LINE)] set { y = value.y; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _yz_ { [IN(LINE)] get => new int4(0, y, z, 0); [IN(LINE)] set { y = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _ywx { [IN(LINE)] get => new int4(0, y, w, x); [IN(LINE)] set { y = value.y; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _ywy { [IN(LINE)] get => new int4(0, y, w, y); [IN(LINE)] set { y = value.y; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _ywz { [IN(LINE)] get => new int4(0, y, w, z); [IN(LINE)] set { y = value.y; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _yww { [IN(LINE)] get => new int4(0, y, w, w); [IN(LINE)] set { y = value.y; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _yw_ { [IN(LINE)] get => new int4(0, y, w, 0); [IN(LINE)] set { y = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _y_x { [IN(LINE)] get => new int4(0, y, 0, x); [IN(LINE)] set { y = value.y; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _y_y { [IN(LINE)] get => new int4(0, y, 0, y); [IN(LINE)] set { y = value.y; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _y_z { [IN(LINE)] get => new int4(0, y, 0, z); [IN(LINE)] set { y = value.y; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _y_w { [IN(LINE)] get => new int4(0, y, 0, w); [IN(LINE)] set { y = value.y; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _y__ { [IN(LINE)] get => new int4(0, y, 0, 0); [IN(LINE)] set { y = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _zxx { [IN(LINE)] get => new int4(0, z, x, x); [IN(LINE)] set { z = value.y; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _zxy { [IN(LINE)] get => new int4(0, z, x, y); [IN(LINE)] set { z = value.y; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _zxz { [IN(LINE)] get => new int4(0, z, x, z); [IN(LINE)] set { z = value.y; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _zxw { [IN(LINE)] get => new int4(0, z, x, w); [IN(LINE)] set { z = value.y; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _zx_ { [IN(LINE)] get => new int4(0, z, x, 0); [IN(LINE)] set { z = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _zyx { [IN(LINE)] get => new int4(0, z, y, x); [IN(LINE)] set { z = value.y; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _zyy { [IN(LINE)] get => new int4(0, z, y, y); [IN(LINE)] set { z = value.y; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _zyz { [IN(LINE)] get => new int4(0, z, y, z); [IN(LINE)] set { z = value.y; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _zyw { [IN(LINE)] get => new int4(0, z, y, w); [IN(LINE)] set { z = value.y; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _zy_ { [IN(LINE)] get => new int4(0, z, y, 0); [IN(LINE)] set { z = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _zzx { [IN(LINE)] get => new int4(0, z, z, x); [IN(LINE)] set { z = value.y; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _zzy { [IN(LINE)] get => new int4(0, z, z, y); [IN(LINE)] set { z = value.y; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _zzz { [IN(LINE)] get => new int4(0, z, z, z); [IN(LINE)] set { z = value.y; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _zzw { [IN(LINE)] get => new int4(0, z, z, w); [IN(LINE)] set { z = value.y; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _zz_ { [IN(LINE)] get => new int4(0, z, z, 0); [IN(LINE)] set { z = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _zwx { [IN(LINE)] get => new int4(0, z, w, x); [IN(LINE)] set { z = value.y; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _zwy { [IN(LINE)] get => new int4(0, z, w, y); [IN(LINE)] set { z = value.y; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _zwz { [IN(LINE)] get => new int4(0, z, w, z); [IN(LINE)] set { z = value.y; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _zww { [IN(LINE)] get => new int4(0, z, w, w); [IN(LINE)] set { z = value.y; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _zw_ { [IN(LINE)] get => new int4(0, z, w, 0); [IN(LINE)] set { z = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _z_x { [IN(LINE)] get => new int4(0, z, 0, x); [IN(LINE)] set { z = value.y; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _z_y { [IN(LINE)] get => new int4(0, z, 0, y); [IN(LINE)] set { z = value.y; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _z_z { [IN(LINE)] get => new int4(0, z, 0, z); [IN(LINE)] set { z = value.y; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _z_w { [IN(LINE)] get => new int4(0, z, 0, w); [IN(LINE)] set { z = value.y; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _z__ { [IN(LINE)] get => new int4(0, z, 0, 0); [IN(LINE)] set { z = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _wxx { [IN(LINE)] get => new int4(0, w, x, x); [IN(LINE)] set { w = value.y; x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _wxy { [IN(LINE)] get => new int4(0, w, x, y); [IN(LINE)] set { w = value.y; x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _wxz { [IN(LINE)] get => new int4(0, w, x, z); [IN(LINE)] set { w = value.y; x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _wxw { [IN(LINE)] get => new int4(0, w, x, w); [IN(LINE)] set { w = value.y; x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _wx_ { [IN(LINE)] get => new int4(0, w, x, 0); [IN(LINE)] set { w = value.y; x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _wyx { [IN(LINE)] get => new int4(0, w, y, x); [IN(LINE)] set { w = value.y; y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _wyy { [IN(LINE)] get => new int4(0, w, y, y); [IN(LINE)] set { w = value.y; y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _wyz { [IN(LINE)] get => new int4(0, w, y, z); [IN(LINE)] set { w = value.y; y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _wyw { [IN(LINE)] get => new int4(0, w, y, w); [IN(LINE)] set { w = value.y; y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _wy_ { [IN(LINE)] get => new int4(0, w, y, 0); [IN(LINE)] set { w = value.y; y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _wzx { [IN(LINE)] get => new int4(0, w, z, x); [IN(LINE)] set { w = value.y; z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _wzy { [IN(LINE)] get => new int4(0, w, z, y); [IN(LINE)] set { w = value.y; z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _wzz { [IN(LINE)] get => new int4(0, w, z, z); [IN(LINE)] set { w = value.y; z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _wzw { [IN(LINE)] get => new int4(0, w, z, w); [IN(LINE)] set { w = value.y; z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _wz_ { [IN(LINE)] get => new int4(0, w, z, 0); [IN(LINE)] set { w = value.y; z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _wwx { [IN(LINE)] get => new int4(0, w, w, x); [IN(LINE)] set { w = value.y; w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _wwy { [IN(LINE)] get => new int4(0, w, w, y); [IN(LINE)] set { w = value.y; w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _wwz { [IN(LINE)] get => new int4(0, w, w, z); [IN(LINE)] set { w = value.y; w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _www { [IN(LINE)] get => new int4(0, w, w, w); [IN(LINE)] set { w = value.y; w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _ww_ { [IN(LINE)] get => new int4(0, w, w, 0); [IN(LINE)] set { w = value.y; w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _w_x { [IN(LINE)] get => new int4(0, w, 0, x); [IN(LINE)] set { w = value.y; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _w_y { [IN(LINE)] get => new int4(0, w, 0, y); [IN(LINE)] set { w = value.y; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _w_z { [IN(LINE)] get => new int4(0, w, 0, z); [IN(LINE)] set { w = value.y; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _w_w { [IN(LINE)] get => new int4(0, w, 0, w); [IN(LINE)] set { w = value.y; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 _w__ { [IN(LINE)] get => new int4(0, w, 0, 0); [IN(LINE)] set { w = value.y; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 __xx { [IN(LINE)] get => new int4(0, 0, x, x); [IN(LINE)] set { x = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 __xy { [IN(LINE)] get => new int4(0, 0, x, y); [IN(LINE)] set { x = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 __xz { [IN(LINE)] get => new int4(0, 0, x, z); [IN(LINE)] set { x = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 __xw { [IN(LINE)] get => new int4(0, 0, x, w); [IN(LINE)] set { x = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 __x_ { [IN(LINE)] get => new int4(0, 0, x, 0); [IN(LINE)] set { x = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 __yx { [IN(LINE)] get => new int4(0, 0, y, x); [IN(LINE)] set { y = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 __yy { [IN(LINE)] get => new int4(0, 0, y, y); [IN(LINE)] set { y = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 __yz { [IN(LINE)] get => new int4(0, 0, y, z); [IN(LINE)] set { y = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 __yw { [IN(LINE)] get => new int4(0, 0, y, w); [IN(LINE)] set { y = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 __y_ { [IN(LINE)] get => new int4(0, 0, y, 0); [IN(LINE)] set { y = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 __zx { [IN(LINE)] get => new int4(0, 0, z, x); [IN(LINE)] set { z = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 __zy { [IN(LINE)] get => new int4(0, 0, z, y); [IN(LINE)] set { z = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 __zz { [IN(LINE)] get => new int4(0, 0, z, z); [IN(LINE)] set { z = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 __zw { [IN(LINE)] get => new int4(0, 0, z, w); [IN(LINE)] set { z = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 __z_ { [IN(LINE)] get => new int4(0, 0, z, 0); [IN(LINE)] set { z = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 __wx { [IN(LINE)] get => new int4(0, 0, w, x); [IN(LINE)] set { w = value.z; x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 __wy { [IN(LINE)] get => new int4(0, 0, w, y); [IN(LINE)] set { w = value.z; y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 __wz { [IN(LINE)] get => new int4(0, 0, w, z); [IN(LINE)] set { w = value.z; z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 __ww { [IN(LINE)] get => new int4(0, 0, w, w); [IN(LINE)] set { w = value.z; w = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 __w_ { [IN(LINE)] get => new int4(0, 0, w, 0); [IN(LINE)] set { w = value.z; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 ___x { [IN(LINE)] get => new int4(0, 0, 0, x); [IN(LINE)] set { x = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 ___y { [IN(LINE)] get => new int4(0, 0, 0, y); [IN(LINE)] set { y = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 ___z { [IN(LINE)] get => new int4(0, 0, 0, z); [IN(LINE)] set { z = value.w; } }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int4 ___w { [IN(LINE)] get => new int4(0, 0, 0, w); [IN(LINE)] set { w = value.w; } }
        #endregion

        #endregion


        #region Other
        [IN(LINE)]
        public /*readonly*/ void CopyTo(Span<int> destination)
        {
#if DEBUG || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
            if (destination.Length < Count) { Throw.ArgumentDestinationTooShort(); }
#endif

#if UNITY_5_3_OR_NEWER
            destination[0] = x; destination[1] = y; destination[2] = z; destination[3] = w;
#else
            Unsafe.WriteUnaligned(ref Unsafe.As<int, byte>(ref MemoryMarshal.GetReference(destination)), this);
#endif
        }
        [IN(LINE)] public override int GetHashCode() { return DM.Hash(this); }
        public override bool Equals(object o) { return o is int4 target && Equals(target); }
        [IN(LINE)] public bool Equals(int4 a) { return x == a.x && y == a.y && z == a.z && w == a.w; }
        public override string ToString() { return $"int4({x}, {y}, {z}, {w})"; }
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"int4({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)}, {w.ToString(format, formatProvider)})";
        }

        internal class DebuggerProxy
        {
            public int x, y, z, w;
            public DebuggerProxy(int4 v) { x = v.x; y = v.y; z = v.z; w = v.w; }
        }
        #endregion

        #region Enumerator
        VectorEnumerator<int, int4> GetEnumerator() { return new VectorEnumerator<int, int4>(this); }
        VectorEnumerator<int, int4> IEnumerableVector<int, int4>.GetEnumerator() { return new VectorEnumerator<int, int4>(this); }
        IEnumerator<int> IEnumerable<int>.GetEnumerator() { return new VectorEnumerator<int, int4>(this); }
        IEnumerator IEnumerable.GetEnumerator() { return new VectorEnumerator<int, int4>(this); }
        #endregion
    }
}