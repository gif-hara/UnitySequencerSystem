#if USS_SUPPORT_LIT_MOTION
using System;
using Cysharp.Threading.Tasks;
using LitMotion;
using UnityEngine;
using UnitySequencerSystem.Resolvers;

namespace UnitySequencerSystem.LitMotion
{
    public interface IAddTo
    {
        MotionHandle AddTo(MotionHandle motionHandler, Container container);
    }

    [Serializable]
    public sealed class AddToTransform : IAddTo
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private TransformResolver targetResolver;

        public MotionHandle AddTo(MotionHandle motionHandler, Container container)
        {
            return motionHandler.AddTo(targetResolver.Resolve(container));
        }
    }
}
#endif
