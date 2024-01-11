using System;
using UnityEngine;

namespace UnitySequencerSystem.Resolvers
{
    public abstract class GameObjectResolver : IResolver<GameObject>
    {
        public abstract GameObject Resolve(Container container);

        [Serializable]
        public sealed class ReferenceGameObject : GameObjectResolver
        {
            [SerializeField]
            private GameObject target;

            public override GameObject Resolve(Container container)
            {
                return target;
            }
        }

        [Serializable]
        public sealed class NameGameObject : GameObjectResolver
        {
            [SerializeField]
            private string name;

            public override GameObject Resolve(Container container)
            {
                return container.Resolve<GameObject>(name);
            }
        }
    }
}
