using System;

namespace nothinbutdotnetstore.infrastructure.containers
{
    public class BasicDependencyFactory : DependencyFactory
    {
        Func<object> factory;

        public BasicDependencyFactory(Func<object> factory)
        {
            this.factory = factory;
        }

        public object create()
        {
            return factory();
        }
    }
}