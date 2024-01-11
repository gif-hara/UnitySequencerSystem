#if USS_TMP_SUPPORT
using System;
using System.Threading;
using HK.UnitySequencerSystem.Resolvers;
using TMPro;
using UnityEngine;
#if USS_SUPPORT_UNITASK
using Cysharp.Threading.Tasks;
#else
using System.Threading.Tasks;
#endif


namespace HK.UnitySequencerSystem.Standard
{
    /// <summary>
    /// <see cref="TMP_Text"/>にテキストを設定するシーケンス
    /// </summary>
    [AddTypeMenu("Standard/TMP_Text SetText")]
    [Serializable]
    public sealed class TMP_TextSetText : ISequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private TMP_TextResolver targetResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
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

#if USS_SUPPORT_UNITASK
        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var target = targetResolver.Resolve(container);
            var text = textResolver.Resolve(container);
            target.SetText(text);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }
}
#endif
