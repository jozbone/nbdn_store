using System.Collections.Generic;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.tasks;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.application.model;
using nothinbutdotnetstore.web.infrastructure.frontcontroller;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class ViewMainDepartmentsInTheStoreSpecs
    {
        public abstract class concern : Observes<ApplicationCommand, ViewMainDepartmentsInTheStore>
        {
        }

        [Subject(typeof(ViewMainDepartmentsInTheStore))]
        public class when_displaying_the_set_of_main_departments_in_the_store : concern
        {
            Establish c = () =>
            {
                catalog_tasks = the_dependency<CatalogTasks>();
                department_list = new List<DepartmentItem> {};
                request = an<Request>();
                response_engine = the_dependency<ResponseEngine>();

                catalog_tasks.Stub(x => x.get_the_main_departments()).Return(department_list);
            };

            Because b = () =>
                sut.process(request);

            It should_tell_the_response_engine_to_display_the_list_of_departments =
                () => { response_engine.received(x => x.display(department_list)); };

            protected static Request request;
            protected static IEnumerable<DepartmentItem> department_list;
            protected static CatalogTasks catalog_tasks;
            static ResponseEngine response_engine;
        }
    }
}