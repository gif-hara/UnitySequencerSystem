using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace HK.UnitySequencerSystem
{
    /// <summary>
    /// <see cref="Transform"/>の回転を設定するシーケンス
    /// </summary>
    [Serializable]
    public sealed class TransformSetRotation : ISequence
    {
        [SerializeField]
        private string targetName;

        [SerializeField]
        private Vector3 rotation;

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

        public TransformSetRotation(string targetName, Vector3 rotation, CoordinateType coordinateType)
        {
            this.targetName = targetName;
            this.rotation = rotation;
            this.coordinateType = coordinateType;
        }

        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
        {
            var target = container.Resolve<GameObject>(this.targetName);
            switch (this.coordinateType)
            {
                case CoordinateType.World:
                    target.transform.rotation = Quaternion.Euler(this.rotation);
                    break;
                case CoordinateType.Local:
                    target.transform.localRotation = Quaternion.Euler(this.rotation);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return UniTask.CompletedTask;
        }
    }
}
