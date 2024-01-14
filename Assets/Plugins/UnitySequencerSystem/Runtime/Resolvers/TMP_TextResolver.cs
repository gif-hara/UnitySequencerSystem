#if USS_TMP_SUPPORT
using System;
using TMPro;
using UnityEngine;

namespace UnitySequencerSystem.Resolvers
{
    public abstract class TMP_TextResolver : IResolver<TMP_Text>
    {
        public abstract TMP_Text Resolve(Container container);

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Reference")]
#endif
        [Serializable]
        public sealed class Reference : TMP_TextResolver
        {
            [SerializeField]
            private TMP_Text target;

            public Reference()
            {
            }

            public Reference(TMP_Text target)
            {
                this.target = target;
            }

            public override TMP_Text Resolve(Container container)
            {
                return target;
            }
        }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Name")]
#endif
        [Serializable]
        public sealed class Name : TMP_TextResolver
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

            public override TMP_Text Resolve(Container container)
            {
                return container.Resolve<TMP_Text>(name);
            }
        }
    }
}
#endif
