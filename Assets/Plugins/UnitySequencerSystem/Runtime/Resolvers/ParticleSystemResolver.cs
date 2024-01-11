using System;
using UnityEngine;

namespace UnitySequencerSystem.Resolvers
{
    public abstract class ParticleSystemResolver : IResolver<ParticleSystem>
    {
        public abstract ParticleSystem Resolve(Container container);

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Reference")]
#endif
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

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Name")]
#endif
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
