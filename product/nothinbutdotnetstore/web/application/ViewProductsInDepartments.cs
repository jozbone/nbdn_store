using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.application.model;
using nothinbutdotnetstore.web.infrastructure.frontcontroller;

namespace nothinbutdotnetstore.web.application
{
    public class ViewProductsInDepartments : ApplicationCommand
    {
        CatalogTasks catalog_tasks;
        ResponseEngine response_engine;


        public ViewProductsInDepartments(CatalogTasks catalog_tasks,
                                            ResponseEngine response_engine)
        {
            this.catalog_tasks = catalog_tasks;
            this.response_engine = response_engine;
        }

        public void process(Request request)
        {
            response_engine.display(catalog_tasks.get_the_products_in(request.map<DepartmentItem>()));
        }
    }
}