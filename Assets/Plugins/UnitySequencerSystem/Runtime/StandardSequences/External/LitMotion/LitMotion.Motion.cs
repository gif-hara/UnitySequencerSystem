#if USS_SUPPORT_LIT_MOTION
using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using LitMotion;
using LitMotion.Adapters;
using UnityEngine;
using UnitySequencerSystem.Resolvers;

namespace UnitySequencerSystem.LitMotion
{
    [Serializable]
    public abstract class Motion<TParameters, TValueResolver, TValue, TOptions, TAdapter, TBindable, TAddTo> : Sequence
        where TParameters : Parameters<TValueResolver, TValue, TOptions, TAdapter>
        where TValueResolver : IResolver<TValue>
        where TValue : unmanaged
        where TOptions : unmanaged, IMotionOptions
        where TAdapter : unmanaged, IMotionAdapter<TValue, TOptions>
        where TBindable : IBindTo<TValue, TOptions, TAdapter>
        where TAddTo : IAddTo
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private TParameters parameters;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private TBindable bindTo;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private TAddTo addTo;

        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
        {
            var motionBuilder = parameters.Build(container);
            var motionHandler = bindTo.BindTo(motionBuilder, container);
            if (addTo != null)
            {
                motionHandler = addTo.AddTo(motionHandler, container);
            }
            return motionHandler
                .ToUniTask(cancellationToken: cancellationToken);
        }
    }


#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("LitMotion/Motion Vector3")]
#endif
    [Serializable]
    public sealed class MotionVector3 : Motion<Vector3Parameters, Vector3Resolver, Vector3, NoOptions, Vector3MotionAdapter, BindToVector3.IBindTo, IAddTo>
    {
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("LitMotion/Motion Vector2")]
#endif
    [Serializable]
    public sealed class MotionVector2 : Motion<Vector2Parameters, Vector2Resolver, Vector2, NoOptions, Vector2MotionAdapter, BindToVector2.IBindTo, IAddTo>
    {
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("LitMotion/Motion Quaternion")]
#endif
    [Serializable]
    public sealed class MotionQuaternion : Motion<QuaternionParameters, QuaternionResolver, Quaternion, NoOptions, QuaternionMotionAdapter, BindToQuaternion.IBindTo, IAddTo>
    {
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("LitMotion/Motion Float")]
#endif
    [Serializable]
    public sealed class MotionFloat : Motion<FloatParameters, FloatResolver, float, NoOptions, FloatMotionAdapter, BindToFloat.IBindTo, IAddTo>
    {
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("LitMotion/Motion Float Shake")]
#endif
    [Serializable]
    public sealed class MotionFloatShake : Motion<FloatShakeParameters, FloatResolver, float, ShakeOptions, FloatShakeMotionAdapter, BindToFloatShake.IBindTo, IAddTo>
    {
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("LitMotion/Motion Vector2 Shake")]
#endif
    [Serializable]
    public sealed class MotionVector2Shake : Motion<Vector2ShakeParameters, Vector2Resolver, Vector2, ShakeOptions, Vector2ShakeMotionAdapter, BindToVector2Shake.IBindTo, IAddTo>
    {
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("LitMotion/Motion Vector3 Shake")]
#endif
    [Serializable]
    public sealed class MotionVector3Shake : Motion<Vector3ShakeParameters, Vector3Resolver, Vector3, ShakeOptions, Vector3ShakeMotionAdapter, BindToVector3Shake.IBindTo, IAddTo>
    {
    }
}
#endif
