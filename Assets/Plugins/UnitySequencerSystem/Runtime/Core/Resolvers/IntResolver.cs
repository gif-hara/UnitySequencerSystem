using System;
using UnityEngine;

namespace HK.UnitySequencerSystem.Resolvers
{
    public abstract class IntResolver : IResolver<int>
    {
        public abstract int Resolve(Container container);

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
