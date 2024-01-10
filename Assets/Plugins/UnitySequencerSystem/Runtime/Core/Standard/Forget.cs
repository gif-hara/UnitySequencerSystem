using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace HK.UnitySequencerSystem.Standard
{
    /// <summary>
    /// シーケンスを非同期で実行するシーケンス
    /// </summary>
    [AddTypeMenu("Standard/Forget")]
    [Serializable]
    public sealed class Forget : ISequence
    {
#if USS_SUB_CLASS_SELECTOR_SUPPORT
        [SubclassSelector]
#endif
        [SerializeReference]
        private List<ISequence> sequences;

        public Forget()
        {
        }

        public Forget(List<ISequence> sequences)
        {
            this.sequences = sequences;
        }

        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
        {
            foreach (var sequence in sequences)
            {
                sequence.PlayAsync(container, cancellationToken).Forget();
            }
            return UniTask.CompletedTask;
        }
    }
}
