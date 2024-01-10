#if USS_SUPPORT_LIT_MOTION
using System;
using System.Threading;
using HK.UnitySequencerSystem.Resolvers;
using HK.UnitySequencerSystem.Resolvers.LitMotion;
using LitMotion;
using LitMotion.Extensions;
using UnityEngine;

#if USS_SUPPORT_UNITASK
using Cysharp.Threading.Tasks;
#else
using System.Threading.Tasks;
using HK.UnitySequencerSystem.Core;
#endif


namespace HK.UnitySequencerSystem.LitMotion
{
    [AddTypeMenu("LitMotion/Bind To Position")]
    [Serializable]
    public sealed class BindToPosition : ISequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private TransformResolver targetResolver;

        [SerializeField]
        private Ease ease;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver fromResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver toResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private FloatResolver durationResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private FloatResolver delayResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private IntResolver loopCountResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private MotionSchedulerResolver motionSchedulerResolver;

        public BindToPosition()
        {
        }

        public BindToPosition(
            TransformResolver targetResolver,
            Vector3Resolver fromResolver,
            Vector3Resolver toResolver,
            FloatResolver durationResolver,
            FloatResolver delayResolver,
            IntResolver loopCountResolver,
            MotionSchedulerResolver motionSchedulerResolver,
            Ease ease
            )
        {
            this.targetResolver = targetResolver;
            this.fromResolver = fromResolver;
            this.toResolver = toResolver;
            this.durationResolver = durationResolver;
            this.delayResolver = delayResolver;
            this.loopCountResolver = loopCountResolver;
            this.motionSchedulerResolver = motionSchedulerResolver;
            this.ease = ease;
        }

#if USS_SUPPORT_UNITASK
        public async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var motion = LMotion.Create(
                    fromResolver.Resolve(container),
                    toResolver.Resolve(container),
                    durationResolver.Resolve(container)
                    )
                .WithEase(ease);
            if (delayResolver != null)
            {
                motion = motion.WithDelay(delayResolver.Resolve(container));
            }
            if (loopCountResolver != null)
            {
                motion = motion.WithLoops(loopCountResolver.Resolve(container));
            }
            if (motionSchedulerResolver != null)
            {
                motion = motion.WithScheduler(motionSchedulerResolver.Resolve(container));
            }
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
        private TransformResolver targetResolver;

        [SerializeField]
        private Ease ease;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver fromResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver toResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private FloatResolver durationResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private FloatResolver delayResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private IntResolver loopCountResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private MotionSchedulerResolver motionSchedulerResolver;

        public BindToLocalPosition()
        {
        }

        public BindToLocalPosition(
            TransformResolver targetResolver,
            Vector3Resolver fromResolver,
            Vector3Resolver toResolver,
            FloatResolver durationResolver,
            FloatResolver delayResolver,
            IntResolver loopCountResolver,
            MotionSchedulerResolver motionSchedulerResolver,
            Ease ease
            )
        {
            this.targetResolver = targetResolver;
            this.fromResolver = fromResolver;
            this.toResolver = toResolver;
            this.durationResolver = durationResolver;
            this.delayResolver = delayResolver;
            this.loopCountResolver = loopCountResolver;
            this.motionSchedulerResolver = motionSchedulerResolver;
            this.ease = ease;
        }

#if USS_SUPPORT_UNITASK
        public async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var motion = LMotion.Create(
                    fromResolver.Resolve(container),
                    toResolver.Resolve(container),
                    durationResolver.Resolve(container)
                    )
                .WithEase(ease);
            if (delayResolver != null)
            {
                motion = motion.WithDelay(delayResolver.Resolve(container));
            }
            if (loopCountResolver != null)
            {
                motion = motion.WithLoops(loopCountResolver.Resolve(container));
            }
            if (motionSchedulerResolver != null)
            {
                motion = motion.WithScheduler(motionSchedulerResolver.Resolve(container));
            }
#if USS_SUPPORT_UNITASK
            await motion.BindToLocalPosition(target).ToUniTask(cancellationToken: cancellationToken);
#else
            await MainThreadDispatcher.Instance.RunCoroutineAsTask(motion.BindToLocalPosition(target).ToYieldInteraction());
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
        private TransformResolver targetResolver;

        [SerializeField]
        private Ease ease;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver fromResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver toResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private FloatResolver durationResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private FloatResolver delayResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private IntResolver loopCountResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private MotionSchedulerResolver motionSchedulerResolver;

        public BindToEulerAngles()
        {
        }

        public BindToEulerAngles(
            TransformResolver targetResolver,
            Vector3Resolver fromResolver,
            Vector3Resolver toResolver,
            FloatResolver durationResolver,
            FloatResolver delayResolver,
            IntResolver loopCountResolver,
            MotionSchedulerResolver motionSchedulerResolver,
            Ease ease
            )
        {
            this.targetResolver = targetResolver;
            this.fromResolver = fromResolver;
            this.toResolver = toResolver;
            this.durationResolver = durationResolver;
            this.delayResolver = delayResolver;
            this.loopCountResolver = loopCountResolver;
            this.motionSchedulerResolver = motionSchedulerResolver;
            this.ease = ease;
        }

#if USS_SUPPORT_UNITASK
        public async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var motion = LMotion.Create(
                    fromResolver.Resolve(container),
                    toResolver.Resolve(container),
                    durationResolver.Resolve(container)
                    )
                .WithEase(ease);
            if (delayResolver != null)
            {
                motion = motion.WithDelay(delayResolver.Resolve(container));
            }
            if (loopCountResolver != null)
            {
                motion = motion.WithLoops(loopCountResolver.Resolve(container));
            }
            if (motionSchedulerResolver != null)
            {
                motion = motion.WithScheduler(motionSchedulerResolver.Resolve(container));
            }
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
        private TransformResolver targetResolver;

        [SerializeField]
        private Ease ease;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver fromResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver toResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private FloatResolver durationResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private FloatResolver delayResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private IntResolver loopCountResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private MotionSchedulerResolver motionSchedulerResolver;

        public BindToLocalEulerAngles()
        {
        }

        public BindToLocalEulerAngles(
            TransformResolver targetResolver,
            Vector3Resolver fromResolver,
            Vector3Resolver toResolver,
            FloatResolver durationResolver,
            FloatResolver delayResolver,
            IntResolver loopCountResolver,
            MotionSchedulerResolver motionSchedulerResolver,
            Ease ease
            )
        {
            this.targetResolver = targetResolver;
            this.fromResolver = fromResolver;
            this.toResolver = toResolver;
            this.durationResolver = durationResolver;
            this.delayResolver = delayResolver;
            this.loopCountResolver = loopCountResolver;
            this.motionSchedulerResolver = motionSchedulerResolver;
            this.ease = ease;
        }

#if USS_SUPPORT_UNITASK
        public async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var motion = LMotion.Create(
                    fromResolver.Resolve(container),
                    toResolver.Resolve(container),
                    durationResolver.Resolve(container)
                    )
                .WithEase(ease);
            if (delayResolver != null)
            {
                motion = motion.WithDelay(delayResolver.Resolve(container));
            }
            if (loopCountResolver != null)
            {
                motion = motion.WithLoops(loopCountResolver.Resolve(container));
            }
            if (motionSchedulerResolver != null)
            {
                motion = motion.WithScheduler(motionSchedulerResolver.Resolve(container));
            }
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
        private TransformResolver targetResolver;

        [SerializeField]
        private Ease ease;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver fromResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver toResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private FloatResolver durationResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private FloatResolver delayResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private IntResolver loopCountResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private MotionSchedulerResolver motionSchedulerResolver;

        public BindToLocalScale()
        {
        }

        public BindToLocalScale(
            TransformResolver targetResolver,
            Vector3Resolver fromResolver,
            Vector3Resolver toResolver,
            FloatResolver durationResolver,
            FloatResolver delayResolver,
            IntResolver loopCountResolver,
            MotionSchedulerResolver motionSchedulerResolver,
            Ease ease
            )
        {
            this.targetResolver = targetResolver;
            this.fromResolver = fromResolver;
            this.toResolver = toResolver;
            this.durationResolver = durationResolver;
            this.delayResolver = delayResolver;
            this.loopCountResolver = loopCountResolver;
            this.motionSchedulerResolver = motionSchedulerResolver;
            this.ease = ease;
        }

#if USS_SUPPORT_UNITASK
        public async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public async Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = this.targetResolver.Resolve(container);
            var motion = LMotion.Create(
                    fromResolver.Resolve(container),
                    toResolver.Resolve(container),
                    durationResolver.Resolve(container)
                    )
                .WithEase(ease);
            if (delayResolver != null)
            {
                motion = motion.WithDelay(delayResolver.Resolve(container));
            }
            if (loopCountResolver != null)
            {
                motion = motion.WithLoops(loopCountResolver.Resolve(container));
            }
            if (motionSchedulerResolver != null)
            {
                motion = motion.WithScheduler(motionSchedulerResolver.Resolve(container));
            }
#if USS_SUPPORT_UNITASK
            await motion.BindToLocalScale(target).ToUniTask(cancellationToken: cancellationToken);
#else
            await MainThreadDispatcher.Instance.RunCoroutineAsTask(motion.BindToLocalScale(target).ToYieldInteraction());
#endif
        }
    }
}
#endif
