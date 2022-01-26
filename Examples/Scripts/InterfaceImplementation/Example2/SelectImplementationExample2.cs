using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Juce.ImplementationSelector.Example2
{
    public class SelectImplementationExample2 : MonoBehaviour
    {
        [SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "<Pending>")]
        [SelectImplementation(typeof(IFood))]
        [SerializeField, SerializeReference]
        private IFood food = default;
    }
}
