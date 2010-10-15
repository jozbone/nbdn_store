using System;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class DependencyFactoryNotRegisteredException : Exception
    {
        public Type type_that_has_no_factory { get; private set; }

        public DependencyFactoryNotRegisteredException(Type type_that_has_no_factory)
        {
            this.type_that_has_no_factory = type_that_has_no_factory;
        }
    }
}