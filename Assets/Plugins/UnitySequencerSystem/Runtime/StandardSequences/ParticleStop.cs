using System;
using System.Threading;
using UnitySequencerSystem.Resolvers;
using UnityEngine;
#if USS_SUPPORT_UNITASK
using Cysharp.Threading.Tasks;
#else
using System.Threading.Tasks;
#endif

namespace UnitySequencerSystem.Standard
{
        /// <summary>
        /// <see cref="ParticleSystem"/>を停止するシーケンス
        /// </summary>
        [AddTypeMenu("Standard/Particle Stop")]
        [Serializable]
        public sealed class ParticleStop : ISequence
        {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
                [SerializeReference]
                private ParticleSystemResolver targetResolver;

                [SerializeField]
                private bool withChildren = true;

                [SerializeField]
                private ParticleSystemStopBehavior stopBehavior = ParticleSystemStopBehavior.StopEmitting;

                public ParticleStop()
                {
                }

                public ParticleStop(ParticleSystemResolver targetResolver, bool withChildren, ParticleSystemStopBehavior stopBehavior)
                {
                        this.targetResolver = targetResolver;
                        this.withChildren = withChildren;
                        this.stopBehavior = stopBehavior;
                }

#if USS_SUPPORT_UNITASK
                public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
                {
                        var target = this.targetResolver.Resolve(container);
                        target.Stop(withChildren, stopBehavior);
#if USS_SUPPORT_UNITASK
                        return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
                }
        }
}
