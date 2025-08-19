#if UNITY_5_3_OR_NEWER
#if DISABLE_DEBUG
#undef DEBUG
#endif
using UnityEngine;
using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct int2
    {
        [IN(LINE)] public int2(Vector2 v) { x = (int)v.x; y = (int)v.y; }
        [IN(LINE)] public int2(Vector2Int v) { x = v.x; y = v.y; }
        [IN(LINE)] public int2(Vector3 v) { x = (int)v.x; y = (int)v.y; }
        [IN(LINE)] public int2(Vector3Int v) { x = v.x; y = v.y; }
        [IN(LINE)] public int2(Vector4 v) { x = (int)v.x; y = (int)v.y; }

        [IN(LINE)] public static implicit operator Vector2(int2 a) { return new Vector2(a.x, a.y); }
        [IN(LINE)] public static implicit operator Vector2Int(int2 a) { return new Vector2Int(a.x, a.y); }
        [IN(LINE)] public static implicit operator Vector3(int2 a) { return new Vector3(a.x, a.y, 0f); }
        [IN(LINE)] public static implicit operator Vector3Int(int2 a) { return new Vector3Int(a.x, a.y, 0); }
        [IN(LINE)] public static implicit operator Vector4(int2 a) { return new Vector4(a.x, a.y, 0f, 0f); }

        [IN(LINE)] public static explicit operator int2(Vector2 a) { return new int2(a); }
        [IN(LINE)] public static implicit operator int2(Vector2Int a) { return new int2(a); }
        [IN(LINE)] public static explicit operator int2(Vector3 a) { return new int2(a); }
        [IN(LINE)] public static explicit operator int2(Vector3Int a) { return new int2(a); }
        [IN(LINE)] public static explicit operator int2(Vector4 a) { return new int2(a); }
    }
}

#if UNITY_EDITOR
namespace DCFApixels.DataMath.Unity.Editors
{
    [UnityEditor.CustomPropertyDrawer(typeof(int2))] internal class Int2Editor : VectorFieldDrawer { }
}
#endif

#endif