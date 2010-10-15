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
            return (Dependency) dependency_factory_registry.get_dependency_factory_for(typeof(Dependency)).create();
        }
    }
}