using System.Collections.Generic;
using nothinbutdotnetstore.web.application.model;

namespace nothinbutdotnetstore.tasks
{
    public interface CatalogTasks
    {
        IEnumerable<DepartmentItem> get_the_main_departments();
        IEnumerable<DepartmentItem> get_the_sub_departments_in(DepartmentItem parent_department);
        IEnumerable<ProductItem> get_the_products_in(DepartmentItem department);
    }
}