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
    /// <see cref="Transform"/>の状態を<see cref="LitMotion"/>で設定するシーケンス
    /// </summary>
    [AddTypeMenu("LitMotion/Bind To Transform")]
    [Serializable]
    public sealed class LitMotionBindToTransform : ISequence
    {
#if USS_SUB_CLASS_SELECTOR_SUPPORT
        [SubclassSelector]
#endif
        [SerializeReference]
        private TransformResolver targetResolver;
        
        [SerializeField]
        private ParameterType parameterType;
        
        [SerializeField]
        private CoordinateType coordinateType;

        [SerializeField]
        private Ease ease;
        
#if USS_SUB_CLASS_SELECTOR_SUPPORT
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver fromResolver;
        
#if USS_SUB_CLASS_SELECTOR_SUPPORT
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver toResolver;
        
#if USS_SUB_CLASS_SELECTOR_SUPPORT
        [SubclassSelector]
#endif
        [SerializeReference]
        private FloatResolver durationResolver;

#if USS_SUB_CLASS_SELECTOR_SUPPORT
        [SubclassSelector]
#endif
        [SerializeReference]
        private FloatResolver delayResolver;
        
#if USS_SUB_CLASS_SELECTOR_SUPPORT
        [SubclassSelector]
#endif
        [SerializeReference]
        private IntResolver loopCountResolver;
        
#if USS_SUB_CLASS_SELECTOR_SUPPORT
        [SubclassSelector]
#endif
        [SerializeReference]
        private MotionSchedulerResolver motionSchedulerResolver;
        
        public enum ParameterType
        {
            Position,
            Rotation,
            Scale,
        }
        
        public enum CoordinateType
        {
            World,
            Local,
        }

        public LitMotionBindToTransform()
        {
        }

        public LitMotionBindToTransform(
            TransformResolver targetResolver,
            ParameterType parameterType,
            Vector3Resolver fromResolver,
            Vector3Resolver toResolver,
            FloatResolver durationResolver,
            FloatResolver delayResolver,
            IntResolver loopCountResolver,
            MotionSchedulerResolver motionSchedulerResolver,
            Ease ease,
            CoordinateType coordinateType
            )
        {
            this.targetResolver = targetResolver;
            this.parameterType = parameterType;
            this.fromResolver = fromResolver;
            this.toResolver = toResolver;
            this.durationResolver = durationResolver;
            this.delayResolver = delayResolver;
            this.loopCountResolver = loopCountResolver;
            this.motionSchedulerResolver = motionSchedulerResolver;
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
            switch (parameterType, coordinateType)
            {
                case (ParameterType.Position, CoordinateType.World):
                    await motion.BindToPosition(target);
                    break;
                case (ParameterType.Position, CoordinateType.Local):
                    await motion.BindToLocalPosition(target);
                    break;
                case (ParameterType.Rotation, CoordinateType.World):
                    await motion.BindToEulerAngles(target);
                    break;
                case (ParameterType.Rotation, CoordinateType.Local):
                    await motion.BindToLocalEulerAngles(target);
                    break;
                case (ParameterType.Scale, CoordinateType.World):
                    throw new ArgumentException("Scale is not supported in world coordinate");
                case (ParameterType.Scale, CoordinateType.Local):
                    await motion.BindToLocalScale(target);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
#endif
