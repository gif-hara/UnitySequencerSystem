using System;
using System.Threading;
using UnityEngine;
using HK.UnitySequencerSystem.Core;
using System.Collections;


#if USS_SUPPORT_UNITASK
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

#if USS_SUPPORT_UNITASK
        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public Task PlayAsync(Container container, CancellationToken cancellationToken)
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
}
