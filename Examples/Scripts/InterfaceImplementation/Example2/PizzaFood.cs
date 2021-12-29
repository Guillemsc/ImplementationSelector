using UnityEngine;

namespace Juce.ImplementationSelector.Example2
{
    [System.Serializable]
    public class PizzaFood : IFood
    {
        [SerializeField, Min(0)] private string pizzaType = default;
        [SerializeField, Min(0)] private int ammountOfSlices = default;
    }
}
