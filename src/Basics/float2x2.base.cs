using DCFApixels.DataMath;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DCFApixels.DataMath.TODO
{
	[DebuggerTypeProxy(typeof(DebuggerProxy))]
	[Serializable]
	[StructLayout(LayoutKind.Sequential, Pack = 4 * 2, Size = 8 * 2)]
	public partial struct float2x2 :
        IRowsMatrix2x2<float, float2>,
        IEnumerableVector<float, float2x2>,
        IEquatable<float2x2>,
        IFormattable
    {
		#region Consts
		public const int ROWS = 2;
		public const int COLUMNS = 2;
		public const int LENGTH = ROWS * COLUMNS;

        public static readonly float2x2 identity = new float2x2(1.0f, 0.0f, 0.0f, 1.0f);
        public static readonly float2x2 zero;
        #endregion

        public float2 c0;
        public float2 c1;

        #region Constructors
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(float2 c0, float2 c1)
        {
            this.c0 = c0; this.c1 = c1;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(float m00, float m01,
                        float m10, float m11)
        {
            c0 = new float2(m00, m10);
            c1 = new float2(m01, m11);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(float v)
        {
            c0 = v; c1 = v;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(int v)
        {
            c0 = v; c1 = v;
        }
    //    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    //    public float2x2(int2x2 v)
    //    {
    //        c0 = v.c0; c1 = v.c1;
    //    }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(uint v)
        {
            c0 = v; c1 = v;
        }
    //    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    //    public float2x2(uint2x2 v)
    //    {
    //        c0 = v.c0; c1 = v.c1;
    //    }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float2x2(double v)
        {
            c0 = (float2)v; c1 = (float2)v;
        }
    //    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    //    public float2x2(double2x2 v)
    //    {
    //        c0 = (float2)v.c0; c1 = (float2)v.c1;
    //    }
        #endregion

        #region IRowsMatrixRxC
        public int rows => ROWS;
		public int columns => COLUMNS;
		public int length => LENGTH;

		public ref float this[int index] => throw new NotImplementedException();
		public ref float this[int r, int c] => throw new NotImplementedException();

		float2 IRowsMatrix2x2<float, float2>.c1
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => c1;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => c1 = value;
		}
		float2 IRowsMatrix2x1<float, float2>.c0
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => c0;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => c0 = value;
		}

		public float m00
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => c0.x;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => c0.x = value;
		}
		public float m01
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => c1.x;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => c1.x = value;
		}
		public float m10
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => c0.y;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => c0.y = value;
		}
		public float m11
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get => c1.y;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			set => c1.y = value;
		}

		public float x 
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => c0.x; 
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => c1.x = value; 
        }
		public float y 
        { 
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => c0.y; 
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => c1.y = value; 
        }
        #endregion

        #region Arithmetic operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator *(float2x2 a, float2x2 b) => new float2x2(a.c0 * b.c0, a.c1 * b.c1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator *(float2x2 a, float b) => new float2x2(a.c0 * b, a.c1 * b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator *(float a, float2x2 b) => new float2x2(a * b.c0, a * b.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator +(float2x2 a, float2x2 b) => new float2x2(a.c0 + b.c0, a.c1 + b.c1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator +(float2x2 a, float b) => new float2x2(a.c0 + b, a.c1 + b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator +(float a, float2x2 b) => new float2x2(a + b.c0, a + b.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator -(float2x2 a, float2x2 b) => new float2x2(a.c0 - b.c0, a.c1 - b.c1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator -(float2x2 a, float b) => new float2x2(a.c0 - b, a.c1 - b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator -(float a, float2x2 b) => new float2x2(a - b.c0, a - b.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator /(float2x2 a, float2x2 b) => new float2x2(a.c0 / b.c0, a.c1 / b.c1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator /(float2x2 a, float b) => new float2x2(a.c0 / b, a.c1 / b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator /(float a, float2x2 b) => new float2x2(a / b.c0, a / b.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator %(float2x2 a, float2x2 b) => new float2x2(a.c0 % b.c0, a.c1 % b.c1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator %(float2x2 a, float b) => new float2x2(a.c0 % b, a.c1 % b);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator %(float a, float2x2 b) => new float2x2(a % b.c0, a % b.c1);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator ++(float2x2 a) => new float2x2(++a.c0, ++a.c1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator --(float2x2 a) => new float2x2(--a.c0, --a.c1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator -(float2x2 a) => new float2x2(-a.c0, -a.c1);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float2x2 operator +(float2x2 a) => new float2x2(+a.c0, +a.c1);
        #endregion

        #region Boolean operators
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(float2x2 a, float2x2 b) => a.c0 == b.c0 && a.c1 == b.c1;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(float2x2 a, float b) => a.c0 == b && a.c1 == b;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(float a, float2x2 b) => a == b.c0 && a == b.c1;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(float2x2 a, float2x2 b) => a.c0 != b.c0 || a.c1 != b.c1;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(float2x2 a, float b) => a.c0 != b || a.c1 != b;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(float a, float2x2 b) => a != b.c0 || a != b.c1;
        #endregion

        #region Enumerator
        VectorEnumerator<float, float2x2> IEnumerableVector<float, float2x2>.GetEnumerator() => new VectorEnumerator<float, float2x2>(this);
		IEnumerator<float> IEnumerable<float>.GetEnumerator() => new VectorEnumerator<float, float2x2>(this);
		IEnumerator IEnumerable.GetEnumerator() => new VectorEnumerator<float, float2x2>(this);
		public Enumerator GetEnumerator() => new Enumerator(this);
		public unsafe ref struct Enumerator
		{
			private readonly float* _pointer;
			private sbyte _index;
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public Enumerator(in float2x2 value)
			{
				fixed (float2x2* array = &value)
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

		#region IEquatable/IFormattable
		public bool Equals(float2x2 other)
		{
			return
				c0.Equals(other.c0) &&
				c1.Equals(other.c1);
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public string ToString(string format, IFormatProvider formatProvider)
		{
			return $"{nameof(float2x2)}(" +
				$"({m00.ToString(formatProvider)}, {m10.ToString(formatProvider)}), " +
				$"({m01.ToString(formatProvider)}, {m11.ToString(formatProvider)}))";
		}
		#endregion

		#region Object
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString()
		{
			return $"{nameof(float2x2)}(" +
				$"({m00}, {m10}), " +
				$"({m01}, {m11}))";
		}
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object o) => o is float2 target && Equals(target);
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override int GetHashCode()
		{
			return math.hash(this);
		}
        #endregion

		#region Utils
		internal class DebuggerProxy
		{
            public float2 c0;
            public float2 c1;
			public DebuggerProxy(float2x2 v)
			{
                c0 = v.c0;
				c1 = v.c1;
			}
		}
		#endregion
	}
}
