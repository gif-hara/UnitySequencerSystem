using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace HK.UnitySequencerSystem
{
    /// <summary>
    /// <see cref="Transform"/>の大きさを加算するシーケンス
    /// </summary>
    [Serializable]
    public sealed class TransformAddScale : ISequence
    {
        [SerializeField]
        private string targetName;

        [SerializeField]
        private Vector3 scale;

        [SerializeField]
        private TimeType timeType;

        [SerializeField]
        private string manualDeltaTimeName;

        public enum TimeType
        {
            DeltaTime,
            UnscaledDeltaTime,
            Manual,
        }

        public TransformAddScale()
        {
        }

        public TransformAddScale(
            string targetName,
            Vector3 scale,
            TimeType timeType,
            string manualDeltaTimeName
            )
        {
            this.targetName = targetName;
            this.scale = scale;
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
            target.localScale += this.scale * deltaTime;
            return UniTask.CompletedTask;
        }
    }
}
