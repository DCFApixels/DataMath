#if UNITY_5_3_OR_NEWER
#if DISABLE_DEBUG
#undef DEBUG
#endif
using UnityEngine;
using static DCFApixels.DataMath.Consts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct double4
    {
        [IN(LINE)] public double4(Vector2 v) { x = v.x; y = v.y; z = 0; w = 0; }
        [IN(LINE)] public double4(Vector2Int v) { x = v.x; y = v.y; z = 0; w = 0; }
        [IN(LINE)] public double4(Vector3 v) { x = v.x; y = v.y; z = v.z; w = 0; }
        [IN(LINE)] public double4(Vector3Int v) { x = v.x; y = v.y; z = v.z; w = 0; }
        [IN(LINE)] public double4(Vector4 v) { x = v.x; y = v.y; z = v.z; w = v.w; }

        [IN(LINE)] public static explicit operator Vector2(double4 a) { return new Vector2((float)a.x, (float)a.y); }
        [IN(LINE)] public static explicit operator Vector2Int(double4 a) { return new Vector2Int((int)a.x, (int)a.y); }
        [IN(LINE)] public static explicit operator Vector3(double4 a) { return new Vector3((float)a.x, (float)a.y, (float)a.z); }
        [IN(LINE)] public static explicit operator Vector3Int(double4 a) { return new Vector3Int((int)a.x, (int)a.y, (int)a.z); }
        [IN(LINE)] public static explicit operator Vector4(double4 a) { return new Vector4((float)a.x, (float)a.y, (float)a.z, (float)a.w); }

        [IN(LINE)] public static implicit operator double4(Vector2 a) { return new double4(a); }
        [IN(LINE)] public static implicit operator double4(Vector2Int a) { return new double4(a); }
        [IN(LINE)] public static implicit operator double4(Vector3 a) { return new double4(a); }
        [IN(LINE)] public static implicit operator double4(Vector3Int a) { return new double4(a); }
        [IN(LINE)] public static implicit operator double4(Vector4 a) { return new double4(a); }
    }
}

#if UNITY_EDITOR
namespace DCFApixels.DataMath.Unity.Editors
{
    [UnityEditor.CustomPropertyDrawer(typeof(double4))] internal class Double4Editor : VectorFieldDrawer { }
}
#endif

#endif