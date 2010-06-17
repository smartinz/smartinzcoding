using System;
using System.ComponentModel;

namespace SpikeRhinoSecurity.Infrastructure
{
    public class NHibernateDynamicProxyTypeDescriptionProvider<T> : TypeDescriptionProvider
    {
        internal NHibernateDynamicProxyTypeDescriptionProvider() : base(TypeDescriptor.GetProvider(typeof(T))) {}

        public override Type GetReflectionType(Type objectType, object instance)
        {
            return base.GetReflectionType(typeof(T), instance);
        }

        public override ICustomTypeDescriptor GetTypeDescriptor(Type objectType, object instance)
        {
            return base.GetTypeDescriptor(typeof(T), instance);
        }
    }
}