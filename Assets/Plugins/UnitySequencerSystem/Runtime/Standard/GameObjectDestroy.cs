using System;
using System.Threading;
using UnityEngine;
#if USS_SUPPORT_UNITASK
using Cysharp.Threading.Tasks;
#else
using System.Threading.Tasks;
#endif

namespace HK.UnitySequencerSystem.Standard
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

#if USS_SUPPORT_UNITASK
        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = container.Resolve<GameObject>(this.targetName);
            UnityEngine.Object.Destroy(target);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }
}
