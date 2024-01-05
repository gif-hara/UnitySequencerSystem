using System.Collections.Generic;
using UnityEngine;

namespace HK.UnitySequencerSystem
{
    /// <summary>
    /// 
    /// </summary>
    public class Test : MonoBehaviour
    {
        [SerializeReference, SubclassSelector(typeof(ISequence))]
        private List<ISequence> sequences = default;

        async void Start()
        {
            var container = new Container();
            var sequencer = new Sequencer(container, this.sequences);
            await sequencer.PlayAsync(this.destroyCancellationToken);
            Debug.Log("end");
        }
    }
}
