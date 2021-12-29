using System.Collections.Generic;
using UnityEngine;

namespace Juce.ImplementationSelector.Example1
{
    public class SelectImplementationExample1 : MonoBehaviour
    {
        [SelectImplementation(typeof(IInteraface))]
        [SerializeField, SerializeReference] private List<IInteraface> listImplementations = new List<IInteraface>();

        [SelectImplementation(typeof(IInteraface), displayLabel: true, forceExpanded: true)]
        [SerializeField, SerializeReference] private List<IInteraface> listForceExpandImplementations = new List<IInteraface>();

        [SelectImplementation(typeof(IInteraface), displayLabel: false, forceExpanded: true)]
        [SerializeField, SerializeReference] private List<IInteraface> listForceExpandNoLabelImplementations = new List<IInteraface>();

        [Header("SingleImplementation")]
        [SelectImplementation(typeof(IInteraface))]
        [SerializeField, SerializeReference] private IInteraface singleImplementation = new Implementation2Interface();

        [Header("SingleForceExpandImplementation")]
        [SelectImplementation(typeof(IInteraface), displayLabel: true, forceExpanded: true)]
        [SerializeField, SerializeReference] private IInteraface singleForceExpandImplementation = new Implementation2Interface();

        [Header("SingleForceExpandNoLabelImplementation")]
        [SelectImplementation(typeof(IInteraface), displayLabel: false, forceExpanded: true)]
        [SerializeField, SerializeReference]
        private IInteraface singleForceExpandNoLabelImplementation = new Implementation2Interface();
    }
}
