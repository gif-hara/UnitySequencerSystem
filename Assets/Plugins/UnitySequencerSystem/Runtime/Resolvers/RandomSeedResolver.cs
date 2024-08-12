using System;
using Unity.Mathematics;
using UnityEngine;

namespace UnitySequencerSystem.Resolvers
{
    public abstract class RandomSeedResolver : IResolver<uint>
    {
        public abstract uint Resolve(Container container);

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Constant")]
#endif
        [Serializable]
        public sealed class Constant : RandomSeedResolver
        {
            [SerializeField]
            private uint value;

            public Constant()
            {
            }

            public Constant(uint value)
            {
                this.value = value;
            }

            public override uint Resolve(Container container)
            {
                return value;
            }
        }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Name")]
#endif
        [Serializable]
        public sealed class Name : RandomSeedResolver
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

            public override uint Resolve(Container container)
            {
                return container.Resolve<uint>(name);
            }
        }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Random")]
#endif
        [Serializable]
        public sealed class Random : RandomSeedResolver
        {
            public Random()
            {
            }

            public override uint Resolve(Container container)
            {
                return (uint)UnityEngine.Random.Range(uint.MinValue, uint.MaxValue);
            }
        }
    }
}
