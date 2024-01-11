using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
#if USS_SUPPORT_UNITASK
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
#if USS_SUPPORT_SUB_CLASS_SELECTOR
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

#if USS_SUPPORT_UNITASK
                public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
                {
#if USS_SUPPORT_UNITASK
                        foreach (var sequence in sequences)
                        {
                                sequence.PlayAsync(container, cancellationToken).Forget();
                        }

                        return UniTask.CompletedTask;
#else
            foreach (var sequence in sequences)
            {
                sequence.PlayAsync(container, cancellationToken);
            }

            return Task.CompletedTask;
#endif
                }
        }
}
