using System;
using UnityEngine;

namespace UnitySequencerSystem.Resolvers
{
    public abstract class SpriteRendererResolver : IResolver<SpriteRenderer>
    {
        public abstract SpriteRenderer Resolve(Container container);

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Reference")]
#endif
        [Serializable]
        public sealed class Reference : SpriteRendererResolver
        {
            [SerializeField]
            private SpriteRenderer target;

            public Reference()
            {
            }

            public Reference(SpriteRenderer target)
            {
                this.target = target;
            }

            public override SpriteRenderer Resolve(Container container)
            {
                return target;
            }
        }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Name")]
#endif
        [Serializable]
        public sealed class Name : SpriteRendererResolver
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

            public override SpriteRenderer Resolve(Container container)
            {
                return container.Resolve<SpriteRenderer>(name);
            }
        }
    }
}
