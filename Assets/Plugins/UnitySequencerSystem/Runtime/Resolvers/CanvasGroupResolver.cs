using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnitySequencerSystem.Resolvers
{
    public abstract class CanvasGroupResolver : IResolver<CanvasGroup>
    {
        public abstract CanvasGroup Resolve(Container container);

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Reference")]
#endif
        [Serializable]
        public sealed class Reference : CanvasGroupResolver
        {
            [SerializeField]
            private CanvasGroup target;

            public Reference()
            {
            }

            public Reference(CanvasGroup target)
            {
                this.target = target;
            }

            public override CanvasGroup Resolve(Container container)
            {
                return target;
            }
        }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Name")]
#endif
        [Serializable]
        public sealed class Name : CanvasGroupResolver
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

            public override CanvasGroup Resolve(Container container)
            {
                return container.Resolve<CanvasGroup>(name);
            }
        }
    }
}
