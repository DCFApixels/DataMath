#if UNITY_5_3_OR_NEWER
using System.Runtime.CompilerServices;
using UnityEngine;

namespace DCFApixels.DataMath
{
    public partial struct float4
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Vector2(float4 a) => new Vector2(a.x, a.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Vector2Int(float4 a) => new Vector2Int((int)a.x, (int)a.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Vector3(float4 a) => new Vector3(a.x, a.y, a.z);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Vector3Int(float4 a) => new Vector3Int((int)a.x, (int)a.y, (int)a.z);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Vector4(float4 a) => new Vector4(a.x, a.y, a.z, a.w);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(Vector2 a) => new float4(a.x, a.y, 0f, 0f);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(Vector2Int a) => new float4(a.x, a.y, 0f, 0f);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(Vector3 a) => new float4(a.x, a.y, a.z, 0f);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(Vector3Int a) => new float4(a.x, a.y, a.z, 0f);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float4(Vector4 a) => new float4(a.x, a.y, a.z, a.w);
    }
}
#endif