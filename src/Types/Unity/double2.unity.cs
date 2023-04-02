#if UNITY_5_3_OR_NEWER
using UnityEngine;

namespace DCFApixels.DataMath
{
    public partial struct double2
    {
        public static implicit operator Vector2(double2 a) => new Vector2((float)a.x, (float)a.y);
        public static implicit operator Vector2Int(double2 a) => new Vector2Int((int)a.x, (int)a.y);

        public static implicit operator Vector3(double2 a) => new Vector3((float)a.x, (float)a.y, 0f);
        public static implicit operator Vector3Int(double2 a) => new Vector3Int((int)a.x, (int)a.y, 0);

        public static implicit operator Vector4(double2 a) => new Vector4((float)a.x, (float)a.y, 0f, 0f);
    }

    public static partial class math
    {
        
    }
}
#endif