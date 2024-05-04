#if UNITY_5_3_OR_NEWER
using System.Runtime.CompilerServices;
using UnityEngine;

namespace DCFApixels.DataMath
{
    public partial struct int2
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Vector2(int2 a) => new Vector2(a.x, a.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Vector2Int(int2 a) => new Vector2Int(a.x, a.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Vector3(int2 a) => new Vector3(a.x, a.y, 0f);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Vector3Int(int2 a) => new Vector3Int(a.x, a.y, 0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Vector4(int2 a) => new Vector4(a.x, a.y, 0f, 0f);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2(Vector2 a) => new int2(a.x, a.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int2(Vector2Int a) => new int2(a.x, a.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2(Vector3 a) => new int2(a.x, a.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2(Vector3Int a) => new int2(a.x, a.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator int2(Vector4 a) => new int2(a.x, a.y);
    }

    public static partial class math
    {

    }
}
#endif