using System;
using UnityEngine;

namespace UnitySequencerSystem.Resolvers
{
    public abstract class BoolResolver : IResolver<bool>
    {
        public abstract bool Resolve(Container container);

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Constant")]
#endif
        [Serializable]
        public sealed class Constant : BoolResolver
        {
            [SerializeField]
            private bool value;

            public Constant()
            {
            }

            public Constant(bool value)
            {
                this.value = value;
            }

            public override bool Resolve(Container container)
            {
                return value;
            }
        }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Name")]
#endif
        [Serializable]
        public sealed class Name : BoolResolver
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

            public override bool Resolve(Container container)
            {
                return container.Resolve<bool>(name);
            }
        }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Func")]
#endif
        [Serializable]
        public sealed class Func : BoolResolver
        {
            [SerializeField]
            private string name;

            public Func()
            {
            }

            public Func(string name)
            {
                this.name = name;
            }

            public override bool Resolve(Container container)
            {
                return container.Resolve<Func<bool>>(name)();
            }
        }
    }
}
