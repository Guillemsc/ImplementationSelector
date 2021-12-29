using System;

namespace Juce.ImplementationSelector
{
    public class SelectImplementationCustomDisplayNameAttribute : Attribute
    {
        public string CustomDisplayName { get; }

        public SelectImplementationCustomDisplayNameAttribute(string customDisplayName)
        {
            CustomDisplayName = customDisplayName;
        }
    }
}