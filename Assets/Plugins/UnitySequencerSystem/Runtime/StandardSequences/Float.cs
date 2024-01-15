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
    [AddTypeMenu("Standard/Float Set")]
#endif
    [Serializable]
    public sealed class FloatSet : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private FloatResolver floatResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver floatNameResolver;

        public FloatSet()
        {
        }

        public FloatSet(FloatResolver floatResolver, StringResolver floatNameResolver)
        {
            this.floatResolver = floatResolver;
            this.floatNameResolver = floatNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var value = floatResolver.Resolve(container);
            var name = floatNameResolver.Resolve(container);
            container.RegisterOrReplace(name, value);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Float Add")]
#endif
    [Serializable]
    public sealed class FloatAdd : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private FloatResolver leftFloatResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private FloatResolver rightFloatResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver floatNameResolver;

        public FloatAdd()
        {
        }

        public FloatAdd(FloatResolver leftFloatResolver, FloatResolver rightFloatResolver, StringResolver floatNameResolver)
        {
            this.leftFloatResolver = leftFloatResolver;
            this.rightFloatResolver = rightFloatResolver;
            this.floatNameResolver = floatNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var left = leftFloatResolver.Resolve(container);
            var right = rightFloatResolver.Resolve(container);
            var name = floatNameResolver.Resolve(container);
            container.RegisterOrReplace(name, left + right);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Float Subtract")]
#endif
    [Serializable]
    public sealed class FloatSubtract : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private FloatResolver leftFloatResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private FloatResolver rightFloatResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver floatNameResolver;

        public FloatSubtract()
        {
        }

        public FloatSubtract(FloatResolver leftFloatResolver, FloatResolver rightFloatResolver, StringResolver floatNameResolver)
        {
            this.leftFloatResolver = leftFloatResolver;
            this.rightFloatResolver = rightFloatResolver;
            this.floatNameResolver = floatNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var left = leftFloatResolver.Resolve(container);
            var right = rightFloatResolver.Resolve(container);
            var name = floatNameResolver.Resolve(container);
            container.RegisterOrReplace(name, left - right);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Float Multiply")]
#endif
    [Serializable]
    public sealed class FloatMultiply : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private FloatResolver leftFloatResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private FloatResolver rightFloatResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver floatNameResolver;

        public FloatMultiply()
        {
        }

        public FloatMultiply(FloatResolver leftFloatResolver, FloatResolver rightFloatResolver, StringResolver floatNameResolver)
        {
            this.leftFloatResolver = leftFloatResolver;
            this.rightFloatResolver = rightFloatResolver;
            this.floatNameResolver = floatNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var left = leftFloatResolver.Resolve(container);
            var right = rightFloatResolver.Resolve(container);
            var name = floatNameResolver.Resolve(container);
            container.RegisterOrReplace(name, left * right);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Float Divide")]
#endif
    [Serializable]
    public sealed class FloatDivide : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private FloatResolver leftFloatResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private FloatResolver rightFloatResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif

        [SerializeReference]
        private StringResolver floatNameResolver;

        public FloatDivide()
        {
        }

        public FloatDivide(FloatResolver leftFloatResolver, FloatResolver rightFloatResolver, StringResolver floatNameResolver)
        {
            this.leftFloatResolver = leftFloatResolver;
            this.rightFloatResolver = rightFloatResolver;
            this.floatNameResolver = floatNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var left = leftFloatResolver.Resolve(container);
            var right = rightFloatResolver.Resolve(container);
            var name = floatNameResolver.Resolve(container);
            container.RegisterOrReplace(name, left / right);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Float Modulo")]
#endif
    [Serializable]
    public sealed class FloatModulo : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private FloatResolver leftFloatResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private FloatResolver rightFloatResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver floatNameResolver;

        public FloatModulo()
        {
        }

        public FloatModulo(FloatResolver leftFloatResolver, FloatResolver rightFloatResolver, StringResolver floatNameResolver)
        {
            this.leftFloatResolver = leftFloatResolver;
            this.rightFloatResolver = rightFloatResolver;
            this.floatNameResolver = floatNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var left = leftFloatResolver.Resolve(container);
            var right = rightFloatResolver.Resolve(container);
            var name = floatNameResolver.Resolve(container);
            container.RegisterOrReplace(name, left % right);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Float To Int")]
#endif
    [Serializable]
    public sealed class FloatToInt : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private FloatResolver floatResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver intNameResolver;

        public FloatToInt()
        {
        }

        public FloatToInt(FloatResolver floatResolver, StringResolver intNameResolver)
        {
            this.floatResolver = floatResolver;
            this.intNameResolver = intNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var value = floatResolver.Resolve(container);
            var name = intNameResolver.Resolve(container);
            container.RegisterOrReplace(name, (float)value);
#if USS_SUPPORT_UNITASK
            return UniTask.CompletedTask;
#else
            return Task.CompletedTask;
#endif
        }
    }

#if USS_SUPPORT_SUB_CLASS_SELECTOR
    [AddTypeMenu("Standard/Float To String")]
#endif
    [Serializable]
    public sealed class FloatToString : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private FloatResolver floatResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver stringNameResolver;

        public FloatToString()
        {
        }

        public FloatToString(FloatResolver floatResolver, StringResolver stringNameResolver)
        {
            this.floatResolver = floatResolver;
            this.stringNameResolver = stringNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var value = floatResolver.Resolve(container);
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
    [AddTypeMenu("Standard/Float To Bool")]
#endif
    [Serializable]
    public sealed class FloatToBool : Sequence
    {
#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private FloatResolver floatResolver;

#if USS_SUPPORT_SUB_CLASS_SELECTOR
        [SubclassSelector]
#endif
        [SerializeReference]
        private StringResolver boolNameResolver;

        public FloatToBool()
        {
        }

        public FloatToBool(FloatResolver floatResolver, StringResolver boolNameResolver)
        {
            this.floatResolver = floatResolver;
            this.boolNameResolver = boolNameResolver;
        }

#if USS_SUPPORT_UNITASK
        public override UniTask PlayAsync(Container container, CancellationToken cancellationToken)
#else
        public override Task PlayAsync(Container container, CancellationToken cancellationToken)
#endif
        {
            var value = floatResolver.Resolve(container);
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

