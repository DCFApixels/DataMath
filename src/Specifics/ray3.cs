using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DCFApixels.DataMath.TODO
{
    /// <summary>Not Implemented</summary>
    public partial struct ray3 : IRay3<float, float3>
    {
        public float3 origin;
        public float3 direction;

        #region Properties
        float3 IRay3<float, float3>.origin
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => origin;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => origin = value;
        }
        float3 IRay3<float, float3>.direction
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
        public float OriginZ
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => origin.z;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => origin.z = value;
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
        public float DirectionZ
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => direction.z;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => direction.z = value;
        }
        #endregion
    }
}
