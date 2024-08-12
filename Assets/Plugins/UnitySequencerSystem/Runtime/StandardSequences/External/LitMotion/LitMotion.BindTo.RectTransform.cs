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
    public abstract class BindToRectTransformQuaternion : IBindToQuaternion
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        protected RectTransformResolver targetResolver;

        public abstract MotionHandle Bind(MotionBuilder<Quaternion, NoOptions, QuaternionMotionAdapter> motionBuilder, Container container);
    }

    [Serializable]
    public sealed class BindToRectTransformAnchoredPosition3D : BindToRectTransformVector3
    {
        public override MotionHandle Bind(MotionBuilder<Vector3, NoOptions, Vector3MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToAnchoredPosition3D(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformEulerAngles : BindToRectTransformVector3
    {
        public override MotionHandle Bind(MotionBuilder<Vector3, NoOptions, Vector3MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToEulerAngles(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformLocalEulerAngles : BindToRectTransformVector3
    {
        public override MotionHandle Bind(MotionBuilder<Vector3, NoOptions, Vector3MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalEulerAngles(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformLocalPosition : BindToRectTransformVector3
    {
        public override MotionHandle Bind(MotionBuilder<Vector3, NoOptions, Vector3MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalPosition(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformLocalScale : BindToRectTransformVector3
    {
        public override MotionHandle Bind(MotionBuilder<Vector3, NoOptions, Vector3MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalScale(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformPosition : BindToRectTransformVector3
    {
        public override MotionHandle Bind(MotionBuilder<Vector3, NoOptions, Vector3MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToPosition(targetResolver.Resolve(container));
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

    [Serializable]
    public sealed class BindToRectTransformAnchorMax : BindToRectTransformVector2
    {
        public override MotionHandle Bind(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToAnchorMax(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformAnchorMin : BindToRectTransformVector2
    {
        public override MotionHandle Bind(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToAnchorMin(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformEulerAnglesXY : BindToRectTransformVector2
    {
        public override MotionHandle Bind(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToEulerAnglesXY(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformEulerAnglesXZ : BindToRectTransformVector2
    {
        public override MotionHandle Bind(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToEulerAnglesXZ(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformEulerAnglesYZ : BindToRectTransformVector2
    {
        public override MotionHandle Bind(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToEulerAnglesYZ(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformLocalEulerAnglesXY : BindToRectTransformVector2
    {
        public override MotionHandle Bind(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalEulerAnglesXY(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformLocalEulerAnglesXZ : BindToRectTransformVector2
    {
        public override MotionHandle Bind(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalEulerAnglesXZ(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformLocalEulerAnglesYZ : BindToRectTransformVector2
    {
        public override MotionHandle Bind(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalEulerAnglesYZ(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformLocalPositionXY : BindToRectTransformVector2
    {
        public override MotionHandle Bind(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalPositionXY(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformLocalPositionXZ : BindToRectTransformVector2
    {
        public override MotionHandle Bind(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalPositionXZ(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformLocalPositionYZ : BindToRectTransformVector2
    {
        public override MotionHandle Bind(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalPositionYZ(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformLocalScaleXY : BindToRectTransformVector2
    {
        public override MotionHandle Bind(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalScaleXY(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformLocalScaleXZ : BindToRectTransformVector2
    {
        public override MotionHandle Bind(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalScaleXZ(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformLocalScaleYZ : BindToRectTransformVector2
    {
        public override MotionHandle Bind(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalScaleYZ(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformPivot : BindToRectTransformVector2
    {
        public override MotionHandle Bind(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToPivot(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformPositionXY : BindToRectTransformVector2
    {
        public override MotionHandle Bind(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToPositionXY(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformPositionXZ : BindToRectTransformVector2
    {
        public override MotionHandle Bind(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToPositionXZ(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformPositionYZ : BindToRectTransformVector2
    {
        public override MotionHandle Bind(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToPositionYZ(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformSizeDelta : BindToRectTransformVector2
    {
        public override MotionHandle Bind(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToSizeDelta(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformLocalRotation : BindToRectTransformQuaternion
    {
        public override MotionHandle Bind(MotionBuilder<Quaternion, NoOptions, QuaternionMotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalRotation(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToRectTransformRotation : BindToRectTransformQuaternion
    {
        public override MotionHandle Bind(MotionBuilder<Quaternion, NoOptions, QuaternionMotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToRotation(targetResolver.Resolve(container));
        }
    }
}
#endif
