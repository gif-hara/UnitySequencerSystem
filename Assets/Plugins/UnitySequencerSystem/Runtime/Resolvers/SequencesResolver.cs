using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnitySequencerSystem.Resolvers
{
    public abstract class SequencesResolver : IResolver<List<ISequence>>
    {
        public abstract List<ISequence> Resolve(Container container);

        [AddTypeMenu("List")]
        [Serializable]
        public sealed class List : SequencesResolver
        {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
            [SubclassSelector]
#endif
            [SerializeReference]
            private List<ISequence> value;

            public override List<ISequence> Resolve(Container container)
            {
                return value;
            }
        }

        [AddTypeMenu("Name")]
        [Serializable]
        public sealed class Name : SequencesResolver
        {
            [SerializeField]
            private string name;

            public override List<ISequence> Resolve(Container container)
            {
                return container.Resolve<List<ISequence>>(name);
            }
        }

        [AddTypeMenu("Func")]
        [Serializable]
        public sealed class Func : SequencesResolver
        {
            [SerializeField]
            private string name;

            public override List<ISequence> Resolve(Container container)
            {
                return container.Resolve<Func<List<ISequence>>>(name)();
            }
        }

        [AddTypeMenu("ScriptableObject")]
        [Serializable]
        public sealed class ScriptableObject : SequencesResolver
        {
            [SerializeField]
            private ScriptableSequences value;

            public override List<ISequence> Resolve(Container container)
            {
                return value.Sequences;
            }
        }
    }
}
