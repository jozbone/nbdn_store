 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino; 
 using Machine.Specifications.DevelopWithPassion.Extensions;
 using nothinbutdotnetstore.web.infrastructure.frontcontroller;
 using Rhino.Mocks;
 
namespace nothinbutdotnetstore.specs.web
{   
    public class ResponseEngineSpecs
    {
        public abstract class concern : Observes<ResponseEngine,
                                            BasicResponseEngine>
        {
        
        }

        [Subject(typeof(BasicResponseEngine))]
        public class when_displaying_a_view_model : concern
        {

            It should_pass_the_model_data_to_the_view;
            
        }
    }
}
