using System.Web;
using nothinbutdotnetstore.infrastructure.containers;

namespace nothinbutdotnetstore.web.infrastructure.frontcontroller
{
    public class RequestHandler : IHttpHandler
    {
        RequestFactory request_factory;
        FrontController front_controller;

        public RequestHandler(RequestFactory request_factory, FrontController front_controller)
        {
            this.request_factory = request_factory;
            this.front_controller = front_controller;
        }

        public RequestHandler():this(Container.resolve.an<RequestFactory>(),Container.resolve.an<FrontController>())
        {
        }

        public void ProcessRequest(HttpContext context)
        {
            front_controller.process(request_factory.create_request_from(context));
        }

        public bool IsReusable
        {
            get { return true; }
        }
    }
}