using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnitySequencerSystem.Resolvers
{
    public abstract class ImageResolver : IResolver<Image>
    {
        public abstract Image Resolve(Container container);

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Reference")]
#endif
        [Serializable]
        public sealed class Reference : ImageResolver
        {
            [SerializeField]
            private Image target;

            public Reference()
            {
            }

            public Reference(Image target)
            {
                this.target = target;
            }

            public override Image Resolve(Container container)
            {
                return target;
            }
        }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Name")]
#endif
        [Serializable]
        public sealed class Name : ImageResolver
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

            public override Image Resolve(Container container)
            {
                return container.Resolve<Image>(name);
            }
        }
    }
}
