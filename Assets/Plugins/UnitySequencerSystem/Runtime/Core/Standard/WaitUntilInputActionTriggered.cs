#if USS_INPUT_SYSTEM_SUPPORT
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using HK.UnitySequencerSystem.Core;


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

#if USS_UNI_TASK_SUPPORT
        [SerializeField]
        private PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.Update;
#endif

        public WaitUntilInputActionTriggered()
        {
        }

#if USS_UNI_TASK_SUPPORT
        public WaitUntilInputActionTriggered(InputActionReference inputActionReference, PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.Update)
        {
            this.inputActionReference = inputActionReference;
            this.playerLoopTiming = playerLoopTiming;
        }
#else
        public WaitUntilInputActionTriggered(InputActionReference inputActionReference)
        {
            this.inputActionReference = inputActionReference;
        }
#endif


#if USS_UNI_TASK_SUPPORT
        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            inputActionReference.action.Enable();
#if USS_UNI_TASK_SUPPORT
            return UniTask.WaitUntil(IsPushed, timing: playerLoopTiming, cancellationToken: cancellationToken);
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
            return this.inputActionReference.action.triggered;
        }
    }
}
#endif
