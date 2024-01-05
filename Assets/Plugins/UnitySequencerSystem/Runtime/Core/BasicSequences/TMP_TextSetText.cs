using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace HK.UnitySequencerSystem
{
    /// <summary>
    /// <see cref="TMP_Text"/>にテキストを設定するシーケンス
    /// </summary>
    [Serializable]
    public sealed class TMP_TextSetText : ISequence
    {
        [SerializeField]
        private string targetName;

        [SerializeField, Multiline]
        private string text;

        public TMP_TextSetText()
        {
        }

        public TMP_TextSetText(string targetName, string text)
        {
            this.targetName = targetName;
            this.text = text;
        }

        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
        {
            var target = container.Resolve<TMP_Text>(this.targetName);
            target.SetText(this.text);
            return UniTask.CompletedTask;
        }
    }
}
