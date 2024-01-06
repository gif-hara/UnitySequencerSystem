using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using HK.UnitySequencerSystem.Resolvers;
using UnityEngine;

namespace HK.UnitySequencerSystem
{
    /// <summary>
    /// <see cref="Transform"/>の座標を設定するシーケンス
    /// </summary>
    [AddTypeMenu("Transform/SetPosition")]
    [Serializable]
    public sealed class TransformSetPosition : ISequence
    {
        [SerializeField]
        private string targetName;

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

        public TransformSetPosition(string targetName, Vector3Resolver positionResolver, CoordinateType coordinateType)
        {
            this.targetName = targetName;
            this.positionResolver = positionResolver;
            this.coordinateType = coordinateType;
        }

        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
        {
            var target = container.Resolve<Transform>(this.targetName);
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
