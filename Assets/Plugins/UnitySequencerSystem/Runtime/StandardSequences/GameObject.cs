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
#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/GameObject Instantiate")]
#endif
    [Serializable]
    public sealed class GameObjectInstantiate : Sequence
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
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
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
#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/GameObject Destroy")]
#endif
    [Serializable]
    public sealed class GameObjectDestroy : Sequence
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
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
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
