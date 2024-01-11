using System;
using System.Collections.Generic;
using System.Threading;
#if USS_SUPPORT_UNITASK
using Cysharp.Threading.Tasks;
#endif
using TMPro;
using UnityEngine;

namespace UnitySequencerSystem
{
    /// <summary>
    /// 
    /// </summary>
    public class Test : MonoBehaviour
    {
        [SubclassSelector]
        [SerializeReference]
        private List<ISequence> runOnceSequences = default;

        [SerializeField]
        private GameObject target = default;

        [SerializeField]
        private List<TMP_Text> texts = default;

        private CancellationTokenSource scope;

        async void Start()
        {
            this.scope = CancellationTokenSource.CreateLinkedTokenSource(this.destroyCancellationToken);
            var container = new Container();
            container.Register(target.name, target.transform);
            foreach (var t in this.texts)
            {
                container.Register(t.name, t);
            }
            container.Register("MyDeltaTime", new Func<float>(() => 0.01f));
            var runOnceSequencer = new Sequencer(container, this.runOnceSequences);
            await runOnceSequencer.PlayAsync(scope.Token);
        }
    }
}
