using Cysharp.Threading.Tasks;

namespace HK.UnitySequencerSystem
{
    public interface ISequencer
    {
        /// <summary>
        /// シーケンスを再生する
        /// </summary>
        UniTask PlayAsync(Container container);
    }
}
