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
    public abstract class BindToTransformVector3 : IBindToVector3
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        protected TransformResolver targetResolver;

        public abstract MotionHandle BindTo(MotionBuilder<Vector3, NoOptions, Vector3MotionAdapter> motionBuilder, Container container);
    }

    [Serializable]
    public abstract class BindToTransformVector2 : IBindToVector2
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        protected TransformResolver targetResolver;

        public abstract MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container);
    }

    [Serializable]
    public abstract class BindToTransformQuaternion : IBindToQuaternion
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        protected TransformResolver targetResolver;

        public abstract MotionHandle BindTo(MotionBuilder<Quaternion, NoOptions, QuaternionMotionAdapter> motionBuilder, Container container);
    }

    [Serializable]
    public sealed class BindToTransformEulerAngles : BindToTransformVector3
    {
        public override MotionHandle BindTo(MotionBuilder<Vector3, NoOptions, Vector3MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToEulerAngles(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToTransformLocalEulerAngles : BindToTransformVector3
    {
        public override MotionHandle BindTo(MotionBuilder<Vector3, NoOptions, Vector3MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalEulerAngles(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToTransformLocalPosition : BindToTransformVector3
    {
        public override MotionHandle BindTo(MotionBuilder<Vector3, NoOptions, Vector3MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalPosition(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToTransformLocalScale : BindToTransformVector3
    {
        public override MotionHandle BindTo(MotionBuilder<Vector3, NoOptions, Vector3MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalScale(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToTransformPosition : BindToTransformVector3
    {
        public override MotionHandle BindTo(MotionBuilder<Vector3, NoOptions, Vector3MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToPosition(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToTransformEulerAngleXY : BindToTransformVector2
    {
        public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToEulerAnglesXY(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToTransformEulerAngleXZ : BindToTransformVector2
    {
        public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToEulerAnglesXZ(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToTransformEulerAngleYZ : BindToTransformVector2
    {
        public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToEulerAnglesYZ(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToTransformLocalEulerAnglesXY : BindToTransformVector2
    {
        public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalEulerAnglesXY(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToTransformLocalEulerAnglesXZ : BindToTransformVector2
    {
        public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalEulerAnglesXZ(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToTransformLocalEulerAnglesYZ : BindToTransformVector2
    {
        public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalEulerAnglesYZ(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToTransformLocalPositionXY : BindToTransformVector2
    {
        public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalPositionXY(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToTransformLocalPositionXZ : BindToTransformVector2
    {
        public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalPositionXZ(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToTransformLocalPositionYZ : BindToTransformVector2
    {
        public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalPositionYZ(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToTransformLocalScaleXY : BindToTransformVector2
    {
        public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalScaleXY(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToTransformLocalScaleXZ : BindToTransformVector2
    {
        public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalScaleXZ(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToTransformLocalScaleYZ : BindToTransformVector2
    {
        public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalScaleYZ(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToTransformPositionXY : BindToTransformVector2
    {
        public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToPositionXY(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToTransformPositionXZ : BindToTransformVector2
    {
        public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToPositionXZ(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToTransformPositionYZ : BindToTransformVector2
    {
        public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToPositionYZ(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToTransformLocalRotation : BindToTransformQuaternion
    {
        public override MotionHandle BindTo(MotionBuilder<Quaternion, NoOptions, QuaternionMotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalRotation(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToTransformRotation : BindToTransformQuaternion
    {
        public override MotionHandle BindTo(MotionBuilder<Quaternion, NoOptions, QuaternionMotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToRotation(targetResolver.Resolve(container));
        }
    }
}
#endif
