using System;
using System.Collections.Generic;
using UnityEngine;

namespace Services.EvnetBusSignals
{
    public sealed class EventBus
    {
        private readonly Dictionary<string, List<object>> _signals = new();

        public void Subscribe<T>(Action<T> signal)
        {
            var key = typeof(T).Name;
            if (_signals.ContainsKey(key))
            {
                _signals[key].Add(signal);
            }
            else
            {
                _signals.Add(key, new List<object>() { signal });
            }
        }

        public void Unsubscribe<T>(Action<T> signal)
        {
            var key = typeof(T).Name;
            if (_signals.ContainsKey(key))
            {
                _signals[key].Remove(signal);
            }
            else
            {
                Debug.LogError($"События {key} нет в словаре");
            }
        }

        public void Invoke<T>(T singal)
        {
            var key = typeof(T).Name;
            if (_signals.ContainsKey(key))
            {
                foreach (var i in _signals[key])
                {
                    var callback = i as Action<T>;
                    callback?.Invoke(singal);
                }
            }
            else
            {
                Debug.LogError($"События {key} нет в словаре");
            }
        }
    }
}