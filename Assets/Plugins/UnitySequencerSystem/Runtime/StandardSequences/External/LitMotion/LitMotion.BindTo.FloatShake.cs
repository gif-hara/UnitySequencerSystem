#if USS_SUPPORT_LIT_MOTION
using System;
using LitMotion;
using LitMotion.Adapters;
using LitMotion.Extensions;
using UnityEngine;
using UnitySequencerSystem.Resolvers;

namespace UnitySequencerSystem.LitMotion
{
    public class BindToFloatShake
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
        public abstract class RectTransformShakeFloat : IBindToFloatShake
        {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
            [SubclassSelector]
#endif
            [SerializeReference]
            protected RectTransformResolver targetResolver;

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

        [Serializable]
        public sealed class TransformEulerAnglesY : TransformShakeFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, ShakeOptions, FloatShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToEulerAnglesY(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformEulerAnglesZ : TransformShakeFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, ShakeOptions, FloatShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToEulerAnglesZ(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformLocalEulerAnglesX : TransformShakeFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, ShakeOptions, FloatShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalEulerAnglesX(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformLocalEulerAnglesY : TransformShakeFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, ShakeOptions, FloatShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalEulerAnglesY(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformLocalEulerAnglesZ : TransformShakeFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, ShakeOptions, FloatShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalEulerAnglesZ(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformLocalPositionX : TransformShakeFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, ShakeOptions, FloatShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalPositionX(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformLocalPositionY : TransformShakeFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, ShakeOptions, FloatShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalPositionY(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformLocalPositionZ : TransformShakeFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, ShakeOptions, FloatShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalPositionZ(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformLocalScaleX : TransformShakeFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, ShakeOptions, FloatShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalScaleX(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformLocalScaleY : TransformShakeFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, ShakeOptions, FloatShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalScaleY(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformLocalScaleZ : TransformShakeFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, ShakeOptions, FloatShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalScaleZ(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformPositionX : TransformShakeFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, ShakeOptions, FloatShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToPositionX(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformPositionY : TransformShakeFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, ShakeOptions, FloatShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToPositionY(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformPositionZ : TransformShakeFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, ShakeOptions, FloatShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToPositionZ(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformAnchoredPosition3DX : RectTransformShakeFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, ShakeOptions, FloatShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToAnchoredPosition3DX(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformAnchoredPosition3DY : RectTransformShakeFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, ShakeOptions, FloatShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToAnchoredPosition3DY(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformAnchoredPosition3DZ : RectTransformShakeFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, ShakeOptions, FloatShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToAnchoredPosition3DZ(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformAnchoredPositionX : RectTransformShakeFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, ShakeOptions, FloatShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToAnchoredPositionX(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformAnchoredPositionY : RectTransformShakeFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, ShakeOptions, FloatShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToAnchoredPositionY(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformEulerAnglesX : RectTransformShakeFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, ShakeOptions, FloatShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToEulerAnglesX(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformEulerAnglesY : RectTransformShakeFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, ShakeOptions, FloatShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToEulerAnglesY(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformEulerAnglesZ : RectTransformShakeFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, ShakeOptions, FloatShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToEulerAnglesZ(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformLocalEulerAnglesX : RectTransformShakeFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, ShakeOptions, FloatShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalEulerAnglesX(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformLocalEulerAnglesY : RectTransformShakeFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, ShakeOptions, FloatShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalEulerAnglesY(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformLocalEulerAnglesZ : RectTransformShakeFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, ShakeOptions, FloatShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalEulerAnglesZ(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformLocalPositionX : RectTransformShakeFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, ShakeOptions, FloatShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalPositionX(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformLocalPositionY : RectTransformShakeFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, ShakeOptions, FloatShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalPositionY(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformLocalPositionZ : RectTransformShakeFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, ShakeOptions, FloatShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalPositionZ(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformLocalScaleX : RectTransformShakeFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, ShakeOptions, FloatShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalScaleX(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformLocalScaleY : RectTransformShakeFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, ShakeOptions, FloatShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalScaleY(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformLocalScaleZ : RectTransformShakeFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, ShakeOptions, FloatShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalScaleZ(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformPositionX : RectTransformShakeFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, ShakeOptions, FloatShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToPositionX(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformPositionY : RectTransformShakeFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, ShakeOptions, FloatShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToPositionY(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformPositionZ : RectTransformShakeFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, ShakeOptions, FloatShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToPositionZ(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformPivotX : RectTransformShakeFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, ShakeOptions, FloatShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToPivotX(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformPivotY : RectTransformShakeFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, ShakeOptions, FloatShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToPivotY(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformSizeDeltaX : RectTransformShakeFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, ShakeOptions, FloatShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToSizeDeltaX(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformSizeDeltaY : RectTransformShakeFloat
        {
            public override MotionHandle BindTo(MotionBuilder<float, ShakeOptions, FloatShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToSizeDeltaY(targetResolver.Resolve(container));
            }
        }
    }
}
#endif
