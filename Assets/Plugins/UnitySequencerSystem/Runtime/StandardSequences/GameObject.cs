using System;
using System.Threading;
using UnityEngine;
using UnitySequencerSystem.Resolvers;
#if USS_SUPPORT_UNITASK
using Cysharp.Threading.Tasks;
#else
using System.Threading.Tasks;
#endif

namespace UnitySequencerSystem.StandardSequences
{
    [AddTypeMenu("Standard/GameObject Instantiate")]
    [Serializable]
    public sealed class GameObjectInstantiate : ISequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private GameObjectResolver prefabResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver containerNameResolver;

        public GameObjectInstantiate()
        {
        }
        
        public GameObjectInstantiate(GameObjectResolver prefabResolver, StringResolver containerNameResolver)
        {
            this.prefabResolver = prefabResolver;
            this.containerNameResolver = containerNameResolver;
        }
        
#if USS_SUPPORT_UNITASK
        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var prefab = this.prefabResolver.Resolve(container);
            var instance = UnityEngine.Object.Instantiate(prefab);
            if (containerNameResolver != null)
            {
                var containerName = containerNameResolver.Resolve(container);
                container.RegisterOrReplace(containerName, instance);
            }
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

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
