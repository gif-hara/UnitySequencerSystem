using System;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace HK.UnitySequencerSystem
{
    /// <summary>
    /// <see cref="ISequence"/>を順番に実行するクラス
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
            try
            {
                foreach (var s in this.sequences)
                {
                    await s.PlayAsync(this.container, cancellationToken);
                }
            }
            catch (OperationCanceledException)
            {
                // Do nothing
            }
        }

        public async UniTask PlayLoopAsync(PlayerLoopTiming playerLoopTiming, CancellationToken cancellationToken)
        {
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    foreach (var s in this.sequences)
                    {
                        await s.PlayAsync(this.container, cancellationToken);
                    }
                    await UniTask.Yield(playerLoopTiming, cancellationToken: cancellationToken);
                }
            }
            catch (OperationCanceledException)
            {
                // Do nothing
            }
        }
    }
}
