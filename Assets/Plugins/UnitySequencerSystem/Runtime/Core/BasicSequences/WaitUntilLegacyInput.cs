using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace HK.UnitySequencerSystem
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
