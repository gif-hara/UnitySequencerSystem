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
    /// <see cref="Transform"/>の座標を加算するシーケンス
    /// </summary>
    [AddTypeMenu("Standard/Transform Add Position")]
    [Serializable]
    public sealed class TransformAddPosition : ISequence
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

        #if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
        #endif
        [SerializeReference]
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

#if USS_SUPPORT_UNITASK
        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
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
            #if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
            #else
            return Task.CompletedTask;
            #endif
        }
    }
}