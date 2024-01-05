using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace HK.UnitySequencerSystem
{
    /// <summary>
    /// <see cref="Transform"/>の回転を設定するシーケンス
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

        public TransformSetScale(string targetName, Vector3 scal)
        {
            this.targetName = targetName;
            this.scale = scal;
        }

        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
        {
            var target = container.Resolve<GameObject>(this.targetName);
            target.transform.localScale = this.scale;
            return UniTask.CompletedTask;
        }
    }
}
