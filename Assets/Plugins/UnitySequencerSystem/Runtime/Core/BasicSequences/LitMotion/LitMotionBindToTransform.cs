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
        
        [SerializeReference, SubclassSelector]
        private TransformResolver targetResolver;
        
        [SerializeField]
        private ParameterType parameterType;

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
