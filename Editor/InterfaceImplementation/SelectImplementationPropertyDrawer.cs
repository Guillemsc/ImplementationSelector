using Juce.ImplementationSelector.Data;
using Juce.ImplementationSelector.Extensions;
using Juce.ImplementationSelector.Layout;
using Juce.ImplementationSelector.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Juce.ImplementationSelector
{
    [CustomPropertyDrawer(typeof(SelectImplementationAttribute))]
    public class SelectImplementationPropertyDrawer : PropertyDrawer
    {
        private readonly PropertyDrawerLayoutHelper layoutHelper = new PropertyDrawerLayoutHelper();
        private readonly Dictionary<string, int> typeIndexMap = new Dictionary<string, int>();

        private readonly EditorData editorData = new EditorData();

        private GUIContent[] names;
        private PropertyDrawer propertyDrawer;
        private int previousTypeIndex = -1;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var typeAttribute = (SelectImplementationAttribute)attribute;

            float height = layoutHelper.GetElementsHeight(1);

            if(!property.isExpanded && !typeAttribute.ForceExpanded)
            {
                return height;
            }

            if (propertyDrawer == null)
            {
                return height + property.GetVisibleChildHeight();
            }

            return height + propertyDrawer.GetPropertyHeight(property, label);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SelectImplementationAttribute typeAttribute = (SelectImplementationAttribute)attribute;

            TryGetTypes(typeAttribute);

            int typeIndex = GetCurrentTypeIndex(property);

            if (editorData.Types.Length > 0 && typeIndex == -1)
            {
                bool defaultFound = TryGetDefaultType(out int defaultTypeIndex);

                if (defaultFound)
                {
                    typeIndex = defaultTypeIndex;
                }
                else
                {
                    typeIndex = 0;
                }

                InitializePropertyAtIndexLogic.Execute(
                    editorData,
                    property,
                    typeIndex
                    );
            }

            if (typeIndex != previousTypeIndex)
            {
                previousTypeIndex = typeIndex;
            }

            layoutHelper.Init(position);

            bool useExpand = property.hasVisibleChildren && !typeAttribute.ForceExpanded;

            Rect popupRect = layoutHelper.NextVerticalRect();

            if (typeAttribute.DisplayLabel)
            {
                SplitLabelFieldLogic.Execute(
                    popupRect, 
                    out Rect labelRect, 
                    out popupRect, 
                    applyIndent: false
                    );

                if (useExpand)
                {
                    property.isExpanded = EditorGUI.Foldout(labelRect, property.isExpanded, label);
                }
                else
                {
                    EditorGUI.LabelField(labelRect, label);
                }
            }
            else if (useExpand)
            {
                SplitLabelFieldLogic.Execute(
                    popupRect, 
                    out Rect labelRect, 
                    out popupRect, 
                    applyIndent: false
                    );
                
                property.isExpanded = EditorGUI.Foldout(labelRect, property.isExpanded, GUIContent.none);
            }

            int nextTypeIndex = EditorGUI.Popup(popupRect, typeIndex, names);

            if (nextTypeIndex != typeIndex)
            {
                InitializePropertyAtIndexLogic.Execute(
                    editorData,
                    property, 
                    nextTypeIndex
                    );
            }

            if (useExpand && !property.isExpanded)
            {
                return;
            }

            EditorGUI.indentLevel++;

            if (propertyDrawer == null)
            {
                property.ForeachVisibleChildren(DrawChildPropertyField);
            }
            else
            {
                propertyDrawer.OnGUI(layoutHelper.NextVerticalRect(property), property, names[typeIndex]);
            }

            EditorGUI.indentLevel--;
        }

        private void TryGetTypes(SelectImplementationAttribute typeAttribute)
        {
            if(editorData.Types != null)
            {
                return;
            }

            Type baseType = typeAttribute.FieldType;

            SelectImplementationTrimDisplayNameAttribute trimDisplayNameAttribute 
                = (SelectImplementationTrimDisplayNameAttribute)Attribute.GetCustomAttribute(baseType, typeof(SelectImplementationTrimDisplayNameAttribute));
            
            string removeTailString = trimDisplayNameAttribute?.TrimDisplayNameValue ?? string.Empty;

            editorData.Types = GetTypes(baseType).ToArray();

            names = editorData.Types.Select(x =>
                new GUIContent(
                    ObjectNames.NicifyVariableName(x.Name.RemoveTail(removeTailString)
                    ),
                    GetTypeTooltip(x)
                )
            ).ToArray();
        }

        private bool TryGetDefaultType(out int defaultTypeIndex)
        {
            for (int i = 0; i < editorData.Types.Length; ++i)
            {
                Type type = editorData.Types[i];

                SelectImplementationDefaultTypeAttribute defaultAttribute = Attribute.GetCustomAttribute(
                    type,
                    typeof(SelectImplementationDefaultTypeAttribute)
                    ) as SelectImplementationDefaultTypeAttribute;

                if(defaultAttribute != null)
                {
                    defaultTypeIndex = i;
                    return true;
                }
            }

            defaultTypeIndex = default;
            return false;
        }

        private static string GetTypeTooltip(Type type)
        {
            SelectImplementationOptionTooltipAttribute tooltipAttribute = Attribute.GetCustomAttribute(
                type, 
                typeof(SelectImplementationOptionTooltipAttribute)
                ) as SelectImplementationOptionTooltipAttribute;
            
            return tooltipAttribute != null ? tooltipAttribute.Tooltip : string.Empty;
        }

        private static IEnumerable<Type> GetTypes(Type type)
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(x => type.IsAssignableFrom(x) && !x.IsAbstract && !x.IsSubclassOf(typeof(UnityEngine.Object)));
        }

        private void DrawChildPropertyField(SerializedProperty childProperty)
        {
            EditorGUI.PropertyField(layoutHelper.NextVerticalRect(childProperty), childProperty, true);
        }

        private int GetCurrentTypeIndex(SerializedProperty property)
        {
            string propertyTypeName = property.managedReferenceFullTypename;

            bool typeFound = typeIndexMap.TryGetValue(propertyTypeName, out int typeIndex);

            if (typeFound)
            {
                return typeIndex;
            }

            for (int i = 0; i < editorData.Types.Length; i++)
            {
                string typeFullName = editorData.Types[i].FullName;

                if (propertyTypeName.Contains(typeFullName))
                {
                    typeIndexMap.Add(propertyTypeName, i);
                    return i;
                }
            }

            return -1;
        }
    }
}

