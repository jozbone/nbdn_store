using System;
using System.Web;

namespace nothinbutdotnetstore.web.infrastructure.frontcontroller
{
    public delegate object PageFactory(string path, Type page_type);
    public delegate HttpContext ContextResolver();
}