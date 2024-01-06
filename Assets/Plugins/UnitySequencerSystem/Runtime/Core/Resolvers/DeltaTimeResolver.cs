using System;
using UnityEngine;

namespace HK.UnitySequencerSystem.Resolvers
{
    public abstract class DeltaTimeResolver : IResolver<float>
    {
        public abstract float Resolve(Container container);

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

        [Serializable]
        public sealed class UnityEngineDeltaTime : DeltaTimeResolver
        {
            public override float Resolve(Container container)
            {
                return Time.deltaTime;
            }
        }

        [Serializable]
        public sealed class UnityEngineFixedDeltaTime : DeltaTimeResolver
        {
            public override float Resolve(Container container)
            {
                return Time.fixedDeltaTime;
            }
        }

        [Serializable]
        public sealed class UnityEngineUnscaledTime : DeltaTimeResolver
        {
            public override float Resolve(Container container)
            {
                return Time.unscaledDeltaTime;
            }
        }
    }
}