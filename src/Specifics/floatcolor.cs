using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DCFApixels.DataMath
{
    //TODO придумать получше имя, color не подохоидт изза конфликта с неймингом переменных, floatcolor получше отражает смысл, но слишком длинное
    //вроде есть еще ваиранты floatclr, colorinfo, colordata но они все все еще не идеальны
    [DebuggerTypeProxy(typeof(DebuggerProxy))]
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 4, Size = 16)]
    public struct floatcolor : IColor, IVector4<float>
    {
        #region Consts
        public static int LENGTH = 4;

        /// <summary> rgba(1, 0, 0, 1) </summary>
        public readonly static floatcolor red = new floatcolor(1f, 0f, 0f);
        /// <summary> rgba(0, 1, 0, 1) </summary>
        public readonly static floatcolor green = new floatcolor(0f, 1f, 0f);
        /// <summary> rgba(0, 0, 1, 1) </summary>
        public readonly static floatcolor blue = new floatcolor(0f, 0f, 0f);
        /// <summary> rgba(0, 0, 0, 0) </summary>
        public readonly static floatcolor clean = new floatcolor(0f, 0f, 0f, 0f);

        /// <summary> rgba(1, 1, 1, 1) </summary>
        public readonly static floatcolor white = new floatcolor(1f, 1f, 1f);
        /// <summary> rgba(0.5, 0.5, 0.5, 1) </summary>
        public readonly static floatcolor gray = new floatcolor(0.5f, 0.5f, 0.5f);
        /// <summary> rgba(0.5, 0.5, 0.5, 1) </summary>
        public readonly static floatcolor grey = gray;
        /// <summary> rgba(0, 0, 0, 1) </summary>
        public readonly static floatcolor black = new floatcolor(0f, 0f, 0f);

        /// <summary> rgba(1, 1, 0, 1) </summary>
        public readonly static floatcolor yellow = new floatcolor(1f, 1f, 0f);    
        /// <summary> rgba(1, 0.5, 0, 1) </summary>
        public readonly static floatcolor orange = new floatcolor(1f, 0.5f, 0f);
        /// <summary> rgba(0, 1, 1, 1) </summary>
        public readonly static floatcolor cyan = new floatcolor(0f, 1f, 1f);
        /// <summary> rgba(1, 0, 1, 1) </summary>
        public readonly static floatcolor magenta = new floatcolor(1f, 0f, 1f);
        #endregion

        public float r;
        public float g;
        public float b;
        public float a;

        #region Constructors
        public floatcolor(float r, float g, float b)
        {
            this.r = r; this.g = g;
            this.b = b; this.a = 1f;
        }
        public floatcolor(float r, float g, float b, float a)
        {
            this.r = r; this.g = g;
            this.b = b; this.a = a;
        }
        /// <summary>accepting color code constructor</summary>
        public floatcolor(ColorCodeUnion colorcode)
        {
            r = colorcode.r;
            g = colorcode.g;
            b = colorcode.b;
            a = colorcode.a;
        }
        #endregion

        #region IColor
        float IColor.r { get => r; set => r = value; }
        float IColor.g { get => g; set => g = value; }
        float IColor.b { get => b; set => b = value; }
        float IColor.a { get => a; set => a = value; }
        #endregion

        #region IVectorN
        public float x { get => r; set => r = value; }
        public float y { get => g; set => g = value; }
        public float z { get => b; set => b = value; }
        public float w { get => a; set => a = value; }

        public unsafe ref float this[int index]
        {
            get
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > LENGTH) throw new IndexOutOfRangeException($"index must be between[0...{(LENGTH - 1)}]");
#endif
                fixed (floatcolor* array = &this) { return ref ((float*)array)[index]; }
            }
        }
        public int length => LENGTH;
        #endregion

        public static implicit operator floatcolor(int colorcode) => new floatcolor(colorcode);
        public static implicit operator floatcolor(uint colorcode) => new floatcolor(colorcode);

        #region Utils
        internal class DebuggerProxy
        {
            public float r;
            public float g;
            public float b;
            public float a;
            public DebuggerProxy(floatcolor v)
            {
                r = v.r;
                g = v.g;
                b = v.b;
                a = v.a;
            }
        }
        #endregion
    }
}
