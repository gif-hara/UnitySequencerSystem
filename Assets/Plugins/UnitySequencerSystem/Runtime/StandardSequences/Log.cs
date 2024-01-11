using System;
using System.Threading;
using UnityEngine;
using UnitySequencerSystem.Resolvers;

#if USS_SUPPORT_UNITASK
using Cysharp.Threading.Tasks;
#else
using System.Threading.Tasks;
#endif

namespace UnitySequencerSystem.StandardSequences
{
#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Log")]
#endif
    [Serializable]
    public sealed class Log : ISequence
    {
        [SerializeField]
        private string message;

        public Log()
        {
        }

        public Log(string message)
        {
            this.message = message;
        }

#if USS_SUPPORT_UNITASK
        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            Debug.Log(this.message);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Log Vector3")]
#endif
    [Serializable]
    public sealed class LogVector3 : ISequence
    {
        [SerializeField]
        private string header;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver vector3Resolver;

        public LogVector3()
        {
        }

        public LogVector3(string header, Vector3Resolver vector3Resolver)
        {
            this.header = header;
            this.vector3Resolver = vector3Resolver;
        }

#if USS_SUPPORT_UNITASK
        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            Debug.Log($"{header}{vector3Resolver.Resolve(container)}");
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }
}
