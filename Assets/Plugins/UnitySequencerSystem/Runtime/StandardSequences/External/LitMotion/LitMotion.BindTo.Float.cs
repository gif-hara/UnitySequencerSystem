#if USS_SUPPORT_LIT_MOTION
using System;
using LitMotion;
using LitMotion.Adapters;
using LitMotion.Extensions;
using UnityEngine;
using UnitySequencerSystem.Resolvers;

namespace UnitySequencerSystem.LitMotion
{
    public interface IBindToFloat : IBindTo<float, NoOptions, FloatMotionAdapter>
    {
    }

    [Serializable]
    public abstract class BindToTransformFloat : IBindToFloat
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        protected TransformResolver targetResolver;

        public abstract MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container);
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
    public abstract class BindToCanvasGroupFloat : IBindToFloat
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        protected CanvasGroupResolver targetResolver;

        public abstract MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container);
    }

    [Serializable]
    public sealed class BindToTransformEulerAnglesX : BindToTransformFloat
    {
        public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToEulerAnglesX(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToTransformEulerAnglesY : BindToTransformFloat
    {
        public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToEulerAnglesY(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToTransformEulerAnglesZ : BindToTransformFloat
    {
        public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToEulerAnglesZ(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToTransformLocalEulerAnglesX : BindToTransformFloat
    {
        public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalEulerAnglesX(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToTransformLocalEulerAnglesY : BindToTransformFloat
    {
        public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalEulerAnglesY(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToTransformLocalEulerAnglesZ : BindToTransformFloat
    {
        public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalEulerAnglesZ(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToTransformLocalPositionX : BindToTransformFloat
    {
        public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalPositionX(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToTransformLocalPositionY : BindToTransformFloat
    {
        public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalPositionY(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToTransformLocalPositionZ : BindToTransformFloat
    {
        public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalPositionZ(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToTransformLocalScaleX : BindToTransformFloat
    {
        public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalScaleX(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToTransformLocalScaleY : BindToTransformFloat
    {
        public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalScaleY(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToTransformLocalScaleZ : BindToTransformFloat
    {
        public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToLocalScaleZ(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToTransformPositionX : BindToTransformFloat
    {
        public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToPositionX(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToTransformPositionY : BindToTransformFloat
    {
        public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToPositionY(targetResolver.Resolve(container));
        }
    }

    [Serializable]
    public sealed class BindToTransformPositionZ : BindToTransformFloat
    {
        public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToPositionZ(targetResolver.Resolve(container));
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

    [Serializable]
    public sealed class BindToCanvasGroupAlpha : BindToCanvasGroupFloat
    {
        public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
        {
            return motionBuilder.BindToCanvasGroupAlpha(targetResolver.Resolve(container));
        }
    }
}
#endif
