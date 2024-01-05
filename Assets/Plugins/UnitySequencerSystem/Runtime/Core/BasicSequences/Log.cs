using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace HK.UnitySequencerSystem
{
    /// <summary>
    /// ログを出力するシーケンス
    /// </summary>
    [Serializable]
    public sealed class Log : ISequence
    {
        [SerializeField]
        private string message;

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
