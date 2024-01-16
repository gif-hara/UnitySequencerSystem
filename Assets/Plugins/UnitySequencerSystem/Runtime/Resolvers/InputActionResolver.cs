#if USS_SUPPORT_INPUT_SYSTEM
using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UnitySequencerSystem.Resolvers
{
    public abstract class InputActionResolver : IResolver<InputAction>
    {
        public abstract InputAction Resolve(Container container);
    }
}
#endif
