using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DCFApixels.DataMath
{
    [DebuggerTypeProxy(typeof(DebuggerProxy))]
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 4, Size = 8)]
    public partial struct float2 : 
        IEquatable<float2>, 
        IFormattable, 
        IValue2<float>, 
        IColor
    {
        #region Consts
        public const int length = 2;

        ///<summary>(0, 0)</summary>
        public static readonly float2 zero = new float2(0f, 0f);
        ///<summary>(1, 1)</summary>
        public static readonly float2 one = new float2(1f, 1f);

        ///<summary>(-1, 0)</summary>
        public static readonly float2 left = new float2(-1f, 0f);
        ///<summary>(1, 0)</summary>
        public static readonly float2 right = new float2(1f, 0f);
        ///<summary>(0, -1)</summary>
        public static readonly float2 down = new float2(0f, -1f);
        ///<summary>(0, 1)</summary>
        public static readonly float2 up = new float2(0f, 1f);
        #endregion

        public float x;
        public float y;

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
            get => 0f;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {}
        }
        public float a 
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => 0f;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set {}
        }
        #endregion

        #region IValueN
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float X 
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => x; 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => x = value; 
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float Y 
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => y; 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => y = value; 
        }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int Length
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => length;
        }

        public unsafe ref float this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > length) throw new IndexOutOfRangeException($"index must be between[0...{(length - 1)}]");
#endif
                fixed (float2* array = &this) { return ref ((float*)array)[index]; }
            }
        }
        #endregion

        #region Constructors
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(float x, float y)
        {
            this.x = x; this.y = y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(float v)
        {
            x = v; y = v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(float2 v)
        {
            x = v.x; y = v.y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(double x, double y)
        {
            this.x = (float)x; this.y = (float)y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(double v)
        {
            x = (float)v; y = (float)v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(double2 v)
        {
            x = (float)v.x; y = (float)v.y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(int x, int y)
        {
            this.x = (float)x; this.y = (float)y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(int v)
        {
            x = (float)v; y = (float)v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(int2 v)
        {
            x = (float)v.x; y = (float)v.y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(uint x, uint y)
        {
            this.x = (float)x; this.y = (float)y;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(uint v)
        {
            x = (float)v; y = (float)v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2(uint2 v)
        {
            x = (float)v.x; y = (float)v.y;
        }

        #endregion

        #region Arithmetic operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator *(float2 a, float2 b) => new float2(a.x * b.x, a.y * b.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator *(float2 a, float b) => new float2(a.x * b, a.y * b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator *(float a, float2 b) => new float2(a * b.x, a * b.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator +(float2 a, float2 b) => new float2(a.x + b.x, a.y + b.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator +(float2 a, float b) => new float2(a.x + b, a.y + b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator +(float a, float2 b) => new float2(a + b.x, a + b.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator -(float2 a, float2 b) => new float2(a.x - b.x, a.y - b.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator -(float2 a, float b) => new float2(a.x - b, a.y - b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator -(float a, float2 b) => new float2(a - b.x, a - b.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator /(float2 a, float2 b) => new float2(a.x / b.x, a.y / b.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator /(float2 a, float b) => new float2(a.x / b, a.y / b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator /(float a, float2 b) => new float2(a / b.x, a / b.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator %(float2 a, float2 b) => new float2(a.x % b.x, a.y % b.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator %(float2 a, float b) => new float2(a.x % b, a.y % b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator %(float a, float2 b) => new float2(a % b.x, a % b.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator ++(float2 a) => new float2(++a.x, ++a.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator --(float2 a) => new float2(--a.x, --a.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2 operator -(float2 a) => new float2(-a.x, -a.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]                                                               
        public static float2 operator +(float2 a) => new float2(+a.x, +a.y);
        #endregion

        #region Boolean operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(float2 a, float2 b) => a.x == b.x && a.y == b.y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(float2 a, float b) => a.x == b && a.y == b;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(float a, float2 b) => a == b.x && a == b.y;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(float2 a, float2 b) => a.x != b.x || a.y != b.y;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(float2 a, float b) => a.x != b || a.y != b;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(float a, float2 b) => a != b.x || a != b.y;
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
        #endregion


        #region Object
        public override bool Equals(object o) => o is float2 target && Equals(target); 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override int GetHashCode() => math.hash(this);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override string ToString() => $"float2({x}, {y})";
        #endregion

        #region IEquatable/IFormattable
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(float2 a) => x == a.x && y == a.y; 
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"float2({x.ToString(format, formatProvider)}, {y.ToString(format, formatProvider)})";
        }
        #endregion

        #region Enumerator
        public Enumerator GetEnumerator() => new Enumerator(this);
        public ref struct Enumerator
        {
            private readonly float2 _value;
            private byte _pointer;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Enumerator(float2 value) { _value = value; _pointer = 0; }
            public float Current => _value[_pointer];

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
            public float x;
            public float y;
            public DebuggerProxy(float2 v)
            {
                x = v.x;
                y = v.y;
            }
        }
        #endregion
    }
}