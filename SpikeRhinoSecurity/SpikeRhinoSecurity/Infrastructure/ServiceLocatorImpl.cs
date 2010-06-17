using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.ServiceLocation;

namespace SpikeRhinoSecurity.Infrastructure
{
    public class ServiceLocatorImpl : ServiceLocatorImplBase
    {
        private readonly Dictionary<Type, Dictionary<string, Func<object>>> _types = new Dictionary<Type, Dictionary<string, Func<object>>>();

        public void Add(Type type, object instance)
        {
            Add(type, "", instance);
        }

        public void Add(Type type, string key, object instance)
        {
            Add(type, key, () => instance);
        }

        public void Add(Type type, Func<object> func)
        {
            Add(type, "", func);
        }

        public void Add(Type type, string key, Func<object> func)
        {
            if(!_types.ContainsKey(type))
            {
                _types.Add(type, new Dictionary<string, Func<object>>());
            }
            _types[type].Add(key, func);
        }

        protected override object DoGetInstance(Type serviceType, string key)
        {
            try
            {
                return _types[serviceType][key ?? ""].Invoke();
            }
            catch(Exception ex)
            {
                throw new ActivationException("Unable to get instance of type '{0}', key '{1}'", ex);
            }
        }

        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            try
            {
                return _types[serviceType].Values.Select(v => v.Invoke());
            }
            catch(Exception ex)
            {
                throw new ActivationException("Unable to get instance of type '{0}', key '{1}'", ex);
            }
        }
    }
}