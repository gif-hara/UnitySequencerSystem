#if USS_SUPPORT_LIT_MOTION
using System;
using LitMotion;
using LitMotion.Adapters;
using LitMotion.Extensions;
using UnityEngine;
using UnitySequencerSystem.Resolvers;

namespace UnitySequencerSystem.LitMotion
{
    public class BindToVector3Shake
    {
        public interface IBindTo : IBindTo<Vector3, ShakeOptions, Vector3ShakeMotionAdapter>
        {
        }

        [Serializable]
        public abstract class BindToTransformVector3Shake : IBindTo
        {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
            [SubclassSelector]
#endif
            [SerializeReference]
            protected TransformResolver targetResolver;

            public abstract MotionHandle BindTo(MotionBuilder<Vector3, ShakeOptions, Vector3ShakeMotionAdapter> motionBuilder, Container container);
        }

        [Serializable]
        public abstract class BindToRectTransformVector3Shake : IBindTo
        {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
            [SubclassSelector]
#endif
            [SerializeReference]
            protected RectTransformResolver targetResolver;

            public abstract MotionHandle BindTo(MotionBuilder<Vector3, ShakeOptions, Vector3ShakeMotionAdapter> motionBuilder, Container container);
        }

        [Serializable]
        public sealed class TransformEulerAngles : BindToTransformVector3Shake
        {
            public override MotionHandle BindTo(MotionBuilder<Vector3, ShakeOptions, Vector3ShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToEulerAngles(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformLocalEulerAngles : BindToTransformVector3Shake
        {
            public override MotionHandle BindTo(MotionBuilder<Vector3, ShakeOptions, Vector3ShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalEulerAngles(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformLocalPosition : BindToTransformVector3Shake
        {
            public override MotionHandle BindTo(MotionBuilder<Vector3, ShakeOptions, Vector3ShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalPosition(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformLocalScale : BindToTransformVector3Shake
        {
            public override MotionHandle BindTo(MotionBuilder<Vector3, ShakeOptions, Vector3ShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalScale(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformPosition : BindToTransformVector3Shake
        {
            public override MotionHandle BindTo(MotionBuilder<Vector3, ShakeOptions, Vector3ShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToPosition(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformAnchoredPosition3D : BindToRectTransformVector3Shake
        {
            public override MotionHandle BindTo(MotionBuilder<Vector3, ShakeOptions, Vector3ShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToAnchoredPosition3D(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformEulerAngles : BindToRectTransformVector3Shake
        {
            public override MotionHandle BindTo(MotionBuilder<Vector3, ShakeOptions, Vector3ShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToEulerAngles(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformLocalEulerAngles : BindToRectTransformVector3Shake
        {
            public override MotionHandle BindTo(MotionBuilder<Vector3, ShakeOptions, Vector3ShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalEulerAngles(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformLocalPosition : BindToRectTransformVector3Shake
        {
            public override MotionHandle BindTo(MotionBuilder<Vector3, ShakeOptions, Vector3ShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalPosition(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformLocalScale : BindToRectTransformVector3Shake
        {
            public override MotionHandle BindTo(MotionBuilder<Vector3, ShakeOptions, Vector3ShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalScale(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformPosition : BindToRectTransformVector3Shake
        {
            public override MotionHandle BindTo(MotionBuilder<Vector3, ShakeOptions, Vector3ShakeMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToPosition(targetResolver.Resolve(container));
            }
        }
    }
}
#endif
