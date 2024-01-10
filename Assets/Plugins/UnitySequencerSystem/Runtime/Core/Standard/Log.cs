using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

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

        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
        {
            Debug.Log(this.message);
            return UniTask.CompletedTask;
        }
    }
}
