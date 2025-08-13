using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DCFApixels.DataMath
{
    /// <summary>Not Implemented</summary>
    [DebuggerTypeProxy(typeof(DebuggerProxy))]
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 4, Size = 8)]
    public partial struct ray1 : IRay1<float>
    {
        public float origin;
        public float direction;

        #region IRayN
        float IRay1<float>.origin
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => origin;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => origin = value;
        }
        float IRay1<float>.direction
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => direction;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => direction = value;
        }
        public float OriginX
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => origin;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => origin = value;
        }
        public float DirectionX
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => direction;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => direction = value;
        }
        #endregion

        #region Utils
        internal class DebuggerProxy
        {
            public float origin;
            public float direction;
            public DebuggerProxy(ray1 v)
            {
                origin = v.origin;
                direction = v.direction;
            }
        }
        #endregion
    }
}
