using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using System.Linq;

#if USS_SUPPORT_UNITASK
using Cysharp.Threading.Tasks;
#else
using System.Threading.Tasks;
#endif

namespace UnitySequencerSystem.StandardSequences
{
    /// <summary>
    /// シーケンスを実行し、全てのシーケンスが完了したら完了するシーケンス
    /// </summary>
#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/When All")]
#endif
    [Serializable]
    public sealed class WhenAll : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private List<Sequence> sequences;

        public WhenAll()
        {
        }

        public WhenAll(List<Sequence> sequences)
        {
            this.sequences = sequences;
        }

#if USS_SUPPORT_UNITASK
        public override async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
#if USS_SUPPORT_UNITASK
            await UniTask.WhenAll(sequences.Select(s => s.PlayAsync(container, cancellationToken)));
#else
            await Task.WhenAll(sequences.Select(s => s.PlayAsync(container, cancellationToken)));
#endif
        }
    }
}
