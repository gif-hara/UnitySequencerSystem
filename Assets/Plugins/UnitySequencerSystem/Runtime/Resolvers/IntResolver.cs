using System;
using UnityEngine;

namespace UnitySequencerSystem.Resolvers
{
    public abstract class IntResolver : IResolver<int>
    {
        public abstract int Resolve(Container container);

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Constant")]
#endif
        [Serializable]
        public sealed class Constant : IntResolver
        {
            [SerializeField]
            private int value;

            public Constant()
            {
            }

            public Constant(int value)
            {
                this.value = value;
            }

            public override int Resolve(Container container)
            {
                return value;
            }
        }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Name")]
#endif
        [Serializable]
        public sealed class Name : IntResolver
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

            public override int Resolve(Container container)
            {
                return container.Resolve<int>(name);
            }
        }
    }
}
