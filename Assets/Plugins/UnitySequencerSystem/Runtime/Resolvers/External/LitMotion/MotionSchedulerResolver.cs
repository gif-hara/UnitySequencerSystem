using System;
using LitMotion;

namespace UnitySequencerSystem.Resolvers.LitMotion
{
    public abstract class MotionSchedulerResolver : IResolver<IMotionScheduler>
    {
        public abstract IMotionScheduler Resolve(Container container);

        [Serializable]
        public sealed class Update : MotionSchedulerResolver
        {
            public override IMotionScheduler Resolve(Container container)
            {
                return MotionScheduler.Update;
            }
        }
        
        [Serializable]
        public sealed class LateUpdate : MotionSchedulerResolver
        {
            public override IMotionScheduler Resolve(Container container)
            {
                return MotionScheduler.LateUpdate;
            }
        }
        
        [Serializable]
        public sealed class FixedUpdate : MotionSchedulerResolver
        {
            public override IMotionScheduler Resolve(Container container)
            {
                return MotionScheduler.FixedUpdate;
            }
        }
        
        [Serializable]
        public sealed class Manual : MotionSchedulerResolver
        {
            public override IMotionScheduler Resolve(Container container)
            {
                return MotionScheduler.Manual;
            }
        }
    }
}
