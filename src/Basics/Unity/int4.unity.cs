#if UNITY_5_3_OR_NEWER
#if DISABLE_DEBUG
#undef DEBUG
#endif
using UnityEngine;
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct int4
    {
        [IN(LINE)] public int4(Vector2 v) { x = (int)v.x; y = (int)v.y; z = 0; w = 0; }
        [IN(LINE)] public int4(Vector2Int v) { x = v.x; y = v.y; z = 0; w = 0; }
        [IN(LINE)] public int4(Vector3 v) { x = (int)v.x; y = (int)v.y; z = (int)v.z; w = 0; }
        [IN(LINE)] public int4(Vector3Int v) { x = v.x; y = v.y; z = v.z; w = 0; }
        [IN(LINE)] public int4(Vector4 v) { x = (int)v.x; y = (int)v.y; z = (int)v.z; w = (int)v.w; }

        [IN(LINE)] public static explicit operator Vector2(int4 a) { return new Vector2(a.x, a.y); }
        [IN(LINE)] public static explicit operator Vector2Int(int4 a) { return new Vector2Int(a.x, a.y); }
        [IN(LINE)] public static explicit operator Vector3(int4 a) { return new Vector3(a.x, a.y, a.z); }
        [IN(LINE)] public static explicit operator Vector3Int(int4 a) { return new Vector3Int(a.x, a.y, a.z); }
        [IN(LINE)] public static implicit operator Vector4(int4 a) { return new Vector4(a.x, a.y, a.z, a.w); }

        [IN(LINE)] public static explicit operator int4(Vector2 a) { return new int4(a); }
        [IN(LINE)] public static implicit operator int4(Vector2Int a) { return new int4(a); }
        [IN(LINE)] public static explicit operator int4(Vector3 a) { return new int4(a); }
        [IN(LINE)] public static implicit operator int4(Vector3Int a) { return new int4(a); }
        [IN(LINE)] public static explicit operator int4(Vector4 a) { return new int4(a); }
    }
}

#if UNITY_EDITOR
namespace DCFApixels.DataMath.Unity.Editors
{
    [UnityEditor.CustomPropertyDrawer(typeof(int4))] internal class Int4Editor : VectorFieldDrawer { }
}
#endif

#endif