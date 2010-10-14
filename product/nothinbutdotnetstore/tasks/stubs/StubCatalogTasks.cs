using System;
using System.Collections.Generic;
using nothinbutdotnetstore.web.application.model;

namespace nothinbutdotnetstore.tasks.stubs
{
    public class StubCatalogTasks : CatalogTasks
    {
        public IEnumerable<DepartmentItem> get_the_main_departments()
        {
            yield return new DepartmentItem {name = "Bakery"};
            yield return new DepartmentItem {name = "Produce"};
            yield return new DepartmentItem {name = "Dairy"};
        }

        public IEnumerable<DepartmentItem> get_the_sub_departments_in(DepartmentItem parent_department)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductItem> get_the_products_in(DepartmentItem department)
        {
            throw new NotImplementedException();
        }
    }
}