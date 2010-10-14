using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.application.model;
using nothinbutdotnetstore.web.infrastructure.frontcontroller;
using nothinbutdotnetstore.web.tasks;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
{
    public class ViewProductsInSubDepartmentsSpecs
    {
        public abstract class concern : Observes<ApplicationCommand, ViewProductsInSubDepartments>
        {
        }

        [Subject(typeof(ViewProductsInSubDepartments))]
        public class when_displaying_all_of_the_products_in_a_sub_department : concern
        {
            Establish c = () =>
            {
                department_repository = the_dependency<DepartmentRepository>();
                all_the_products_in_a_department = new List<ProductItem> { };
                parent_category = new DepartmentItem();
                request = an<Request>();
                response_engine = the_dependency<ResponseEngine>();

                department_repository.Stub(x => x.get_the_products_in_a_sub_deparment(parent_category)).Return(
                    all_the_products_in_a_department);

                request.Stub(x => x.map<DepartmentItem>()).Return(parent_category);

            };

            Because b = () =>
                sut.process(request);

            It should_tell_the_response_engine_to_display_the_list_of_products =
                () => { response_engine.received(x => x.display(all_the_products_in_a_department)); };

            protected static Request request;
            protected static IEnumerable<ProductItem> all_the_products_in_a_department;
            static ResponseEngine response_engine;
            static DepartmentItem parent_category;
            static DepartmentRepository department_repository;
        }

        
    }
}
