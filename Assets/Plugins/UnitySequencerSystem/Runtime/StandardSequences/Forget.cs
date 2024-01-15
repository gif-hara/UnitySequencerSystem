using System;
using System.Threading;
using UnityEngine;
using UnitySequencerSystem.Resolvers;

#if USS_SUPPORT_UNITASK
using Cysharp.Threading.Tasks;
#else
using System.Threading.Tasks;
#endif

namespace UnitySequencerSystem.StandardSequences
{
#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Forget")]
#endif
    [Serializable]
    public sealed class Forget : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private SequencesResolver sequencesResolver;

        public Forget()
        {
        }

        public Forget(SequencesResolver sequencesResolver)
        {
            this.sequencesResolver = sequencesResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var sequences = sequencesResolver.Resolve(container);
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
