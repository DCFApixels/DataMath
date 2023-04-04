using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace DCFApixels.DataMath.TODO
{
    /// <summary>Not Implemented</summary>
    [DebuggerTypeProxy(typeof(DebuggerProxy))]
    [Serializable]
    [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 16)]
    public partial struct ray2 : IRay2<float, float2>
    {
        public float2 origin;
        public float2 direction;

        #region IRayN
        float2 IRay2<float, float2>.origin
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => origin;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => origin = value;
        }
        float2 IRay2<float, float2>.direction
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => direction;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => direction = value;
        }
        public float OriginX
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => origin.x;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => origin.x = value;
        }
        public float OriginY
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => origin.y;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => origin.y = value;
        }
        public float DirectionX
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => direction.x;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => direction.x = value;
        }
        public float DirectionY
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => direction.y;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => direction.y = value;
        }
        #endregion

        #region Utils
        internal class DebuggerProxy
        {
            public float2 origin;
            public float2 direction;
            public DebuggerProxy(ray2 v)
            {
                origin = v.origin;
                direction = v.direction;
            }
        }
        #endregion
    }
}
