using System;
using System.Threading;
using HK.UnitySequencerSystem.Resolvers;
using UnityEngine;
#if USS_UNI_TASK_SUPPORT
using Cysharp.Threading.Tasks;
#else
using System.Threading.Tasks;
#endif

namespace HK.UnitySequencerSystem.Standard
{
    /// <summary>
    /// <see cref="ParticleSystem"/>を停止するシーケンス
    /// </summary>
    [AddTypeMenu("Standard/Particle Stop")]
    [Serializable]
    public sealed class ParticleStop : ISequence
    {
#if USS_SUB_CLASS_SELECTOR_SUPPORT
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

        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
        {
            var target = this.targetResolver.Resolve(container);
            target.Stop(withChildren, stopBehavior);
            return UniTask.CompletedTask;
        }
    }
}
