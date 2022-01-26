using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Juce.ImplementationSelector.Example2
{
    [SelectImplementationDefaultType]
    [System.Serializable]
    public class AppleFood : IFood
    {
        [SerializeField]
        private string appleName = default;
    }
}
