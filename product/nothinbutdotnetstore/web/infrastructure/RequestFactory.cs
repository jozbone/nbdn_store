using System.Web;

namespace nothinbutdotnetstore.web.infrastructure
{
    public interface RequestFactory
    {
        Request create_from(HttpContext http_context);
    }
}