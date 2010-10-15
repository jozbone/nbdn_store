using System;
using System.Collections.Generic;
using nothinbutdotnetstore.infrastructure.containers.basic;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public class DefaultDependencyFactoryRegistry : DependencyFactoryRegistry
    {
        IDictionary<Type, DependencyFactory> factories;

        public DefaultDependencyFactoryRegistry(IDictionary<Type, DependencyFactory> factories)
        {
            this.factories = factories;
        }

        public DependencyFactory get_dependency_factory_for(Type dependency_type)
        {
            if(factories.ContainsKey(dependency_type))
            {
                return factories[dependency_type];
            }

            throw new DependencyCreationException(null, dependency_type);
        }
    }
}