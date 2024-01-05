using System.Threading;
using Cysharp.Threading.Tasks;

namespace HK.UnitySequencerSystem
{
    /// <summary>
    /// シーケンスを表すインターフェイス
    /// </summary>
    public interface ISequence
    {
        /// <summary>
        /// シーケンスを再生する
        /// </summary>
        UniTask PlayAsync(Container container, CancellationToken cancellationToken);
    }
}
