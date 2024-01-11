using System;
using System.Threading;
using UnitySequencerSystem.Resolvers;
using UnityEngine;
#if USS_SUPPORT_UNITASK
using Cysharp.Threading.Tasks;
#else
using System.Threading.Tasks;
#endif

namespace UnitySequencerSystem.StandardSequences
{
        /// <summary>
        /// <see cref="Transform"/>の大きさを設定するシーケンス
        /// </summary>
        [AddTypeMenu("Standard/Transform Set Scale")]
        [Serializable]
        public sealed class TransformSetScale : ISequence
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

                public TransformSetScale()
                {
                }

                public TransformSetScale(TransformResolver targetResolver, Vector3Resolver scaleResolver)
                {
                        this.targetResolver = targetResolver;
                        this.scaleResolver = scaleResolver;
                }

#if USS_SUPPORT_UNITASK
                public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
                {
                        var target = this.targetResolver.Resolve(container);
                        var scale = this.scaleResolver.Resolve(container);
                        target.localScale = scale;
#if USS_SUPPORT_UNITASK
                        return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
                }
        }
}
