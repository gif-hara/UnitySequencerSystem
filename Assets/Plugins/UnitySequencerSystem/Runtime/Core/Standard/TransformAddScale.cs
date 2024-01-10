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
    /// <see cref="Transform"/>の大きさを加算するシーケンス
    /// </summary>
    [AddTypeMenu("Standard/Transform Add Scale")]
    [Serializable]
    public sealed class TransformAddScale : ISequence
    {
#if USS_SUB_CLASS_SELECTOR_SUPPORT
        [SubclassSelector]
#endif
        [SerializeReference]
        private TransformResolver targetResolver;

#if USS_SUB_CLASS_SELECTOR_SUPPORT
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver scaleResolver;

#if USS_SUB_CLASS_SELECTOR_SUPPORT
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
