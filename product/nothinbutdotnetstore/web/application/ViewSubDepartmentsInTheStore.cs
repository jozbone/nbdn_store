using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.application.model;
using nothinbutdotnetstore.web.infrastructure.frontcontroller;

namespace nothinbutdotnetstore.web.application
{
    public class ViewSubDepartmentsInTheStore : ApplicationCommand
    {
        CatalogTasks catalog_tasks;
        ResponseEngine response_engine;


        public ViewSubDepartmentsInTheStore(CatalogTasks catalog_tasks,
                                            ResponseEngine response_engine)
        {
            this.catalog_tasks = catalog_tasks;
            this.response_engine = response_engine;
        }

        public ViewSubDepartmentsInTheStore():this(new StubCatalogTasks(),new BasicResponseEngine())
        {
        }

        public void process(Request request)
        {
            response_engine.display(catalog_tasks.get_the_sub_departments_in(request.map<DepartmentItem>()));
        }
    }
}