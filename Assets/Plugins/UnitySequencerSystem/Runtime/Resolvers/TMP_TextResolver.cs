#if USS_TMP_SUPPORT
using System;
using TMPro;
using UnityEngine;

namespace UnitySequencerSystem.Resolvers
{
    public abstract class TMP_TextResolver : IResolver<TMP_Text>
    {
        public abstract TMP_Text Resolve(Container container);

        [AddTypeMenu("Reference")]
        [Serializable]
        public sealed class ReferenceTMP_Text : TMP_TextResolver
        {
            [SerializeField]
            private TMP_Text target;

            public override TMP_Text Resolve(Container container)
            {
                return target;
            }
        }

        [AddTypeMenu("Name")]
        [Serializable]
        public sealed class NameTMP_Text : TMP_TextResolver
        {
            [SerializeField]
            private string name;

            public override TMP_Text Resolve(Container container)
            {
                return container.Resolve<TMP_Text>(name);
            }
        }
    }
}
#endif
