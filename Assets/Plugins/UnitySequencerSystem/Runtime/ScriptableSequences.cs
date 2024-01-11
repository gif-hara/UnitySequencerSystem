using System.Collections.Generic;
using UnityEngine;

namespace UnitySequencerSystem
{
    /// <summary>
    /// Represents a collection of scriptable sequences in the Unity Sequencer System.
    /// </summary>
    [CreateAssetMenu(fileName = "ScriptableSequences", menuName = "UnitySequencerSystem/ScriptableSequences")]
    public class ScriptableSequences : ScriptableObject
    {
        [SerializeField]
        private List<ISequence> sequences = new();

        /// <summary>
        /// Gets the list of sequences in the scriptable object.
        /// </summary>
        public List<ISequence> Sequences => sequences;
    }
}
