using System;
using UnityEngine;

namespace UnitySequencerSystem.Resolvers
{
    public abstract class BooleanResolver : IResolver<bool>
    {
        public abstract bool Resolve(Container container);

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Constant")]
#endif
        [Serializable]
        public sealed class Constant : BooleanResolver
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
        public sealed class NameBoolean : BooleanResolver
        {
            [SerializeField]
            private string name;

            public NameBoolean()
            {
            }

            public NameBoolean(string name)
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
        public sealed class FuncBoolean : BooleanResolver
        {
            [SerializeField]
            private string name;

            public FuncBoolean()
            {
            }

            public FuncBoolean(string name)
            {
                this.name = name;
            }

            public override bool Resolve(Container container)
            {
                return container.Resolve<Func<bool>>(name).Invoke();
            }
        }
    }
}
