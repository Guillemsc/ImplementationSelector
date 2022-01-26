using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Juce.ImplementationSelector.Example2
{
    [System.Serializable]
    public class GrapesFood : IFood
    {
        [SerializeField, Min(0)] private int ammountOfGrapes = default;
    }
}
