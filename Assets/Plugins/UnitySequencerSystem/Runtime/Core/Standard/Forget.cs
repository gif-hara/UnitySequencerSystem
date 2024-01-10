using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
#if USS_UNI_TASK_SUPPORT
using Cysharp.Threading.Tasks;
#else
using System.Threading.Tasks;
#endif

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

#if USS_UNI_TASK_SUPPORT
        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            foreach (var sequence in sequences)
            {
#if USS_UNI_TASK_SUPPORT
                sequence.PlayAsync(container, cancellationToken).Forget();
#else
                sequence.PlayAsync(container, cancellationToken);
#endif
            }
            return Task.CompletedTask;
        }
    }
}
