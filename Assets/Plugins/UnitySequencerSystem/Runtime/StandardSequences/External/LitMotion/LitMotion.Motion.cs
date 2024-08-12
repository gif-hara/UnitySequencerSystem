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
            var motionHandler = bindTo.Bind(motionBuilder, container);
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
    public sealed class MotionVector3 : Motion<Vector3Parameters, Vector3Resolver, Vector3, NoOptions, Vector3MotionAdapter, IBindToVector3, IAddTo>
    {
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("LitMotion/Motion Vector2")]
#endif
    [Serializable]
    public sealed class MotionVector2 : Motion<Vector2Parameters, Vector2Resolver, Vector2, NoOptions, Vector2MotionAdapter, IBindToVector2, IAddTo>
    {
    }
}
#endif
