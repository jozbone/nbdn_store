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
    public class ViewSubDeparmentsInTheStoreSpecs
    {
        public abstract class concern : Observes<ApplicationCommand, ViewSubDepartmentsInTheStore>
        {
        }

        [Subject(typeof(ViewSubDepartmentsInTheStore))]
        public class when_displaying_all_of_the_subdepartments_in_a_department : concern
        {
            Establish c = () =>
            {
                catalog_tasks = the_dependency<CatalogTasks>();
                all_the_sub_departments_in_a_department = new List<DepartmentItem> {};
                parent_department = new DepartmentItem();
                request = an<Request>();
                response_engine = the_dependency<ResponseEngine>();

                catalog_tasks.Stub(x => x.get_the_sub_departments_in(parent_department)).Return(
                    all_the_sub_departments_in_a_department);

                request.Stub(x => x.map<DepartmentItem>()).Return(parent_department);


            };

            Because b = () =>
                sut.process(request);

            It should_tell_the_response_engine_to_display_the_list_of_departments =
                () => { response_engine.received(x => x.display(all_the_sub_departments_in_a_department)); };

            protected static Request request;
            protected static IEnumerable<DepartmentItem> all_the_sub_departments_in_a_department;
            static ResponseEngine response_engine;
            static DepartmentItem parent_department;
            static CatalogTasks catalog_tasks;
        }
    }
}