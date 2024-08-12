#if USS_SUPPORT_LIT_MOTION
using System;
using LitMotion;
using LitMotion.Adapters;
using LitMotion.Extensions;
using UnityEngine;
using UnitySequencerSystem.Resolvers;

namespace UnitySequencerSystem.LitMotion
{
    [Serializable]
    public abstract class BindToRectTransformVector3 : IBindToVector3
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        protected RectTransformResolver targetResolver;

        public abstract MotionHandle Bind(MotionBuilder<Vector3, NoOptions, Vector3MotionAdapter> motionBuilder, Container container);
    }

    [Serializable]
    public abstract class BindToRectTransformVector2 : IBindToVector2
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        protected RectTransformResolver targetResolver;

        public abstract MotionHandle Bind(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container);
    }

    [Serializable]
    public sealed class BindToRectTransformPosition3D : BindToRectTransformVector3
    {
        public override MotionHandle Bind(MotionBuilder<Vector3, NoOptions, Vector3MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToAnchoredPosition3D(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformAnchoredPosition : BindToRectTransformVector2
    {
        public override MotionHandle Bind(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToAnchoredPosition(targetResolver.Resolve(container));
        }
    }
}
#endif
