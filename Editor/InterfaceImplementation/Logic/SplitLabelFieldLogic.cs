using UnityEditor;
using UnityEngine;

namespace Juce.ImplementationSelector.Logic
{
    public static class SplitLabelFieldLogic
    {
        public static void Execute(
           Rect rect,
           out Rect labelRect,
           out Rect fieldRect,
           float margin = 0,
           bool applyIndent = true
           )
        {
            Rect indentedContent = EditorGUI.IndentedRect(rect);

            float labelWidth = EditorGUIUtility.labelWidth - (indentedContent.xMin - rect.xMin) - margin;
            float fieldWidth = rect.width - labelWidth;

            Vector2 position = applyIndent ? indentedContent.position : rect.position;

            labelRect = new Rect(
                position,
                new Vector2(labelWidth, rect.height)
                );

            fieldRect = new Rect(
                position + new Vector2(labelWidth + margin, 0),
                new Vector2(fieldWidth - margin, rect.height)
                );
        }
    }
}