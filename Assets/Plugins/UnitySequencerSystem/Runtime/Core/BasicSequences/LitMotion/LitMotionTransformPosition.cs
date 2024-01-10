#if USS_LIT_MOTION_SUPPORT
using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using HK.UnitySequencerSystem.Resolvers;
using HK.UnitySequencerSystem.Resolvers.LitMotion;
using LitMotion;
using LitMotion.Extensions;
using UnityEngine;

namespace HK.UnitySequencerSystem.LitMotion
{
    /// <summary>
    /// <see cref="Transform"/>の座標をLitMotionで設定するシーケンス
    /// </summary>
    [AddTypeMenu("LitMotion/Transform Set Position")]
    [Serializable]
    public sealed class LitMotionTransformPosition : ISequence
    {
        [SerializeReference, SubclassSelector]
        private TransformResolver targetResolver;

        [SerializeReference, SubclassSelector]
        private Vector3Resolver fromResolver;
        
        [SubclassSelector]
        [SerializeReference]
        private Vector3Resolver toResolver;
        
        [SubclassSelector]
        [SerializeReference]
        private FloatResolver durationResolver;

        [SubclassSelector]
        [SerializeReference]
        private FloatResolver delayResolver;
        
        [SubclassSelector]
        [SerializeReference]
        private IntResolver loopCountResolver;
        
        [SubclassSelector]
        [SerializeReference]
        private MotionSchedulerResolver motionSchedulerResolver;

        [SerializeField]
        private Ease ease;

        [SerializeField]
        private CoordinateType coordinateType;

        public enum CoordinateType
        {
            World,
            Local,
        }

        public LitMotionTransformPosition()
        {
        }

        public LitMotionTransformPosition(
            TransformResolver targetResolver,
            Vector3Resolver fromResolver,
            Vector3Resolver toResolver,
            FloatResolver durationResolver,
            FloatResolver delayResolver,
            Ease ease,
            CoordinateType coordinateType
            )
        {
            this.targetResolver = targetResolver;
            this.fromResolver = fromResolver;
            this.toResolver = toResolver;
            this.durationResolver = durationResolver;
            this.delayResolver = delayResolver;
            this.ease = ease;
            this.coordinateType = coordinateType;
        }

        public async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
        {
            var target = this.targetResolver.Resolve(container);
            var motion = LMotion.Create(
                    fromResolver.Resolve(container),
                    toResolver.Resolve(container),
                    durationResolver.Resolve(container)
                    )
                .WithEase(ease);
            if(delayResolver != null)
            {
                motion = motion.WithDelay(delayResolver.Resolve(container));
            }
            if(loopCountResolver != null)
            {
                motion = motion.WithLoops(loopCountResolver.Resolve(container));
            }
            if(motionSchedulerResolver != null)
            {
                motion = motion.WithScheduler(motionSchedulerResolver.Resolve(container));
            }
            switch (coordinateType)
            {
                case CoordinateType.World:
                    await motion.BindToPosition(target);
                    break;
                case CoordinateType.Local:
                    await motion.BindToLocalPosition(target);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
#endif
