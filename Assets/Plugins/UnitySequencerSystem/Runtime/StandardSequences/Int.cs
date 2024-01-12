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
    [AddTypeMenu("Standard/Int Set")]
#endif
    [Serializable]
    public sealed class IntSet : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private IntResolver intResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver intNameResolver;

        public IntSet()
        {
        }

        public IntSet(IntResolver intResolver, StringResolver intNameResolver)
        {
            this.intResolver = intResolver;
            this.intNameResolver = intNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var value = intResolver.Resolve(container);
            var name = intNameResolver.Resolve(container);
            container.RegisterOrReplace(name, value);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Int Add")]
#endif
    [Serializable]
    public sealed class IntAdd : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private IntResolver leftIntResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private IntResolver rightIntResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver intNameResolver;

        public IntAdd()
        {
        }

        public IntAdd(IntResolver leftIntResolver, IntResolver rightIntResolver, StringResolver intNameResolver)
        {
            this.leftIntResolver = leftIntResolver;
            this.rightIntResolver = rightIntResolver;
            this.intNameResolver = intNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var left = leftIntResolver.Resolve(container);
            var right = rightIntResolver.Resolve(container);
            var name = intNameResolver.Resolve(container);
            container.RegisterOrReplace(name, left + right);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Int Subtract")]
#endif
    [Serializable]
    public sealed class IntSubtract : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private IntResolver leftIntResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private IntResolver rightIntResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver intNameResolver;

        public IntSubtract()
        {
        }

        public IntSubtract(IntResolver leftIntResolver, IntResolver rightIntResolver, StringResolver intNameResolver)
        {
            this.leftIntResolver = leftIntResolver;
            this.rightIntResolver = rightIntResolver;
            this.intNameResolver = intNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var left = leftIntResolver.Resolve(container);
            var right = rightIntResolver.Resolve(container);
            var name = intNameResolver.Resolve(container);
            container.RegisterOrReplace(name, left - right);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Int Multiply")]
#endif
    [Serializable]
    public sealed class IntMultiply : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private IntResolver leftIntResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private IntResolver rightIntResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver intNameResolver;

        public IntMultiply()
        {
        }

        public IntMultiply(IntResolver leftIntResolver, IntResolver rightIntResolver, StringResolver intNameResolver)
        {
            this.leftIntResolver = leftIntResolver;
            this.rightIntResolver = rightIntResolver;
            this.intNameResolver = intNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var left = leftIntResolver.Resolve(container);
            var right = rightIntResolver.Resolve(container);
            var name = intNameResolver.Resolve(container);
            container.RegisterOrReplace(name, left * right);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Int Divide")]
#endif
    [Serializable]
    public sealed class IntDivide : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private IntResolver leftIntResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private IntResolver rightIntResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif

        [SerializeReference]
        private StringResolver intNameResolver;

        public IntDivide()
        {
        }

        public IntDivide(IntResolver leftIntResolver, IntResolver rightIntResolver, StringResolver intNameResolver)
        {
            this.leftIntResolver = leftIntResolver;
            this.rightIntResolver = rightIntResolver;
            this.intNameResolver = intNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var left = leftIntResolver.Resolve(container);
            var right = rightIntResolver.Resolve(container);
            var name = intNameResolver.Resolve(container);
            container.RegisterOrReplace(name, left / right);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Int Modulo")]
#endif
    [Serializable]
    public sealed class IntModulo : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private IntResolver leftIntResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private IntResolver rightIntResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver intNameResolver;

        public IntModulo()
        {
        }

        public IntModulo(IntResolver leftIntResolver, IntResolver rightIntResolver, StringResolver intNameResolver)
        {
            this.leftIntResolver = leftIntResolver;
            this.rightIntResolver = rightIntResolver;
            this.intNameResolver = intNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var left = leftIntResolver.Resolve(container);
            var right = rightIntResolver.Resolve(container);
            var name = intNameResolver.Resolve(container);
            container.RegisterOrReplace(name, left % right);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Int To Float")]
#endif
    [Serializable]
    public sealed class IntToFloat : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private IntResolver intResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver floatNameResolver;

        public IntToFloat()
        {
        }

        public IntToFloat(IntResolver intResolver, StringResolver floatNameResolver)
        {
            this.intResolver = intResolver;
            this.floatNameResolver = floatNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var value = intResolver.Resolve(container);
            var name = floatNameResolver.Resolve(container);
            container.RegisterOrReplace(name, (float)value);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Int To String")]
#endif
    [Serializable]
    public sealed class IntToString : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private IntResolver intResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver stringNameResolver;

        public IntToString()
        {
        }

        public IntToString(IntResolver intResolver, StringResolver stringNameResolver)
        {
            this.intResolver = intResolver;
            this.stringNameResolver = stringNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var value = intResolver.Resolve(container);
            var name = stringNameResolver.Resolve(container);
            container.RegisterOrReplace(name, value.ToString());
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Int To Bool")]
#endif
    [Serializable]
    public sealed class IntToBool : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private IntResolver intResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver boolNameResolver;

        public IntToBool()
        {
        }

        public IntToBool(IntResolver intResolver, StringResolver boolNameResolver)
        {
            this.intResolver = intResolver;
            this.boolNameResolver = boolNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var value = intResolver.Resolve(container);
            var name = boolNameResolver.Resolve(container);
            container.RegisterOrReplace(name, value != 0);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }
}

