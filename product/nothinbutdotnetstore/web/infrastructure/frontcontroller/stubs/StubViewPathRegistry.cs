using System;
using System.Collections.Generic;
using nothinbutdotnetstore.web.application.model;

namespace nothinbutdotnetstore.web.infrastructure.frontcontroller.stubs
{
    public class StubViewPathRegistry : ViewPathRegistry
    {
        public string get_path_to_view_for<ViewModel>()
        {
            if (typeof(ViewModel) == typeof(IEnumerable<DepartmentItem>)) return "~/views/DepartmentBrowser.aspx";
            if (typeof(ViewModel) == typeof(IEnumerable<ProductItem>)) return "~/views/ProductBrowser.aspx";

            throw new NotImplementedException();
        }
    }
}