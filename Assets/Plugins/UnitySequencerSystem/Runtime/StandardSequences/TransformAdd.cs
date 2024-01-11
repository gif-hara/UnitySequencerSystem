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
    /// <summary>
    /// <see cref="Transform"/>の座標を加算するシーケンス
    /// </summary>
    [AddTypeMenu("Standard/Transform Add Position")]
    [Serializable]
    public sealed class TransformAddPosition : ISequence
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
        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public Task PlayAsync(Container container, CancellationToken cancellationToken)
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
    [AddTypeMenu("Standard/Transform Add Local Position")]
    [Serializable]
    public sealed class TransformAddLocalPosition : ISequence
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
        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public Task PlayAsync(Container container, CancellationToken cancellationToken)
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
    [AddTypeMenu("Standard/Transform Add Euler Angles")]
    [Serializable]
    public sealed class TransformAddEulerAngles : ISequence
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
        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public Task PlayAsync(Container container, CancellationToken cancellationToken)
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
    [AddTypeMenu("Standard/Transform Add Local Euler Angles")]
    [Serializable]
    public sealed class TransformAddLocalEulerAngles : ISequence
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
        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
        #else
        public Task PlayAsync(Container container, CancellationToken cancellationToken)
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
    [AddTypeMenu("Standard/Transform Add Local Scale")]
    [Serializable]
    public sealed class TransformAddLocalScale : ISequence
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
        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
        #else
        public Task PlayAsync(Container container, CancellationToken cancellationToken)
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
}
