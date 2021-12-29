using System;
using UnityEditor;

namespace Juce.ImplementationSelector.Extensions
{
    public static class SerializedPropertyExtensions 
    {
        public static float GetVisibleChildHeight(this SerializedProperty serializedProperty)
        {
            if (!serializedProperty.hasVisibleChildren)
            {
                return 0;
            }

            float height = 0f;
            SerializedProperty endProperty = serializedProperty.GetEndProperty();

            serializedProperty.NextVisible(true);

            while (!SerializedProperty.EqualContents(serializedProperty, endProperty))
            {
                height += EditorGUI.GetPropertyHeight(serializedProperty);
                serializedProperty.NextVisible(false);
            }

            return height;
        }

        public static void ForeachVisibleChildren(
            this SerializedProperty serializedProperty, 
            Action<SerializedProperty> action
            )
        {
            if (!serializedProperty.hasVisibleChildren)
            {
                return;
            }

            SerializedProperty endProperty = serializedProperty.GetEndProperty();

            serializedProperty.NextVisible(true);

            while (!SerializedProperty.EqualContents(serializedProperty, endProperty))
            {
                action.Invoke(serializedProperty);
                serializedProperty.NextVisible(false);
            }
        }
    }
}