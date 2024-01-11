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
    [AddTypeMenu("Standard/Transform Add Rotation")]
    [Serializable]
    public sealed class TransformAddRotation : ISequence
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
        private Vector3Resolver rotationResolver;

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

        public TransformAddRotation()
        {
        }

        public TransformAddRotation(
            TransformResolver targetResolver,
            Vector3Resolver rotationResolver,
            DeltaTimeResolver deltaTimeResolver,
            CoordinateType coordinateType
        )
        {
            this.targetResolver = targetResolver;
            this.rotationResolver = rotationResolver;
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
            var rotation = this.rotationResolver.Resolve(container);
            var deltaTime = this.deltaTimeResolver.Resolve(container);
            switch (this.coordinateType)
            {
            case CoordinateType.World:
                target.rotation *= Quaternion.Euler(rotation * deltaTime);
                break;
            case CoordinateType.Local:
                target.localRotation *= Quaternion.Euler(rotation * deltaTime);
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
