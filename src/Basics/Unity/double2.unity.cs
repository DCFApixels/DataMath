#if UNITY_5_3_OR_NEWER
using System.Runtime.CompilerServices;
using UnityEngine;

namespace DCFApixels.DataMath
{
    public partial struct double2
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Vector2(double2 a) => new Vector2((float)a.x, (float)a.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Vector2Int(double2 a) => new Vector2Int((int)a.x, (int)a.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Vector3(double2 a) => new Vector3((float)a.x, (float)a.y, 0f);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Vector3Int(double2 a) => new Vector3Int((int)a.x, (int)a.y, 0);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator Vector4(double2 a) => new Vector4((float)a.x, (float)a.y, 0f, 0f);


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(Vector2 a) => new double2(a.x, a.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double2(Vector2Int a) => new double2(a.x, a.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double2(Vector3 a) => new double2(a.x, a.y);
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double2(Vector3Int a) => new double2(a.x, a.y);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator double2(Vector4 a) => new double2(a.x, a.y);
    }

    public static partial class math
    {

    }
}
#endif