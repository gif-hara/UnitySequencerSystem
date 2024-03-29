using System;
using System.Threading;
using UnityEngine;
using UnitySequencerSystem.Resolvers;

#if USS_SUPPORT_UNITASK
using Cysharp.Threading.Tasks;
#else
using System.Threading.Tasks;
using System.Collections;
#endif

namespace UnitySequencerSystem.StandardSequences
{
#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Update")]
#endif
    [Serializable]
    public sealed class Update : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private SequencesResolver sequencesResolver;

#if USS_SUPPORT_UNITASK
        [SerializeField]
        private PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.Update;
#endif

        public Update()
        {
        }

        public Update(SequencesResolver sequencesResolver)
        {
            this.sequencesResolver = sequencesResolver;
        }

#if USS_SUPPORT_UNITASK
        public override async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var sequences = sequencesResolver.Resolve(container);
#if USS_SUPPORT_UNITASK
            while (!cancellationToken.IsCancellationRequested)
            {
                foreach (var sequence in sequences)
                {
                    await sequence.PlayAsync(container, cancellationToken);
                }

                await UniTask.Yield(playerLoopTiming, cancellationToken: cancellationToken);
            }
#else
            IEnumerator WaitNextFrame()
            {
                yield return null;
            }
            while (!cancellationToken.IsCancellationRequested)
            {
                foreach (var sequence in sequences)
                {
                    await sequence.PlayAsync(container, cancellationToken);
                }

                await MainThreadDispatcher.Instance.RunCoroutineAsTask(WaitNextFrame());
            }
#endif
        }
    }
}
