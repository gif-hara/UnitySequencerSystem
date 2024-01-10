#if USS_INPUT_SYSTEM_SUPPORT
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
#if USS_UNI_TASK_SUPPORT
using Cysharp.Threading.Tasks;
#else
using System.Threading.Tasks;
#endif

namespace HK.UnitySequencerSystem.Standard
{
    /// <summary>
    /// <see cref="InputAction"/>のトリガーを待機するシーケンス
    /// </summary>
    [AddTypeMenu("Standard/WaitUntil InputActionTriggered")]
    [Serializable]
    public sealed class WaitUntilInputActionTriggered : ISequence
    {
        [SerializeField]
        private InputActionReference inputActionReference;

        [SerializeField]
        private PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.Update;

        public WaitUntilInputActionTriggered()
        {
        }

        public WaitUntilInputActionTriggered(InputActionReference inputActionReference, PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.Update)
        {
            this.inputActionReference = inputActionReference;
            this.playerLoopTiming = playerLoopTiming;
        }

        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
        {
            inputActionReference.action.Enable();
            return UniTask.WaitUntil(IsPushed, timing: playerLoopTiming, cancellationToken: cancellationToken);
        }

        private bool IsPushed()
        {
            return this.inputActionReference.action.triggered;
        }
    }
}
#endif
