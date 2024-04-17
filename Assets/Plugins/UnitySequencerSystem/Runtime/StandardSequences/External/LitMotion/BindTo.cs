#if USS_SUPPORT_LIT_MOTION
using System;
using System.Threading;
using UnitySequencerSystem.Resolvers;
using UnitySequencerSystem.Resolvers.LitMotion;
using LitMotion;
using LitMotion.Extensions;
using UnityEngine;
using LitMotion.Adapters;
using UnityEngine.UI;



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

    [Serializable]
    public sealed class ColorParameters : Parameters<ColorResolver, Color, NoOptions, ColorMotionAdapter>
    {
    }

    [Serializable]
    public abstract class BindTo<TValueResolver, TValue, TParameters> : Sequence
        where TValueResolver : IResolver<TValue>
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        protected TValueResolver targetResolver;

        [SerializeField]
        protected TParameters parameters;

        public BindTo()
        {
        }

        public BindTo(TValueResolver targetResolver, TParameters parameters)
        {
            this.targetResolver = targetResolver;
            this.parameters = parameters;
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("LitMotion/Bind To Position")]
#endif
    [Serializable]
    public sealed class BindToPosition : BindTo<TransformResolver, Transform, Vector3Parameters>
    {
        public BindToPosition()
        {
        }

        public BindToPosition(TransformResolver targetResolver, Vector3Parameters parameters)
            : base(targetResolver, parameters)
        {
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
    public sealed class BindToLocalPosition : BindTo<TransformResolver, Transform, Vector3Parameters>
    {
        public BindToLocalPosition()
        {
        }

        public BindToLocalPosition(TransformResolver targetResolver, Vector3Parameters parameters)
            : base(targetResolver, parameters)
        {
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
    public sealed class BindToEulerAngles : BindTo<TransformResolver, Transform, Vector3Parameters>
    {
        public BindToEulerAngles()
        {
        }

        public BindToEulerAngles(TransformResolver targetResolver, Vector3Parameters parameters)
            : base(targetResolver, parameters)
        {
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
    public sealed class BindToLocalEulerAngles : BindTo<TransformResolver, Transform, Vector3Parameters>
    {
        public BindToLocalEulerAngles()
        {
        }

        public BindToLocalEulerAngles(TransformResolver targetResolver, Vector3Parameters parameters)
            : base(targetResolver, parameters)
        {
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
    public sealed class BindToLocalScale : BindTo<TransformResolver, Transform, Vector3Parameters>
    {
        public BindToLocalScale()
        {
        }

        public BindToLocalScale(TransformResolver targetResolver, Vector3Parameters parameters)
            : base(targetResolver, parameters)
        {
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
    public sealed class BindToPositionX : BindTo<TransformResolver, Transform, FloatParameters>
    {
        public BindToPositionX()
        {
        }

        public BindToPositionX(TransformResolver targetResolver, FloatParameters parameters)
            : base(targetResolver, parameters)
        {
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
    public sealed class BindToPositionY : BindTo<TransformResolver, Transform, FloatParameters>
    {
        public BindToPositionY()
        {
        }

        public BindToPositionY(TransformResolver targetResolver, FloatParameters parameters)
            : base(targetResolver, parameters)
        {
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
    public sealed class BindToPositionZ : BindTo<TransformResolver, Transform, FloatParameters>
    {
        public BindToPositionZ()
        {
        }

        public BindToPositionZ(TransformResolver targetResolver, FloatParameters parameters)
            : base(targetResolver, parameters)
        {
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
    public sealed class BindToLocalPositionX : BindTo<TransformResolver, Transform, FloatParameters>
    {
        public BindToLocalPositionX()
        {
        }

        public BindToLocalPositionX(TransformResolver targetResolver, FloatParameters parameters)
            : base(targetResolver, parameters)
        {
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
    public sealed class BindToLocalPositionY : BindTo<TransformResolver, Transform, FloatParameters>
    {
        public BindToLocalPositionY()
        {
        }

        public BindToLocalPositionY(TransformResolver targetResolver, FloatParameters parameters)
            : base(targetResolver, parameters)
        {
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
    public sealed class BindToLocalPositionZ : BindTo<TransformResolver, Transform, FloatParameters>
    {
        public BindToLocalPositionZ()
        {
        }

        public BindToLocalPositionZ(TransformResolver targetResolver, FloatParameters parameters)
            : base(targetResolver, parameters)
        {
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
    public sealed class BindToRotation : BindTo<TransformResolver, Transform, QuaternionParameters>
    {
        public BindToRotation()
        {
        }

        public BindToRotation(TransformResolver targetResolver, QuaternionParameters parameters)
            : base(targetResolver, parameters)
        {
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
    public sealed class BindToLocalRotation : BindTo<TransformResolver, Transform, QuaternionParameters>
    {
        public BindToLocalRotation()
        {
        }

        public BindToLocalRotation(TransformResolver targetResolver, QuaternionParameters parameters)
            : base(targetResolver, parameters)
        {
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
    public sealed class BindToLocalScaleX : BindTo<TransformResolver, Transform, FloatParameters>
    {
        public BindToLocalScaleX()
        {
        }

        public BindToLocalScaleX(TransformResolver targetResolver, FloatParameters parameters)
            : base(targetResolver, parameters)
        {
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
    public sealed class BindToLocalScaleY : BindTo<TransformResolver, Transform, FloatParameters>
    {
        public BindToLocalScaleY()
        {
        }

        public BindToLocalScaleY(TransformResolver targetResolver, FloatParameters parameters)
            : base(targetResolver, parameters)
        {
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
    public sealed class BindToLocalScaleZ : BindTo<TransformResolver, Transform, FloatParameters>
    {
        public BindToLocalScaleZ()
        {
        }

        public BindToLocalScaleZ(TransformResolver targetResolver, FloatParameters parameters)
            : base(targetResolver, parameters)
        {
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
    public sealed class BindToEulerAnglesX : BindTo<TransformResolver, Transform, FloatParameters>
    {
        public BindToEulerAnglesX()
        {
        }

        public BindToEulerAnglesX(TransformResolver targetResolver, FloatParameters parameters)
            : base(targetResolver, parameters)
        {
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
    public sealed class BindToEulerAnglesY : BindTo<TransformResolver, Transform, FloatParameters>
    {
        public BindToEulerAnglesY()
        {
        }

        public BindToEulerAnglesY(TransformResolver targetResolver, FloatParameters parameters)
            : base(targetResolver, parameters)
        {
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
    public sealed class BindToEulerAnglesZ : BindTo<TransformResolver, Transform, FloatParameters>
    {
        public BindToEulerAnglesZ()
        {
        }

        public BindToEulerAnglesZ(TransformResolver targetResolver, FloatParameters parameters)
            : base(targetResolver, parameters)
        {
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
    public sealed class BindToLocalEulerAnglesX : BindTo<TransformResolver, Transform, FloatParameters>
    {
        public BindToLocalEulerAnglesX()
        {
        }

        public BindToLocalEulerAnglesX(TransformResolver targetResolver, FloatParameters parameters)
            : base(targetResolver, parameters)
        {
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
    public sealed class BindToLocalEulerAnglesY : BindTo<TransformResolver, Transform, FloatParameters>
    {
        public BindToLocalEulerAnglesY()
        {
        }

        public BindToLocalEulerAnglesY(TransformResolver targetResolver, FloatParameters parameters)
            : base(targetResolver, parameters)
        {
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
    public sealed class BindToLocalEulerAnglesZ : BindTo<TransformResolver, Transform, FloatParameters>
    {
        public BindToLocalEulerAnglesZ()
        {
        }

        public BindToLocalEulerAnglesZ(TransformResolver targetResolver, FloatParameters parameters)
            : base(targetResolver, parameters)
        {
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

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("LitMotion/Bind To SpriteRenderer ColorR")]
#endif
    [Serializable]
    public sealed class BindToSpriteRendererColorR : BindTo<SpriteRendererResolver, SpriteRenderer, FloatParameters>
    {
        public BindToSpriteRendererColorR()
        {
        }

        public BindToSpriteRendererColorR(SpriteRendererResolver targetResolver, FloatParameters parameters)
            : base(targetResolver, parameters)
        {
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
                .BindToColorR(target)
                .AddTo(target)
                .ToUniTask(cancellationToken: cancellationToken);
#else
            await MainThreadDispatcher.Instance.RunCoroutineAsTask(motion.BindToColorR(target).ToYieldInteraction());
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("LitMotion/Bind To SpriteRenderer ColorG")]
#endif
    [Serializable]
    public sealed class BindToSpriteRendererColorG : BindTo<SpriteRendererResolver, SpriteRenderer, FloatParameters>
    {
        public BindToSpriteRendererColorG()
        {
        }

        public BindToSpriteRendererColorG(SpriteRendererResolver targetResolver, FloatParameters parameters)
            : base(targetResolver, parameters)
        {
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
                .BindToColorG(target)
                .AddTo(target)
                .ToUniTask(cancellationToken: cancellationToken);
#else
            await MainThreadDispatcher.Instance.RunCoroutineAsTask(motion.BindToColorG(target).ToYieldInteraction());
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("LitMotion/Bind To SpriteRenderer ColorB")]
#endif
    [Serializable]
    public sealed class BindToSpriteRendererColorB : BindTo<SpriteRendererResolver, SpriteRenderer, FloatParameters>
    {
        public BindToSpriteRendererColorB()
        {
        }

        public BindToSpriteRendererColorB(SpriteRendererResolver targetResolver, FloatParameters parameters)
            : base(targetResolver, parameters)
        {
        }

#if USS_SUPPORT_UNITASK
        public override async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var motion = parameters.Build(container);
#if USS_SUPPORT_UNITTASK
            cancellationToken = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, target.GetCancellationTokenOnDestroy()).Token;
            await motion
                .BindToColorB(target)
                .AddTo(target)
                .ToUniTask(cancellationToken: cancellationToken);
#else
            await MainThreadDispatcher.Instance.RunCoroutineAsTask(motion.BindToColorB(target).ToYieldInteraction());
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("LitMotion/Bind To SpriteRenderer ColorA")]
#endif
    [Serializable]
    public sealed class BindToSpriteRendererColorA : BindTo<SpriteRendererResolver, SpriteRenderer, FloatParameters>
    {
        public BindToSpriteRendererColorA()
        {
        }

        public BindToSpriteRendererColorA(SpriteRendererResolver targetResolver, FloatParameters parameters)
            : base(targetResolver, parameters)
        {
        }

#if USS_SUPPORT_UNITASK
        public override async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var motion = parameters.Build(container);
#if USS_SUPPORT_UNITTASK
            cancellationToken = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, target.GetCancellationTokenOnDestroy()).Token;
            await motion
                .BindToColorA(target)
                .AddTo(target)
                .ToUniTask(cancellationToken: cancellationToken);
#else
            await MainThreadDispatcher.Instance.RunCoroutineAsTask(motion.BindToColorA(target).ToYieldInteraction());
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("LitMotion/Bind To SpriteRenderer Color")]
#endif
    [Serializable]
    public sealed class BindToSpriteRendererColor : BindTo<SpriteRendererResolver, SpriteRenderer, ColorParameters>
    {
        public BindToSpriteRendererColor()
        {
        }

        public BindToSpriteRendererColor(SpriteRendererResolver targetResolver, ColorParameters parameters)
            : base(targetResolver, parameters)
        {
        }

#if USS_SUPPORT_UNITASK
        public override async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var motion = parameters.Build(container);
#if USS_SUPPORT_UNITTASK
            cancellationToken = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, target.GetCancellationTokenOnDestroy()).Token;
            await motion
                .BindToColor(target)
                .AddTo(target)
                .ToUniTask(cancellationToken: cancellationToken);
#else
            await MainThreadDispatcher.Instance.RunCoroutineAsTask(motion.BindToColor(target).ToYieldInteraction());
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("LitMotion/Bind To Graphic ColorR")]
#endif
    [Serializable]
    public sealed class BindToGraphicColorR : BindTo<GraphicResolver, Graphic, FloatParameters>
    {
        public BindToGraphicColorR()
        {
        }

        public BindToGraphicColorR(GraphicResolver targetResolver, FloatParameters parameters)
            : base(targetResolver, parameters)
        {
        }

#if USS_SUPPORT_UNITASK
        public override async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var motion = parameters.Build(container);
#if USS_SUPPORT_UNITTASK
            cancellationToken = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, target.GetCancellationTokenOnDestroy()).Token;
            await motion
                .BindToColorR(target)
                .AddTo(target)
                .ToUniTask(cancellationToken: cancellationToken);
#else
            await MainThreadDispatcher.Instance.RunCoroutineAsTask(motion.BindToColorR(target).ToYieldInteraction());
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("LitMotion/Bind To Graphic ColorG")]
#endif
    [Serializable]
    public sealed class BindToGraphicColorG : BindTo<GraphicResolver, Graphic, FloatParameters>
    {
        public BindToGraphicColorG()
        {
        }

        public BindToGraphicColorG(GraphicResolver targetResolver, FloatParameters parameters)
            : base(targetResolver, parameters)
        {
        }

#if USS_SUPPORT_UNITASK
        public override async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var motion = parameters.Build(container);
#if USS_SUPPORT_UNITTASK
            cancellationToken = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, target.GetCancellationTokenOnDestroy()).Token;
            await motion
                .BindToColorG(target)
                .AddTo(target)
                .ToUniTask(cancellationToken: cancellationToken);
#else
            await MainThreadDispatcher.Instance.RunCoroutineAsTask(motion.BindToColorG(target).ToYieldInteraction());
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("LitMotion/Bind To Graphic ColorB")]
#endif
    [Serializable]
    public sealed class BindToGraphicColorB : BindTo<GraphicResolver, Graphic, FloatParameters>
    {
        public BindToGraphicColorB()
        {
        }

        public BindToGraphicColorB(GraphicResolver targetResolver, FloatParameters parameters)
            : base(targetResolver, parameters)
        {
        }

#if USS_SUPPORT_UNITASK
        public override async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var motion = parameters.Build(container);
#if USS_SUPPORT_UNITTASK
            await motion
                .BindToColorB(target)
                .AddTo(target)
                .ToUniTask(cancellationToken: cancellationToken);
#else
            await MainThreadDispatcher.Instance.RunCoroutineAsTask(motion.BindToColorB(target).ToYieldInteraction());
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("LitMotion/Bind To Graphic ColorA")]
#endif
    [Serializable]
    public sealed class BindToGraphicColorA : BindTo<GraphicResolver, Graphic, FloatParameters>
    {
        public BindToGraphicColorA()
        {
        }

        public BindToGraphicColorA(GraphicResolver targetResolver, FloatParameters parameters)
            : base(targetResolver, parameters)
        {
        }

#if USS_SUPPORT_UNITASK
        public override async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var motion = parameters.Build(container);
#if USS_SUPPORT_UNITTASK
            await motion
                .BindToColorA(target)
                .AddTo(target)
                .ToUniTask(cancellationToken: cancellationToken);
#else
            await MainThreadDispatcher.Instance.RunCoroutineAsTask(motion.BindToColorA(target).ToYieldInteraction());
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("LitMotion/Bind To Graphic Color")]
#endif
    [Serializable]
    public sealed class BindToGraphicColor : BindTo<GraphicResolver, Graphic, ColorParameters>
    {
        public BindToGraphicColor()
        {
        }

        public BindToGraphicColor(GraphicResolver targetResolver, ColorParameters parameters)
            : base(targetResolver, parameters)
        {
        }

#if USS_SUPPORT_UNITASK
        public override async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var motion = parameters.Build(container);
#if USS_SUPPORT_UNITTASK
            await motion
                .BindToColor(target)
                .AddTo(target)
                .ToUniTask(cancellationToken: cancellationToken);
#else
            await MainThreadDispatcher.Instance.RunCoroutineAsTask(motion.BindToColor(target).ToYieldInteraction());
#endif
        }
    }
}
#endif
