using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace HK.UnitySequencerSystem
{
    /// <summary>
    /// 指定した秒数待機するシーケンス
    /// </summary>
    [Serializable]
    public sealed class Delay : ISequence
    {
        [SerializeField]
        private float seconds;

        public Delay()
        {
        }

        public Delay(float seconds)
        {
            this.seconds = seconds;
        }

        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
        {
            return UniTask.Delay(TimeSpan.FromSeconds(this.seconds), cancellationToken: cancellationToken);
        }
    }
}
