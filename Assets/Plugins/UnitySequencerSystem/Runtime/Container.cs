using System;
using System.Collections.Generic;

namespace HK.UnitySequencerSystem
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

        public T Resolve<T>()
        {
            return (T)this.data[typeof(T)];
        }

        public T Resolve<T>(string name)
        {
            return (T)this.namedData[typeof(T)][name];
        }
    }
}
