using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace HK.UnitySequencerSystem
{
    /// <summary>
    /// <see cref="Transform"/>の大きさを設定するシーケンス
    /// </summary>
    [Serializable]
    public sealed class TransformSetScale : ISequence
    {
        [SerializeField]
        private string targetName;

        [SerializeField]
        private Vector3 scale;

        public TransformSetScale()
        {
        }

        public TransformSetScale(string targetName, Vector3 scale)
        {
            this.targetName = targetName;
            this.scale = scale;
        }

        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
        {
            var target = container.Resolve<Transform>(this.targetName);
            target.localScale = this.scale;
            return UniTask.CompletedTask;
        }
    }
}
