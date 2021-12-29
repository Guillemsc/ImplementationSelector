using UnityEngine;

namespace Juce.ImplementationSelector.Example2
{
    [SelectImplementationDefaultType]
    [SelectImplementationCustomDisplayName("Custom Apple display")]
    [System.Serializable]
    public class AppleFood : IFood
    {
        [SerializeField] private string appleName = default;
    }
}
