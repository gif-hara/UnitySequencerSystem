using System;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;


#if USS_SUPPORT_UNITASK
using Cysharp.Threading.Tasks;
#else
using System.Linq;
using System.Threading.Tasks;
#endif


namespace UnitySequencerSystem.StandardSequences
{
#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Input Action Read Value/Vector2")]
#endif
    [Serializable]
    public sealed class InputActionReadValueVector2 : ISequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private InputActionReference inputActionReference;

        [SerializeField]
        private string registerName;

        public InputActionReadValueVector2()
        {
        }

        public InputActionReadValueVector2(InputActionReference inputActionReference)
        {
            this.inputActionReference = inputActionReference;
        }

#if USS_SUPPORT_UNITASK
        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var value = inputActionReference.action.ReadValue<Vector2>();
            container.RegisterOrReplace(registerName, value);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }
}
