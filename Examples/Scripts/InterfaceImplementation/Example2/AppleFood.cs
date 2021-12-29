using UnityEngine;

namespace Juce.ImplementationSelector.Example2
{
    [SelectImplementationDefaultType]
    [SelectImplementationTooltip("Apple tooltip")]
    [System.Serializable]
    public class AppleFood : IFood
    {
        [SerializeField] private string appleName = default;
    }
}
