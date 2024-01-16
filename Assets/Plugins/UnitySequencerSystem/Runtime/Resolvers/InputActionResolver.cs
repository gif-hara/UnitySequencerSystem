#if USS_SUPPORT_INPUT_SYSTEM
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UnitySequencerSystem.Resolvers
{
    public abstract class InputActionResolver : IResolver<InputAction>
    {
        public abstract InputAction Resolve(Container container);

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("ReferenceInputActionReference")]
#endif
        [Serializable]
        public sealed class ReferenceInputActionReference : InputActionResolver
        {
            [SerializeField]
            private InputActionReference inputActionReference;

            public override InputAction Resolve(Container container)
            {
                return inputActionReference.action;
            }
        }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("NameInputActionReference")]
#endif
        [Serializable]
        public sealed class NameInputActionReference : InputActionResolver
        {
            [SerializeField]
            private string inputActionName;

            public override InputAction Resolve(Container container)
            {
                return container.Resolve<InputActionReference>(inputActionName).action;
            }
        }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [AddTypeMenu("ReferenceInputAction")]
#endif
        [Serializable]
        public sealed class ReferenceInputAction : InputActionResolver
        {
            [SerializeField]
            private InputAction inputAction;

            public override InputAction Resolve(Container container)
            {
                return inputAction;
            }
        }
    }
}
#endif
