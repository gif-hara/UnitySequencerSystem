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
    [AddTypeMenu("Standard/Input Action Read Value/Vector3")]
#endif
    [Serializable]
    public sealed class InputActionReadValueVector3 : Sequence
    {
        [SerializeField]
        private InputActionReference inputActionReference;

        [SerializeField]
        private string vector3Name;

        public InputActionReadValueVector3()
        {
        }

        public InputActionReadValueVector3(InputActionReference inputActionReference)
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
            var value = inputActionReference.action.ReadValue<Vector3>();
            container.RegisterOrReplace(vector3Name, value);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Input Action Read Value/bool")]
#endif
    [Serializable]
    public sealed class InputActionReadValueBool : Sequence
    {
        [SerializeField]
        private InputActionReference inputActionReference;

        [SerializeField]
        private string boolName;

        public InputActionReadValueBool()
        {
        }

        public InputActionReadValueBool(InputActionReference inputActionReference)
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
            var value = inputActionReference.action.ReadValue<bool>();
            container.RegisterOrReplace(boolName, value);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Input Action Read Value/float")]
#endif
    [Serializable]
    public sealed class InputActionReadValueFloat : Sequence
    {
        [SerializeField]
        private InputActionReference inputActionReference;

        [SerializeField]
        private string floatName;

        public InputActionReadValueFloat()
        {
        }

        public InputActionReadValueFloat(InputActionReference inputActionReference)
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
            var value = inputActionReference.action.ReadValue<float>();
            container.RegisterOrReplace(floatName, value);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Input Action Phase")]
#endif
    [Serializable]
    public sealed class InputActionPhase : Sequence
    {
        [SerializeField]
        private InputActionReference inputActionReference;

        [SerializeField]
        private string phaseName;

        public InputActionPhase()
        {
        }

        public InputActionPhase(InputActionReference inputActionReference)
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
            var value = inputActionReference.action.phase;
            container.RegisterOrReplace(phaseName, value);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }
}
#endif
