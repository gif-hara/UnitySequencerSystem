using System;
using UnityEngine;

namespace UnitySequencerSystem.Resolvers
{
    public abstract class ColorResolver : IResolver<Color>
    {
        public abstract Color Resolve(Container container);

        [AddTypeMenu("Constant")]
        [Serializable]
        public sealed class Constant : ColorResolver
        {
            [SerializeField]
            private Color value;

            public override Color Resolve(Container container)
            {
                return value;
            }
        }

        [AddTypeMenu("Name")]
        [Serializable]
        public sealed class Name : ColorResolver
        {
            [SerializeField]
            private string name;

            public override Color Resolve(Container container)
            {
                return container.Resolve<Color>(name);
            }
        }

        [AddTypeMenu("Func")]
        [Serializable]
        public sealed class Func : ColorResolver
        {
            [SerializeField]
            private string name;

            public override Color Resolve(Container container)
            {
                return container.Resolve<Func<Color>>(name)();
            }
        }
    }
}
