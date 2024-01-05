using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HK.UnitySequencerSystem
{
    /// <summary>
    /// <see cref="InputAction"/>のトリガーを待機するシーケンス
    /// </summary>
    [Serializable]
    public sealed class WaitInputActionTriggered : ISequence
    {
        [SerializeField]
        private InputActionReference inputActionReference;

        [SerializeField]
        private PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.Update;

        public WaitInputActionTriggered()
        {
        }

        public WaitInputActionTriggered(InputActionReference inputActionReference, PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.Update)
        {
            this.inputActionReference = inputActionReference;
            this.playerLoopTiming = playerLoopTiming;
        }

        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
        {
            inputActionReference.action.Enable();
            return UniTask.WaitUntil(() => IsPushed(), timing: playerLoopTiming, cancellationToken: cancellationToken);
        }

        private bool IsPushed()
        {
            return this.inputActionReference.action.triggered;
        }
    }
}
