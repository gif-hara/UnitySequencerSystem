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
    [AddTypeMenu("Standard/Transform Set Position")]
    [Serializable]
    public sealed class TransformSetPosition : ISequence
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
        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public Task PlayAsync(Container container, CancellationToken cancellationToken)
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

    [AddTypeMenu("Standard/Transform Set Local Position")]
    [Serializable]
    public sealed class TransformSetLocalPosition : ISequence
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
        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public Task PlayAsync(Container container, CancellationToken cancellationToken)
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

    [AddTypeMenu("Standard/Transform Set Euler Angles")]
    [Serializable]
    public sealed class TransformSetEulerAngles : ISequence
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
        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public Task PlayAsync(Container container, CancellationToken cancellationToken)
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

    [AddTypeMenu("Standard/Transform Set Local Euler Angles")]
    [Serializable]
    public sealed class TransformSetLocalEulerAngles : ISequence
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
        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public Task PlayAsync(Container container, CancellationToken cancellationToken)
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

    [AddTypeMenu("Standard/Transform Set Local Scale")]
    [Serializable]
    public sealed class TransformSetLocalScale : ISequence
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
        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public Task PlayAsync(Container container, CancellationToken cancellationToken)
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
}
