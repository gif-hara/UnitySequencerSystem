#if USS_SUPPORT_LIT_MOTION
using System;
using LitMotion;
using LitMotion.Adapters;
using LitMotion.Extensions;
using UnityEngine;
using UnitySequencerSystem.Resolvers;

namespace UnitySequencerSystem.LitMotion
{
    public class BindToShake
    {
        public interface IBindToFloatShake : IBindTo<float, ShakeOptions, FloatShakeMotionAdapter>
        {
        }

        [Serializable]
        public abstract class TransformShakeFloat : IBindToFloatShake
        {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
            [SubclassSelector]
#endif
            [SerializeReference]
            protected TransformResolver targetResolver;

            public abstract MotionHandle BindTo(MotionBuilder<float, ShakeOptions, FloatShakeMotionAdapter> motionBuilder, Container container);
        }

        [Serializable]
        public sealed class TransformEulerAnglesX : TransformShakeFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, ShakeOptions, FloatShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToEulerAnglesX(targetResolver.Resolve(container));
            }
        }
    }
}
#endif
