using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Juce.ImplementationSelector.Example2
{
    [SelectImplementationDefaultType]
    [System.Serializable]
    public class AppleFood : IFood
    {
        [SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "<Pending>")]
        [SerializeField] private string appleName = default;
    }
}
