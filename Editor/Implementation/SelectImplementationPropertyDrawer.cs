using Juce.ImplementationSelector.Data;
using Juce.ImplementationSelector.Extensions;
using Juce.ImplementationSelector.Layout;
using Juce.ImplementationSelector.Logic;
using UnityEditor;
using UnityEngine;

namespace Juce.ImplementationSelector
{
    [CustomPropertyDrawer(typeof(SelectImplementationAttribute))]
    public class SelectImplementationPropertyDrawer : PropertyDrawer
    {
        private readonly PropertyDrawerLayoutHelper layoutHelper = new PropertyDrawerLayoutHelper();

        private readonly EditorData editorData = new EditorData();

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            SelectImplementationAttribute typeAttribute = (SelectImplementationAttribute)attribute;

            float height = layoutHelper.GetElementsHeight(1);

            bool isCollapsed = !property.isExpanded && !typeAttribute.ForceExpanded;

            if (isCollapsed)
            {
                return height;
            }

            return height + property.GetVisibleChildHeight();
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SelectImplementationAttribute typeAttribute = (SelectImplementationAttribute)attribute;

            TryCacheTypesLogic.Execute(editorData, typeAttribute);
            TryCacheNamesGuiContentLogic.Execute(editorData, typeAttribute);

            bool typeIndexFound = TryGetTypeIndexLogic.Execute(
                editorData,
                property,
                out int typeIndex
                );

            bool isUninitalized = !typeIndexFound && editorData.Types.Length > 0;

            if (isUninitalized)
            {
                typeIndex = GetDefaultTypeIndexLogic.Execute(editorData);

                InitializePropertyAtIndexLogic.Execute(
                    editorData,
                    property,
                    typeIndex
                    );
            }

            if (Event.current.type == EventType.Layout)
            {
                return;
            }

            layoutHelper.Init(position);

            bool shouldDrawChildren = (property.hasVisibleChildren && property.isExpanded) || typeAttribute.ForceExpanded;

            Rect popupRect = layoutHelper.NextVerticalRect();

            GUIContent finalLabel = GUIContent.none;

            if (typeAttribute.DisplayLabel)
            {
                finalLabel = label;
            }

            if (typeAttribute.ForceExpanded)
            {
                property.isExpanded = true;
            }
            else
            {
                property.isExpanded = EditorGUI.Foldout(popupRect, property.isExpanded, GUIContent.none);
            }

            int newTypeIndex = EditorGUI.Popup(
                popupRect, 
                finalLabel, 
                typeIndex, 
                editorData.NamesGuiContent
                );

            if (newTypeIndex != typeIndex)
            {
                InitializePropertyAtIndexLogic.Execute(
                    editorData,
                    property, 
                    newTypeIndex
                    );
            }

            if (!shouldDrawChildren && !property.isExpanded)
            {
                return;
            }

            EditorGUI.indentLevel++;
            {
                property.ForeachVisibleChildren(DrawChildPropertyField);
            }
            EditorGUI.indentLevel--;
        }

        private void DrawChildPropertyField(SerializedProperty childProperty)
        {
            EditorGUI.PropertyField(
                layoutHelper.NextVerticalRect(childProperty), 
                childProperty, 
                includeChildren: true
                );
        }
    }
}

