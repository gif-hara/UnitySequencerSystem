using System;
using UnityEngine;

namespace UnitySequencerSystem.Resolvers
{
    public abstract class GameObjectResolver : IResolver<GameObject>
    {
        public abstract GameObject Resolve(Container container);

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Reference")]
#endif
        [Serializable]
        public sealed class ReferenceGameObject : GameObjectResolver
        {
            [SerializeField]
            private GameObject target;

            public ReferenceGameObject()
            {
            }

            public ReferenceGameObject(GameObject target)
            {
                this.target = target;
            }

            public override GameObject Resolve(Container container)
            {
                return target;
            }
        }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("Name")]
#endif
        [Serializable]
        public sealed class NameGameObject : GameObjectResolver
        {
            [SerializeField]
            private string name;

            public NameGameObject()
            {
            }

            public NameGameObject(string name)
            {
                this.name = name;
            }

            public override GameObject Resolve(Container container)
            {
                return container.Resolve<GameObject>(name);
            }
        }
    }
}
