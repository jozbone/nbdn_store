using System;

namespace nothinbutdotnetstore.infrastructure.containers.basic
{
    public interface DependencyType
    {
        bool represents(Type type);
    }
}