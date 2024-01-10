using System;
using System.Threading;
using UnityEngine;
#if USS_UNI_TASK_SUPPORT
using Cysharp.Threading.Tasks;
#else
using System.Threading.Tasks;
#endif

namespace HK.UnitySequencerSystem.Standard
{
    /// <summary>
    /// キー入力を待機するシーケンス
    /// </summary>
    [AddTypeMenu("Standard/WaitUntil LegacyInput")]
    [Serializable]
    public sealed class WaitUntilLegacyInput : ISequence
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

        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
        {
            return UniTask.WaitUntil(IsPushed, cancellationToken: cancellationToken);
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
}
