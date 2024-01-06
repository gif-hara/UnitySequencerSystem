using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine.Assertions;

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
        public async UniTask PlayAsync(CancellationToken cancellationToken)
        {
            try
            {
                foreach (var s in this.sequences)
                {
                    await PlayAsync(s, cancellationToken);
                }
            }
            catch (OperationCanceledException)
            {
                // Do nothing
            }
        }

        /// <summary>
        /// シーケンスをループして実行する
        /// </summary>
        public async UniTask PlayLoopAsync(PlayerLoopTiming playerLoopTiming, CancellationToken cancellationToken)
        {
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    foreach (var s in this.sequences)
                    {
                        await PlayAsync(s, cancellationToken);
                    }
                    await UniTask.Yield(playerLoopTiming, cancellationToken: cancellationToken);
                }
            }
            catch (OperationCanceledException)
            {
                // Do nothing
            }
        }

        /// <summary>
        /// シーケンスを実行する
        /// </summary>
        private UniTask PlayAsync(ISequence sequence, CancellationToken cancellationToken)
        {
            Assert.IsNotNull(sequence, $"[{nameof(Sequencer)}] {nameof(sequence)} is null");
            return sequence.PlayAsync(this.container, cancellationToken);
        }
    }
}
