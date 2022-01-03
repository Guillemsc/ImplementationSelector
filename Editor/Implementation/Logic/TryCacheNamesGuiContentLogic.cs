using Juce.ImplementationSelector.Data;
using Juce.ImplementationSelector.Extensions;
using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Juce.ImplementationSelector.Logic
{
    public static class TryCacheNamesGuiContentLogic
    {
        public static void Execute(
            EditorData editorData,
            SelectImplementationAttribute typeAttribute
            )
        {
            if (editorData.NamesGuiContent != null)
            {
                return;
            }

            Type baseType = typeAttribute.FieldType;

            string removeTailString = GetRemoveTailString(baseType);

            editorData.NamesGuiContent = new GUIContent[editorData.Types.Length];

            for (int i = 0; i < editorData.Types.Length; ++i)
            {
                Type type = editorData.Types[i];

                bool hasCustomDisplayName = TryGetCustomDisplayName(
                    type,
                    out string customDisplayName
                    );

                if (hasCustomDisplayName)
                {
                    editorData.NamesGuiContent[i] = new GUIContent(
                        ObjectNames.NicifyVariableName(customDisplayName),
                        GetTypeTooltip(type)
                        );
                }
                else
                {
                    editorData.NamesGuiContent[i] = new GUIContent(
                        ObjectNames.NicifyVariableName(type.Name.RemoveTail(removeTailString)),
                        GetTypeTooltip(type)
                        );
                }
            }
        }

        private static string GetTypeTooltip(Type type)
        {
            SelectImplementationTooltipAttribute tooltipAttribute = Attribute.GetCustomAttribute(
                type,
                typeof(SelectImplementationTooltipAttribute)
                ) as SelectImplementationTooltipAttribute;

            if (tooltipAttribute == null)
            {
                return string.Empty;
            }

            return tooltipAttribute.Tooltip;
        }

        private static string GetRemoveTailString(Type type)
        {
            SelectImplementationTrimDisplayNameAttribute trimDisplayNameAttribute
                = Attribute.GetCustomAttribute(
                    type,
                    typeof(SelectImplementationTrimDisplayNameAttribute)
                    ) as SelectImplementationTrimDisplayNameAttribute;

            if (trimDisplayNameAttribute == null)
            {
                return string.Empty;
            }

            return trimDisplayNameAttribute.TrimDisplayNameValue;
        }

        private static bool TryGetCustomDisplayName(
            Type type,
            out string customName
            )
        {
            SelectImplementationCustomDisplayNameAttribute customDisplayNameAttribute
                = Attribute.GetCustomAttribute(
                    type,
                    typeof(SelectImplementationCustomDisplayNameAttribute)
                    ) as SelectImplementationCustomDisplayNameAttribute;

            if (customDisplayNameAttribute == null)
            {
                customName = default;
                return false;
            }

            customName = customDisplayNameAttribute.CustomDisplayName;
            return true;
        }
    }
}