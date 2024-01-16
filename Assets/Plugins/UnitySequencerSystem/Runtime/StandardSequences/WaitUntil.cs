#if USS_SUPPORT_INPUT_SYSTEM
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnitySequencerSystem.Resolvers;
#if USS_SUPPORT_UNITASK
using Cysharp.Threading.Tasks;
#else
using System.Threading.Tasks;
using System.Collections;
#endif

namespace UnitySequencerSystem.StandardSequences
{
#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/WaitUntil")]
#endif
    [Serializable]
    public sealed class WaitUntil : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private BoolResolver conditionResolver;

        public WaitUntil()
        {
        }

        public WaitUntil(BoolResolver conditionResolver)
        {
            this.conditionResolver = conditionResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
#if USS_SUPPORT_UNITASK
            return UniTask.WaitUntil(() => conditionResolver.Resolve(container), cancellationToken: cancellationToken);
#else
            IEnumerator WaitUntil()
            {
                while (!conditionResolver.Resolve(container))
                {
                    yield return null;
                }
            }
            return MainThreadDispatcher.Instance.RunCoroutineAsTask(WaitUntil());
#endif
        }
    }
    /// <summary>
    /// キー入力を待機するシーケンス
    /// </summary>
#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/WaitUntil LegacyInput")]
#endif
    [Serializable]
    public sealed class WaitUntilLegacyInput : Sequence
    {
        public enum InputKeyType
        {
            Down,
            Up,
            Press,
        }

        [SerializeField]
        private InputKeyType keyPushType;

        [SerializeField]
        private KeyCode keyCode;

        public WaitUntilLegacyInput()
        {
        }

        public WaitUntilLegacyInput(InputKeyType keyPushType, KeyCode keyCode)
        {
            this.keyPushType = keyPushType;
            this.keyCode = keyCode;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
#if USS_SUPPORT_UNITASK
            return UniTask.WaitUntil(IsPushed, cancellationToken: cancellationToken);
#else
            IEnumerator WaitUntil()
            {
                while (!IsPushed())
                {
                    yield return null;
                }
            }
            return MainThreadDispatcher.Instance.RunCoroutineAsTask(WaitUntil());
#endif
        }

        private bool IsPushed()
        {
            return this.keyPushType switch
            {
                InputKeyType.Down => Input.GetKeyDown(this.keyCode),
                InputKeyType.Up => Input.GetKeyUp(this.keyCode),
                InputKeyType.Press => Input.GetKey(this.keyCode),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }

    /// <summary>
    /// <see cref="InputAction"/>のトリガーを待機するシーケンス
    /// </summary>
#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/WaitUntil InputActionTriggered")]
#endif
    [Serializable]
    public sealed class WaitUntilInputActionTriggered : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private InputActionResolver inputActionResolver;

#if USS_SUPPORT_UNITASK
        [SerializeField]
        private PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.Update;
#endif

        public WaitUntilInputActionTriggered()
        {
        }

#if USS_SUPPORT_UNITASK
        public WaitUntilInputActionTriggered(InputActionResolver inputActionResolver, PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.Update)
        {
            this.inputActionResolver = inputActionResolver;
            this.playerLoopTiming = playerLoopTiming;
        }
#else
        public WaitUntilInputActionTriggered(InputActionReference inputActionReference)
        {
            this.inputActionReference = inputActionReference;
        }
#endif


#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var inputAction = inputActionResolver.Resolve(container);
            inputAction.Enable();
#if USS_SUPPORT_UNITASK
            return UniTask.WaitUntil(() => IsPushed(inputAction), timing: playerLoopTiming, cancellationToken: cancellationToken);
#else
            IEnumerator WaitUntil()
            {
                while (!IsPushed(inputAction))
                {
                    yield return null;
                }
            }
            return MainThreadDispatcher.Instance.RunCoroutineAsTask(WaitUntil());
#endif
        }

        private bool IsPushed(InputAction inputAction)
        {
            return inputAction.triggered;
        }
    }
}
#endif
