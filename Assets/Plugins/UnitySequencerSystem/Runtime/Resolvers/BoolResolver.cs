using System;
using UnityEngine;

namespace UnitySequencerSystem.Resolvers
{
    public abstract class BoolResolver : IResolver<bool>
    {
        public abstract bool Resolve(Container container);

        [AddTypeMenu("Constant")]
        [Serializable]
        public sealed class Constant : BoolResolver
        {
            [SerializeField]
            private bool value;

            public override bool Resolve(Container container)
            {
                return value;
            }
        }

        [AddTypeMenu("Name")]
        [Serializable]
        public sealed class Name : BoolResolver
        {
            [SerializeField]
            private string name;

            public override bool Resolve(Container container)
            {
                return container.Resolve<bool>(name);
            }
        }

        [AddTypeMenu("Func")]
        [Serializable]
        public sealed class Func : BoolResolver
        {
            [SerializeField]
            private string name;

            public override bool Resolve(Container container)
            {
                return container.Resolve<Func<bool>>(name)();
            }
        }
    }
}
