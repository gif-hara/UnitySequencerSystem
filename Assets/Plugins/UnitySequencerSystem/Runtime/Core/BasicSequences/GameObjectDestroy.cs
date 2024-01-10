using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace HK.UnitySequencerSystem
{
    /// <summary>
    /// <see cref="GameObject"/>を破棄するシーケンス
    /// </summary>
    [AddTypeMenu("Standard/GameObject Destroy")]
    [Serializable]
    public sealed class GameObjectDestroy : ISequence
    {
        [SerializeField]
        private string targetName;

        public GameObjectDestroy()
        {
        }

        public GameObjectDestroy(string targetName)
        {
            this.targetName = targetName;
        }

        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
        {
            var target = container.Resolve<GameObject>(this.targetName);
            UnityEngine.Object.Destroy(target);
            return UniTask.CompletedTask;
        }
    }
}
