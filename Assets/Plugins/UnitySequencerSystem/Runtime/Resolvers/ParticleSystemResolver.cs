using System;
using UnityEngine;

namespace UnitySequencerSystem.Resolvers
{
    public abstract class ParticleSystemResolver : IResolver<ParticleSystem>
    {
        public abstract ParticleSystem Resolve(Container container);

        [AddTypeMenu("Reference")]
        [Serializable]
        public sealed class ReferenceParticleSystem : ParticleSystemResolver
        {
            [SerializeField]
            private ParticleSystem target;

            public override ParticleSystem Resolve(Container container)
            {
                return target;
            }
        }

        [AddTypeMenu("Name")]
        [Serializable]
        public sealed class NameParticleSystem : ParticleSystemResolver
        {
            [SerializeField]
            private string name;

            public override ParticleSystem Resolve(Container container)
            {
                return container.Resolve<ParticleSystem>(name);
            }
        }
    }
}
