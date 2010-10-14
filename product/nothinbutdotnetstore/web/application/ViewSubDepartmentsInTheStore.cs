using nothinbutdotnetstore.web.application.model;
using nothinbutdotnetstore.web.infrastructure.frontcontroller;
using nothinbutdotnetstore.web.tasks;

namespace nothinbutdotnetstore.web.application
{
    public class ViewSubDepartmentsInTheStore : ApplicationCommand
    {
        DepartmentRepository department_repository;
        ResponseEngine response_engine;


        public ViewSubDepartmentsInTheStore(DepartmentRepository department_repository,
                                            ResponseEngine response_engine)
        {
            this.department_repository = department_repository;
            this.response_engine = response_engine;
        }

        public void process(Request request)
        {
            response_engine.display(department_repository.get_the_sub_departments_in(request.map<DepartmentItem>()));
        }
    }
}