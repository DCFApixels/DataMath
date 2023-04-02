#if UNITY_5_3_OR_NEWER
using UnityEngine;

namespace DCFApixels.DataMath
{
    public partial struct int2
    {
        public static explicit operator Vector2(int2 a) => new Vector2(a.x, a.y);
        public static explicit operator Vector2Int(int2 a) => new Vector2Int(a.x, a.y);

        public static explicit operator Vector3(int2 a) => new Vector3(a.x, a.y, 0f);
        public static explicit operator Vector3Int(int2 a) => new Vector3Int(a.x, a.y, 0);

        public static explicit operator Vector4(int2 a) => new Vector4(a.x, a.y, 0f, 0f);
    }

    public static partial class math
    {
        
    }
}
#endif