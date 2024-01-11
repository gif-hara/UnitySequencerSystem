#if USS_SUPPORT_LIT_MOTION
using System;
using System.Threading;
using UnitySequencerSystem.Resolvers;
using UnitySequencerSystem.Resolvers.LitMotion;
using LitMotion;
using LitMotion.Extensions;
using UnityEngine;
using LitMotion.Adapters;


#if USS_SUPPORT_UNITASK
using Cysharp.Threading.Tasks;
#else
using System.Threading.Tasks;
#endif


namespace UnitySequencerSystem.LitMotion
{
    [Serializable]
    public abstract class Parameters<TValueResolver, TValue, TOptions, TAdapter>
        where TValueResolver : IResolver<TValue>
        where TValue : unmanaged
        where TOptions : unmanaged, IMotionOptions
        where TAdapter : unmanaged, IMotionAdapter<TValue, TOptions>
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        public TValueResolver fromResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        public TValueResolver toResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        public FloatResolver durationResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        public FloatResolver delayResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        public IntResolver loopCountResolver;

        [SerializeField]
        private LoopType loopType;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        public MotionSchedulerResolver motionSchedulerResolver;

        [SerializeField]
        public Ease ease;

        [SerializeField]
        private bool ignoreTimeScale = true;

        public MotionBuilder<TValue, TOptions, TAdapter> Build(Container container)
        {
            var result = LMotion.Create<TValue, TOptions, TAdapter>(
                    fromResolver.Resolve(container),
                    toResolver.Resolve(container),
                    durationResolver.Resolve(container)
                    )
                .WithEase(ease)
                .WithIgnoreTimeScale(ignoreTimeScale);
            if (delayResolver != null)
            {
                result = result.WithDelay(delayResolver.Resolve(container));
            }
            if (loopCountResolver != null)
            {
                result = result.WithLoops(loopCountResolver.Resolve(container), loopType);
            }
            if (motionSchedulerResolver != null)
            {
                result = result.WithScheduler(motionSchedulerResolver.Resolve(container));
            }

            return result;
        }
    }

    [Serializable]
    public sealed class Vector3Parameters : Parameters<Vector3Resolver, Vector3, NoOptions, Vector3MotionAdapter>
    {
    }

    [Serializable]
    public sealed class FloatParameters : Parameters<FloatResolver, float, NoOptions, FloatMotionAdapter>
    {
    }

    [AddTypeMenu("LitMotion/Bind To Position")]
    [Serializable]
    public sealed class BindToPosition : ISequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        public TransformResolver targetResolver;

        [SerializeField]
        private Vector3Parameters parameters;

        public BindToPosition()
        {
        }

        public BindToPosition(TransformResolver targetResolver, Vector3Parameters parameters)
        {
            this.targetResolver = targetResolver;
            this.parameters = parameters;
        }

#if USS_SUPPORT_UNITASK
        public async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var motion = parameters.Build(container);
#if USS_SUPPORT_UNITASK
            await motion.BindToPosition(target).ToUniTask(cancellationToken: cancellationToken);
#else
            await MainThreadDispatcher.Instance.RunCoroutineAsTask(motion.BindToPosition(target).ToYieldInteraction());
#endif
        }
    }

    [AddTypeMenu("LitMotion/Bind To Local Position")]
    [Serializable]
    public sealed class BindToLocalPosition : ISequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        public TransformResolver targetResolver;

        [SerializeField]
        private Vector3Parameters parameters;

        public BindToLocalPosition()
        {
        }

        public BindToLocalPosition(TransformResolver targetResolver, Vector3Parameters parameters)
        {
            this.targetResolver = targetResolver;
            this.parameters = parameters;
        }

#if USS_SUPPORT_UNITASK
        public async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var motion = parameters.Build(container);
#if USS_SUPPORT_UNITASK
            await motion.BindToPosition(target).ToUniTask(cancellationToken: cancellationToken);
#else
            await MainThreadDispatcher.Instance.RunCoroutineAsTask(motion.BindToPosition(target).ToYieldInteraction());
#endif
        }
    }

    [AddTypeMenu("LitMotion/Bind To Euler Angles")]
    [Serializable]
    public sealed class BindToEulerAngles : ISequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        public TransformResolver targetResolver;

        [SerializeField]
        private Vector3Parameters parameters;

        public BindToEulerAngles()
        {
        }

        public BindToEulerAngles(TransformResolver targetResolver, Vector3Parameters parameters)
        {
            this.targetResolver = targetResolver;
            this.parameters = parameters;
        }

#if USS_SUPPORT_UNITASK
        public async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var motion = parameters.Build(container);
#if USS_SUPPORT_UNITASK
            await motion.BindToEulerAngles(target).ToUniTask(cancellationToken: cancellationToken);
#else
            await MainThreadDispatcher.Instance.RunCoroutineAsTask(motion.BindToEulerAngles(target).ToYieldInteraction());
#endif
        }
    }

    [AddTypeMenu("LitMotion/Bind To Local Euler Angles")]
    [Serializable]
    public sealed class BindToLocalEulerAngles : ISequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        public TransformResolver targetResolver;

        [SerializeField]
        private Vector3Parameters parameters;

        public BindToLocalEulerAngles()
        {
        }

        public BindToLocalEulerAngles(TransformResolver targetResolver, Vector3Parameters parameters)
        {
            this.targetResolver = targetResolver;
            this.parameters = parameters;
        }

#if USS_SUPPORT_UNITASK
        public async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var motion = parameters.Build(container);
#if USS_SUPPORT_UNITASK
            await motion.BindToLocalEulerAngles(target).ToUniTask(cancellationToken: cancellationToken);
#else
            await MainThreadDispatcher.Instance.RunCoroutineAsTask(motion.BindToLocalEulerAngles(target).ToYieldInteraction());
#endif
        }
    }

    [AddTypeMenu("LitMotion/Bind To Local Scale")]
    [Serializable]
    public sealed class BindToLocalScale : ISequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        public TransformResolver targetResolver;

        [SerializeField]
        private Vector3Parameters parameters;

        public BindToLocalScale()
        {
        }

        public BindToLocalScale(TransformResolver targetResolver, Vector3Parameters parameters)
        {
            this.targetResolver = targetResolver;
            this.parameters = parameters;
        }

#if USS_SUPPORT_UNITASK
        public async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var motion = parameters.Build(container);
#if USS_SUPPORT_UNITASK
            await motion.BindToLocalScale(target).ToUniTask(cancellationToken: cancellationToken);
#else
            await MainThreadDispatcher.Instance.RunCoroutineAsTask(motion.BindToLocalScale(target).ToYieldInteraction());
#endif
        }
    }

    [AddTypeMenu("LitMotion/Bind To PositionX")]
    [Serializable]
    public sealed class BindToPositionX : ISequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        public TransformResolver targetResolver;

        [SerializeField]
        private FloatParameters parameters;

        public BindToPositionX()
        {
        }

        public BindToPositionX(TransformResolver targetResolver, FloatParameters parameters)
        {
            this.targetResolver = targetResolver;
            this.parameters = parameters;
        }

#if USS_SUPPORT_UNITASK
        public async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var motion = parameters.Build(container);
#if USS_SUPPORT_UNITASK
            await motion.BindToPositionX(target).ToUniTask(cancellationToken: cancellationToken);
#else
            await MainThreadDispatcher.Instance.RunCoroutineAsTask(motion.BindToPositionX(target).ToYieldInteraction());
#endif
        }
    }

    [AddTypeMenu("LitMotion/Bind To PositionY")]
    [Serializable]
    public sealed class BindToPositionY : ISequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        public TransformResolver targetResolver;

        [SerializeField]
        private FloatParameters parameters;

        public BindToPositionY()
        {
        }

        public BindToPositionY(TransformResolver targetResolver, FloatParameters parameters)
        {
            this.targetResolver = targetResolver;
            this.parameters = parameters;
        }

#if USS_SUPPORT_UNITASK
        public async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var motion = parameters.Build(container);
#if USS_SUPPORT_UNITASK
            await motion.BindToPositionY(target).ToUniTask(cancellationToken: cancellationToken);
#else
            await MainThreadDispatcher.Instance.RunCoroutineAsTask(motion.BindToPositionY(target).ToYieldInteraction());
#endif
        }
    }

    [AddTypeMenu("LitMotion/Bind To PositionZ")]
    [Serializable]
    public sealed class BindToPositionZ : ISequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        public TransformResolver targetResolver;

        [SerializeField]
        private FloatParameters parameters;

        public BindToPositionZ()
        {
        }

        public BindToPositionZ(TransformResolver targetResolver, FloatParameters parameters)
        {
            this.targetResolver = targetResolver;
            this.parameters = parameters;
        }

#if USS_SUPPORT_UNITASK
        public async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var motion = parameters.Build(container);
#if USS_SUPPORT_UNITASK
            await motion.BindToPositionZ(target).ToUniTask(cancellationToken: cancellationToken);
#else
            await MainThreadDispatcher.Instance.RunCoroutineAsTask(motion.BindToPositionZ(target).ToYieldInteraction());
#endif
        }
    }

    [AddTypeMenu("LitMotion/Bind To Local PositionX")]
    [Serializable]
    public sealed class BindToLocalPositionX : ISequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        public TransformResolver targetResolver;

        [SerializeField]
        private FloatParameters parameters;

        public BindToLocalPositionX()
        {
        }

        public BindToLocalPositionX(TransformResolver targetResolver, FloatParameters parameters)
        {
            this.targetResolver = targetResolver;
            this.parameters = parameters;
        }

#if USS_SUPPORT_UNITASK
        public async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif

        {
            var target = this.targetResolver.Resolve(container);
            var motion = parameters.Build(container);
#if USS_SUPPORT_UNITASK
            await motion.BindToLocalPositionX(target).ToUniTask(cancellationToken: cancellationToken);
#else
            await MainThreadDispatcher.Instance.RunCoroutineAsTask(motion.BindToLocalPositionX(target).ToYieldInteraction());
#endif
        }
    }

    [AddTypeMenu("LitMotion/Bind To Local PositionY")]
    [Serializable]
    public sealed class BindToLocalPositionY : ISequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        public TransformResolver targetResolver;

        [SerializeField]
        private FloatParameters parameters;

        public BindToLocalPositionY()
        {
        }

        public BindToLocalPositionY(TransformResolver targetResolver, FloatParameters parameters)
        {
            this.targetResolver = targetResolver;
            this.parameters = parameters;
        }

#if USS_SUPPORT_UNITASK
        public async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif

        {
            var target = this.targetResolver.Resolve(container);
            var motion = parameters.Build(container);
#if USS_SUPPORT_UNITASK
            await motion.BindToLocalPositionY(target).ToUniTask(cancellationToken: cancellationToken);
#else
            await MainThreadDispatcher.Instance.RunCoroutineAsTask(motion.BindToLocalPositionY(target).ToYieldInteraction());
#endif
        }
    }

    [AddTypeMenu("LitMotion/Bind To Local PositionZ")]
    [Serializable]
    public sealed class BindToLocalPositionZ : ISequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        public TransformResolver targetResolver;

        [SerializeField]
        private FloatParameters parameters;

        public BindToLocalPositionZ()
        {
        }

        public BindToLocalPositionZ(TransformResolver targetResolver, FloatParameters parameters)
        {
            this.targetResolver = targetResolver;
            this.parameters = parameters;
        }

#if USS_SUPPORT_UNITASK
        public async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif

        {
            var target = this.targetResolver.Resolve(container);
            var motion = parameters.Build(container);
#if USS_SUPPORT_UNITASK
            await motion.BindToLocalPositionZ(target).ToUniTask(cancellationToken: cancellationToken);
#else
            await MainThreadDispatcher.Instance.RunCoroutineAsTask(motion.BindToLocalPositionZ(target).ToYieldInteraction());
#endif
        }
    }
}
#endif
