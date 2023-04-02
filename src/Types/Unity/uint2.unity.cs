#if UNITY_5_3_OR_NEWER
using System.Runtime.CompilerServices;
using UnityEngine;

namespace DCFApixels.DataMath
{
    public partial struct uint2
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Vector2(uint2 a) => new Vector2(a.x, a.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Vector2Int(uint2 a) => new Vector2Int((int)a.x, (int)a.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Vector3(uint2 a) => new Vector3(a.x, a.y, 0f);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Vector3Int(uint2 a) => new Vector3Int((int)a.x, (int)a.y, 0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Vector4(uint2 a) => new Vector4(a.x, a.y, 0f, 0f);
    }

    public static partial class math
    {
        
    }
}
#endif