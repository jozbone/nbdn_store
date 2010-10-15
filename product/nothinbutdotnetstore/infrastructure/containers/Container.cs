using System;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public class Container
    {
        public static ContainerResolver container_resolver;

        public static DependencyContainer resolve
        {
            get { return container_resolver(); }
        }
    }
}