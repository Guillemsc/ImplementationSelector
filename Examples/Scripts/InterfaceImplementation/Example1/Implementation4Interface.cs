using System.Collections.Generic;
using UnityEngine;

namespace Juce.ImplementationSelector.Example1
{
    [System.Serializable]
    [SelectImplementationCustomDisplayName("Nested")]
    public class Implementation4Interface : IInteraface
    {
        [SelectImplementation(typeof(IInteraface))]
        [SerializeField, SerializeReference] private List<IInteraface> listImplementations = new List<IInteraface>();
    }
}
