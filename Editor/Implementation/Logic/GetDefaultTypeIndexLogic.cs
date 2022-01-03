using Juce.ImplementationSelector.Data;
using System;

namespace Juce.ImplementationSelector.Logic
{
    public static class GetDefaultTypeIndexLogic
    {
        public static int Execute(
            EditorData editorData
           )
        {
            for (int i = 0; i < editorData.Types.Length; ++i)
            {
                Type type = editorData.Types[i];

                SelectImplementationDefaultTypeAttribute defaultAttribute = Attribute.GetCustomAttribute(
                    type,
                    typeof(SelectImplementationDefaultTypeAttribute)
                    ) as SelectImplementationDefaultTypeAttribute;

                if (defaultAttribute != null)
                {
                    return i;
                }
            }

            return 0;
        }
    }
}