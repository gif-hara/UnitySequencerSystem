using System;
using UnityEngine;

namespace UnitySequencerSystem.Resolvers
{
    public abstract class FloatResolver : IResolver<float>
    {
        public abstract float Resolve(Container container);

        [Serializable]
        public sealed class Constant : FloatResolver
        {
            [SerializeField]
            private float value;

            public override float Resolve(Container container)
            {
                return value;
            }
        }

        [Serializable]
        public sealed class NameFloat : FloatResolver
        {
            [SerializeField]
            private string name;

            public override float Resolve(Container container)
            {
                return container.Resolve<float>(name);
            }
        }
    }
}
