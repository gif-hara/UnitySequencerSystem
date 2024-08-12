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
        private AnimationCurve customAnimationCurve;

        public MotionBuilder<TValue, TOptions, TAdapter> Build(Container container)
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
    }
}
#endif
