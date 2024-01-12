#if USS_SUPPORT_INPUT_SYSTEM
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnitySequencerSystem.Resolvers;



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
    public sealed class InputActionReadValueVector2 : Sequence
    {
        [SerializeField]
        private InputActionReference inputActionReference;

        [SerializeField]
        private string vector2Name;

        public InputActionReadValueVector2()
        {
        }

        public InputActionReadValueVector2(InputActionReference inputActionReference)
        {
            this.inputActionReference = inputActionReference;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            inputActionReference.action.Enable();
            var value = inputActionReference.action.ReadValue<Vector2>();
            container.RegisterOrReplace(vector2Name, value);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Input Action Performed")]
#endif
    [Serializable]
    public sealed class InputActionPerformed : Sequence
    {
        [SerializeField]
        private InputActionReference inputActionReference;

        [SerializeField]
        private SequencesResolver sequencesResolver;

        public InputActionPerformed()
        {
        }

        public InputActionPerformed(InputActionReference inputActionReference, SequencesResolver sequencesResolver)
        {
            this.inputActionReference = inputActionReference;
            this.sequencesResolver = sequencesResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            inputActionReference.action.Enable();
            inputActionReference.action.performed += OnPerformed;
            void OnPerformed(InputAction.CallbackContext context)
            {
                var sequences = sequencesResolver.Resolve(container);
                var sequencer = new Sequencer(container, sequences);
                sequencer.PlayAsync(cancellationToken).Forget();
            }
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }
}
#endif
