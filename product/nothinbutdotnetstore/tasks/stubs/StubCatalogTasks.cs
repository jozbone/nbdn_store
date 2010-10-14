using System.Collections.Generic;
using System.Linq;
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
            return
                Enumerable.Range(1, 100).Select(
                    x => new DepartmentItem {name = x.ToString("Subdepartment of the department 0")});
        }

        public IEnumerable<ProductItem> get_the_products_in(DepartmentItem department)
        {
            return
                Enumerable.Range(1, 100).Select(
                    x => new ProductItem {});
        }
    }
}