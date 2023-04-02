#if UNITY_5_3_OR_NEWER
using UnityEngine;

namespace DCFApixels.DataMath
{
    public partial struct int3
    {
        public static explicit operator Vector2(int3 a) => new Vector2(a.x, a.y);
        public static explicit operator Vector2Int(int3 a) => new Vector2Int(a.x, a.y);

        public static explicit operator Vector3(int3 a) => new Vector3(a.x, a.y, a.z);
        public static explicit operator Vector3Int(int3 a) => new Vector3Int(a.x, a.y, a.z);

        public static explicit operator Vector4(int3 a) => new Vector4(a.x, a.y, a.z, 0f);
    }

    public static partial class math
    {
        
    }
}
#endif