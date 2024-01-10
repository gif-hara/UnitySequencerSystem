using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace HK.UnitySequencerSystem.Standard
{
    /// <summary>
    /// シーケンスを実行し、どれかが完了したら終了するシーケンス
    /// </summary>
    [AddTypeMenu("Standard/When Any")]
    [Serializable]
    public sealed class WhenAny : ISequence
    {
#if USS_SUB_CLASS_SELECTOR_SUPPORT
        [SubclassSelector]
#endif
        [SerializeReference]
        private List<ISequence> sequences;

        public WhenAny()
        {
        }

        public WhenAny(List<ISequence> sequences)
        {
            this.sequences = sequences;
        }

        public async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
        {
            await UniTask.WhenAny(sequences.Select(s => s.PlayAsync(container, cancellationToken)));
        }
    }
}
