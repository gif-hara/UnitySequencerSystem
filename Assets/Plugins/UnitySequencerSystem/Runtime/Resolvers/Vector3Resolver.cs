using System;
using UnityEngine;

namespace UnitySequencerSystem.Resolvers
{
    public abstract class Vector3Resolver : IResolver<Vector3>
    {
        public abstract Vector3 Resolve(Container container);

        [AddTypeMenu("Constant")]
        [Serializable]
        public sealed class Constant : Vector3Resolver
        {
            [SerializeField]
            private Vector3 value;

            public override Vector3 Resolve(Container container)
            {
                return value;
            }
        }

        [AddTypeMenu("Name")]
        [Serializable]
        public sealed class NameVector3 : Vector3Resolver
        {
            [SerializeField]
            private string name;

            public override Vector3 Resolve(Container container)
            {
                return container.Resolve<Vector3>(name);
            }
        }

        [AddTypeMenu("Reference Transform Position")]
        [Serializable]
        public sealed class ReferenceTransformPosition : Vector3Resolver
        {
            [SerializeField]
            private Transform target;
            
            public override Vector3 Resolve(Container container)
            {
                return target.position;
            }
        }

        [AddTypeMenu("Reference Transform Local Position")]
        [Serializable]
        public sealed class ReferenceTransformLocalPosition : Vector3Resolver
        {
            [SerializeField]
            private Transform target;
            
            public override Vector3 Resolve(Container container)
            {
                return target.localPosition;
            }
        }

        [AddTypeMenu("Reference Transform Euler Angles")]
        [Serializable]
        public sealed class ReferenceTransformEulerAngles : Vector3Resolver
        {
            [SerializeField]
            private Transform target;
            
            public override Vector3 Resolve(Container container)
            {
                return target.eulerAngles;
            }
        }

        [AddTypeMenu("Reference Transform Local Euler Angles")]
        [Serializable]
        public sealed class ReferenceTransformLocalEulerAngles : Vector3Resolver
        {
            [SerializeField]
            private Transform target;
            
            public override Vector3 Resolve(Container container)
            {
                return target.localEulerAngles;
            }
        }

        [AddTypeMenu("Reference Transform Local Scale")]
        [Serializable]
        public sealed class ReferenceTransformLocalScale : Vector3Resolver
        {
            [SerializeField]
            private Transform target;
            
            public override Vector3 Resolve(Container container)
            {
                return target.localScale;
            }
        }

        [AddTypeMenu("Reference Transform Lossy Scale")]
        [Serializable]
        public sealed class ReferenceTransformLossyScale : Vector3Resolver
        {
            [SerializeField]
            private Transform target;
            
            public override Vector3 Resolve(Container container)
            {
                return target.lossyScale;
            }
        }

        [AddTypeMenu("Name Transform Position")]
        [Serializable]
        public sealed class NameTransformPosition : Vector3Resolver
        {
            [SerializeField]
            private string name;
            
            public override Vector3 Resolve(Container container)
            {
                var target = container.Resolve<Transform>(name);
                return target.position;
            }
        }

        [AddTypeMenu("Name Transform Local Position")]
        [Serializable]
        public sealed class NameTransformLocalPosition : Vector3Resolver
        {
            [SerializeField]
            private string name;
            
            public override Vector3 Resolve(Container container)
            {
                var target = container.Resolve<Transform>(name);
                return target.localPosition;
            }
        }
        
        [AddTypeMenu("Name Transform Euler Angles")]
        [Serializable]
        public sealed class NameTransformEulerAngles : Vector3Resolver
        {
            [SerializeField]
            private string name;
            
            public override Vector3 Resolve(Container container)
            {
                var target = container.Resolve<Transform>(name);
                return target.eulerAngles;
            }
        }

        [AddTypeMenu("Name Transform Local Euler Angles")]
        [Serializable]
        public sealed class NameTransformLocalEulerAngles : Vector3Resolver
        {
            [SerializeField]
            private string name;
            
            public override Vector3 Resolve(Container container)
            {
                var target = container.Resolve<Transform>(name);
                return target.localEulerAngles;
            }
        }

        [AddTypeMenu("Name Transform Local Scale")]
        [Serializable]
        public sealed class NameTransformLocalScale : Vector3Resolver
        {
            [SerializeField]
            private string name;
            
            public override Vector3 Resolve(Container container)
            {
                var target = container.Resolve<Transform>(name);
                return target.localScale;
            }
        }

        [AddTypeMenu("Name Transform Lossy Scale")]
        [Serializable]
        public sealed class NameTransformLossyScale : Vector3Resolver
        {
            [SerializeField]
            private string name;
            
            public override Vector3 Resolve(Container container)
            {
                var target = container.Resolve<Transform>(name);
                return target.lossyScale;
            }
        }
    }
}
