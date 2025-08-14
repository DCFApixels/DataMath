using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    /// <summary>Not Implemented</summary>
    [DebuggerTypeProxy(typeof(DebuggerProxy))]
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 16)]
    public partial struct ray2 :
        IEquatable<ray2>,
        IFormattable,
        IRay2<float, float2>
    {
        public float2 origin;
        public float2 direction;

        #region IRayN
        float2 IRay2<float, float2>.origin
        {
            [IN(LINE)]
            get => origin;
            [IN(LINE)]
            set => origin = value;
        }
        float2 IRay2<float, float2>.direction
        {
            [IN(LINE)]
            get => direction;
            [IN(LINE)]
            set => direction = value;
        }
        public float OriginX
        {
            [IN(LINE)]
            get => origin.x;
            [IN(LINE)]
            set => origin.x = value;
        }
        public float OriginY
        {
            [IN(LINE)]
            get => origin.y;
            [IN(LINE)]
            set => origin.y = value;
        }
        public float DirectionX
        {
            [IN(LINE)]
            get => direction.x;
            [IN(LINE)]
            set => direction.x = value;
        }
        public float DirectionY
        {
            [IN(LINE)]
            get => direction.y;
            [IN(LINE)]
            set => direction.y = value;
        }
        #endregion

        #region Constructors
        [IN(LINE)]
        public ray2(float2 origin, float2 direction)
        {
            this.origin = origin;
            this.direction = direction;
        }
        [IN(LINE)]
        public ray2(float2 direction) : this(float2.zero, direction) { }
        #endregion

        #region operators
        [IN(LINE)] public static ray2 operator -(ray2 a) => new ray2(a.origin, -a.direction);
        [IN(LINE)] public static ray2 operator +(ray2 a) => new ray2(a.origin, +a.direction);

        [IN(LINE)] public static bool operator ==(ray3 a, ray3 b) { return (a.origin == b.origin) == (a.direction == b.direction) == DM.all; }
        [IN(LINE)] public static bool operator !=(ray3 a, ray3 b) { return !(a == b); }
        #endregion

        #region Other 
        [IN(LINE)] public override int GetHashCode() => DM.Hash(this);
        public override bool Equals(object o) => o is ray2 target && Equals(target);
        [IN(LINE)] public bool Equals(ray2 a) => origin == a.origin && direction == a.direction;
        public override string ToString() => $"{nameof(ray2)}({origin}, {direction})";
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"{nameof(ray2)}({origin.ToString(format, formatProvider)}, {direction.ToString(format, formatProvider)})";
        }

        internal class DebuggerProxy
        {
            public float3 origin, direction;
            public DebuggerProxy(ray3 v)
            {
                origin = v.origin;
                direction = v.direction;
            }
        }
        #endregion
    }

    public static partial class DM
    {
        [IN(LINE)] public static ray2 Move(ray2 ray, float distance) => new ray2(ray.origin, ray.origin + ray.direction * distance);
        [IN(LINE)] public static float2 GetPoint(ray2 ray, float distance) => ray.origin + ray.direction * distance;
    }

    public static partial class DM
    {
        [IN(LINE)] public static int Hash(ray2 a) => Hash(a.origin) ^ Hash(a.direction);
        [IN(LINE)] public static uint UHash(ray2 a) => unchecked((uint)Hash(a));
    }

    public static partial class DM
    {
        [IN(LINE)] public static ray2 Ray2(float2 origin, float2 direction) => new ray2(origin, direction);
        [IN(LINE)] public static ray2 Ray2(float2 direction) => new ray2(direction);
    }
}
