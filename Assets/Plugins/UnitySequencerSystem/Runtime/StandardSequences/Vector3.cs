using System;
using System.Threading;
using UnityEngine;
using UnitySequencerSystem.Resolvers;

#if USS_SUPPORT_UNITASK
using Cysharp.Threading.Tasks;
#else
using System.Threading.Tasks;
using System.Collections;
#endif

namespace UnitySequencerSystem.StandardSequences
{
#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Vector3 Set")]
#endif
    [Serializable]
    public sealed class Vector3Set : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver vector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver setNameResolver;

        public Vector3Set()
        {
        }

        public Vector3Set(Vector3Resolver vector3Resolver, StringResolver setNameResolver)
        {
            this.vector3Resolver = vector3Resolver;
            this.setNameResolver = setNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var vector3 = vector3Resolver.Resolve(container);
            var setName = setNameResolver.Resolve(container);
            container.RegisterOrReplace(setName, vector3);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Vector3 Add")]
#endif
    [Serializable]
    public sealed class Vector3Add : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver leftVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver rightVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver addNameResolver;

        public Vector3Add()
        {
        }

        public Vector3Add(Vector3Resolver leftVector3Resolver, Vector3Resolver rightVector3Resolver, StringResolver addNameResolver)
        {
            this.leftVector3Resolver = leftVector3Resolver;
            this.rightVector3Resolver = rightVector3Resolver;
            this.addNameResolver = addNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var leftVector3 = leftVector3Resolver.Resolve(container);
            var rightVector3 = rightVector3Resolver.Resolve(container);
            var addName = addNameResolver.Resolve(container);
            container.RegisterOrReplace(addName, leftVector3 + rightVector3);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Vector3 Subtract")]
#endif
    [Serializable]
    public sealed class Vector3Subtract : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver leftVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver rightVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver subtractNameResolver;

        public Vector3Subtract()
        {
        }

        public Vector3Subtract(Vector3Resolver leftVector3Resolver, Vector3Resolver rightVector3Resolver, StringResolver subtractNameResolver)
        {
            this.leftVector3Resolver = leftVector3Resolver;
            this.rightVector3Resolver = rightVector3Resolver;
            this.subtractNameResolver = subtractNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var leftVector3 = leftVector3Resolver.Resolve(container);
            var rightVector3 = rightVector3Resolver.Resolve(container);
            var subtractName = subtractNameResolver.Resolve(container);
            container.RegisterOrReplace(subtractName, leftVector3 - rightVector3);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Vector3 Multiply")]
#endif
    [Serializable]
    public sealed class Vector3Multiply : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver leftVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver rightVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver multiplyNameResolver;

        public Vector3Multiply()
        {
        }

        public Vector3Multiply(Vector3Resolver leftVector3Resolver, Vector3Resolver rightVector3Resolver, StringResolver multiplyNameResolver)
        {
            this.leftVector3Resolver = leftVector3Resolver;
            this.rightVector3Resolver = rightVector3Resolver;
            this.multiplyNameResolver = multiplyNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var leftVector3 = leftVector3Resolver.Resolve(container);
            var rightVector3 = rightVector3Resolver.Resolve(container);
            var multiplyName = multiplyNameResolver.Resolve(container);
            container.RegisterOrReplace(multiplyName, Vector3.Scale(leftVector3, rightVector3));
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Vector3 Divide")]
#endif
    [Serializable]
    public sealed class Vector3Divide : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver leftVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver rightVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver divideNameResolver;

        public Vector3Divide()
        {
        }

        public Vector3Divide(Vector3Resolver leftVector3Resolver, Vector3Resolver rightVector3Resolver, StringResolver divideNameResolver)
        {
            this.leftVector3Resolver = leftVector3Resolver;
            this.rightVector3Resolver = rightVector3Resolver;
            this.divideNameResolver = divideNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var leftVector3 = leftVector3Resolver.Resolve(container);
            var rightVector3 = rightVector3Resolver.Resolve(container);
            var divideName = divideNameResolver.Resolve(container);
            container.RegisterOrReplace(divideName, new Vector3(leftVector3.x / rightVector3.x, leftVector3.y / rightVector3.y, leftVector3.z / rightVector3.z));
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_UNITASK
    [AddTypeMenu("Standard/Vector3 Slerp")]
#endif
    [Serializable]
    public sealed class Vector3Slerp : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver fromVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver toVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private FloatResolver timeResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver slerpNameResolver;

        public Vector3Slerp()
        {
        }

        public Vector3Slerp(Vector3Resolver fromVector3Resolver, Vector3Resolver toVector3Resolver, FloatResolver timeResolver, StringResolver slerpNameResolver)
        {
            this.fromVector3Resolver = fromVector3Resolver;
            this.toVector3Resolver = toVector3Resolver;
            this.timeResolver = timeResolver;
            this.slerpNameResolver = slerpNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var fromVector3 = fromVector3Resolver.Resolve(container);
            var toVector3 = toVector3Resolver.Resolve(container);
            var time = timeResolver.Resolve(container);
            var slerpName = slerpNameResolver.Resolve(container);
            container.RegisterOrReplace(slerpName, Vector3.Slerp(fromVector3, toVector3, time));
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_UNITASK
    [AddTypeMenu("Standard/Vector3 SlerpUnclamped")]
#endif
    [Serializable]
    public sealed class Vector3SlerpUnclamped : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver fromVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver toVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private FloatResolver timeResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver slerpUnclampedNameResolver;

        public Vector3SlerpUnclamped()
        {
        }

        public Vector3SlerpUnclamped(Vector3Resolver fromVector3Resolver, Vector3Resolver toVector3Resolver, FloatResolver timeResolver, StringResolver slerpUnclampedNameResolver)
        {
            this.fromVector3Resolver = fromVector3Resolver;
            this.toVector3Resolver = toVector3Resolver;
            this.timeResolver = timeResolver;
            this.slerpUnclampedNameResolver = slerpUnclampedNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var fromVector3 = fromVector3Resolver.Resolve(container);
            var toVector3 = toVector3Resolver.Resolve(container);
            var time = timeResolver.Resolve(container);
            var slerpUnclampedName = slerpUnclampedNameResolver.Resolve(container);
            container.RegisterOrReplace(slerpUnclampedName, Vector3.SlerpUnclamped(fromVector3, toVector3, time));
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_UNITASK
    [AddTypeMenu("Standard/Vector3 OrthoNormalize2")]
#endif
    [Serializable]
    public sealed class Vector3OrthoNormalize2 : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver normalVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver tangentVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver normalNameResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver tangentNameResolver;

        public Vector3OrthoNormalize2()
        {
        }

        public Vector3OrthoNormalize2(Vector3Resolver normalVector3Resolver, Vector3Resolver tangentVector3Resolver, StringResolver normalNameResolver, StringResolver tangentNameResolver)
        {
            this.normalVector3Resolver = normalVector3Resolver;
            this.tangentVector3Resolver = tangentVector3Resolver;
            this.normalNameResolver = normalNameResolver;
            this.tangentNameResolver = tangentNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var normalVector3 = normalVector3Resolver.Resolve(container);
            var tangentVector3 = tangentVector3Resolver.Resolve(container);
            var normalName = normalNameResolver.Resolve(container);
            var tangentName = tangentNameResolver.Resolve(container);
            Vector3.OrthoNormalize(ref normalVector3, ref tangentVector3);
            container.RegisterOrReplace(normalName, normalVector3);
            container.RegisterOrReplace(tangentName, tangentVector3);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_UNITASK
    [AddTypeMenu("Standard/Vector3 OrthoNormalize3")]
#endif
    [Serializable]
    public sealed class Vector3OrthoNormalize3 : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver normalVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver tangentVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver binormalVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver normalNameResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver tangentNameResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver binormalNameResolver;

        public Vector3OrthoNormalize3()
        {
        }

        public Vector3OrthoNormalize3(Vector3Resolver normalVector3Resolver, Vector3Resolver tangentVector3Resolver, Vector3Resolver binormalVector3Resolver, StringResolver normalNameResolver, StringResolver tangentNameResolver, StringResolver binormalNameResolver)
        {
            this.normalVector3Resolver = normalVector3Resolver;
            this.tangentVector3Resolver = tangentVector3Resolver;
            this.binormalVector3Resolver = binormalVector3Resolver;
            this.normalNameResolver = normalNameResolver;
            this.tangentNameResolver = tangentNameResolver;
            this.binormalNameResolver = binormalNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var normalVector3 = normalVector3Resolver.Resolve(container);
            var tangentVector3 = tangentVector3Resolver.Resolve(container);
            var binormalVector3 = binormalVector3Resolver.Resolve(container);
            var normalName = normalNameResolver.Resolve(container);
            var tangentName = tangentNameResolver.Resolve(container);
            var binormalName = binormalNameResolver.Resolve(container);
            Vector3.OrthoNormalize(ref normalVector3, ref tangentVector3, ref binormalVector3);
            container.RegisterOrReplace(normalName, normalVector3);
            container.RegisterOrReplace(tangentName, tangentVector3);
            container.RegisterOrReplace(binormalName, binormalVector3);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_UNITASK
    [AddTypeMenu("Standard/Vector3 RotateTowards")]
#endif
    [Serializable]
    public sealed class Vector3RotateTowards : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver currentVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver targetVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private FloatResolver maxRadiansDeltaResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private FloatResolver maxMagnitudeDeltaResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver rotateTowardsNameResolver;

        public Vector3RotateTowards()
        {
        }

        public Vector3RotateTowards(Vector3Resolver currentVector3Resolver, Vector3Resolver targetVector3Resolver, FloatResolver maxRadiansDeltaResolver, FloatResolver maxMagnitudeDeltaResolver, StringResolver rotateTowardsNameResolver)
        {
            this.currentVector3Resolver = currentVector3Resolver;
            this.targetVector3Resolver = targetVector3Resolver;
            this.maxRadiansDeltaResolver = maxRadiansDeltaResolver;
            this.maxMagnitudeDeltaResolver = maxMagnitudeDeltaResolver;
            this.rotateTowardsNameResolver = rotateTowardsNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif

        {
            var currentVector3 = currentVector3Resolver.Resolve(container);
            var targetVector3 = targetVector3Resolver.Resolve(container);
            var maxRadiansDelta = maxRadiansDeltaResolver.Resolve(container);
            var maxMagnitudeDelta = maxMagnitudeDeltaResolver.Resolve(container);
            var rotateTowardsName = rotateTowardsNameResolver.Resolve(container);
            container.RegisterOrReplace(rotateTowardsName, Vector3.RotateTowards(currentVector3, targetVector3, maxRadiansDelta, maxMagnitudeDelta));
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_UNITASK
    [AddTypeMenu("Standard/Vector3 Lerp")]
#endif
    [Serializable]
    public sealed class Vector3Lerp : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver fromVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver toVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private FloatResolver timeResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver lerpNameResolver;

        public Vector3Lerp()
        {
        }

        public Vector3Lerp(Vector3Resolver fromVector3Resolver, Vector3Resolver toVector3Resolver, FloatResolver timeResolver, StringResolver lerpNameResolver)
        {
            this.fromVector3Resolver = fromVector3Resolver;
            this.toVector3Resolver = toVector3Resolver;
            this.timeResolver = timeResolver;
            this.lerpNameResolver = lerpNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif

        {
            var fromVector3 = fromVector3Resolver.Resolve(container);
            var toVector3 = toVector3Resolver.Resolve(container);
            var time = timeResolver.Resolve(container);
            var lerpName = lerpNameResolver.Resolve(container);
            container.RegisterOrReplace(lerpName, Vector3.Lerp(fromVector3, toVector3, time));
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;  
#endif
        }
    }

#if USS_SUPPORT_UNITASK
    [AddTypeMenu("Standard/Vector3 LerpUnclamped")]
#endif
    [Serializable]
    public sealed class Vector3LerpUnclamped : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver fromVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver toVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private FloatResolver timeResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver lerpUnclampedNameResolver;

        public Vector3LerpUnclamped()
        {
        }

        public Vector3LerpUnclamped(Vector3Resolver fromVector3Resolver, Vector3Resolver toVector3Resolver, FloatResolver timeResolver, StringResolver lerpUnclampedNameResolver)
        {
            this.fromVector3Resolver = fromVector3Resolver;
            this.toVector3Resolver = toVector3Resolver;
            this.timeResolver = timeResolver;
            this.lerpUnclampedNameResolver = lerpUnclampedNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif

        {
            var fromVector3 = fromVector3Resolver.Resolve(container);
            var toVector3 = toVector3Resolver.Resolve(container);
            var time = timeResolver.Resolve(container);
            var lerpUnclampedName = lerpUnclampedNameResolver.Resolve(container);
            container.RegisterOrReplace(lerpUnclampedName, Vector3.LerpUnclamped(fromVector3, toVector3, time));
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_UNITASK
    [AddTypeMenu("Standard/Vector3 MoveTowards")]
#endif
    [Serializable]
    public sealed class Vector3MoveTowards : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver currentVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver targetVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private FloatResolver maxDistanceDeltaResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver moveTowardsNameResolver;

        public Vector3MoveTowards()
        {
        }

        public Vector3MoveTowards(Vector3Resolver currentVector3Resolver, Vector3Resolver targetVector3Resolver, FloatResolver maxDistanceDeltaResolver, StringResolver moveTowardsNameResolver)
        {
            this.currentVector3Resolver = currentVector3Resolver;
            this.targetVector3Resolver = targetVector3Resolver;
            this.maxDistanceDeltaResolver = maxDistanceDeltaResolver;
            this.moveTowardsNameResolver = moveTowardsNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif

        {
            var currentVector3 = currentVector3Resolver.Resolve(container);
            var targetVector3 = targetVector3Resolver.Resolve(container);
            var maxDistanceDelta = maxDistanceDeltaResolver.Resolve(container);
            var moveTowardsName = moveTowardsNameResolver.Resolve(container);
            container.RegisterOrReplace(moveTowardsName, Vector3.MoveTowards(currentVector3, targetVector3, maxDistanceDelta));
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_UNITASK
    [AddTypeMenu("Standard/Vector3 SmoothDamp")]
#endif
    [Serializable]
    public sealed class Vector3SmoothDamp : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver currentVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver targetVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver currentVelocityVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private FloatResolver smoothTimeResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private FloatResolver maxSpeedResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private FloatResolver deltaTimeResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif

        [SerializeReference]
        private StringResolver smoothDampNameResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif

        [SerializeReference]
        private StringResolver currentVelocityNameResolver;

        public Vector3SmoothDamp()
        {
        }

        public Vector3SmoothDamp(Vector3Resolver currentVector3Resolver, Vector3Resolver targetVector3Resolver, Vector3Resolver currentVelocityVector3Resolver, FloatResolver smoothTimeResolver, FloatResolver maxSpeedResolver, FloatResolver deltaTimeResolver, StringResolver smoothDampNameResolver, StringResolver currentVelocityNameResolver)
        {
            this.currentVector3Resolver = currentVector3Resolver;
            this.targetVector3Resolver = targetVector3Resolver;
            this.currentVelocityVector3Resolver = currentVelocityVector3Resolver;
            this.smoothTimeResolver = smoothTimeResolver;
            this.maxSpeedResolver = maxSpeedResolver;
            this.deltaTimeResolver = deltaTimeResolver;
            this.smoothDampNameResolver = smoothDampNameResolver;
            this.currentVelocityNameResolver = currentVelocityNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif

        {
            var currentVector3 = currentVector3Resolver.Resolve(container);
            var targetVector3 = targetVector3Resolver.Resolve(container);
            var currentVelocityVector3 = currentVelocityVector3Resolver.Resolve(container);
            var smoothTime = smoothTimeResolver.Resolve(container);
            var maxSpeed = maxSpeedResolver.Resolve(container);
            var deltaTime = deltaTimeResolver.Resolve(container);
            var smoothDampName = smoothDampNameResolver.Resolve(container);
            var currentVelocityName = currentVelocityNameResolver.Resolve(container);
            container.RegisterOrReplace(smoothDampName, Vector3.SmoothDamp(currentVector3, targetVector3, ref currentVelocityVector3, smoothTime, maxSpeed, deltaTime));
            container.RegisterOrReplace(currentVelocityName, currentVelocityVector3);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Vector3 Cross")]
#endif
    [Serializable]
    public sealed class Vector3Cross : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver leftVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver rightVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver crossNameResolver;

        public Vector3Cross()
        {
        }

        public Vector3Cross(Vector3Resolver leftVector3Resolver, Vector3Resolver rightVector3Resolver, StringResolver crossNameResolver)
        {
            this.leftVector3Resolver = leftVector3Resolver;
            this.rightVector3Resolver = rightVector3Resolver;
            this.crossNameResolver = crossNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var leftVector3 = leftVector3Resolver.Resolve(container);
            var rightVector3 = rightVector3Resolver.Resolve(container);
            var crossName = crossNameResolver.Resolve(container);
            container.RegisterOrReplace(crossName, Vector3.Cross(leftVector3, rightVector3));
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Vector3 HashCode")]
#endif
    [Serializable]
    public sealed class Vector3HashCode : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver vector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver hashCodeNameResolver;

        public Vector3HashCode()
        {
        }

        public Vector3HashCode(Vector3Resolver vector3Resolver, StringResolver hashCodeNameResolver)
        {
            this.vector3Resolver = vector3Resolver;
            this.hashCodeNameResolver = hashCodeNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif

        {
            var vector3 = vector3Resolver.Resolve(container);
            var hashCodeName = hashCodeNameResolver.Resolve(container);
            container.RegisterOrReplace(hashCodeName, vector3.GetHashCode());
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Vector3 Equals")]
#endif
    [Serializable]
    public sealed class Vector3Equals : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver leftVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver rightVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver equalsNameResolver;

        public Vector3Equals()
        {
        }

        public Vector3Equals(Vector3Resolver leftVector3Resolver, Vector3Resolver rightVector3Resolver, StringResolver equalsNameResolver)
        {
            this.leftVector3Resolver = leftVector3Resolver;
            this.rightVector3Resolver = rightVector3Resolver;
            this.equalsNameResolver = equalsNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif

        {
            var leftVector3 = leftVector3Resolver.Resolve(container);
            var rightVector3 = rightVector3Resolver.Resolve(container);
            var equalsName = equalsNameResolver.Resolve(container);
            container.RegisterOrReplace(equalsName, leftVector3.Equals(rightVector3));
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Vector3 Reflect")]
#endif
    [Serializable]
    public sealed class Vector3Reflect : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver inDirectionVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver inNormalVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver reflectNameResolver;

        public Vector3Reflect()
        {
        }

        public Vector3Reflect(Vector3Resolver inDirectionVector3Resolver, Vector3Resolver inNormalVector3Resolver, StringResolver reflectNameResolver)
        {
            this.inDirectionVector3Resolver = inDirectionVector3Resolver;
            this.inNormalVector3Resolver = inNormalVector3Resolver;
            this.reflectNameResolver = reflectNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif

        {
            var inDirectionVector3 = inDirectionVector3Resolver.Resolve(container);
            var inNormalVector3 = inNormalVector3Resolver.Resolve(container);
            var reflectName = reflectNameResolver.Resolve(container);
            container.RegisterOrReplace(reflectName, Vector3.Reflect(inDirectionVector3, inNormalVector3));
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Vector3 Normalize")]
#endif
    [Serializable]
    public sealed class Vector3Normalize : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver vector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver normalizeNameResolver;

        public Vector3Normalize()
        {
        }

        public Vector3Normalize(Vector3Resolver vector3Resolver, StringResolver normalizeNameResolver)
        {
            this.vector3Resolver = vector3Resolver;
            this.normalizeNameResolver = normalizeNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var vector3 = vector3Resolver.Resolve(container);
            var normalizeName = normalizeNameResolver.Resolve(container);
            container.RegisterOrReplace(normalizeName, vector3.normalized);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Vector3 Dot")]
#endif
    [Serializable]
    public sealed class Vector3Dot : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver leftVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver rightVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver dotNameResolver;

        public Vector3Dot()
        {
        }

        public Vector3Dot(Vector3Resolver leftVector3Resolver, Vector3Resolver rightVector3Resolver, StringResolver dotNameResolver)
        {
            this.leftVector3Resolver = leftVector3Resolver;
            this.rightVector3Resolver = rightVector3Resolver;
            this.dotNameResolver = dotNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var leftVector3 = leftVector3Resolver.Resolve(container);
            var rightVector3 = rightVector3Resolver.Resolve(container);
            var dotName = dotNameResolver.Resolve(container);
            container.RegisterOrReplace(dotName, Vector3.Dot(leftVector3, rightVector3));
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Vector3 Project")]
#endif
    [Serializable]
    public sealed class Vector3Project : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver vector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver onNormalVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver projectNameResolver;

        public Vector3Project()
        {
        }

        public Vector3Project(Vector3Resolver vector3Resolver, Vector3Resolver onNormalVector3Resolver, StringResolver projectNameResolver)
        {
            this.vector3Resolver = vector3Resolver;
            this.onNormalVector3Resolver = onNormalVector3Resolver;
            this.projectNameResolver = projectNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif

        {
            var vector3 = vector3Resolver.Resolve(container);
            var onNormalVector3 = onNormalVector3Resolver.Resolve(container);
            var projectName = projectNameResolver.Resolve(container);
            container.RegisterOrReplace(projectName, Vector3.Project(vector3, onNormalVector3));
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Vector3 ProjectOnPlane")]
#endif
    [Serializable]
    public sealed class Vector3ProjectOnPlane : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver vector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver planeNormalVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver projectOnPlaneNameResolver;

        public Vector3ProjectOnPlane()
        {
        }

        public Vector3ProjectOnPlane(Vector3Resolver vector3Resolver, Vector3Resolver planeNormalVector3Resolver, StringResolver projectOnPlaneNameResolver)
        {
            this.vector3Resolver = vector3Resolver;
            this.planeNormalVector3Resolver = planeNormalVector3Resolver;
            this.projectOnPlaneNameResolver = projectOnPlaneNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif

        {
            var vector3 = vector3Resolver.Resolve(container);
            var planeNormalVector3 = planeNormalVector3Resolver.Resolve(container);
            var projectOnPlaneName = projectOnPlaneNameResolver.Resolve(container);
            container.RegisterOrReplace(projectOnPlaneName, Vector3.ProjectOnPlane(vector3, planeNormalVector3));
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Vector3 Angle")]
#endif
    [Serializable]
    public sealed class Vector3Angle : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver fromVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver toVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver angleNameResolver;

        public Vector3Angle()
        {
        }

        public Vector3Angle(Vector3Resolver fromVector3Resolver, Vector3Resolver toVector3Resolver, StringResolver angleNameResolver)
        {
            this.fromVector3Resolver = fromVector3Resolver;
            this.toVector3Resolver = toVector3Resolver;
            this.angleNameResolver = angleNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif

        {
            var fromVector3 = fromVector3Resolver.Resolve(container);
            var toVector3 = toVector3Resolver.Resolve(container);
            var angleName = angleNameResolver.Resolve(container);
            container.RegisterOrReplace(angleName, Vector3.Angle(fromVector3, toVector3));
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Vector3 SignedAngle")]
#endif
    [Serializable]
    public sealed class Vector3SignedAngle : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver fromVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver toVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver axisVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver signedAngleNameResolver;

        public Vector3SignedAngle()
        {
        }

        public Vector3SignedAngle(Vector3Resolver fromVector3Resolver, Vector3Resolver toVector3Resolver, Vector3Resolver axisVector3Resolver, StringResolver signedAngleNameResolver)
        {
            this.fromVector3Resolver = fromVector3Resolver;
            this.toVector3Resolver = toVector3Resolver;
            this.axisVector3Resolver = axisVector3Resolver;
            this.signedAngleNameResolver = signedAngleNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var fromVector3 = fromVector3Resolver.Resolve(container);
            var toVector3 = toVector3Resolver.Resolve(container);
            var axisVector3 = axisVector3Resolver.Resolve(container);
            var signedAngleName = signedAngleNameResolver.Resolve(container);
            container.RegisterOrReplace(signedAngleName, Vector3.SignedAngle(fromVector3, toVector3, axisVector3));
#if USS_SUPPORT_UNITASK

            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Vector3 Distance")]
#endif
    [Serializable]
    public sealed class Vector3Distance : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver leftVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver rightVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver distanceNameResolver;

        public Vector3Distance()
        {
        }

        public Vector3Distance(Vector3Resolver leftVector3Resolver, Vector3Resolver rightVector3Resolver, StringResolver distanceNameResolver)
        {
            this.leftVector3Resolver = leftVector3Resolver;
            this.rightVector3Resolver = rightVector3Resolver;
            this.distanceNameResolver = distanceNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var leftVector3 = leftVector3Resolver.Resolve(container);
            var rightVector3 = rightVector3Resolver.Resolve(container);
            var distanceName = distanceNameResolver.Resolve(container);
            container.RegisterOrReplace(distanceName, Vector3.Distance(leftVector3, rightVector3));
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Vector3 ClampMagnitude")]
#endif
    [Serializable]
    public sealed class Vector3ClampMagnitude : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver vector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private FloatResolver maxLengthResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver clampMagnitudeNameResolver;

        public Vector3ClampMagnitude()
        {
        }

        public Vector3ClampMagnitude(Vector3Resolver vector3Resolver, FloatResolver maxLengthResolver, StringResolver clampMagnitudeNameResolver)
        {
            this.vector3Resolver = vector3Resolver;
            this.maxLengthResolver = maxLengthResolver;
            this.clampMagnitudeNameResolver = clampMagnitudeNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var vector3 = vector3Resolver.Resolve(container);
            var maxLength = maxLengthResolver.Resolve(container);
            var clampMagnitudeName = clampMagnitudeNameResolver.Resolve(container);
            container.RegisterOrReplace(clampMagnitudeName, Vector3.ClampMagnitude(vector3, maxLength));
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Vector3 Magnitude")]
#endif
    [Serializable]
    public sealed class Vector3Magnitude : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver vector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver magnitudeNameResolver;

        public Vector3Magnitude()
        {
        }

        public Vector3Magnitude(Vector3Resolver vector3Resolver, StringResolver magnitudeNameResolver)
        {
            this.vector3Resolver = vector3Resolver;
            this.magnitudeNameResolver = magnitudeNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var vector3 = vector3Resolver.Resolve(container);
            var magnitudeName = magnitudeNameResolver.Resolve(container);
            container.RegisterOrReplace(magnitudeName, vector3.magnitude);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Vector3 SqrMagnitude")]
#endif
    [Serializable]
    public sealed class Vector3SqrMagnitude : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver vector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver sqrMagnitudeNameResolver;

        public Vector3SqrMagnitude()
        {
        }

        public Vector3SqrMagnitude(Vector3Resolver vector3Resolver, StringResolver sqrMagnitudeNameResolver)
        {
            this.vector3Resolver = vector3Resolver;
            this.sqrMagnitudeNameResolver = sqrMagnitudeNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var vector3 = vector3Resolver.Resolve(container);
            var sqrMagnitudeName = sqrMagnitudeNameResolver.Resolve(container);
            container.RegisterOrReplace(sqrMagnitudeName, vector3.sqrMagnitude);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_UNITASK
    [AddTypeMenu("Standard/Vector3 Min")]
#endif
    [Serializable]
    public sealed class Vector3Min : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver leftVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver rightVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver minNameResolver;

        public Vector3Min()
        {
        }

        public Vector3Min(Vector3Resolver leftVector3Resolver, Vector3Resolver rightVector3Resolver, StringResolver minNameResolver)
        {
            this.leftVector3Resolver = leftVector3Resolver;
            this.rightVector3Resolver = rightVector3Resolver;
            this.minNameResolver = minNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var leftVector3 = leftVector3Resolver.Resolve(container);
            var rightVector3 = rightVector3Resolver.Resolve(container);
            var minName = minNameResolver.Resolve(container);
            container.RegisterOrReplace(minName, Vector3.Min(leftVector3, rightVector3));
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_UNITASK
    [AddTypeMenu("Standard/Vector3 Max")]
#endif
    [Serializable]
    public sealed class Vector3Max : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver leftVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector3Resolver rightVector3Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver maxNameResolver;

        public Vector3Max()
        {
        }

        public Vector3Max(Vector3Resolver leftVector3Resolver, Vector3Resolver rightVector3Resolver, StringResolver maxNameResolver)
        {
            this.leftVector3Resolver = leftVector3Resolver;
            this.rightVector3Resolver = rightVector3Resolver;
            this.maxNameResolver = maxNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var leftVector3 = leftVector3Resolver.Resolve(container);
            var rightVector3 = rightVector3Resolver.Resolve(container);
            var maxName = maxNameResolver.Resolve(container);
            container.RegisterOrReplace(maxName, Vector3.Max(leftVector3, rightVector3));
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }
}
