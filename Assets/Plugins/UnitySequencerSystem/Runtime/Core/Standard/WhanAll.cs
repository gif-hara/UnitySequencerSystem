using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace HK.UnitySequencerSystem.Standard
{
    /// <summary>
    /// シーケンスを実行し、全てのシーケンスが完了したら完了するシーケンス
    /// </summary>
    [AddTypeMenu("Standard/When All")]
    [Serializable]
    public sealed class WhenAll : ISequence
    {
#if USS_SUB_CLASS_SELECTOR_SUPPORT
        [SubclassSelector]
#endif
        [SerializeReference]
        private List<ISequence> sequences;

        public WhenAll()
        {
        }

        public WhenAll(List<ISequence> sequences)
        {
            this.sequences = sequences;
        }

        public async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
        {
            await UniTask.WhenAll(sequences.Select(s => s.PlayAsync(container, cancellationToken)));
        }
    }
}
