using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using HK.UnitySequencerSystem.Resolvers;
using UnityEngine;

namespace HK.UnitySequencerSystem.Standard
{
    /// <summary>
    /// <see cref="Transform"/>の回転を加算するシーケンス
    /// </summary>
    [AddTypeMenu("Standard/Transform Add Rotation")]
    [Serializable]
    public sealed class TransformAddRotation : ISequence
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
        private Vector3Resolver rotationResolver;

#if USS_SUB_CLASS_SELECTOR_SUPPORT
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

        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
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
            return UniTask.CompletedTask;
        }
    }
}
