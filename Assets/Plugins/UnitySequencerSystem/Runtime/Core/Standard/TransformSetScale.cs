using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using HK.UnitySequencerSystem.Resolvers;
using UnityEngine;

namespace HK.UnitySequencerSystem.Standard
{
    /// <summary>
    /// <see cref="Transform"/>の大きさを設定するシーケンス
    /// </summary>
    [AddTypeMenu("Standard/Transform Set Scale")]
    [Serializable]
    public sealed class TransformSetScale : ISequence
    {
        [SerializeReference, SubclassSelector]
        private TransformResolver targetResolver;

        [SerializeReference, SubclassSelector]
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
