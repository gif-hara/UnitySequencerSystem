using System;
using UnityEngine;

namespace UnitySequencerSystem.Resolvers
{
    public abstract class DeltaTimeResolver : IResolver<float>
    {
        public abstract float Resolve(Container container);

        [AddTypeMenu("Constant")]
        [Serializable]
        public sealed class Constant : DeltaTimeResolver
        {
            [SerializeField]
            private float value;

            public override float Resolve(Container container)
            {
                return value;
            }
        }

        [AddTypeMenu("UnityEngine DeltaTime")]
        [Serializable]
        public sealed class UnityEngineDeltaTime : DeltaTimeResolver
        {
            public override float Resolve(Container container)
            {
                return Time.deltaTime;
            }
        }

        [AddTypeMenu("UnityEngine FixedDeltaTime")]
        [Serializable]
        public sealed class UnityEngineFixedDeltaTime : DeltaTimeResolver
        {
            public override float Resolve(Container container)
            {
                return Time.fixedDeltaTime;
            }
        }

        [AddTypeMenu("UnityEngine UnscaledDeltaTime")]
        [Serializable]
        public sealed class UnityEngineUnscaledTime : DeltaTimeResolver
        {
            public override float Resolve(Container container)
            {
                return Time.unscaledDeltaTime;
            }
        }

        [AddTypeMenu("Name")]
        [Serializable]
        public sealed class Name : DeltaTimeResolver
        {
            [SerializeField]
            private string name;

            public override float Resolve(Container container)
            {
                return container.Resolve<float>(name);
            }
        }

        [AddTypeMenu("Func")]
        [Serializable]
        public sealed class Func : DeltaTimeResolver
        {
            [SerializeField]
            private string name;

            public override float Resolve(Container container)
            {
                return container.Resolve<Func<float>>(name)();
            }
        }
    }
}
