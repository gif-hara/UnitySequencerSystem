using System;
using UnityEngine;

namespace UnitySequencerSystem.Resolvers
{
    public abstract class ColorResolver : IResolver<Color>
    {
        public abstract Color Resolve(Container container);

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Constant")]
#endif
        [Serializable]
        public sealed class Constant : ColorResolver
        {
            [SerializeField]
            private Color value;

            public override Color Resolve(Container container)
            {
                return value;
            }
        }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Name")]
#endif
        [Serializable]
        public sealed class Name : ColorResolver
        {
            [SerializeField]
            private string name;

            public override Color Resolve(Container container)
            {
                return container.Resolve<Color>(name);
            }
        }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Func")]
#endif
        [Serializable]
        public sealed class Func : ColorResolver
        {
            [SerializeField]
            private string name;

            public override Color Resolve(Container container)
            {
                return container.Resolve<Func<Color>>(name)();
            }
        }
    }
}
