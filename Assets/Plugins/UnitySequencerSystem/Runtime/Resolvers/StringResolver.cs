using System;
using UnityEngine;

namespace UnitySequencerSystem.Resolvers
{
    public abstract class StringResolver : IResolver<string>
    {
        public abstract string Resolve(Container container);

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Constant")]
#endif
        [Serializable]
        public sealed class Constant : StringResolver
        {
            [SerializeField]
            private string value;

            public override string Resolve(Container container)
            {
                return value;
            }
        }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Name")]
#endif
        [Serializable]
        public sealed class NameString : StringResolver
        {
            [SerializeField]
            private string name;

            public override string Resolve(Container container)
            {
                return container.Resolve<string>(name);
            }
        }
    }
}
