using System;
using System.Collections.Generic;
using UnityEngine.Assertions;

namespace UnitySequencerSystem
{
    /// <summary>
    /// シーケンスが利用するデータが格納されたコンテナ
    /// </summary>
    public sealed class Container
    {
        private readonly Dictionary<Type, object> data = new();

        private readonly Dictionary<Type, Dictionary<string, object>> namedData = new();

        public void Register<T>(T data)
        {
            this.data.Add(typeof(T), data);
        }

        public void Register<T>(string name, T data)
        {
            if (!this.namedData.TryGetValue(typeof(T), out var namedData))
            {
                namedData = new Dictionary<string, object>();
                this.namedData.Add(typeof(T), namedData);
            }

            namedData.Add(name, data);
        }

        public void RegisterOrReplace<T>(T data)
        {
            if (this.data.ContainsKey(typeof(T)))
            {
                this.data[typeof(T)] = data;
            }
            else
            {
                this.data.Add(typeof(T), data);
            }
        }

        public void RegisterOrReplace<T>(string name, T data)
        {
            if (!this.namedData.TryGetValue(typeof(T), out var namedData))
            {
                namedData = new Dictionary<string, object>();
                this.namedData.Add(typeof(T), namedData);
            }

            namedData[name] = data;
        }

        public T Resolve<T>()
        {
            Assert.IsTrue(this.data.ContainsKey(typeof(T)), $"{typeof(T)} is not registered.");
            return (T)this.data[typeof(T)];
        }

        public T Resolve<T>(string name)
        {
            Assert.IsTrue(this.namedData.ContainsKey(typeof(T)), $"{typeof(T)} is not registered.");
            Assert.IsTrue(this.namedData[typeof(T)].ContainsKey(name), $"{typeof(T)} {name} is not registered.");
            return (T)this.namedData[typeof(T)][name];
        }

        public bool Contains<T>()
        {
            return this.data.ContainsKey(typeof(T));
        }

        public bool Contains<T>(string name)
        {
            return this.namedData.ContainsKey(typeof(T)) && this.namedData[typeof(T)].ContainsKey(name);
        }

        public bool TryResolve<T>(out T value)
        {
            if (this.data.TryGetValue(typeof(T), out var obj))
            {
                value = (T)obj;
                return true;
            }
            value = default;
            return false;
        }

        public bool TryResolve<T>(string name, out T value)
        {
            if (this.namedData.TryGetValue(typeof(T), out var x) && x.TryGetValue(name, out var obj))
            {
                value = (T)obj;
                return true;
            }
            value = default;
            return false;
        }

        public void Remove<T>()
        {
            this.data.Remove(typeof(T));
        }

        public void Remove<T>(string name)
        {
            if (this.namedData.TryGetValue(typeof(T), out var namedData))
            {
                namedData.Remove(name);
            }
        }

        public override string ToString()
        {
            var sb = new System.Text.StringBuilder();
            foreach (var kv in this.data)
            {
                sb.AppendLine($"Type: {kv.Key}, Value: {kv.Value}");
            }
            foreach (var kv in this.namedData)
            {
                foreach (var kv2 in kv.Value)
                {
                    sb.AppendLine($"Type: {kv.Key}, Name: {kv2.Key}, Value: {kv2.Value}");
                }
            }
            return sb.ToString();
        }
    }
}
