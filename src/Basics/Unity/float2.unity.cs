#if UNITY_5_3_OR_NEWER
using System.Runtime.CompilerServices;
using UnityEngine;

namespace DCFApixels.DataMath
{
    public partial struct float2
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Vector2(float2 a) => new Vector2(a.x, a.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Vector2Int(float2 a) => new Vector2Int((int)a.x, (int)a.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Vector3(float2 a) => new Vector3(a.x, a.y, 0f);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Vector3Int(float2 a) => new Vector3Int((int)a.x, (int)a.y, 0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Vector4(float2 a) => new Vector4(a.x, a.y, 0f, 0f);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(Vector2 a) => new float2(a.x, a.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float2(Vector2Int a) => new float2(a.x, a.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float2(Vector3 a) => new float2(a.x, a.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float2(Vector3Int a) => new float2(a.x, a.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator float2(Vector4 a) => new float2(a.x, a.y);
    }

    public static partial class math
    {
        
    }
}
#endif