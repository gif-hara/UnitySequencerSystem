#if USS_SUPPORT_LIT_MOTION
using System;
using System.Threading;
using HK.UnitySequencerSystem.Resolvers;
using HK.UnitySequencerSystem.Resolvers.LitMotion;
using LitMotion;
using LitMotion.Extensions;
using UnityEngine;
using HK.UnitySequencerSystem.Core;

#if USS_SUPPORT_UNITASK
using Cysharp.Threading.Tasks;
#else
using System.Threading.Tasks;
#endif


namespace HK.UnitySequencerSystem.LitMotion
{
        /// <summary>
        /// <see cref="LitMotion"/>で<see cref="Transform"/>の座標を設定するシーケンス
        /// </summary>
        [AddTypeMenu("LitMotion/Bind To Position")]
        [Serializable]
        public sealed class LitMotionBindToPosition : ISequence
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

                public LitMotionBindToPosition()
                {
                }

                public LitMotionBindToPosition(
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
                        await MainThreadDispatcher.Instance.RunCoroutineAsTask(motion.BindToPosition(target).ToYieldInteraction());
                }
        }
}
#endif
