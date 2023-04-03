using System;

namespace DCFApixels.DataMath
{
    //TODO придумать получше имя, color не подохоидт изза конфликта с неймингом переменных, floatcolor получше отражает смысл, но слишком длинное
    public struct floatcolor : IColor, IValue4<float>
    {
        #region Consts
        public static int length = 4;

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
                fixed (floatcolor* array = &this) { return ref ((float*)array)[index]; }
            }
        }
        public int Length => length;
        #endregion

        public static implicit operator floatcolor(int colorcode) => new floatcolor(colorcode);
        public static implicit operator floatcolor(uint colorcode) => new floatcolor(colorcode);
    }
}
