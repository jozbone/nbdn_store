using System.Web;

namespace nothinbutdotnetstore.web.infrastructure.frontcontroller
{
    public interface View<ViewModel> : IHttpHandler
    {
        ViewModel model { get; set; }
    }
}