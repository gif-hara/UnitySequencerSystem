using System;
using UnityEngine;

namespace HK.UnitySequencerSystem.Resolvers
{
    public abstract class StringResolver : IResolver<string>
    {
        public abstract string Resolve(Container container);

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
