using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace HK.UnitySequencerSystem
{
    /// <summary>
    /// <see cref="Transform"/>の回転を加算するシーケンス
    /// </summary>
    [Serializable]
    public sealed class TransformAddRotation : ISequence
    {
        [SerializeField]
        private string targetName;

        [SerializeField]
        private Vector3 rotation;

        [SerializeField]
        private CoordinateType coordinateType;

        [SerializeField]
        private TimeType timeType;

        [SerializeField]
        private string manualDeltaTimeName;

        public enum CoordinateType
        {
            World,
            Local,
        }

        public enum TimeType
        {
            DeltaTime,
            UnscaledDeltaTime,
            Manual,
        }

        public TransformAddRotation()
        {
        }

        public TransformAddRotation(
            string targetName,
            Vector3 rotation,
            CoordinateType coordinateType,
            TimeType timeType,
            string manualDeltaTimeName
            )
        {
            this.targetName = targetName;
            this.rotation = rotation;
            this.coordinateType = coordinateType;
            this.timeType = timeType;
            this.manualDeltaTimeName = manualDeltaTimeName;
        }

        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
        {
            var target = container.Resolve<Transform>(this.targetName);
            var deltaTime = this.timeType switch
            {
                TimeType.DeltaTime => Time.deltaTime,
                TimeType.UnscaledDeltaTime => Time.unscaledDeltaTime,
                TimeType.Manual => container.Resolve<Func<float>>(this.manualDeltaTimeName)(),
                _ => throw new ArgumentOutOfRangeException()
            };
            switch (this.coordinateType)
            {
                case CoordinateType.World:
                    target.rotation *= Quaternion.Euler(this.rotation * deltaTime);
                    break;
                case CoordinateType.Local:
                    target.localRotation *= Quaternion.Euler(this.rotation * deltaTime);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return UniTask.CompletedTask;
        }
    }
}
