using System;
using System.Threading;
using UnityEngine;
#if USS_SUPPORT_UNITASK
using Cysharp.Threading.Tasks;
#else
using System.Threading.Tasks;
#endif

namespace UnitySequencerSystem.StandardSequences
{
    /// <summary>
    /// 指定した秒数待機するシーケンス
    /// </summary>
    [AddTypeMenu("Standard/Delay")]
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

#if USS_SUPPORT_UNITASK
        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
        {
            return UniTask.Delay(TimeSpan.FromSeconds(this.seconds), cancellationToken: cancellationToken);
        }
#else
        public Task PlayAsync(Container container, CancellationToken cancellationToken)
        {
            return Task.Delay(TimeSpan.FromSeconds(this.seconds), cancellationToken: cancellationToken);
        }
#endif
    }
}
