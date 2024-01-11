using System;
using UnityEngine;

namespace UnitySequencerSystem.Resolvers
{
    public abstract class QuaternionResolver : IResolver<Quaternion>
    {
        public abstract Quaternion Resolve(Container container);

        [AddTypeMenu("Constant")]
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

        [AddTypeMenu("Name")]
        [Serializable]
        public sealed class NameQuaternion : QuaternionResolver
        {
            [SerializeField]
            private string name;

            public override Quaternion Resolve(Container container)
            {
                return container.Resolve<Quaternion>(name);
            }
        }
        
        [AddTypeMenu("Reference Transform Rotation")]
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
        
        [AddTypeMenu("Reference Transform Local Rotation")]
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
        
        [AddTypeMenu("Name Transform Rotation")]
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
        
        [AddTypeMenu("Name Transform Local Rotation")]
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
