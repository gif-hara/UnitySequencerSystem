using System;
using System.Threading;
using HK.UnitySequencerSystem.Resolvers;
using UnityEngine;
#if USS_SUPPORT_UNITASK
using Cysharp.Threading.Tasks;
#else
using System.Threading.Tasks;
#endif

namespace HK.UnitySequencerSystem.Standard
{
    /// <summary>
    /// <see cref="Transform"/>の大きさを加算するシーケンス
    /// </summary>
    [AddTypeMenu("Standard/Transform Add Scale")]
    [Serializable]
    public sealed class TransformAddScale : ISequence
    {
        #if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
        #endif
        [SerializeReference]
        private TransformResolver targetResolver;

        #if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
        #endif
        [SerializeReference]
        private Vector3Resolver scaleResolver;

        #if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
        #endif
        [SerializeReference]
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

        #if USS_SUPPORT_UNITASK
        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
        #else
        public Task PlayAsync(Container container, CancellationToken cancellationToken)
        #endif
        {
            var target = this.targetResolver.Resolve(container);
            var scale = this.scaleResolver.Resolve(container);
            var deltaTime = this.deltaTimeResolver.Resolve(container);
            target.localScale += scale * deltaTime;
            #if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
            #else
            return Task.CompletedTask;
            #endif
        }
    }
}
