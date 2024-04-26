using System;
using UnityEngine;

namespace UnitySequencerSystem.Resolvers
{
    public abstract class RectTransformResolver : IResolver<RectTransform>
    {
        public abstract RectTransform Resolve(Container container);

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Reference")]
#endif
        [Serializable]
        public sealed class Reference : RectTransformResolver
        {
            [SerializeField]
            private RectTransform target;

            public Reference()
            {
            }

            public Reference(RectTransform target)
            {
                this.target = target;
            }

            public override RectTransform Resolve(Container container)
            {
                return target;
            }
        }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Name")]
#endif
        [Serializable]
        public sealed class Name : RectTransformResolver
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

            public override RectTransform Resolve(Container container)
            {
                return container.Resolve<RectTransform>(name);
            }
        }
    }
}
