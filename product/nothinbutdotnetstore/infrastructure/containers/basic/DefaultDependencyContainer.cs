using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class DefaultDependencyContainer : DependencyContainer
    {
        IDictionary<DependencyType, DependencyFactory> dependency_dictionary;

        public DefaultDependencyContainer(IDictionary<DependencyType, DependencyFactory> dependency_dictionary  )
        {
            this.dependency_dictionary = dependency_dictionary;
        }

        public Dependency an<Dependency>()
        {
            foreach(DependencyType dt in dependency_dictionary.Keys)
            {
                if (dt.represents(typeof(Dependency)))
                    return (Dependency)dependency_dictionary[dt].create();
            }
          
            throw new ArgumentException("could not find dependancy");
        }
    }
}