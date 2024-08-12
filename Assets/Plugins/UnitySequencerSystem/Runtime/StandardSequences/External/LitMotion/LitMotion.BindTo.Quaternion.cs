#if USS_SUPPORT_LIT_MOTION
using System;
using LitMotion;
using LitMotion.Adapters;
using LitMotion.Extensions;
using UnityEngine;
using UnitySequencerSystem.Resolvers;

namespace UnitySequencerSystem.LitMotion
{
    public class BindToQuaternion
    {
        public interface IBindTo : IBindTo<Quaternion, NoOptions, QuaternionMotionAdapter>
        {
        }

        [Serializable]
        public abstract class BindToTransformQuaternion : IBindTo
        {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
            [SubclassSelector]
#endif
            [SerializeReference]
            protected TransformResolver targetResolver;

            public abstract MotionHandle BindTo(MotionBuilder<Quaternion, NoOptions, QuaternionMotionAdapter> motionBuilder, Container container);
        }

        [Serializable]
        public abstract class BindToRectTransformQuaternion : IBindTo
        {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
            [SubclassSelector]
#endif
            [SerializeReference]
            protected RectTransformResolver targetResolver;

            public abstract MotionHandle BindTo(MotionBuilder<Quaternion, NoOptions, QuaternionMotionAdapter> motionBuilder, Container container);
        }

        [Serializable]
        public sealed class TransformLocalRotation : BindToTransformQuaternion
        {
            public override MotionHandle BindTo(MotionBuilder<Quaternion, NoOptions, QuaternionMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalRotation(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformRotation : BindToTransformQuaternion
        {
            public override MotionHandle BindTo(MotionBuilder<Quaternion, NoOptions, QuaternionMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToRotation(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformLocalRotation : BindToRectTransformQuaternion
        {
            public override MotionHandle BindTo(MotionBuilder<Quaternion, NoOptions, QuaternionMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalRotation(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformRotation : BindToRectTransformQuaternion
        {
            public override MotionHandle BindTo(MotionBuilder<Quaternion, NoOptions, QuaternionMotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToRotation(targetResolver.Resolve(container));
            }
        }
    }
}
#endif
