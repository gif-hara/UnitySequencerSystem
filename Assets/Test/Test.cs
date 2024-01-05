using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
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

        [SerializeField]
        private GameObject target = default;

        private CancellationTokenSource scope = new();

        async void Start()
        {
            var container = new Container();
            container.Register(target.name, target.transform);
            container.Register("MyDeltaTime", new Func<float>(() => 0.01f));
            var sequencer = new Sequencer(container, this.sequences);
            await sequencer.PlayLoopAsync(PlayerLoopTiming.Update, scope.Token);
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
