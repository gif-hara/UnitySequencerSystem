#if USS_SUPPORT_LIT_MOTION
using System;
using LitMotion;
using LitMotion.Adapters;
using UnityEngine;
using UnitySequencerSystem.Resolvers;
using UnitySequencerSystem.Resolvers.LitMotion;

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
        protected TValueResolver fromResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        protected TValueResolver toResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        protected FloatResolver durationResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        protected FloatResolver delayResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        protected IntResolver loopCountResolver;

        [SerializeField]
        protected LoopType loopType;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        protected MotionSchedulerResolver motionSchedulerResolver;

        [SerializeField]
        protected Ease ease;

        [SerializeField]
        protected AnimationCurve customAnimationCurve;

        public virtual MotionBuilder<TValue, TOptions, TAdapter> Build(Container container)
        {
            var result = LMotion.Create<TValue, TOptions, TAdapter>(
                fromResolver.Resolve(container),
                toResolver.Resolve(container),
                durationResolver.Resolve(container)
                );
            if (ease == Ease.CustomAnimationCurve)
            {
                result = result.WithEase(customAnimationCurve);
            }
            else
            {
                result = result.WithEase(ease);
            }
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
    public sealed class Vector2Parameters : Parameters<Vector2Resolver, Vector2, NoOptions, Vector2MotionAdapter>
    {
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
    public sealed class FloatShakeParameters : Parameters<FloatResolver, float, ShakeOptions, FloatShakeMotionAdapter>
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private IntResolver frequencyResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private FloatResolver dampingResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private RandomSeedResolver randomSeedResolver;

        public override MotionBuilder<float, ShakeOptions, FloatShakeMotionAdapter> Build(Container container)
        {
            var result = LMotion.Shake.Create(
                fromResolver.Resolve(container),
                toResolver.Resolve(container),
                durationResolver.Resolve(container)
            );
            if (ease == Ease.CustomAnimationCurve)
            {
                result = result.WithEase(customAnimationCurve);
            }
            else
            {
                result = result.WithEase(ease);
            }
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
            if (frequencyResolver != null)
            {
                result = result.WithFrequency(frequencyResolver.Resolve(container));
            }
            if (dampingResolver != null)
            {
                result = result.WithDampingRatio(dampingResolver.Resolve(container));
            }
            if (randomSeedResolver != null)
            {
                result = result.WithRandomSeed(randomSeedResolver.Resolve(container));
            }
            return result;
        }
    }
}
#endif
