using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

#if USS_SUPPORT_UNITASK
using Cysharp.Threading.Tasks;
#else
using System.Linq;
using System.Threading.Tasks;
#endif


namespace UnitySequencerSystem.StandardSequences
{
    /// <summary>
    /// シーケンスを実行し、どれかが完了したら終了するシーケンス
    /// </summary>
#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/When Any")]
#endif
    [Serializable]
    public sealed class WhenAny : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private List<Sequence> sequences;

        public WhenAny()
        {
        }

        public WhenAny(List<Sequence> sequences)
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
            await UniTask.WhenAny(sequences.Select(s => s.PlayAsync(container, cancellationToken)));
#else
            await Task.WhenAny(sequences.Select(s => s.PlayAsync(container, cancellationToken)));
#endif

        }
    }
}
