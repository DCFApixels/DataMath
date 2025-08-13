#if DISABLE_DEBUG
#undef DEBUG
#endif
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    [DebuggerTypeProxy(typeof(DebuggerProxy))]
    [Serializable]
    public partial struct bool2 :
        IBoolVector,
        IEquatable<bool2>,
        IVector2<bool>,
        IColor,
        IEnumerableVector<bool, bool2>
    {
        #region Consts
        public const int Count = 2;

        ///<summary>(0, 0)</summary>
        public static readonly bool2 zero = new bool2(0, 0);
        ///<summary>(1, 1)</summary>
        public static readonly bool2 one = new bool2(1, 1);

        ///<summary>(-1, 0)</summary>
        public static readonly bool2 left = new bool2(-1, 0);
        ///<summary>(1, 0)</summary>
        public static readonly bool2 right = new bool2(1, 0);
        ///<summary>(0, -1)</summary>
        public static readonly bool2 down = new bool2(0, -1);
        ///<summary>(0, 1)</summary>
        public static readonly bool2 up = new bool2(0, 1);
        #endregion

        public bool x;
        public bool y;

        #region IColor
        public float r { [IN(LINE)] get => x ? 1f : 0f; [IN(LINE)] set => x = value > 0; }
        public float g { [IN(LINE)] get => y ? 1f : 0f; [IN(LINE)] set => y = value > 0; }
        public float b { [IN(LINE)] get => 0f; [IN(LINE)] set { } }
        public float a { [IN(LINE)] get => 1f; [IN(LINE)] set { } }
        #endregion

        #region IVectorN
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool IVector1<bool>.x { [IN(LINE)] get => x; [IN(LINE)] set => x = value; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool IVector2<bool>.y { [IN(LINE)] get => y; [IN(LINE)] set => y = value; }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int count { [IN(LINE)] get => Count; }
        public bool all { [IN(LINE)] get => x & y; [IN(LINE)] set { x = value; y = value; } }
        public bool any { [IN(LINE)] get => x | y; }

        public unsafe bool this[int index]
        {
            get
            {
#if DEBUG || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > Count) throw new IndexOutOfRangeException($"Index must be between[0..{(Count - 1)}].");
#endif
                fixed (bool2* array = &this) { return ((bool*)array)[index]; }
            }
            set
            {
#if DEBUG || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > Count) throw new IndexOutOfRangeException($"Index must be between[0..{(Count - 1)}].");
#endif
                fixed (bool* array = &x) { array[index] = value; }
            }
        }
        #endregion

        #region Constructors
        [IN(LINE)] public bool2(bool x, bool y) { this.x = x; this.y = y; }
        [IN(LINE)] public bool2(bool v) { x = v; y = v; }
        [IN(LINE)] public bool2(bool2 v) { x = v.x; y = v.y; }
        [IN(LINE)] public bool2(float x, float y) { this.x = x > 0; this.y = y > 0; }
        [IN(LINE)] public bool2(float v) { x = v > 0; y = v > 0; }
        [IN(LINE)] public bool2(float2 v) { x = v.x > 0; y = v.y > 0; }
        [IN(LINE)] public bool2(double x, double y) { this.x = x > 0; this.y = y > 0; }
        [IN(LINE)] public bool2(double v) { x = v > 0; y = v > 0; }
        [IN(LINE)] public bool2(double2 v) { x = v.x > 0; y = v.y > 0; }
        [IN(LINE)] public bool2(int x, int y) { this.x = x > 0; this.y = y > 0; }
        [IN(LINE)] public bool2(int v) { x = v > 0; y = v > 0; }
        [IN(LINE)] public bool2(int2 v) { x = v.x > 0; y = v.y > 0; }
        [IN(LINE)] public bool2(uint x, uint y) { this.x = x > 0; this.y = y > 0; }
        [IN(LINE)] public bool2(uint v) { x = v > 0; y = v > 0; }
        [IN(LINE)] public bool2(uint2 v) { x = v.x > 0; y = v.y > 0; }
        #endregion

        #region operators

        #region Bits
        [IN(LINE)] public static bool2 operator !(bool2 a) => new bool2(!a.x, !a.y);

        [IN(LINE)] public static bool2 operator |(bool2 a, bool2 b) => new bool2(a.x | b.x, a.y | b.y);
        [IN(LINE)] public static bool2 operator |(bool2 a, bool b) => new bool2(a.x | b, a.y | b);
        [IN(LINE)] public static bool2 operator |(bool a, bool2 b) => new bool2(a | b.x, a | b.y);

        [IN(LINE)] public static bool2 operator &(bool2 a, bool2 b) => new bool2(a.x & b.x, a.y & b.y);
        [IN(LINE)] public static bool2 operator &(bool2 a, bool b) => new bool2(a.x & b, a.y & b);
        [IN(LINE)] public static bool2 operator &(bool a, bool2 b) => new bool2(a & b.x, a & b.y);

        [IN(LINE)] public static bool2 operator ^(bool2 a, bool2 b) => new bool2(a.x ^ b.x, a.y ^ b.y);
        [IN(LINE)] public static bool2 operator ^(bool2 a, bool b) => new bool2(a.x ^ b, a.y ^ b);
        [IN(LINE)] public static bool2 operator ^(bool a, bool2 b) => new bool2(a ^ b.x, a ^ b.y);
        #endregion

        #region Boolean

        [IN(LINE)] public static bool2 operator ==(bool2 a, bool2 b) => a.x == b.x && a.y == b.y;
        [IN(LINE)] public static bool2 operator ==(bool2 a, bool b) => a.x == b && a.y == b;
        [IN(LINE)] public static bool2 operator ==(bool a, bool2 b) => a == b.x && a == b.y;

        [IN(LINE)] public static bool2 operator !=(bool2 a, bool2 b) => a.x != b.x || a.y != b.y;
        [IN(LINE)] public static bool2 operator !=(bool2 a, bool b) => a.x != b || a.y != b;
        [IN(LINE)] public static bool2 operator !=(bool a, bool2 b) => a != b.x || a != b.y;

        [IN(LINE)] public static bool operator ==(bool2 a, DM.AllCheckMode b) { return a.all; }
        [IN(LINE)] public static bool operator !=(bool2 a, DM.AllCheckMode b) { return !a.all; }
        [IN(LINE)] public static bool operator ==(DM.AllCheckMode b, bool2 a) { return a.all; }
        [IN(LINE)] public static bool operator !=(DM.AllCheckMode b, bool2 a) { return !a.all; }

        [IN(LINE)] public static bool operator ==(bool2 a, DM.AnyCheckMode b) { return a.any; }
        [IN(LINE)] public static bool operator !=(bool2 a, DM.AnyCheckMode b) { return !a.any; }
        [IN(LINE)] public static bool operator ==(DM.AnyCheckMode b, bool2 a) { return a.any; }
        [IN(LINE)] public static bool operator !=(DM.AnyCheckMode b, bool2 a) { return !a.any; }
        #endregion

        #endregion

        #region Swaps

        #region Swap2
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool2 xx { [IN(LINE)] get => new bool2(x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool2 xy { [IN(LINE)] get => new bool2(x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool2 x_ { [IN(LINE)] get => new bool2(x, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool2 yx { [IN(LINE)] get => new bool2(y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool2 yy { [IN(LINE)] get => new bool2(y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool2 y_ { [IN(LINE)] get => new bool2(y, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool2 _x { [IN(LINE)] get => new bool2(false, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool2 _y { [IN(LINE)] get => new bool2(false, y); }
        #endregion

        #region Swap3
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 xxx { [IN(LINE)] get => new bool3(x, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 xxy { [IN(LINE)] get => new bool3(x, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 xx_ { [IN(LINE)] get => new bool3(x, x, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 xyx { [IN(LINE)] get => new bool3(x, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 xyy { [IN(LINE)] get => new bool3(x, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 xy_ { [IN(LINE)] get => new bool3(x, y, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 x_x { [IN(LINE)] get => new bool3(x, false, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 x_y { [IN(LINE)] get => new bool3(x, false, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 x__ { [IN(LINE)] get => new bool3(x, false, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 yxx { [IN(LINE)] get => new bool3(y, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 yxy { [IN(LINE)] get => new bool3(y, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 yx_ { [IN(LINE)] get => new bool3(y, x, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 yyx { [IN(LINE)] get => new bool3(y, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 yyy { [IN(LINE)] get => new bool3(y, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 yy_ { [IN(LINE)] get => new bool3(y, y, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 y_x { [IN(LINE)] get => new bool3(y, false, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 y_y { [IN(LINE)] get => new bool3(y, false, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 y__ { [IN(LINE)] get => new bool3(y, false, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 _xx { [IN(LINE)] get => new bool3(false, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 _xy { [IN(LINE)] get => new bool3(false, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 _x_ { [IN(LINE)] get => new bool3(false, x, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 _yx { [IN(LINE)] get => new bool3(false, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 _yy { [IN(LINE)] get => new bool3(false, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 _y_ { [IN(LINE)] get => new bool3(false, y, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 __x { [IN(LINE)] get => new bool3(false, false, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool3 __y { [IN(LINE)] get => new bool3(false, false, y); }
        #endregion

        #region Swap4
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xxxx { [IN(LINE)] get => new bool4(x, x, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xxxy { [IN(LINE)] get => new bool4(x, x, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xxx_ { [IN(LINE)] get => new bool4(x, x, x, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xxyx { [IN(LINE)] get => new bool4(x, x, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xxyy { [IN(LINE)] get => new bool4(x, x, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xxy_ { [IN(LINE)] get => new bool4(x, x, y, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xx_x { [IN(LINE)] get => new bool4(x, x, false, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xx_y { [IN(LINE)] get => new bool4(x, x, false, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xx__ { [IN(LINE)] get => new bool4(x, x, false, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xyxx { [IN(LINE)] get => new bool4(x, y, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xyxy { [IN(LINE)] get => new bool4(x, y, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xyx_ { [IN(LINE)] get => new bool4(x, y, x, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xyyx { [IN(LINE)] get => new bool4(x, y, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xyyy { [IN(LINE)] get => new bool4(x, y, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xyy_ { [IN(LINE)] get => new bool4(x, y, y, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xy_x { [IN(LINE)] get => new bool4(x, y, false, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xy_y { [IN(LINE)] get => new bool4(x, y, false, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 xy__ { [IN(LINE)] get => new bool4(x, y, false, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 x_xx { [IN(LINE)] get => new bool4(x, false, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 x_xy { [IN(LINE)] get => new bool4(x, false, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 x_x_ { [IN(LINE)] get => new bool4(x, false, x, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 x_yx { [IN(LINE)] get => new bool4(x, false, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 x_yy { [IN(LINE)] get => new bool4(x, false, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 x_y_ { [IN(LINE)] get => new bool4(x, false, y, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 x__x { [IN(LINE)] get => new bool4(x, false, false, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 x__y { [IN(LINE)] get => new bool4(x, false, false, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 x___ { [IN(LINE)] get => new bool4(x, false, false, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yxxx { [IN(LINE)] get => new bool4(y, x, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yxxy { [IN(LINE)] get => new bool4(y, x, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yxx_ { [IN(LINE)] get => new bool4(y, x, x, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yxyx { [IN(LINE)] get => new bool4(y, x, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yxyy { [IN(LINE)] get => new bool4(y, x, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yxy_ { [IN(LINE)] get => new bool4(y, x, y, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yx_x { [IN(LINE)] get => new bool4(y, x, false, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yx_y { [IN(LINE)] get => new bool4(y, x, false, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yx__ { [IN(LINE)] get => new bool4(y, x, false, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yyxx { [IN(LINE)] get => new bool4(y, y, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yyxy { [IN(LINE)] get => new bool4(y, y, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yyx_ { [IN(LINE)] get => new bool4(y, y, x, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yyyx { [IN(LINE)] get => new bool4(y, y, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yyyy { [IN(LINE)] get => new bool4(y, y, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yyy_ { [IN(LINE)] get => new bool4(y, y, y, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yy_x { [IN(LINE)] get => new bool4(y, y, false, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yy_y { [IN(LINE)] get => new bool4(y, y, false, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 yy__ { [IN(LINE)] get => new bool4(y, y, false, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 y_xx { [IN(LINE)] get => new bool4(y, false, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 y_xy { [IN(LINE)] get => new bool4(y, false, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 y_x_ { [IN(LINE)] get => new bool4(y, false, x, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 y_yx { [IN(LINE)] get => new bool4(y, false, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 y_yy { [IN(LINE)] get => new bool4(y, false, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 y_y_ { [IN(LINE)] get => new bool4(y, false, y, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 y__x { [IN(LINE)] get => new bool4(y, false, false, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 y__y { [IN(LINE)] get => new bool4(y, false, false, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 y___ { [IN(LINE)] get => new bool4(y, false, false, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _xxx { [IN(LINE)] get => new bool4(false, x, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _xxy { [IN(LINE)] get => new bool4(false, x, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _xx_ { [IN(LINE)] get => new bool4(false, x, x, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _xyx { [IN(LINE)] get => new bool4(false, x, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _xyy { [IN(LINE)] get => new bool4(false, x, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _xy_ { [IN(LINE)] get => new bool4(false, x, y, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _x_x { [IN(LINE)] get => new bool4(false, x, false, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _x_y { [IN(LINE)] get => new bool4(false, x, false, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _x__ { [IN(LINE)] get => new bool4(false, x, false, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _yxx { [IN(LINE)] get => new bool4(false, y, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _yxy { [IN(LINE)] get => new bool4(false, y, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _yx_ { [IN(LINE)] get => new bool4(false, y, x, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _yyx { [IN(LINE)] get => new bool4(false, y, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _yyy { [IN(LINE)] get => new bool4(false, y, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _yy_ { [IN(LINE)] get => new bool4(false, y, y, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _y_x { [IN(LINE)] get => new bool4(false, y, false, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _y_y { [IN(LINE)] get => new bool4(false, y, false, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 _y__ { [IN(LINE)] get => new bool4(false, y, false, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 __xx { [IN(LINE)] get => new bool4(false, false, x, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 __xy { [IN(LINE)] get => new bool4(false, false, x, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 __x_ { [IN(LINE)] get => new bool4(false, false, x, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 __yx { [IN(LINE)] get => new bool4(false, false, y, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 __yy { [IN(LINE)] get => new bool4(false, false, y, y); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 __y_ { [IN(LINE)] get => new bool4(false, false, y, false); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 ___x { [IN(LINE)] get => new bool4(false, false, false, x); }
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool4 ___y { [IN(LINE)] get => new bool4(false, false, false, y); }
        #endregion

        #endregion


        #region Other 
        [IN(LINE)] public override int GetHashCode() => DM.Hash(this);
        public override bool Equals(object o) => o is bool2 target && Equals(target);
        [IN(LINE)] public bool Equals(bool2 a) => x == a.x && y == a.y;
        public override string ToString() => $"bool2({x}, {y})";

        internal class DebuggerProxy
        {
            public bool x, y;
            public DebuggerProxy(bool2 v) { x = v.x; y = v.y; }
        }
        #endregion

        #region Enumerator
        VectorEnumerator<bool, bool2> GetEnumerator() { return new VectorEnumerator<bool, bool2>(this); }
        VectorEnumerator<bool, bool2> IEnumerableVector<bool, bool2>.GetEnumerator() { return new VectorEnumerator<bool, bool2>(this); }
        IEnumerator<bool> IEnumerable<bool>.GetEnumerator() { return new VectorEnumerator<bool, bool2>(this); }
        IEnumerator IEnumerable.GetEnumerator() { return new VectorEnumerator<bool, bool2>(this); }
        #endregion
    }
}