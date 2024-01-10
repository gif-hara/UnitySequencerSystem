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
    /// <see cref="Transform"/>の回転を設定するシーケンス
    /// </summary>
    [AddTypeMenu("Standard/Transform Set Rotation")]
    [Serializable]
    public sealed class TransformSetRotation : ISequence
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

        [SerializeField]
        private CoordinateType coordinateType;

        public enum CoordinateType
        {
            World,
            Local,
        }

        public TransformSetRotation()
        {
        }

        public TransformSetRotation(TransformResolver targetResolver, Vector3Resolver rotationResolver, CoordinateType coordinateType)
        {
            this.targetResolver = targetResolver;
            this.rotationResolver = rotationResolver;
            this.coordinateType = coordinateType;
        }

        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
        {
            var target = this.targetResolver.Resolve(container);
            var rotation = this.rotationResolver.Resolve(container);
            switch (this.coordinateType)
            {
                case CoordinateType.World:
                    target.rotation = Quaternion.Euler(rotation);
                    break;
                case CoordinateType.Local:
                    target.localRotation = Quaternion.Euler(rotation);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return UniTask.CompletedTask;
        }
    }
}
