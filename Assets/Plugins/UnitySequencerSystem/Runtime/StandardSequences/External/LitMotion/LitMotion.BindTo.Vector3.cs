#if USS_SUPPORT_LIT_MOTION
using System;
using LitMotion;
using LitMotion.Adapters;
using LitMotion.Extensions;
using UnityEngine;
using UnitySequencerSystem.Resolvers;

namespace UnitySequencerSystem.LitMotion
{
    public class BindToVector3
    {
        public interface IBindTo : IBindTo<Vector3, NoOptions, Vector3MotionAdapter>
        {
        }

        [Serializable]
        public abstract class BindToTransformVector3 : IBindTo
        {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
            [SubclassSelector]
#endif
            [SerializeReference]
            protected TransformResolver targetResolver;

            public abstract MotionHandle BindTo(MotionBuilder<Vector3, NoOptions, Vector3MotionAdapter> motionBuilder, Container container);
        }

        [Serializable]
        public abstract class BindToRectTransformVector3 : IBindTo
        {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
            [SubclassSelector]
#endif
            [SerializeReference]
            protected RectTransformResolver targetResolver;

            public abstract MotionHandle BindTo(MotionBuilder<Vector3, NoOptions, Vector3MotionAdapter> motionBuilder, Container container);
        }

        [Serializable]
        public sealed class TransformEulerAngles : BindToTransformVector3
        {
            public override MotionHandle BindTo(MotionBuilder<Vector3, NoOptions, Vector3MotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToEulerAngles(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformLocalEulerAngles : BindToTransformVector3
        {
            public override MotionHandle BindTo(MotionBuilder<Vector3, NoOptions, Vector3MotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalEulerAngles(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformLocalPosition : BindToTransformVector3
        {
            public override MotionHandle BindTo(MotionBuilder<Vector3, NoOptions, Vector3MotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalPosition(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformLocalScale : BindToTransformVector3
        {
            public override MotionHandle BindTo(MotionBuilder<Vector3, NoOptions, Vector3MotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalScale(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformPosition : BindToTransformVector3
        {
            public override MotionHandle BindTo(MotionBuilder<Vector3, NoOptions, Vector3MotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToPosition(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformAnchoredPosition3D : BindToRectTransformVector3
        {
            public override MotionHandle BindTo(MotionBuilder<Vector3, NoOptions, Vector3MotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToAnchoredPosition3D(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformEulerAngles : BindToRectTransformVector3
        {
            public override MotionHandle BindTo(MotionBuilder<Vector3, NoOptions, Vector3MotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToEulerAngles(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformLocalEulerAngles : BindToRectTransformVector3
        {
            public override MotionHandle BindTo(MotionBuilder<Vector3, NoOptions, Vector3MotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalEulerAngles(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformLocalPosition : BindToRectTransformVector3
        {
            public override MotionHandle BindTo(MotionBuilder<Vector3, NoOptions, Vector3MotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalPosition(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformLocalScale : BindToRectTransformVector3
        {
            public override MotionHandle BindTo(MotionBuilder<Vector3, NoOptions, Vector3MotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalScale(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformPosition : BindToRectTransformVector3
        {
            public override MotionHandle BindTo(MotionBuilder<Vector3, NoOptions, Vector3MotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToPosition(targetResolver.Resolve(container));
            }
        }
    }
}
#endif
