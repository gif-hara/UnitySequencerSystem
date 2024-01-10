using System;
using System.Collections.Generic;
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
    /// シーケンスを実行し、どれかが完了したら終了するシーケンス
    /// </summary>
    [AddTypeMenu("Standard/When Any")]
    [Serializable]
    public sealed class WhenAny : ISequence
    {
#if USS_SUB_CLASS_SELECTOR_SUPPORT
        [SubclassSelector]
#endif
        [SerializeReference]
        private List<ISequence> sequences;

        public WhenAny()
        {
        }

        public WhenAny(List<ISequence> sequences)
        {
            this.sequences = sequences;
        }

        public async UniTask PlayAsync(Container container, CancellationToken cancellationToken)
        {
            await UniTask.WhenAny(sequences.Select(s => s.PlayAsync(container, cancellationToken)));
        }
    }
}
