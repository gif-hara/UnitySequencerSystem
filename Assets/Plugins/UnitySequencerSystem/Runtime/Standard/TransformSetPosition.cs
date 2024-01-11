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
    /// <see cref="Transform"/>の座標を設定するシーケンス
    /// </summary>
    [AddTypeMenu("Standard/Transform Set Position")]
    [Serializable]
    public sealed class TransformSetPosition : ISequence
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
        private Vector3Resolver positionResolver;

        [SerializeField]
        private CoordinateType coordinateType;

        public enum CoordinateType
        {
            World,
            Local,
        }

        public TransformSetPosition()
        {
        }

        public TransformSetPosition(TransformResolver targetResolver, Vector3Resolver positionResolver, CoordinateType coordinateType)
        {
            this.targetResolver = targetResolver;
            this.positionResolver = positionResolver;
            this.coordinateType = coordinateType;
        }

#if USS_SUPPORT_UNITASK
        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var position = this.positionResolver.Resolve(container);
            switch (this.coordinateType)
            {
                case CoordinateType.World:
                    target.position = position;
                    break;
                case CoordinateType.Local:
                    target.localPosition = position;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }
}
