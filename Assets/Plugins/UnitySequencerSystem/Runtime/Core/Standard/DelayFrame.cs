#if USS_UNI_TASK_SUPPORT
using System;
using System.Threading;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace HK.UnitySequencerSystem.Standard
{
    /// <summary>
    /// 指定したフレーム待機するシーケンス
    /// </summary>
    [AddTypeMenu("Standard/Delay Frame")]
    [Serializable]
    public sealed class DelayFrame : ISequence
    {
        [SerializeField]
        private int frames;

        public DelayFrame()
        {
        }

        public DelayFrame(int frames)
        {
            this.frames = frames;
        }

        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
        {
            return UniTask.DelayFrame(this.frames, cancellationToken: cancellationToken);
        }
    }
}
#endif
