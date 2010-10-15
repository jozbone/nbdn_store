using System;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public class Container
    {
        public static ContainerResolver container_resolver = delegate
        {
            throw new NotImplementedException("This needs to be configured by the startup pipeline"); 
        };

        public static DependencyContainer resolve { get
        {
            throw new NotImplementedException();
        }}
    }
}