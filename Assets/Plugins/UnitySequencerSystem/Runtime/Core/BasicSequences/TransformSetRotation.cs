using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using HK.UnitySequencerSystem.Resolvers;
using UnityEngine;

namespace HK.UnitySequencerSystem
{
    /// <summary>
    /// <see cref="Transform"/>の回転を設定するシーケンス
    /// </summary>
    [AddTypeMenu("Transform/SetRotation")]
    [Serializable]
    public sealed class TransformSetRotation : ISequence
    {
        [SerializeReference, SubclassSelector]
        private TransformResolver targetResolver;

        [SerializeReference, SubclassSelector]
        private Vector3Resolver rotationResolver;

        [SerializeReference, SubclassSelector]
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
