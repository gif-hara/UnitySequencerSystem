using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace HK.UnitySequencerSystem
{
    /// <summary>
    /// 
    /// </summary>
    public class Test : MonoBehaviour
    {
        [SerializeReference, SubclassSelector(typeof(ISequence))]
        private List<ISequence> runOnceSequences = default;

        [SerializeReference, SubclassSelector(typeof(ISequence))]
        private List<ISequence> runLoopSequences = default;

        [SerializeField]
        private GameObject target = default;

        [SerializeField]
        private List<TMP_Text> texts = default;

        private CancellationTokenSource scope = new();

        void Start()
        {
            var container = new Container();
            container.Register(target.name, target.transform);
            foreach (var t in this.texts)
            {
                container.Register(t.name, t);
            }
            container.Register("MyDeltaTime", new Func<float>(() => 0.01f));
            var runOnceSequencer = new Sequencer(container, this.runOnceSequences);
            var runLoopSequencer = new Sequencer(container, this.runLoopSequences);
            runOnceSequencer.PlayAsync(scope.Token).Forget();
            runLoopSequencer.PlayLoopAsync(PlayerLoopTiming.Update, scope.Token).Forget();
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
