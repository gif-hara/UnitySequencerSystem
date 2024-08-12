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

        public abstract MotionHandle BindTo(MotionBuilder<Vector3, NoOptions, Vector3MotionAdapter> motionBuilder, Container container);
    }

    [Serializable]
    public abstract class BindToRectTransformQuaternion : IBindToQuaternion
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        protected RectTransformResolver targetResolver;

        public abstract MotionHandle BindTo(MotionBuilder<Quaternion, NoOptions, QuaternionMotionAdapter> motionBuilder, Container container);
    }

    [Serializable]
    public sealed class BindToRectTransformAnchoredPosition3D : BindToRectTransformVector3
    {
        public override MotionHandle BindTo(MotionBuilder<Vector3, NoOptions, Vector3MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToAnchoredPosition3D(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformEulerAngles : BindToRectTransformVector3
    {
        public override MotionHandle BindTo(MotionBuilder<Vector3, NoOptions, Vector3MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToEulerAngles(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformLocalEulerAngles : BindToRectTransformVector3
    {
        public override MotionHandle BindTo(MotionBuilder<Vector3, NoOptions, Vector3MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalEulerAngles(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformLocalPosition : BindToRectTransformVector3
    {
        public override MotionHandle BindTo(MotionBuilder<Vector3, NoOptions, Vector3MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalPosition(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformLocalScale : BindToRectTransformVector3
    {
        public override MotionHandle BindTo(MotionBuilder<Vector3, NoOptions, Vector3MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalScale(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformPosition : BindToRectTransformVector3
    {
        public override MotionHandle BindTo(MotionBuilder<Vector3, NoOptions, Vector3MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToPosition(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformLocalRotation : BindToRectTransformQuaternion
    {
        public override MotionHandle BindTo(MotionBuilder<Quaternion, NoOptions, QuaternionMotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalRotation(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformRotation : BindToRectTransformQuaternion
    {
        public override MotionHandle BindTo(MotionBuilder<Quaternion, NoOptions, QuaternionMotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToRotation(targetResolver.Resolve(container));
        }
    }
}
#endif
