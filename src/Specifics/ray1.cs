using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DCFApixels.DataMath.TODO
{
    /// <summary>Not Implemented</summary>
    public partial struct ray1 : IRay1<float>
    {
        public float origin;
        public float direction;
        #region Properties
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
    }
}
