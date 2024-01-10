using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using HK.UnitySequencerSystem.Resolvers;
using UnityEngine;

namespace HK.UnitySequencerSystem.Standard
{
    /// <summary>
    /// <see cref="ParticleSystem"/>を再生するシーケンス
    /// </summary>
    [AddTypeMenu("Standard/Particle Play")]
    [Serializable]
    public sealed class ParticlePlay : ISequence
    {
        [SerializeReference, SubclassSelector]
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

        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
        {
            var target = this.targetResolver.Resolve(container);
            target.Play(withChildren);
            return UniTask.CompletedTask;
        }
    }
}
