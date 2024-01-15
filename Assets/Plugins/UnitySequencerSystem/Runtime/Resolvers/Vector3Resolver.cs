using System;
using UnityEngine;

namespace UnitySequencerSystem.Resolvers
{
    public abstract class Vector3Resolver : IResolver<Vector3>
    {
        public abstract Vector3 Resolve(Container container);

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Constant")]
#endif
        [Serializable]
        public sealed class Constant : Vector3Resolver
        {
            [SerializeField]
            private Vector3 value;

            public Constant()
            {
            }

            public Constant(Vector3 value)
            {
                this.value = value;
            }

            public override Vector3 Resolve(Container container)
            {
                return value;
            }
        }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Name")]
#endif
        [Serializable]
        public sealed class Name : Vector3Resolver
        {
            [SerializeField]
            private string name;

            public Name()
            {
            }

            public Name(string name)
            {
                this.name = name;
            }

            public override Vector3 Resolve(Container container)
            {
                return container.Resolve<Vector3>(name);
            }
        }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Reference Transform Position")]
#endif
        [Serializable]
        public sealed class ReferenceTransformPosition : Vector3Resolver
        {
            [SerializeField]
            private Transform target;

            public ReferenceTransformPosition()
            {
            }

            public ReferenceTransformPosition(Transform target)
            {
                this.target = target;
            }

            public override Vector3 Resolve(Container container)
            {
                return target.position;
            }
        }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Reference Transform Local Position")]
#endif
        [Serializable]
        public sealed class ReferenceTransformLocalPosition : Vector3Resolver
        {
            [SerializeField]
            private Transform target;

            public ReferenceTransformLocalPosition()
            {
            }

            public ReferenceTransformLocalPosition(Transform target)
            {
                this.target = target;
            }

            public override Vector3 Resolve(Container container)
            {
                return target.localPosition;
            }
        }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Reference Transform Euler Angles")]
#endif
        [Serializable]
        public sealed class ReferenceTransformEulerAngles : Vector3Resolver
        {
            [SerializeField]
            private Transform target;

            public ReferenceTransformEulerAngles()
            {
            }

            public ReferenceTransformEulerAngles(Transform target)
            {
                this.target = target;
            }

            public override Vector3 Resolve(Container container)
            {
                return target.eulerAngles;
            }
        }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Reference Transform Local Euler Angles")]
#endif
        [Serializable]
        public sealed class ReferenceTransformLocalEulerAngles : Vector3Resolver
        {
            [SerializeField]
            private Transform target;

            public ReferenceTransformLocalEulerAngles()
            {
            }

            public ReferenceTransformLocalEulerAngles(Transform target)
            {
                this.target = target;
            }

            public override Vector3 Resolve(Container container)
            {
                return target.localEulerAngles;
            }
        }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Reference Transform Local Scale")]
#endif
        [Serializable]
        public sealed class ReferenceTransformLocalScale : Vector3Resolver
        {
            [SerializeField]
            private Transform target;

            public ReferenceTransformLocalScale()
            {
            }

            public ReferenceTransformLocalScale(Transform target)
            {
                this.target = target;
            }

            public override Vector3 Resolve(Container container)
            {
                return target.localScale;
            }
        }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Reference Transform Lossy Scale")]
#endif
        [Serializable]
        public sealed class ReferenceTransformLossyScale : Vector3Resolver
        {
            [SerializeField]
            private Transform target;

            public ReferenceTransformLossyScale()
            {
            }

            public ReferenceTransformLossyScale(Transform target)
            {
                this.target = target;
            }

            public override Vector3 Resolve(Container container)
            {
                return target.lossyScale;
            }
        }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Name Transform Position")]
#endif
        [Serializable]
        public sealed class NameTransformPosition : Vector3Resolver
        {
            [SerializeField]
            private string name;

            public NameTransformPosition()
            {
            }

            public NameTransformPosition(string name)
            {
                this.name = name;
            }

            public override Vector3 Resolve(Container container)
            {
                var target = container.Resolve<Transform>(name);
                return target.position;
            }
        }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Name Transform Local Position")]
#endif
        [Serializable]
        public sealed class NameTransformLocalPosition : Vector3Resolver
        {
            [SerializeField]
            private string name;

            public NameTransformLocalPosition()
            {
            }

            public NameTransformLocalPosition(string name)
            {
                this.name = name;
            }

            public override Vector3 Resolve(Container container)
            {
                var target = container.Resolve<Transform>(name);
                return target.localPosition;
            }
        }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Name Transform Euler Angles")]
#endif
        [Serializable]
        public sealed class NameTransformEulerAngles : Vector3Resolver
        {
            [SerializeField]
            private string name;

            public NameTransformEulerAngles()
            {
            }

            public NameTransformEulerAngles(string name)
            {
                this.name = name;
            }

            public override Vector3 Resolve(Container container)
            {
                var target = container.Resolve<Transform>(name);
                return target.eulerAngles;
            }
        }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Name Transform Local Euler Angles")]
#endif
        [Serializable]
        public sealed class NameTransformLocalEulerAngles : Vector3Resolver
        {
            [SerializeField]
            private string name;

            public NameTransformLocalEulerAngles()
            {
            }

            public NameTransformLocalEulerAngles(string name)
            {
                this.name = name;
            }

            public override Vector3 Resolve(Container container)
            {
                var target = container.Resolve<Transform>(name);
                return target.localEulerAngles;
            }
        }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Name Transform Local Scale")]
#endif
        [Serializable]
        public sealed class NameTransformLocalScale : Vector3Resolver
        {
            [SerializeField]
            private string name;

            public NameTransformLocalScale()
            {
            }

            public NameTransformLocalScale(string name)
            {
                this.name = name;
            }

            public override Vector3 Resolve(Container container)
            {
                var target = container.Resolve<Transform>(name);
                return target.localScale;
            }
        }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Name Transform Lossy Scale")]
#endif
        [Serializable]
        public sealed class NameTransformLossyScale : Vector3Resolver
        {
            [SerializeField]
            private string name;

            public NameTransformLossyScale()
            {
            }

            public NameTransformLossyScale(string name)
            {
                this.name = name;
            }

            public override Vector3 Resolve(Container container)
            {
                var target = container.Resolve<Transform>(name);
                return target.lossyScale;
            }
        }
    }
}
