using System.Collections.Specialized;

namespace nothinbutdotnetstore.infrastructure
{
    public interface Mapper<Input,Output>
    {
        Output map_from(Input input);
    }
}