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
    public sealed class GameObjectSetPosition : ISequence
    {
        [SerializeField]
        private string targetName;

        [SerializeField]
        private Vector3 position;

        public GameObjectSetPosition()
        {
        }

        public GameObjectSetPosition(string targetName)
        {
            this.targetName = targetName;
        }

        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
        {
            var target = container.Resolve<GameObject>(this.targetName);
            target.transform.position = this.position;
            return UniTask.CompletedTask;
        }
    }
}
