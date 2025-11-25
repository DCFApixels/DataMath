#pragma warning disable CS8981
#if DISABLE_DEBUG
#undef DEBUG
#endif
#if ENABLE_IL2CPP
using Unity.IL2CPP.CompilerServices;
#endif
using System;
using System.Diagnostics;
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
    public unsafe partial struct line3 :
        IEquatable<line3>,
        IFormattable,
        IRange3Impl<float, float3>
    {
        public float3 a;
        public float3 b;

        #region IRangeN
        public float3 src
        {
            [IN(LINE)]
            get { return a; }
            [IN(LINE)]
            set
            {
                var direction = b - a;
                a = value;
                b = value + direction;
            }
        }
        public float3 dir
        {
            [IN(LINE)]
            get { return b - a; }
            [IN(LINE)]
            set { b = a + value; }
        }
        float3 IRangeN<float, float3>.a { [IN(LINE)] get { return a; } [IN(LINE)] set { a = value; } }
        float3 IRangeN<float, float3>.b { [IN(LINE)] get { return b; } [IN(LINE)] set { b = value; } }
        public float3 min
        {
            [IN(LINE)]
            get { return DM.Min(a, b); }
            [IN(LINE)]
            set
            {
                var currentMax = DM.Max(a, b);
                a = value;
                b = currentMax;
            }
        }
        public float3 max
        {
            [IN(LINE)]
            get { return DM.Max(a, b); }
            [IN(LINE)]
            set
            {
                var currentMin = DM.Min(a, b);
                a = currentMin;
                b = value;
            }
        }
        public float3 center
        {
            [IN(LINE)]
            get { return (a + b) * 0.5f; }
            [IN(LINE)]
            set
            {
                var halfSize = (b - a) * 0.5f;
                a = value - halfSize;
                b = value + halfSize;
            }
        }
        bool IRangeN.IsVectorN { [IN(LINE)] get { return true; } }
        object IRangeN.GetSrcRaw() { return src; }
        object IRangeN.GetDirRaw() { return dir; }
        void IRangeN.SetSrcRaw(object raw) { src = (float3)raw; }
        void IRangeN.SetDirRaw(object raw) { dir = (float3)raw; }
        [IN(LINE)] Type IRangeN.GetComponentType() { return typeof(float3); }
        #endregion

        #region Other
        [IN(LINE)] public override int GetHashCode() { return DM.Hash(a) ^ DM.Hash(b); }
        [IN(LINE)] public override bool Equals(object o) { return o is ray3 target && Equals(target); }
        [IN(LINE)] public bool Equals(line3 a) { return DM.All(this.a == a.a && b == a.b); }
        [IN(LINE)] public override string ToString() { return $"{nameof(ray3)}({src}, {dir})"; }
        [IN(LINE)]
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return $"{nameof(ray3)}({src.ToString(format, formatProvider)}, {dir.ToString(format, formatProvider)})";
        }
        internal class DebuggerProxy
        {
            public float3 src;
            public float3 dir;
            public DebuggerProxy(ray3 v)
            {
                src = v.src;
                dir = v.dir;
            }
        }
        #endregion
    }
}
