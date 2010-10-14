using System;
using System.Web;
using nothinbutdotnetstore.web.application.model;

namespace nothinbutdotnetstore.web.infrastructure.frontcontroller.stubs
{
    public class StubRequestFactory : RequestFactory
    {
        public Request create_request_from(HttpContext http_context)
        {
            return new StubRequest();
        }

        class StubRequest : Request
        {
            public InputModel map<InputModel>()
            {
                object department = new DepartmentItem {name = "Parent Department"};
                return (InputModel) department;
            }
        }
    }
}