using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace HK.UnitySequencerSystem
{
    /// <summary>
    /// シーケンサーを表すクラス
    /// </summary>
    public sealed class Sequencer
    {
        private readonly Container container;

        private readonly IEnumerable<ISequence> sequences;

        public Sequencer(Container container, IEnumerable<ISequence> sequences)
        {
            this.container = container;
            this.sequences = sequences;
        }

        public async UniTask PlayAsync(CancellationToken cancellationToken)
        {
            foreach (var s in this.sequences)
            {
                await s.PlayAsync(this.container, cancellationToken);
            }
        }
    }
}
