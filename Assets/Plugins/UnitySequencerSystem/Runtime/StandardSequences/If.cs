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
    [AddTypeMenu("Standard/If")]
#endif
    [Serializable]
    public sealed class If : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private BoolResolver conditionResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private SequencesResolver trueSequencesResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private SequencesResolver falseSequencesResolver;

        public If()
        {
        }

        public If(BoolResolver conditionResolver, SequencesResolver trueSequencesResolver, SequencesResolver falseSequencesResolver)
        {
            this.conditionResolver = conditionResolver;
            this.trueSequencesResolver = trueSequencesResolver;
            this.falseSequencesResolver = falseSequencesResolver;
        }

#if USS_SUPPORT_UNITASK
        public override async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var sequences = conditionResolver.Resolve(container) ? trueSequencesResolver.Resolve(container) : falseSequencesResolver.Resolve(container);
            var sequencer = new Sequencer(container, sequences);
            await sequencer.PlayAsync(cancellationToken);
        }
    }
}
