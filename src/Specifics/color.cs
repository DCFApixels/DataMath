using System;

namespace DCFApixels.DataMath
{
    public struct color : IColor, IValue4<float>
    {
        public static int length = 4;

        public readonly static color red; 
        public readonly static color green; 
        public readonly static color blue; 
        public readonly static color clean;
                
        public readonly static color white;
        public readonly static color gray;
        public readonly static color grey;
        public readonly static color black;
                
        public readonly static color yellow;
        public readonly static color orange;
        public readonly static color cyan;

        public float r;
        public float g;
        public float b;
        public float a;

        #region IColor
        float IColor.r { get => r; set => r = value; }
        float IColor.g { get => g; set => g = value; }
        float IColor.b { get => b; set => b = value; }
        float IColor.a { get => a; set => a = value; }
        #endregion

        #region IValueN
        float IValue2<float>.x { get => r; set => r = value; }
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
    }
}
