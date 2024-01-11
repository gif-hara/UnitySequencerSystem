using System;
using UnityEngine;

namespace HK.UnitySequencerSystem.Resolvers
{
    public abstract class ParticleSystemResolver : IResolver<ParticleSystem>
    {
        public abstract ParticleSystem Resolve(Container container);

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
