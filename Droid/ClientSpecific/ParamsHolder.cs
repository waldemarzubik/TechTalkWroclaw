using System;
using System.Collections.Generic;
using TechTalk.Droid.Interfaces;

namespace TechTalk.Droid.ClientSpecific
{
    public class ParamsHolder : IParamsHolder
    {
        private readonly Dictionary<string, WeakReference> _parameter;

        public ParamsHolder()
        {
            _parameter = new Dictionary<string, WeakReference>();
        }

        public T GetParameter<T>(string key, bool remove = true)
        {
            var parameterValue = default(T);
            WeakReference valueReference;
            if (_parameter.TryGetValue(key, out valueReference))
            {
                parameterValue = (T)valueReference.Target;
                if (remove)
                {
                    _parameter.Remove(key);
                }
            }
            return parameterValue;
        }

        public void SetParameter<T>(string key, T parameter)
        {
            if (_parameter.ContainsKey(key))
            {
                _parameter[key] = new WeakReference(parameter);
            }
            else
            {
                _parameter.Add(key, new WeakReference(parameter));
            }
        }
    }
}

