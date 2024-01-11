using System;
using System.Threading;
using UnityEngine;
using System.Collections;
using UnitySequencerSystem.Core;


#if USS_SUPPORT_UNITASK
using Cysharp.Threading.Tasks;
#else
using System.Threading.Tasks;
#endif

namespace UnitySequencerSystem.StandardSequences
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

#if USS_SUPPORT_UNITASK
        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
#if USS_SUPPORT_UNITASK
            return UniTask.DelayFrame(this.frames, cancellationToken: cancellationToken);
#else
            IEnumerator DelayFrame()
            {
                for (var i = 0; i < this.frames; i++)
                {
                    yield return null;
                }
            }
            return MainThreadDispatcher.Instance.RunCoroutineAsTask(DelayFrame());
#endif
        }
    }
}
