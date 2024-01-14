using System;
using System.Threading;
using UnityEngine;
using UnitySequencerSystem.Resolvers;


#if USS_SUPPORT_UNITASK
using Cysharp.Threading.Tasks;
#else
using System.Linq;
using System.Threading.Tasks;
#endif


namespace UnitySequencerSystem.StandardSequences
{
#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Vector2 Set")]
#endif
    [Serializable]
    public sealed class Vector2Set : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector2Resolver vector2Resolver;

        [SerializeField]
        private StringResolver setNameResolver;

        public Vector2Set()
        {
        }

        public Vector2Set(Vector2Resolver vector2Resolver, StringResolver setNameResolver)
        {
            this.vector2Resolver = vector2Resolver;
            this.setNameResolver = setNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var value = vector2Resolver.Resolve(container);
            var name = setNameResolver.Resolve(container);
            container.RegisterOrReplace(name, value);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Vector2 Add")]
#endif
    [Serializable]
    public sealed class Vector2Add : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector2Resolver leftVector2Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector2Resolver rightVector2Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver addNameResolver;


        public Vector2Add()
        {
        }

        public Vector2Add(Vector2Resolver leftVector2Resolver, Vector2Resolver rightVector2Resolver, StringResolver addNameResolver)
        {
            this.leftVector2Resolver = leftVector2Resolver;
            this.rightVector2Resolver = rightVector2Resolver;
            this.addNameResolver = addNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var left = leftVector2Resolver.Resolve(container);
            var right = rightVector2Resolver.Resolve(container);
            var name = addNameResolver.Resolve(container);
            container.RegisterOrReplace(name, left + right);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Vector2 Subtract")]
#endif
    [Serializable]
    public sealed class Vector2Subtract : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector2Resolver leftVector2Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector2Resolver rightVector2Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver subtractNameResolver;

        public Vector2Subtract()
        {
        }

        public Vector2Subtract(Vector2Resolver leftVector2Resolver, Vector2Resolver rightVector2Resolver, StringResolver subtractNameResolver)
        {
            this.leftVector2Resolver = leftVector2Resolver;
            this.rightVector2Resolver = rightVector2Resolver;
            this.subtractNameResolver = subtractNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var left = leftVector2Resolver.Resolve(container);
            var right = rightVector2Resolver.Resolve(container);
            var name = subtractNameResolver.Resolve(container);
            container.RegisterOrReplace(name, left - right);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Vector2 Multiply")]
#endif
    [Serializable]
    public sealed class Vector2Multiply : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector2Resolver leftVector2Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector2Resolver rightVector2Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver multiplyNameResolver;

        public Vector2Multiply()
        {
        }

        public Vector2Multiply(Vector2Resolver leftVector2Resolver, Vector2Resolver rightVector2Resolver, StringResolver multiplyNameResolver)
        {
            this.leftVector2Resolver = leftVector2Resolver;
            this.rightVector2Resolver = rightVector2Resolver;
            this.multiplyNameResolver = multiplyNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var left = leftVector2Resolver.Resolve(container);
            var right = rightVector2Resolver.Resolve(container);
            var name = multiplyNameResolver.Resolve(container);
            container.RegisterOrReplace(name, left * right);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Vector2 Divide")]
#endif
    [Serializable]
    public sealed class Vector2Divide : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector2Resolver leftVector2Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector2Resolver rightVector2Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver divideNameResolver;

        public Vector2Divide()
        {
        }

        public Vector2Divide(Vector2Resolver leftVector2Resolver, Vector2Resolver rightVector2Resolver, StringResolver divideNameResolver)
        {
            this.leftVector2Resolver = leftVector2Resolver;
            this.rightVector2Resolver = rightVector2Resolver;
            this.divideNameResolver = divideNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var left = leftVector2Resolver.Resolve(container);
            var right = rightVector2Resolver.Resolve(container);
            var name = divideNameResolver.Resolve(container);
            container.RegisterOrReplace(name, left / right);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Vector2 Normalize")]
#endif
    [Serializable]
    public sealed class Vector2Normalize : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector2Resolver vector2Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver normalizeNameResolver;

        public Vector2Normalize()
        {
        }

        public Vector2Normalize(Vector2Resolver vector2Resolver, StringResolver normalizeNameResolver)
        {
            this.vector2Resolver = vector2Resolver;
            this.normalizeNameResolver = normalizeNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var vector2 = vector2Resolver.Resolve(container);
            var name = normalizeNameResolver.Resolve(container);
            container.RegisterOrReplace(name, vector2.normalized);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }
#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Vector2 SqrMagnitude")]
#endif
    [Serializable]
    public sealed class Vector2SqrMagnitude : Sequence
    {
        [SerializeReference]
        private Vector2Resolver vector2Resolver;

        [SerializeReference]
        private StringResolver sqrMagnitudeNameResolver;

        public Vector2SqrMagnitude()
        {
        }

        public Vector2SqrMagnitude(Vector2Resolver vector2Resolver, StringResolver sqrMagnitudeNameResolver)
        {
            this.vector2Resolver = vector2Resolver;
            this.sqrMagnitudeNameResolver = sqrMagnitudeNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var vector2 = vector2Resolver.Resolve(container);
            var name = sqrMagnitudeNameResolver.Resolve(container);
            container.RegisterOrReplace(name, vector2.sqrMagnitude);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Vector2 Magnitude")]
#endif
    [Serializable]
    public sealed class Vector2Magnitude : Sequence
    {
        [SerializeReference]
        private Vector2Resolver vector2Resolver;

        [SerializeReference]
        private StringResolver magnitudeNameResolver;

        public Vector2Magnitude()
        {
        }

        public Vector2Magnitude(Vector2Resolver vector2Resolver, StringResolver magnitudeNameResolver)
        {
            this.vector2Resolver = vector2Resolver;
            this.magnitudeNameResolver = magnitudeNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var vector2 = vector2Resolver.Resolve(container);
            var name = magnitudeNameResolver.Resolve(container);
            container.RegisterOrReplace(name, vector2.magnitude);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Vector2 Dot")]
#endif
    [Serializable]
    public sealed class Vector2Dot : Sequence
    {
        [SerializeReference]
        private Vector2Resolver leftVector2Resolver;

        [SerializeReference]
        private Vector2Resolver rightVector2Resolver;

        [SerializeReference]
        private StringResolver dotNameResolver;

        public Vector2Dot()
        {
        }

        public Vector2Dot(Vector2Resolver leftVector2Resolver, Vector2Resolver rightVector2Resolver, StringResolver dotNameResolver)
        {
            this.leftVector2Resolver = leftVector2Resolver;
            this.rightVector2Resolver = rightVector2Resolver;
            this.dotNameResolver = dotNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var left = leftVector2Resolver.Resolve(container);
            var right = rightVector2Resolver.Resolve(container);
            var name = dotNameResolver.Resolve(container);
            container.RegisterOrReplace(name, Vector2.Dot(left, right));
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Vector2 Perpendicular")]
#endif
    [Serializable]
    public sealed class Vector2Perpendicular : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector2Resolver vector2Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver perpendicularNameResolver;

        public Vector2Perpendicular()
        {
        }

        public Vector2Perpendicular(Vector2Resolver vector2Resolver, StringResolver perpendicularNameResolver)
        {
            this.vector2Resolver = vector2Resolver;
            this.perpendicularNameResolver = perpendicularNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var vector2 = vector2Resolver.Resolve(container);
            var name = perpendicularNameResolver.Resolve(container);
            container.RegisterOrReplace(name, Vector2.Perpendicular(vector2));
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Vector2 Reflect")]
#endif
    [Serializable]
    public sealed class Vector2Reflect : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector2Resolver vector2Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector2Resolver normalResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver reflectNameResolver;

        public Vector2Reflect()
        {
        }

        public Vector2Reflect(Vector2Resolver vector2Resolver, Vector2Resolver normalResolver, StringResolver reflectNameResolver)
        {
            this.vector2Resolver = vector2Resolver;
            this.normalResolver = normalResolver;
            this.reflectNameResolver = reflectNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif

        {
            var vector2 = vector2Resolver.Resolve(container);
            var normal = normalResolver.Resolve(container);
            var name = reflectNameResolver.Resolve(container);
            container.RegisterOrReplace(name, Vector2.Reflect(vector2, normal));
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Vector2 Angle")]
#endif
    [Serializable]
    public sealed class Vector2Angle : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector2Resolver fromVector2Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector2Resolver toVector2Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver angleNameResolver;

        public Vector2Angle()
        {
        }

        public Vector2Angle(Vector2Resolver fromVector2Resolver, Vector2Resolver toVector2Resolver, StringResolver angleNameResolver)
        {
            this.fromVector2Resolver = fromVector2Resolver;
            this.toVector2Resolver = toVector2Resolver;
            this.angleNameResolver = angleNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif

        {
            var from = fromVector2Resolver.Resolve(container);
            var to = toVector2Resolver.Resolve(container);
            var name = angleNameResolver.Resolve(container);
            container.RegisterOrReplace(name, Vector2.Angle(from, to));
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Vector2 SignedAngle")]
#endif
    [Serializable]
    public sealed class Vector2SignedAngle : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector2Resolver fromVector2Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector2Resolver toVector2Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver signedAngleNameResolver;

        public Vector2SignedAngle()
        {
        }

        public Vector2SignedAngle(Vector2Resolver fromVector2Resolver, Vector2Resolver toVector2Resolver, StringResolver signedAngleNameResolver)
        {
            this.fromVector2Resolver = fromVector2Resolver;
            this.toVector2Resolver = toVector2Resolver;
            this.signedAngleNameResolver = signedAngleNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif

        {
            var from = fromVector2Resolver.Resolve(container);
            var to = toVector2Resolver.Resolve(container);
            var name = signedAngleNameResolver.Resolve(container);
            container.RegisterOrReplace(name, Vector2.SignedAngle(from, to));
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Vector2 Distance")]
#endif
    [Serializable]
    public sealed class Vector2Distance : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector2Resolver fromVector2Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector2Resolver toVector2Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver distanceNameResolver;

        public Vector2Distance()
        {
        }

        public Vector2Distance(Vector2Resolver fromVector2Resolver, Vector2Resolver toVector2Resolver, StringResolver distanceNameResolver)
        {
            this.fromVector2Resolver = fromVector2Resolver;
            this.toVector2Resolver = toVector2Resolver;
            this.distanceNameResolver = distanceNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif

        {
            var from = fromVector2Resolver.Resolve(container);
            var to = toVector2Resolver.Resolve(container);
            var name = distanceNameResolver.Resolve(container);
            container.RegisterOrReplace(name, Vector2.Distance(from, to));
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Vector2 ClampMagnitude")]
#endif
    [Serializable]
    public sealed class Vector2ClampMagnitude : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector2Resolver vector2Resolver;

        [SerializeField]
        private FloatResolver maxLengthResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver clampMagnitudeNameResolver;

        public Vector2ClampMagnitude()
        {
        }

        public Vector2ClampMagnitude(Vector2Resolver vector2Resolver, FloatResolver maxLengthResolver, StringResolver clampMagnitudeNameResolver)
        {
            this.vector2Resolver = vector2Resolver;
            this.maxLengthResolver = maxLengthResolver;
            this.clampMagnitudeNameResolver = clampMagnitudeNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif

        {
            var vector2 = vector2Resolver.Resolve(container);
            var maxLength = maxLengthResolver.Resolve(container);
            var name = clampMagnitudeNameResolver.Resolve(container);
            container.RegisterOrReplace(name, Vector2.ClampMagnitude(vector2, maxLength));
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Vector2 Lerp")]
#endif
    [Serializable]
    public sealed class Vector2Lerp : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector2Resolver fromVector2Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector2Resolver toVector2Resolver;

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

        public Vector2Lerp()
        {
        }

        public Vector2Lerp(Vector2Resolver fromVector2Resolver, Vector2Resolver toVector2Resolver, FloatResolver timeResolver, StringResolver lerpNameResolver)
        {
            this.fromVector2Resolver = fromVector2Resolver;
            this.toVector2Resolver = toVector2Resolver;
            this.timeResolver = timeResolver;
            this.lerpNameResolver = lerpNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif

        {
            var from = fromVector2Resolver.Resolve(container);
            var to = toVector2Resolver.Resolve(container);
            var time = timeResolver.Resolve(container);
            var name = lerpNameResolver.Resolve(container);
            container.RegisterOrReplace(name, Vector2.Lerp(from, to, time));
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Vector2 LerpUnclamped")]
#endif
    [Serializable]
    public sealed class Vector2LerpUnclamped : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector2Resolver fromVector2Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector2Resolver toVector2Resolver;

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

        public Vector2LerpUnclamped()
        {
        }

        public Vector2LerpUnclamped(Vector2Resolver fromVector2Resolver, Vector2Resolver toVector2Resolver, FloatResolver timeResolver, StringResolver lerpUnclampedNameResolver)
        {
            this.fromVector2Resolver = fromVector2Resolver;
            this.toVector2Resolver = toVector2Resolver;
            this.timeResolver = timeResolver;
            this.lerpUnclampedNameResolver = lerpUnclampedNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif

        {
            var from = fromVector2Resolver.Resolve(container);
            var to = toVector2Resolver.Resolve(container);
            var time = timeResolver.Resolve(container);
            var name = lerpUnclampedNameResolver.Resolve(container);
            container.RegisterOrReplace(name, Vector2.LerpUnclamped(from, to, time));
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Vector2 MoveTowards")]
#endif
    [Serializable]
    public sealed class Vector2MoveTowards : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector2Resolver currentVector2Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector2Resolver targetVector2Resolver;

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

        public Vector2MoveTowards()
        {
        }

        public Vector2MoveTowards(Vector2Resolver currentVector2Resolver, Vector2Resolver targetVector2Resolver, FloatResolver maxDistanceDeltaResolver, StringResolver moveTowardsNameResolver)
        {
            this.currentVector2Resolver = currentVector2Resolver;
            this.targetVector2Resolver = targetVector2Resolver;
            this.maxDistanceDeltaResolver = maxDistanceDeltaResolver;
            this.moveTowardsNameResolver = moveTowardsNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)    
#endif

        {
            var current = currentVector2Resolver.Resolve(container);
            var target = targetVector2Resolver.Resolve(container);
            var maxDistanceDelta = maxDistanceDeltaResolver.Resolve(container);
            var name = moveTowardsNameResolver.Resolve(container);
            container.RegisterOrReplace(name, Vector2.MoveTowards(current, target, maxDistanceDelta));
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Vector2 SmoothDamp")]
#endif
    [Serializable]
    public sealed class Vector2SmoothDamp : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector2Resolver currentVector2Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector2Resolver targetVector2Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector2Resolver currentVelocityVector2Resolver;

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


        public Vector2SmoothDamp()
        {
        }

        public Vector2SmoothDamp(Vector2Resolver currentVector2Resolver, Vector2Resolver targetVector2Resolver, Vector2Resolver currentVelocityVector2Resolver, FloatResolver smoothTimeResolver, FloatResolver maxSpeedResolver, FloatResolver deltaTimeResolver, StringResolver smoothDampNameResolver, StringResolver currentVelocityNameResolver)
        {
            this.currentVector2Resolver = currentVector2Resolver;
            this.targetVector2Resolver = targetVector2Resolver;
            this.currentVelocityVector2Resolver = currentVelocityVector2Resolver;
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
            var current = currentVector2Resolver.Resolve(container);
            var target = targetVector2Resolver.Resolve(container);
            var currentVelocity = currentVelocityVector2Resolver.Resolve(container);
            var smoothTime = smoothTimeResolver.Resolve(container);
            var maxSpeed = maxSpeedResolver.Resolve(container);
            var deltaTime = deltaTimeResolver.Resolve(container);
            var smoothDampName = smoothDampNameResolver.Resolve(container);
            var currentVelocityName = currentVelocityNameResolver.Resolve(container);
            container.RegisterOrReplace(smoothDampName, Vector2.SmoothDamp(current, target, ref currentVelocity, smoothTime, maxSpeed, deltaTime));
            container.RegisterOrReplace(currentVelocityName, currentVelocity);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Vector2 Min")]
#endif
    [Serializable]
    public sealed class Vector2Min : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector2Resolver leftVector2Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector2Resolver rightVector2Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver minNameResolver;

        public Vector2Min()
        {
        }

        public Vector2Min(Vector2Resolver leftVector2Resolver, Vector2Resolver rightVector2Resolver, StringResolver minNameResolver)
        {
            this.leftVector2Resolver = leftVector2Resolver;
            this.rightVector2Resolver = rightVector2Resolver;
            this.minNameResolver = minNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var left = leftVector2Resolver.Resolve(container);
            var right = rightVector2Resolver.Resolve(container);
            var name = minNameResolver.Resolve(container);
            container.RegisterOrReplace(name, Vector2.Min(left, right));
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Vector2 Max")]
#endif
    [Serializable]
    public sealed class Vector2Max : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector2Resolver leftVector2Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector2Resolver rightVector2Resolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver maxNameResolver;

        public Vector2Max()
        {
        }

        public Vector2Max(Vector2Resolver leftVector2Resolver, Vector2Resolver rightVector2Resolver, StringResolver maxNameResolver)
        {
            this.leftVector2Resolver = leftVector2Resolver;
            this.rightVector2Resolver = rightVector2Resolver;
            this.maxNameResolver = maxNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var left = leftVector2Resolver.Resolve(container);
            var right = rightVector2Resolver.Resolve(container);
            var name = maxNameResolver.Resolve(container);
            container.RegisterOrReplace(name, Vector2.Max(left, right));
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }


    /// <summary>
    /// Represents a sequence that converts a Vector2 to a Vector3.
    /// </summary>
#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Vector2 To Vector3")]
#endif
    [Serializable]
    public sealed class Vector2ToVector3 : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private Vector2Resolver vector2Resolver;

        [SerializeField]
        private Axis axisX = Axis.X;

        [SerializeField]
        private Axis axisY = Axis.Y;

        [SerializeField]
        private Axis axisZ = Axis.Zero;

        [SerializeField]
        private StringResolver vector3NameResolver;

        public enum Axis
        {
            X,
            Y,
            Zero,
        }

        /// <summary>
        /// Initializes a new instance of the Vector2ToVector3 class.
        /// </summary>
        public Vector2ToVector3()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Vector2ToVector3 class with the specified parameters.
        /// </summary?
        /// <param name="vector2Resolver">The resolver that resolves the Vector2.</param>
        /// <param name="axisX">The axis to use for the X component.</param>
        /// <param name="axisY">The axis to use for the Y component.</param>
        /// <param name="axisZ">The axis to use for the Z component.</param>
        /// <param name="vector3NameResolver">The resolver that resolves the name of the Vector3.</param>
        public Vector2ToVector3(Vector2Resolver vector2Resolver, Axis axisX, Axis axisY, Axis axisZ, StringResolver vector3NameResolver)
        {
            this.vector2Resolver = vector2Resolver;
            this.axisX = axisX;
            this.axisY = axisY;
            this.axisZ = axisZ;
            this.vector3NameResolver = vector3NameResolver;
        }

#if USS_SUPPORT_UNITASK
        /// <summary>
        /// Plays the sequence asynchronously.
        /// </summary>
        /// <param name="container">The container that holds the sequence data.</param>
        /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
        /// <returns>A UniTask representing the asynchronous operation.</returns>
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        /// <summary>
        /// Plays the sequence asynchronously.
        /// </summary>
        /// <param name="container">The container that holds the sequence data.</param>
        /// <param name="cancellationToken">The cancellation token to cancel the operation.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var value = vector2Resolver.Resolve(container);
            var x = GetAxisValue(value, axisX);
            var y = GetAxisValue(value, axisY);
            var z = GetAxisValue(value, axisZ);
            var name = vector3NameResolver.Resolve(container);
            container.RegisterOrReplace(name, new Vector3(x, y, z));
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }

        private static float GetAxisValue(Vector2 value, Axis axis)
        {
            return axis switch
            {
                Axis.X => value.x,
                Axis.Y => value.y,
                Axis.Zero => 0,
                _ => throw new ArgumentOutOfRangeException(nameof(axis), axis, null)
            };
        }
    }
}
