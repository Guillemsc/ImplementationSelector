using System;
using UnityEngine;

namespace Juce.ImplementationSelector
{
    public class SelectImplementationAttribute : PropertyAttribute
    {
        public Type FieldType { get; }
        public bool DisplayLabel { get; }
        public bool ForceExpanded { get; }

        public SelectImplementationAttribute(
            Type type,
            bool displayLabel = true,
            bool forceExpanded = false
            )
        {
            FieldType = type;
            DisplayLabel = displayLabel;
            ForceExpanded = forceExpanded;
        }
    }
}