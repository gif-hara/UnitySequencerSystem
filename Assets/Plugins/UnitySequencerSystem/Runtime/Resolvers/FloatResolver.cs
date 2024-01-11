using System;
using UnityEngine;

namespace UnitySequencerSystem.Resolvers
{
    public abstract class FloatResolver : IResolver<float>
    {
        public abstract float Resolve(Container container);

        [AddTypeMenu("Constant")]
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

        [AddTypeMenu("Name")]
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
