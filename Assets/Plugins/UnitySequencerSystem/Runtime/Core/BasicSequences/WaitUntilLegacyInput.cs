using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace HK.UnitySequencerSystem
{
    /// <summary>
    /// キー入力を待機するシーケンス
    /// </summary>
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
            return UniTask.WaitUntil(() => IsPushed(), cancellationToken: cancellationToken);
        }

        private bool IsPushed()
        {
            switch (this.keyPushType)
            {
                case InputKeyType.Down:
                    return Input.GetKeyDown(this.keyCode);
                case InputKeyType.Up:
                    return Input.GetKeyUp(this.keyCode);
                case InputKeyType.Press:
                    return Input.GetKey(this.keyCode);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
