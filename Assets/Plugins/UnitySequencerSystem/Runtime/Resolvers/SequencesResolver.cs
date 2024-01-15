using System;
using System.Collections.Generic;
using UnityEngine;

namespace UnitySequencerSystem.Resolvers
{
    public abstract class SequencesResolver : IResolver<List<ISequence>>
    {
        public abstract List<ISequence> Resolve(Container container);

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("List")]
#endif
        [Serializable]
        public sealed class List : SequencesResolver
        {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
            [SubclassSelector]
#endif
            [SerializeReference]
            private List<ISequence> value;

            public List()
            {
            }

            public List(List<ISequence> value)
            {
                this.value = value;
            }

            public override List<ISequence> Resolve(Container container)
            {
                return value;
            }
        }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Name")]
#endif
        [Serializable]
        public sealed class Name : SequencesResolver
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

            public override List<ISequence> Resolve(Container container)
            {
                return container.Resolve<List<ISequence>>(name);
            }
        }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Func")]
#endif
        [Serializable]
        public sealed class Func : SequencesResolver
        {
            [SerializeField]
            private string name;

            public Func()
            {
            }

            public Func(string name)
            {
                this.name = name;
            }

            public override List<ISequence> Resolve(Container container)
            {
                return container.Resolve<Func<List<ISequence>>>(name)();
            }
        }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("ScriptableObject")]
#endif
        [Serializable]
        public sealed class ScriptableObject : SequencesResolver
        {
            [SerializeField]
            private ScriptableSequences value;

            public ScriptableObject()
            {
            }

            public ScriptableObject(ScriptableSequences value)
            {
                this.value = value;
            }

            public override List<ISequence> Resolve(Container container)
            {
                return value.Sequences;
            }
        }
    }
}
