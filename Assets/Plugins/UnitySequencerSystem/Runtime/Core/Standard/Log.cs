using System;
using System.Threading;
using UnityEngine;
#if USS_UNI_TASK_SUPPORT
using Cysharp.Threading.Tasks;
#else
using System.Threading.Tasks;
#endif

namespace HK.UnitySequencerSystem.Standard
{
    /// <summary>
    /// ログを出力するシーケンス
    /// </summary>
    [AddTypeMenu("Standard/Log")]
    [Serializable]
    public sealed class Log : ISequence
    {
        [SerializeField]
        private string message;

        public Log()
        {
        }

        public Log(string message)
        {
            this.message = message;
        }

#if USS_UNI_TASK_SUPPORT
        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            Debug.Log(this.message);
#if USS_UNI_TASK_SUPPORT
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }
}
