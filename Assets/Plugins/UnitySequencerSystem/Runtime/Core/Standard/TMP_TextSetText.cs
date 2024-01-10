#if USS_TMP_SUPPORT
using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using HK.UnitySequencerSystem.Resolvers;
using TMPro;
using UnityEngine;

namespace HK.UnitySequencerSystem.Standard
{
    /// <summary>
    /// <see cref="TMP_Text"/>にテキストを設定するシーケンス
    /// </summary>
    [AddTypeMenu("Standard/TMP_Text SetText")]
    [Serializable]
    public sealed class TMP_TextSetText : ISequence
    {
#if USS_SUB_CLASS_SELECTOR_SUPPORT
        [SubclassSelector]
#endif
        [SerializeReference]
        private TMP_TextResolver targetResolver;

#if USS_SUB_CLASS_SELECTOR_SUPPORT
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver textResolver;

        public TMP_TextSetText()
        {
        }

        public TMP_TextSetText(TMP_TextResolver targetResolver, StringResolver textResolver)
        {
            this.targetResolver = targetResolver;
            this.textResolver = textResolver;
        }

        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
        {
            var target = targetResolver.Resolve(container);
            var text = textResolver.Resolve(container);
            target.SetText(text);
            return UniTask.CompletedTask;
        }
    }
}
#endif
