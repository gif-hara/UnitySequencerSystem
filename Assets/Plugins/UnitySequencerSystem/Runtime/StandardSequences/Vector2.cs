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
        private string vector2Name;

        public Vector2Set()
        {
        }

        public Vector2Set(Vector2Resolver vector2Resolver, string vector2Name)
        {
            this.vector2Resolver = vector2Resolver;
            this.vector2Name = vector2Name;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var value = vector2Resolver.Resolve(container);
            container.RegisterOrReplace(vector2Name, value);
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
        private StringResolver vector2NameResolver;


        public Vector2Add()
        {
        }

        public Vector2Add(Vector2Resolver leftVector2Resolver, Vector2Resolver rightVector2Resolver, StringResolver vector2NameResolver)
        {
            this.leftVector2Resolver = leftVector2Resolver;
            this.rightVector2Resolver = rightVector2Resolver;
            this.vector2NameResolver = vector2NameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var left = leftVector2Resolver.Resolve(container);
            var right = rightVector2Resolver.Resolve(container);
            var vector2Name = vector2NameResolver.Resolve(container);
            container.RegisterOrReplace(vector2Name, left + right);
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
        private StringResolver vector2NameResolver;

        public Vector2Subtract()
        {
        }

        public Vector2Subtract(Vector2Resolver leftVector2Resolver, Vector2Resolver rightVector2Resolver, StringResolver vector2NameResolver)
        {
            this.leftVector2Resolver = leftVector2Resolver;
            this.rightVector2Resolver = rightVector2Resolver;
            this.vector2NameResolver = vector2NameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var left = leftVector2Resolver.Resolve(container);
            var right = rightVector2Resolver.Resolve(container);
            var vector2Name = vector2NameResolver.Resolve(container);
            container.RegisterOrReplace(vector2Name, left - right);
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
        private StringResolver vector2NameResolver;

        public Vector2Multiply()
        {
        }

        public Vector2Multiply(Vector2Resolver leftVector2Resolver, Vector2Resolver rightVector2Resolver, StringResolver vector2NameResolver)
        {
            this.leftVector2Resolver = leftVector2Resolver;
            this.rightVector2Resolver = rightVector2Resolver;
            this.vector2NameResolver = vector2NameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var left = leftVector2Resolver.Resolve(container);
            var right = rightVector2Resolver.Resolve(container);
            var vector2Name = vector2NameResolver.Resolve(container);
            container.RegisterOrReplace(vector2Name, left * right);
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
        private StringResolver vector2NameResolver;

        public Vector2Divide()
        {
        }

        public Vector2Divide(Vector2Resolver leftVector2Resolver, Vector2Resolver rightVector2Resolver, StringResolver vector2NameResolver)
        {
            this.leftVector2Resolver = leftVector2Resolver;
            this.rightVector2Resolver = rightVector2Resolver;
            this.vector2NameResolver = vector2NameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var left = leftVector2Resolver.Resolve(container);
            var right = rightVector2Resolver.Resolve(container);
            var vector2Name = vector2NameResolver.Resolve(container);
            container.RegisterOrReplace(vector2Name, left / right);
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
        private string vector3Name;

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
        /// Initializes a new instance of the Vector2ToVector3 class with the specified Vector2Resolver.
        /// </summary>
        /// <param name="vector2Resolver">The Vector2Resolver to use for resolving the Vector2 value.</param>
        public Vector2ToVector3(Vector2Resolver vector2Resolver)
        {
            this.vector2Resolver = vector2Resolver;
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
            container.RegisterOrReplace(vector3Name, new Vector3(x, y, z));
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
