#if USS_SUPPORT_LIT_MOTION
using System;
using LitMotion;
using LitMotion.Adapters;
using LitMotion.Extensions;
using UnityEngine;
using UnitySequencerSystem.Resolvers;

namespace UnitySequencerSystem.LitMotion
{
    public class BindToVector2
    {
        public interface IBindTo : IBindTo<Vector2, NoOptions, Vector2MotionAdapter>
        {
        }

        [Serializable]
        public abstract class BindToTransformVector2 : IBindTo
        {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
            [SubclassSelector]
#endif
            [SerializeReference]
            protected TransformResolver targetResolver;

            public abstract MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container);
        }

        [Serializable]
        public abstract class BindToRectTransformVector2 : IBindTo
        {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
            [SubclassSelector]
#endif
            [SerializeReference]
            protected RectTransformResolver targetResolver;

            public abstract MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container);
        }

        [Serializable]
        public sealed class TransformEulerAngleXY : BindToTransformVector2
        {
            public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToEulerAnglesXY(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformEulerAngleXZ : BindToTransformVector2
        {
            public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToEulerAnglesXZ(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformEulerAngleYZ : BindToTransformVector2
        {
            public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToEulerAnglesYZ(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformLocalEulerAnglesXY : BindToTransformVector2
        {
            public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalEulerAnglesXY(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformLocalEulerAnglesXZ : BindToTransformVector2
        {
            public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalEulerAnglesXZ(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformLocalEulerAnglesYZ : BindToTransformVector2
        {
            public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalEulerAnglesYZ(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformLocalPositionXY : BindToTransformVector2
        {
            public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalPositionXY(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformLocalPositionXZ : BindToTransformVector2
        {
            public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalPositionXZ(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformLocalPositionYZ : BindToTransformVector2
        {
            public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalPositionYZ(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformLocalScaleXY : BindToTransformVector2
        {
            public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalScaleXY(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformLocalScaleXZ : BindToTransformVector2
        {
            public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalScaleXZ(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformLocalScaleYZ : BindToTransformVector2
        {
            public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalScaleYZ(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformPositionXY : BindToTransformVector2
        {
            public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToPositionXY(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformPositionXZ : BindToTransformVector2
        {
            public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToPositionXZ(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class TransformPositionYZ : BindToTransformVector2
        {
            public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToPositionYZ(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformAnchoredPosition : BindToRectTransformVector2
        {
            public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToAnchoredPosition(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformAnchorMax : BindToRectTransformVector2
        {
            public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToAnchorMax(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformAnchorMin : BindToRectTransformVector2
        {
            public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToAnchorMin(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformEulerAnglesXY : BindToRectTransformVector2
        {
            public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToEulerAnglesXY(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformEulerAnglesXZ : BindToRectTransformVector2
        {
            public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToEulerAnglesXZ(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformEulerAnglesYZ : BindToRectTransformVector2
        {
            public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToEulerAnglesYZ(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformLocalEulerAnglesXY : BindToRectTransformVector2
        {
            public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalEulerAnglesXY(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformLocalEulerAnglesXZ : BindToRectTransformVector2
        {
            public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalEulerAnglesXZ(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformLocalEulerAnglesYZ : BindToRectTransformVector2
        {
            public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalEulerAnglesYZ(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformLocalPositionXY : BindToRectTransformVector2
        {
            public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalPositionXY(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformLocalPositionXZ : BindToRectTransformVector2
        {
            public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalPositionXZ(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformLocalPositionYZ : BindToRectTransformVector2
        {
            public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalPositionYZ(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformLocalScaleXY : BindToRectTransformVector2
        {
            public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalScaleXY(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformLocalScaleXZ : BindToRectTransformVector2
        {
            public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalScaleXZ(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformLocalScaleYZ : BindToRectTransformVector2
        {
            public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToLocalScaleYZ(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformPivot : BindToRectTransformVector2
        {
            public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToPivot(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformPositionXY : BindToRectTransformVector2
        {
            public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToPositionXY(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformPositionXZ : BindToRectTransformVector2
        {
            public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToPositionXZ(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformPositionYZ : BindToRectTransformVector2
        {
            public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToPositionYZ(targetResolver.Resolve(container));
            }
        }

        [Serializable]
        public sealed class RectTransformSizeDelta : BindToRectTransformVector2
        {
            public override MotionHandle BindTo(MotionBuilder<Vector2, NoOptions, Vector2MotionAdapter> motionBuilder, Container container)
            {
                return motionBuilder.BindToSizeDelta(targetResolver.Resolve(container));
            }
        }
    }
}
#endif
