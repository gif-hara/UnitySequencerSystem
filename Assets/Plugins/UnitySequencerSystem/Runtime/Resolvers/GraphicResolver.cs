using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnitySequencerSystem.Resolvers
{
    public abstract class GraphicResolver : IResolver<Graphic>
    {
        public abstract Graphic Resolve(Container container);

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Reference")]
#endif
        [Serializable]
        public sealed class Reference : GraphicResolver
        {
            [SerializeField]
            private Graphic target;

            public Reference()
            {
            }

            public Reference(Graphic target)
            {
                this.target = target;
            }

            public override Graphic Resolve(Container container)
            {
                return target;
            }
        }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Name")]
#endif
        [Serializable]
        public sealed class Name : GraphicResolver
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

            public override Graphic Resolve(Container container)
            {
                return container.Resolve<Graphic>(name);
            }
        }
    }
}
