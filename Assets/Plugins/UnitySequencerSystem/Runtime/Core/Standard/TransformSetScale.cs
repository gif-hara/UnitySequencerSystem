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
    /// <see cref="Transform"/>の大きさを設定するシーケンス
    /// </summary>
    [AddTypeMenu("Standard/Transform Set Scale")]
    [Serializable]
    public sealed class TransformSetScale : ISequence
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

        public TransformSetScale()
        {
        }

        public TransformSetScale(TransformResolver targetResolver, Vector3Resolver scaleResolver)
        {
            this.targetResolver = targetResolver;
            this.scaleResolver = scaleResolver;
        }

        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
        {
            var target = this.targetResolver.Resolve(container);
            var scale = this.scaleResolver.Resolve(container);
            target.localScale = scale;
            return UniTask.CompletedTask;
        }
    }
}
