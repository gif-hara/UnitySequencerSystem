using System;
using UnityEngine;
using UnityEngine.Audio;

namespace UnitySequencerSystem.Resolvers
{
    public abstract class AudioMixerResolver : IResolver<AudioMixer>
    {
        public abstract AudioMixer Resolve(Container container);

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Reference")]
#endif
        [Serializable]
        public sealed class Reference : AudioMixerResolver
        {
            [SerializeField]
            private AudioMixer target;

            public Reference()
            {
            }

            public Reference(AudioMixer target)
            {
                this.target = target;
            }

            public override AudioMixer Resolve(Container container)
            {
                return target;
            }
        }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Name")]
#endif
        [Serializable]
        public sealed class Name : AudioMixerResolver
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

            public override AudioMixer Resolve(Container container)
            {
                return container.Resolve<AudioMixer>(name);
            }
        }
    }
}
