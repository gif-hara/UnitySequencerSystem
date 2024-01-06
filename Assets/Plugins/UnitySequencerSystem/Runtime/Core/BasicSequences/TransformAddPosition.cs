using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using HK.UnitySequencerSystem.Resolvers;
using UnityEngine;

namespace HK.UnitySequencerSystem
{
    /// <summary>
    /// <see cref="Transform"/>の座標を加算するシーケンス
    /// </summary>
    [AddTypeMenu("Transform/AddPosition")]
    [Serializable]
    public sealed class TransformAddPosition : ISequence
    {
        [SerializeReference, SubclassSelector]
        private TransformResolver targetResolver;

        [SerializeReference, SubclassSelector]
        private Vector3Resolver positionResolver;

        [SerializeReference, SubclassSelector]
        private DeltaTimeResolver deltaTimeResolver;

        [SerializeField]
        private CoordinateType coordinateType;

        public enum CoordinateType
        {
            World,
            Local,
        }

        public TransformAddPosition()
        {
        }

        public TransformAddPosition(
            TransformResolver targetResolver,
            Vector3Resolver positionResolver,
            DeltaTimeResolver deltaTimeResolver,
            CoordinateType coordinateType
            )
        {
            this.targetResolver = targetResolver;
            this.positionResolver = positionResolver;
            this.deltaTimeResolver = deltaTimeResolver;
            this.coordinateType = coordinateType;
        }

        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
        {
            var target = this.targetResolver.Resolve(container);
            var position = this.positionResolver.Resolve(container);
            var deltaTime = this.deltaTimeResolver.Resolve(container);
            switch (this.coordinateType)
            {
                case CoordinateType.World:
                    target.position += position * deltaTime;
                    break;
                case CoordinateType.Local:
                    target.localPosition += position * deltaTime;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return UniTask.CompletedTask;
        }
    }
}
