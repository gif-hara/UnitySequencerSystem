using System.Collections.Generic;
using System.Threading;
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

        private CancellationTokenSource scope = new();

        async void Start()
        {
            var container = new Container();
            var sequencer = new Sequencer(container, this.sequences);
            await sequencer.PlayAsync(scope.Token);
            Debug.Log("end");
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.scope.Cancel();
                scope = new CancellationTokenSource();
            }
        }
    }
}
