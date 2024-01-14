using System;
using UnityEngine;

namespace UnitySequencerSystem.Resolvers
{
    public abstract class Vector2Resolver : IResolver<Vector2>
    {
        public abstract Vector2 Resolve(Container container);

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Constant")]
#endif
        [Serializable]
        public sealed class Constant : Vector2Resolver
        {
            [SerializeField]
            private Vector2 value;

            public Constant()
            {
            }

            public Constant(Vector2 value)
            {
                this.value = value;
            }

            public override Vector2 Resolve(Container container)
            {
                return value;
            }
        }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Name")]
#endif
        [Serializable]
        public sealed class Name : Vector2Resolver
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

            public override Vector2 Resolve(Container container)
            {
                return container.Resolve<Vector2>(name);
            }
        }
    }
}
