using System;
using UnityEngine;

namespace UnitySequencerSystem.Resolvers
{
    public abstract class StringResolver : IResolver<string>
    {
        public abstract string Resolve(Container container);

        [AddTypeMenu("Constant")]
        [Serializable]
        public sealed class Constant : StringResolver
        {
            [SerializeField]
            private string value;

            public override string Resolve(Container container)
            {
                return value;
            }
        }

        [AddTypeMenu("Name")]
        [Serializable]
        public sealed class NameString : StringResolver
        {
            [SerializeField]
            private string name;

            public override string Resolve(Container container)
            {
                return container.Resolve<string>(name);
            }
        }
    }
}
