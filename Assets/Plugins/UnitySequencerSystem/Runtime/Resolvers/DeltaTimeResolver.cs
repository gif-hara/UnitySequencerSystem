using System;
using UnityEngine;

namespace UnitySequencerSystem.Resolvers
{
    public abstract class DeltaTimeResolver : IResolver<float>
    {
        public abstract float Resolve(Container container);

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Constant")]
#endif
        [Serializable]
        public sealed class Constant : DeltaTimeResolver
        {
            [SerializeField]
            private float value;

            public Constant()
            {
            }

            public override float Resolve(Container container)
            {
                return value;
            }
        }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("UnityEngine DeltaTime")]
#endif
        [Serializable]
        public sealed class UnityEngineDeltaTime : DeltaTimeResolver
        {
            public UnityEngineDeltaTime()
            {
            }

            public override float Resolve(Container container)
            {
                return Time.deltaTime;
            }
        }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("UnityEngine FixedDeltaTime")]
#endif
        [Serializable]
        public sealed class UnityEngineFixedDeltaTime : DeltaTimeResolver
        {
            public UnityEngineFixedDeltaTime()
            {
            }

            public override float Resolve(Container container)
            {
                return Time.fixedDeltaTime;
            }
        }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("UnityEngine UnscaledDeltaTime")]
#endif
        [Serializable]
        public sealed class UnityEngineUnscaledTime : DeltaTimeResolver
        {
            public UnityEngineUnscaledTime()
            {
            }

            public override float Resolve(Container container)
            {
                return Time.unscaledDeltaTime;
            }
        }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Name")]
#endif
        [Serializable]
        public sealed class Name : DeltaTimeResolver
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

            public override float Resolve(Container container)
            {
                return container.Resolve<float>(name);
            }
        }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Func")]
#endif
        [Serializable]
        public sealed class Func : DeltaTimeResolver
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

            public override float Resolve(Container container)
            {
                return container.Resolve<Func<float>>(name)();
            }
        }
    }
}
