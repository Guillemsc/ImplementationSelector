using System;

namespace Juce.ImplementationSelector
{
    public class SelectImplementationOptionTooltipAttribute : Attribute
    {
        public string Tooltip { get; }

        public SelectImplementationOptionTooltipAttribute(string tooltip)
        {
            Tooltip = tooltip;
        }
    }
}