using UnityEngine;

namespace Juce.ImplementationSelector.Example2
{
    public class SelectImplementationExample2 : MonoBehaviour
    {
        [SelectImplementation(typeof(IFood))]
        [SerializeField, SerializeReference] private IFood food = default;
    }
}
