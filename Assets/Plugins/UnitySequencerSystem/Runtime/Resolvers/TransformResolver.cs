using System;
using UnityEngine;

namespace UnitySequencerSystem.Resolvers
{
    public abstract class TransformResolver : IResolver<Transform>
    {
        public abstract Transform Resolve(Container container);

        [Serializable]
        public sealed class ReferenceTransform : TransformResolver
        {
            [SerializeField]
            private Transform target;

            public override Transform Resolve(Container container)
            {
                return target;
            }
        }

        [Serializable]
        public sealed class NameTransform : TransformResolver
        {
            [SerializeField]
            private string name;

            public override Transform Resolve(Container container)
            {
                return container.Resolve<Transform>(name);
            }
        }
    }
}
