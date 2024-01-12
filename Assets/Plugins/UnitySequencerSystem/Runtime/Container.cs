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

        public override string ToString()
        {
            var sb = new System.Text.StringBuilder();
            foreach (var kv in this.data)
            {
                sb.AppendLine($"{kv.Key} {kv.Value}");
            }
            foreach (var kv in this.namedData)
            {
                foreach (var kv2 in kv.Value)
                {
                    sb.AppendLine($"{kv.Key} {kv2.Key} {kv2.Value}");
                }
            }
            return sb.ToString();
        }
    }
}
