using System.Collections.Generic;
using UnityEngine;

namespace Juce.ImplementationSelector
{
    public class SelectImplementationExample : MonoBehaviour
    {
        [SelectImplementation(typeof(IInteraface))]
        [SerializeField, SerializeReference] private List<IInteraface> implementations = new List<IInteraface>();
    }
}
