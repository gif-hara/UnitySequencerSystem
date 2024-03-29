using System.Threading;
#if USS_SUPPORT_UNITASK
using Cysharp.Threading.Tasks;
#else
using System.Threading.Tasks;
#endif


namespace UnitySequencerSystem
{

    public abstract class Sequence : ISequence
    {
#if USS_SUPPORT_UNITASK
        public abstract UniTask PlayAsync(Container container, CancellationToken cancellationToken);
#else
        public abstract Task PlayAsync(Container container, CancellationToken cancellationToken);
#endif
    }

    public interface ISequence
    {
#if USS_SUPPORT_UNITASK
        UniTask PlayAsync(Container container, CancellationToken cancellationToken);
#else
        Task PlayAsync(Container container, CancellationToken cancellationToken);
#endif
    }
}
