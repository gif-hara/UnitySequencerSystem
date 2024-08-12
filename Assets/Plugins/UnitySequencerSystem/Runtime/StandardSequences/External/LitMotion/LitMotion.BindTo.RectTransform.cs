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
    public abstract class BindToRectTransformVector2 : IBindToVector2
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        protected RectTransformResolver targetResolver;

        public abstract MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container);
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
    public abstract class BindToRectTransformFloat : IBindToFloat
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        protected RectTransformResolver targetResolver;

        public abstract MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container);
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
    public sealed class BindToRectTransformAnchoredPosition : BindToRectTransformVector2
    {
        public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToAnchoredPosition(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformAnchorMax : BindToRectTransformVector2
    {
        public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToAnchorMax(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformAnchorMin : BindToRectTransformVector2
    {
        public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToAnchorMin(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformEulerAnglesXY : BindToRectTransformVector2
    {
        public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToEulerAnglesXY(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformEulerAnglesXZ : BindToRectTransformVector2
    {
        public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToEulerAnglesXZ(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformEulerAnglesYZ : BindToRectTransformVector2
    {
        public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToEulerAnglesYZ(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformLocalEulerAnglesXY : BindToRectTransformVector2
    {
        public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalEulerAnglesXY(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformLocalEulerAnglesXZ : BindToRectTransformVector2
    {
        public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalEulerAnglesXZ(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformLocalEulerAnglesYZ : BindToRectTransformVector2
    {
        public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalEulerAnglesYZ(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformLocalPositionXY : BindToRectTransformVector2
    {
        public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalPositionXY(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformLocalPositionXZ : BindToRectTransformVector2
    {
        public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalPositionXZ(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformLocalPositionYZ : BindToRectTransformVector2
    {
        public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalPositionYZ(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformLocalScaleXY : BindToRectTransformVector2
    {
        public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalScaleXY(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformLocalScaleXZ : BindToRectTransformVector2
    {
        public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalScaleXZ(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformLocalScaleYZ : BindToRectTransformVector2
    {
        public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalScaleYZ(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformPivot : BindToRectTransformVector2
    {
        public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToPivot(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformPositionXY : BindToRectTransformVector2
    {
        public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToPositionXY(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformPositionXZ : BindToRectTransformVector2
    {
        public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToPositionXZ(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformPositionYZ : BindToRectTransformVector2
    {
        public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToPositionYZ(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformSizeDelta : BindToRectTransformVector2
    {
        public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToSizeDelta(targetResolver.Resolve(container));
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

    [Serializable]
    public sealed class BindToRectTransformEulerAnglesX : BindToRectTransformFloat
    {
        public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToEulerAnglesX(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformEulerAnglesY : BindToRectTransformFloat
    {
        public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToEulerAnglesY(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformEulerAnglesZ : BindToRectTransformFloat
    {
        public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToEulerAnglesZ(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformLocalEulerAnglesX : BindToRectTransformFloat
    {
        public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalEulerAnglesX(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformLocalEulerAnglesY : BindToRectTransformFloat
    {
        public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalEulerAnglesY(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformLocalEulerAnglesZ : BindToRectTransformFloat
    {
        public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalEulerAnglesZ(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformLocalPositionX : BindToRectTransformFloat
    {
        public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalPositionX(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformLocalPositionY : BindToRectTransformFloat
    {
        public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalPositionY(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformLocalPositionZ : BindToRectTransformFloat
    {
        public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalPositionZ(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformLocalScaleX : BindToRectTransformFloat
    {
        public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalScaleX(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformLocalScaleY : BindToRectTransformFloat
    {
        public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalScaleY(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformLocalScaleZ : BindToRectTransformFloat
    {
        public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalScaleZ(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformPositionX : BindToRectTransformFloat
    {
        public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToPositionX(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformPositionY : BindToRectTransformFloat
    {
        public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToPositionY(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformPositionZ : BindToRectTransformFloat
    {
        public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToPositionZ(targetResolver.Resolve(container));
        }
    }
}
#endif
