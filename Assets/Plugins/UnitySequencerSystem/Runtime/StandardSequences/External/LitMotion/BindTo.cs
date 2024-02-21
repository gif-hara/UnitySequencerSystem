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

        public MotionBuilder<TValue, TOptions, TAdapter> Build(Container container)
        {
            var result = LMotion.Create<TValue, TOptions, TAdapter>(
                    fromResolver.Resolve(container),
                    toResolver.Resolve(container),
                    durationResolver.Resolve(container)
                    )
                .WithEase(ease);
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

    [Serializable]
    public sealed class QuaternionParameters : Parameters<QuaternionResolver, Quaternion, NoOptions, QuaternionMotionAdapter>
    {
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("LitMotion/Bind To Position")]
#endif
    [Serializable]
    public sealed class BindToPosition : Sequence
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
        public override async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var motion = parameters.Build(container);
#if USS_SUPPORT_UNITASK
            cancellationToken = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, target.GetCancellationTokenOnDestroy()).Token;
            await motion
                .BindToPosition(target)
                .AddTo(target)
                .ToUniTask(cancellationToken: cancellationToken);
#else
            await MainThreadDispatcher.Instance.RunCoroutineAsTask(motion.BindToPosition(target).ToYieldInteraction());
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("LitMotion/Bind To Local Position")]
#endif
    [Serializable]
    public sealed class BindToLocalPosition : Sequence
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
        public override async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var motion = parameters.Build(container);
#if USS_SUPPORT_UNITASK
            cancellationToken = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, target.GetCancellationTokenOnDestroy()).Token;
            await motion
                .BindToPosition(target)
                .AddTo(target)
                .ToUniTask(cancellationToken: cancellationToken);
#else
            await MainThreadDispatcher.Instance.RunCoroutineAsTask(motion.BindToPosition(target).ToYieldInteraction());
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("LitMotion/Bind To Euler Angles")]
#endif
    [Serializable]
    public sealed class BindToEulerAngles : Sequence
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
        public override async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var motion = parameters.Build(container);
#if USS_SUPPORT_UNITASK
            cancellationToken = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, target.GetCancellationTokenOnDestroy()).Token;
            await motion
                .BindToEulerAngles(target)
                .AddTo(target)
                .ToUniTask(cancellationToken: cancellationToken);
#else
            await MainThreadDispatcher.Instance.RunCoroutineAsTask(motion.BindToEulerAngles(target).ToYieldInteraction());
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("LitMotion/Bind To Local Euler Angles")]
#endif
    [Serializable]
    public sealed class BindToLocalEulerAngles : Sequence
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
        public override async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var motion = parameters.Build(container);
#if USS_SUPPORT_UNITASK
            cancellationToken = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, target.GetCancellationTokenOnDestroy()).Token;
            await motion
                .BindToLocalEulerAngles(target)
                .AddTo(target)
                .ToUniTask(cancellationToken: cancellationToken);
#else
            await MainThreadDispatcher.Instance.RunCoroutineAsTask(motion.BindToLocalEulerAngles(target).ToYieldInteraction());
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("LitMotion/Bind To Local Scale")]
#endif
    [Serializable]
    public sealed class BindToLocalScale : Sequence
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
        public override async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var motion = parameters.Build(container);
#if USS_SUPPORT_UNITASK
            cancellationToken = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, target.GetCancellationTokenOnDestroy()).Token;
            await motion
                .BindToLocalScale(target)
                .AddTo(target)
                .ToUniTask(cancellationToken: cancellationToken);
#else
            await MainThreadDispatcher.Instance.RunCoroutineAsTask(motion.BindToLocalScale(target).ToYieldInteraction());
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("LitMotion/Bind To PositionX")]
#endif
    [Serializable]
    public sealed class BindToPositionX : Sequence
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
        public override async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var motion = parameters.Build(container);
#if USS_SUPPORT_UNITASK
            cancellationToken = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, target.GetCancellationTokenOnDestroy()).Token;
            await motion
                .BindToPositionX(target)
                .AddTo(target)
                .ToUniTask(cancellationToken: cancellationToken);
#else
            await MainThreadDispatcher.Instance.RunCoroutineAsTask(motion.BindToPositionX(target).ToYieldInteraction());
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("LitMotion/Bind To PositionY")]
#endif
    [Serializable]
    public sealed class BindToPositionY : Sequence
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
        public override async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var motion = parameters.Build(container);
#if USS_SUPPORT_UNITASK
            cancellationToken = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, target.GetCancellationTokenOnDestroy()).Token;
            await motion
                .BindToPositionY(target)
                .AddTo(target)
                .ToUniTask(cancellationToken: cancellationToken);
#else
            await MainThreadDispatcher.Instance.RunCoroutineAsTask(motion.BindToPositionY(target).ToYieldInteraction());
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("LitMotion/Bind To PositionZ")]
#endif
    [Serializable]
    public sealed class BindToPositionZ : Sequence
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
        public override async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var motion = parameters.Build(container);
#if USS_SUPPORT_UNITASK
            cancellationToken = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, target.GetCancellationTokenOnDestroy()).Token;
            await motion
                .BindToPositionZ(target)
                .AddTo(target)
                .ToUniTask(cancellationToken: cancellationToken);
#else
            await MainThreadDispatcher.Instance.RunCoroutineAsTask(motion.BindToPositionZ(target).ToYieldInteraction());
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("LitMotion/Bind To Local PositionX")]
#endif
    [Serializable]
    public sealed class BindToLocalPositionX : Sequence
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
        public override async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif

        {
            var target = this.targetResolver.Resolve(container);
            var motion = parameters.Build(container);
#if USS_SUPPORT_UNITASK
            cancellationToken = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, target.GetCancellationTokenOnDestroy()).Token;
            await motion
                .BindToLocalPositionX(target)
                .AddTo(target)
                .ToUniTask(cancellationToken: cancellationToken);
#else
            await MainThreadDispatcher.Instance.RunCoroutineAsTask(motion.BindToLocalPositionX(target).ToYieldInteraction());
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("LitMotion/Bind To Local PositionY")]
#endif
    [Serializable]
    public sealed class BindToLocalPositionY : Sequence
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
        public override async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif

        {
            var target = this.targetResolver.Resolve(container);
            var motion = parameters.Build(container);
#if USS_SUPPORT_UNITASK
            cancellationToken = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, target.GetCancellationTokenOnDestroy()).Token;
            await motion
                .BindToLocalPositionY(target)
                .AddTo(target)
                .ToUniTask(cancellationToken: cancellationToken);
#else
            await MainThreadDispatcher.Instance.RunCoroutineAsTask(motion.BindToLocalPositionY(target).ToYieldInteraction());
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("LitMotion/Bind To Local PositionZ")]
#endif
    [Serializable]
    public sealed class BindToLocalPositionZ : Sequence
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
        public override async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif

        {
            var target = this.targetResolver.Resolve(container);
            var motion = parameters.Build(container);
#if USS_SUPPORT_UNITASK
            cancellationToken = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, target.GetCancellationTokenOnDestroy()).Token;
            await motion
                .BindToLocalPositionZ(target)
                .AddTo(target)
                .ToUniTask(cancellationToken: cancellationToken);
#else
            await MainThreadDispatcher.Instance.RunCoroutineAsTask(motion.BindToLocalPositionZ(target).ToYieldInteraction());
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("LitMotion/Bind To Rotation")]
#endif
    [Serializable]
    public sealed class BindToRotation : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        public TransformResolver targetResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        public QuaternionParameters parameters;

        public BindToRotation()
        {
        }

        public BindToRotation(TransformResolver targetResolver, QuaternionParameters parameters)
        {
            this.targetResolver = targetResolver;
            this.parameters = parameters;
        }

#if USS_SUPPORT_UNITASK
        public override async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif

        {
            var target = this.targetResolver.Resolve(container);
            var motion = parameters.Build(container);
#if USS_SUPPORT_UNITASK
            cancellationToken = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, target.GetCancellationTokenOnDestroy()).Token;
            await motion
                .BindToRotation(target)
                .AddTo(target)
                .ToUniTask(cancellationToken: cancellationToken);
#else
            await MainThreadDispatcher.Instance.RunCoroutineAsTask(motion.BindToRotation(target).ToYieldInteraction());
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("LitMotion/Bind To Local Rotation")]
#endif
    [Serializable]
    public sealed class BindToLocalRotation : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        public TransformResolver targetResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        public QuaternionParameters parameters;

        public BindToLocalRotation()
        {
        }

        public BindToLocalRotation(TransformResolver targetResolver, QuaternionParameters parameters)
        {
            this.targetResolver = targetResolver;
            this.parameters = parameters;
        }

#if USS_SUPPORT_UNITASK
        public override async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var motion = parameters.Build(container);
#if USS_SUPPORT_UNITASK
            cancellationToken = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, target.GetCancellationTokenOnDestroy()).Token;
            await motion
                .BindToLocalRotation(target)
                .AddTo(target)
                .ToUniTask(cancellationToken: cancellationToken);
#else
            await MainThreadDispatcher.Instance.RunCoroutineAsTask(motion.BindToLocalRotation(target).ToYieldInteraction());
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("LitMotion/Bind To Local ScaleX")]
#endif
    [Serializable]
    public sealed class BindToLocalScaleX : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        public TransformResolver targetResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        public FloatParameters parameters;

        public BindToLocalScaleX()
        {
        }

        public BindToLocalScaleX(TransformResolver targetResolver, FloatParameters parameters)
        {
            this.targetResolver = targetResolver;
            this.parameters = parameters;
        }

#if USS_SUPPORT_UNITASK
        public override async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var motion = parameters.Build(container);
#if USS_SUPPORT_UNITASK
            cancellationToken = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, target.GetCancellationTokenOnDestroy()).Token;
            await motion
                .BindToLocalScaleX(target)
                .AddTo(target)
                .ToUniTask(cancellationToken: cancellationToken);
#else
            await MainThreadDispatcher.Instance.RunCoroutineAsTask(motion.BindToLocalScaleX(target).ToYieldInteraction());
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("LitMotion/Bind To Local ScaleY")]
#endif
    [Serializable]
    public sealed class BindToLocalScaleY : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        public TransformResolver targetResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        public FloatParameters parameters;

        public BindToLocalScaleY()
        {
        }

        public BindToLocalScaleY(TransformResolver targetResolver, FloatParameters parameters)
        {
            this.targetResolver = targetResolver;
            this.parameters = parameters;
        }

#if USS_SUPPORT_UNITASK
        public override async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var motion = parameters.Build(container);
#if USS_SUPPORT_UNITASK
            cancellationToken = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, target.GetCancellationTokenOnDestroy()).Token;
            await motion
                .BindToLocalScaleY(target)
                .AddTo(target)
                .ToUniTask(cancellationToken: cancellationToken);
#else
            await MainThreadDispatcher.Instance.RunCoroutineAsTask(motion.BindToLocalScaleY(target).ToYieldInteraction());
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("LitMotion/Bind To Local ScaleZ")]
#endif
    [Serializable]
    public sealed class BindToLocalScaleZ : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        public TransformResolver targetResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        public FloatParameters parameters;

        public BindToLocalScaleZ()
        {
        }

        public BindToLocalScaleZ(TransformResolver targetResolver, FloatParameters parameters)
        {
            this.targetResolver = targetResolver;
            this.parameters = parameters;
        }

#if USS_SUPPORT_UNITASK
        public override async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var motion = parameters.Build(container);
#if USS_SUPPORT_UNITASK
            cancellationToken = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, target.GetCancellationTokenOnDestroy()).Token;
            await motion
                .BindToLocalScaleZ(target)
                .AddTo(target)
                .ToUniTask(cancellationToken: cancellationToken);
#else
            await MainThreadDispatcher.Instance.RunCoroutineAsTask(motion.BindToLocalScaleZ(target).ToYieldInteraction());
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("LitMotion/Bind To Euler AnglesX")]
#endif
    [Serializable]
    public sealed class BindToEulerAnglesX : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        public TransformResolver targetResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        public FloatParameters parameters;

        public BindToEulerAnglesX()
        {
        }

        public BindToEulerAnglesX(TransformResolver targetResolver, FloatParameters parameters)
        {
            this.targetResolver = targetResolver;
            this.parameters = parameters;
        }

#if USS_SUPPORT_UNITASK
        public override async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var motion = parameters.Build(container);
#if USS_SUPPORT_UNITASK
            cancellationToken = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, target.GetCancellationTokenOnDestroy()).Token;
            await motion
                .BindToEulerAnglesX(target)
                .AddTo(target)
                .ToUniTask(cancellationToken: cancellationToken);
#else
            await MainThreadDispatcher.Instance.RunCoroutineAsTask(motion.BindToEulerAnglesX(target).ToYieldInteraction());
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("LitMotion/Bind To Euler AnglesY")]
#endif
    [Serializable]
    public sealed class BindToEulerAnglesY : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        public TransformResolver targetResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        public FloatParameters parameters;

        public BindToEulerAnglesY()
        {
        }

        public BindToEulerAnglesY(TransformResolver targetResolver, FloatParameters parameters)
        {
            this.targetResolver = targetResolver;
            this.parameters = parameters;
        }

#if USS_SUPPORT_UNITASK
        public override async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var motion = parameters.Build(container);
#if USS_SUPPORT_UNITASK
            cancellationToken = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, target.GetCancellationTokenOnDestroy()).Token;
            await motion
                .BindToEulerAnglesY(target)
                .AddTo(target)
                .ToUniTask(cancellationToken: cancellationToken);
#else
            await MainThreadDispatcher.Instance.RunCoroutineAsTask(motion.BindToEulerAnglesY(target).ToYieldInteraction());
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("LitMotion/Bind To Euler AnglesZ")]
#endif
    [Serializable]
    public sealed class BindToEulerAnglesZ : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        public TransformResolver targetResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        public FloatParameters parameters;

        public BindToEulerAnglesZ()
        {
        }

        public BindToEulerAnglesZ(TransformResolver targetResolver, FloatParameters parameters)
        {
            this.targetResolver = targetResolver;
            this.parameters = parameters;
        }

#if USS_SUPPORT_UNITASK
        public override async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var motion = parameters.Build(container);
#if USS_SUPPORT_UNITASK
            cancellationToken = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, target.GetCancellationTokenOnDestroy()).Token;
            await motion
                .BindToEulerAnglesZ(target)
                .AddTo(target)
                .ToUniTask(cancellationToken: cancellationToken);
#else
            await MainThreadDispatcher.Instance.RunCoroutineAsTask(motion.BindToEulerAnglesZ(target).ToYieldInteraction());
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("LitMotion/Bind To Local Euler AnglesX")]
#endif
    [Serializable]
    public sealed class BindToLocalEulerAnglesX : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        public TransformResolver targetResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        public FloatParameters parameters;

        public BindToLocalEulerAnglesX()
        {
        }

        public BindToLocalEulerAnglesX(TransformResolver targetResolver, FloatParameters parameters)
        {
            this.targetResolver = targetResolver;
            this.parameters = parameters;
        }

#if USS_SUPPORT_UNITASK
        public override async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var motion = parameters.Build(container);
#if USS_SUPPORT_UNITASK
            cancellationToken = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, target.GetCancellationTokenOnDestroy()).Token;
            await motion
                .BindToLocalEulerAnglesX(target)
                .AddTo(target)
                .ToUniTask(cancellationToken: cancellationToken);
#else
            await MainThreadDispatcher.Instance.RunCoroutineAsTask(motion.BindToLocalEulerAnglesX(target).ToYieldInteraction());
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("LitMotion/Bind To Local Euler AnglesY")]
#endif
    [Serializable]
    public sealed class BindToLocalEulerAnglesY : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        public TransformResolver targetResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        public FloatParameters parameters;

        public BindToLocalEulerAnglesY()
        {
        }

        public BindToLocalEulerAnglesY(TransformResolver targetResolver, FloatParameters parameters)
        {
            this.targetResolver = targetResolver;
            this.parameters = parameters;
        }

#if USS_SUPPORT_UNITASK
        public override async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var motion = parameters.Build(container);
#if USS_SUPPORT_UNITASK
            cancellationToken = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, target.GetCancellationTokenOnDestroy()).Token;
            await motion
                .BindToLocalEulerAnglesY(target)
                .AddTo(target)
                .ToUniTask(cancellationToken: cancellationToken);
#else
            await MainThreadDispatcher.Instance.RunCoroutineAsTask(motion.BindToLocalEulerAnglesY(target).ToYieldInteraction());
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("LitMotion/Bind To Local Euler AnglesZ")]
#endif
    [Serializable]
    public sealed class BindToLocalEulerAnglesZ : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        public TransformResolver targetResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        public FloatParameters parameters;

        public BindToLocalEulerAnglesZ()
        {
        }

        public BindToLocalEulerAnglesZ(TransformResolver targetResolver, FloatParameters parameters)
        {
            this.targetResolver = targetResolver;
            this.parameters = parameters;
        }

#if USS_SUPPORT_UNITASK
        public override async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
    
        public override async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var motion = parameters.Build(container);
#if USS_SUPPORT_UNITASK
            cancellationToken = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, target.GetCancellationTokenOnDestroy()).Token;
            await motion
                .BindToLocalEulerAnglesZ(target)
                .AddTo(target)
                .ToUniTask(cancellationToken: cancellationToken);
#else
            await MainThreadDispatcher.Instance.RunCoroutineAsTask(motion.BindToLocalEulerAnglesZ(target).ToYieldInteraction());
#endif
        }
    }
}
#endif
