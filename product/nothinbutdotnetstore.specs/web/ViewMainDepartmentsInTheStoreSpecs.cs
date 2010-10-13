 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.web.application;
 using nothinbutdotnetstore.web.infrastructure.frontcontroller;

namespace nothinbutdotnetstore.specs.web
 {   
     public class ViewMainDepartmentsInTheStoreSpecs
     {
         public abstract class concern : Observes<ApplicationCommand,
                                             ViewMainDepartmentsInTheStore>
         {
        
         }

         [Subject(typeof(ViewMainDepartmentsInTheStore))]
         public class when_observation_name : concern
         {
        
                 
         }
     }
 }
