#if UNITY_5_3_OR_NEWER
#if DISABLE_DEBUG
#undef DEBUG
#endif
using UnityEngine;
using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct int3
    {
        [IN(LINE)] public int3(Vector2 v) { x = (int)v.x; y = (int)v.y; z = 0; }
        [IN(LINE)] public int3(Vector2Int v) { x = v.x; y = v.y; z = 0; }
        [IN(LINE)] public int3(Vector3 v) { x = (int)v.x; y = (int)v.y; z = (int)v.z; }
        [IN(LINE)] public int3(Vector3Int v) { x = v.x; y = v.y; z = v.z; }
        [IN(LINE)] public int3(Vector4 v) { x = (int)v.x; y = (int)v.y; z = (int)v.z; }

        [IN(LINE)] public static explicit operator Vector2(int3 a) { return new Vector2(a.x, a.y); }
        [IN(LINE)] public static explicit operator Vector2Int(int3 a) { return new Vector2Int(a.x, a.y); }
        [IN(LINE)] public static implicit operator Vector3(int3 a) { return new Vector3(a.x, a.y, a.z); }
        [IN(LINE)] public static implicit operator Vector3Int(int3 a) { return new Vector3Int(a.x, a.y, a.z); }
        [IN(LINE)] public static implicit operator Vector4(int3 a) { return new Vector4(a.x, a.y, a.z, 0f); }

        [IN(LINE)] public static explicit operator int3(Vector2 a) { return new int3(a); }
        [IN(LINE)] public static implicit operator int3(Vector2Int a) { return new int3(a); }
        [IN(LINE)] public static explicit operator int3(Vector3 a) { return new int3(a); }
        [IN(LINE)] public static implicit operator int3(Vector3Int a) { return new int3(a); }
        [IN(LINE)] public static explicit operator int3(Vector4 a) { return new int3(a); }
    }
}

#if UNITY_EDITOR
namespace DCFApixels.DataMath.Unity.Editors
{
    [UnityEditor.CustomPropertyDrawer(typeof(int3))] internal class Int3Editor : VectorFieldDrawer { }
}
#endif

#endif