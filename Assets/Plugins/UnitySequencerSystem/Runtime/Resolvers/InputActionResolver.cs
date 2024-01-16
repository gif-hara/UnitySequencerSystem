#if USS_SUPPORT_INPUT_SYSTEM
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UnitySequencerSystem.Resolvers
{
    public abstract class InputActionResolver : IResolver<InputAction>
    {
        public abstract InputAction Resolve(Container container);

        public sealed class ReferenceInputActionReference : InputActionResolver
        {
            [SerializeField]
            private InputActionReference inputActionReference;

            public override InputAction Resolve(Container container)
            {
                return inputActionReference.action;
            }
        }
    }
}
#endif
