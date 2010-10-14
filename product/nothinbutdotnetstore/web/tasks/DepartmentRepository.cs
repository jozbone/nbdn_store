using System.Collections.Generic;
using nothinbutdotnetstore.web.application.model;

namespace nothinbutdotnetstore.web.tasks
{
    public interface DepartmentRepository
    {
        IEnumerable<DepartmentItem> get_the_main_departments();
        IEnumerable<DepartmentItem> get_the_sub_departments_in(DepartmentItem parent_department);
        IEnumerable<ProductItem> get_the_products_in_a_sub_deparment(DepartmentItem parent_department);
    }
}