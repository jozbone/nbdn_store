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
    public class ViewProductsInADepartmentSpecs
    {
        public abstract class concern : Observes<ApplicationCommand, ViewProductsInDepartments>
        {
        }

        [Subject(typeof(ViewProductsInDepartments))]
        public class when_displaying_all_of_the_products_in_a_sub_department : concern
        {
            Establish c = () =>
            {
                catalog_tasks = the_dependency<CatalogTasks>();
                all_the_products_in_a_department = new List<ProductItem> {};
                department_with_products = new DepartmentItem();
                request = an<Request>();
                response_engine = the_dependency<ResponseEngine>();

                catalog_tasks.Stub(x => x.get_the_products_in(department_with_products)).Return(
                    all_the_products_in_a_department);

                request.Stub(x => x.map<DepartmentItem>()).Return(department_with_products);
            };

            Because b = () =>
                sut.process(request);

            It should_tell_the_response_engine_to_display_the_list_of_products = () =>
                response_engine.received(x => x.display(all_the_products_in_a_department));

            protected static Request request;
            protected static IEnumerable<ProductItem> all_the_products_in_a_department;
            static ResponseEngine response_engine;
            static DepartmentItem department_with_products;
            static CatalogTasks catalog_tasks;
        }
    }
}