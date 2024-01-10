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
    /// <see cref="ParticleSystem"/>を再生するシーケンス
    /// </summary>
    [AddTypeMenu("Standard/Particle Play")]
    [Serializable]
    public sealed class ParticlePlay : ISequence
    {
#if USS_SUB_CLASS_SELECTOR_SUPPORT
        [SubclassSelector]
#endif
        [SerializeReference]
        private ParticleSystemResolver targetResolver;

        [SerializeField]
        private bool withChildren = true;

        public ParticlePlay()
        {
        }

        public ParticlePlay(ParticleSystemResolver targetResolver, bool withChildren)
        {
            this.targetResolver = targetResolver;
            this.withChildren = withChildren;
        }

#if USS_UNI_TASK_SUPPORT
        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            target.Play(withChildren);
#if USS_UNI_TASK_SUPPORT
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }
}
