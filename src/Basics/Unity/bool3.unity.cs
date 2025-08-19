
#if UNITY_5_3_OR_NEWER
#if DISABLE_DEBUG
#undef DEBUG
#endif
//using UnityEngine;
//using static DCFApixels.DataMath.Consts;
//using IN = System.Runtime.CompilerServices.MethodImplAttribute;

namespace DCFApixels.DataMath
{
    public partial struct bool3
    {

    }
}

#if UNITY_EDITOR
namespace DCFApixels.DataMath.Unity.Editors
{
    [UnityEditor.CustomPropertyDrawer(typeof(bool3))] internal class Bool3Editor : VectorFieldDrawer { }
}
#endif

#endif