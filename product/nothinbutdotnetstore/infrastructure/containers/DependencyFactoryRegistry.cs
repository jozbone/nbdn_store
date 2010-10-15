using System;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public interface DependencyFactoryRegistry
    {
        DependencyFactory get_dependency_factory_for(Type dependency_type);
    }
}