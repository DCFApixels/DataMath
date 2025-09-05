#if UNITY_5_3_OR_NEWER
#if DISABLE_DEBUG
#undef DEBUG
#endif
using UnityEngine;
using static DCFApixels.DataMath.InlineConsts;
using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct color
    {
        [IN(LINE)] public color(Color v) { r = v.r; g = v.g; b = v.b; a = v.a; }
        [IN(LINE)] public color(Color32 v) { this = new color(new color32(v)); }

        [IN(LINE)] public static explicit operator Color(color a) { return new Color(a.r, a.g, a.b, a.a); }
        [IN(LINE)] public static explicit operator Color32(color a) { return new Color(a.r, a.g, a.b, a.a); }

        [IN(LINE)] public static implicit operator color(Color a) { return new color(a); }
        [IN(LINE)] public static implicit operator color(Color32 a) { return new color(a); }
    }
}

#if UNITY_EDITOR
namespace DCFApixels.DataMath.Unity.Editors
{
    [UnityEditor.CustomPropertyDrawer(typeof(color))] internal class ColorEditor : ColorFieldDrawer { }
}
#endif

#endif