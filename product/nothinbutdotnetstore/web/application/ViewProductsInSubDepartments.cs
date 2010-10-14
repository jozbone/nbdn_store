using nothinbutdotnetstore.web.application.model;
using nothinbutdotnetstore.web.infrastructure.frontcontroller;
using nothinbutdotnetstore.web.tasks;

namespace nothinbutdotnetstore.web.application
{
    public class ViewProductsInSubDepartments : ApplicationCommand
    {
        DepartmentRepository department_repository;
        ResponseEngine response_engine;


        public ViewProductsInSubDepartments(DepartmentRepository department_repository,
                                            ResponseEngine response_engine)
        {
            this.department_repository = department_repository;
            this.response_engine = response_engine;
        }

        public void process(Request request)
        {
            response_engine.display(department_repository.get_the_products_in_a_sub_deparment(request.map<DepartmentItem>()));
        }
    }
}