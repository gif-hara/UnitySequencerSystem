#if USS_SUPPORT_LIT_MOTION
using System;
using LitMotion;
using LitMotion.Adapters;
using LitMotion.Extensions;
using UnityEngine;
using UnitySequencerSystem.Resolvers;

namespace UnitySequencerSystem.LitMotion
{
    public class BindToFloat
    {
        public interface IBindTo : IBindTo<float, NoOptions, FloatMotionAdapter>
        {
        }

        [Serializable]
        public abstract class BindToTransformFloat : IBindTo
        {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
            [SubclassSelector]
#endif
            [SerializeReference]
            protected TransformResolver targetResolver;

            public abstract MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container);
        }

        [Serializable]
        public abstract class BindToRectTransformFloat : IBindTo
        {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
            [SubclassSelector]
#endif
            [SerializeReference]
            protected RectTransformResolver targetResolver;

            public abstract MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container);
        }

        [Serializable]
        public abstract class BindToCanvasGroupFloat : IBindTo
        {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
            [SubclassSelector]
#endif
            [SerializeReference]
            protected CanvasGroupResolver targetResolver;

            public abstract MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container);
        }

        [Serializable]
        public abstract class BindToAudioMixerFloat : IBindTo
        {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
            [SubclassSelector]
#endif
            [SerializeReference]
            protected AudioMixerResolver targetResolver;

            public abstract MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container);
        }

        [Serializable]
        public abstract class BindToMaterialFloat : IBindTo
        {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
            [SubclassSelector]
#endif
            [SerializeReference]
            protected MaterialResolver targetResolver;

            public abstract MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container);
        }

        [Serializable]
        public sealed class TransformEulerAnglesX : BindToTransformFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToEulerAnglesX(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformEulerAnglesY : BindToTransformFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToEulerAnglesY(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformEulerAnglesZ : BindToTransformFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToEulerAnglesZ(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformLocalEulerAnglesX : BindToTransformFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalEulerAnglesX(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformLocalEulerAnglesY : BindToTransformFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalEulerAnglesY(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformLocalEulerAnglesZ : BindToTransformFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalEulerAnglesZ(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformLocalPositionX : BindToTransformFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalPositionX(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformLocalPositionY : BindToTransformFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalPositionY(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformLocalPositionZ : BindToTransformFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalPositionZ(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformLocalScaleX : BindToTransformFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalScaleX(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformLocalScaleY : BindToTransformFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalScaleY(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformLocalScaleZ : BindToTransformFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalScaleZ(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformPositionX : BindToTransformFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToPositionX(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformPositionY : BindToTransformFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToPositionY(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformPositionZ : BindToTransformFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToPositionZ(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformAnchoredPosition3DX : BindToRectTransformFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToAnchoredPosition3DX(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformAnchoredPosition3DY : BindToRectTransformFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToAnchoredPosition3DY(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformAnchoredPosition3DZ : BindToRectTransformFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToAnchoredPosition3DZ(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformAnchoredPositionX : BindToRectTransformFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToAnchoredPositionX(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformAnchoredPositionY : BindToRectTransformFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToAnchoredPositionY(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformEulerAnglesX : BindToRectTransformFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToEulerAnglesX(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformEulerAnglesY : BindToRectTransformFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToEulerAnglesY(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformEulerAnglesZ : BindToRectTransformFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToEulerAnglesZ(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformLocalEulerAnglesX : BindToRectTransformFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalEulerAnglesX(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformLocalEulerAnglesY : BindToRectTransformFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalEulerAnglesY(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformLocalEulerAnglesZ : BindToRectTransformFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalEulerAnglesZ(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformLocalPositionX : BindToRectTransformFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalPositionX(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformLocalPositionY : BindToRectTransformFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalPositionY(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformLocalPositionZ : BindToRectTransformFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalPositionZ(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformLocalScaleX : BindToRectTransformFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalScaleX(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformLocalScaleY : BindToRectTransformFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalScaleY(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformLocalScaleZ : BindToRectTransformFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalScaleZ(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformPositionX : BindToRectTransformFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToPositionX(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformPositionY : BindToRectTransformFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToPositionY(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformPositionZ : BindToRectTransformFloat
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

        [Serializable]
        public sealed class BindToAudioMixerValue : BindToAudioMixerFloat
        {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
            [SubclassSelector]
#endif
            [SerializeReference]
            private StringResolver nameResolver;

            public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToAudioMixerFloat(targetResolver.Resolve(container), nameResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class BindToMaterialValue : BindToMaterialFloat
        {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
            [SubclassSelector]
#endif
            [SerializeReference]
            private StringResolver nameResolver;

            public override MotionHandle BindTo(MotionBuilder<float, NoOptions, FloatMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToMaterialFloat(targetResolver.Resolve(container), nameResolver.Resolve(container));
            }
        }
    }
}
#endif
