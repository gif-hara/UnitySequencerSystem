using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace HK.UnitySequencerSystem
{
    /// <summary>
    /// <see cref="Transform"/>の座標を設定するシーケンス
    /// </summary>
    [Serializable]
    public sealed class TransformSetPosition : ISequence
    {
        [SerializeField]
        private string targetName;

        [SerializeField]
        private Vector3 position;

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

        public TransformSetPosition(string targetName, Vector3 position, CoordinateType coordinateType)
        {
            this.targetName = targetName;
            this.position = position;
            this.coordinateType = coordinateType;
        }

        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
        {
            var target = container.Resolve<Transform>(this.targetName);
            switch (this.coordinateType)
            {
                case CoordinateType.World:
                    target.position = this.position;
                    break;
                case CoordinateType.Local:
                    target.localPosition = this.position;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return UniTask.CompletedTask;
        }
    }
}
