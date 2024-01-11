using System;
using UnityEngine;

namespace UnitySequencerSystem.Resolvers
{
    public abstract class IntResolver : IResolver<int>
    {
        public abstract int Resolve(Container container);

        [AddTypeMenu("Constant")]
        [Serializable]
        public sealed class Constant : IntResolver
        {
            [SerializeField]
            private int value;

            public override int Resolve(Container container)
            {
                return value;
            }
        }

        [AddTypeMenu("Name")]
        [Serializable]
        public sealed class NameFloat : IntResolver
        {
            [SerializeField]
            private string name;

            public override int Resolve(Container container)
            {
                return container.Resolve<int>(name);
            }
        }
    }
}
