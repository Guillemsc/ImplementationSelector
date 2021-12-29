namespace Juce.ImplementationSelector.Example1
{
    [System.Serializable]
    [SelectImplementationDefaultType]
    public class Implementation2Interface : IInteraface
    {
        public string stringValue = default;
    }
}
