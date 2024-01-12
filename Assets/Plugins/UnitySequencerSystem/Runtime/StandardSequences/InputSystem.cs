#if USS_SUPPORT_INPUT_SYSTEM
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
    [AddTypeMenu("Standard/Input Action Read Value Vector2")]
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

        public InputActionReadValueVector2(InputActionReference inputActionReference, string vector2Name)
        {
            this.inputActionReference = inputActionReference;
            this.vector2Name = vector2Name;
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
    [AddTypeMenu("Standard/Input Action Read Value Vector3")]
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

        public InputActionReadValueVector3(InputActionReference inputActionReference, string vector3Name)
        {
            this.inputActionReference = inputActionReference;
            this.vector3Name = vector3Name;
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
    [AddTypeMenu("Standard/Input Action Read Value Float")]
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

        public InputActionReadValueFloat(InputActionReference inputActionReference, string floatName)
        {
            this.inputActionReference = inputActionReference;
            this.floatName = floatName;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            inputActionReference.action.Enable();
            var value = inputActionReference.action.ReadValue<float>();
            Debug.Log(value);
            container.RegisterOrReplace(floatName, value);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Input Action Was Pressed This Frame")]
#endif
    [Serializable]
    public sealed class InputActionWasPressedThisFrame : Sequence
    {
        [SerializeField]
        private InputActionReference inputActionReference;

        [SerializeField]
        private string boolName;

        public InputActionWasPressedThisFrame()
        {
        }

        public InputActionWasPressedThisFrame(InputActionReference inputActionReference, string boolName)
        {
            this.inputActionReference = inputActionReference;
            this.boolName = boolName;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            inputActionReference.action.Enable();
            var value = inputActionReference.action.WasPressedThisFrame();
            container.RegisterOrReplace(boolName, value);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Input Action Was Released This Frame")]
#endif
    [Serializable]
    public sealed class InputActionWasReleasedThisFrame : Sequence
    {
        [SerializeField]
        private InputActionReference inputActionReference;

        [SerializeField]
        private string boolName;

        public InputActionWasReleasedThisFrame()
        {
        }

        public InputActionWasReleasedThisFrame(InputActionReference inputActionReference, string boolName)
        {
            this.inputActionReference = inputActionReference;
            this.boolName = boolName;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            inputActionReference.action.Enable();
            var value = inputActionReference.action.WasReleasedThisFrame();
            container.RegisterOrReplace(boolName, value);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Input Action Was Performed")]
#endif
    [Serializable]
    public sealed class InputActionWasPerformedThisFrame : Sequence
    {
        [SerializeField]
        private InputActionReference inputActionReference;

        [SerializeField]
        private string boolName;

        public InputActionWasPerformedThisFrame()
        {
        }

        public InputActionWasPerformedThisFrame(InputActionReference inputActionReference, string boolName)
        {
            this.inputActionReference = inputActionReference;
            this.boolName = boolName;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            inputActionReference.action.Enable();
            var value = inputActionReference.action.WasPerformedThisFrame();
            container.RegisterOrReplace(boolName, value);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }
}
#endif
