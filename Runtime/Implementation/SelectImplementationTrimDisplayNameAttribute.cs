using System;

namespace Juce.ImplementationSelector
{
    public class SelectImplementationTrimDisplayNameAttribute : Attribute
    {
        public string TrimDisplayNameValue { get; }

        public SelectImplementationTrimDisplayNameAttribute(string trimDisplayNameValue)
        {
            TrimDisplayNameValue = trimDisplayNameValue;
        }
    }
}