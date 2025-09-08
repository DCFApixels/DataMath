#if UNITY_5_3_OR_NEWER
#pragma warning disable CS8981
#if DISABLE_DEBUG
#undef DEBUG
#endif
using UnityEngine;
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct uint3
    {
        [IN(LINE)] public uint3(Vector2 v) { x = (uint)v.x; y = (uint)v.y; z = 0; }
        [IN(LINE)] public uint3(Vector2Int v) { x = (uint)v.x; y = (uint)v.y; z = 0; }
        [IN(LINE)] public uint3(Vector3 v) { x = (uint)v.x; y = (uint)v.y; z = (uint)v.z; }
        [IN(LINE)] public uint3(Vector3Int v) { x = (uint)v.x; y = (uint)v.y; z = (uint)v.z; }
        [IN(LINE)] public uint3(Vector4 v) { x = (uint)v.x; y = (uint)v.y; z = (uint)v.z; }

        [IN(LINE)] public static explicit operator Vector2(uint3 a) { return new Vector2(a.x, a.y); }
        [IN(LINE)] public static explicit operator Vector2Int(uint3 a) { return new Vector2Int((int)a.x, (int)a.y); }
        [IN(LINE)] public static implicit operator Vector3(uint3 a) { return new Vector3(a.x, a.y, a.z); }
        [IN(LINE)] public static explicit operator Vector3Int(uint3 a) { return new Vector3Int((int)a.x, (int)a.y, (int)a.z); }
        [IN(LINE)] public static implicit operator Vector4(uint3 a) { return new Vector4(a.x, a.y, a.z, 0f); }

        [IN(LINE)] public static explicit operator uint3(Vector2 a) { return new uint3(a); }
        [IN(LINE)] public static explicit operator uint3(Vector2Int a) { return new uint3(a); }
        [IN(LINE)] public static explicit operator uint3(Vector3 a) { return new uint3(a); }
        [IN(LINE)] public static explicit operator uint3(Vector3Int a) { return new uint3(a); }
        [IN(LINE)] public static explicit operator uint3(Vector4 a) { return new uint3(a); }
    }
}

#if UNITY_EDITOR
namespace DCFApixels.DataMath.Unity.Editors
{
    [UnityEditor.CustomPropertyDrawer(typeof(uint3))] internal class UInt3Editor : VectorFieldDrawer { }
}
#endif

#endif