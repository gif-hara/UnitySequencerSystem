using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine.Assertions;
#if USS_SUPPORT_UNITASK
using Cysharp.Threading.Tasks;
#else
using System.Threading.Tasks;
#endif


namespace HK.UnitySequencerSystem
{
    /// <summary>
    /// <see cref="ISequence"/>を順番に実行するクラス
    /// </summary>
    public sealed class Sequencer
    {
        private readonly Container container;

        private readonly List<ISequence> sequences;

        public Sequencer(Container container, List<ISequence> sequences)
        {
            Assert.IsNotNull(container, $"[{nameof(Sequencer)}] {nameof(container)} is null");
            Assert.IsNotNull(sequences, $"[{nameof(Sequencer)}] {nameof(sequences)} is null");
            this.container = container;
            this.sequences = sequences;
        }

        /// <summary>
        /// シーケンスを実行する
        /// </summary>
#if USS_SUPPORT_UNITASK
        public async UniTask PlayAsync(CancellationToken cancellationToken)
#else
        public async Task PlayAsync(CancellationToken cancellationToken)
#endif
        {
            try
            {
                foreach (var sequence in this.sequences)
                {
                    await sequence.PlayAsync(this.container, cancellationToken);
                }
            }
            catch (OperationCanceledException)
            {
                // Do nothing
            }
        }
    }
}
