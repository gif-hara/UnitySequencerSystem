using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace HK.UnitySequencerSystem
{
    /// <summary>
    /// 指定したフレーム待機するシーケンス
    /// </summary>
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