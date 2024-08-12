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
    }
}
#endif
