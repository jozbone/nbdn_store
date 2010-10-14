using System.Collections.Generic;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.tasks.stubs;
using nothinbutdotnetstore.web.infrastructure.frontcontroller;

namespace nothinbutdotnetstore.web.application
{
    public class ViewMainDepartmentsInTheStore : ApplicationCommand
    {
        CatalogTasks catalog_tasks;
        ResponseEngine response_engine;

        public ViewMainDepartmentsInTheStore() : this(new StubCatalogTasks(), new BasicResponseEngine())
        {
        }

        public ViewMainDepartmentsInTheStore(CatalogTasks catalog_tasks, ResponseEngine response_engine)
        {
            this.catalog_tasks = catalog_tasks;
            this.response_engine = response_engine;
        }

        public void process(Request request)
        {
            response_engine.display(catalog_tasks.get_the_main_departments());
        }
    }

}