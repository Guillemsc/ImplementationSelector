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

            editorData.Types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(x => baseType.IsAssignableFrom(x) && !x.IsAbstract && !x.IsSubclassOf(typeof(UnityEngine.Object)))
                .ToArray();
        }
    }
}