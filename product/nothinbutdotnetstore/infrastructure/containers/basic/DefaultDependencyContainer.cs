using System;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class DefaultDependencyContainer : DependencyContainer
    {
        DependencyFactoryRegistry dependency_factory_registry;

        public DefaultDependencyContainer(DependencyFactoryRegistry dependency_factory_registry)
        {
            this.dependency_factory_registry = dependency_factory_registry;
        }

        public Dependency an<Dependency>()
        {
            try
            {
                return (Dependency) dependency_factory_registry.get_dependency_factory_for(typeof(Dependency)).create();
            }
            catch(Exception ex)
            {
                var dce = new DependencyCreationException("Could not create the requested Dependancy", ex);
                dce.type_that_could_not_be_created = typeof(Dependency);
                throw dce;
            }
        }
    }
}