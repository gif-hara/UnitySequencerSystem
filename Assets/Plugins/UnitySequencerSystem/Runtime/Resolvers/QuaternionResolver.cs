using System;
using UnityEngine;

namespace UnitySequencerSystem.Resolvers
{
    public abstract class QuaternionResolver : IResolver<Quaternion>
    {
        public abstract Quaternion Resolve(Container container);

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Constant")]
#endif
        [Serializable]
        public sealed class Constant : QuaternionResolver
        {
            [SerializeField]
            private Quaternion value;

            public override Quaternion Resolve(Container container)
            {
                return value;
            }
        }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Name")]
#endif
        [Serializable]
        public sealed class Name : QuaternionResolver
        {
            [SerializeField]
            private string name;

            public override Quaternion Resolve(Container container)
            {
                return container.Resolve<Quaternion>(name);
            }
        }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Reference Transform Rotation")]
#endif
        [Serializable]
        public sealed class ReferenceTransformRotation : QuaternionResolver
        {
            [SerializeField]
            private Transform target;

            public override Quaternion Resolve(Container container)
            {
                return target.rotation;
            }
        }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Reference Transform Local Rotation")]
#endif
        [Serializable]
        public sealed class ReferenceTransformLocalRotation : QuaternionResolver
        {
            [SerializeField]
            private Transform target;

            public override Quaternion Resolve(Container container)
            {
                return target.localRotation;
            }
        }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Name Transform Rotation")]
#endif
        [Serializable]
        public sealed class NameTransformRotation : QuaternionResolver
        {
            [SerializeField]
            private string name;

            public override Quaternion Resolve(Container container)
            {
                var target = container.Resolve<Transform>(name);
                return target.rotation;
            }
        }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Name Transform Local Rotation")]
#endif
        [Serializable]
        public sealed class NameTransformLocalRotation : QuaternionResolver
        {
            [SerializeField]
            private string name;

            public override Quaternion Resolve(Container container)
            {
                var target = container.Resolve<Transform>(name);
                return target.localRotation;
            }
        }
    }
}
