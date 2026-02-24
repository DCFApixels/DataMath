#if UNITY_5_3_OR_NEWER && UNITY_EDITOR
using DCFApixels.DataMath.DisplayAttributes;
using System;
using UnityEditor;
using UnityEngine;

namespace DCFApixels.DataMath.Unity.Editors
{
    [CustomPropertyDrawer(typeof(VectorFieldAttribute))]
    public unsafe class VectorFieldDrawer : VectorFieldDrawerBase<VectorFieldAttribute>
    {
        protected override bool IsHideDefaultDraw
        {
            get
            {
                if (!IsAttribute) { return true; }
                return !Attribute.IsShowDefaultDraw;
            }
        }
        protected override void DrawLine(Rect position, SerializedProperty property, GUIContent label)
        {
            if (Error)
            {
                EditorGUI.LabelField(position, label, "ERROR");
                return;
            }


            EditorGUIUtility.labelWidth = 12f;
            EditorGUI.indentLevel = 0;



            if (Attribute == null || string.IsNullOrEmpty(Attribute.Swizzle))
            {
                position.width = position.width / FieldCount;
                position.xMin += 3f;
                float width = position.width;

                bool x = true;
                int depth = property.depth;
                while (property.Next(x))
                {
                    if (property.depth <= depth) { break; }

                    label.text = property.displayName;
                    label.tooltip = property.tooltip;
                    if (property.propertyType == SerializedPropertyType.Boolean)
                    {
                        Color c = property.boolValue ? Color.white : Color.black;
                        c.a = 0.1f;
                        EditorGUI.DrawRect(position, c);
                    }
                    EditorGUI.PropertyField(position, property, label);
                    position.x += width;
                    x = false;
                }
            }
            else
            {
                int drawedCount = 0;
                char* axiss = stackalloc char[4] { 'x', 'y', 'z', 'w' };
                var axisIndex = -1;
                var swizzle = Attribute.Swizzle.AsSpan();

                position.width = position.width / swizzle.Length;
                position.xMin += 3f;
                float width = position.width;
                Rect zeroPos = position;

                bool x = true;
                int depth = property.depth;
                while (property.Next(x))
                {
                    if (property.depth <= depth) { break; }
                    axisIndex++;
                    var axis = axiss[axisIndex];

                    for (int i = 0; i < swizzle.Length; i++)
                    {
                        if (swizzle[i] != axis) { continue; }
                        position = zeroPos;
                        position.x += width * i;

                        label.text = property.displayName;
                        label.tooltip = property.tooltip;
                        if (property.propertyType == SerializedPropertyType.Boolean)
                        {
                            Color c = property.boolValue ? Color.white : Color.black;
                            c.a = 0.1f;
                            EditorGUI.DrawRect(position, c);
                        }
                        EditorGUI.PropertyField(position, property, label);
                        drawedCount++;
                    }

                    if(drawedCount >= swizzle.Length)
                    {
                        break;
                    }
                    x = false;
                }
            }
        }
    }
}
#endif