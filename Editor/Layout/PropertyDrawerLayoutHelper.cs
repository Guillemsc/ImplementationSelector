using UnityEditor;

using UnityEngine;

namespace Juce.ImplementationSelector.Layout
{
    public class PropertyDrawerLayoutHelper
    {
        private Rect totalRect;
        private Rect currentRect;

        private bool isFirst;

        public Rect TotalRect => totalRect;

        public void Init(Rect rect)
        {
            this.totalRect = new Rect(rect.position, Vector2.zero);
            this.currentRect = rect;

            this.isFirst = true;
        }

        public Rect NextVerticalRect(float height)
        {
            currentRect.height = height;

            if (!isFirst)
            {
                height += 2f;
                currentRect.y = totalRect.y + totalRect.height + 2.0f;
            }

            totalRect.height += height;

            isFirst = false;

            return currentRect;
        }

        public Rect NextVerticalRect()
        {
            return NextVerticalRect(EditorGUIUtility.singleLineHeight);
        }

        public Rect NextVerticalRect(SerializedProperty serializedProperty)
        {
            return NextVerticalRect(EditorGUI.GetPropertyHeight(serializedProperty));
        }

        public float GetElementsHeight(int elementsCount)
        {
            if (elementsCount <= 0)
            {
                return 0.0f;
            }

            return (elementsCount * (EditorGUIUtility.singleLineHeight + 2)) + 2;
        }
    }
}