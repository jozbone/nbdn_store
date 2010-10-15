using System;
using System.Runtime.Serialization;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public class DependencyCreationException :Exception
    {

        public DependencyCreationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public Type type_that_could_not_be_created { get; set; }
    }
}