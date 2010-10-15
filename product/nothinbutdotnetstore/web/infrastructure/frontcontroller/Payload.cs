using System.Collections.Specialized;

namespace nothinbutdotnetstore.web.infrastructure.frontcontroller
{
    public interface Payload
    {
        NameValueCollection raw_values { get;}
    }
}