#if UNITY_5_3_OR_NEWER && UNITY_EDITOR
using System;
using UnityEditor;
using UnityEngine;

namespace DCFApixels.DataMath.Unity.Editors
{
    [CustomPropertyDrawer(typeof(Swizzle))]
    public sealed class SwizzleFieldDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            Swizzle currentValue = (Swizzle)property.enumValueIndex;
            string currentString = currentValue.ToString();

            Rect fieldPosition = EditorGUI.PrefixLabel(position, label);
            string newString = EditorGUI.TextField(fieldPosition, currentString);

            if (newString != currentString)
            {
                Swizzle result = SwizzleUtility.ParseSafe(newString);
                if (Enum.IsDefined(typeof(Swizzle), result))
                {
                    property.enumValueIndex = (int)result;
                }
            }
            EditorGUI.EndProperty();
        }
    }
}
#endif