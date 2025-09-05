#if DISABLE_DEBUG
#undef DEBUG
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
#if ENABLE_IL2CPP
using Unity.IL2CPP.CompilerServices;
#endif

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
    public partial struct float4 :
        IEquatable<float4>,
        IFormattable,
        IVector4Impl<float>,
        IColor,
        IEnumerableVector<float, float4>
    {
        #region Consts
        public const int Count = 4;

        ///<summary>(0, 0, 0, 0)</summary>
        public static readonly float4 zero = new float4(0f, 0f, 0f, 0f);
        ///<summary>(1, 1, 1, 1)</summary>
        public static readonly float4 one = new float4(1f, 1f, 1f, 1f);

        ///<summary>(-1, 0, 0, 0)</summary>
        public static readonly float4 left = new float4(unchecked((float)-1f), 0f, 0f, 0f);
        ///<summary>(1, 0, 0, 0)</summary>
        public static readonly float4 right = new float4(1f, 0f, 0f, 0f);
        ///<summary>(0, -1, 0, 0)</summary>
        public static readonly float4 down = new float4(0f, unchecked((float)-1f), 0f, 0f);
        ///<summary>(0, 1, 0, 0)</summary>
        public static readonly float4 up = new float4(0f, 1f, 0f, 0f);
        ///<summary>(0, 0, -1, 0)</summary>
        public static readonly float4 back = new float4(0f, 0f, unchecked((float)-1f), 0f);
        ///<summary>(0, 0, 1, 0)</summary>
        public static readonly float4 forward = new float4(0f, 0f, 1f, 0f);
        ///<summary>(0, 0, 0, -1)</summary>
        public static readonly float4 before = new float4(0f, 0f, 0f, unchecked((float)-1f));
        ///<summary>(0, 0, 0, 1)</summary>
        public static readonly float4 after = new float4(0f, 0f, 0f, 1f);
        #endregion

        public float x;
        public float y;
        public float z;
        public float w;

        #region IColor
        public float r { [IN(LINE)] get { return (float)x; } [IN(LINE)] set { x = (float)value; } }
        public float g { [IN(LINE)] get { return (float)y; } [IN(LINE)] set { y = (float)value; } }
        public float b { [IN(LINE)] get { return (float)z; } [IN(LINE)] set { z = (float)value; } }
        public float a { [IN(LINE)] get { return (float)w; } [IN(LINE)] set { w = (float)value; } }
        #endregion

        #region IVector
        [EditorBrowsable(EditorBrowsableState.Never)] float IVector1<float>.x { [IN(LINE)] get { return x; } [IN(LINE)] set { x = value; } }
        [EditorBrowsable(EditorBrowsableState.Never)] float IVector2<float>.y { [IN(LINE)] get { return y; } [IN(LINE)] set { y = value; } }
        [EditorBrowsable(EditorBrowsableState.Never)] float IVector3<float>.z { [IN(LINE)] get { return z; } [IN(LINE)] set { z = value; } }
        [EditorBrowsable(EditorBrowsableState.Never)] float IVector4<float>.w { [IN(LINE)] get { return w; } [IN(LINE)] set { w = value; } }
        [EditorBrowsable(EditorBrowsableState.Never)] int IVectorN.Count { [IN(LINE)] get { return Count; } }

        public unsafe float this[int index]
        {
            [IN(LINE)]
            get
            {
#if DEBUG || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > Count) { Throw.IndexOutOfRange(Count); }
#endif
                fixed (float4* array = &this) { return ((float*)array)[index]; }
            }
            [IN(LINE)]
            set
            {
#if DEBUG || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > Count) { Throw.IndexOutOfRange(Count); }
#endif
                fixed (float* array = &x) { array[index] = value; }
            }
        }

        object IVectorN.GetComponentRaw(int index) { return this[index]; }
        void IVectorN.SetComponentRaw(int index, object raw) { if (raw is float cmp) { this[index] = cmp; } }
        [IN(LINE)] Type IVectorN.GetComponentType() { return typeof(float); }
        #endregion

        #region Constructors
        [IN(LINE)]
        public float4((float x, float y, float z, float w) a)
        {
            this.x = a.x; this.y = a.y;
            this.z = a.z; this.w = a.w;
        }
        [IN(LINE)]
        public float4((float x, float y, float z) a, float w)
        {
            this.x = a.x; this.y = a.y;
            this.z = a.z; this.w = w;
        }
        [IN(LINE)]
        public float4(float x, (float x, float y, float z) a)
        {
            this.x = x; this.y = a.x;
            this.z = a.y; this.w = a.z;
        }
        [IN(LINE)]
        public float4((float x, float y) a, float z, float w)
        {
            this.x = a.x; this.y = a.y;
            this.z = z; this.w = w;
        }
        [IN(LINE)]
        public float4(float x, (float x, float y) a, float w)
        {
            this.x = x; this.y = a.x;
            this.z = a.y; this.w = w;
        }
        [IN(LINE)]
        public float4(float x, float y, (float x, float y) a)
        {
            this.x = x; this.y = y;
            this.z = a.x; this.w = a.y;
        }
        [IN(LINE)]
        public float4((float x, float y) a, (float x, float y) b)
        {
            this.x = a.x; this.y = a.y;
            this.z = b.x; this.w = b.y;
        }

        [IN(LINE)]
        public float4(float x, float y, float z, float w)
        {
            this.x = x; this.y = y;
            this.z = z; this.w = w;
        }
        [IN(LINE)]
        public float4(float3 a, float w)
        {
            this.x = a.x; this.y = a.y;
            this.z = a.z; this.w = w;
        }
        [IN(LINE)]
        public float4(float x, float3 a)
        {
            this.x = x; this.y = a.x;
            this.z = a.y; this.w = a.z;
        }
        [IN(LINE)]
        public float4(float2 a, float z, float w)
        {
            this.x = a.x; this.y = a.y;
            this.z = z; this.w = w;
        }
        [IN(LINE)]
        public float4(float x, float2 a, float w)
        {
            this.x = x; this.y = a.x;
            this.z = a.y; this.w = w;
        }
        [IN(LINE)]
        public float4(float x, float y, float2 a)
        {
            this.x = x; this.y = y;
            this.z = a.x; this.w = a.y;
        }
        [IN(LINE)]
        public float4(float2 a, float2 b)
        {
            this.x = a.x; this.y = a.y;
            this.z = b.x; this.w = b.y;
        }

        [IN(LINE)]
        public float4(float v)
        {
            x = v; y = v;
            z = v; w = v;
        }
        [IN(LINE)]
        public float4(float4 v)
        {
            x = v.x; y = v.y;
            z = v.z; w = v.w;
        }
        [IN(LINE)]
        public float4(double v)
        {
            x = (float)v; y = (float)v;
            z = (float)v; w = (float)v;
        }
        [IN(LINE)]
        public float4(double4 v)
        {
            x = (float)v.x; y = (float)v.y;
            z = (float)v.z; w = (float)v.w;
        }
        [IN(LINE)]
        public float4(int v)
        {
            x = (float)v; y = (float)v;
            z = (float)v; w = (float)v;
        }
        [IN(LINE)]
        public float4(int4 v)
        {
            x = (float)v.x; y = (float)v.y;
            z = (float)v.z; w = (float)v.w;
        }
        [IN(LINE)]
        public float4(uint v)
        {
            x = (float)v; y = (float)v;
            z = (float)v; w = (float)v;
        }
        [IN(LINE)]
        public float4(uint4 v)
        {
            x = (float)v.x; y = (float)v.y;
            z = (float)v.z; w = (float)v.w;
        }

        [IN(LINE)]
        public float4(ReadOnlySpan<float> values)
        {
#if DEBUG || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
            if (values.Length < Count) { Throw.ArgumentOutOfRange(nameof(values)); }
#endif
#if UNITY_5_3_OR_NEWER
            x = values[0]; y = values[1]; z = values[2]; w = values[3];
#else
            this = Unsafe.ReadUnaligned<float4>(ref Unsafe.As<float, byte>(ref MemoryMarshal.GetReference(values)));
#endif
        }
        [IN(LINE)] public void Deconstruct(out float x, out float y, out float z, out float w) { x = this.x; y = this.y; z = this.z; w = this.w; }
        #endregion

        #region operators

        #region Arithmetic
        [IN(LINE)] public static float4 operator +(float4 a, float4 b) { return new float4(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w); }
        [IN(LINE)] public static float4 operator +(float4 a, float b) { return new float4(a.x + b, a.y + b, a.z + b, a.w + b); }
        [IN(LINE)] public static float4 operator +(float a, float4 b) { return new float4(a + b.x, a + b.y, a + b.z, a + b.w); }

        [IN(LINE)] public static float4 operator -(float4 a, float4 b) { return new float4(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w); }
        [IN(LINE)] public static float4 operator -(float4 a, float b) { return new float4(a.x - b, a.y - b, a.z - b, a.w - b); }
        [IN(LINE)] public static float4 operator -(float a, float4 b) { return new float4(a - b.x, a - b.y, a - b.z, a - b.w); }

        [IN(LINE)] public static float4 operator *(float4 a, float4 b) { return new float4(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w); }
        [IN(LINE)] public static float4 operator *(float4 a, float b) { return new float4(a.x * b, a.y * b, a.z * b, a.w * b); }
        [IN(LINE)] public static float4 operator *(float a, float4 b) { return new float4(a * b.x, a * b.y, a * b.z, a * b.w); }

        [IN(LINE)] public static float4 operator /(float4 a, float4 b) { return new float4(a.x / b.x, a.y / b.y, a.z / b.z, a.w / b.w); }
        [IN(LINE)] public static float4 operator /(float4 a, float b) { return new float4(a.x / b, a.y / b, a.z / b, a.w / b); }
        [IN(LINE)] public static float4 operator /(float a, float4 b) { return new float4(a / b.x, a / b.y, a / b.z, a / b.w); }

        [IN(LINE)] public static float4 operator %(float4 a, float4 b) { return new float4(a.x % b.x, a.y % b.y, a.z % b.z, a.w % b.w); }
        [IN(LINE)] public static float4 operator %(float4 a, float b) { return new float4(a.x % b, a.y % b, a.z % b, a.w % b); }
        [IN(LINE)] public static float4 operator %(float a, float4 b) { return new float4(a % b.x, a % b.y, a % b.z, a % b.w); }

        [IN(LINE)] public static float4 operator ++(float4 a) { return new float4(++a.x, ++a.y, ++a.z, ++a.w); }
        [IN(LINE)] public static float4 operator --(float4 a) { return new float4(--a.x, --a.y, --a.z, --a.w); }
        [IN(LINE)] public static float4 operator +(float4 a) { return new float4(+a.x, +a.y, +a.z, +a.w); }
        [IN(LINE)] public static float4 operator -(float4 a) { return new float4((float)-a.x, (float)-a.y, (float)-a.z, (float)-a.w); }
        #endregion

        #region Boolean
        [IN(LINE)] public static bool4 operator <(float4 a, float4 b) { return new bool4(a.x < b.x, a.y < b.y, a.z < b.z, a.w < b.w); }
        [IN(LINE)] public static bool4 operator <(float4 a, float b) { return new bool4(a.x < b, a.y < b, a.z < b, a.w < b); }
        [IN(LINE)] public static bool4 operator <(float a, float4 b) { return new bool4(a < b.x, a < b.y, a < b.z, a < b.w); }

        [IN(LINE)] public static bool4 operator <=(float4 a, float4 b) { return new bool4(a.x <= b.x, a.y <= b.y, a.z <= b.z, a.w <= b.w); }
        [IN(LINE)] public static bool4 operator <=(float4 a, float b) { return new bool4(a.x <= b, a.y <= b, a.z <= b, a.w <= b); }
        [IN(LINE)] public static bool4 operator <=(float a, float4 b) { return new bool4(a <= b.x, a <= b.y, a <= b.z, a <= b.w); }

        [IN(LINE)] public static bool4 operator >(float4 a, float4 b) { return new bool4(a.x > b.x, a.y > b.y, a.z > b.z, a.w > b.w); }
        [IN(LINE)] public static bool4 operator >(float4 a, float b) { return new bool4(a.x > b, a.y > b, a.z > b, a.w > b); }
        [IN(LINE)] public static bool4 operator >(float a, float4 b) { return new bool4(a > b.x, a > b.y, a > b.z, a > b.w); }

        [IN(LINE)] public static bool4 operator >=(float4 a, float4 b) { return new bool4(a.x >= b.x, a.y >= b.y, a.z >= b.z, a.w >= b.w); }
        [IN(LINE)] public static bool4 operator >=(float4 a, float b) { return new bool4(a.x >= b, a.y >= b, a.z >= b, a.w >= b); }
        [IN(LINE)] public static bool4 operator >=(float a, float4 b) { return new bool4(a >= b.x, a >= b.y, a >= b.z, a >= b.w); }

        [IN(LINE)] public static bool4 operator ==(float4 a, float4 b) { return new bool4(a.x == b.x, a.y == b.y, a.z == b.z, a.w == b.w); }
        [IN(LINE)] public static bool4 operator ==(float4 a, float b) { return new bool4(a.x == b, a.y == b, a.z == b, a.w == b); }
        [IN(LINE)] public static bool4 operator ==(float a, float4 b) { return new bool4(a == b.x, a == b.y, a == b.z, a == b.w); }

        [IN(LINE)] public static bool4 operator !=(float4 a, float4 b) { return new bool4(a.x != b.x, a.y != b.y, a.z != b.z, a.w != b.w); }
        [IN(LINE)] public static bool4 operator !=(float4 a, float b) { return new bool4(a.x != b, a.y != b, a.z != b, a.w != b); }
        [IN(LINE)] public static bool4 operator !=(float a, float4 b) { return new bool4(a != b.x, a != b.y, a != b.z, a != b.w); }
        #endregion

        #region Other
        [IN(LINE)] public static float4 operator !(float4 a) { return 1f - a; }
        #endregion

        #endregion

        #region Swaps

        #region Swap2
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float2 xx { [IN(LINE)] get => new float2(x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float2 xy { [IN(LINE)] get => new float2(x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float2 xz { [IN(LINE)] get => new float2(x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float2 xw { [IN(LINE)] get => new float2(x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float2 yx { [IN(LINE)] get => new float2(y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float2 yy { [IN(LINE)] get => new float2(y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float2 yz { [IN(LINE)] get => new float2(y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float2 yw { [IN(LINE)] get => new float2(y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float2 zx { [IN(LINE)] get => new float2(z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float2 zy { [IN(LINE)] get => new float2(z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float2 zz { [IN(LINE)] get => new float2(z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float2 zw { [IN(LINE)] get => new float2(z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float2 wx { [IN(LINE)] get => new float2(w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float2 wy { [IN(LINE)] get => new float2(w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float2 wz { [IN(LINE)] get => new float2(w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float2 ww { [IN(LINE)] get => new float2(w, w); }
        #endregion

        #region Swap3
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 xxx { [IN(LINE)] get => new float3(x, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 xxy { [IN(LINE)] get => new float3(x, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 xxz { [IN(LINE)] get => new float3(x, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 xxw { [IN(LINE)] get => new float3(x, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 xyx { [IN(LINE)] get => new float3(x, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 xyy { [IN(LINE)] get => new float3(x, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 xyz { [IN(LINE)] get => new float3(x, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 xyw { [IN(LINE)] get => new float3(x, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 xzx { [IN(LINE)] get => new float3(x, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 xzy { [IN(LINE)] get => new float3(x, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 xzz { [IN(LINE)] get => new float3(x, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 xzw { [IN(LINE)] get => new float3(x, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 xwx { [IN(LINE)] get => new float3(x, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 xwy { [IN(LINE)] get => new float3(x, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 xwz { [IN(LINE)] get => new float3(x, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 xww { [IN(LINE)] get => new float3(x, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 yxx { [IN(LINE)] get => new float3(y, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 yxy { [IN(LINE)] get => new float3(y, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 yxz { [IN(LINE)] get => new float3(y, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 yxw { [IN(LINE)] get => new float3(y, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 yyx { [IN(LINE)] get => new float3(y, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 yyy { [IN(LINE)] get => new float3(y, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 yyz { [IN(LINE)] get => new float3(y, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 yyw { [IN(LINE)] get => new float3(y, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 yzx { [IN(LINE)] get => new float3(y, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 yzy { [IN(LINE)] get => new float3(y, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 yzz { [IN(LINE)] get => new float3(y, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 yzw { [IN(LINE)] get => new float3(y, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 ywx { [IN(LINE)] get => new float3(y, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 ywy { [IN(LINE)] get => new float3(y, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 ywz { [IN(LINE)] get => new float3(y, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 yww { [IN(LINE)] get => new float3(y, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 zxx { [IN(LINE)] get => new float3(z, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 zxy { [IN(LINE)] get => new float3(z, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 zxz { [IN(LINE)] get => new float3(z, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 zxw { [IN(LINE)] get => new float3(z, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 zyx { [IN(LINE)] get => new float3(z, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 zyy { [IN(LINE)] get => new float3(z, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 zyz { [IN(LINE)] get => new float3(z, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 zyw { [IN(LINE)] get => new float3(z, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 zzx { [IN(LINE)] get => new float3(z, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 zzy { [IN(LINE)] get => new float3(z, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 zzz { [IN(LINE)] get => new float3(z, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 zzw { [IN(LINE)] get => new float3(z, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 zwx { [IN(LINE)] get => new float3(z, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 zwy { [IN(LINE)] get => new float3(z, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 zwz { [IN(LINE)] get => new float3(z, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 zww { [IN(LINE)] get => new float3(z, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 wxx { [IN(LINE)] get => new float3(w, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 wxy { [IN(LINE)] get => new float3(w, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 wxz { [IN(LINE)] get => new float3(w, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 wxw { [IN(LINE)] get => new float3(w, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 wyx { [IN(LINE)] get => new float3(w, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 wyy { [IN(LINE)] get => new float3(w, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 wyz { [IN(LINE)] get => new float3(w, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 wyw { [IN(LINE)] get => new float3(w, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 wzx { [IN(LINE)] get => new float3(w, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 wzy { [IN(LINE)] get => new float3(w, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 wzz { [IN(LINE)] get => new float3(w, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 wzw { [IN(LINE)] get => new float3(w, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 wwx { [IN(LINE)] get => new float3(w, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 wwy { [IN(LINE)] get => new float3(w, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 wwz { [IN(LINE)] get => new float3(w, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float3 www { [IN(LINE)] get => new float3(w, w, w); }
        #endregion

        #region Swap4
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xxxx { [IN(LINE)] get => new float4(x, x, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xxxy { [IN(LINE)] get => new float4(x, x, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xxxz { [IN(LINE)] get => new float4(x, x, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xxxw { [IN(LINE)] get => new float4(x, x, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xxyx { [IN(LINE)] get => new float4(x, x, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xxyy { [IN(LINE)] get => new float4(x, x, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xxyz { [IN(LINE)] get => new float4(x, x, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xxyw { [IN(LINE)] get => new float4(x, x, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xxzx { [IN(LINE)] get => new float4(x, x, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xxzy { [IN(LINE)] get => new float4(x, x, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xxzz { [IN(LINE)] get => new float4(x, x, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xxzw { [IN(LINE)] get => new float4(x, x, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xxwx { [IN(LINE)] get => new float4(x, x, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xxwy { [IN(LINE)] get => new float4(x, x, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xxwz { [IN(LINE)] get => new float4(x, x, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xxww { [IN(LINE)] get => new float4(x, x, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xyxx { [IN(LINE)] get => new float4(x, y, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xyxy { [IN(LINE)] get => new float4(x, y, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xyxz { [IN(LINE)] get => new float4(x, y, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xyxw { [IN(LINE)] get => new float4(x, y, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xyyx { [IN(LINE)] get => new float4(x, y, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xyyy { [IN(LINE)] get => new float4(x, y, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xyyz { [IN(LINE)] get => new float4(x, y, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xyyw { [IN(LINE)] get => new float4(x, y, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xyzx { [IN(LINE)] get => new float4(x, y, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xyzy { [IN(LINE)] get => new float4(x, y, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xyzz { [IN(LINE)] get => new float4(x, y, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xyzw { [IN(LINE)] get => new float4(x, y, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xywx { [IN(LINE)] get => new float4(x, y, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xywy { [IN(LINE)] get => new float4(x, y, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xywz { [IN(LINE)] get => new float4(x, y, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xyww { [IN(LINE)] get => new float4(x, y, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xzxx { [IN(LINE)] get => new float4(x, z, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xzxy { [IN(LINE)] get => new float4(x, z, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xzxz { [IN(LINE)] get => new float4(x, z, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xzxw { [IN(LINE)] get => new float4(x, z, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xzyx { [IN(LINE)] get => new float4(x, z, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xzyy { [IN(LINE)] get => new float4(x, z, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xzyz { [IN(LINE)] get => new float4(x, z, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xzyw { [IN(LINE)] get => new float4(x, z, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xzzx { [IN(LINE)] get => new float4(x, z, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xzzy { [IN(LINE)] get => new float4(x, z, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xzzz { [IN(LINE)] get => new float4(x, z, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xzzw { [IN(LINE)] get => new float4(x, z, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xzwx { [IN(LINE)] get => new float4(x, z, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xzwy { [IN(LINE)] get => new float4(x, z, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xzwz { [IN(LINE)] get => new float4(x, z, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xzww { [IN(LINE)] get => new float4(x, z, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xwxx { [IN(LINE)] get => new float4(x, w, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xwxy { [IN(LINE)] get => new float4(x, w, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xwxz { [IN(LINE)] get => new float4(x, w, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xwxw { [IN(LINE)] get => new float4(x, w, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xwyx { [IN(LINE)] get => new float4(x, w, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xwyy { [IN(LINE)] get => new float4(x, w, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xwyz { [IN(LINE)] get => new float4(x, w, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xwyw { [IN(LINE)] get => new float4(x, w, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xwzx { [IN(LINE)] get => new float4(x, w, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xwzy { [IN(LINE)] get => new float4(x, w, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xwzz { [IN(LINE)] get => new float4(x, w, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xwzw { [IN(LINE)] get => new float4(x, w, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xwwx { [IN(LINE)] get => new float4(x, w, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xwwy { [IN(LINE)] get => new float4(x, w, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xwwz { [IN(LINE)] get => new float4(x, w, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 xwww { [IN(LINE)] get => new float4(x, w, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yxxx { [IN(LINE)] get => new float4(y, x, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yxxy { [IN(LINE)] get => new float4(y, x, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yxxz { [IN(LINE)] get => new float4(y, x, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yxxw { [IN(LINE)] get => new float4(y, x, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yxyx { [IN(LINE)] get => new float4(y, x, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yxyy { [IN(LINE)] get => new float4(y, x, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yxyz { [IN(LINE)] get => new float4(y, x, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yxyw { [IN(LINE)] get => new float4(y, x, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yxzx { [IN(LINE)] get => new float4(y, x, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yxzy { [IN(LINE)] get => new float4(y, x, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yxzz { [IN(LINE)] get => new float4(y, x, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yxzw { [IN(LINE)] get => new float4(y, x, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yxwx { [IN(LINE)] get => new float4(y, x, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yxwy { [IN(LINE)] get => new float4(y, x, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yxwz { [IN(LINE)] get => new float4(y, x, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yxww { [IN(LINE)] get => new float4(y, x, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yyxx { [IN(LINE)] get => new float4(y, y, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yyxy { [IN(LINE)] get => new float4(y, y, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yyxz { [IN(LINE)] get => new float4(y, y, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yyxw { [IN(LINE)] get => new float4(y, y, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yyyx { [IN(LINE)] get => new float4(y, y, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yyyy { [IN(LINE)] get => new float4(y, y, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yyyz { [IN(LINE)] get => new float4(y, y, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yyyw { [IN(LINE)] get => new float4(y, y, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yyzx { [IN(LINE)] get => new float4(y, y, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yyzy { [IN(LINE)] get => new float4(y, y, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yyzz { [IN(LINE)] get => new float4(y, y, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yyzw { [IN(LINE)] get => new float4(y, y, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yywx { [IN(LINE)] get => new float4(y, y, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yywy { [IN(LINE)] get => new float4(y, y, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yywz { [IN(LINE)] get => new float4(y, y, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yyww { [IN(LINE)] get => new float4(y, y, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yzxx { [IN(LINE)] get => new float4(y, z, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yzxy { [IN(LINE)] get => new float4(y, z, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yzxz { [IN(LINE)] get => new float4(y, z, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yzxw { [IN(LINE)] get => new float4(y, z, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yzyx { [IN(LINE)] get => new float4(y, z, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yzyy { [IN(LINE)] get => new float4(y, z, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yzyz { [IN(LINE)] get => new float4(y, z, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yzyw { [IN(LINE)] get => new float4(y, z, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yzzx { [IN(LINE)] get => new float4(y, z, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yzzy { [IN(LINE)] get => new float4(y, z, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yzzz { [IN(LINE)] get => new float4(y, z, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yzzw { [IN(LINE)] get => new float4(y, z, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yzwx { [IN(LINE)] get => new float4(y, z, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yzwy { [IN(LINE)] get => new float4(y, z, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yzwz { [IN(LINE)] get => new float4(y, z, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 yzww { [IN(LINE)] get => new float4(y, z, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 ywxx { [IN(LINE)] get => new float4(y, w, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 ywxy { [IN(LINE)] get => new float4(y, w, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 ywxz { [IN(LINE)] get => new float4(y, w, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 ywxw { [IN(LINE)] get => new float4(y, w, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 ywyx { [IN(LINE)] get => new float4(y, w, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 ywyy { [IN(LINE)] get => new float4(y, w, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 ywyz { [IN(LINE)] get => new float4(y, w, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 ywyw { [IN(LINE)] get => new float4(y, w, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 ywzx { [IN(LINE)] get => new float4(y, w, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 ywzy { [IN(LINE)] get => new float4(y, w, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 ywzz { [IN(LINE)] get => new float4(y, w, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 ywzw { [IN(LINE)] get => new float4(y, w, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 ywwx { [IN(LINE)] get => new float4(y, w, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 ywwy { [IN(LINE)] get => new float4(y, w, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 ywwz { [IN(LINE)] get => new float4(y, w, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 ywww { [IN(LINE)] get => new float4(y, w, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zxxx { [IN(LINE)] get => new float4(z, x, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zxxy { [IN(LINE)] get => new float4(z, x, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zxxz { [IN(LINE)] get => new float4(z, x, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zxxw { [IN(LINE)] get => new float4(z, x, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zxyx { [IN(LINE)] get => new float4(z, x, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zxyy { [IN(LINE)] get => new float4(z, x, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zxyz { [IN(LINE)] get => new float4(z, x, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zxyw { [IN(LINE)] get => new float4(z, x, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zxzx { [IN(LINE)] get => new float4(z, x, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zxzy { [IN(LINE)] get => new float4(z, x, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zxzz { [IN(LINE)] get => new float4(z, x, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zxzw { [IN(LINE)] get => new float4(z, x, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zxwx { [IN(LINE)] get => new float4(z, x, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zxwy { [IN(LINE)] get => new float4(z, x, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zxwz { [IN(LINE)] get => new float4(z, x, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zxww { [IN(LINE)] get => new float4(z, x, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zyxx { [IN(LINE)] get => new float4(z, y, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zyxy { [IN(LINE)] get => new float4(z, y, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zyxz { [IN(LINE)] get => new float4(z, y, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zyxw { [IN(LINE)] get => new float4(z, y, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zyyx { [IN(LINE)] get => new float4(z, y, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zyyy { [IN(LINE)] get => new float4(z, y, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zyyz { [IN(LINE)] get => new float4(z, y, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zyyw { [IN(LINE)] get => new float4(z, y, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zyzx { [IN(LINE)] get => new float4(z, y, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zyzy { [IN(LINE)] get => new float4(z, y, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zyzz { [IN(LINE)] get => new float4(z, y, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zyzw { [IN(LINE)] get => new float4(z, y, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zywx { [IN(LINE)] get => new float4(z, y, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zywy { [IN(LINE)] get => new float4(z, y, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zywz { [IN(LINE)] get => new float4(z, y, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zyww { [IN(LINE)] get => new float4(z, y, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zzxx { [IN(LINE)] get => new float4(z, z, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zzxy { [IN(LINE)] get => new float4(z, z, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zzxz { [IN(LINE)] get => new float4(z, z, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zzxw { [IN(LINE)] get => new float4(z, z, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zzyx { [IN(LINE)] get => new float4(z, z, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zzyy { [IN(LINE)] get => new float4(z, z, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zzyz { [IN(LINE)] get => new float4(z, z, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zzyw { [IN(LINE)] get => new float4(z, z, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zzzx { [IN(LINE)] get => new float4(z, z, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zzzy { [IN(LINE)] get => new float4(z, z, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zzzz { [IN(LINE)] get => new float4(z, z, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zzzw { [IN(LINE)] get => new float4(z, z, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zzwx { [IN(LINE)] get => new float4(z, z, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zzwy { [IN(LINE)] get => new float4(z, z, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zzwz { [IN(LINE)] get => new float4(z, z, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zzww { [IN(LINE)] get => new float4(z, z, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zwxx { [IN(LINE)] get => new float4(z, w, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zwxy { [IN(LINE)] get => new float4(z, w, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zwxz { [IN(LINE)] get => new float4(z, w, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zwxw { [IN(LINE)] get => new float4(z, w, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zwyx { [IN(LINE)] get => new float4(z, w, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zwyy { [IN(LINE)] get => new float4(z, w, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zwyz { [IN(LINE)] get => new float4(z, w, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zwyw { [IN(LINE)] get => new float4(z, w, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zwzx { [IN(LINE)] get => new float4(z, w, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zwzy { [IN(LINE)] get => new float4(z, w, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zwzz { [IN(LINE)] get => new float4(z, w, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zwzw { [IN(LINE)] get => new float4(z, w, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zwwx { [IN(LINE)] get => new float4(z, w, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zwwy { [IN(LINE)] get => new float4(z, w, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zwwz { [IN(LINE)] get => new float4(z, w, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 zwww { [IN(LINE)] get => new float4(z, w, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wxxx { [IN(LINE)] get => new float4(w, x, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wxxy { [IN(LINE)] get => new float4(w, x, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wxxz { [IN(LINE)] get => new float4(w, x, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wxxw { [IN(LINE)] get => new float4(w, x, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wxyx { [IN(LINE)] get => new float4(w, x, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wxyy { [IN(LINE)] get => new float4(w, x, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wxyz { [IN(LINE)] get => new float4(w, x, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wxyw { [IN(LINE)] get => new float4(w, x, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wxzx { [IN(LINE)] get => new float4(w, x, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wxzy { [IN(LINE)] get => new float4(w, x, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wxzz { [IN(LINE)] get => new float4(w, x, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wxzw { [IN(LINE)] get => new float4(w, x, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wxwx { [IN(LINE)] get => new float4(w, x, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wxwy { [IN(LINE)] get => new float4(w, x, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wxwz { [IN(LINE)] get => new float4(w, x, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wxww { [IN(LINE)] get => new float4(w, x, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wyxx { [IN(LINE)] get => new float4(w, y, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wyxy { [IN(LINE)] get => new float4(w, y, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wyxz { [IN(LINE)] get => new float4(w, y, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wyxw { [IN(LINE)] get => new float4(w, y, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wyyx { [IN(LINE)] get => new float4(w, y, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wyyy { [IN(LINE)] get => new float4(w, y, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wyyz { [IN(LINE)] get => new float4(w, y, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wyyw { [IN(LINE)] get => new float4(w, y, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wyzx { [IN(LINE)] get => new float4(w, y, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wyzy { [IN(LINE)] get => new float4(w, y, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wyzz { [IN(LINE)] get => new float4(w, y, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wyzw { [IN(LINE)] get => new float4(w, y, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wywx { [IN(LINE)] get => new float4(w, y, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wywy { [IN(LINE)] get => new float4(w, y, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wywz { [IN(LINE)] get => new float4(w, y, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wyww { [IN(LINE)] get => new float4(w, y, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wzxx { [IN(LINE)] get => new float4(w, z, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wzxy { [IN(LINE)] get => new float4(w, z, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wzxz { [IN(LINE)] get => new float4(w, z, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wzxw { [IN(LINE)] get => new float4(w, z, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wzyx { [IN(LINE)] get => new float4(w, z, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wzyy { [IN(LINE)] get => new float4(w, z, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wzyz { [IN(LINE)] get => new float4(w, z, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wzyw { [IN(LINE)] get => new float4(w, z, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wzzx { [IN(LINE)] get => new float4(w, z, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wzzy { [IN(LINE)] get => new float4(w, z, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wzzz { [IN(LINE)] get => new float4(w, z, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wzzw { [IN(LINE)] get => new float4(w, z, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wzwx { [IN(LINE)] get => new float4(w, z, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wzwy { [IN(LINE)] get => new float4(w, z, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wzwz { [IN(LINE)] get => new float4(w, z, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wzww { [IN(LINE)] get => new float4(w, z, w, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wwxx { [IN(LINE)] get => new float4(w, w, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wwxy { [IN(LINE)] get => new float4(w, w, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wwxz { [IN(LINE)] get => new float4(w, w, x, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wwxw { [IN(LINE)] get => new float4(w, w, x, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wwyx { [IN(LINE)] get => new float4(w, w, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wwyy { [IN(LINE)] get => new float4(w, w, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wwyz { [IN(LINE)] get => new float4(w, w, y, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wwyw { [IN(LINE)] get => new float4(w, w, y, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wwzx { [IN(LINE)] get => new float4(w, w, z, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wwzy { [IN(LINE)] get => new float4(w, w, z, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wwzz { [IN(LINE)] get => new float4(w, w, z, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wwzw { [IN(LINE)] get => new float4(w, w, z, w); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wwwx { [IN(LINE)] get => new float4(w, w, w, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wwwy { [IN(LINE)] get => new float4(w, w, w, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wwwz { [IN(LINE)] get => new float4(w, w, w, z); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float4 wwww { [IN(LINE)] get => new float4(w, w, w, w); }
        #endregion

        #endregion


        #region Other
        [IN(LINE)]
        public /*readonly*/ void CopyTo(Span<float> destination)
        {
#if DEBUG || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
            if (destination.Length < Count) { Throw.ArgumentDestinationTooShort(); }
#endif

#if UNITY_5_3_OR_NEWER
            destination[0] = x; destination[1] = y; destination[2] = z; destination[3] = w;
#else
            Unsafe.WriteUnaligned(ref Unsafe.As<float, byte>(ref MemoryMarshal.GetReference(destination)), this);
#endif
        }
        [IN(LINE)] public override int GetHashCode() { return DM.Hash(this); }
        public override bool Equals(object o) { return o is float4 target && Equals(target); }
        [IN(LINE)] public bool Equals(float4 a) { return x == a.x && y == a.y && z == a.z && w == a.w; }
        public override string ToString() { return $"float4({x}, {y}, {z}, {w})"; }
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"float4({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)}, {z.ToString(format, formatProvider)}, {w.ToString(format, formatProvider)})";
        }

        internal class DebuggerProxy
        {
            public float x, y, z, w;
            public DebuggerProxy(float4 v) { x = v.x; y = v.y; z = v.z; w = v.w; }
        }
        #endregion

        #region Enumerator
        VectorEnumerator<float, float4> GetEnumerator() { return new VectorEnumerator<float, float4>(this); }
        VectorEnumerator<float, float4> IEnumerableVector<float, float4>.GetEnumerator() { return new VectorEnumerator<float, float4>(this); }
        IEnumerator<float> IEnumerable<float>.GetEnumerator() { return new VectorEnumerator<float, float4>(this); }
        IEnumerator IEnumerable.GetEnumerator() { return new VectorEnumerator<float, float4>(this); }
        #endregion
    }
}