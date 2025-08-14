using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    [DebuggerTypeProxy(typeof(DebuggerProxy))]
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 24)]
    public partial struct ray3 :
        IEquatable<ray3>,
        IFormattable,
        IRay3<float, float3>
    {
        public float3 origin;
        public float3 direction;

        #region IRayN
        float3 IRay3<float, float3>.origin
        {
            [IN(LINE)]
            get => origin;
            [IN(LINE)]
            set => origin = value;
        }
        float3 IRay3<float, float3>.direction
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
        public float OriginZ
        {
            [IN(LINE)]
            get => origin.z;
            [IN(LINE)]
            set => origin.z = value;
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
        public float DirectionZ
        {
            [IN(LINE)]
            get => direction.z;
            [IN(LINE)]
            set => direction.z = value;
        }
        #endregion

        #region Constructors
        [IN(LINE)]
        public ray3(float3 origin, float3 direction)
        {
            this.origin = origin;
            this.direction = direction;
        }
        [IN(LINE)]
        public ray3(float3 direction) : this(float3.zero, direction) { }
        #endregion

        #region operators
        [IN(LINE)] public static ray3 operator -(ray3 a) => new ray3(a.origin, -a.direction);
        [IN(LINE)] public static ray3 operator +(ray3 a) => new ray3(a.origin, +a.direction);

        [IN(LINE)] public static bool operator ==(ray3 a, ray3 b) { return (a.origin == b.origin) == (a.direction == b.direction) == DM.all; }
        [IN(LINE)] public static bool operator !=(ray3 a, ray3 b) { return !(a == b); }
        #endregion

        #region Other 
        [IN(LINE)] public override int GetHashCode() { return DM.Hash(this); }
        public override bool Equals(object o) { return o is ray3 target && Equals(target); }
        [IN(LINE)] public bool Equals(ray3 a) { return this == a; }
        public override string ToString() { return $"{nameof(ray3)}({origin}, {direction})"; }
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"{nameof(ray3)}({origin.ToString(format, formatProvider)}, {direction.ToString(format, formatProvider)})";
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
        [IN(LINE)] public static ray3 Move(ray3 ray, float distance) => new ray3(ray.origin, ray.origin + ray.direction * distance);
        [IN(LINE)] public static float3 GetPoint(ray3 ray, float distance) => ray.origin + ray.direction * distance;
    }

    public static partial class DM
    {
        [IN(LINE)] public static int Hash(ray3 a) => Hash(a.origin) ^ Hash(a.direction);
        [IN(LINE)] public static uint UHash(ray3 a) => unchecked((uint)Hash(a));
    }

    public static partial class DM
    {
        [IN(LINE)] public static ray3 Ray3(float3 origin, float3 direction) => new ray3(origin, direction);
        [IN(LINE)] public static ray3 Ray3(float3 direction) => new ray3(direction);
    }
}
