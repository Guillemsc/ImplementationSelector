using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Juce.ImplementationSelector.Example2
{
    [System.Serializable]
    public class GrapesFood : IFood
    {
        [SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "<Pending>")]
        [SerializeField, Min(0)] private int ammountOfGrapes = default;
    }
}
