using System;
using UnityEngine;

namespace UnitySequencerSystem.Resolvers
{
    public abstract class MaterialResolver : IResolver<Material>
    {
        public abstract Material Resolve(Container container);

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Reference")]
#endif
        [Serializable]
        public sealed class Reference : MaterialResolver
        {
            [SerializeField]
            private Material target;

            public Reference()
            {
            }

            public Reference(Material target)
            {
                this.target = target;
            }

            public override Material Resolve(Container container)
            {
                return target;
            }
        }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Name")]
#endif
        [Serializable]
        public sealed class Name : MaterialResolver
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

            public override Material Resolve(Container container)
            {
                return container.Resolve<Material>(name);
            }
        }
    }
}
