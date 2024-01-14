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
