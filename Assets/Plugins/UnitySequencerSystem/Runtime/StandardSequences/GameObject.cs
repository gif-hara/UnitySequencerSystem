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
        private StringResolver gameObjectNameResolver;

        public GameObjectInstantiate()
        {
        }

        public GameObjectInstantiate(GameObjectResolver prefabResolver, StringResolver gameObjectNameResolver)
        {
            this.prefabResolver = prefabResolver;
            this.gameObjectNameResolver = gameObjectNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var prefab = this.prefabResolver.Resolve(container);
            var instance = UnityEngine.Object.Instantiate(prefab);
            if (gameObjectNameResolver != null)
            {
                var name = gameObjectNameResolver.Resolve(container);
                container.RegisterOrReplace(name, instance);
            }
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/GameObject Destroy")]
#endif
    [Serializable]
    public sealed class GameObjectDestroy : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private GameObjectResolver targetResolver;

        public GameObjectDestroy()
        {
        }

        public GameObjectDestroy(GameObjectResolver targetResolver)
        {
            this.targetResolver = targetResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            UnityEngine.Object.Destroy(target);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/GameObject To Transform")]
#endif
    [Serializable]
    public sealed class GameObjectToTransform : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private GameObjectResolver targetResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver transformNameResolver;

        public GameObjectToTransform()
        {
        }

        public GameObjectToTransform(GameObjectResolver targetResolver, StringResolver transformNameResolver)
        {
            this.targetResolver = targetResolver;
            this.transformNameResolver = transformNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var transformName = this.transformNameResolver.Resolve(container);
            container.RegisterOrReplace(transformName, target.transform);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }
}
