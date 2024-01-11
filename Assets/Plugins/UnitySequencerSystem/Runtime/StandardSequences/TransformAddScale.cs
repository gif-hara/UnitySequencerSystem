using System;
using System.Threading;
using UnitySequencerSystem.Resolvers;
using UnityEngine;
#if USS_SUPPORT_UNITASK
using Cysharp.Threading.Tasks;
#else
using System.Threading.Tasks;
#endif

namespace UnitySequencerSystem.Standard
{
    /// <summary>
    /// Represents a sequence that adds scale to a target <see cref="Transform"/>.
    /// </summary>
    [AddTypeMenu("Standard/Transform Add Scale")]
    [Serializable]
    public sealed class TransformAddScale : ISequence
    {
        /// <summary>
        /// The resolver for the target <see cref="Transform"/>.
        /// </summary>
        #if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
        #endif
        [SerializeReference]
        private TransformResolver targetResolver;

        /// <summary>
        /// The resolver for the scale <see cref="Vector3"/>.
        /// </summary>
        #if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
        #endif
        [SerializeReference]
        private Vector3Resolver scaleResolver;

        /// <summary>
        /// The resolver for the delta time.
        /// </summary>
        #if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
        #endif
        [SerializeReference]
        private DeltaTimeResolver deltaTimeResolver;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransformAddScale"/> class.
        /// </summary>
        public TransformAddScale()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransformAddScale"/> class with the specified resolvers.
        /// </summary>
        /// <param name="targetResolver">The resolver for the target <see cref="Transform"/>.</param>
        /// <param name="scaleResolver">The resolver for the scale <see cref="Vector3"/>.</param>
        /// <param name="deltaTimeResolver">The resolver for the delta time.</param>
        public TransformAddScale(
            TransformResolver targetResolver,
            Vector3Resolver scaleResolver,
            DeltaTimeResolver deltaTimeResolver
        )
        {
            this.targetResolver = targetResolver;
            this.scaleResolver = scaleResolver;
            this.deltaTimeResolver = deltaTimeResolver;
        }

        /// <summary>
        /// Plays the sequence asynchronously.
        /// </summary>
        /// <param name="container">The container for resolving dependencies.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        #if USS_SUPPORT_UNITASK
        public UniTask PlayAsync(Container container, CancellationToken cancellationToken)
        #else
        public Task PlayAsync(Container container, CancellationToken cancellationToken)
        #endif
        {
            var target = this.targetResolver.Resolve(container);
            var scale = this.scaleResolver.Resolve(container);
            var deltaTime = this.deltaTimeResolver.Resolve(container);
            target.localScale += scale * deltaTime;
            #if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
            #else
            return Task.CompletedTask;
            #endif
        }
    }
}
