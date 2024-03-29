using System;
using System.Threading;
using UnitySequencerSystem.Resolvers;
using UnityEngine;
#if USS_SUPPORT_UNITASK
using Cysharp.Threading.Tasks;
#else
using System.Threading.Tasks;
#endif

namespace UnitySequencerSystem.StandardSequences
{
#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Transform Set Position")]
#endif
    [Serializable]
    public sealed class TransformSetPosition : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private TransformResolver targetResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver positionResolver;

        public TransformSetPosition()
        {
        }

        public TransformSetPosition(TransformResolver targetResolver, Vector3Resolver positionResolver)
        {
            this.targetResolver = targetResolver;
            this.positionResolver = positionResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var position = this.positionResolver.Resolve(container);
            target.position = position;
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Transform Set Local Position")]
#endif
    [Serializable]
    public sealed class TransformSetLocalPosition : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private TransformResolver targetResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver positionResolver;

        public TransformSetLocalPosition()
        {
        }

        public TransformSetLocalPosition(TransformResolver targetResolver, Vector3Resolver positionResolver)
        {
            this.targetResolver = targetResolver;
            this.positionResolver = positionResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var position = this.positionResolver.Resolve(container);
            target.localPosition = position;
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Transform Set Euler Angles")]
#endif
    [Serializable]
    public sealed class TransformSetEulerAngles : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private TransformResolver targetResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver eulerAnglesResolver;

        public TransformSetEulerAngles()
        {
        }

        public TransformSetEulerAngles(TransformResolver targetResolver, Vector3Resolver eulerAnglesResolver)
        {
            this.targetResolver = targetResolver;
            this.eulerAnglesResolver = eulerAnglesResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var eulerAngles = this.eulerAnglesResolver.Resolve(container);
            target.eulerAngles = eulerAngles;
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Transform Set Local Euler Angles")]
#endif
    [Serializable]
    public sealed class TransformSetLocalEulerAngles : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private TransformResolver targetResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver eulerAnglesResolver;

        public TransformSetLocalEulerAngles()
        {
        }

        public TransformSetLocalEulerAngles(TransformResolver targetResolver, Vector3Resolver eulerAnglesResolver)
        {
            this.targetResolver = targetResolver;
            this.eulerAnglesResolver = eulerAnglesResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var eulerAngles = this.eulerAnglesResolver.Resolve(container);
            target.localEulerAngles = eulerAngles;
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Transform Set Local Scale")]
#endif
    [Serializable]
    public sealed class TransformSetLocalScale : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private TransformResolver targetResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver localScaleResolver;

        public TransformSetLocalScale()
        {
        }

        public TransformSetLocalScale(TransformResolver targetResolver, Vector3Resolver localScaleResolver)
        {
            this.targetResolver = targetResolver;
            this.localScaleResolver = localScaleResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var localScale = this.localScaleResolver.Resolve(container);
            target.localScale = localScale;
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

    /// <summary>
    /// <see cref="Transform"/>の座標を加算するシーケンス
    /// </summary>
#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Transform Add Position")]
#endif
    [Serializable]
    public sealed class TransformAddPosition : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private TransformResolver targetResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver positionResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private DeltaTimeResolver deltaTimeResolver;

        public TransformAddPosition()
        {
        }

        public TransformAddPosition(
            TransformResolver targetResolver,
            Vector3Resolver positionResolver,
            DeltaTimeResolver deltaTimeResolver
        )
        {
            this.targetResolver = targetResolver;
            this.positionResolver = positionResolver;
            this.deltaTimeResolver = deltaTimeResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var position = this.positionResolver.Resolve(container);
            var deltaTime = this.deltaTimeResolver.Resolve(container);
            target.position += position * deltaTime;
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

    /// <summary>
    /// <see cref="Transform"/>の座標を加算するシーケンス
    /// </summary>
#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Transform Add Local Position")]
#endif
    [Serializable]
    public sealed class TransformAddLocalPosition : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private TransformResolver targetResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver positionResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private DeltaTimeResolver deltaTimeResolver;

        public TransformAddLocalPosition()
        {
        }

        public TransformAddLocalPosition(
            TransformResolver targetResolver,
            Vector3Resolver positionResolver,
            DeltaTimeResolver deltaTimeResolver
        )
        {
            this.targetResolver = targetResolver;
            this.positionResolver = positionResolver;
            this.deltaTimeResolver = deltaTimeResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var position = this.positionResolver.Resolve(container);
            var deltaTime = this.deltaTimeResolver.Resolve(container);
            target.localPosition += position * deltaTime;
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

    /// <summary>
    /// <see cref="Transform"/>の回転を加算するシーケンス
    /// </summary>
#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Transform Add Euler Angles")]
#endif
    [Serializable]
    public sealed class TransformAddEulerAngles : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private TransformResolver targetResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver eulerAnglesResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private DeltaTimeResolver deltaTimeResolver;

        public TransformAddEulerAngles()
        {
        }

        public TransformAddEulerAngles(
            TransformResolver targetResolver,
            Vector3Resolver eulerAnglesResolver,
            DeltaTimeResolver deltaTimeResolver
        )
        {
            this.targetResolver = targetResolver;
            this.eulerAnglesResolver = eulerAnglesResolver;
            this.deltaTimeResolver = deltaTimeResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var eulerAngles = this.eulerAnglesResolver.Resolve(container);
            var deltaTime = this.deltaTimeResolver.Resolve(container);
            target.eulerAngles += eulerAngles * deltaTime;
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

    /// <summary>
    /// <see cref="Transform"/>の回転を加算するシーケンス
    /// </summary>
#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Transform Add Local Euler Angles")]
#endif
    [Serializable]
    public sealed class TransformAddLocalEulerAngles : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private TransformResolver targetResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver eulerAnglesResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private DeltaTimeResolver deltaTimeResolver;

        public TransformAddLocalEulerAngles()
        {
        }

        public TransformAddLocalEulerAngles(
            TransformResolver targetResolver,
            Vector3Resolver eulerAnglesResolver,
            DeltaTimeResolver deltaTimeResolver
        )
        {
            this.targetResolver = targetResolver;
            this.eulerAnglesResolver = eulerAnglesResolver;
            this.deltaTimeResolver = deltaTimeResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var eulerAngles = this.eulerAnglesResolver.Resolve(container);
            var deltaTime = this.deltaTimeResolver.Resolve(container);
            target.localEulerAngles += eulerAngles * deltaTime;
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

    /// <summary>
    /// <see cref="Transform"/>のスケールを加算するシーケンス
    /// </summary>
#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Transform Add Local Scale")]
#endif
    [Serializable]
    public sealed class TransformAddLocalScale : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private TransformResolver targetResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver scaleResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private DeltaTimeResolver deltaTimeResolver;

        public TransformAddLocalScale()
        {
        }

        public TransformAddLocalScale(
            TransformResolver targetResolver,
            Vector3Resolver scaleResolver,
            DeltaTimeResolver deltaTimeResolver
        )
        {
            this.targetResolver = targetResolver;
            this.scaleResolver = scaleResolver;
            this.deltaTimeResolver = deltaTimeResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var scale = this.scaleResolver.Resolve(container);
            var deltaTime = this.deltaTimeResolver.Resolve(container);
            target.localScale += scale * deltaTime;
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Transform To GameObject")]
#endif
    [Serializable]
    public sealed class TransformToGameObject : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private TransformResolver transformResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver gameObjectNameResolver;

        public TransformToGameObject()
        {
        }

        public TransformToGameObject(TransformResolver transformResolver, StringResolver gameObjectNameResolver)
        {
            this.transformResolver = transformResolver;
            this.gameObjectNameResolver = gameObjectNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.transformResolver.Resolve(container);
            var gameObjectName = this.gameObjectNameResolver.Resolve(container);
            container.RegisterOrReplace(gameObjectName, target.gameObject);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }
}
