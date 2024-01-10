using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using HK.UnitySequencerSystem.Resolvers;
using UnityEngine;

namespace HK.UnitySequencerSystem.Standard
{
    /// <summary>
    /// <see cref="Transform"/>の座標を設定するシーケンス
    /// </summary>
    [AddTypeMenu("Standard/Transform Set Position")]
    [Serializable]
    public sealed class TransformSetPosition : ISequence
    {
        [SerializeReference, SubclassSelector]
        private TransformResolver targetResolver;

        [SerializeReference, SubclassSelector]
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

        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
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
            return UniTask.CompletedTask;
        }
    }
}
