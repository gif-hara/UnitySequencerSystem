using System.Threading;
#if USS_SUPPORT_UNITASK
using Cysharp.Threading.Tasks;
#else
using System.Threading.Tasks;
#endif


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
#if USS_SUPPORT_UNITASK
        UniTask PlayAsync(Container container, CancellationToken cancellationToken);
#else
                Task PlayAsync(Container container, CancellationToken cancellationToken);
#endif
        }
}
