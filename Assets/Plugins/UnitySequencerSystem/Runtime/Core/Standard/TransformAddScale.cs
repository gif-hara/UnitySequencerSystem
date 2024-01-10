using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using HK.UnitySequencerSystem.Resolvers;
using UnityEngine;

namespace HK.UnitySequencerSystem.Standard
{
    /// <summary>
    /// <see cref="Transform"/>の大きさを加算するシーケンス
    /// </summary>
    [AddTypeMenu("Standard/Transform Add Scale")]
    [Serializable]
    public sealed class TransformAddScale : ISequence
    {
        [SerializeReference, SubclassSelector]
        private TransformResolver targetResolver;

        [SerializeReference, SubclassSelector]
        private Vector3Resolver scaleResolver;

        [SerializeReference, SubclassSelector]
        private DeltaTimeResolver deltaTimeResolver;

        public TransformAddScale()
        {
        }

        public TransformAddScale(
            TransformResolver targetResolver,
            Vector3Resolver scaleResolver,
            DeltaTimeResolver deltaTimeResolver
            )
        {
            this.targetResolver = targetResolver;
            this.scaleResolver = scaleResolver;
            this.deltaTimeResolver = deltaTimeResolver;
        }

        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
        {
            var target = this.targetResolver.Resolve(container);
            var scale = this.scaleResolver.Resolve(container);
            var deltaTime = this.deltaTimeResolver.Resolve(container);
            target.localScale += scale * deltaTime;
            return UniTask.CompletedTask;
        }
    }
}
