namespace Juce.ImplementationSelector.Example1
{
    [System.Serializable]
    [SelectImplementationCustomDisplayName("Custom display")]
    public class Implementation1Interface : IInteraface
    {
        public int intValue = default;
    }
}
