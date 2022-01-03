using Juce.ImplementationSelector.Data;
using System;
using UnityEditor;
using UnityEngine;

namespace Juce.ImplementationSelector.Logic
{
    public static class InitializePropertyAtIndexLogic
    {
        public static void Execute(
            EditorData editorData,
            SerializedProperty property, 
            int typeIndex
           )
        {
            if(editorData.Types.Length == 0)
            {
                return;
            }

            typeIndex = Mathf.Clamp(typeIndex, 0, editorData.Types.Length - 1);

            Type type = editorData.Types[typeIndex];

            property.managedReferenceValue = Activator.CreateInstance(type);
            property.serializedObject.ApplyModifiedProperties();
        }
    }
}