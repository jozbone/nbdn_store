using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.web.application.model;

namespace nothinbutdotnetstore.web.tasks.stubs
{
    public class StubDepartmentRepository : DepartmentRepository
    {
        public IEnumerable<DepartmentItem> get_the_main_departments()
        {
            yield return new DepartmentItem {name = "Bakery"};
            yield return new DepartmentItem {name = "Produce"};
            yield return new DepartmentItem {name = "Dairy"};

        }
    }
}