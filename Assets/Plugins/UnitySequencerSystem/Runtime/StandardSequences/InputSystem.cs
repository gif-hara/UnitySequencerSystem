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
    [AddTypeMenu("Standard/Input Action Read Value Vector2")]
#endif
    [Serializable]
    public sealed class InputActionReadValueVector2 : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private InputActionResolver inputActionResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver vector2NameResolver;

        public InputActionReadValueVector2()
        {
        }

        public InputActionReadValueVector2(InputActionResolver inputActionResolver, StringResolver vector2NameResolver)
        {
            this.inputActionResolver = inputActionResolver;
            this.vector2NameResolver = vector2NameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var inputAction = inputActionResolver.Resolve(container);
            inputAction.Enable();
            var value = inputAction.ReadValue<Vector2>();
            var vector2Name = vector2NameResolver.Resolve(container);
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
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private InputActionResolver inputActionResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver vector3NameResolver;

        public InputActionReadValueVector3()
        {
        }

        public InputActionReadValueVector3(InputActionResolver inputActionResolver, StringResolver vector3NameResolver)
        {
            this.inputActionResolver = inputActionResolver;
            this.vector3NameResolver = vector3NameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var inputAction = inputActionResolver.Resolve(container);
            inputAction.Enable();
            var value = inputAction.ReadValue<Vector3>();
            var vector3Name = vector3NameResolver.Resolve(container);
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
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private InputActionResolver inputActionResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver floatNameResolver;

        public InputActionReadValueFloat()
        {
        }

        public InputActionReadValueFloat(InputActionResolver inputActionResolver, StringResolver floatNameResolver)
        {
            this.inputActionResolver = inputActionResolver;
            this.floatNameResolver = floatNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var inputAction = inputActionResolver.Resolve(container);
            inputAction.Enable();
            var value = inputAction.ReadValue<float>();
            var floatName = floatNameResolver.Resolve(container);
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
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private InputActionResolver inputActionResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver boolNameResolver;

        public InputActionWasPressedThisFrame()
        {
        }

        public InputActionWasPressedThisFrame(InputActionResolver inputActionResolver, StringResolver boolNameResolver)
        {
            this.inputActionResolver = inputActionResolver;
            this.boolNameResolver = boolNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var inputAction = inputActionResolver.Resolve(container);
            inputAction.Enable();
            var value = inputAction.WasPressedThisFrame();
            var boolName = boolNameResolver.Resolve(container);
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
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private InputActionResolver inputActionResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver boolNameResolver;

        public InputActionWasReleasedThisFrame()
        {
        }

        public InputActionWasReleasedThisFrame(InputActionResolver inputActionResolver, StringResolver boolNameResolver)
        {
            this.inputActionResolver = inputActionResolver;
            this.boolNameResolver = boolNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var inputAction = inputActionResolver.Resolve(container);
            inputAction.Enable();
            var value = inputAction.WasReleasedThisFrame();
            var boolName = boolNameResolver.Resolve(container);
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
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private InputActionResolver inputActionResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver boolNameResolver;

        public InputActionWasPerformedThisFrame()
        {
        }

        public InputActionWasPerformedThisFrame(InputActionResolver inputActionResolver, StringResolver boolNameResolver)
        {
            this.inputActionResolver = inputActionResolver;
            this.boolNameResolver = boolNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var inputAction = inputActionResolver.Resolve(container);
            inputAction.Enable();
            var value = inputAction.WasPerformedThisFrame();
            var boolName = boolNameResolver.Resolve(container);
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
