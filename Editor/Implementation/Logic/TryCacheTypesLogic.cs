using UnityEditor;
using Juce.ImplementationSelector.Data;
using System;
using System.Linq;


namespace Juce.ImplementationSelector.Logic
{
    public static class TryCacheTypesLogic
    {
        public static void Execute(
            EditorData editorData,
            SelectImplementationAttribute typeAttribute
            )
        {
            if (editorData.Types != null)
            {
                return;
            }

            Type baseType = typeAttribute.FieldType;

            editorData.Types = TypeCache.GetTypesDerivedFrom(baseType).Where(x => 
	            baseType != x &&
	            baseType.IsAssignableFrom(x) &&
	            !x.IsAbstract &&
	            !x.IsSubclassOf(typeof(UnityEngine.Object)) &&
	            (x.GetConstructor(Type.EmptyTypes) != null || x.IsValueType)
            ).ToArray();
        }
    }
}