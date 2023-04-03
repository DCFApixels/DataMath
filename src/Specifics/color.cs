using System;

namespace DCFApixels.DataMath
{
    public struct color : IColor, IValue4<float>
    {
        #region Consts
        public static int length = 4;

        /// <summary> rgba(1, 0, 0, 1) </summary>
        public readonly static color red = new color(1f, 0f, 0f);
        /// <summary> rgba(0, 1, 0, 1) </summary>
        public readonly static color green = new color(0f, 1f, 0f);
        /// <summary> rgba(0, 0, 1, 1) </summary>
        public readonly static color blue = new color(0f, 0f, 0f);
        /// <summary> rgba(0, 0, 0, 0) </summary>
        public readonly static color clean = new color(0f, 0f, 0f, 0f);

        /// <summary> rgba(1, 1, 1, 1) </summary>
        public readonly static color white = new color(1f, 1f, 1f);
        /// <summary> rgba(0.5, 0.5, 0.5, 1) </summary>
        public readonly static color gray = new color(0.5f, 0.5f, 0.5f);
        /// <summary> rgba(0.5, 0.5, 0.5, 1) </summary>
        public readonly static color grey = gray;
        /// <summary> rgba(0, 0, 0, 1) </summary>
        public readonly static color black = new color(0f, 0f, 0f);

        /// <summary> rgba(1, 1, 0, 1) </summary>
        public readonly static color yellow = new color(1f, 1f, 0f);    
        /// <summary> rgba(1, 0.5, 0, 1) </summary>
        public readonly static color orange = new color(1f, 0.5f, 0f);
        /// <summary> rgba(0, 1, 1, 1) </summary>
        public readonly static color cyan = new color(0f, 1f, 1f);
        /// <summary> rgba(1, 0, 1, 1) </summary>
        public readonly static color magenta = new color(1f, 0f, 1f);
        #endregion

        public float r;
        public float g;
        public float b;
        public float a;

        #region Constructors
        public color(float r, float g, float b)
        {
            this.r = r; this.g = g;
            this.b = b; this.a = 1f;
        }
        public color(float r, float g, float b, float a)
        {
            this.r = r; this.g = g;
            this.b = b; this.a = a;
        }
        /// <summary>accepting color code constructor</summary>
        public color(ColorCodeUnion colorcode)
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

        #region IValueN
        float IValue1<float>.x { get => r; set => r = value; }
        float IValue2<float>.y { get => g; set => g = value; }
        float IValue3<float>.z { get => b; set => b = value; }
        float IValue4<float>.w { get => a; set => a = value; }

        public unsafe ref float this[int index]
        {
            get
            {
#if (DEBUG && !DISABLE_DEBUG) || !DCFADATAMATH_DISABLE_SANITIZE_CHECKS
                if (index > length) throw new IndexOutOfRangeException($"index must be between[0...{(length - 1)}]");
#endif
                fixed (color* array = &this) { return ref ((float*)array)[index]; }
            }
        }
        public int Length => length;
        #endregion

        public static implicit operator color(int colorcode) => new color(colorcode);
        public static implicit operator color(uint colorcode) => new color(colorcode);
    }
}
