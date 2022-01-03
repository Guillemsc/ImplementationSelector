using System;

namespace Juce.ImplementationSelector
{
    public class SelectImplementationTooltipAttribute : Attribute
    {
        public string Tooltip { get; }

        public SelectImplementationTooltipAttribute(string tooltip)
        {
            Tooltip = tooltip;
        }
    }
}