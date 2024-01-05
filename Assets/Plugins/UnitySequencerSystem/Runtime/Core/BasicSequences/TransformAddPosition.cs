using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace HK.UnitySequencerSystem
{
    /// <summary>
    /// <see cref="Transform"/>の座標を加算するシーケンス
    /// </summary>
    [Serializable]
    public sealed class TransformAddPosition : ISequence
    {
        [SerializeField]
        private string targetName;

        [SerializeField]
        private Vector3 position;

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

        public TransformAddPosition()
        {
        }

        public TransformAddPosition(
            string targetName,
            Vector3 position,
            CoordinateType coordinateType,
            TimeType timeType,
            string manualDeltaTimeName
            )
        {
            this.targetName = targetName;
            this.position = position;
            this.coordinateType = coordinateType;
            this.timeType = timeType;
            this.manualDeltaTimeName = manualDeltaTimeName;
        }

        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
        {
            var target = container.Resolve<GameObject>(this.targetName);
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
                    target.transform.position += this.position * deltaTime;
                    break;
                case CoordinateType.Local:
                    target.transform.localPosition += this.position * deltaTime;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            return UniTask.CompletedTask;
        }
    }
}
