using System;

namespace nothinbutdotnetstore.web.infrastructure.frontcontroller
{
    public delegate object PageFactory(string path, Type page_type);
}